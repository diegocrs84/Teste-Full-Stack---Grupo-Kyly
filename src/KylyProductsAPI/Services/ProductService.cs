using KylyProductsAPI.Models;
using System.Globalization;
using CsvHelper;

namespace KylyProductsAPI.Services
{
    public interface IProductService
    {
        Task<SearchResult> SearchProductsAsync(string? keyword, int page = 1, int pageSize = 15);
    }

    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly string _csvPath;
        private readonly string _list1Path;
        private readonly string _list2Path;
        private List<Product>? _productsCache;
        private HashSet<string>? _relevanceList1;
        private HashSet<string>? _relevanceList2;

        public ProductService(ILogger<ProductService> logger, IConfiguration configuration)
        {
            _logger = logger;
            var basePath = configuration["DataPath:BasePath"] ?? Directory.GetCurrentDirectory();
            
            _csvPath = Path.Combine(basePath, "sample_db.csv");
            _list1Path = Path.Combine(basePath, "lista_relevancia_1.txt");
            _list2Path = Path.Combine(basePath, "lista_relevancia_2.txt");
        }

        public async Task<SearchResult> SearchProductsAsync(string? keyword, int page = 1, int pageSize = 15)
        {
            try
            {
                // Carrega dados se ainda não foram carregados
                await LoadDataAsync();

                // Normaliza a busca
                var searchKeyword = (keyword ?? string.Empty).ToUpperInvariant().Trim();

                // Filtra produtos
                var filtered = _productsCache!
                    .Where(p => 
                        string.IsNullOrEmpty(searchKeyword) ||
                        p.ProductCode.ToUpperInvariant().Contains(searchKeyword) ||
                        p.ProductDescription.ToUpperInvariant().Contains(searchKeyword) ||
                        p.ColorDescription.ToUpperInvariant().Contains(searchKeyword) ||
                        p.SizeDescription.ToUpperInvariant().Contains(searchKeyword)
                    )
                    .OrderByDescending(p => p.RelevancePriority)
                    .ThenBy(p => p.ProductCode)
                    .ToList();

                var totalCount = filtered.Count;
                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                // Valida página
                if (page < 1) page = 1;
                if (page > totalPages && totalPages > 0) page = totalPages;

                // Pagina resultados
                var items = filtered
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return new SearchResult
                {
                    Items = items,
                    TotalCount = totalCount,
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalPages = totalPages
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar produtos");
                throw;
            }
        }

        private async Task LoadDataAsync()
        {
            if (_productsCache != null)
                return;

            await Task.Run(() =>
            {
                // Carrega listas de relevância
                _relevanceList1 = LoadRelevanceList(_list1Path);
                _relevanceList2 = LoadRelevanceList(_list2Path);

                // Carrega produtos do CSV
                _productsCache = new List<Product>();

                using (var reader = new StreamReader(_csvPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.Configuration.Delimiter = ";";
                    csv.Read(); // Pula header
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        var product = new Product
                        {
                            Id = csv.GetField("Id") ?? string.Empty,
                            ProductCode = csv.GetField("Produto") ?? string.Empty,
                            ProductDescription = csv.GetField("DescProduto") ?? string.Empty,
                            ColorCode = csv.GetField("Cor") ?? string.Empty,
                            ColorDescription = csv.GetField("DescCor") ?? string.Empty,
                            SizeCode = csv.GetField("Tamanhho") ?? csv.GetField("Tamanho") ?? string.Empty,
                            SizeDescription = csv.GetField("DescTamanho") ?? string.Empty
                        };

                        // Define prioridade
                        if (_relevanceList1?.Contains(product.ProductCode) == true)
                            product.RelevancePriority = 1;
                        else if (_relevanceList2?.Contains(product.ProductCode) == true)
                            product.RelevancePriority = 2;

                        _productsCache.Add(product);
                    }
                }

                _logger.LogInformation($"Carregados {_productsCache.Count} produtos do CSV");
            });
        }

        private HashSet<string> LoadRelevanceList(string filePath)
        {
            if (!File.Exists(filePath))
                return new HashSet<string>();

            var items = new HashSet<string>();
            foreach (var line in File.ReadAllLines(filePath))
            {
                var item = line.Trim();
                if (!string.IsNullOrEmpty(item))
                    items.Add(item);
            }
            return items;
        }
    }
}

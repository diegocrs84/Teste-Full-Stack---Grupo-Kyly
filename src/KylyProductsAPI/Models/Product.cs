namespace KylyProductsAPI.Models
{
    public class Product
    {
        public string Id { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ColorCode { get; set; } = string.Empty;
        public string ColorDescription { get; set; } = string.Empty;
        public string SizeCode { get; set; } = string.Empty;
        public string SizeDescription { get; set; } = string.Empty;
        public int RelevancePriority { get; set; } = 0; // 0 = sem prioridade, 1 = lista 1, 2 = lista 2
    }
}

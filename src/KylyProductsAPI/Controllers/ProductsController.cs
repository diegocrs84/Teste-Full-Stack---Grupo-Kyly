using KylyProductsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KylyProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? keyword, [FromQuery] int page = 1)
        {
            try
            {
                if (page < 1) page = 1;

                _logger.LogInformation($"Busca iniciada - Keyword: {keyword}, Page: {page}");
                
                var result = await _productService.SearchProductsAsync(keyword, page, 15);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro na busca de produtos");
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { message = "Erro ao buscar produtos" });
            }
        }
    }
}

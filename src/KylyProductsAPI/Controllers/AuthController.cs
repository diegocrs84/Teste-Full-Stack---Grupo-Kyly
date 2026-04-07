using KylyProductsAPI.Models;
using KylyProductsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KylyProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        /// <summary>
        /// Autentica um usuário e retorna um token JWT
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /api/auth/login
        ///     {
        ///         "username": "demo",
        ///         "password": "demo123"
        ///     }
        /// </remarks>
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Usuário e senha são obrigatórios" });
            }

            var response = _authService.Authenticate(request);
            
            if (!response.Success)
            {
                return Unauthorized(response);
            }

            _logger.LogInformation($"Usuário {request.Username} autenticado com sucesso");
            return Ok(response);
        }
    }
}

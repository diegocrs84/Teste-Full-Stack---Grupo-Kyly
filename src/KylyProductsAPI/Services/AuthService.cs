using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KylyProductsAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace KylyProductsAPI.Services
{
    public interface IAuthService
    {
        AuthResponse Authenticate(AuthRequest request);
    }

    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IConfiguration configuration, ILogger<AuthService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public AuthResponse Authenticate(AuthRequest request)
        {
            try
            {
                // Aqui você pode adicionar validação contra um banco de dados
                // Para este exemplo, usaremos credenciais simples
                var validUsername = _configuration["Auth:Username"] ?? "demo";
                var validPassword = _configuration["Auth:Password"] ?? "demo123";

                if (request.Username != validUsername || request.Password != validPassword)
                {
                    _logger.LogWarning($"Tentativa de login inválida para usuário: {request.Username}");
                    return new AuthResponse
                    {
                        Success = false,
                        Message = "Usuário ou senha inválidos"
                    };
                }

                var token = GenerateToken(request.Username);

                return new AuthResponse
                {
                    Success = true,
                    Message = "Autenticado com sucesso",
                    Token = token
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro na autenticação");
                return new AuthResponse
                {
                    Success = false,
                    Message = "Erro ao processar autenticação"
                };
            }
        }

        private string GenerateToken(string username)
        {
            var jwtSecret = _configuration["Jwt:Secret"] ?? "sua_chave_secreta_super_segura_e_longa_aqui";
            var jwtExpireMinutes = int.Parse(_configuration["Jwt:ExpireMinutes"] ?? "60");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(jwtExpireMinutes),
                Issuer = "KylyProductsAPI",
                Audience = "KylyProductsWeb",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

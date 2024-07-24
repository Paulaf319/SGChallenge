using Microsoft.IdentityModel.Tokens;
using SGChallengeApplication.Data.Dtos;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SGChallengeApplication.Repositories
{
    public class UtilidadesRepo : IUtilidadesRepo
    {
        private readonly IConfiguration _configuration;
        private readonly ChallengeSgContext _context;

        public UtilidadesRepo(IConfiguration configuration, ChallengeSgContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public bool BuscarUsuario (LoginDTO login)
        {
            var user = (from u in _context.Usuarios
                       join c in _context.Clientes on u.Id equals c.IdUsuario

                       where u.NombreUsuario == login.NombreUsuario &&
                             u.Contrasenia == EncriptarSHA256(login.Contrasenia) &&
                             c.Mail == login.Mail

                       select u).FirstOrDefault();

            if(user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string EncriptarSHA256(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computar el hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

                // Convertir el array de bytes a string
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public string GenerarJWT(LoginDTO login)
        {
            //crear la informacion del usuario para token
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, login.NombreUsuario),
                new Claim(ClaimTypes.Email, login.Mail)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //crear detalle del token
            var jwtConfig = new JwtSecurityToken(claims: userClaims, expires: DateTime.UtcNow.AddMinutes(10), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }

        public LoginDTO? Autenticar(ClaimsIdentity claimsIdentity)
        {
            if (claimsIdentity != null)
            {
                var userIdClaim = claimsIdentity.FindFirst((ClaimTypes.NameIdentifier));
                var emailClaim = claimsIdentity.FindFirst(ClaimTypes.Email);

                string userId = userIdClaim.Value;
                string mail = emailClaim.Value;

                return new LoginDTO
                {
                    NombreUsuario = userId,
                    Mail = mail
                };
            }

            return null;
        }


    }
}

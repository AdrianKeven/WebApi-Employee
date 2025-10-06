using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi_Employee.Domain.Model.EmployeeAggregate;

namespace WebApi_Employee.Application.Services
{
    public class TokenServices
    {
        // Gera um token JWT para o funcionário fornecido (Codigo padrao)
        public static object GenerateToken(Employee employee)
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret);
            var tokenConfig = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim("employeeId", employee.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature
            )};

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenHash = tokenHandler.WriteToken(token);

            return new { token = tokenHash };
        }
    }
}

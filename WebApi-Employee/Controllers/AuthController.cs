using Microsoft.AspNetCore.Mvc;
using WebApi_Employee.Application.Services;

namespace WebApi_Employee.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        // POST api/v1/auth => Autentica o usuário e retorna um token JWT
        // Usuario e senha fixos: admin/admin, apenas para fins de demonstração
        [HttpPost]
        public IActionResult Auth(String username, String password) 
        { 
            if (username == "admin" && password == "admin") 
            {
                var token = TokenServices.GenerateToken(new Domain.Model.Employee("admin", 0, ""));
                return Ok(token);
            }

            return Unauthorized("Usuario ou senha invalidos");  
        }
    }
}

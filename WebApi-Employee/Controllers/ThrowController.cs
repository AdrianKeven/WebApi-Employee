using Microsoft.AspNetCore.Mvc;

namespace WebApi_Employee.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ThrowController : Controller
    {
        //Rota para redirecionar erros em desenvolvilmento (mostra muitas informacoes pro dev)
        [Route("error")]
        public IActionResult HandleError() =>
           Problem();

        //Rota para redirecionar erros em producao (mostra poucas informacoes pro usuario)
        [Route("error-development")]
        public IActionResult HandleErrorDevelopment(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName == "Development")
            {
                var exceptionHandlerFeature =
                    HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                return Problem(
                    detail: exceptionHandlerFeature?.Error.StackTrace,
                    title: exceptionHandlerFeature?.Error.Message);
            }
            return NotFound();
        }

    }
}

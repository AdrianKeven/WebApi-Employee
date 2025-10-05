using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi_Employee.Application.ViewModel;
using WebApi_Employee.Domain.Model;

namespace WebApi_Employee.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        // POST api/v1/employee => Adiciona um novo funcionário
        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeViewModel)
        {
            var photoPath = Path.Combine("Storage", employeeViewModel.Photo.FileName);

            using (var stream = new FileStream(photoPath, FileMode.Create))
            {
                employeeViewModel.Photo.CopyTo(stream);
            }

            var employee = new Employee(employeeViewModel.Name, employeeViewModel.Age, photoPath);
            _employeeRepository.Add(employee);
            return Ok();
        }

        // POST api/v1/employee/{id}/download => Baixa a foto do funcionário
        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null || string.IsNullOrEmpty(employee.photo))
            {
                _logger.LogError("Erro funcionario nao encontrado, foto nula");
                return NotFound();

            } 
            else if (!System.IO.File.Exists(employee.photo))
            {
                _logger.LogError("Foto nao existe no sistema");
                return NotFound();
            }

                var photoBytes = System.IO.File.ReadAllBytes(employee.photo);
            var fileName = Path.GetFileName(employee.photo);
            return File(photoBytes, "image/png", fileName);
        }

        // GET api/v1/employee => Retorna a lista de funcionários
        [Authorize]
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            var employess = _employeeRepository.Get(pageNumber,pageQuantity);

            return Ok(employess);
        }

        // GET api/v1/employee/{id} => Retorna um funcionário pelo ID
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(int id)
        {
            var employee = _employeeRepository.Get(id);
            var employeeDto = _mapper.Map<Domain.DTOs.EmployeeDTO>(employee);

            if (employeeDto == null)
            {
                return NotFound();
            }

            return Ok(employeeDto);
        }
    }
}

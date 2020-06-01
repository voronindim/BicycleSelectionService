using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Specifications : Controller
    {
        private readonly ISpecificationService _specificationService;

        public Specifications(ISpecificationService specificationService)
        {
            _specificationService = specificationService;
        }
        
        [HttpGet("get-specifications")]
        
        public IActionResult GetSpecifications()
        {
            return Ok(_specificationService.GetSpecifications());
        }
    }
}
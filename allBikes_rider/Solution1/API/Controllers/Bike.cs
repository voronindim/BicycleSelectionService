using System;
using BLL.DTO.DTOModels;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bike : Controller
    {
        private readonly IBikeService _bikeService;

        public Bike(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        
        
        [HttpPost("create-bike")]
        public IActionResult createBike([FromForm]CreateBikeModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bikeService.CreateBike(model);
                    return Ok(true);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest("Ошибка входных данных");
        }

        [HttpGet("get-bikes")]
        public IActionResult GetBikes()
        {
            return Ok(_bikeService.GetBikes());

        }
        
        [HttpGet("get-bikes-by-filter")]
        public IActionResult GetBikesByFilter(string name = null, int? weight = null, int? speed = null, double? capacity = null, double? radius = null, double? height = null)
        { 
            return Ok(_bikeService.GetBikesByFilter(name, weight, speed, capacity, radius, height));
        }
        
        [HttpGet("get-bike-by-id/{id}")]
        public IActionResult GetBike(int id)
        {
            return Ok(_bikeService.GetBikeById(id));
        }
        
                

    }
}
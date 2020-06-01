using System;
using BLL.DTO.DTOModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Comment : Controller
    {
        private readonly ICommentsServices _commentsServices;

        public Comment(ICommentsServices commentsServices)
        {
            this._commentsServices = commentsServices;
        }

        [HttpPost("create-comment")]
        public IActionResult createComment(CreateCommentModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _commentsServices.CreateComment(model);
                    return Ok(true);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest("Ошибка входных данных");
        }

        [HttpGet("get-comments")]
        public IActionResult GetComments()
        {
            return Ok(_commentsServices.GetComments());
        }
        
        [HttpGet("get-comments-by-bikeId/{bikeId}")]
        public IActionResult GetCommentsByBikeId(int bikeId)
        {
            return Ok(_commentsServices.GetCommentsByBikeId(bikeId));
        }
    }
}
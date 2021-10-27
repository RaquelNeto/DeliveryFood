using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Feedback;
using deliveryFoodAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private IFeedbackService _feedbackService;
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbcontext;
        public FeedbackController(IFeedbackService feedbackService, IConfiguration configuration, ApplicationDbContext dbcontext)
        {
            this._feedbackService = feedbackService;
            this._configuration = configuration;
            _dbcontext = dbcontext;
        }



        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddFeedback([FromBody] AddFeedbackModel model, string orderID)
        {
            if (ModelState.IsValid)
            {
                var result = await _feedbackService.AddFeedback(model,orderID);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Ingredient creation failed! Please check user details and try again." });
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateFeedback([FromBody] UpdateFeedbackModel model, string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _feedbackService.UpdateFeedback(model, id);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Update ingredient failed! Please check user details and try again." });
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteFeedback(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _feedbackService.RemoveFeedback(id);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Delete type failed! Please check user details and try again." });
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetFeedback(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _feedbackService.GetFeedback(id);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get type failed! Please check user details and try again." });
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetFeedbacksall()
        {
            if (ModelState.IsValid)
            {
                var result = _feedbackService.GetAllFeedback();
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get type failed! Please check user details and try again." });
        }

    }
}

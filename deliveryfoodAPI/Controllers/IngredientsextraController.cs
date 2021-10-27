using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.IngredientExtra;
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
    public class IngredientsextraController : ControllerBase
    {
        private IIngredientsExtraServices _ingredientsextraServices;
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbcontext;
        public IngredientsextraController(IIngredientsExtraServices ingredientsextraServices, IConfiguration configuration, ApplicationDbContext dbcontext)
        {
            this._ingredientsextraServices = ingredientsextraServices;
            this._configuration = configuration;
            _dbcontext = dbcontext;
        }


        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddIngredientextra([FromBody] AddIngredientExtraModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _ingredientsextraServices.AddIngredient(model);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Ingredient creation failed! Please check user details and try again." });
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateIngredientextra([FromBody] UpdateIngredientExtraModel model, string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _ingredientsextraServices.UpdateIngredient(model, id);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Update ingredient failed! Please check user details and try again." });
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteIngredientextra(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _ingredientsextraServices.RemoveIngredient(id);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Delete type failed! Please check user details and try again." });
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetIngredientextra(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _ingredientsextraServices.GetIngredient(id);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get type failed! Please check user details and try again." });
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetIngredientextrasall()
        {
            if (ModelState.IsValid)
            {
                var result = _ingredientsextraServices.GetAllIngredients();
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get type failed! Please check user details and try again." });
        }
    }
}

using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Ingredients;
using deliveryFoodAPI.Models.Product;
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
    public class IngredientsController : ControllerBase
    {
        private IIngredientsServices _ingredientsServices;
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbcontext;
        public IngredientsController(IIngredientsServices ingredientsServices, IConfiguration configuration, ApplicationDbContext dbcontext)
        {
            this._ingredientsServices = ingredientsServices;
            this._configuration = configuration;
            _dbcontext = dbcontext;
        }


        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddIngredient([FromBody] AddIngredientModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _ingredientsServices.AddIngredient(model);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Ingredient creation failed! Please check user details and try again." });
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateIngredient([FromBody] UpdateIngredient model, string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _ingredientsServices.UpdateIngredient(model , id);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Update ingredient failed! Please check user details and try again." });
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteIngredient(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _ingredientsServices.RemoveIngredient(id);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Delete type failed! Please check user details and try again." });
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetIngredient(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _ingredientsServices.GetIngredient(id);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get type failed! Please check user details and try again." });
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetIngredientsall()
        {
            if (ModelState.IsValid)
            {
                var result =  _ingredientsServices.GetAllIngredients();
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get type failed! Please check user details and try again." });
        }
    }
}

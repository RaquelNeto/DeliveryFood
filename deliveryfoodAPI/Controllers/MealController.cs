using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.IngredientExtra;
using deliveryFoodAPI.Models.Meal;
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
    public class MealController : ControllerBase
    {
        private IMealServices _mealService;
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbcontext;
        public MealController(IMealServices mealService, IConfiguration configuration, ApplicationDbContext dbcontext)
        {
            this._mealService = mealService;
            this._configuration = configuration;
            _dbcontext = dbcontext;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddMeal([FromBody] AddMealModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mealService.AddMeal(model);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Add Meal creation failed! Please check user details and try again." });
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateMeal([FromBody] UpdateMealModel model,string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _mealService.UpdateMeal(model,id);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Update meal failed! Please check user details and try again." });
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteMeal(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _mealService.RemoveMeal(id);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Delete meal failed! Please check user details and try again." });
        }




        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetMeal(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _mealService.GetMeal(id);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get type failed! Please check user details and try again." });
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetallMeal()
        {
            if (ModelState.IsValid)
            {
                var result =  _mealService.GetAllMeals();
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get type failed! Please check user details and try again." });
        }


        [HttpPost]
        [Route("addingredients")]
        public async Task<IActionResult> AddingredientsMeal([FromBody] AddMealIngredients model,string mealID, string ingredientID )
        {
            if (ModelState.IsValid)
            {
                var result = await _mealService.AddMealIngredients(model,mealID,ingredientID);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Add Meal creation failed! Please check user details and try again." });
        }


        [HttpDelete]
        [Route("deleteingredients")]
        public async Task<IActionResult> DeleteMealingredients(string mealID, string ingredientID)
        {
            if (ModelState.IsValid)
            {
                var result = await _mealService.RemoveMealIngredient(mealID,ingredientID);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Delete meal failed! Please check user details and try again." });
        }

        [HttpGet]
        [Route("getallingredients")]
        public async Task<IActionResult> GetallIngredients(string mealID)
        {
            if (ModelState.IsValid)
            {
                var result = _mealService.GetAllIngredients(mealID);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get type failed! Please check user details and try again." });
        }

    }
}

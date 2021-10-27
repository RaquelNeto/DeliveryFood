using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Order;
using deliveryFoodAPI.Models.OrderProducts;
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
    public class OrderController : ControllerBase
    {

        private IOrderServices _orderService;
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbcontext;
        public OrderController(IOrderServices orderService, IConfiguration configuration, ApplicationDbContext dbcontext)
        {
            this._orderService = orderService;
            this._configuration = configuration;
            _dbcontext = dbcontext;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AdddOrder([FromBody] AddOrderModel model, string userID)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.AddOrder(model,userID);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Employee creation failed! Please check user details and try again." });
        }

        [HttpPost]
        [Route("addmealorder")]
        public async Task<IActionResult> AddmealOrder([FromBody] AddMealOrderModel model, string mealID, string orderId)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.AddMealOrder(model, mealID, orderId);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Employee creation failed! Please check user details and try again." });
        }

        [HttpPost]
        [Route("addingredientmeal")]
        public async Task<IActionResult> Addingredientmeal(string ingredientID, string mealID)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.AddIngredientMeal(ingredientID, mealID);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Employee creation failed! Please check user details and try again." });
        }

        

        [HttpDelete]
        [Route("removeingredientsmeal")]
        public async Task<IActionResult> Removeingredientmeal(string ingredientID, string mealID)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.RemoveingredientMeal( ingredientID,  mealID);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteOrder(string orderID)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.RemoveOrder(orderID);

                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }

        [HttpDelete]
        [Route("deletemealorder")]
        public async Task<IActionResult> DeletemealOrder(string mealID)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.RemoveMealOrder(mealID);

                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }

        [HttpDelete]
        [Route("deleteingredientextra")]
        public async Task<IActionResult> Deleteingredientextra(string ingredientID, string orderID)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.RemovengredientExtra(ingredientID,orderID);

                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }



        [HttpPut]
        [Route("update")]

        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderModel model, string orderID)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.UpdateOrder(model, orderID);

                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }

        [HttpPost]
        [Route("addingredientextra")]
        public async Task<IActionResult> Addingredientextra(string ingredientID, string orderID)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.AddIngredientExtra(ingredientID, orderID);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Employee creation failed! Please check user details and try again." });
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetOrder(string orderID)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.GetOrder(orderID);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }

        [HttpGet]
        [Route("getallmealorder")]
        public async Task<IActionResult> GetAllMealsOrder(string orderID)
        {
            if (ModelState.IsValid)
            {
                var result =  _orderService.GetAllMealsOrder(orderID);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }
        [HttpGet]
        [Route("getmeal")]
        public async Task<IActionResult> GetMeal(string mealID)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.GetMeal(mealID);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }

        [HttpGet]
        [Route("getallingredientsmeal")]
        public async Task<IActionResult> GetAllingredientsMeal(string mealID)
        {
            if (ModelState.IsValid)
            {
                var result =  _orderService.GetAllingredientsMeal(mealID);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }

        [HttpGet]
        [Route("getallingredientsExtra")]
        public async Task<IActionResult> GetIngredientsExtra(string orderID)
        {
            if (ModelState.IsValid)
            {
                var result = _orderService.GetIngredientsExtra(orderID);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }

    }
}









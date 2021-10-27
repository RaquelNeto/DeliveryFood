using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Deliveryman;
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
    public class DeliverymanController : ControllerBase
    {
        private IDeliverymanServices _deliverymanServices;
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbcontext;
        public DeliverymanController(IDeliverymanServices deliverymanServices, IConfiguration configuration, ApplicationDbContext dbcontext)
        {
            this._deliverymanServices = deliverymanServices;
            this._configuration = configuration;
            _dbcontext = dbcontext;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Adddeliveryman([FromBody] AddDeliverymanModel  model){
            if (ModelState.IsValid)
            {
                var result = await _deliverymanServices.AddDeliveryman(model);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Employee creation failed! Please check user details and try again." });
        }



        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetEmployee( string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _deliverymanServices.GetDeliveryman(id);
                if (result!=null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteEmployee(string id )
        {
            if (ModelState.IsValid)
            {
                var result = await _deliverymanServices.RemoveDeliveryman(id);
               
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }

        [HttpPut]
        [Route("update")]

        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateDeliverymanModel model , string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _deliverymanServices.UpdateDeliveryman(model,id);

                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get employee failed! Please check user details and try again." });
        }

    }
}

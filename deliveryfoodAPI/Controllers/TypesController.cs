using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Types;
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
    public class TypesController : ControllerBase
    {
        private ITypesService _typesServices;
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbcontext;
        public TypesController(ITypesService typesServices, IConfiguration configuration, ApplicationDbContext dbcontext)
        {
            this._typesServices = typesServices;
            this._configuration = configuration;
            _dbcontext = dbcontext;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Addtype([FromBody] AddTypesModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _typesServices.AddType(model);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Type creation failed! Please check user details and try again." });
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateType([FromBody] UpdateTypesModel model,string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _typesServices.UpdateType(model,id);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Update type failed! Please check user details and try again." });
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteType(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _typesServices.RemoveType(id);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Delete type failed! Please check user details and try again." });
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetType(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _typesServices.GetType(id);
                if (result!=null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get type failed! Please check user details and try again." });
        }
    }
}

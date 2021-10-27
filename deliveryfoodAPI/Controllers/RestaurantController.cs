using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Restaurant;
using deliveryFoodAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantServices _restaurantServices;
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbcontext;
        private IFileService _fileservice;
        public RestaurantController(IRestaurantServices restaurantServices, IFileService fileService, IConfiguration configuration, ApplicationDbContext dbcontext)
        {
            this._restaurantServices = restaurantServices;
            this._configuration = configuration;
            this._dbcontext = dbcontext;
            this._fileservice = fileService;
        }


        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRestaurant([FromBody] CreateRestaurantModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _restaurantServices.AddRestaurant(model);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Restaurant creation failed! Please check user details and try again." });
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> getRestaurant(string id)
        {
           
                var result = await _restaurantServices.GetRestaurant(id);
                if (result!=null)
                {
                    return Ok(result);
                }
           
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Get restaurant failed! Please check user details and try again." });
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteRestaurant(string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _restaurantServices.RemoveRestaurant(id);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Restaurant delete failed! Please check user details and try again." });
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateRestaurant([FromBody] UpdateRestaurantModel model, string id)
        {
            if (ModelState.IsValid)
            {
                var result = await _restaurantServices.UpdateRestaurant(model,id);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Restaurant Update failed! Please check user details and try again." });
        }

        [HttpPost("uploadrestaurant")]
        public async Task<IActionResult> UploadRestaurant(string id)
        {
            var restaurants = _dbcontext.restaurants.Where(x => x.id == id).First();


            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Restaurant");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                string[] files = System.IO.Directory.GetFiles(pathToSave, "*");
                foreach (var i in files)
                {
                    if (id != null && i != null && i.Split("\\").Last().Split(".").First() == id && i.Length > 0)
                    {
                        System.IO.File.Delete(i);

                    }
                }

                if (file.Length > 0)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());
                    var extensao = filename.Replace("\"", " ").Trim().Split(".").Last();
                    var filename_ = filename.Replace("\"", " ").Trim().Split(".").First();
                    string newName = _fileservice.newNameFiles(filename_, extensao, id);
                    var fullName = pathToSave + "/" + newName;

                    restaurants.photo = newName;
                    _dbcontext.Update(restaurants);
                    await _dbcontext.SaveChangesAsync();
                    using (var stream = new FileStream(fullName, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok(new Response { Status = "Success", Message = "Upload successfully!" });
            }
            catch (System.Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Falhou {ex.Message}");

            }




        }


    }
}

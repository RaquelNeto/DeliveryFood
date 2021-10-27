using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Entities;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Users;
using deliveryFoodAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private IFileService _fileservice;
        private IAuthenticateServices _authenticateServices;
        private ApplicationDbContext _dbcontext;
        public AuthenticateController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IFileService fileService, IAuthenticateServices authenticateServices, ApplicationDbContext dbContext)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._configuration = configuration;
            this._fileservice = fileService;
            this._authenticateServices = authenticateServices;
            this._dbcontext = dbContext;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                if(_roleManager.Roles.Count() == 0)
                {
                    var _result = await _authenticateServices.CreateRole();
                    if (!_result.isSuccess)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
                    }
                }
                var result = await _authenticateServices.RegistarUserAsync(model);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
        }
       
        [HttpGet("perfil")]
        public async Task<IActionResult> getId(string id)
        {

            var user = await _authenticateServices.GetUserAsync(id);
            if (user == null)
            {
                return BadRequest("Utilizador não encontrado");
            }
            return Ok(user);
        }



        [HttpPost]
        [Route("registeraadmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_roleManager.Roles.Count() == 0)
                {
                    var _result = await _authenticateServices.CreateRole();
                    if (!_result.isSuccess)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
                    }
                }
                var result = await _authenticateServices.RegistarAdminAsync(model);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
        }



        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticateServices.LoginUserAsync(model);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return Unauthorized();

        }


        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserModel model, string id)
        {
            var result = await _authenticateServices.UpdateUserAsync(id, model);

            if (!result.isSuccess)
            {
                return BadRequest(result); // 400
            }


            return Ok(result); // 200


        }


        [HttpPost("uploadperfil")]
        public async Task<IActionResult> Upload(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Perfil");
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

                    user.Photo = newName;
                    await _userManager.UpdateAsync(user);
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


        [HttpGet("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Email not confirmed! " });

            var result = await _authenticateServices.ConfirmarEmailAsync(userId, token);

            if (result.isSuccess)
            {
                return Ok(new Response { Status = "Success", Message = "Email confirmed successfully!" , isSuccess= true });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Email not confirmed! " });
        }

        [HttpPost("forgetpassword")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
                return NotFound();


            var result = await _authenticateServices.ForgetPasswordAsync(model);

            if (result.isSuccess)
                return Ok(result); // 200

            return BadRequest(result); // 400
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model, string email, string token)
        {

            if (ModelState.IsValid)
            {

                var result = await _authenticateServices.ResetPasswordAsync(model, token, email);

                if (result.isSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Alguns campos estão inválidos!");
        }

    }
}

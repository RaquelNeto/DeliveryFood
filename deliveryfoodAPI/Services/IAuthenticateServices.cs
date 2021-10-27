using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Entities;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Services
{
    public interface IAuthenticateServices
    {
        Task<Response> CreateRole();
        Task<Response> RegistarUserAsync(RegisterUserModel model);
        Task<ResponseToken> LoginUserAsync(LoginUserModel model);
        Task<GetUserModel> GetUserAsync(string id);
        Task<Response> UpdateUserAsync(string id,UpdateUserModel model);
        Task<Response> ConfirmarEmailAsync(string id, string token);

        Task<Response> ForgetPasswordAsync(ForgetModel model);

        Task<Response> ResetPasswordAsync(ResetPasswordModel model, string token, string email);

        Task<Response> RegistarAdminAsync(RegisterUserModel model);







    }
    public class AuthenticateServices : IAuthenticateServices

        
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;
        private ApplicationDbContext _dbContext;

        public AuthenticateServices(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMailService mailService, ApplicationDbContext dbContext)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._configuration = configuration;
            this._mailService = mailService;
            this._dbContext = dbContext;

        }



        public async Task<Response> CreateRole() {


            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            else
                return new Response
                {
                    Status = "Error",
                    Message = "Role creation Erroe!",
                    isSuccess = false
                };
            if (!await _roleManager.RoleExistsAsync("User"))
                await _roleManager.CreateAsync(new IdentityRole("User"));
            else
                return new Response
                {
                    Status = "Error",
                    Message = "Role creation Erroe!",
                    isSuccess = false
                };
            if (!await _roleManager.RoleExistsAsync("Employee"))
                await _roleManager.CreateAsync(new IdentityRole("Employee"));
            else
                return new Response
                {
                    Status = "Error",
                    Message = "Role creation Erroe!",
                    isSuccess = false
                };

            return new Response
            {
                Status = "Success",
                Message = "Role create!",
                isSuccess = true
            };
        }

        public async Task<Response> RegistarUserAsync(RegisterUserModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists == null)
            {
                User user = new User
                {
                    Email = model.Email,
                    Name = model.Name,
                    PhoneNumber=model.phonenumber,
                    UserName = model.Email,  
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Created_at =DateTime.Now,
                    NIF=model.nif
                  

                };
               

                if (model.Password == model.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(user, model.Password);
                 
                    
                }
                else
                {
                    return new Response
                    {
                        Status = "Error",
                        Message = "Password don't match!",
                        isSuccess = false
                    };
                }

                if (await _roleManager.RoleExistsAsync("User"))
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
                else
                {
                    return new Response
                    {
                        Status = "Error",
                        Message = "Don't exist roles!",
                        isSuccess = false
                    };
                }





                var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                string url = $"{_configuration["AppUrl"]}/api/Authenticate/confirmemail?userid={user.Id}&token={validEmailToken}";

                await _mailService.SendEmailAsync(user.Email, "Confirma o teu email", $"<h1>Bem-vindo ao Delivery Food</h1>" +
                    $"<p>Por favor confirma o teu email <a href='{url}'>Clique aqui</a></p>");




                return new Response
                {
                    Status = "Success",
                    Message = "User Register!",
                    isSuccess = true
                };
            }
            return new Response
            {
                Status = "Error",
                Message = "User already exists!",
                isSuccess = false
            };


        }

        public async Task<Response> RegistarAdminAsync(RegisterUserModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists == null)
            {
                User user = new User
                {
                    Email = model.Email,
                    Name = model.Name,
                    UserName = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Created_at = DateTime.Now,


                };


                if (model.Password == model.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(user, model.Password);


                }
                else
                {
                    return new Response
                    {
                        Status = "Error",
                        Message = "Password don't match!",
                        isSuccess = false
                    };
                }

                if (await _roleManager.RoleExistsAsync("Admin"))
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    return new Response
                    {
                        Status = "Error",
                        Message = "Don't exist roles!",
                        isSuccess = false
                    };
                }





                var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                string url = $"{_configuration["AppUrl"]}/api/Authenticate/confirmemail?userid={user.Id}&token={validEmailToken}";

                await _mailService.SendEmailAsync(user.Email, "Confirma o teu email", $"<h1>Bem-vindo ao Delivery Food</h1>" +
                    $"<p>Por favor confirma o teu email <a href='{url}'>Clique aqui</a></p>");

                OwnerRestaurant owner = new OwnerRestaurant
                {
                    userID = user.Id
                };
                _dbContext.ownerRestaurants.Add(owner);
                var __result = await _dbContext.SaveChangesAsync();
                if(__result <=0)
                {
                    return new Response
                    {
                        Status = "Error",
                        Message = "Something wrong!",
                        isSuccess = false
                    };
                }



                return new Response
                {
                    Status = "Success",
                    Message = "User Register!",
                    isSuccess = true
                };
            }
            return new Response
            {
                Status = "Error",
                Message = "User already exists!",
                isSuccess = false
            };


        }

        public async Task<ResponseToken> LoginUserAsync(LoginUserModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password) && user.EmailConfirmed)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
               

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                return (new ResponseToken
                {
                    id= user.Id,
                    role_name = userRoles.First() ,
                    email= user.Email,
                    photo=user.Photo,
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return null;
        }

        public async Task<Response> ConfirmarEmailAsync(string id, string token)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return new Response
                {
                    Status = "Error",
                    Message = "User don't match!",
                    isSuccess = false
                };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
                return new Response
                {
                    Status = "Success",
                    Message = "User confirm!",
                    isSuccess = true
                };

            return new Response
            {
                Status = "Error",
                Message = "Email not confirm!",
                isSuccess = false
            };
        }


        public async Task<GetUserModel> GetUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            GetUserModel temp_user = new GetUserModel
            {
                Name = user.Name,
                userName = user.UserName,
                Birthdate = user.Birthdate,
                City = user.City,
                Created_at = user.Created_at,
                email = user.Email,
                phone_number = user.PhoneNumber,
                Photo = user.Photo,
                Street = user.Street,
                Update_at = user.Update_at,
                ZIP = user.ZIP
            };
            return temp_user;
        }

        public async Task<Response> UpdateUserAsync(string id, UpdateUserModel model)
        {
            var user = await _userManager.FindByIdAsync(id);

  
            if (model.Username != null)
            {
                user.UserName = model.Username;

                user.Update_at = DateTime.Now;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {



                    return new Response
                    {
                        Status = "Error",
                        Message = "Something wrong!",
                        isSuccess = false
                    };

                }

            }
            if (model.Name != null)
            {

                user.Name = model.Name;
                user.Update_at = DateTime.Now;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {



                    return new Response
                    {
                        Status = "Error",
                        Message = "Something wrong!",
                        isSuccess = false
                    };

                }


            }
            if (model.Street != null)
            {

                user.Street = model.Street;
                user.Update_at = DateTime.Now;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {



                    return new Response
                    {
                        Status = "Error",
                        Message = "Something wrong!",
                        isSuccess = false
                    };

                }


            }

            if (model.City != null)
            {

                user.Street = model.City;
                user.Update_at = DateTime.Now;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {



                    return new Response
                    {
                        Status = "Error",
                        Message = "Something wrong!",
                        isSuccess = false
                    };

                }


            }

            if (model.ZIP != null)
            {

                user.ZIP = model.ZIP;
                user.Update_at = DateTime.Now;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {



                    return new Response
                    {
                        Status = "Error",
                        Message = "Something wrong!",
                        isSuccess = false
                    };

                }


            }

            if (model.Photo != null)
            {

                user.Photo = model.Photo;
                user.Update_at = DateTime.Now;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {



                    return new Response
                    {
                        Status = "Error",
                        Message = "Something wrong!",
                        isSuccess = false
                    };

                }

            }




            if (model.phone_number != null)
            {

                user.PhoneNumber = model.phone_number;
                user.Update_at = DateTime.Now;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {



                    return new Response
                    {
                        Status = "Error",
                        Message = "Something wrong!",
                        isSuccess = false
                    };

                }

            }

            if (model.password != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, model.password);
                if (!result)
                {

                    return new Response
                    {
                        Status = "Error",
                        Message = "Something wrong!",
                        isSuccess = false
                    };
                }

                if (model.new_password == model.confirm_password)
                {
                    user.Update_at = DateTime.Now;
                    var resultP = await _userManager.ChangePasswordAsync(user, model.password, model.new_password);
                    await _mailService.SendEmailAsync(user.Email, "Atualização de password", $"<h1>A sua pasword foi atualizada com sucesso!</h1>");

                    if (!resultP.Succeeded)
                    {



                        return new Response
                        {
                            Status = "Error",
                            Message = "Something wrong!",
                            isSuccess = false
                        };

                    }

                }



            }

      
            return new Response
            {
                Status = "Success",
                Message = "Campo atualizado com sucesso!",
                isSuccess = true
            };
        }



        public async Task<Response> ForgetPasswordAsync(ForgetModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new Response
                {
                    isSuccess = false,
                    Message = "Email not found!",
                    Status = "Insuccess!" 
                };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}/api/Authenticate/ResetPassword?email={model.Email}&token={validToken}";

            await _mailService.SendEmailAsync(model.Email, "Reset Password", "<h1>Segue as intruções para repor a password</h1>" +
                $"<p>Para repor a password <a href='{url}'>Clica aqui</a></p>");

            return new Response
            {
                isSuccess = true,
                Message = "Email send!",
                Status = "Success!"
            };
        }

        public async Task<Response> ResetPasswordAsync(ResetPasswordModel model, string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return new Response
                {
                    isSuccess = false,
                    Message = "Email not found!",
                    Status = "Insuccess!"
                };

            if (model.NewPassword != model.ConfirmPassword)
                return new Response
                {
                    isSuccess = false,
                    Message = "Password not match!",
                    Status = "Insuccess!"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);

            if (result.Succeeded)
                return new Response
                {
                    isSuccess = true,
                    Message = "Password seted!",
                    Status = "success!"
                };

            return new Response
            {
                isSuccess = false,
                Message = "Something wrong!",
                Status = "Insuccess!"
            };
        }


    

       

    
       


       

        

     
    }
}

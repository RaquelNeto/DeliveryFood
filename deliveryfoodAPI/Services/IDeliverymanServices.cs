using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Entities;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Deliveryman;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Services
{
    public interface IDeliverymanServices
    {
        Task<Response> AddDeliveryman(AddDeliverymanModel model);
        Task<GetDeliverymanModel> GetDeliveryman(string id);
        Task<Response> UpdateDeliveryman(UpdateDeliverymanModel model, string id);
        Task<Response> RemoveDeliveryman(string id);
        
    }

    public class DeliverymanServices : IDeliverymanServices
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbContext;

        public DeliverymanServices(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ApplicationDbContext dbContext)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._configuration = configuration;
            this._dbContext = dbContext;

        }
        public async Task<Response> AddDeliveryman(AddDeliverymanModel model)
        {
            var user = await _userManager.FindByIdAsync(model.userId);
            var restaurant = _dbContext.restaurants.Where(x => x.id == model.restaurantId).Count();

            if(user==null || restaurant == 0)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            Deliveryman newDelivery = new Deliveryman
            {
                userID = model.userId,
                restaurantID = model.restaurantId,
                active = model.state,
                isAvailable = true,
                vehicle = model.vehicle
            };


            var result = _dbContext.deliveryman.Update(newDelivery);
            var _result = await _dbContext.SaveChangesAsync();

            if (_result <= 0)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

                    await _userManager.AddToRoleAsync(user, "Employee");

            return new Response
            {
                Status = "Success",
                Message = "Employee regist!",
                isSuccess = true
            };


        }

        public async Task<GetDeliverymanModel> GetDeliveryman(string id)
        {

            var deliveryman = _dbContext.deliveryman.Where(x => x.id == id).First();
            var user = await _userManager.FindByIdAsync(deliveryman.userID);
            if (user == null || deliveryman == null)
            {
                return null;
            }

            GetDeliverymanModel temp_delivery = new GetDeliverymanModel
            {
               name= user.Name,
               phone_number=user.PhoneNumber,
               vehicle=deliveryman.vehicle,
               Created_at=user.Created_at,
               state=deliveryman.isAvailable,
               Update_at=user.Update_at
               
            };
            return temp_delivery;
            
        }

        public async Task<Response> RemoveDeliveryman(string id)
        {
            var delivery = _dbContext.deliveryman.Where(x => x.id == id).First();
            var user = await _userManager.FindByIdAsync(delivery.userID);
            if (delivery==null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }


            await _userManager.RemoveFromRoleAsync(user, "Employee");
            var result = _dbContext.deliveryman.Remove(delivery);
            var _result = await _dbContext.SaveChangesAsync();

            if(_result <= 0)
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
                Message = "Employee removed!",
                isSuccess = true
            };

        }

        public async Task<Response> UpdateDeliveryman(UpdateDeliverymanModel model, string id)
        {

            var deliveryman = _dbContext.deliveryman.Where(x => x.id == id).First();
       
            if (deliveryman == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }
  

            if (model.vehicle!= null)
            {
                deliveryman.vehicle = model.vehicle;
                _dbContext.deliveryman.Update(deliveryman);
               var _result = await _dbContext.SaveChangesAsync();

                if(_result <= 0)
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
                    Message = "Updated!",
                    isSuccess = true
                };


            }

            if(model.state != deliveryman.isAvailable)
            {
                deliveryman.isAvailable = model.state;
                _dbContext.deliveryman.Update(deliveryman);
                var _result = await _dbContext.SaveChangesAsync();

                if (_result <= 0)
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
                    Message = "Updated!",
                    isSuccess = true
                };

            }
            return new Response
            {
                Status = "Success",
                Message = "Updated!",
                isSuccess = true
            };



        }
    }
}

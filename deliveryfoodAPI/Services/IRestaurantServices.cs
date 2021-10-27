using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Entities;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Restaurant;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Services
{
    public interface IRestaurantServices
    {
        Task<Response> AddRestaurant(CreateRestaurantModel model);
        Task<Restaurants> GetRestaurant(string id);
        Task<Response> UpdateRestaurant(UpdateRestaurantModel model, string id);
        Task<Response> RemoveRestaurant(string id);
    }

    public class RestaurantServices : IRestaurantServices
    {
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbContext;
        public RestaurantServices(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            this._configuration = configuration;
            this._dbContext = dbContext;
           
        }
        public async Task<Response> AddRestaurant(CreateRestaurantModel model)
        {

            var owner = _dbContext.ownerRestaurants.Where(x=>x.userID==model.ownerID).Count();
            if (owner == 0)
            {
                OwnerRestaurant _owner = new OwnerRestaurant
                {
                    userID = model.ownerID
                };

                _dbContext.ownerRestaurants.Add(_owner);
                var __result = await _dbContext.SaveChangesAsync();

                if (__result <= 0)
                {
                    return new Response
                    {
                        Status = "Error",
                        Message = "Something wrong!",
                        isSuccess = false
                    };
                }
            }

            var __owner = _dbContext.ownerRestaurants.Where(x => x.userID == model.ownerID).First();

            Restaurants restaurants = new Restaurants
            {
                name = model.name,
                email= model.email,
                phone= model.phone,
                photo= model.photo,
                City=model.City,
                Street=model.Street,
                ZIP=model.ZIP,
                ownerID=__owner.id
            };

            _dbContext.restaurants.Add(restaurants);
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
                Message = "Restaurant created!",
                isSuccess = true
            };

        }

        public async Task<Restaurants> GetRestaurant(string id)
        {
            var result = _dbContext.restaurants.Where(x => x.id == id).First();
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<Response> RemoveRestaurant(string id)
        {
            var result = _dbContext.restaurants.Where(x => x.id == id).First();
            if (result == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            _dbContext.restaurants.Remove(result);
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
                Message = "Restaurant removed!",
                isSuccess = true
            };
        }

        public async Task<Response> UpdateRestaurant(UpdateRestaurantModel model, string id)
        {
            var result = _dbContext.restaurants.Where(x => x.id == id).First();
            if (result == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            if(model.City!= null)
            {
                result.City = model.City;
                _dbContext.restaurants.Update(result);
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

                
            }
            if(model.email!= null)
            {
                result.email = model.email;
                _dbContext.restaurants.Update(result);
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

               
            }
            if (model.phone != null)
            {
                result.phone = model.phone;
                _dbContext.restaurants.Update(result);
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

               
            }
            if(model.photo != null)
            {
                result.photo = model.photo;
                _dbContext.restaurants.Update(result);
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

               
            }
            if (model.Street!=null)
            {
                result.Street = model.Street;
                _dbContext.restaurants.Update(result);
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

                
            }

            if (model.ZIP != null)
            {
                result.ZIP = model.ZIP;
                _dbContext.restaurants.Update(result);
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

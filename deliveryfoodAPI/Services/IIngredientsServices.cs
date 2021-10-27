using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Entities;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.IngredientExtra;
using deliveryFoodAPI.Models.Ingredients;
using deliveryFoodAPI.Models.Product;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Services
{
    public interface IIngredientsServices
    {
        Task<Response> AddIngredient(AddIngredientModel model);
        Task<Ingredients> GetIngredient(string id);
        Task<Response> UpdateIngredient(UpdateIngredient model, string id);
        Task<Response> RemoveIngredient(string id);
        List<Ingredients> GetAllIngredients();
    }

    public class IngredientsServices : IIngredientsServices
    {
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbContext;
        public IngredientsServices(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            this._configuration = configuration;
            this._dbContext = dbContext;
        }
        public async Task<Response> AddIngredient(AddIngredientModel model)
        {
            Ingredients ingredients = new Ingredients
            {
                name = model.name,
                description = model.description
            };

            _dbContext.ingredients.Add(ingredients);
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
                Message = "Ingredient created!",
                isSuccess = true
            };

        }

        public List<Ingredients> GetAllIngredients()
        {
            var ingredients = _dbContext.ingredients.ToList();
            if (ingredients.Count == 0)
            {
                return null;
            }



            return ingredients;
        }

        public async Task<Ingredients> GetIngredient(string id)
        {
            var ingredients = _dbContext.ingredients.Where(x => x.id == id).First();
            if (ingredients == null)
            {
                return null;
            }
            return ingredients;
        }

        public async Task<Response> RemoveIngredient(string id)
        {
            var ingredients = _dbContext.ingredients.Where(x => x.id == id).First();
            if (ingredients == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            _dbContext.ingredients.Remove(ingredients);
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
                Message = "Removed!",
                isSuccess = true
            };
        }

        public async Task<Response> UpdateIngredient(UpdateIngredient model, string id)
        {
            var ingredients = _dbContext.ingredients.Where(x => x.id == id).First();

            if (ingredients == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            if (model.description != null)
            {
                ingredients.description = model.description;
                _dbContext.ingredients.Update(ingredients);
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
            if (model.name != null)
            {
                ingredients.name = model.name;
                _dbContext.ingredients.Update(ingredients);
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

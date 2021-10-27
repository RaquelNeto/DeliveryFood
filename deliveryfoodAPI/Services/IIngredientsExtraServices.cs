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
    public interface IIngredientsExtraServices
    {
        Task<Response> AddIngredient(AddIngredientExtraModel model);
        Task<IngredientsExtra> GetIngredient(string id);
        Task<Response> UpdateIngredient(UpdateIngredientExtraModel model, string id);
        Task<Response> RemoveIngredient(string id);
        List<IngredientsExtra> GetAllIngredients();
    }
    public class IngredientsExtraServices : IIngredientsExtraServices
    {
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbContext;
        public IngredientsExtraServices(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            this._configuration = configuration;
            this._dbContext = dbContext;
        }
        public async Task<Response> AddIngredient(AddIngredientExtraModel model)
        {
            IngredientsExtra ingredients = new IngredientsExtra
            {
                name = model.name,
                description = model.description,
                price = model.price

            };

            _dbContext.ingredientsextra.Add(ingredients);
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
                Message = "Type created!",
                isSuccess = true
            };

        }

        public List<IngredientsExtra> GetAllIngredients()
        {
            var ingredients = _dbContext.ingredientsextra.ToList();
            if (ingredients.Count == 0)
            {
                return null;
            }



            return ingredients;
        }

        public async Task<IngredientsExtra> GetIngredient(string id)
        {
            var ingredients = _dbContext.ingredientsextra.Where(x => x.id == id).First();
            if (ingredients == null)
            {
                return null;
            }
            return ingredients;
        }

        public async Task<Response> RemoveIngredient(string id)
        {
            var ingredients = _dbContext.ingredientsextra.Where(x => x.id == id).First();
            if (ingredients == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            _dbContext.ingredientsextra.Remove(ingredients);
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

        public async Task<Response> UpdateIngredient(UpdateIngredientExtraModel model, string id)
        {
            var ingredients = _dbContext.ingredientsextra.Where(x => x.id == id).First();

            if (ingredients == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }


            if (model.price != ingredients.price)
            {
                ingredients.price = model.price;
                _dbContext.ingredientsextra.Update(ingredients);
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

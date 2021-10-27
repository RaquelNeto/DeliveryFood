using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Entities;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.IngredientExtra;
using deliveryFoodAPI.Models.Meal;
using deliveryFoodAPI.Models.Product;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Services
{
    public interface IMealServices
    {
        Task<Response> AddMeal(AddMealModel model);
        Task<Response> UpdateMeal(UpdateMealModel model,string id);
        Task<Response> RemoveMeal(string id);
        Task<Meal> GetMeal(string id);
        List<Meal> GetAllMeals();
        Task<Response> AddMealIngredients(AddMealIngredients model, string mealID, string ingredientID);
        Task<Response> RemoveMealIngredient(string mealID, string ingredientID);
        List<Ingredients> GetAllIngredients(string mealID);       
    }

    public class MealServices : IMealServices
    {


        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbContext;
        public MealServices(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            this._configuration = configuration;
            this._dbContext = dbContext;
        }
        

        public async Task<Response> AddMeal(AddMealModel model)
        {
             Meal meal = new Meal
            {
                name = model.name,
                description=model.description,
                photo= model.photo,
                price= model.price,
                restaurantID= model.restaurantID,
                state= model.state,
                typeID= model.typeID
            };
            _dbContext.meal.Add(meal);
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
                Message = "Meal created!",
                isSuccess = true
            };
        }

        public async Task<Response> AddMealIngredients(AddMealIngredients model, string mealID, string ingredientID)
        {
            var meal = _dbContext.meal.Where(x => x.id == mealID).First();
            if (meal == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }
            var ingredient = _dbContext.ingredients.Where(x => x.id == ingredientID).First();
            if (ingredient == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            MealsIngredients mealsIngredients = new MealsIngredients
            {
               ingredientID=ingredient.id,
               mealID=mealID,
               isRequest=true,
               isRequired=true
            };
            _dbContext.MealsIngredients.Add(mealsIngredients);
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
                Message = "Meal ingredient created!",
                isSuccess = true
            };
        }

        public List<Ingredients> GetAllIngredients(string mealID)
        {
            var ingredients = _dbContext.MealsIngredients.Where(x => x.mealID == mealID).ToList();

            List<Ingredients> ingredient = new List<Ingredients>();

            foreach (var mealin in ingredients){
               ingredient.Add( _dbContext.ingredients.Where(x => x.id == mealin.ingredientID).First());

            }

            return ingredient;
        }

        public List<Meal> GetAllMeals()
        {
            var meal = _dbContext.meal.ToList();
            if (meal == null)
            {
                return null;
            }

            return meal;
        }

        public async Task<Meal> GetMeal(string id)
        {
            var meal = _dbContext.meal.Where(x => x.id == id).First();
            if(meal == null)
            {
                return null;
            }

            return meal;
        }

  

        public async Task<Response> RemoveMeal(string id)
        {
            var meal = _dbContext.meal.Where(x => x.id == id).First();
            if (meal == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            _dbContext.meal.Remove(meal);
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

        public async Task<Response> RemoveMealIngredient(string mealID, string ingredientID)
        {
            var mealingredient=_dbContext.MealsIngredients.Where(x => x.ingredientID == ingredientID).Where(x => x.mealID == mealID).First();
            if (mealingredient == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }
            _dbContext.MealsIngredients.Remove(mealingredient);
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

        public async Task<Response> UpdateMeal(UpdateMealModel model,string id)
        {
            var meal = _dbContext.meal.Where(x => x.id == id).First();
            if (meal == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            if (model.price != meal.price)
            {
                meal.price = model.price;
                _dbContext.meal.Update(meal);
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
            if (model.photo != null)
            {
                meal.photo = model.photo;
                _dbContext.meal.Update(meal);
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

            if (model.state != meal.state)
            {
                meal.state = model.state;
                _dbContext.meal.Update(meal);
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

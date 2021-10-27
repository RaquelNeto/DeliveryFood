using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Entities;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Order;
using deliveryFoodAPI.Models.OrderIngredientextra;
using deliveryFoodAPI.Models.OrderProducts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Services
{
    public interface IOrderServices
    {
        Task<Response> AddOrder(AddOrderModel model, string userID);
        Task<Response> AddMealOrder(AddMealOrderModel model, string mealID, string orderId);
        Task<Response> AddIngredientMeal(string ingredientID, string mealID);

        Task<Response> RemoveingredientMeal(string ingredientID, string mealID);


    
        List<Mealhistory> GetAllMealsOrder(string OrderID);
        Task<Mealhistory> GetMeal(string mealID);
        Task<Order> GetOrder(string orderID);
        List<Ingredients> GetAllingredientsMeal(string mealID);
        Task<Response> AddIngredientExtra(string ingredientID, string orderID);
        Task<Response> RemovengredientExtra(string ingredientID, string orderID);
        List<IngredientsExtra> GetIngredientsExtra(string orderID);

        Task<Response> UpdateOrder(UpdateOrderModel model, string orderID);
        Task<Response> RemoveOrder(string orderID);
        Task<Response> RemoveMealOrder(string mealID);
    }
    public class OrderServices : IOrderServices
    {
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbContext;
        public OrderServices(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            this._configuration = configuration;
            this._dbContext = dbContext;
        }



        public async Task<Response> AddOrder(AddOrderModel model, string userID)
        {
            Order order = new Order
            {
                City = model.City,
                delivermanID = null,
                requestDate = DateTime.Now,
                require_invoice = model.require_invoice,
                status_request = "A preparar ...",
                Street = model.Street,
                qrcode = model.qrcode,
                total_price = model.total_price,
                userID = userID,
                ZIP = model.ZIP

            };

            _dbContext.order.Add(order);
            var result = await _dbContext.SaveChangesAsync();
            if (result == 0)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Order creation Erroe!",
                    isSuccess = false
                };
            }
            return new Response
            {
                Status = "Success",
                Message = "Order create!",
                isSuccess = true
            };

        }

        public async Task<Response> AddMealOrder(AddMealOrderModel model, string mealID, string orderId)
        {
            var _meal = _dbContext.meal.Where(x => x.id == mealID).First();
            if (_meal == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            var _order = _dbContext.order.Where(x => x.id == orderId).First();
            if (_order == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            Mealhistory mealhistory = new Mealhistory
            {
                mealID = _meal.id,
                name = _meal.name,
                photo = _meal.photo,
                price = _meal.price,
                restaurantID = _meal.restaurantID,
                state = _meal.state,
                typeID = _meal.typeID,
                description = _meal.description,
                orderID = orderId,
                quantity= model.quantity
            };
            _dbContext.Mealhistory.Add(mealhistory);
            var result = await _dbContext.SaveChangesAsync();
            if (result == 0)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            var mealsingredients = _dbContext.MealsIngredients.Where(x => x.mealID == mealID).ToList();

            foreach (var ingredient in mealsingredients)
            {
                MealsIngredients mealsIngredients_ = new MealsIngredients
                {
                    ingredientID = ingredient.ingredientID,
                    mealID = mealhistory.id,
                    isRequest = ingredient.isRequest,
                    isRequired = ingredient.isRequired
                };
                _dbContext.MealsIngredients.Add(mealsIngredients_);
                var __result = await _dbContext.SaveChangesAsync();
                if (__result == 0)
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
                Message = "Meal Order created!",
                isSuccess = true
            };

        }
        public async Task<Response> AddIngredientMeal(string ingredientID, string mealID)
        {
            var meal = _dbContext.Mealhistory.Where(x => x.id == mealID).First();
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
                mealID = mealID,
                ingredientID = ingredientID,
                isRequest = true,
                isRequired = true
            };

            _dbContext.MealsIngredients.Add(mealsIngredients);
            var result = await _dbContext.SaveChangesAsync();

            if (result == 0)
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
                Message = "Ingredient adicionado!",
                isSuccess = true
            };


        }

        public async Task<Response> RemoveingredientMeal(string ingredientID, string mealID)
        {
            var mealingrediet = _dbContext.MealsIngredients.Where(x => x.mealID == mealID).Where(y => y.ingredientID == ingredientID).First();
            if (mealingrediet == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }



            _dbContext.MealsIngredients.Remove(mealingrediet);
            var result = await _dbContext.SaveChangesAsync();

            if (result == 0)
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
                Message = "Ingredient Removed!",
                isSuccess = true
            };


        }


        public List<Mealhistory> GetAllMealsOrder(string OrderID)
        {
            var mealsorder = _dbContext.Mealhistory.Where(x => x.orderID == OrderID).ToList();
            if (mealsorder == null)
            {
                return null;
            }
            return mealsorder;
        }
        public async Task<Mealhistory> GetMeal(string mealID)
        {
            var meal = _dbContext.Mealhistory.Where(x => x.id == mealID).First();
            if (meal == null)
            {
                return null;
            }
            return meal;
        }

        public async Task<Order> GetOrder (string orderID)
        {
            var order = _dbContext.order.Where(x => x.id == orderID).First();
            if(order == null)
            {
                return null;
            }
            return order;
        }

        public  List<Ingredients> GetAllingredientsMeal(string mealID)
        {
            var meal = _dbContext.Mealhistory.Where(x => x.id == mealID).First();
            if(meal== null)
            {
                return null;
            }
            var ingredientsMeal = _dbContext.MealsIngredients.Where(x => x.mealID == mealID).ToList();

            List<Ingredients> ingredients = new List<Ingredients>();

            foreach (var p in ingredientsMeal)
            {
                ingredients.Add(_dbContext.ingredients.Where(x => x.id == p.ingredientID).First());
            }

            if(ingredients== null)
            {
                return null;
            }
            return ingredients;

        }

        public async Task<Response> AddIngredientExtra(string ingredientID, string orderID)
        {
            var ingredientextra = _dbContext.ingredientsextra.Where(x => x.id == ingredientID).First();
            if (ingredientextra == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            var order = _dbContext.order.Where(x => x.id == orderID).First();
            if (order == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            IngredientOrderExtra ingredientextraorder = new IngredientOrderExtra
            {
                ingredientextraID = ingredientID,
                orderID = orderID
            };

            _dbContext.ingredientoorderextra.Add(ingredientextraorder);
            var result = await _dbContext.SaveChangesAsync();

            if (result == 0)
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
                Message = "Ingredient extra adicionado!",
                isSuccess = true
            };


        }

        public async Task<Response> RemovengredientExtra(string ingredientID, string orderID)
        {
            var ingredietextra = _dbContext.ingredientoorderextra.Where(x => x.ingredientextraID == ingredientID).Where(y => y.orderID == orderID).First();
            if (ingredietextra == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }



            _dbContext.ingredientoorderextra.Remove(ingredietextra);
            var result = await _dbContext.SaveChangesAsync();

            if (result == 0)
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
                Message = "Ingredient Removed!",
                isSuccess = true
            };


        }





        public List<IngredientsExtra> GetIngredientsExtra(string orderID)
        {
            var ingredientsextra = _dbContext.ingredientoorderextra.Where(x => x.orderID == orderID).ToList();
            if (ingredientsextra == null)
            {
                return null;
            }

            List<IngredientsExtra> ingredients = new List<IngredientsExtra>();

            foreach(var p in ingredientsextra)
            {
                ingredients.Add(_dbContext.ingredientsextra.Where(x => x.id == p.ingredientextraID).First());
            }

            if(ingredients== null)
            {
                return null;
            }

            return ingredients;

        }


        public async Task<Response> UpdateOrder(UpdateOrderModel model, string orderID)
        {
            var order = _dbContext.order.Where(x => x.id == orderID).First();
            if (order == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            if (model.City != null)
            {

                order.City = model.City;
                _dbContext.order.Update(order);
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
            if (model.delivermanID != null)
            {
                order.delivermanID = model.delivermanID;
                _dbContext.order.Update(order);
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
            if (model.require_invoice != order.require_invoice)
            {
                order.require_invoice = model.require_invoice;
                _dbContext.order.Update(order);
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

            if (model.status_request!=null)
            {
                order.status_request = model.status_request;
                _dbContext.order.Update(order);
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
            if(model.Street!= null)
            {
                order.Street = model.Street;
                _dbContext.order.Update(order);
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
            if(model.total_price!= order.total_price)
            {
                order.total_price = model.total_price;
                _dbContext.order.Update(order);
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
            if(model.ZIP!= null)
            {
                order.ZIP = model.ZIP;
                _dbContext.order.Update(order);
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


        public async Task<Response> RemoveOrder (string orderID)
        {
            var order = _dbContext.order.Where(x => x.id == orderID).First();
            if (order == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            _dbContext.order.Remove(order);
            var result =await _dbContext.SaveChangesAsync();
            if (result == 0)
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
                Message = "Order Removed!",
                isSuccess = true
            };
        }

        public async Task<Response> RemoveMealOrder(string mealID)
        {
            var meal = _dbContext.Mealhistory.Where(x => x.id == mealID).First();
            if (meal == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            _dbContext.Mealhistory.Remove(meal);
            var result = await _dbContext.SaveChangesAsync();
            if (result == 0)
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
                Message = "Meal Removed!",
                isSuccess = true
            };

        }





        

    }

}

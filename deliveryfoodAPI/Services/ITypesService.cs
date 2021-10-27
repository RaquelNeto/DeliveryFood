using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Entities;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Types;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Services
{
    public interface ITypesService
    {
        Task<Response> AddType(AddTypesModel model);
        Task<Response> UpdateType(UpdateTypesModel model, string id);
        Task<Response> RemoveType(string id);
        Task<Types> GetType(string id);

    }
    public class TypesService : ITypesService
    {
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbContext;
        public TypesService(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            this._configuration = configuration;
            this._dbContext = dbContext;
        }
        public async Task<Response> AddType(AddTypesModel model)
        {
            
            var result = _dbContext.types.Where(x => x.name.ToLower() == model.name.ToLower()).Count();
            if(result > 0)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong, yet exists!",
                    isSuccess = false
                };
            }

            Types type = new Types
            {
                name= model.name,
                description = model.description
            };

            _dbContext.types.Add(type);
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

        public async Task<Types> GetType(string id)
        {
            var type = _dbContext.types.Where(x => x.id == id).First();
            if (type == null)
            {
                return null;
            }
            return type;
        }

        public async Task<Response> RemoveType(string id)
        {
            var type = _dbContext.types.Where(x => x.id == id).First();
            if (type == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            _dbContext.types.Remove(type);
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

        public async Task<Response> UpdateType(UpdateTypesModel model ,string id)
        {
            var type = _dbContext.types.Where(x => x.id == id).First();
            if(type == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            if(model.name != null)
            {
                type.name = model.name;
                _dbContext.types.Update(type);
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

          
            }
            if (model.description != null)
            {
                type.description = model.description;
                _dbContext.types.Update(type);
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

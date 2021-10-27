using deliveryFoodAPI.DBContext;
using deliveryFoodAPI.Entities;
using deliveryFoodAPI.Models;
using deliveryFoodAPI.Models.Feedback;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Services
{
    public interface IFeedbackService
    {
        Task<Response> AddFeedback(AddFeedbackModel model, string orderID);
        Task<Feedback> GetFeedback(string id);
        Task<Response> UpdateFeedback(UpdateFeedbackModel model, string id);
        Task<Response> RemoveFeedback(string id);
        List<Feedback> GetAllFeedback();
    }
    public class FeedbackService : IFeedbackService
    {
        private readonly IConfiguration _configuration;
        private ApplicationDbContext _dbContext;
        public FeedbackService(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            this._configuration = configuration;
            this._dbContext = dbContext;
        }



        public async Task<Response> AddFeedback(AddFeedbackModel model , string orderID)
        {
            var feedback = _dbContext.feedback.Where(x => x.orderID == orderID).First();
            if(feedback!= null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            Feedback _feedback = new Feedback
            {
                stars = model.stars,
                comment = model.comment,
                orderID = orderID
            };

            _dbContext.feedback.Add(_feedback);
            var _result = await _dbContext.SaveChangesAsync();

            return new Response
            {
                Status = "Success",
                Message = "Feedback created!",
                isSuccess = true
            };
        }

        public List<Feedback> GetAllFeedback()
        {
            var feedback = _dbContext.feedback.ToList();
            if (feedback.Count == 0)
            {
                return null;
            }



            return feedback;
        }

        public async Task<Feedback> GetFeedback(string id)
        {
            var feedback = _dbContext.feedback.Where(x => x.id == id).First();
            if (feedback == null)
            {
                return null;
            }
            return feedback;
        }

        public async Task<Response> RemoveFeedback(string id)
        {
            var feedback = _dbContext.feedback.Where(x => x.id == id).First();
            if (feedback == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            _dbContext.feedback.Remove(feedback);
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

        public async Task<Response> UpdateFeedback(UpdateFeedbackModel model, string id)
        {

            var feedback = _dbContext.feedback.Where(x => x.id == id).First();

            if (feedback == null)
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Something wrong!",
                    isSuccess = false
                };
            }

            if (model.stars != feedback.stars)
            {
                feedback.stars = model.stars;
                _dbContext.feedback.Update(feedback);
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
            if (feedback.comment != null)
            {
                feedback.comment = model.comment;
                _dbContext.feedback.Update(feedback);
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

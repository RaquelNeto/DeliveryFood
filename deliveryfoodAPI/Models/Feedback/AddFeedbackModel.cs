using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Feedback
{
    public class AddFeedbackModel
    {

        public int stars { get; set; }
        public string comment { get; set; }
       
    }
}

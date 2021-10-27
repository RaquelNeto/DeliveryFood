using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models
{
    public class Response
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public bool isSuccess { get; set; }
    }
}

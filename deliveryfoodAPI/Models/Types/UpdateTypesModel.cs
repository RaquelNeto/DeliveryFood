﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Models.Types
{
    public class UpdateTypesModel
    {
 
        public string name { get; set; }
        public string description { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission6try2.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}

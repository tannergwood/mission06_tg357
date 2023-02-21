using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission6try2.Models
{
    public class MovieInput
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required]
        public string Title { get; set; }



        [Required]
        [Range(1800,3000)]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }

        //Build the Foreign Key Relationship
        [Required]
        public int CategoryID { get; set; }

        public Category category { get; set; }
    }
}

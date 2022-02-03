using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialSpice.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [Range(0.1,100,ErrorMessage ="Price should be between 0.1 to 100.")]
        public double Price { get; set; }
        [Display(Name ="Food Type")]
        public int FoodTypeId { get; set; }
        public FoodType FoodType { get; set; }
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

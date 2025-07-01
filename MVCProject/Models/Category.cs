using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ValidateNever]
        public List <Product> Products { get; set; }


    }
}

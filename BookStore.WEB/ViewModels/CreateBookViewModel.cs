using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WEB.ViewModels
{
    public class CreateBookViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the title of the book")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter a description for the book")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter the price of the book")]
        [Range(0.00,1000.00,ErrorMessage = "Invalid price value entered")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Select the author of the book")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Select the genre of the book")]
        public int CategoryId { get; set; }
        
        public SelectList Authors { get; set; }
        public SelectList Genres { get; set; }
    }
}
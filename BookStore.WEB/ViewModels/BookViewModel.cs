using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.BLL.DTO;

namespace BookStore.WEB.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the title of the book")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter a description for the book")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter the price of the book")]
        public decimal Price { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }

    }
}
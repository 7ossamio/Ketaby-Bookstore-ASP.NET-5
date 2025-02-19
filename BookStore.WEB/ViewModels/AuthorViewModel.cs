﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.WEB.ViewModels
{
    public class AuthorViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Full name must be filled")]
        public string Name { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace onlinebookstore.Models
{
    public class Checkout
    {
        [Key]
        [BindNever]
        public int  CheckoutId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name ")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line name ")]

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name ")]

        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name ")]

        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name ")]

        public string Country { get; set; }

        [BindNever]
        public bool OrderShipped { get; set; } = false;

    }
}

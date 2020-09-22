using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductBasket.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string ProdName { get; set; }

        [DisplayName("Image Name")]
        public string ProdImageName { get; set; }

        [Required]
        [DisplayName("Price")]
        public double ProdPrice { get; set; }

    }
}

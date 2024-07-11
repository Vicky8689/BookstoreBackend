using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model
{
    public class AddBookRequestModel
    {
        [Required]
        public string bookName { get; set; }
        [Required]
        public string author { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public int discountPrice { get; set; }

    }
}

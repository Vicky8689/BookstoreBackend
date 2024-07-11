using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model
{
    public class CartResponseModel
    {
        public int cartId { get; set; }

        public int bookId { get; set; }

        public string bookName { get; set; }

        
        public string author { get; set; }

       
        public string description { get; set; }
       
        public int quantity { get; set; }
       
        public int price { get; set; }
       
        public int discountPrice { get; set; }

        public DateTime createdAt { get; set; }

        [Required]
        public DateTime updatedAt { get; set; }

    }
}

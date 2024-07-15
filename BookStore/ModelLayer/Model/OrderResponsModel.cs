using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model
{
    public class OrderResponsModel
    {
        public int orderId { get; set; }
        public DateTime orderDate { get; set; }

      public int bookId { get; set; }
        public string bookName {  get; set; }
        public string bookAuthor { get; set; }
        public int totalPrice  { get; set; }
        public int totalDiscountPrice  { get; set; }
     
    }
}

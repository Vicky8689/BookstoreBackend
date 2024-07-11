using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model
{
    public class WishlistResponseModel
    {
        public int userId { get; set; }
        public int WishlistId { get; set; }
        public int bookid { get; set; }
        public string bookname { get; set; }
        public int price { get; set; }
        public int discountprice { get; set; }
        public string  author { get; set; }

    }
}

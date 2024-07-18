using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model
{
    public class AddFeedBackRequestModel
    {
        public int bookId {  get; set; }
        public string feedback { get; set; }
    }

}

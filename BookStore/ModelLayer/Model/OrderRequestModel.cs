using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Model
{
    public class OrderRequestModel
    {
       
        [Required]
        [StringLength(50)]
        public string cName { get; set; }

        [Required]
        public int cMobil { get; set; }
        [Required]
        [StringLength(100)]
        public string cAdd { get; set; }
        [Required]
        [StringLength(50)]
        public string cCity { get; set; }
        [Required]
        [StringLength(50)]
        public string cState { get; set; }
      
        public int CartId { get; set; }
        public int BookId { get; set; }
    }
}

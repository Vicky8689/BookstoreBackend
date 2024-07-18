using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bookId { get; set; }

        [Required]
        [StringLength(20)]
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

        [Required]
        public DateTime createdAt { get; set; }

        [Required]
        public DateTime updatedAt { get; set; }

        public string FeedBack {  get; set; }
    }
}

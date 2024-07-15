using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }
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
        [Required]
        public DateTime orderDate { get; set; }

        [Required]
        public int totalPrice {  get; set; }
        [Required]
        public int totladiscountPrice { get; set; }

        public int UserId {  get; set; }
        [ForeignKey(nameof(UserId))]
        public UserEntity user { get; set; }

        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public BookEntity book { get;}



    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class WishListEntity
    {

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListId { get; set; }
        
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserEntity user { get; set; }

        public int bookId { get; set; }
        [ForeignKey(nameof(bookId))]
        public BookEntity book { get; set; }
    }
}

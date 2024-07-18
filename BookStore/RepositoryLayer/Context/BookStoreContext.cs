using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<CartEntity> Cart { get; set; }

        public DbSet<WishListEntity> WishLists { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<FeedBackEntity> FeedBack { get; set; }
    }
}

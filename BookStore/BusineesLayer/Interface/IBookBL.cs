using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Interface
{
    public interface IBookBL
    {
        public BookEntity AddBook(AddBookRequestModel model);

        public List<BookEntity> GetAllBooks();
        public BookEntity GetBooksById(int bookId);

        public CartEntity AddCart(int userId, int bookId);

        public List<CartResponseModel> GetAllCart(int userId);

        public CartEntity DeleteCart(int cartId,int userId);
        public bool AddWishlist(int userid, int bookid);
        public List<WishlistResponseModel> GetAllWishlist(int UserId);
        public bool deletewishlist(int UserId, int bookid);


    }
}

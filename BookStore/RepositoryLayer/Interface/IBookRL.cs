using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        public BookEntity AddBook(AddBookRequestModel model);
        public List<BookEntity> GetAllBooks();
        public CartEntity AddCart(int userId,int bookId);
        public List<CartResponseModel> GetAllCart(int userId);

        public CartEntity DeleteCart(int cartId, int userId);
        public BookEntity GetBooksById(int bookId);
        public List<WishlistResponseModel> GetAllWishlist(int UserId);

        public bool AddWishlist(int userid, int bookid);
        public bool deletewishlist(int UserId, int bookid);
    }
}

using BusineesLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer.Services
{
    public class BookBL:IBookBL
    {
        public readonly IBookRL _bookRL;
        public BookBL(IBookRL bookRL)
        {
            _bookRL = bookRL;
        }
        public BookEntity AddBook(AddBookRequestModel model)
        {
            return _bookRL.AddBook(model);
        }
        public List<BookEntity> GetAllBooks()
        {
            return _bookRL.GetAllBooks();
        }
        public BookEntity GetBooksById(int bookId)
        {

            return _bookRL.GetBooksById(bookId);
        }

        public CartEntity AddCart(int userId, int bookId)
        {
            return _bookRL.AddCart(userId, bookId);
        }

        public List<CartResponseModel> GetAllCart(int userId)
        {
            return _bookRL.GetAllCart(userId);  
        }
        public CartEntity DeleteCart(int cartId, int userId)
        {
            return _bookRL.DeleteCart(cartId,userId);
        }
        public bool AddWishlist(int userid, int bookid)
        {
            return _bookRL.AddWishlist(userid, bookid);
        }
        public List<WishlistResponseModel> GetAllWishlist(int UserId)
        {
            return _bookRL.GetAllWishlist(UserId);
        }
        public bool deletewishlist(int UserId, int bookid)
        {
            return _bookRL.deletewishlist(UserId, bookid);
        }

    }
}

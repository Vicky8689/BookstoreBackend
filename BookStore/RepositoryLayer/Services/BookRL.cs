using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class BookRL:IBookRL
    {
        private readonly BookStoreContext _context;
        public BookRL(BookStoreContext context)
        {
            _context = context;
        }
        public BookEntity AddBook(AddBookRequestModel model)
        {
            var IsPresent = _context.Books.FirstOrDefault(x => x.bookName == model.bookName);

            if (IsPresent == null)
            {
                BookEntity bookEntity = new BookEntity();
                bookEntity.bookName = model.bookName;
                bookEntity.author = model.author;
                bookEntity.price = model.price;
                bookEntity.quantity = model.quantity;
                bookEntity.description = model.description;
                bookEntity.discountPrice = model.discountPrice;
                bookEntity.createdAt = DateTime.Now;
                bookEntity.updatedAt = DateTime.Now;

                _context.Add(bookEntity); 
                _context.SaveChanges();

                return bookEntity;
            }
            else
            {
                return null;
            }
        }

        public List<BookEntity> GetAllBooks()
        {
            var data = _context.Books.ToList();
            
            return data;
        }
        //add cart
        public CartEntity AddCart(int userId,int bookId)
        {
            var findCart = _context.Cart.FirstOrDefault(x => x.UserId == userId && x.bookId == bookId);
            if (findCart == null)
            {
                CartEntity cart = new CartEntity();
                cart.bookQuantity = 1;
                cart.bookId = bookId;
                cart.UserId = userId;
                _context.Cart.Add(cart);
                int rasult = _context.SaveChanges();
                if (rasult > 0)
                {
                    return cart;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                findCart.bookQuantity++;
                _context.Update(findCart);
                _context.SaveChanges();
                return findCart;
            }

        }

        //getbook by id
        public BookEntity GetBooksById(int bookId)
        {
            var data = _context.Books.FirstOrDefault(x => x.bookId == bookId);

            return data;
        }
       
        //get all cart
        public List<CartResponseModel> GetAllCart(int userId)
        {
           var result = _context.Cart.Where(x=>x.UserId==userId).ToList();
            List<CartResponseModel> alllist = new List<CartResponseModel>();
            foreach (var item in result)
            {
            CartResponseModel data = new CartResponseModel();
                var bookdata = _context.Books.FirstOrDefault(x=>x.bookId==item.bookId);
                data.cartId = item.CartId;
                data.bookId = bookdata.bookId;
                data.bookName = bookdata.bookName;  
                data.author = bookdata.author;
                data.description= bookdata.description;
                data.price = bookdata.price;
                data.quantity = item.bookQuantity;  
                data.discountPrice = bookdata.discountPrice;
                data.createdAt = bookdata.createdAt;
                data.updatedAt = bookdata.updatedAt;
                data.isPurchease = item.isPurchase;
                alllist.Add(data);
            }

           return alllist;
        }

        //delete cart
        public CartEntity DeleteCart(int cartId, int userId)
        {
            var cart = _context.Cart.FirstOrDefault(x => x.bookId == cartId && x.UserId==userId);
            if (cart != null)
            {
                if (cart.bookQuantity > 1)
                {
                    cart.bookQuantity--;
                    _context.Update(cart);
                    _context.SaveChanges();
                    return cart;

                }
                else
                {
                var result = _context.Cart.Remove(cart);
                 _context.SaveChanges();
                return cart;

                }
            }
            else
            {
                return null;
            }

        }


        public bool AddWishlist(int userid,int bookid)
        {
            var isinlist = _context.WishLists.FirstOrDefault(x=>x.UserId==userid && x.bookId==bookid); 
            if (isinlist == null)
            {
                WishListEntity wish = new WishListEntity();
                wish.UserId = userid;
                wish.bookId = bookid;
                _context.Add(wish);
                _context.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }

        }


        //get wishlist
        public List<WishlistResponseModel> GetAllWishlist(int UserId )
        {
            var result = _context.WishLists.Where(x=>x.UserId== UserId).ToList();
            if (result.Count > 0)
            {

            List<WishlistResponseModel> alllist = new List<WishlistResponseModel>();
            foreach (var wish in result)
            {
                WishlistResponseModel data = new WishlistResponseModel();
                var bookdata = _context.Books.FirstOrDefault(x => x.bookId == wish.bookId);
                data.bookid = wish.bookId;
                data.WishlistId = wish.WishListId;
                data.bookname = bookdata.bookName;
                data.author = bookdata.author;
                data.price = bookdata.price;
                data.discountprice = bookdata.discountPrice;
                alllist.Add(data);
            }

            return alllist;
            }
            return null;
        }

        public bool deletewishlist(int UserId,int bookid)
        {
            var getwhishlist=_context.WishLists.FirstOrDefault(x=>x.UserId== UserId && x.bookId==bookid);
            if (getwhishlist != null)
            {
                _context.WishLists.Remove(getwhishlist);
                var result = _context.SaveChanges();
                if (result > 0)
                {

                return true;
                }
            }
            return false;

        }

        //addfeedback
        public FeedBackEntity addfeedBack(int userid,AddFeedBackRequestModel model)
        {
            FeedBackEntity feedBack = new FeedBackEntity();
            feedBack.bookId= model.bookId;
            feedBack.feedback = model.feedback;
            feedBack.UserId = userid;
            _context.FeedBack.Add(feedBack);
            _context.SaveChanges();
            return feedBack;

        }
        //get feedback 
        public List<FeedbackResponseModel> getAllFeedback(int bookid)
        {
            var result = _context.FeedBack.Where(x => x.bookId == bookid).ToList();
            List<FeedbackResponseModel> alldata = new List<FeedbackResponseModel>();

            foreach (var item in result)
            {
                var userdata = _context.Users.FirstOrDefault(x=>x.UserId==item.UserId);
                if (userdata != null)
                {

                    FeedbackResponseModel feed = new FeedbackResponseModel();
                    feed.username = userdata.Name;
                    feed.msg = item.feedback;

                    alldata.Add(feed);
                }
            }
            return alldata;



        }


    }
}


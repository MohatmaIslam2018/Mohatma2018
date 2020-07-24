using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Data;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreateOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPage = model.TotalPage.HasValue ? model.TotalPage.Value : 0,
                UpdateOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl
            };

            newBook.bookGallery = new List<BookGallery>();

            foreach (var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }


        //public async Task<List<BookModel>> GetAllBooks()
        //{

        //var books = new List<BookModel>();
        //var allbooks = await _context.Books.ToListAsync();
        //if(allbooks?.Any() == true) 
        //{
        //    foreach (var book in allbooks)
        //    {
        //        books.Add(new BookModel()
        //        {
        //            Author = book.Author,
        //            Category = book.Category,
        //            Description = book.Description,
        //            Id = book.Id,
        //            LanguageId = book.LanguageId,
        //            Language = book.Language.Name,
        //            Title = book.Title,
        //            TotalPage = book.TotalPage,
        //            CoverImageUrl = book.CoverImageUrl

        //        });
        //    }
        //}
        //return books;
        //}

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
                  .Select(book => new BookModel()
                  {
                      Author = book.Author,
                      Category = book.Category,
                      Description = book.Description,
                      Id = book.Id,
                      LanguageId = book.LanguageId,
                      Language = book.Language.Name,
                      Title = book.Title,
                      TotalPage = book.TotalPage,
                      CoverImageUrl = book.CoverImageUrl
                  }).ToListAsync();
        }

        public async Task<BookModel> GetBookById(int id)
        {

            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPage = book.TotalPage,
                    CoverImageUrl = book.CoverImageUrl,
                    Gallery = book.bookGallery.Select(g => new GalleryModel()
                    { 
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL
                    }).ToList(),
                    BookPdfUrl = book.BookPdfUrl

                }).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBook(string title, string authorName) 
        {
            //return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
            return null;
        }

        //private List<BookModel> DataSource()
        //    {
        //        return new List<BookModel>()
        //        {
        //            new BookModel() { Id = 1, Title = "Asp.Net MVC", Author = "Mohatma", Description="This is about Asp.Net MVC prgramming book", Category="Advance Programming", Language="English", TotalPage=227 },
        //            new BookModel() { Id = 2, Title = "JavaBook", Author = "Ratul", Description="This is about Java prgramming book, useful for java developer", Category="Programming", Language="English", TotalPage=297},
        //            new BookModel() { Id = 3, Title = "Python", Author = "Imran", Description="This is about Python prgramming book, useful for pythor developer", Category="Basic Programming", Language="English", TotalPage=305},
        //            new BookModel() { Id = 4, Title = "Angular", Author = "Faizal", Description="This is about Angular Front End design, useful for client side programming", Category="Typescript", Language="English", TotalPage=335},
        //            new BookModel() { Id = 5, Title = "React", Author = "Adilet", Description="This is about Reach javascript for professional client side programming", Category="Framework", Language="English", TotalPage=187},
        //            new BookModel() { Id = 6, Title = "AzureDev", Author = "Afrodite", Description="This is about Azure Developement book, for professional leve", Category="Framework", Language="English", TotalPage=288}
        //        };

        //    }
        
    }
}

﻿using AutoMapper;
using BookStore.BLL.DTO;
using BookStore.BLL.Infrastructure;
using BookStore.BLL.Interfaces;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.BLL.Services
{
    public class BookService:IBookService
    {
        private IUnitOfWork database;
        public BookService(IUnitOfWork uow)
        {
            database = uow;
        }

        public IEnumerable<BookDTO> FindBooks(string searchName)
        {
                var books =  database.Books.Find(searchName);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>().ForMember(dto => dto.Author,
                    src => src.MapFrom(b => b.Author.Name)).ForMember(dto => dto.Category,
                    src => src.MapFrom(b => b.Category.CategoryName))).CreateMapper();
                    return mapper.Map<IEnumerable<Book>, List<BookDTO>>(books);
            
        }
        public BookDTO GetBook(int? id)
        {
            if (id == null)
                throw new ValidationException("Book id not set", "");
            var book = database.Books.Get(id.Value);
            if (book == null)
                throw new ValidationException("Book not found", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>().ForMember(dto => dto.Author,
                src => src.MapFrom(b => b.Author.Name)).ForMember(dto => dto.Category,
                src => src.MapFrom(b => b.Category.CategoryName)).ForMember(dto => dto.CategoryId,
                src => src.MapFrom(b => b.Category.Id)).ForMember(dto => dto.AuthorId,
                src => src.MapFrom(b => b.Author.Id))).CreateMapper();
            return mapper.Map<Book, BookDTO>(database.Books.Get(id.Value));

        }

        public IEnumerable<BookDTO> GetBooks(string category,string author)
        {
            IEnumerable<Book> books;
            if (category != null || author !=null)
            {
                books = database.Books.GetAll().Where(b=>b.Category.CategoryName == category || b.Author.Name ==author);

            }
            else
            {
                books = database.Books.GetAll();

            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>().ForMember(dto => dto.Author,
                src => src.MapFrom(b => b.Author.Name)).ForMember(dto => dto.Category,
                src => src.MapFrom(b => b.Category.CategoryName))).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(books);
        }

        public void DeleteBook(int id)
        {
            database.Books.Delete(id);
            database.Save();
            

        }

        public void Update(BookDTO bookDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>()).CreateMapper();
            var book = mapper.Map<BookDTO, Book>(bookDTO);
            database.Books.Update(book);
            database.Save();
        }

        public void CreateBook(BookDTO bookDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>()).CreateMapper();
            var book = mapper.Map<BookDTO, Book>(bookDTO);
            database.Books.Create(book);
            database.Save();
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>().ForMember(dto => dto.Author,
                src => src.MapFrom(b => b.Author.Name)).ForMember(dto => dto.Category,
                src => src.MapFrom(b => b.Category.CategoryName))).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(database.Books.GetAll());
        }
    }
}

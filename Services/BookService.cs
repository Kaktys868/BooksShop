using AutoMapper;
using BooksShop.Classes.Common;
using BooksShop.DTO;
using BooksShop.Interfaces.IRepository;
using BooksShop.Interfaces.IService;
using BooksShop.Models;
using BooksShop.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<IEnumerable<BookDto>> GetAllBookAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task AddBookAsync(CreateBookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.AddAsync(book);
        }

        public async Task UpdateBookAsync(int id, CreateBookDto bookDto)
        {

            var book = await _bookRepository.GetByIdAsync(id);
            _mapper.Map(bookDto, book);
            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }
    }
}
using AutoMapper;
using BooksShop.DTO;
using BooksShop.Models;

namespace BooksShop.Help
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            //Book
            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.BookName))
                .ForMember(dest => dest.BookDateDesign, opt => opt.MapFrom(src => src.BookDateDesign))
                .ForMember(dest => dest.BookCost, opt => opt.MapFrom(src => src.BookCost))
                .ForMember(dest => dest.BookSeries, opt => opt.MapFrom(src => src.BookSeries))
                .ForMember(dest => dest.BookGenre, opt => opt.MapFrom(src => src.BookGenre))
                .ForMember(dest => dest.BookPublisher, opt => opt.MapFrom(src => src.BookPublisher));

            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.BookName))
                .ForMember(dest => dest.BookDateDesign, opt => opt.MapFrom(src => src.BookDateDesign))
                .ForMember(dest => dest.BookCost, opt => opt.MapFrom(src => src.BookCost))
                .ForMember(dest => dest.BookSeries, opt => opt.MapFrom(src => src.Series.SeriesId))
                .ForMember(dest => dest.BookGenre, opt => opt.MapFrom(src => src.GenreBooks.FirstOrDefault().Genre.GenreId))
                .ForMember(dest => dest.BookPublisher, opt => opt.MapFrom(src => src.Publishers.PublisherId));

            //Series
            CreateMap<CreateSeriesDto, Series>()
                .ForMember(dest => dest.SeriesName, opt => opt.MapFrom(src => src.SeriesName))
                .ForMember(dest => dest.SeriesDescription, opt => opt.MapFrom(src => src.SeriesDescription));

            CreateMap<Series, SeriesDto>()
                .ForMember(dest => dest.SeriesName, opt => opt.MapFrom(src => src.SeriesName))
                .ForMember(dest => dest.SeriesDescription, opt => opt.MapFrom(src => src.SeriesDescription));

        }
    }
}
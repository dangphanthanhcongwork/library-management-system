using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Application.DTOs.Requests;
using LibraryManagementSystem.Application.DTOs.Responses;

namespace LibraryManagementSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));
            CreateMap<User, UserResponse>();

            CreateMap<CategoryRequest, Category>();
            CreateMap<Category, CategoryResponse>();

            CreateMap<BookRequest, Book>();
            CreateMap<Book, BookResponse>();

            CreateMap<BookBorrowingRequest, BookBorrowing>();
            CreateMap<BookBorrowing, BookBorrowingResponse>();
        }
    }
}
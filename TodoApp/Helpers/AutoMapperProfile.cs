using AutoMapper;
using TodoApp.Data.Entity;
using TodoApp.Models.BusinessModels;
using TodoApp.Models.Dtos;

namespace TodoApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterUserDto, RegisterUserRequest>();
            CreateMap<RegisterUserRequest, AcUser>();
            CreateMap<UserLoginDto, UserLoginRequest>();
            CreateMap<AddTodoDto, AddTodoRequest>();
            CreateMap<DeleteTodoDto, DeleteTodoRequest>();
            CreateMap<UpdateTodoDto, UpdateTodoRequest>();
            CreateMap<GetTodoDto, GetTodoRequest>();
        }
    }
}

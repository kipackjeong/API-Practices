using AppPractice1.Model;
using AutoMapper;
using Dto;

namespace Profiles
{
    public class ToDoUserAccountProfile : Profile
    {
        //CTOR
        public ToDoUserAccountProfile()
        {
            //GET
            CreateMap<ToDoUserAccount, ToDoUserAccountReadDto>();

            //CREATE
            // target -> source
            CreateMap<ToDoUserAccountCreateDto, ToDoUserAccount>();
            
            //UPDATE
            CreateMap<ToDoUserAccountUpdateDto, ToDoUserAccount>();
            
            //PATCH
            CreateMap<ToDoUserAccount, ToDoUserAccountUpdateDto>();
        }
    }
}
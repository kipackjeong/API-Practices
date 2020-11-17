using APIPractice2.Model;
using AutoMapper;
using APIPractice2.Dto;

namespace Profiles
{
    public class CustomerProfile : Profile
    {
        
        public CustomerProfile()
        {
            // Create Map
            CreateMap<Customer,CustomerReadDto>();



            CreateMap<CustomerCreatedDto, Customer>();
            


            CreateMap<Customer, CustomerUpdateDto>();
            CreateMap<CustomerUpdateDto, Customer>();
            

        }
            
    }
}
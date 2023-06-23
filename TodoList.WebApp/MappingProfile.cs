using AutoMapper;
using TodoList.WebApp.Models.UserViewModel;
using TodoList.WebApp.Services.Base;

namespace TodoList.WebApp
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        { 
            CreateMap<RegisterVM,RegistrationRequest>().ReverseMap();
        }
    }
}

namespace Student_Management_Sys.Helpers;

using AutoMapper;
using Student_Management_Sys.Entities;
using Student_Management_Sys.Models;
using Student_Management_Sys.Models.Users;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // User -> AuthenticateResponse
        CreateMap<User, AuthenticateResponse>();

        // RegisterRequest -> User
        CreateMap<RegisterRequest, User>();

        // RegisterRequest -> Student
        CreateMap<StudentRegister, Student>();

        // RegisterRequest -> Category
        CreateMap<CategoryCreate, Category>();

        // UpdateRequest -> User
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));

        // UpdateRequest -> Student
        CreateMap<StudentUpdate, Student>()
           .ForAllMembers(x => x.Condition(
               (src, dest, prop) =>
               {
                    // ignore null & empty string properties
                   if (prop == null) return false;
                   if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                   return true;
               }
           ));
    }
}
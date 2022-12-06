using AutoMapper;
using TicketingSystemAPI.Entities;
using TicketingSystemAPI.Models;

namespace TicketingSystemAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<Entities.User, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<RegisterModel, Entities.User>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, Entities.User>()
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
}
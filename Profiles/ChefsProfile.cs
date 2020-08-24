using AutoMapper;
using ChefAPI.Details;
using ChefAPI.Models;

namespace ChefAPI.Profiles
{
    public class ChefProfiles : Profile
    {
        public ChefProfiles()
        {
            // Source -> Destination
            CreateMap<Chef, Chef_Details>();
            CreateMap<ChefCreate_Details, Chef>();
            CreateMap<ChefUpdate_Details, Chef>();
            CreateMap<Chef, ChefUpdate_Details>();
        }
    }
}
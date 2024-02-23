using AutoMapper;
using Microsoft.Win32;
using TestProjectBackend.Models.DTO;
using TestProjectBackend.Models.Entities;
using TestProjectBackend.Models.Requests;

namespace ProductsManagement.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
          
            CreateMap<RegisterRequest, Korisnik>().ForMember(dest => dest.Password, opt => opt.Ignore());
            CreateMap<Korisnik, KorisnikDTO>();
            CreateMap<KorisnikDTO, Korisnik>();

        }
    }
}
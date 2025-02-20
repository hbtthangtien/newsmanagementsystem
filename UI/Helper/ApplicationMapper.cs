using AutoMapper;
using Persistences.Entities;
using UI.Models;

namespace UI.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<LoginModel, SystemAccount>().ReverseMap();
        }
    }
}

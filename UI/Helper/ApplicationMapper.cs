using AutoMapper;
using Persistences.Entities;
using UI.Areas.Staff.Models;
using UI.Models;

namespace UI.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<LoginModel, SystemAccount>().ReverseMap()
                    .ForMember(dest => dest.Password, otp => otp.MapFrom(src => src.AccountPassword))
                    .ForMember(dest => dest.Email, otp => otp.MapFrom(src =>src.AccountEmail))
                    .ReverseMap();
            CreateMap<NewsArticleViewModel, NewsArticle>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();
        }
    }
}

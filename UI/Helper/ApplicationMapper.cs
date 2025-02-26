using Application.DTOs;
using AutoMapper;
using Persistences.Entities;
using System.Linq;
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
            CreateMap<NewsArticleModel, NewsArticle>().ReverseMap()
                    .ForMember(dest => dest.CreatedBy, e => e.MapFrom(src => src.CreatedBy!.AccountName))
                    .ForMember(dest => dest.Category, e => e.MapFrom(src => src.Category!.CategoryName))
                    .ForMember(dest => dest.Tags, e => e.MapFrom(src => string.Join(";",src.Tags.Select(e => e.TagId))))
                    .ReverseMap();
            CreateMap<TagModel, Tag>().ReverseMap();
            CreateMap<NewsArticleModel,NewsArticleDTO>().ReverseMap();
            CreateMap<AccountModel, SystemAccount>().ReverseMap();
            CreateMap<Areas.Admin.Models.AccountModel,SystemAccount>().ReverseMap();
        }
    }
}

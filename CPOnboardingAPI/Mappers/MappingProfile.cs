using AutoMapper;
using CPOnboardingAPI.Dtos.Requests;
using CPOnboardingAPI.Dtos.Responses;
using CPOnboardingAPI.Models;

namespace CPOnboardingAPI.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseQuestionRequest, BaseQuestionResponse>().ReverseMap();
            CreateMap<DropdownQuestionRequest, DropdownQuestionResponse>().ReverseMap();
            CreateMap<DateQuestionRequest, DateQuestionResponse>().ReverseMap();
            CreateMap<NumberQuestionRequest, NumberQuestionResponse>().ReverseMap();


            //
            CreateMap<BaseQuestionRequest, ParagraphQuestion>();
            CreateMap<DropdownQuestionRequest, DropdownQuestion>();
            CreateMap<DateQuestionRequest, DateQuestion>();
            CreateMap<NumberQuestionRequest, NumberQuestion>();

            CreateMap<BaseQuestionRequest, BaseQuestionResponse>().ReverseMap();
            CreateMap<DropdownQuestionRequest, DropdownQuestionResponse>().ReverseMap();
            CreateMap<DateQuestionRequest, DateQuestionResponse>().ReverseMap();
            CreateMap<NumberQuestionRequest, NumberQuestionResponse>().ReverseMap();

            CreateMap<ParagraphQuestion, BaseQuestionResponse>().ReverseMap();
            CreateMap<DropdownQuestion, DropdownQuestionResponse>().ReverseMap();
            CreateMap<DateQuestion, DateQuestionResponse>().ReverseMap();
            CreateMap<NumberQuestion, NumberQuestionResponse>().ReverseMap();


            CreateMap<ApplicationTemplateRequest, ApplicationTemplateResponse>()
                .ReverseMap();
        }
    }
}

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
            CreateMap<BaseQuestion, BaseQuestion>(); // This is the base mapping
            CreateMap<ParagraphQuestion, ParagraphQuestion>();
            CreateMap<DropdownQuestion, DropdownQuestion>();
            CreateMap<DateQuestion, DateQuestion>();
            CreateMap<YesOrNoQuestion, YesOrNoQuestion>();

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
            CreateMap<BaseQuestion, BaseQuestionResponse>().ReverseMap();

            CreateMap<BaseQuestionRequest, ParagraphQuestion>(). ReverseMap();
            CreateMap<BaseQuestionRequest, DropdownQuestion>().ReverseMap();
            CreateMap<BaseQuestionRequest, DateQuestion>().ReverseMap();
            CreateMap<BaseQuestionRequest, YesOrNoQuestion>().ReverseMap();
            CreateMap<BaseQuestionRequest, NumberQuestion>().ReverseMap();


           
            CreateMap<ApplicationTemplateRequest, ApplicationTemplate>()
            .ForMember(dest => dest.CustomQuestions, opt => opt.MapFrom(src => src.CustomQuestions));

            CreateMap<BaseQuestionRequest, BaseQuestion>()
                .ConstructUsing((src, ctx) =>
                {
                    switch (src.Type)
                    {
                        case QuestionType.Paragraph:
                            return ctx.Mapper.Map<ParagraphQuestion>(src);
                        case QuestionType.Dropdown:
                            return ctx.Mapper.Map<DropdownQuestion>(src);
                        case QuestionType.Date:
                            return ctx.Mapper.Map<DateQuestion>(src);
                        case QuestionType.YesOrNo:
                            return ctx.Mapper.Map<YesOrNoQuestion>(src);

                        case QuestionType.Number:
                            return ctx.Mapper.Map<NumberQuestion>(src);
                           
                        default:
                            throw new InvalidOperationException($"Unknown question type: {src.Type}");
                    }
                });

            CreateMap<ApplicationTemplate, ApplicationTemplateResponse>()
                .ReverseMap();
        }
    }
}

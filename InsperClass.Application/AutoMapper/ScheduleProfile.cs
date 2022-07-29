using System;
using System.Collections.Generic;
using System.Text;
using InsperClass.Domain.Entity;
using InsperClass.Domain.Model;
using AutoMapper;

namespace InsperClass.Application.AutoMapper
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, ScheduleViewModel>()
                .ForMember(dest =>
                    dest.Course,
                    opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest =>
                    dest.Class,
                    opt => opt.MapFrom(src => src.Class.Name))
            .ReverseMap();
        }
    }
}

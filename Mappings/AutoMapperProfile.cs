using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Barber.Dtos;
using Barber.Models;

namespace Barber.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //USERS
            CreateMap<User, UserViewDTO>().ReverseMap();

            //SERVICES
            CreateMap<Service, ServiceViewDTO>().ReverseMap();

            //Schedulings

            CreateMap<Scheduling, SchedulingViewDTO>().ReverseMap();
            CreateMap<Scheduling, SchedulingDTO>().ReverseMap();

        }
    }
}
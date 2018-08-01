using AutoMapper;
using myAppService.API.Dto;
using myAppService.API.models;

namespace myAppService.API.utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Train,TrainDto>();

            CreateMap<Scheduler,TrainScheduleDto>();
           
        }       
    }
}
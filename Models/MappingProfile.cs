using AutoMapper;
using StudentDetailApi.Data;

namespace StudentDetailApi.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }

    }
}

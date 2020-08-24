using AutoMapper;
using DataAccessLayer.Entities;
using LogicLayer.DataTransferObjects;

namespace LogicLayer.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Record, RecordDTO>();
            CreateMap<RecordDTO, Record>();
        }
    }
}

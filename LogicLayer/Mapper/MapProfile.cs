using AutoMapper;
using DataAccessLayer.Entities;
using LogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Record, RecordDTO>();
            CreateMap<RecordDTO, Record>();
            CreateMap<IEnumerable<Record>, List<RecordDTO>>();
        }
    }
}

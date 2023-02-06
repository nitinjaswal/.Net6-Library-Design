using AutoMapper;
using Library_Business.Dtos;
using Library_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Business.Mapper
{
    public class MasterBookListProfile: Profile
    {
        public MasterBookListProfile()
        {
            CreateMap<dynamic, MasterBookListDto>();
        }
    }
}

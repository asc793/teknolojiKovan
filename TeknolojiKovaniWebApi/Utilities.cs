using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknolojiKovaniWebApi
{
    public class Utilities
    {
        public static K Map<T, K>(T source, K target)
        {
            AutoMapper.Mapper.Initialize(i => i.CreateMap<T, K>());

            return Mapper.Map<T, K>(source);
        }
    }
}
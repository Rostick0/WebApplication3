using AutoMapper;
using Microsoft.Extensions.Hosting;

namespace WebApplication3.Utils
{
    public class MapperShort
    {
        public static TDestination Get<TSource, TDestination>(TSource values)
        {
            MapperConfiguration config = new(cfg => cfg.CreateMap<TSource, TDestination>());
            Mapper mapper = new(config);

            return mapper.Map<TDestination>(values);
        }
    }
}

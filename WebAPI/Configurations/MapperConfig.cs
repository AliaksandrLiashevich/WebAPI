using AutoMapper;
using System;
using System.Linq;

namespace WebAPI.Configurations
{
    public static class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("BLL")).ToArray();
                cfg.AddProfiles(assemblies);
            });
        }
    }
}

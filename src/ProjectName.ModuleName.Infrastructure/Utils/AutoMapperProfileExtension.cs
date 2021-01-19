using AutoMapper;
using MediatR;
using ProjectName.ModuleName.Domain.SeedWork;

namespace ProjectName.ModuleName.Infrastructure.Utils
{
    // Source: https://github.com/cloudnative-netcore/netcorekit/blob/master/src/NetCoreKit.Infrastructure/Mappers/AutoMapperProfileExtension.cs
    public static class AutoMapperProfileExtension
    {
        public static Profile MapMySelf<TSource>(this Profile profile) where TSource : Entity
        {
            profile.CreateMap(typeof(TSource), typeof(TSource)).ReverseMap();
            return profile;
        }

        public static Profile MapTo<TSource, TDestination>(this Profile profile)
        {
            profile.CreateMap(typeof(TSource), typeof(TDestination)).ReverseMap();
            return profile;
        }

        public static Profile MapToNotification<TSource, TDestination>(this Profile profile)
        {
            // Source: https://stackoverflow.com/questions/13075588/configure-automapper-to-map-to-concrete-types-but-allow-interfaces-in-the-defini/13075915
            profile.CreateMap(typeof(TSource), typeof(TDestination));
            profile.CreateMap(typeof(TSource), typeof(INotification)).As(typeof(TDestination));
            return profile;
        }
    }
}

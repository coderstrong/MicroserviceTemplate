using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Reflection;

namespace ProjectName.Api.Infrastructure
{
    public class ServiceConfig
    {
        public static void RegisterService(IConfiguration Configuration, IServiceCollection services)
        {
            Assembly assembly = Assembly.Load("ProjectName.Bussiness");
            var serviceList = new List<ServiceInfo>();
            Configuration.GetSection("DIServices").Bind(serviceList);
            foreach (var service in serviceList)
            {
                services.Add(new ServiceDescriptor(
                    assembly.GetType(service.ServiceType),
                    assembly.GetType(service.ImplementationType),
                    service.Lifetime
                ));
            }
        }
    }

    public class ServiceInfo
    {
        public string ServiceType { get; set; }
        public string ImplementationType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceLifetime Lifetime { get; set; }
    }
}
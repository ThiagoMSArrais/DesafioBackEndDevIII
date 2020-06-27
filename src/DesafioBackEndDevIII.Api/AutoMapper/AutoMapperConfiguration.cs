using AutoMapper;
using DesafioBackEndDevIII.Api.DTO;
using DesafioBackEndDevIII.Domain.Clientes;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioBackEndDevIII.Api.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Endereco, EnderecoDto>().ReverseMap();
        }
    }

    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new AutoMapperConfiguration());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

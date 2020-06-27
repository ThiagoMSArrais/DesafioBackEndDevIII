using DesafioBackEndDevIII.Domain.Clientes.Interfaces;
using DesafioBackEndDevIII.Domain.Clientes.Service;
using DesafioBackEndDevIII.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioBackEndDevIII.Infra.IoC.BootStrapperInjector
{
    public class NativeInjectorBootStrapper
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            // Model
            services.AddScoped<IClienteService, ClienteService>();

            // Infra Data
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}

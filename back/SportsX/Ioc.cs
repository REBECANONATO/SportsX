using ConsulAPI.Executor;
using ConsulAPI.Models;
using ConsulAPI.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace ConsulAPI
{
    public class IoC
    {
        internal static void SetInjections(IServiceCollection services)
        {
            services.AddTransient<IClienteRepositorio<Cliente>, ClienteRepositorio>();

            services.AddTransient<IAtualizarClienteExecutor, AtualizarClienteExecutor>();
            services.AddTransient<IBuscarClienteExecutor, BuscarClienteExecutor>();
            services.AddTransient<IInserirClienteExecutor, InserirClienteExecutor>();
            services.AddTransient<IDeletarClienteExecutor, DeletarClienteExecutor>();


        }
    }
}

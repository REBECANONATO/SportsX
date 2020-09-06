using ConsulAPI.Executor;
using ConsulAPI.Models;
using ConsulAPI.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsulAPI
{
    public class IoC
    {
        internal static void SetInjections(IServiceCollection services)
        {
            services.AddTransient<IConsultorioRepositorio<Consultorio>, ConsultorioRepositorio>();

            services.AddTransient<IAtualizaConsultorioExecutor, AtualizaConsultorioExecutor>();
            services.AddTransient<IBuscarConsultorioExecutor, BuscarConsultorioExecutor>();
            services.AddTransient<IInserirConsultorioExecutor, InserirConsultorioExecutor>();
            services.AddTransient<IDeletarConsultorioExecutor, DeletarConsultorioExecutor>();

        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Autofac;
using AutoMapper;
using ClubinhoDoBebe.Infra.Repository.Interfaces;

namespace ClubinhoDoBebe.Functions
{
    public static class ServiceDependencies
    {

        private static IServiceCollection Services { get; set; }

        private static void RegistrarRepositorio(string dataBaseConnectionString)
        {
            Services.AddScoped(typeof(IProdutoRepository), typeof(ProdutoRepository));
        }

        private static void RegistrarEventGrid(string topicKeyIndicacaoPremiada)
        {
            Services.AddSingleton<IEventGridClient>(serviceProvider =>
                new EventGridClient(new TopicCredentials(topicKeyIndicacaoPremiada)));
            Services.AddSingleton<IEventGrid, EventGridAgent>();
        }

        private static void RegistrarProfiles()
        {
            Services.AddAutoMapper(typeof(CidadeProfile).GetTypeInfo().Assembly);
        }

        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<ConfiguracoesAplicacao>().As<ConfiguracoesAplicacaoAbstrato>().InstancePerLifetimeScope();

            IoCConfig.Inicializar(builder);
        }

    }
}

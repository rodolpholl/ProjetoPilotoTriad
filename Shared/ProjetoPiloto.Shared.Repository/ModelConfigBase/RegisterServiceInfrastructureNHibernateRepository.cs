using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Event;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace ProjetoPiloto.Shared.Repository.ModelConfigBase
{
    public static class RegisterServiceInfrastructureNHibernateRepository
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, IConfiguration configuration, Assembly infrastrucutureAssembly)
        {
            //TODO: Substituir pelo componente de Secret Voult
            string connectionString = configuration.GetSection("DatabaseConfig:ConnectionString").Value;

            var mapper = new ModelMapper();
            mapper.AddMappings(infrastrucutureAssembly.ExportedTypes);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();


           




            var dbConfiguration = new Configuration();
            dbConfiguration.DataBaseIntegration(c =>
            {
                c.Dialect<PostgreSQLDialect>();
                c.ConnectionString = connectionString;
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.SchemaAction = SchemaAutoAction.Update;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
            });
            dbConfiguration.AddMapping(domainMapping);
           

            //Add Audit Event Listeners to update createtime and updatetime
            dbConfiguration.AppendListeners(ListenerType.PreInsert, new IPreInsertEventListener[] { new AuditEventListeners() });
            dbConfiguration.AppendListeners(ListenerType.PreUpdate, new IPreUpdateEventListener[] { new AuditEventListeners() });
        

            var sessionFactory = dbConfiguration.BuildSessionFactory();

            

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());

            return services;
        }
    }
}

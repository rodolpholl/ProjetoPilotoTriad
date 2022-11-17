using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Event;
using NHibernate.Mapping.ByCode;

namespace ProjetoPiloto.Shared.Repository.ModelConfigBase
{
    public static class RegisterServiceInfrastructureNHibernateRepository
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO: Substituir pelo componente de Secret Voult
            string connectionString = configuration.GetSection("DatabaseConfig:ConnectionString").Value;


            var mapper = new ModelMapper();
            mapper.AddMapping((IConformistHoldersProvider)typeof(RegisterServiceInfrastructureNHibernateRepository).Assembly.ExportedTypes);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var dbConfiguration = new Configuration();
            dbConfiguration.DataBaseIntegration(c =>
            {
                c.Dialect<PostgreSQLDialect>();
                c.ConnectionString = connectionString;
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.SchemaAction = SchemaAutoAction.Validate;
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

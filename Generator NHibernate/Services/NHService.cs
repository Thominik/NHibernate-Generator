using DownloadAPP.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    static class NHService
    {
        private static string _CONNECTION_STRING = null;
        public static ISessionFactory SessionFactory { get; private set; }

        public static void Init(string CONNECTION_STRING)
        {
            try
            {
                _CONNECTION_STRING = CONNECTION_STRING;

                ModelMapper mapper = new ModelMapper();
                mapper.AddMappings(GetMappingTypes());

                Configuration config = GetDbConfigurationNH();
                config.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), null);

                SessionFactory = config.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Configuration GetDbConfigurationNH()
        {
            var configure = new Configuration();
            return configure.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2008Dialect>();
                db.Driver<SqlClientDriver>();
                db.ConnectionString = _CONNECTION_STRING;
                db.LogFormattedSql = false;
                db.LogSqlInConsole = false;
            });
        }

        private static List<Type> GetMappingTypes()
        {
            var m = new List<Type>();  
            m.Add(typeof(ColumMap));
            m.Add(typeof(TableMap));

            return m;
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}

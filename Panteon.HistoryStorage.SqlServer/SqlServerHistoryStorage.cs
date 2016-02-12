using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Autofac.Extras.NLog;
using Dapper;
using Panteon.Sdk.History;

namespace Panteon.HistoryStorage.SqlServer
{
    public class SqlServerHistoryStorage : IHistoryStorage
    {
        private readonly ILogger _logger;
        private readonly IHistoryStorageSettings _settings;

        public SqlServerHistoryStorage(ILogger logger, IHistoryStorageSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public bool Store(HistoryModel historyModel)
        {
            const string Sql = "INSERT HistoryDetail(Name,Details, DateCreated) VALUES (@name,@details,@dateCreated)";

            bool result = false;
            try
            {
                using (var conn = new SqlConnection(_settings.ConnectionString))
                {
                    result = conn.Execute(Sql, new { name = historyModel.Name, details = historyModel.Details, dateCreated = historyModel.DateCreated }) > 0;
                }
            }
            catch (Exception exception)
            {
                _logger.Error("SqlServerHistoryStorage#Store", exception);
            }

            return result;
        }

        public IEnumerable<HistoryModel> Load(string name, DateTime? @from = null, DateTime? to = null)
        {
            //TODO: Impl from to
            const string Sql = "SELECT Id, Name, Details, DateCreated FROM HistoryDetail WITH (NOLOCK)";
            IEnumerable<HistoryModel> result = Enumerable.Empty<HistoryModel>();

            try
            {
                using (var conn = new SqlConnection(_settings.ConnectionString))
                {
                    result = conn.Query<HistoryModel>(Sql).ToList();
                }
            }
            catch (Exception exception)
            {
                _logger.Error("SqlServerHistoryStorage#Load", exception);
            }

            return result;
        }
    }
}

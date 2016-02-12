using System;
using System.Collections.Generic;
using Autofac.Extras.NLog;
using Panteon.Sdk.History;

namespace Panteon.HistoryStorage.SqlServer
{
    public class SqlServerHistoryStorage :IHistoryStorage
    {
        private readonly ILogger _logger;

        public SqlServerHistoryStorage(ILogger logger)
        {
            _logger = logger;
        }

        public bool Store(HistoryModel historyModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HistoryModel> Load(string name, DateTime? @from = null, DateTime? to = null)
        {
            throw new NotImplementedException();
        }
    }
}

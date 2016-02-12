using Panteon.Sdk.History;

namespace Panteon.HistoryStorage.Tests
{
    public class TestHistoryStorageSettings : IHistoryStorageSettings
    {
        public TestHistoryStorageSettings()
        {
            Enabled = true;
            ConnectionString = @"Data Source=.\;Initial Catalog=Panth;Integrated Security=True";
        }
        public string ConnectionString { get; set; }
        public bool Enabled { get; set; }
    }
}
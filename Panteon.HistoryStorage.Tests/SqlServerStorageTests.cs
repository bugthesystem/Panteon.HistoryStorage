using System;
using System.Collections.Generic;
using Autofac.Extras.NLog;
using Common.Testing.NUnit;
using FluentAssertions;
using NUnit.Framework;
using Panteon.HistoryStorage.SqlServer;
using Panteon.Sdk.History;

namespace Panteon.HistoryStorage.Tests
{
    public class SqlServerStorageTests : TestBase
    {
        IHistoryStorage _historyStorage;
        const string TASK_NAME = "TEST";

        protected override void FinalizeSetUp()
        {
            var settings = new TestHistoryStorageSettings();

            _historyStorage = new SqlServerHistoryStorage(new NullLogger(), settings);
        }

        [Test]
        public void StoreTest()
        {

            var store = _historyStorage.Store(new HistoryModel { Details = "Details", Name = TASK_NAME, DateCreated = DateTime.Now });
            store.Should().BeTrue();
        }


        [Test]
        public void LoadTest()
        {
            IEnumerable<HistoryModel> models = _historyStorage.Load(TASK_NAME);
            models.Should().NotBeNullOrEmpty();
        }
    }
}

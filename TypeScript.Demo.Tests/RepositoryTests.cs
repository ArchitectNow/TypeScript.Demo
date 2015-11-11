using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using TypeScript.Demo.Data.Repositories;

namespace TypeScript.Demo.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void BasicRepositoryTests()
        {
            var _container = AutofacConfig.ConfigureContainer();

            var _personRepo = _container.Resolve<IPersonRepository>();

            var _resultTask = _personRepo.GetAll();

            _resultTask.Wait(); //required due to async nature of call..

            var _result = _resultTask.Result;

            Assert.IsNotNull(_result);
            Assert.IsTrue(_result.Count > 0);
        }
    }
}

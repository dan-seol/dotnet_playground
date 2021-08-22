using NUnit.Framework;
using Singleton;
using Autofac;

namespace SingletonTest
{
    [TestFixture]
    public class SingletonTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SingletonTest1()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
            //Assert.Pass();
        }

        [Test] //problems for testing om live db ; sure, R is okay, but what about CUD ?
        public void SingletonTotalPopulationTest()
        {
            var rf = new SingletonRecordFinder();
            var names = new[] {"Seoul", "Mexico City"};
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(17400000 + 17500000));
        }

        [Test]
        public void ConfigurablePopulationTest()
        {
            var rf = new ConfigurableRecordFinder(new DummyDatabase());
            var names = new[] {"alpha", "gamma"};
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(4));
        }

        [Test]
        public void DIPopulationTest()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();
            cb.RegisterType<ConfigurableRecordFinder>();

            using (var c = cb.Build())
            {
                var rf  = c.Resolve<ConfigurableRecordFinder>();
                var names = new[] {"Seoul", "Mexico City"};
                int tp = rf.GetTotalPopulation(names);
                Assert.That(tp, Is.EqualTo(17400000 + 17500000));
            }
            
        }
    }
}
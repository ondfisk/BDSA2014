using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Stuff.Entities;

namespace Stuff.Models.Tests
{
    [TestFixture]
    public class StuffRepositoryTests
    {
        private StuffRepository _repository;
        
        [SetUp]
        public void Setup()
        {
            var stuff = new List<Entities.Stuff>
            {
                new Entities.Stuff {Id = 1, Name = "Good stuff", Cool = true},
                new Entities.Stuff {Id = 2, Name = "Bad stuff", Cool = false},
                new Entities.Stuff {Id = 3, Name = "Very good stuff", Cool = true},
                new Entities.Stuff {Id = 4, Name = "Insanely good stuff", Cool = true}
            };
            var set = new Mock<DbSet<Entities.Stuff>>().SetupData(stuff);

            var context = new Mock<IStuffContext>();
            context.Setup(c => c.Stuff).Returns(set.Object);

            _repository = new StuffRepository(context.Object);
        }

        [Test]
        public async void GetAllGoodStuff_returns_only_good_stuff()
        {
            // Act
            var goodStuff = await _repository.GetAllGoodStuff();
                
            // Assert
            Assert.AreEqual(3, goodStuff.Count);
            Assert.AreEqual("Good stuff", goodStuff.First().Name);
        }

        [TearDown]
        public void TearDown()
        {
            _repository.Dispose();
        }
    }
}

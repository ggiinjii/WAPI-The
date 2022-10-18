using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Wapi_the_Core.DAL;
using Wapi_the_Core.DTO;
using Wapi_the_Services.Services;

namespace Wapi_The_UnitTest
{

    [TestFixture]
    public class Tests
    {
        List<HeroDto> _heroList;
        public Mock<IHeroRepository> _mock_HeroRepo;

        [SetUp]
        [OneTimeSetUp]
        public void Setup()
        {
            _mock_HeroRepo = new Mock<IHeroRepository>(MockBehavior.Strict);

            HeroDto h1 = new HeroDto(1, "Deku", "OneForAll");
            HeroDto h2 = new HeroDto(2, "Green Lantern", "Ring Of Will");
            HeroDto h3 = new HeroDto(3, "Me", "Awsomeness");
            HeroDto h4 = new HeroDto(4, "My Ego", "Ego");
            HeroDto h5 = new HeroDto(5, "My Ego Part 2", "Ego");

            _heroList = new List<HeroDto>();
            _heroList.Add(h1);
            _heroList.Add(h2);
            _heroList.Add(h3);
            _heroList.Add(h4);
            _heroList.Add(h5);
        }

        [Test]
        public void GetHeroesReturnHeroList()
        {
            _mock_HeroRepo.Setup(p => p.GetHeroes()).Returns(_heroList);

            HeroService myService = new HeroService(null, _mock_HeroRepo.Object);
            var test = myService.getHeroes();

            HeroDto h1_r = new HeroDto(1, "Deku", "OneForAll");
            HeroDto h2_r = new HeroDto(2, "Green Lantern", "Ring Of Will");
            HeroDto h3_r = new HeroDto(3, "Me", "Awsomeness");
            HeroDto h4_r = new HeroDto(4, "My Ego", "Ego");
            HeroDto h5_r = new HeroDto(5, "My Ego Part 2", "Ego");

            List<HeroDto> heroList = new List<HeroDto>();
            heroList.Add(h1_r);
            heroList.Add(h2_r);
            heroList.Add(h3_r);
            heroList.Add(h4_r);
            heroList.Add(h5_r);

            for (int i = 0; i < heroList.Count; i++)
            {
                Assert.That(heroList[0].Name, Is.EqualTo(test[0].Name));
                Assert.That(heroList[0].Id, Is.EqualTo(test[0].Id));
                Assert.That(heroList[0].Alter, Is.EqualTo(test[0].Alter));
            }
        }

        [Test]
        public void HeroExistReturnTrue()
        {

            _mock_HeroRepo.Setup(p => p.GetHeroes()).Returns(_heroList);

            HeroService myService = new HeroService(null, _mock_HeroRepo.Object);
            bool test = myService.HeroExists(2);

            Assert.IsTrue(test);
        }

        [Test]
        public void HeroExistReturnFalse()
        {
            _mock_HeroRepo.Setup(p => p.GetHeroes()).Returns(_heroList);
            HeroService myService = new HeroService(null, _mock_HeroRepo.Object);
            bool test = myService.HeroExists(0);

            Assert.IsFalse(test);
        }

        [Test]
        public void CreateIsOkAndReturnObj()
        {
            HeroDto h1_r = new HeroDto(1, "Test", "Test");

            _mock_HeroRepo.Setup(p => p.GetHeroes()).Returns(_heroList);
            _mock_HeroRepo.Setup(p => p.InsertHero(It.IsAny<HeroDto>())).Callback((HeroDto item) => _heroList.Add(item));

            HeroService myService = new HeroService(null, _mock_HeroRepo.Object);

            var test = myService.Create(h1_r);

            Assert.That(test.Name, Is.EqualTo("Test"));
            Assert.That(test.Id, Is.EqualTo(6));
            Assert.That(test.Alter, Is.EqualTo("Test"));
        }

        [Test]
        public void CreateReturnNULL()
        {
            HeroDto h1_r = new HeroDto(1, "Test", "Test");

            _mock_HeroRepo.Setup(p => p.GetHeroes()).Returns(_heroList);
            _mock_HeroRepo.Setup(p => p.InsertHero(It.IsAny<HeroDto>())).Callback((HeroDto item) => _heroList.Add(item));

            HeroService myService = new HeroService(null, _mock_HeroRepo.Object);

            var test = myService.Create(null);
            Assert.IsNull(test);

            h1_r.Alter = null;
            test = myService.Create(h1_r);
            Assert.IsNull(test);

            h1_r.Alter = "test";
            h1_r.Name = null;

            test = myService.Create(h1_r);
            Assert.IsNull(test);
        }

        [Test]
        public void DeleteReturnOk()
        {
            _mock_HeroRepo.Setup(p => p.GetHeroes()).Returns(_heroList);
            _mock_HeroRepo.Setup(p => p.DeleteHero(It.IsAny<int>())).Callback((int item) => _heroList.RemoveAt(item));

            HeroService myService = new HeroService(null, _mock_HeroRepo.Object);
            bool test = myService.Delete(1);

            var listHero = myService.getHeroes();

            Assert.IsTrue(test);
            Assert.That(listHero.Count, Is.EqualTo(4));
        }

        [Test]
        public void EditOkAndReturnObjEdited()
        {
            HeroDto h1_r = new HeroDto(4, "Test", "Test");

            _mock_HeroRepo.Setup(p => p.GetHeroes()).Returns(_heroList);
            _mock_HeroRepo.Setup(p => p.UpdateHero(h1_r)).Callback((HeroDto item) => _heroList.Contains(item));

            HeroService myService = new HeroService(null, _mock_HeroRepo.Object);

            var test = myService.Edit(4, h1_r);

            Assert.That(test.Name, Is.EqualTo("Test"));
            Assert.That(test.Id, Is.EqualTo(4));
            Assert.That(test.Alter, Is.EqualTo("Test"));
        }

        [Test]
        public void EditReturnNull()
        {
            HeroDto h1_r = new HeroDto(4, "Test", "Test");

            _mock_HeroRepo.Setup(p => p.GetHeroes()).Returns(_heroList);
            _mock_HeroRepo.Setup(p => p.UpdateHero(h1_r)).Callback((HeroDto item) => _heroList.Contains(item));

            HeroService myService = new HeroService(null, _mock_HeroRepo.Object);

            var test = myService.Edit(2, h1_r);

            Assert.IsNull(test);
        }

        [Test]
        public void GetHeroIdReturnOk()
        {
            var dido = _heroList.ElementAt(3);

            _mock_HeroRepo.Setup(p => p.GetHeroes()).Returns(_heroList);
            _mock_HeroRepo.Setup(p => p.GetHeroByID(3)).Returns(_heroList.ElementAt(3));

            HeroService myService = new HeroService(null, _mock_HeroRepo.Object);
            var test = myService.getHeroId(3);

            Assert.That(test.Name, Is.EqualTo("My Ego"));
            Assert.That(test.Id, Is.EqualTo(4));
            Assert.That(test.Alter, Is.EqualTo("Ego"));
        }

    }
}
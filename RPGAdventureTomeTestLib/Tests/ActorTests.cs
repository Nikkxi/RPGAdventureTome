using RPGAdventureTome.Actors;
using NUnit.Framework;
using RPGAdventureTomeTestLib.Utils;
using System.Collections.Generic;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace RPGAdventureTomeTestLib.Tests
{
    [TestFixture(Author = "SupCMDr", Description = "Actor Creation Tests")]
    class ActorTests
    {
        private DataLoader loader;
        private ILogger logger;

        private LoggingConfiguration config;
        private FileTarget logfile;
        private ConsoleTarget logconsole;

        [OneTimeSetUp]
        public void Setup()
        {
            loader = new DataLoader();
            logger = LogManager.GetCurrentClassLogger();

            logger.Log(LogLevel.Info, "=== BEGIN ACTOR LOADER TESTS ===");
        }

        [OneTimeTearDown]
        public void TearDown(){
            logger.Log(LogLevel.Info, "");
        }

        [Test]
        public void CreateBreedsTest()
        {
            int health = 10;
            int attack = 3;

            Breed newBreed = new Breed("Orc", health, attack);

            //Assert.NotNull(newBreed, "The new breed was not created.");
        }

        [Test]
        public void LoadBreedsTest()
        {
            logger.Info("TEST: " + TestContext.CurrentContext.Test.Name);

            List<Breed> breeds = loader.LoadMonsterBreeds();

            Assert.That(breeds, Is.Not.Empty);
            Assert.That(breeds.Count, Is.Positive);

            foreach(Breed breed in breeds){
                logger.Info("Breed: " + breed.name);
                if(breed.parent != null)
                    logger.Info("Parent:  " + breed.parent.name);
                logger.Info("Health: " + breed.health);
                logger.Info("Attack: " + breed.attack);
                logger.Info("");
            }
        }

        [Test]
        public void CloneMonsterTest()
        {
            logger.Info("TEST: " + TestContext.CurrentContext.Test.Name);
            List<Breed> breeds = loader.LoadMonsterBreeds();
            Assert.That(breeds, Is.Not.Empty);

            List<Monster> clones = new List<Monster>();
            Assert.That(clones, Is.Empty);
            logger.Info("Clones count: " + clones.Count);

            foreach(Breed breed in breeds)
            {
                logger.Info("Breed: " + breed.GetName());
                var monster = breed.newMonster();
                Assert.That(monster, Is.Not.Null);
                //clones.Add(breed.newMonster());
                //logger.Info("Clones count: " + clones.Count);
            }

            int index = 0;
            foreach(Monster clone in clones)
            {
                Assert.That(clone.GetName(), Is.EqualTo(breeds[index].GetName()));
                index++;
            }
        }
    }
}

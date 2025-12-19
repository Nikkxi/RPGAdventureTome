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
    class MonsterTests
    {
        private DataHandler loader;
        private Logger logger;

        [OneTimeSetUp]
        public void Setup()
        {
            loader = new DataHandler();
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
            logger.Info("Breeds count: " + breeds.Count);

            List<Monster> monsters = new List<Monster>();
            Assert.That(monsters, Is.Empty);
            logger.Info("Monsters count: " + monsters.Count);

            foreach(Breed breed in breeds)
            {
                //logger.Info("Breed: " + breed.GetName());
                var monster = breed.newMonster();
                Assert.That(monster, Is.Not.Null);
                monsters.Add(breed.newMonster());
                logger.Info("Monster cloned: " + monster.GetName());
            }
            
            logger.Info("Monster count: " + monsters.Count);

            int index = 0;
            foreach(Monster clone in monsters)
            {
                Assert.That(clone.GetName(), Is.EqualTo(breeds[index].GetName()));
                index++;
            }
        }

        [Test]
        public void DamageMonsterTest()
        {
            logger.Info("TEST: " + TestContext.CurrentContext.Test.Name);
            
            int health = 10;
            int attack = 3;

            Breed newBreed = new Breed("Orc", health, attack);

            var monster = newBreed.newMonster();
            
            Assert.That(monster, Is.Not.Null);
            Assert.That(monster.getCurrentHealth(), Is.EqualTo(health));

            monster.TakeDamage(attack);
            
            Assert.That(monster.getCurrentHealth(), Is.EqualTo(health-attack));
        }

        [Test]
        public void HealMonsterTest()
        {
            logger.Info("TEST: " + TestContext.CurrentContext.Test.Name);

            int health = 10;
            int attack = 3;

            Breed newBreed = new Breed("Troll", health, attack);
            
            var monster = newBreed.newMonster();
            
            Assert.That(monster, Is.Not.Null);
            monster.TakeDamage(attack);
            Assert.That(monster.getCurrentHealth(), Is.EqualTo(health-attack));
            
            monster.Heal(attack);
            Assert.That(monster.getCurrentHealth(), Is.EqualTo(health));
        }
    }
}

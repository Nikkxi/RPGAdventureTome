using System.Collections.Generic;

using NUnit.Framework;

using NLog;

using RPGAdventureTomeTestLib.Utils;
using RPGAdventureTome.Items.Equipment;
using RPGAdventureTome.Capabilities;
using RPGAdventureTome.Items;

namespace RPGAdventureTomeTestLib.Tests
{
    [TestFixture(Author = "SupCMDr", Description = "Weapon Data Loading Tests")]
    public class ArmorTests
    {
        private DataHandler loader;
        private ILogger logger;


        [OneTimeSetUp]
        public void Setup()
        {
            loader = new DataHandler();
            logger = LogManager.GetCurrentClassLogger();

            logger.Log(LogLevel.Info, "=== BEGIN ARMOR LOADER TESTS ===");
        }

        [OneTimeTearDown]
        public void TearDown(){
            logger.Log(LogLevel.Info, "");
        }

        [Test]
        public void CreateNewArmor(){
            string Name = "Test Armor";
            string Description = "Test Armor Descriptions";
            
            var newItem = new Armor(Name, Description);

            Assert.That(newItem, Is.Not.Null);
            Assert.That(newItem.name, Is.Not.Null);
            Assert.That(newItem.description, Is.Not.Null);
        }

        [Test]
        public void CreateNewArmor2(){
            var newItem = new Armor(
                "Spiked Shield",
                "A round shield with spikes on the front."
            );
            newItem.AddAttack(new Attack(){minDamage=1,maxDamage=6,range=1});
            newItem.AddDefense(new Defense(){armor=10,dodgeChance=70});

            Assert.That(newItem, Is.Not.Null);
            Assert.That(newItem.name, Is.Not.Null);
            Assert.That(newItem.attack, Is.Not.Null);
            Assert.That(newItem.defense, Is.Not.Null);
            Assert.That(newItem.usables, Is.Not.Null);
            Assert.That(newItem.usables, Is.Empty);
        }

        [Test(Description="Load Weapons test")]
        public void LoadArmorTest(){
            List<Armor> armorList = loader.LoadArmor();

            logger.Info("Number of Armors Loaded: " + armorList.Count);
            Assert.That(armorList.Count, Is.Positive);

            foreach(Equipment armor in armorList)
            {
                logger.Info("======================");
                Assert.That(armor, Is.Not.Null);

                Assert.That(armor.name, Is.Not.Null);
                logger.Info("name: " + armor.name);

                Assert.That(armor.description, Is.Not.Null);
                logger.Info("Description: " + armor.description);

                Assert.That(armor.defense, Is.Not.Null);
                logger.Info("Armor: " + armor.defense.armor);
                //Assert.That(armor.Defense.DodgeChance, Is.Not.EqualTo(0));
                logger.Info("Dodge Chance: " + armor.defense.dodgeChance);
            }
        }
    }
}
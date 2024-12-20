using System.Collections.Generic;

using NUnit.Framework;

using NLog;
using NLog.Config;
using NLog.Targets;

using RPGAdventureTomeTestLib;
using RPGAdventureTomeTestLib.Utils;
using RPGAdventureTome.Items;
using RPGAdventureTome.Capabilities;

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
            var newItem = new Item();
            newItem.ItemName = "Test Armor";
            newItem.Description = "Test Armor Descriptions";

            Assert.That(newItem, Is.Not.Null);
            Assert.That(newItem.ItemName, Is.Not.Null);
            Assert.That(newItem.Description, Is.Not.Null);
        }

        [Test]
        public void CreateNewArmor2(){
            var newItem = new Item(
                "Spiked Shield",
                "A round shield with spikes on the front.",
                new Attack(){MinDamage=1,MaxDamage=6,Range=1},
                new Defense(){Armor=10,DodgeChance=70}
            );

            Assert.That(newItem, Is.Not.Null);
            Assert.That(newItem.ItemName, Is.Not.Null);
            Assert.That(newItem.Attack, Is.Not.Null);
            Assert.That(newItem.Defense, Is.Not.Null);
            Assert.That(newItem.Usables, Is.Not.Null);
            Assert.That(newItem.Usables, Is.Empty);
        }

        [Test(Description="Load Weapons test")]
        public void LoadArmorTest(){
            List<Item> armorList = loader.loadArmor();

            logger.Info("Number of Armors Loaded: " + armorList.Count);
            Assert.That(armorList.Count, Is.Positive);

            foreach(Item armor in armorList)
            {
                logger.Info("======================");
                Assert.That(armor, Is.Not.Null);

                Assert.That(armor.ItemName, Is.Not.Null);
                logger.Info("Name: " + armor.ItemName);

                Assert.That(armor.Description, Is.Not.Null);
                logger.Info("Description: " + armor.Description);

                logger.Info("Armor: " + armor.Defense.Armor);
                //Assert.That(armor.Defense.DodgeChance, Is.Not.EqualTo(0));
                logger.Info("Dodge Chance: " + armor.Defense.DodgeChance);
            }
        }
    }
}
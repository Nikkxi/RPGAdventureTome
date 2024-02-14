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
        private DataLoader loader;
        private ILogger logger;


        [OneTimeSetUp]
        public void Setup()
        {
            loader = new DataLoader();
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
            Assert.That(newItem.attack, Is.Not.Null);
            Assert.That(newItem.defense, Is.Not.Null);
            Assert.That(newItem.uses, Is.Empty);
        }

        [Test(Description="Load Weapons test")]
        public void LoadArmorTest(){
            List<Item> armorList = loader.loadArmor();
            
            Assert.That(armorList.Count, Is.Not.EqualTo(0));

            foreach(Item armor in armorList)
            {
                logger.Info("======================");
                Assert.That(armor, Is.Not.Null);

                Assert.That(armor.ItemName, Is.Not.Null);
                logger.Info(armor.ItemName);

                Assert.That(armor.Description, Is.Not.Null);
                logger.Info(armor.Description);

                Assert.That(armor.defense.Armor, Is.Not.EqualTo(0));
                logger.Info(armor.defense.Armor);
                Assert.That(armor.defense.DodgeChance, Is.Not.EqualTo(0));
                logger.Info(armor.defense.DodgeChance);
            }
        }
    }
}
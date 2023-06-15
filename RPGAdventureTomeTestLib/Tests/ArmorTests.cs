using RPGAdventureTomeTestLib;
using RPGAdventureTomeTestLib.Utils;
using RPGAdventureTome.Items;
using RPGAdventureTome.Capabilities;
using System.Collections.Generic;
using NUnit.Framework;
using NLog;
using NLog.Config;
using NLog.Targets;

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
            Item newItem = new Item();
            newItem.ItemName = "Test Armor";
            newItem.ItemType = ItemType.ARMOR;
            newItem.Defense = new Defense();
            newItem.Defense.Armor = 12;
            newItem.Defense.DodgeChance = 80;

            Assert.IsNotNull(newItem);
            Assert.IsNotNull(newItem.ItemName);
            Assert.IsNotNull(newItem.ItemType);
            Assert.IsNotNull(newItem.Melee);
            Assert.IsNotNull(newItem.Range);
            Assert.IsNotNull(newItem.Defense);
            Assert.IsEmpty(newItem.Uses);

            StringAssert.AreEqualIgnoringCase(newItem.ItemName, "Test Armor");
            Assert.AreEqual(newItem.ItemType, ItemType.ARMOR);
            Assert.AreEqual(newItem.Defense.Armor, 12);
            Assert.AreEqual(newItem.Defense.DodgeChance, 80);
        }

        [Test]
        public void CreateNewArmor2(){
            Item newItem = new Item(
                "Test Armor 2", 
                ItemType.ARMOR,
                new Attack(){MinDamage=1,MaxDamage=6},
                new Attack(){MinDamage=2,MaxDamage=4},
                new Defense(){Armor=10,DodgeChance=70},
                new List<Use>()
            );

            Assert.IsNotNull(newItem);
            Assert.IsNotNull(newItem.ItemName);
            Assert.IsNotNull(newItem.ItemType);
            Assert.IsNotNull(newItem.Melee);
            Assert.IsNotNull(newItem.Range);
            Assert.IsNotNull(newItem.Defense);
            Assert.IsEmpty(newItem.Uses);
        }

        [Test(Description="Load Weapons test")]
        public void LoadArmorTest(){
            List<Item> armorList = loader.loadArmor();
            
            Assert.NotZero(armorList.Count);

            foreach(Item armor in armorList)
            {
                logger.Info("======================");
                Assert.IsNotNull(armor);

                Assert.IsNotNull(armor.ItemName);
                logger.Info(armor.ItemName);

                Assert.AreEqual(armor.ItemType, ItemType.ARMOR, "The Item Type is not ARMOR.");
                logger.Info(armor.ItemType);

                Assert.IsNotNull(armor.Defense.Armor);
                logger.Info(armor.Defense.Armor);
                Assert.IsNotNull(armor.Defense.DodgeChance);
                logger.Info(armor.Defense.DodgeChance);
            }
        }
    }
}
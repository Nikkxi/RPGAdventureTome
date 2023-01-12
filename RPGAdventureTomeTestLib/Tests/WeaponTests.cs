using RPGAdventureTomeTestLib;
using RPGAdventureTomeTestLib.Utils;
using RPGAdventureTome.Items;
using RPGAdventureTome.Capabilities;
using System.Collections.Generic;
using System;
using NUnit.Framework;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace RPGAdventureTomeTestLib.Tests
{
    [TestFixture(Author = "SupCMDr", Description = "Weapon Data Loading Tests")]
    public class WeaponTests
    {
        private DataLoader loader;
        private ILogger logger;

        private LoggingConfiguration config;
        private FileTarget logfile;
        private ConsoleTarget logconsole;

        [SetUp]
        public void Setup()
        {
            loader = new DataLoader();
            logger = LogManager.GetCurrentClassLogger();
        }

        [Test]
        public void CreateNewWeapon(){
            Item newItem = new Item();
            newItem.ItemName = "Test Sword";
            newItem.ItemType = ItemType.SWORD;
            newItem.Melee = new Attack();
            newItem.Melee.MinDamage = 1;
            newItem.Melee.MaxDamage = 4;

            Assert.IsNotNull(newItem);
            Assert.IsNotNull(newItem.ItemName);
            Assert.IsNotNull(newItem.ItemType);
            Assert.IsNotNull(newItem.Melee);
            Assert.IsNotNull(newItem.Melee.MinDamage);
            Assert.IsNotNull(newItem.Melee.MaxDamage);
        }

        [Test(Description="Load Weapons test")]
        public void LoadWeaponsTest(){
            List<Item> weaponList = loader.loadWeapons();
            
            logger.Info("Number of Weapons Loaded: " + weaponList.Count);
            Assert.NotZero(weaponList.Count);

            foreach(Item weapon in weaponList)
            {
                logger.Info("======================");
                Assert.IsNotNull(weapon);

                Assert.IsNotNull(weapon.ItemName);
                logger.Info(weapon.ItemName);

                Assert.IsNotNull(weapon.ItemType);
                logger.Info(weapon.ItemType);

                if(weapon.ItemType != ItemType.BOW && weapon.ItemType != ItemType.POTION)
                {
                    Assert.IsNotNull(weapon.Melee);
                    Assert.IsNotNull(weapon.Melee.MinDamage);
                    logger.Info(weapon.Melee.MinDamage);
                    Assert.IsNotNull(weapon.Melee.MaxDamage);
                    logger.Info(weapon.Melee.MaxDamage);
                }
                
                if(weapon.ItemType == ItemType.BOW)
                {
                    Assert.IsNotNull(weapon.Range);
                    Assert.IsNotNull(weapon.Range.MinDamage);
                    logger.Info(weapon.Range.MinDamage);
                    Assert.IsNotNull(weapon.Range.MaxDamage);
                    logger.Info(weapon.Range.MaxDamage);
                }
                
                if(weapon.ItemType == ItemType.POTION)
                {  
                    Console.WriteLine("No weapon should have a POTION item type!");
                    Assert.Fail("No weapon should have a POTION item type!");
                }
            }
        }
    }
}
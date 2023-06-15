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


        [OneTimeSetUp]
        public void Setup()
        {
            loader = new DataLoader();
            logger = LogManager.GetCurrentClassLogger();

            logger.Log(LogLevel.Info, "=== BEGIN WEAPON LOADER TESTS ===");
        }

        [OneTimeTearDown]
        public void TearDown(){
            logger.Log(LogLevel.Info, "");
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
            Assert.AreEqual(newItem.Melee.MinDamage, 1);
            Assert.AreEqual(newItem.Melee.MaxDamage, 4);
        }

        [Test]
        public void CreateNewWeapon2(){
            Item newItem = new Item(
                "Test Sword 2",
                ItemType.SWORD,
                new Attack(){MinDamage=1, MaxDamage=4},
                new Attack(){MinDamage=0, MaxDamage=0},
                new Defense(){Armor=0,DodgeChance=0},
                new List<Use>()
            );

            Assert.IsNotNull(newItem);
            Assert.IsNotNull(newItem.ItemName);
            Assert.IsNotNull(newItem.ItemType);
            Assert.IsNotNull(newItem.Melee);
            Assert.IsNotNull(newItem.Range);
            Assert.IsNotNull(newItem.Defense);
            Assert.IsEmpty(newItem.Uses);
            Assert.AreEqual(newItem.Melee.MinDamage, 1);
            Assert.AreEqual(newItem.Melee.MaxDamage, 4);
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
using System;
using System.Collections.Generic;
using NLog;
using NLog.Config;
using NLog.Targets;
using NUnit.Framework;
using RPGAdventureTome.Capabilities;
using RPGAdventureTome.Items;
using RPGAdventureTomeTestLib;
using RPGAdventureTomeTestLib.Utils;

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
        public void TearDown()
        {
            logger.Log(LogLevel.Info, "");
        }

        [Test]
        public void CreateNewWeapon()
        {
            var newItem = new Item();
            newItem.ItemName = "Test Melee Weapon";
            newItem.Description = "A simple test melee weapon.";
            newItem.attack = new Attack();
            newItem.attack.MinDamage = 1;
            newItem.attack.MaxDamage = 4;
            newItem.attack.Range = 1;

            Assert.That(newItem, Is.Not.Null);
            Assert.That(newItem.Description, Is.Not.Null);
            Assert.That(newItem.attack, Is.Not.Null);
            Assert.That(newItem.attack.MinDamage, Is.EqualTo(1));
            Assert.That(newItem.attack.MaxDamage, Is.EqualTo(4));
            Assert.That(newItem.attack.Range, Is.EqualTo(1));

            Assert.That(newItem.defense, Is.Null);
            Assert.That(newItem.uses, Is.Empty);
        }

        [Test]
        public void CreateNewWeapon2()
        {
            var newItem = new Item(
                "Test Ranged Weapon",
                "A sample test ranged weapon",
                new Attack() { MinDamage = 1, MaxDamage = 4 , Range = 3},
                new Defense() { Armor = 0, DodgeChance = 0 }
            );

            Assert.That(newItem, Is.Not.Null);
            Assert.That(newItem.ItemName, Is.Not.Null);
            Assert.That(newItem.Description, Is.Not.Null);
            Assert.That(newItem.attack, Is.Not.Null);
            Assert.That(newItem.defense, Is.Not.Null);
            Assert.That(newItem.uses, Is.Empty);
            Assert.That(newItem.attack.MinDamage, Is.EqualTo(1));
            Assert.That(newItem.attack.MaxDamage, Is.EqualTo(4));
            Assert.That(newItem.attack.Range, Is.EqualTo(3));
        }

        [Test(Description = "Load Weapons test")]
        public void LoadWeaponsTest()
        {
            List<Item> weaponList = loader.loadWeapons();

            logger.Info("Number of Weapons Loaded: " + weaponList.Count);
            Assert.That(weaponList.Count, Is.Positive);

            foreach (Item weapon in weaponList)
            {
                logger.Info("======================");
                Assert.That(weapon, Is.Not.Null);

                Assert.That(weapon.ItemName, Is.Not.Null);
                logger.Info(weapon.ItemName);

                Assert.That(weapon.Description, Is.Not.Null);
                logger.Info(weapon.Description);

                Assert.That(weapon.attack, Is.Not.Null);
                Assert.That(weapon.attack.MinDamage, Is.Positive);
                logger.Info(weapon.attack.MinDamage);
                Assert.That(weapon.attack.MaxDamage, Is.Positive);
                logger.Info(weapon.attack.MaxDamage);

            }
        }
    }
}
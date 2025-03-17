using System;
using System.Collections.Generic;
using NLog;
using NLog.Config;
using NLog.Targets;
using NUnit.Framework;
using RPGAdventureTome.Capabilities;
using RPGAdventureTome.Items;
using RPGAdventureTome.Items.Equipment;
using RPGAdventureTomeTestLib;
using RPGAdventureTomeTestLib.Utils;

namespace RPGAdventureTomeTestLib.Tests
{
    [TestFixture(Author = "SupCMDr", Description = "Weapon Data Loading Tests")]
    public class WeaponTests
    {
        private DataHandler loader;
        private ILogger logger;


        [OneTimeSetUp]
        public void Setup()
        {
            loader = new DataHandler();
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
            string name = "Test Melee Weapon";
            string description = "A simple test melee weapon.";
            var newItem = new Weapon(name, description, WeaponType.SWORD);
            newItem.AddAttack(new Attack(1, 4, 1));

            Assert.That(newItem, Is.Not.Null);
            Assert.That(newItem.description, Is.Not.Null);
            Assert.That(newItem.attack, Is.Not.Null);
            Assert.That(newItem.attack.minDamage, Is.EqualTo(1));
            Assert.That(newItem.attack.maxDamage, Is.EqualTo(4));
            Assert.That(newItem.attack.range, Is.EqualTo(1));
            Assert.That(newItem.weaponType, Is.EqualTo(WeaponType.SWORD));

            Assert.That(newItem.defense, Is.Null);
            Assert.That(newItem.usables, Is.Empty);
        }

        [Test]
        public void CreateNewWeapon2()
        {
            var newItem = new Weapon(
                "Test Ranged Weapon",
                "A sample test ranged weapon",
                WeaponType.STAFF
            );
            newItem.AddAttack(new Attack() { minDamage = 1, maxDamage = 4 , range = 3});
            newItem.AddDefense(new Defense() { armor = 0, dodgeChance = 0 });
            
            Assert.That(newItem, Is.Not.Null);
            Assert.That(newItem.name, Is.Not.Null);
            Assert.That(newItem.description, Is.Not.Null);
            Assert.That(newItem.attack, Is.Not.Null);
            Assert.That(newItem.defense, Is.Not.Null);
            Assert.That(newItem.usables, Is.Empty);
            Assert.That(newItem.attack.minDamage, Is.EqualTo(1));
            Assert.That(newItem.attack.maxDamage, Is.EqualTo(4));
            Assert.That(newItem.attack.range, Is.EqualTo(3));
        }

        [Test(Description = "Load Weapons test")]
        public void LoadWeaponsTest()
        {
            List<Weapon> weaponList = loader.LoadWeapons();

            logger.Info("Number of Weapons Loaded: " + weaponList.Count);
            Assert.That(weaponList.Count, Is.Positive);

            foreach (Equipment weapon in weaponList)
            {
                logger.Info("======================");
                Assert.That(weapon, Is.Not.Null);

                Assert.That(weapon.name, Is.Not.Null);
                logger.Info(weapon.name);

                Assert.That(weapon.description, Is.Not.Null);
                logger.Info(weapon.description);

                Assert.That(weapon.attack, Is.Not.Null);
                Assert.That(weapon.attack.minDamage, Is.Positive);
                logger.Info(weapon.attack.minDamage);
                Assert.That(weapon.attack.maxDamage, Is.Positive);
                logger.Info(weapon.attack.maxDamage);

            }
        }
    }
}
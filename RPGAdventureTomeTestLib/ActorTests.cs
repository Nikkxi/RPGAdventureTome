using RPGAdventureTome.Actors;
using NUnit.Framework;
using RPGAdventureTomeTestLib.Utils;
using System.Collections.Generic;
using System;

namespace AdventureTomeTestLib
{
    class ActorTests
    {
        private DataLoader loader;

        [SetUp]
        public void Setup()
        {
            loader = new DataLoader();
        }

        [Test]
        public void CreateBreedsTest()
        {
            int health = 10;
            int attack = 3;

            Breed newBreed = new Breed("Orc", health, attack);

            Assert.NotNull(newBreed, "The new breed was not created.");
        }

        [Test]
        public void LoadBreedsTest()
        {
            List<Breed> breeds = loader.LoadMonsterBreeds();

            Assert.IsNotEmpty(breeds);
            Assert.GreaterOrEqual(breeds.Count, 1);

            foreach(Breed breed in breeds){
                Console.WriteLine("Breed:" + breed.name);
                if(breed.parent != null)
                    Console.WriteLine("Parent: " + breed.parent.name);
                Console.WriteLine("Health: " + breed.health);
                Console.WriteLine("Attack: " + breed.attack);
                Console.WriteLine();
            }
        }

        [Test]
        public void CloneMonsterTest()
        {
            List<Breed> breeds = loader.LoadMonsterBreeds();

            List<Monster> clones = new List<Monster>();

            foreach(Breed breed in breeds)
            {
                clones.Add(breed.newMonster());
            }

            int index = 0;
            foreach(Monster clone in clones)
            {
                Assert.AreEqual(clone.breed, breeds[index]);
                index++;
            }
        }
    }
}

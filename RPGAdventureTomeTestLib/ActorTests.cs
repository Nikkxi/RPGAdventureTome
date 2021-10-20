using AdventureTome.Actors;
using NUnit.Framework;

namespace AdventureTomeTestLib
{
    class ActorTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateBreedsTest()
        {
            int health = 10;
            int attack = 3;

            Breed newBreed = new Breed(health, attack);

            Assert.NotNull(newBreed, "The new breed was not created.");
        }

        public void CreateChildBreed()
        {
            Breed parentBreed = new Breed(10, 3);

            Breed childBreed = new Breed(parentBreed, 8, 2);


            Assert.NotNull(childBreed.getParent(), "Parent was not linked.");
            Assert.AreNotEqual(parentBreed.getHealth(), childBreed.getHealth(), "The child's health matches the parent's health. Expected NOT EQUAL.");
            Assert.AreNotEqual(parentBreed.getAttack(), childBreed.getAttack(), "The child's attack matches the parent's attack. Expected NOT EQUAL.");
        }
    }
}

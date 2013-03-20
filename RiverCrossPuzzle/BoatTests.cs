using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace RiverCrossPuzzle
{
   [TestFixture]
   public class BoatTests
   {
      // SUT
      private Boat _boat;

      [SetUp]
      public void Setup()
      {
         _boat = new Boat();
      }

      [Test]
      public void There_should_be_a_boat()
      {
         _boat.ShouldNotBe(null);
      }

      [Test]
      public void A_boat_should_allow_occupants_to_be_added()
      {
         _boat.AddOccupant(new Occupant());
         _boat.AddOccupant(new Occupant());
      }

      [Test]
      public void Should_only_allow_2_occupants_to_be_added()
      {
         _boat.AddOccupant(new Occupant());
         _boat.AddOccupant(new Occupant());
         Assert.Throws<BoatOverloadException>(() => _boat.AddOccupant(new Occupant()));
      }

      [Test]
      public void Should_be_able_to_get_occupants()
      {
         var occupant1 = new Occupant();
         var occupant2 = new Occupant();
         _boat.AddOccupant(occupant1);
         _boat.AddOccupant(occupant2);
         var occupants = _boat.Occupants.ToList();
         occupants[0].ShouldBe(occupant1);
         occupants[1].ShouldBe(occupant2);
      }

      [Test]
      public void Should_be_able_to_unload_occupants()
      {
         var occupant1 = new Occupant();
         var occupant2 = new Occupant();
         _boat.AddOccupant(occupant1);
         _boat.AddOccupant(occupant2);
         var occupants = _boat.Occupants.ToList();
         _boat.Occupants.Count().ShouldBe(2);
         _boat.RemoveOccupant(occupant1);
         _boat.Occupants.Count().ShouldBe(1);
      }
   }
}

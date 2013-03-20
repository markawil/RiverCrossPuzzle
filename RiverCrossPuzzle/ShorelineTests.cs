using NUnit.Framework;

namespace RiverCrossPuzzle
{
   [TestFixture]
   public class ShorelineTests
   {
       // SUT
      private Shoreline _shoreLine;

      // dependencies (kind of)
      private Occupant _farmer;
      private Occupant _duck;
      private Occupant _corn;
      private Occupant _fox;

      [SetUp]
      public void Setup()
      {
         _shoreLine = new Shoreline();

         _farmer = new Farmer();
         _duck = new Duck();
         _fox = new Fox();
         _corn = new Corn();
      }

      #region adding to the shoreline

      [Test]
      public void Can_add_occupants()
      {
         _shoreLine.AddOccupant(new Occupant());
      }

      [Test]
      public void Fox_and_duck_cant_be_together_on_same_shoreline()
      {
         Occupant fox = new Fox();
         Occupant duck = new Duck();

         _shoreLine.AddOccupant(fox);
         Assert.Throws<OccupantAteTheOtherException>(() => _shoreLine.AddOccupant(duck));

         _shoreLine = new Shoreline();
         _shoreLine.AddOccupant(duck);
         Assert.Throws<OccupantAteTheOtherException>(() => _shoreLine.AddOccupant(fox));
      }

      [Test]
      public void Duck_and_Corn_cant_be_together_on_same_shoreline()
      {
         Occupant duck = new Duck();
         Occupant corn = new Corn();
         _shoreLine.AddOccupant(duck);
         Assert.Throws<OccupantAteTheOtherException>(() => _shoreLine.AddOccupant(corn));

         _shoreLine = new Shoreline();
         _shoreLine.AddOccupant(corn);
         Assert.Throws<OccupantAteTheOtherException>(() => _shoreLine.AddOccupant(duck));
      }

      [Test]
      public void Duck_and_Fox_can_coexist_on_same_shoreline_if_Farmer_is_also_there()
      {
         Occupant duck = new Duck();
         Occupant fox = new Fox();
         Occupant farmer = new Farmer();

         _shoreLine.AddOccupant(farmer);
         _shoreLine.AddOccupant(fox);
         Assert.DoesNotThrow(() => _shoreLine.AddOccupant(duck));
      }

      [Test]
      public void Duck_and_Corn_can_coexist_on_same_shoreline_if_Farmer_is_also_there()
      {
         Occupant duck = new Duck();
         Occupant corn = new Corn();
         Occupant farmer = new Farmer();

         _shoreLine.AddOccupant(farmer);
         _shoreLine.AddOccupant(corn);
         Assert.DoesNotThrow(() => _shoreLine.AddOccupant(duck));
      }

      #endregion

      #region removing from the shoreline

      [Test]
      public void Removing_farmer_should_throw_OccupantAteExc_if_fox_and_duck_left()
      {
         addOccupants();
         _shoreLine.RemoveOccupant(_corn);
         Assert.Throws<OccupantAteTheOtherException>(() => _shoreLine.RemoveOccupant(_farmer));
      }

      [Test]
      public void Removing_farmer_should_throw_OccupantAteExc_if_duck_and_corn_left()
      {
         addOccupants();
         _shoreLine.RemoveOccupant(_fox);
         Assert.Throws<OccupantAteTheOtherException>(() => _shoreLine.RemoveOccupant(_farmer));
      }

      private void addOccupants()
      {
         _shoreLine.AddOccupant(_farmer);
         _shoreLine.AddOccupant(_duck);
         _shoreLine.AddOccupant(_fox);
         _shoreLine.AddOccupant(_corn);
      }

      #endregion

   }
}
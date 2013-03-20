using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace RiverCrossPuzzle
{
   [TestFixture]
   public class GameTests
   {
       //SUT 
      private Game _game;

      [SetUp]
      public void Setup()
      {
         _game = new Game();
      }

      [Test]
      public void Ctr_should_add_4_occupants_to_the_shore()
      {
         _game.Occupants.Count().ShouldBe(4);
      }

      [Test]
      public void Ctr_should_build_2_shoreLines()
      {
         _game.ShoreLines.Count().ShouldBe(2);
      }

      [Test]
      public void Ctr_should_add_all_4_occupants_to_starting_shoreLine()
      {
         _game.ShoreLines.ToList()[0].Occupants.Count().ShouldBe(4);
      }

      [Test]
      public void Should_be_able_to_send_duck_across()
      {
         var duck = _game.Occupants.Where(d => d.GetType() == typeof (Duck)).First();
         _game.SendAcrossRiver(duck);
      }
   }
}
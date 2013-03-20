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


   }
}
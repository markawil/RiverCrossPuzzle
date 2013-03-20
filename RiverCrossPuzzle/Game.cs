using System.Collections.Generic;

namespace RiverCrossPuzzle
{
   public class Game
   {
      private List<Occupant> _occupants = new List<Occupant>();

      public IEnumerable<Occupant> Occupants
      {
         get { return _occupants; }
      }

      public Game()
      {
         var duck = new Duck();
         var fox = new Fox();
         var farmer = new Farmer();
         var corn = new Corn();

         _occupants.Add(duck);
         _occupants.Add(fox);
         _occupants.Add(farmer);
         _occupants.Add(corn);
      }
   }
}
using System.Collections.Generic;

namespace RiverCrossPuzzle
{
   public class Game
   {
      private List<Occupant> _occupants = new List<Occupant>();
      private List<Shoreline> _shoreLines = new List<Shoreline>();

      public IEnumerable<Occupant> Occupants
      {
         get { return _occupants; }
      }

      public IEnumerable<Shoreline> ShoreLines
      {
         get { return _shoreLines; }
      }

      public Game()
      {
         var duck = new Duck();
         var fox = new Fox();
         var farmer = new Farmer();
         var corn = new Corn();

         _occupants.Add(farmer);
         _occupants.Add(duck);
         _occupants.Add(fox);
         _occupants.Add(corn);

         var shorelineStart = new Shoreline();
         var shoreLineEnd = new Shoreline();
         _shoreLines.Add(shorelineStart);
         _shoreLines.Add(shoreLineEnd);

         foreach (var o in _occupants)
         {
            _shoreLines[0].AddOccupant(o);
         }
      }

      public void SendAcrossRiver(Occupant duck)
      {
         
      }
   }
}
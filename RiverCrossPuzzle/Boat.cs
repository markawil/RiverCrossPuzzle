using System.Collections.Generic;

namespace RiverCrossPuzzle
{
   public class Boat
   {
      private List<Occupant> _occupants = new List<Occupant>();

      public IEnumerable<Occupant> Occupants
      {
         get { return _occupants; }
      }

      public void AddOccupant(Occupant occupant)
      {
         if (_occupants.Count < 2)
            _occupants.Add(occupant);
         else
            throw new BoatOverloadException();
      }

      public void RemoveOccupant(Occupant occupant)
      {
         _occupants.Remove(occupant);
      }
   }
}
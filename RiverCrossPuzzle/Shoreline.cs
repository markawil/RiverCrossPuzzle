using System.Collections.Generic;
using System.Linq;

namespace RiverCrossPuzzle
{
   public class Shoreline
   {
      private List<Occupant> _occupants = new List<Occupant>();

      public IEnumerable<Occupant> Occupants
      {
         get { return _occupants; }
      }

      public void AddOccupant(Occupant occupant)
      {
         _occupants.Add(occupant);
         ValidateOccupants();
      }

      private void ValidateOccupants()
      {
         var foxes = getOccupantsOfType<Fox>();
         var ducks = getOccupantsOfType<Duck>();
         var corns = getOccupantsOfType<Corn>();
         var farmers = getOccupantsOfType<Farmer>();

         if (!farmers.Any())
         {
            if (foxes.Any() && ducks.Any())
               throw new OccupantAteTheOtherException();

            if (ducks.Any() && foxes.Any() || (ducks.Any() && corns.Any()))
               throw new OccupantAteTheOtherException();

            if (corns.Any() && ducks.Any())
               throw new OccupantAteTheOtherException();
         }
      }

      private IEnumerable<Occupant> getOccupantsOfType<T>() where T : Occupant
      {
         return _occupants.Where(d => d.GetType() == typeof(T));
      }

      public void RemoveOccupant(Occupant occupant)
      {
         _occupants.Remove(occupant);
         ValidateOccupants();
      }
   }
}
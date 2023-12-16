using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.Refactoring
{
    public class RefactorLinqExamples
    {

        public void UseCorrectMethods()
        {
            PassengerGenerator generator = new();
            List<Passenger> people = generator.GeneratePassengers(50);

            Passenger me = people.FirstOrDefault(p => p.FullName == "Matt Eland");

            Console.WriteLine($"{me.FullName} is group {me.BoardingGroup}");
        }

        public void CombineLinqMethods()
        {
            PassengerGenerator generator = new();
            List<Passenger> people = generator.GeneratePassengers(50);

            bool anyBoarded =
              people.Any(p => p.HasBoarded);
            int numBoarded =
              people.Count(p => p.HasBoarded);
            Passenger firstBoarded =
              people.First(p => p.HasBoarded);
        }

        public void TransformingWithSelect()
        {
            PassengerGenerator generator = new();
            List<Passenger> people = generator.GeneratePassengers(50);

            List<string> names = new();
            names.AddRange(people.Where(p => !p.HasBoarded)
                .Select(p => $"{p.FullName}-{p.BoardingGroup}"));
        }

        public void EnumeratingWithTakeAndSkip()
        {
            PassengerGenerator generator = new();
            List<Passenger> people = generator.GeneratePassengers(50)
                                              .OrderBy(p => p.BoardingGroup)
                                              .ToList();

            foreach (Passenger p in people.SkipWhile(p => p.BoardingGroup < 3).Take(3))
            {
                Console.WriteLine($"Upgrading {p.FullName}");
            }

        }

        public void RangeIndexers()
        {
            PassengerGenerator generator = new();
            List<Passenger> people = generator.GeneratePassengers(50).ToList();

            Passenger last = people[people.Count - 1];
        }
    }
}

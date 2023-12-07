using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.Refactoring
{
    public class Passenger
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BoardingGroup { get; set; }
        public bool IsMilitary { get; set; }
        public bool NeedsHelp { get; set; }
        public bool HasBoarded { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public override string ToString() => FullName;
    }
}

using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tzometsfarim.Utils
{
    public class UserPersonalDetails
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Cell { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HomeNumber   { get; set; }
       
        public override string ToString()
        {
           return Email + "|" + Name + "|" + Surname + "|" + Cell + "|" + City + "|" + Street +"|"+HomeNumber;
        }

    }
}

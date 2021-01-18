using devChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevChallengeCarguero.Models
{
    public class Address
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public  string UserName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Data.Entities.Models
{
    public class Adopter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactPhone { get; set; }
        public string Oib { get; set; }
        public int AnimalId { get; set; }
        public string LocationAddress { get; set; }
        public string Motivation { get; set; }
        public Animal Animal { get; set; }
    }
}

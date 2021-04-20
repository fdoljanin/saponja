using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Data.Entities.Models
{
    public class Adopter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactPhone { get; set; }
        public string Oib { get; set; }
        public string LocationAddress { get; set; }
        public string Motivation { get; set; }
        public string ConfirmationLink { get; set; }
        public bool HasConfirmedMail { get; set; }
        public bool HasReceivedDocumentation { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}

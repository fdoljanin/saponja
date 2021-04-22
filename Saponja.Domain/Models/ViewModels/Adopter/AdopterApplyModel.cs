using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Models.ViewModels.Adopter
{
    public class AdopterApplyModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Motivation { get; set; }
        public int AnimalId { get; set; }
    }
}

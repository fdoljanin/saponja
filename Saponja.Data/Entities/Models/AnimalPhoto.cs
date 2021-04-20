using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Data.Entities.Models
{
    public class AnimalPhoto
    {
        public int Id { get; set; }

        public string PhotoLink { get; set; }

        public int AnimalId { get; set; }

        public Animal Animal { get; set; }
    }
}

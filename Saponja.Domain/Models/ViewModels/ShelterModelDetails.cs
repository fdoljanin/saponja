using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Models.ViewModels
{
    public class ShelterModelDetails : ShelterModel
    {
        public string DescriptionFileLink { get; set; }
        public string Iban { get; set; }
        public string DocumentationLink { get; set; }
    }
}

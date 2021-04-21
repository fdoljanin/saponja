using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Models
{
    public class ShelterInfoModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Oib { get; set; }
        public string Iban { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Models.ViewModels.Animal
{
    public class AnimalListModel
    {
        public int AnimalsCount { get; set; }
        public IEnumerable<AnimalModel> Animals { get; set; }
    }
}

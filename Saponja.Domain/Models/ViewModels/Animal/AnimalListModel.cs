using System.Collections.Generic;

namespace Saponja.Domain.Models.ViewModels.Animal
{
    public class AnimalListModel
    {
        public int AnimalsCount { get; set; }
        public IEnumerable<AnimalModel> Animals { get; set; }
    }
}

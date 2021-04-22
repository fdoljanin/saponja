﻿using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Data.Enums;

namespace Saponja.Domain.Models.ViewModels
{
    public class AnimalModelDetails : AnimalModel
    {
        public AnimalType Type { get; set; }
        public string Description { get; set; }
        public bool IsSterilized { get; set; }
        public bool IsGoodWithChildren { get; set; }
        public bool IsGoodWithCats { get; set; }
        public bool IsGoodWithDogs { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsRequiredExperience { get; set; }
        public bool IsDangerous { get; set; }
        public int ShelterId { get; set; }
    }
}

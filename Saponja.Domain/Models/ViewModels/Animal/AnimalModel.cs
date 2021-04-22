﻿using Saponja.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Models.ViewModels
{
    public class AnimalModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePhotoLink { get; set; }
        public AnimalAge Age { get; set; }
        public AnimalGender Gender { get; set; }

        public ShelterModel Shelter { get; set; }
    }
}
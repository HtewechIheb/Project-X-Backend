﻿using System.Collections.Generic;

namespace Project_X.Models
{
    public class Offer
    {
        public long Id { get; set; }
        public string Industry { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Spots { get; set; }
        public double? Salary { get; set; }
        public string Degree { get; set; }
        public string Gender { get; set; }
        public string Skills { get; set; }
        public string Type { get; set; }
        public string MinimumExperience { get; set; }
        public string RecommendedExperience { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}

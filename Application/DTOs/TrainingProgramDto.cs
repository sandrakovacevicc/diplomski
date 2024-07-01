﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessSystem.Application.DTOs
{
    public class TrainingProgramDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TrainingDurationInMinutes { get; set; }
        public string TrainingType { get; set; }
        public List<Session> Sessions { get; set; }
    }
}

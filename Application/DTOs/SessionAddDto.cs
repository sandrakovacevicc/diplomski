﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessSystem.Application.DTOs
{
    public class SessionAddDto
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int Duration { get; set; }
        public int Capacity { get; set; }
        public int TrainingProgramId { get; set; }
        public int TrainerId { get; set; }
        public int RoomId { get; set; }
    }
}
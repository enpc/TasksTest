﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tasks.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStates State {get;set;}
        public DateTime? Started { get; set; }
        public DateTime? Ended { get; set; }
    }
}
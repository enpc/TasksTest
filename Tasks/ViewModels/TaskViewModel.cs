using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tasks.Models;

namespace Tasks.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStates State { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Ended { get; set; }
    }
}
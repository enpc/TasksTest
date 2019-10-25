using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tasks.Services;

namespace Tasks.Models
{
    public class TaskModel
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStates State { get; private set; }
        public DateTime? Started { get; private set; }
        public DateTime? Ended { get; private set; }

        private readonly ITimeService TimeService;

        public TaskModel(ITimeService timeService, int id, TaskStates state, DateTime? started, DateTime? ended)
        {
            Id = id;
            State = state;
            Started = started;
            Ended = ended;
            TimeService = timeService ?? throw new ArgumentException("TimeService cannot be null");
        }

        public void ChangeState(TaskStates newState)
        {
            if (State == newState)
            {
                return;
            }

            switch (newState)
            {
                case TaskStates.Todo:
                    Started = null;
                    Ended = null;
                    break;
                case TaskStates.InProgress:
                    Started = TimeService.ActualTime;
                    Ended = null;
                    break;
                case TaskStates.Done:
                    Ended = TimeService.ActualTime;
                    if (Started == null)
                    {
                        Started = Ended;
                    }
                    break;               
            }

            State = newState;
        }
    }
}
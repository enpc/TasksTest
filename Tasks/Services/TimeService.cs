using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tasks.Services
{
    public class TimeService : ITimeService
    {
        public DateTime ActualTime => DateTime.Now;
                   
    }
}
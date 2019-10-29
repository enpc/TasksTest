using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Services;

namespace TasksTests.Models.services
{
    class TestTimeService : ITimeService
    {
        public DateTime Time { get; set; }

        public DateTime ActualTime => Time;
    }
}

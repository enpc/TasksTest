using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksTests.Models.services;

namespace Tasks.Models.Tests
{
    [TestClass()]
    public class TaskModelTests
    {
        [TestMethod()]
        public void TaskModelTest()
        {
            var task = new TaskModel(new TestTimeService(), 1, TaskStates.Todo, null, null);                       
        }

        [TestMethod()]
        public void TaskModelNoTimeServiceTest()
        {
            Assert.ThrowsException<ArgumentException>(()=> new TaskModel(null, 1, TaskStates.Todo, null, null));
        }

        [TestMethod()]
        public void ChangeStateTodoToInProgressTest()
        {
            var timeService = new TestTimeService
            {
                Time = new DateTime(2019,10,24,22,00,00)
            };
            var task = new TaskModel(timeService, 1, TaskStates.Todo, null, null);
            task.ChangeState(TaskStates.InProgress);

            Assert.AreEqual(TaskStates.InProgress, task.State);
            Assert.AreEqual(timeService.Time, task.Started);
            Assert.AreEqual(null, task.Ended);
        }

        [TestMethod()]
        public void ChangeStateInProgressToDoneWithDifferentTimeTest()
        {
            var timeService = new TestTimeService
            {
                Time = new DateTime(2019, 10, 24, 22, 00, 00)
            };

            var startTime = new DateTime(2019, 10, 24, 21, 00, 00);

            var task = new TaskModel(timeService, 1, TaskStates.InProgress, startTime, null);
            task.ChangeState(TaskStates.Done);

            Assert.AreEqual(TaskStates.Done, task.State);
            Assert.AreEqual(startTime, task.Started);
            Assert.AreEqual(timeService.Time, task.Ended);
        }

        [TestMethod()]
        public void ChangeStateInProgressToDoneWithNoStartTimeTest()
        {
            var timeService = new TestTimeService
            {
                Time = new DateTime(2019, 10, 24, 22, 00, 00)
            };
            var task = new TaskModel(timeService, 1, TaskStates.InProgress, null, null);
            task.ChangeState(TaskStates.Done);

            Assert.AreEqual(TaskStates.Done, task.State);
            Assert.AreEqual(timeService.Time, task.Started);
            Assert.AreEqual(timeService.Time, task.Ended);
        }

        [TestMethod()]
        public void ChangeStateTodoToDoneTimeTest()
        {
            var timeService = new TestTimeService
            {
                Time = new DateTime(2019, 10, 24, 22, 00, 00)
            };
            var task = new TaskModel(timeService, 1, TaskStates.Todo, null, null);
            task.ChangeState(TaskStates.Done);

            Assert.AreEqual(TaskStates.Done, task.State);
            Assert.AreEqual(timeService.Time, task.Started);
            Assert.AreEqual(timeService.Time, task.Ended);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tasks.Models;
using Tasks.Services;
using Tasks.ViewModels;

namespace Tasks.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksModel Model = TasksModel.GetInstance();

        public ActionResult Index()
        {
            var tasks = Model.GetTasks().Select(s => ViewModelFromModel(s)).ToArray();
            return View(tasks);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                Model.CreateTask(model.Name, model.Description);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                TaskModel taskModel = null;
                try
                {
                    taskModel = Model.GetTask((int)id);
                } catch (ArgumentOutOfRangeException e)
                {
                    ModelState.AddModelError("", $"The task does not exists");
                    return View("Error");
                }
                return View(ViewModelFromModel(taskModel));
            }
            else
            {
                ModelState.AddModelError("", "The Task id not specified");
                return View("Error");
            }
        }


        [HttpPost]
        public ActionResult Edit(TaskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var taskModel = Model.GetTask(viewModel.Id);
                taskModel.Name = viewModel.Name;
                taskModel.Description = viewModel.Description;
                taskModel.ChangeState(viewModel.State);
                Model.UpdateTask(taskModel);

                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Model.DeleteTask(Model.GetTask(id));
            }
            catch (ArgumentOutOfRangeException e)
            {
                ModelState.AddModelError("", $"The task does not exists");
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        private TaskViewModel ViewModelFromModel(TaskModel taskModel)
        {
            return new TaskViewModel()
            {
                Id = taskModel.Id,
                Name = taskModel.Name,
                Description = taskModel.Description,
                State = taskModel.State,
                Started = taskModel.Started,
                Ended = taskModel.Ended
            };
        }
    }
}
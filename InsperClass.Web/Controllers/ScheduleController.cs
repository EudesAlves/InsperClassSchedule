using InsperClass.Domain.Entity;
using InsperClass.Domain.Interface;
using InsperClass.Domain.Interface.Service;
using InsperClass.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace InsperClass.Web.Controllers
{
    public class ScheduleController : Controller
    {
        IScheduleRepository _scheduleRepository;
        ICourseRepository _courseRepository;
        IClassRepository _classRepository;
        IScheduleService _scheduleService;

        public ScheduleController(IScheduleRepository scheduleRepository, ICourseRepository courseRepository, IClassRepository classRepository, IScheduleService scheduleService)
        {
            _scheduleRepository = scheduleRepository;
            _courseRepository = courseRepository;
            _classRepository = classRepository;
            _scheduleService = scheduleService;
        }
        
        // GET: ScheduleController
        public ActionResult Index()
        {
            var schedules = _scheduleService.Get();
            return View(schedules);
        }

        // GET: ScheduleController/Create
        public ActionResult Create()
        {
            var courses = _courseRepository.Get();

            var coursesSelect = from Course c in courses
                                select new { Id = c.Id, Name = c.Name };

            var weekDaysSelect = from EWeekDay w in Enum.GetValues(typeof(EWeekDay))
                           select new { Id = (int)w, Name = w.ToString() };

            ViewBag.Courses = new SelectList(coursesSelect, "Id", "Name");
            ViewBag.WeekDays = new SelectList(weekDaysSelect, "Id", "Name");
            return View();
        }

        // POST: ScheduleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Schedule schedule)
        {
            try
            {
                _scheduleRepository.Add(schedule);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ScheduleController/Delete/id
        public ActionResult Delete(int id)
        {
            var schedule = _scheduleRepository.GetViewModelById(id);
            return View(schedule);
        }
        // POST: ScheduleController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ScheduleViewModel schedule)
        {
            try
            {
                _scheduleRepository.Delete(schedule.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult GetClassesByCourseId(int id)
        {
            var classes = _classRepository.GetByCourseId(id);
            return Json(classes);
        }
    }
}

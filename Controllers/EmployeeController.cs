using ArtSofteASPMVC_net6_.DAL;
using ArtSofteASPMVC_net6_.Domain;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Reflection;

namespace ArtSofteASPMVC_net6_.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _emprepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IProgLangRepository _progLangRepository;

        // GET: EmployeeController
        public EmployeeController(ILogger<HomeController> logger, 
            IEmployeeRepository emprepository, 
            IDepartmentRepository departmentRepository, 
            IProgLangRepository progLangRepository)
        {
            _logger = logger;
            _emprepository = emprepository;
            _departmentRepository = departmentRepository;
            _progLangRepository = progLangRepository;
        }
        public ActionResult Index()
        {
            var model = _emprepository.GetAll();
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            var model = new Employee();
            ViewBag.depList = _departmentRepository.GetAll();
            ViewBag.progLangList = _progLangRepository.GetAll();
            ViewBag.genderList = new List<ConvertEnum>();
            foreach (Gender lang in Enum.GetValues(typeof(Gender)))
                ViewBag.genderList.Add(new ConvertEnum
                {
                    Value = (int)lang,
                    Text = lang.ToString()
                });
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var res = _emprepository.InsertData(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _emprepository.GetByID(id);
            if (model.Id == 0)
            {
                return NotFound();
            }

            ViewBag.depList = _departmentRepository.GetAll();
            ViewBag.progLangList = _progLangRepository.GetAll();
            ViewBag.genderList = new List<ConvertEnum>();
            foreach (Gender lang in Enum.GetValues(typeof(Gender)))
                ViewBag.genderList.Add(new ConvertEnum
                {
                    Value = (int)lang,
                    Text = lang.ToString()
                });
            return View(model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var res = _emprepository.UpdateData(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: EmployeeController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _emprepository.GetByID(id);

            if (model.Id==0)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee model)
        {
            var res = _emprepository.Delete(model.Id);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var model = new AutocompleteNames();
            return Json(model.Items);
        }
    }
}

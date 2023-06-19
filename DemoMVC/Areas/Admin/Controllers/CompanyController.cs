using DemoMVC.DataAccess.Repository.IRepository;
using DemoMVC.Models;
using DemoMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Company> objCompanyList = _unitOfWork.Company.GetAll();
            return View(objCompanyList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Company.Add(model);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type Added";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Upsert(int? id)
        {
            Company company = new();

            if (id == null || id == 0)
            {
                return View(company);
            }
            else
            {
                company = _unitOfWork.Company.GetFirstOrDefault(p => p.Id == id);
                return View(company);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Company model)
        {
            if (ModelState.IsValid)
            {

                if (model.Id == 0)
                {
                    _unitOfWork.Company.Add(model);
                    TempData["success"] = "Company Added";
                }
                else
                {
                    _unitOfWork.Company.Update(model);
                    TempData["success"] = "Company Updated";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        #region API EndPoint
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Company> objCompanyList = _unitOfWork.Company.GetAll();
            return Json(new { data = objCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var Company = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            if (Company == null) return Json(new { success = false, message = "Error while deleting" });

            _unitOfWork.Company.Remove(Company);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Cover Type Deleted" });
        }
        #endregion
    }
}

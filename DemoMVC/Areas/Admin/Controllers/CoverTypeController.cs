using DemoMVC.DataAccess.Repository.IRepository;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CoverType model)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.CoverType.Add(model);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type Added";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverType == null) return NotFound();
            return View(coverType);
        }
        [HttpPost]
        public IActionResult Edit(CoverType model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(model);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type Updated";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpDelete("{id}")]
        [Route("/api/del/{id}")]
        public IActionResult Delete(string id)
        {
            //if (id == null || id == 0) return NotFound();
            //var coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            //if (coverType == null) return NotFound();
            //_unitOfWork.CoverType.Remove(coverType);
            //_unitOfWork.Save();
            //TempData["success"] = "Cover Type Deleted";
            return RedirectToAction("Index");
        }
    }
}

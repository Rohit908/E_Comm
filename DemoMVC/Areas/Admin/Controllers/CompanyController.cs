//using DemoMVC.DataAccess.Repository.IRepository;
//using DemoMVC.Models;
//using DemoMVC.Models.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace DemoMVC.Web.Areas.Admin.Controllers
//{
    
//    public class ProductController : Controller
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IWebHostEnvironment _hostEnvironment;

//        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
//        {
//            _unitOfWork = unitOfWork;
//            _hostEnvironment = hostEnvironment;
//        }
//        public IActionResult Index()
//        {
//            //IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll();
//            return View();
//        }
//        public IActionResult Create()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Create(Product model)
//        {
//            if (ModelState.IsValid)
//            {
//                _unitOfWork.Product.Add(model);
//                _unitOfWork.Save();
//                TempData["success"] = "Cover Type Added";
//                return RedirectToAction("Index");
//            }
//            return View(model);
//        }
//        public IActionResult Upsert(int? id)
//        {
//            ProductVM productVM = new()
//            {
//                Product = new(),
//                CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
//                {
//                    Text = x.Name,
//                    Value = x.Id.ToString()
//                }),
//                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(x => new SelectListItem
//                {
//                    Text = x.Name,
//                    Value = x.Id.ToString()
//                })
//            };

//            if (id == null || id == 0)
//            {
//                return View(productVM);
//            }
//            else
//            {
//                productVM.Product = _unitOfWork.Product.GetFirstOrDefault(p => p.Id == id);
//                return View(productVM);
//            }
//        }
//        [HttpPost]
//        public IActionResult Upsert(ProductVM model, IFormFile? file)
//        {
//            if (ModelState.IsValid)
//            {
//                string wwwRootPath = _hostEnvironment.WebRootPath;
//                if(file!=null)
//                {
//                    string fileName = Guid.NewGuid().ToString();
//                    var uploads = Path.Combine(wwwRootPath, @"images\products");
//                    var extention = Path.GetExtension(file.FileName);

//                    if(model.Product.ImageUrl!=null)
//                    {
//                        var oldImagePath = Path.Combine(wwwRootPath, model.Product.ImageUrl.TrimStart('\\'));
//                        if(System.IO.File.Exists(oldImagePath))
//                        {
//                            System.IO.File.Delete(oldImagePath);
//                        }
//                    }
                    
//                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName+extention), FileMode.Create))
//                    {
//                        file.CopyTo(fileStream);
//                    }
//                    model.Product.ImageUrl = @"images\products\" + fileName + extention;
//                }

//                if (model.Product.Id == 0)
//                {
//                    _unitOfWork.Product.Add(model.Product);
//                    TempData["success"] = "Product Added";
//                }
//                else
//                {
//                    _unitOfWork.Product.Update(model.Product);
//                    TempData["success"] = "Product Updated";
//                }
//                _unitOfWork.Save();
//                return RedirectToAction("Index");
//            }
//            return View(model);
//        }
        
//        #region API EndPoint
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            IEnumerable<Product> objProductList = _unitOfWork.Product.GetAll("Category,CoverType");
//            return Json(new { data = objProductList });
//        }

//        [HttpDelete]
//        public IActionResult Delete(int? id)
//        {
//            if (id == null || id == 0) return NotFound();
//            var Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
//            if (Product == null) return Json(new {success=false, message="Error while deleting"});

//            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, Product.ImageUrl.TrimStart('\\'));
//            if (System.IO.File.Exists(oldImagePath))
//            {
//                System.IO.File.Delete(oldImagePath);
//            }

//            _unitOfWork.Product.Remove(Product);
//            _unitOfWork.Save();
//            return Json(new { success = true, message = "Cover Type Deleted" });
//        }
//        #endregion
//    }
//}

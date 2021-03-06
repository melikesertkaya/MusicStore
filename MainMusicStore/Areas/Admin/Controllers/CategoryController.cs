using MainMusicStore.DataAccess.IMainRepository;
using MainMusicStore.Models.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace MainMusicStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        #region Variables
        private readonly IUnitOfWork _uow;
        #endregion

        #region Ctor
        public CategoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        #endregion

        #region Actions

        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Apı Calls
        public IActionResult GetAll()
        {
            var allObj = _uow.Category.GetAll();
            return Json(new { data = allObj });
        }

       [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleteData = _uow.Category.Get(id);
            if (deleteData == null)
                return Json(new { success = false, message = "Data Not Found!" });

            _uow.Category.Remove(deleteData);
            _uow.Save();
            return Json(new { success = true, message = "Delete Operation Successfully" });
        }


        #endregion

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Category cat = new Category();
            if (id == null)
            {
                //this for create
                return View(cat);
            }
            cat = _uow.Category.Get((int)id);
            if (cat != null)
            {
                return View(cat);
            }
            return NotFound();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id==0)
                {
                    //create
                    _uow.Category.Add(category);
                }
                else
                {
                    //update
                    _uow.Category.Update(category);
                }
                _uow.Save();
                return RedirectToAction("Index");
            }
            return View(category);

        }
    }
}


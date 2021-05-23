using MainMusicStore.DataAccess.IMainRepository;
using MainMusicStore.Models.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace MainMusicStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        #region Variables
        private readonly IUnitOfWork _uow;
        #endregion

        #region Ctor
        public CompanyController(IUnitOfWork uow)
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
            var allObj = _uow.Company.GetAll();
            return Json(new { data = allObj });
        }

       [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deleteData = _uow.Company.Get(id);
            if (deleteData == null)
                return Json(new { success = false, message = "Data Not Found!" });

            _uow.Company.Remove(deleteData);
            _uow.Save();
            return Json(new { success = true, message = "Delete Operation Successfully" });
        }


        #endregion

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Company cat = new Company();
            if (id == null)
            {
                //this for create
                return View(cat);
            }
            cat = _uow.Company.Get((int)id);
            if (cat != null)
            {
                return View(cat);
            }
            return NotFound();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id==0)
                {
                    //create
                    _uow.Company.Add(company);
                }
                else
                {
                    //update
                    _uow.Company.Update(company);
                }
                _uow.Save();
                return RedirectToAction("Index");
            }
            return View(company);

        }
    }
}


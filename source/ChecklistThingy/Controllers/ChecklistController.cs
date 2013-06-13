using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecklistThingy.DataAccess;
using ChecklistThingy.Models;
using WebMatrix.WebData;

namespace ChecklistThingy.Controllers
{
    [Authorize]
    public class ChecklistController : Controller
    {
        private readonly ChecklistDao _checklistDao;

        public ChecklistController()
        {
            _checklistDao = new ChecklistDao(WebSecurity.CurrentUserId);
        }

        public ActionResult List()
        {
            return View(_checklistDao.FetchMany());
        }

        public ActionResult Add()
        {
            ViewBag.FormMode = "Add";
            return View("Edit", new ChecklistModel());
        }

        [HttpPost]
        public ActionResult Add(ChecklistModel newChecklist)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _checklistDao.Insert(newChecklist);
                    return RedirectToAction("List");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
            }

            ViewBag.FormMode = "Add";
            return View("Edit", newChecklist);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.FormMode = "Edit";
            return View(_checklistDao.GetSingle(id));
        }

        [HttpPost]
        public ActionResult Edit(ChecklistModel newChecklist)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _checklistDao.Update(newChecklist);
                    return RedirectToAction("List");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
            }

            ViewBag.FormMode = "Edit";
            return View("Edit", newChecklist);
        }

    }
}

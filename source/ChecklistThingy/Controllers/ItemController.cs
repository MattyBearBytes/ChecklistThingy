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
    public class ItemController : Controller
    {
        private readonly ItemDao _itemDao;

        public ItemController()
        {
            _itemDao = new ItemDao(WebSecurity.CurrentUserId);
        }

        public ActionResult List(int id)
        {
            return View(_itemDao.FetchMany(id));
        }

        public ActionResult Add()
        {
            ViewBag.FormMode = "Add";
            return View("Edit", new ChecklistItemModel());
        }

        [HttpPost]
        public ActionResult Add(ChecklistItemModel newItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _itemDao.Insert(newItem);
                    return RedirectToAction("List");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
            }

            ViewBag.FormMode = "Add";
            return View("Edit");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.FormMode = "Edit";
            return View(_itemDao.GetSingle(id));
        }

        [HttpPost]
        public ActionResult Edit(ChecklistItemModel newItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _itemDao.Update(newItem);
                    return RedirectToAction("List");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
            }

            ViewBag.FormMode = "Edit";
            return View("Edit");
        }

    }
}

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
        private readonly ChecklistDao _checklistDao;


        public ItemController()
        {
            _itemDao = new ItemDao(WebSecurity.CurrentUserId);
            _checklistDao = new ChecklistDao(WebSecurity.CurrentUserId);
        }

        public ActionResult List(int id)
        {
            var viewModel = new ListItemsViewModel
            {
                Checklist = _checklistDao.GetSingle(id),
                Items = _itemDao.FetchMany(id)
            };

            return View(viewModel);
        }

        public ActionResult Add(int id)
        {
            ViewBag.FormMode = "Add";
            return View("Edit", new ChecklistItemModel{ChecklistId = id});
        }

        [HttpPost]
        public ActionResult Add(ChecklistItemModel newItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _itemDao.Insert(newItem);
                    return RedirectToAction("List", new { id = newItem.ChecklistId });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
            }

            ViewBag.FormMode = "Add";
            return View("Edit", newItem);
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
                    return RedirectToAction("List", new { id = newItem.ChecklistId });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
            }

            ViewBag.FormMode = "Edit";
            return View("Edit", newItem);
        }

    }
}

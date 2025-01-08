using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;

// Generated from Custom Template.

namespace MVC.Controllers
{
    [Authorize]
    public class OblastsController : MvcController
    {
        // Service injections:
        private readonly IOblastsService _oblastsService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        private readonly IPoliticalPartiesService _politicalPartiesService;

        public OblastsController(
            IOblastsService oblastsService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            , IPoliticalPartiesService politicalPartiesService
        )
        {
            _oblastsService = oblastsService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            _politicalPartiesService = politicalPartiesService;
        }

    // GET: Oblasts
    [AllowAnonymous]
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _oblastsService.Query().ToList();
            return View(list);
        }

        // GET: Oblasts/Details/5
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _oblastsService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            ViewBag.PoliticalPartyIds = new MultiSelectList(_politicalPartiesService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Oblasts/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Oblasts/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OblastsModel oblasts)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _oblastsService.Create(oblasts.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = oblasts.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(oblasts);
        }

        // GET: Oblasts/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _oblastsService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Oblasts/Edit
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OblastsModel oblasts)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _oblastsService.Update(oblasts.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = oblasts.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(oblasts);
        }

        // GET: Oblasts/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _oblastsService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Oblasts/Delete
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _oblastsService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}

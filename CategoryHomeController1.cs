using Day3_NongAnhThu.Data;
using Day3_NongAnhThu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Day3_NongAnhThu.Controllers
{
    public class CategoryHomeController1 : Controller
    {
        // GET: Hiển thị danh sách Category
        public IActionResult Index()
        {
            return View(SaveData.categories);
        }

        // GET: Hiển thị chi tiết Category
        public IActionResult Details(int id)
        {
            var category = SaveData.categories
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Hiển thị trang Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thêm Category mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                SaveData.categories.Add(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = SaveData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            var oldCategory = SaveData.categories.FirstOrDefault(c => c.Id == id);

            if (oldCategory == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                oldCategory.Name = category.Name;
                oldCategory.Description = category.Description;

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = SaveData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var category = SaveData.categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                SaveData.categories.Remove(category);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
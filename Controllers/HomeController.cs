using dailyphongve.Models;
using dailyphongve.Models.viewmodels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dailyphongve.Controllers
{
    public class HomeController : Controller
    {
        private readonly dailyphongveDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly dailyphongveDbContext _context;
        private readonly IdailyphongveRepository repository;
        public int PageSize = 3;
        public HomeController(IdailyphongveRepository repo, dailyphongveDbContext context, IWebHostEnvironment hostEnvironment)
        {
            repository = repo;
            dbContext = context;
            webHostEnvironment = hostEnvironment;
            _context = context;
        }
        public IActionResult Index(string? genre, int vePage = 1)
        {
            const int PageSize = 10;

            // ✅ Lấy toàn bộ vé từ repository
            var allVes = repository.ves;

            // ✅ Lọc theo thể loại nếu có
            IQueryable<ve> filteredVes;
            if (!string.IsNullOrEmpty(genre))
            {
                filteredVes = allVes.Where(p => p.Genre == genre);
            }
            else
            {
                filteredVes = allVes;
            }

            int totalItems = filteredVes.Count();

            var vesOnPage = filteredVes
                .OrderBy(p => p.veID)
                .Skip((vePage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var pagingInfo = new PagingInfo
            {
                CurrentPage = vePage,
                ItemsPerPage = PageSize,
                TotalItems = totalItems
            };

            var viewModel = new vesListViewModel
            {
                ves = vesOnPage,
                PagingInfo = pagingInfo,
                CurrentGenre = genre
            };

            return View(viewModel);
        }


        public IActionResult Created()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Created(veViewModels model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                ve Ve = new ve
                {

                    Title = model.Title,
                    time = model.time,
                    Period = model.Period,
                    Genre = model.Genre,
                    Price = model.Price,
                    ProfilePicture = uniqueFileName,
                };
                dbContext.Add(Ve);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        private string UploadedFile(veViewModels model)
        {
            string uniqueFileName = null;

            if (model.Imageve != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Imageve.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Imageve.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Ve = await _context.ves
                .FirstOrDefaultAsync(m => m.veID == id);
            if (Ve == null)
            {
                return NotFound();
            }

            return View(Ve);
        }

        // POST: SMartPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var sMartPhone = await _context.ves.FindAsync(id);
            _context.ves.Remove(sMartPhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SMartPhoneExists(long id)
        {
            return _context.ves.Any(e => e.veID == id);
        }
    }
}

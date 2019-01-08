using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PongStudiosPortal.Data;
using PongStudiosPortal.Models;
using PongStudiosPortal.Models.GenericViewModels;

// https://github.com/BlackrockDigital/startbootstrap-thumbnail-gallery/blob/master/index.html
namespace PongStudiosPortal.Controllers
{
    [Authorize(Roles = "PortalAdmin")]
    public class PortalLinksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _env;

        public PortalLinksController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: PortalLinks
        public async Task<IActionResult> Index()
        {
            return View(await _context.PortalLinks.ToListAsync());
        }

        // GET: PortalLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portalLink = await _context.PortalLinks
                .SingleOrDefaultAsync(m => m.Id == id);

            if (portalLink == null)
            {
                return NotFound();
            }

            return View(portalLink);
        }

        // GET: PortalLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortalLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortalLinkFormViewModel viewModel)
        {
            DateTime dateTime = DateTime.UtcNow;
            string sDateTime =Convert.ToString(dateTime.Ticks);

            if (ModelState.IsValid)
            {
                var file = viewModel.Image;
                string uploadFolder = _env.WebRootPath + @"\Data\Files";
                string uploadFileName = Convert.ToString(DateTime.UtcNow.Ticks);
                string ext = new FileInfo(viewModel.Image.FileName).Extension;

                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                var filePath = Path.Combine(uploadFolder, uploadFileName + ext);

                using (var stream = System.IO.File.OpenWrite(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                
                PortalLink portalLink = new PortalLink
                {
                    Id = viewModel.Id
                    , Image = @"/Data/Files/"+ uploadFileName + ext
                    , HttpLink = viewModel.HttpLink
                    , Text = viewModel.Text
                };

                _context.Add(portalLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: PortalLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portalLink = await _context.PortalLinks.SingleOrDefaultAsync(m => m.Id == id);
            if (portalLink == null)
            {
                return NotFound();
            }
            return View(portalLink);
        }

        // POST: PortalLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,LinkName,HttpLink")] PortalLink portalLink)
        {
            if (id != portalLink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portalLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortalLinkExists(portalLink.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(portalLink);
        }

        // GET: PortalLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portalLink = await _context.PortalLinks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (portalLink == null)
            {
                return NotFound();
            }

            return View(portalLink);
        }

        // POST: PortalLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portalLink = await _context.PortalLinks.SingleOrDefaultAsync(m => m.Id == id);
            _context.PortalLinks.Remove(portalLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortalLinkExists(int id)
        {
            return _context.PortalLinks.Any(e => e.Id == id);
        }
    }
}

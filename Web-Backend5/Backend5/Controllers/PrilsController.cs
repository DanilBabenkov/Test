using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend5.Data;
using Backend5.Models;
using Backend5.Models.ViewModels;

namespace Backend5.Controllers
{
    public class PrilsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrilsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            return this.View(await this._context.Prils.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var prosto = await this._context.Prils
                .SingleOrDefaultAsync(m => m.Id == id);
            if (prosto == null)
            {
                return this.NotFound();
            }

            return this.View(prosto);
        }

        //public IActionResult Sort()
        //{
        //    return this.View(new SortModel());
        //}

        //// POST: Doctors/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Sort(SortModel model)
        //{
        //    if (this.ModelState.IsValid)
        //    {

        //         using (ApplicationDbContext db = new ApplicationDbContext())
        //        {
        //            var phones = db.Prils.OrderBy(p => p.Number);
        //            foreach (Pril p in phones)
        //                Console.WriteLine("{0}.{1} - {2}", p.Id, p.Number, p.Text);
        //        }




        //        await this._context.SaveChangesAsync();
        //        return this.RedirectToAction("Index");
        //    }
        //    return this.View(model);
        //}

        // GET: Doctors/Create
        public IActionResult Create()
        {
            return this.View(new ProstoBDCreateModel());
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProstoBDCreateModel model)
        {
            if (this.ModelState.IsValid)
            {
                var now = DateTime.UtcNow;
                var prosto = new Pril
                {
                    //Id = model.Id,
                    Text = model.Text,
                    Number = model.Number,
                    Created = now
                };

                this._context.Prils.Add(prosto);
                await this._context.SaveChangesAsync();
                return this.RedirectToAction("Index");
            }
            return this.View(model);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var prosto = await this._context.Prils.SingleOrDefaultAsync(m => m.Id == id);
            if (prosto == null)
            {
                return this.NotFound();
            }

            var model = new ProstoBDEditModel
            {
                Text = prosto.Text,
                Number = prosto.Number,
                Created = prosto.Created
            };

            return this.View(model);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32? id, ProstoBDEditModel model)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var prosto = await this._context.Prils
        .SingleOrDefaultAsync(m => m.Id == id);
            if (prosto == null)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                prosto.Text = model.Text;
                prosto.Number = model.Number;
                prosto.Created = DateTime.UtcNow;

                await this._context.SaveChangesAsync();
                return this.RedirectToAction("Index");
            }

            return this.View(model);

        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var prosto = await this._context.Prils
                .SingleOrDefaultAsync(m => m.Id == id);
            if (prosto == null)
            {
                return this.NotFound();
            }

            return this.View(prosto);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var prosto = await this._context.Prils.SingleOrDefaultAsync(m => m.Id == id);
            this._context.Prils.Remove(prosto);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction("Index");
        }
        private bool ProstoBDExists(int id)
        {
            return _context.Prils.Any(e => e.Id == id);
        }
    }
}

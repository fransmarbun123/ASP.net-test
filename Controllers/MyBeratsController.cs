using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Berat.Models;

namespace Berat.Controllers
{
    public class MyBeratsController : Controller
    {
        private BeratContext db = new BeratContext();

        // GET: MyBerats
        public async Task<ActionResult> Index()
        {
            return View(await db.MyBerats.ToListAsync());
        }

        // GET: MyBerats/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyBerat myBerat = await db.MyBerats.FindAsync(id);
            if (myBerat == null)
            {
                return HttpNotFound();
            }
            return View(myBerat);
        }

        // GET: MyBerats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyBerats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Tanggal,Max,Min,Perbedaan")] MyBerat myBerat)
        {
            if (ModelState.IsValid)
            {
                myBerat.Perbedaan = (myBerat.Max - myBerat.Min);
                db.MyBerats.Add(myBerat);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(myBerat);
        }

        // GET: MyBerats/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyBerat myBerat = await db.MyBerats.FindAsync(id);
            if (myBerat == null)
            {
                return HttpNotFound();
            }
            return View(myBerat);
        }

        // POST: MyBerats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Tanggal,Max,Min,Perbedaan")] MyBerat myBerat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myBerat).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(myBerat);
        }

        // GET: MyBerats/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyBerat myBerat = await db.MyBerats.FindAsync(id);
            if (myBerat == null)
            {
                return HttpNotFound();
            }
            return View(myBerat);
        }

        // POST: MyBerats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MyBerat myBerat = await db.MyBerats.FindAsync(id);
            db.MyBerats.Remove(myBerat);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

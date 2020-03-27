using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PoshakBioSciences.DbModel;

namespace PoshakBioSciences.Controllers
{
    public class MenuMasterController : Controller
    {
        private PoshBioSolDbEntities db = new PoshBioSolDbEntities();

        // GET: MenuMaster
        public async Task<ActionResult> Index()
        {
            return View(await db.M_MenuMaster.ToListAsync());
        }

        // GET: MenuMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MenuMaster m_MenuMaster = await db.M_MenuMaster.FindAsync(id);
            if (m_MenuMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_MenuMaster);
        }

        // GET: MenuMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MenuID,MenuName,SubMenu,Url,AltTag,Remarks,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_MenuMaster m_MenuMaster)
        {
            if (ModelState.IsValid)
            {
                db.M_MenuMaster.Add(m_MenuMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_MenuMaster);
        }

        // GET: MenuMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MenuMaster m_MenuMaster = await db.M_MenuMaster.FindAsync(id);
            if (m_MenuMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_MenuMaster);
        }

        // POST: MenuMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MenuID,MenuName,SubMenu,Url,AltTag,Remarks,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_MenuMaster m_MenuMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_MenuMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_MenuMaster);
        }

        // GET: MenuMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MenuMaster m_MenuMaster = await db.M_MenuMaster.FindAsync(id);
            if (m_MenuMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_MenuMaster);
        }

        // POST: MenuMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_MenuMaster m_MenuMaster = await db.M_MenuMaster.FindAsync(id);
            db.M_MenuMaster.Remove(m_MenuMaster);
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

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
using PoshakBioSciences.App_Code;

namespace PoshakBioSciences.Controllers
{
    public class ProductMasterController : Controller
    {
        private PoshBioSolDbEntities db = new PoshBioSolDbEntities();

        // GET: ProductMaster
        public async Task<ActionResult> Index()
        {
            return View(await db.M_ProductMaster.OrderByDescending(x=>x.ProductId).ToListAsync());
        }

        // GET: ProductMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_ProductMaster m_ProductMaster = await db.M_ProductMaster.FindAsync(id);
            if (m_ProductMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_ProductMaster);
        }

        // GET: ProductMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,ProductName,ProductSubTitle,ProdDescription,KeyFeatures,Composition,ProdApplication,ProdPresentation,ImgPath1,ImgPath2,ImgPath3")] M_ProductMaster m_ProductMaster,FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Request.Files["ImgPath1"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.PoshakBioSciencesWebResources.TextNewImagesPath);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    string FullPathWithFileName = FolderPath + "\\" + Request.Files["ImgPath1"].FileName;
                    string FolderPathForImage = Request.Files["ImgPath1"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                        Request.Files["ImgPath1"].SaveAs(FullPathWithFileName);
                        m_ProductMaster.ImgPath1 = FolderPathForImage;
                    }
                }
                if (!string.IsNullOrEmpty(Request.Files["ImgPath2"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.PoshakBioSciencesWebResources.TextNewImagesPath);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    string FullPathWithFileName = FolderPath + "\\" + Request.Files["ImgPath2"].FileName;
                    string FolderPathForImage = Request.Files["ImgPath2"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                        Request.Files["ImgPath2"].SaveAs(FullPathWithFileName);
                        m_ProductMaster.ImgPath2 = FolderPathForImage;
                    }
                }
                if (!string.IsNullOrEmpty(Request.Files["ImgPath3"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.PoshakBioSciencesWebResources.TextNewImagesPath);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    string FullPathWithFileName = FolderPath + "\\" + Request.Files["ImgPath3"].FileName;
                    string FolderPathForImage = Request.Files["ImgPath3"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                        Request.Files["ImgPath3"].SaveAs(FullPathWithFileName);
                        m_ProductMaster.ImgPath3 = FolderPathForImage;
                    }
                }
                m_ProductMaster.CreatedBy = Session["PrCode"].ToString();
                m_ProductMaster.CreatedDate = DateTime.Now;
                m_ProductMaster.ModifiedBy = Session["PrCode"].ToString();
                m_ProductMaster.ModifiedDate = DateTime.Now;
                m_ProductMaster.Active = true;
                db.M_ProductMaster.Add(m_ProductMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_ProductMaster);
        }

        // GET: ProductMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_ProductMaster m_ProductMaster = await db.M_ProductMaster.FindAsync(id);
            if (m_ProductMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_ProductMaster);
        }

        // POST: ProductMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,ProductName,ProductSubTitle,ProdDescription,KeyFeatures,Composition,ProdApplication,ProdPresentation,ImgPath1,ImgPath2,ImgPath3,CreatedBy,CreatedDate")] M_ProductMaster m_ProductMaster,FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Request.Files["ImgPath1"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.PoshakBioSciencesWebResources.TextNewImagesPath);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    string FullPathWithFileName = FolderPath + "\\" + Request.Files["ImgPath1"].FileName;
                    string FolderPathForImage = Request.Files["ImgPath1"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                        Request.Files["ImgPath1"].SaveAs(FullPathWithFileName);
                        m_ProductMaster.ImgPath1 = FolderPathForImage;
                    }
                }
                if (!string.IsNullOrEmpty(Request.Files["ImgPath2"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.PoshakBioSciencesWebResources.TextNewImagesPath);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    string FullPathWithFileName = FolderPath + "\\" + Request.Files["ImgPath2"].FileName;
                    string FolderPathForImage = Request.Files["ImgPath2"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                        Request.Files["ImgPath2"].SaveAs(FullPathWithFileName);
                        m_ProductMaster.ImgPath2 = FolderPathForImage;
                    }
                }
                if (!string.IsNullOrEmpty(Request.Files["ImgPath3"].FileName))
                {
                    string FolderPath = Server.MapPath(Resources.PoshakBioSciencesWebResources.TextNewImagesPath);// + "\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek;
                    string FullPathWithFileName = FolderPath + "\\" + Request.Files["ImgPath3"].FileName;
                    string FolderPathForImage = Request.Files["ImgPath3"].FileName;  //"\\" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.DayOfWeek + "\\" + Request.Files["StdProfilePicPath"].FileName;
                    if (CommonFunction.IsFolderExist(FolderPath))
                    {
                        Request.Files["ImgPath3"].SaveAs(FullPathWithFileName);
                        m_ProductMaster.ImgPath3 = FolderPathForImage;
                    }
                }
                m_ProductMaster.CreatedBy = Session["PrCode"].ToString();
                m_ProductMaster.CreatedDate = DateTime.Now;
                m_ProductMaster.ModifiedBy = Session["PrCode"].ToString();
                m_ProductMaster.ModifiedDate = DateTime.Now;
                db.Entry(m_ProductMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_ProductMaster);
        }

        // GET: ProductMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_ProductMaster m_ProductMaster = await db.M_ProductMaster.FindAsync(id);
            if (m_ProductMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_ProductMaster);
        }

        // POST: ProductMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_ProductMaster m_ProductMaster = await db.M_ProductMaster.FindAsync(id);
            db.M_ProductMaster.Remove(m_ProductMaster);
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

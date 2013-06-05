using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fmspod1.Models;
using System.IO;

namespace fmspod1.Controllers
{
    public class ZgloszeniaController : Controller
    {
        //
        // GET: /Zgloszenia/

        public ActionResult Index()
        {
            using (var db = new ZgloszeniaEntities())
                //return View(db.Zgloszenies.SqlQuery("SELECT * FROM Zgloszenie WHERE status = 'zgłoszona'").ToList());
                
                return View(db.Zgloszenies.ToList());
        }

        public ActionResult Status()
        { 
            using(var db = new ZgloszeniaEntities())
            if(User.Identity.Name == "admin")
            {
            return View(db.Zgloszenies.SqlQuery("SELECT * FROM Zgloszenie WHERE status = 'zgloszona'").ToList());
            }
            else return RedirectToAction("Index");
        }

      

        // public ActionResult ChosenQuery()
        //{ 
        //    using (var str = new fmspod1.Models.ChooseModels)
        //     string query = ("SELECT * FROM Zgloszenie WHERE kod_pocztowy = '{0}'",);
        //     using(var db = new ZgloszeniaEntities())             
        //     return View(db.Zgloszenies.SqlQuery(query).ToList());
        // }

        //
        // GET: /Zgloszenia/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Zgloszenia/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Zgloszenia/Create

        [HttpPost]
        public ActionResult Create(Zgloszenie zgloszenie)
        {
            try
            {
                // TODO: Add insert logic here
                using (var db = new ZgloszeniaEntities())
                {
                    db.Zgloszenies.Add(zgloszenie);
                    zgloszenie.Data = DateTime.Now;
                    zgloszenie.status = "zgloszona";
                    zgloszenie.tresc_zgloszenia = User.Identity.Name;
                    zgloszenie.zdjecie = "pierwsze pole do googlemapsa";
                    zgloszenie.komentarz_admina = "drugie ppole do googlemapsa";
                    //zgloszenie.zdjecie = GetPhoto("c:/a.jpg");
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public static byte[] GetPhoto(string filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            byte[] photo = br.ReadBytes((int)fs.Length);

            br.Close();
            fs.Close();

            return photo;
        }

        
        //
        // GET: /Zgloszenia/Edit/5
 
        public ActionResult Edit(int id)
        {
            using (var db = new ZgloszeniaEntities())
            {
                return View(db.Zgloszenies.Find(id));
            }
        }

        //
        // POST: /Zgloszenia/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Zgloszenie zgloszenie)
        {
            try
            {
                // TODO: Add update logic here
                using (var db = new ZgloszeniaEntities())
                {
                    db.Entry(zgloszenie).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Zgloszenia/Delete/5
 
        public ActionResult Delete(int id)
        {
            using (var db = new ZgloszeniaEntities())
            {
                return View(db.Zgloszenies.Find(id));
            }
        }

        //
        // POST: /Zgloszenia/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Zgloszenie zgloszenie)
        {
            try
            {
                // TODO: Add delete logic here
                using (var db = new ZgloszeniaEntities())
                {
                    db.Entry(zgloszenie).State = System.Data.EntityState.Deleted;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using CoreProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace CoreProject.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var values = c.Personels.Include(x => x.Birim).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult NewPersonel()
        {
            List<SelectListItem> degerler = (from x in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd,
                                                 Value = x.BirimID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        public IActionResult NewPersonel(Personel p)
        {
            var per = c.Birims.Where(x => x.BirimID == p.Birim.BirimID).FirstOrDefault();
            p.Birim = per;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeletePersonel(int id)
        {
            var prs = c.Personels.Find(id);
            c.Personels.Remove(prs);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetPersonel(int id)
        {
            var pers = c.Personels.Find(id);
            List<SelectListItem> degers = (from x in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd,
                                                 Value = x.BirimID.ToString()
                                             }).ToList();
            ViewBag.dgr = degers;
            return View("GetPersonel", pers);
        }

        public IActionResult UpdatePersonel(Personel p)
        {
            var psn = c.Personels.Find(p.PersonelID);
            psn.Ad = p.Ad;
            psn.Soyad = p.Soyad;
            psn.Sehir = p.Sehir;
            psn.BirimID = p.BirimID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

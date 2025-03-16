using CoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    public class BirimController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var values = c.Birims.ToList();
            return View(values);
        }

        public IActionResult NewBirim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewBirim(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBirim(int id)
        {
            var brm = c.Birims.Find(id);
            c.Birims.Remove(brm);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetBirim(int id)
        {
            var brm = c.Birims.Find(id);
            return View("GetBirim", brm);
        }

        public IActionResult UpdateBirim(Birim b)
        {
            var birm = c.Birims.Find(b.BirimID);
            birm.BirimAd = b.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DetailBirim(int id)
        {
            var values = c.Personels.Where(x => x.BirimID == id).ToList();
            var brmad = c.Birims.Where(x => x.BirimID == id).Select(y => y.BirimAd).FirstOrDefault();
            ViewBag.brm = brmad;
            return View(values);
        }
    }
}

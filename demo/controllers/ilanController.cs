using Kariyer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace Kariyer.Controllers
{
    public class ilanController : Controller
    {
        kariyerEntities db = new kariyerEntities();


        // GET: ilan
        public ActionResult ilanDetay()
        {

           
            return View();

        }
        [HttpPost]
        public JsonResult IlIlce(int? ilID, string tip,string ilcex)
        {
            //EntityFramework ile veritabanı modelimizi oluşturduk ve
            //IlilceDBEntities ile db nesnesi oluşturduk.
            kariyerEntities db = new kariyerEntities();
            //geriye döndüreceğim sonucListim
            List<SelectListItem> sonuc = new List<SelectListItem>();
            //bu işlem başarılı bir şekilde gerçekleşti mi onun kontrolunnü yapıyorum
            bool basariliMi = true;
            try
            {
                switch (tip)
                {
                    case "ilGetir":
                        //veritabanımızdaki iller tablomuzdan illerimizi sonuc değişkenimze atıyoruz
                        foreach (var il in db.iller.ToList())
                        {
                            sonuc.Add(new SelectListItem
                            {
                                Text = il.ilad,
                                Value = il.ilid.ToString()
                            });
                        }
                        break;
                    case "ilceGetir":
                        //ilcelerimizi getireceğiz ilimizi selecten seçilen ilID sine göre 
                        foreach (var ilce in db.ilceler.Where(il => il.ilid == ilID).ToList())
                        {
                            sonuc.Add(new SelectListItem
                            {
                                Text = ilce.ilce,
                                Value = ilce.ilce
                            });
                        }
                        break;
					case "ilcegetir2":
						//veritabanımızdaki iller tablomuzdan illerimizi sonuc değişkenimze atıyoruz

						var ilcegetir = db.ilceler.Where(x => x.ilce == ilcex).FirstOrDefault();
						Session["ilceID"] = ilcegetir.ilceid;

						break;

					default:
                        break;

                }
            }
            catch (Exception)
            {
                //hata ile karşılaşırsak buraya düşüyor
                basariliMi = false;
                sonuc = new List<SelectListItem>();
                sonuc.Add(new SelectListItem
                {
                    Text = "Bir hata oluştu :(",
                    Value = "Default"
                });

            }
            //Oluşturduğum sonucları json olarak geriye gönderiyorum
            return Json(new { ok = basariliMi, text = sonuc });
        }
	 


		public ActionResult Tumilanlar()
        {

            return View();
        }
        //filitre- ilker

        //[HttpGet]/bilisim-internet+egitim+pazarlama+perakende+satis+bilgi-teknolojileri-kategorisi+egitim-kategorisi+hizmet-kategorisi+pazarlama-kategorisi+satis-kategorisi-is-ilanlari
        public ActionResult ilanfilitre(int? il, string ilce, string tarih, int? sektors)
        {
            //var ilanlar = db.ilanlar_view.Where(X => X.ilad== il).FirstOrDefault();

            //return View(ilanlar)

            //TempData["YOK"] = "";
            using (kariyerEntities ctx = new kariyerEntities())
            {

                if ( il == null && sektors == null )
                {
                    var ilanhepsi = ctx.ILANDETAY_VIEW.ToList();
                    return View(ilanhepsi);
                }
                else
                {
                    var ilanfilter = (from i in ctx.ILANDETAY_VIEW.Where(x => (il == -1 || x.ilid == il)&&(sektors== -1 || x.sektorid==sektors ) && (sektors == -1 || x.sektorid == sektors)) select i).ToList();

                    return View(ilanfilter);
                     
                    
                 
                }
                 



            }


        }
        





public ActionResult ilanbasvuru(int k_id, int ilanid, string stringurl)
        {

            using (kariyerEntities ctx = new kariyerEntities())
            {
                var kayıtkontrol = ctx.ilanBasvuru.Where(x => x.ilanID == ilanid && x.kullaniciID == k_id).FirstOrDefault();

                //
                if (kayıtkontrol == null)
                {
                    ctx.basvuruEkleSP(Convert.ToInt32(ilanid), '1', Convert.ToInt32(k_id), DateTime.Now);

                    TempData["value_basvur"] = "b_yapsın";

                    return RedirectToAction("ilanDetay", "ilan", new { ilanid = Convert.ToInt32(ilanid) });
                }
                else
                {
                    TempData["value_basvur"] = "b_yapmasın";

                    return RedirectToAction("ilanDetay", "ilan", new { ilanid = Convert.ToInt32(ilanid) });
                }

            }


        }


    }

}
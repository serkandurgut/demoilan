using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Kariyer.Models;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Data.Entity;

namespace Kariyer.Controllers
{
    public class AccountController : Controller
    {
        kullanici km = new kullanici();

        kariyerEntities kt = new kariyerEntities();

        public ActionResult GetLogin()
        {
            return View();
        }

        #region VIEWS
        //register sayfası


        public ActionResult Login()
        {
            return View();

        }

        //login sayfası

        public ActionResult ConfirmedEmail()
        {
            return View();

        }
        public ActionResult Register()
        {
            return View();
        }


        #endregion

        #region POSTS



        [HttpPost]
        //login için gerekli nesne ve modelleri çekiyoruz
        public ActionResult Login(Models.Modeller.LoginModel kulx  )
        {


            //nesneler aktifse
            if (ModelState.IsValid)
            {


                using (kariyerEntities dbx = new kariyerEntities()) 
                {
                    


                    var logincontrol = dbx.kullanici.Where(x => (x.kullaniciAdi == kulx.kullaniciAdi || x.email == kulx.kullaniciAdi) && x.parola == kulx.parola ).FirstOrDefault();
                  


                        if (logincontrol != null)
                        {
                            //string aktifmi = logincontrol.aktifmi.ToString(); //true- false
                          

                        if (logincontrol.aktifmi!=false)
                        {



                            int rol = Convert.ToInt32(logincontrol.rolid);

                            Session["email"] = logincontrol.email;
                            Session["username"] = logincontrol.kullaniciAdi;
                            Session["ID"] = logincontrol.kullaniciID;
                            TempData["loginmesaj"] = "";
                            return RedirectToAction("AnaSayfa", "Home");  //anasayfaya yönlendir


                        }
                        else
                        {

                        

                            TempData["login_a"] = "var";
                        }
                    

                    }
                    else
                    {
                        TempData["loginmesaj"] = "Kullanıcı ve Şifre Yanlış";
                        TempData["loginred"] = "var";
                        //eposta onayınız yapılmaıştır
                    }
                            
                        //      if (aktifcontrol!=null)
                        //    {
                        //    TempData["login_a"] = "var";
                        //    }
                        //      else if(aktifcontrol == null)
                        //{

                        //}
                        //      if (parolacntrl!=null) {

                        //    TempData["pw_k"] = "var";
                        //}


                        
                    }



                }
            
            return View();

        }


      


        [HttpPost]
        public ActionResult Register(int rols, Models.Modeller.RegisterModel kul)
        {

            //register için gerekli nesne ve modeller

            Guid g = Guid.NewGuid(); // Guid oluşturmç
            var keyid = TempData["deneme"] = g;
            Session["h2"] = keyid;
            kul.rolid = rols;
            //kullanıcıadı ve email sistemde kayıtlı mı =?
            if (ModelState.IsValid) //nesneler aktifse

            {
             
                using (kariyerEntities ctx = new kariyerEntities()) //ana modelimizi open ve dispose etmek için kullanılıyor
                {

                    var kulkayit = ctx.kullanici.Where(x => x.kullaniciAdi == kul.kullaniciAdi  || x.email == kul.email).FirstOrDefault();

                    if (kulkayit == null)
                    {


                        ctx.kullaniciekle(kul.kullaniciAdi, kul.email, kul.parola, kul.rolid, DateTime.Now, null, false);
                        var message = "http://localhost:63611/Account/ConfirmedEmail/?username=" + kul.kullaniciAdi + "&kod=" + keyid;
                        var body = new StringBuilder();
                        body.AppendLine(message);
                        MailSender(body.ToString(), kul.email.ToString());

                         
                        return  RedirectToAction("Login","Account");
                    }
                    else
                    {
                      

                    }

                    var mailcntrl = ctx.kullanici.Where(x => x.email == kul.email).FirstOrDefault();
                    var usrcntrl = ctx.kullanici.Where(x => x.kullaniciAdi == kul.kullaniciAdi).FirstOrDefault();
                    if (usrcntrl!=null)
                    {
                        TempData["kayıt_k"] = "var";
                    }
                    else if(usrcntrl==null)
                    {
                        TempData["kayıt_k"] = "yok";
                    }

                    if (mailcntrl != null)
                    {
                        TempData["eposta_k"] = "var";
                    }
                    else if (mailcntrl == null)
                    {
                        TempData["eposta_k"] = "yok";
                    }
                }
                    
            }
      
            return View();
        }

             


            
         

    
    #endregion
    #region METODS
    public static void MailSender(string body, string email) //mail gönderme metodu
    {
        var fromAddress = new MailAddress("serkann.091@gmail.com"); //hangi adresten
        var toAddress = new MailAddress(email); //mail nesnesindeki adrese //ne alaka ya
        const string subject = "www.canlimulakat.com | Mail Onaylama"; //konu
        using (var smtp = new SmtpClient  //smtp ayarları
        {
            Host = "smtp.gmail.com", //gmail hostu
            Port = 587, //türkiye portu
            EnableSsl = true, //ssl aktif
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, "d3n3m3d3n") //gönderen mailinde oturum aç
        })
        {
            using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
            {
                smtp.Send(message); //mail gönder
            }
        }
    }
    #endregion
}
        }
    
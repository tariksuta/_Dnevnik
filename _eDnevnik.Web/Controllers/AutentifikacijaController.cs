﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _eDnevnik.Data;
using _eDnevnik.Data.EntityModel;
using _eDnevnik.Web.Helper;
using _eDnevnik.Web.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _eDnevnik.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private MyDbContext _db;
        public AutentifikacijaController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()//Dodaja na sve akcije I <- ActionResut
        {
            return View(new LoginVM()
            {
                ZapamtiPassword = false//Difoltna vrijednost da se zapamti password
            });
        }

        public IActionResult Logins(LoginVM input) {
          
            Login korisnik = _db.Login.SingleOrDefault(x => x.KorisnickoIme == input.Username && x.Sifra == input.Password);
            if (korisnik == null) {
                //ViewData["error_poruka"] = "pogrešan username ili password ";
                TempData["error_poruka"] = "pogrešan username ili password ";
                return View("Index", input);//View,Parametar
            }

            //Nakon ukljucivanja sesija mozemo poslat podatke 1.
            //HttpContext.Session.SetString("nekiKey",korisnik.Username);

            //Ali ako zelimo poslati cijeli objekat, moramo koristiti helper metodu MySessionExtensions 2.
            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-3.0
            //HttpContext.Session.Set("nekiKey",korisnik);//Hleper..

            //3.
            HttpContext.SetLogiraniKorisnik(korisnik, input.ZapamtiPassword);

            return RedirectToAction("Index", "Home");//Akcija, Kontroler
        }

        public IActionResult Logout()
        {
            //HttpContext.SetLoginKorisnik(null);   

            return RedirectToAction("Index");
        }



    }
}
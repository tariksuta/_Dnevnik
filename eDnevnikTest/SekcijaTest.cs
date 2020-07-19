using _eDnevnik.Data;
using _eDnevnik.Web.Controllers;
using _eDnevnik.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eDnevnikTest
{
    [TestClass]
    public class SekcijaTest
    {
        public SekcijaTest()
        {
        }
        [TestMethod]
        public void TestirajPrikazSekcije()
        {
            SekcijaController controller = new SekcijaController(new MyDbContext());
            ViewResult result = controller.PrikazSekcija() as ViewResult;
            var model = result.Model as SekcijaPrikazSekcijaVM;
            Assert.AreEqual(3, model.sekcije.Count);
        }

        [TestMethod]
        public void TestirajDrzavaDodajUredi()
        {
            DrzavaController controller = new DrzavaController(new MyDbContext());
            ViewResult result = controller.DodajUredi(1) as ViewResult;
            var model = result.Model as DrzavaDodajUrediVM;
            Assert.AreEqual("Bosna i Hercegovina", model.Naziv);
        }


        [TestMethod]
        public void TestirajPredmetDodajUredi()
        {
            PredmetController controller = new PredmetController(new MyDbContext());
            ViewResult result = controller.DodajUredi(0) as ViewResult;
            var model = result.Model as PredmetDodajUrediVM;
            Assert.IsNull(model.Naziv);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestirajOdjeljenjeUcenikDodaj_neposojece()
        {
            OdjeljenjeUcenikController controller = new OdjeljenjeUcenikController(new MyDbContext());
            ViewResult result = controller.DodajUredi(1) as ViewResult;//neosojeci
        }

        [TestMethod]
        public void TestirajOdjeljenjeUcenikDodaj_po_vise_vrijednosti()
        {
            OdjeljenjeUcenikController controller = new OdjeljenjeUcenikController(new MyDbContext());
            ViewResult result = controller.DodajUredi(2048) as ViewResult;
            var model = result.Model as OdjeljenjeUcenikDodajUrediVM;
            Assert.AreEqual(12, model.OdjeljenjeID);
            Assert.AreEqual(1, model.UcenikID);
            Assert.AreEqual(2, model.BrojUDnevniku);
        }

        //[TestMethod]//odkomentarisi u gradDodajUredi
        //[ExpectedException(typeof(Exception))]
        //public void TestirajGradDodajUredi()
        //{
        //    GradController controller = new GradController(new MyDbContext());
        //    ViewResult result = controller.DodajUredi(7689) as ViewResult;
        //}

    }
}
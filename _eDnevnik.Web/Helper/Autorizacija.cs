using _eDnevnik.Data;
using _eDnevnik.Data.EntityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eDnevnik.Web.Helper
{//atribut se koristi tako sto se navede naziv "Autorizacija" bez nastavka Attribut(moze i sa njim) 
 //iznad akcija koje zelimo zastitit ili cijelog kontrolera i onda se odnosi na sve akcije unutar kontrolera
    public class AutorizacijaAttribute:TypeFilterAttribute//filter https://www.c-sharpcorner.com/article/working-with-filters-in-asp-net-core-mvc/
    {
        public AutorizacijaAttribute(bool roditelj, bool profesor, bool administrator) :base(typeof(MyAuthorizeImpl)) {
            Arguments = new object[] { roditelj, profesor, administrator };
        }
    }

    public class MyAuthorizeImpl : IAsyncActionFilter 
    {
        public MyAuthorizeImpl(bool roditelj, bool profesor, bool administrator) {
            _roditelj = roditelj;
            _profesor = profesor;
            _administrator = administrator;
        }

        private readonly bool _roditelj;
        private readonly bool _profesor;
        private readonly bool _administrator;

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next) {

            //Login k = Autetntifikacija.GetLogiraniKorisnik(filterContext.HttpContext);
            Login k = filterContext.HttpContext.GetLogiraniKorisnik();

            if (k == null) {
                if (filterContext.Controller is Controller controller) {
                    controller.TempData["error_poruka"] = "Niste logirani";
                }
                filterContext.Result = new RedirectToActionResult("Index", "Autentifikacija", new { area = "" });
                return;
            }

            //DbContext preuzimamo preko app servisa
            MyDbContext db = filterContext.HttpContext.RequestServices.GetService<MyDbContext>();//GetRequiredService

            //prava pristupa
            if (_roditelj && db.Roditelj.Any(s => s.LoginID == k.ID)) {
                await next();
                return;
            }

            if (_profesor && db.Profesor.Any(s => s.LoginID == k.ID))
            {
                await next();
                return;
            }

            if (_administrator && db.Administrator.Any(s => s.LoginID == k.ID))
            {
                await next();
                return;
            }

            if (filterContext.Controller is Controller c1)
            {
                c1.TempData["error_poruka"] = "Nemate pravo pristupa";
            }
            filterContext.Result = new RedirectToActionResult("Index", "Home", new { area = "" });
            return;
        }

        public void OnActionExecuted(ActionExecutedContext context) { 
            //throw new NotImplementException();
        }

    }


}

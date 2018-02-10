using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Dominio.Application;
using ECommerce.Dominio.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ClienteController : Controller
    {
        IClienteSrv servicio;
        public ClienteController()
        {
            servicio = App.GetInstance<IClienteSrv>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await servicio.LoginAsync(request);
            return Redirect("/");
        }
    }
}
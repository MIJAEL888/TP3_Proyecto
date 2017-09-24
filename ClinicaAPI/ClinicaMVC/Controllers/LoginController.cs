using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ClinicaBussines;
using ClinicaEntity;
using ClinicaMVC.Models;
using ClinicaUtil;

namespace ClinicaMVC.Controllers
{
    public class LoginController : Controller
    {
        readonly UsuarioBl _usuarioBl = UsuarioBl.Instance;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn(UsuarioViewModel model)
        {
            var entidad =_usuarioBl.Get(model.CorreoUsuario, model.Contrasenia);
            if (entidad == null || entidad.Id == 0)
                return Json(new
                {
                    estado = "error",
                    mensaje = "No se hallo usuario."
                });

            Session[Constantes.NombreSession.Usuario] = entidad;
            return Json(new
            {
                estado = "ok"
            });
        }

    }
}
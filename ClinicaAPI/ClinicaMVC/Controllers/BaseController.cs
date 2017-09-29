using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicaEntity;
using ClinicaUtil;

namespace ClinicaMVC.Controllers
{
    public partial class BaseController : Controller
    {
        protected Usuario UsuarioData;

        public BaseController()
        {
            GetUsuario();
        }

        public void GetUsuario()
        {
            try
            {
                if (System.Web.HttpContext.Current.Session[Constantes.NombreSession.Usuario] != null)
                {
                    UsuarioData = (Usuario)System.Web.HttpContext.Current.Session[Constantes.NombreSession.Usuario] ?? new Usuario();
                    ViewBag.Usuario = UsuarioData;
                }
                else
                {
                    UsuarioData = new Usuario();
                    ViewBag.Usuario = new Usuario();
                }
                
            }
            catch (Exception e)
            {
                UsuarioData = new Usuario();
                ViewBag.usuario = UsuarioData;
            }
        }
    }
}
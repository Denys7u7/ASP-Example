using EjemploCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjemploCRUD.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        EstudianteModel em = new EstudianteModel();
        public ActionResult Index()
        {
            DataSet ds = em.mostrarEstudiantes();
            
            ViewBag.emp = ds.Tables[0];
            return View();
        }

        public ActionResult insertarEstudiante()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertarEstudiante(FormCollection fc)
        {
            Estudiante est = new Estudiante(fc["carnet"],fc["nombre"], fc["apellido"], fc["sexo"], fc["edad"]);
            if (em.agregarEstudiante(est))
            {
                TempData["mensaje"] = "Estudiante agregado correctamente";
            }
            else
            {
                TempData["mensaje"] = "El estudiante no se pudo ingresar";
            }
            return RedirectToAction("Index");
        }

        public ActionResult modificarEstudiante(int id)
        {
            DataSet ds = em.mostrarEstudiante(id);
            ViewBag.emp = ds.Tables[0];
            return View();
        }
        

        [HttpPost]
        public ActionResult modificarEstudiante(FormCollection fc)
        {
            Estudiante est = new Estudiante(int.Parse(fc["id"]), fc["carnet"], fc["nombre"], fc["apellido"], fc["sexo"], fc["edad"]);
            if (em.modificarEstudiante(est))
            {
                TempData["mensaje"] = "Estudiante modificado correctamente";
            }
            else
            {
                TempData["mensaje"] = "El estudiante no se pudo modificar";
            }
            return RedirectToAction("Index");
        }


        public ActionResult eliminarEstudiante(int id)
        {
            Estudiante est = new Estudiante(id);
            em.eliminarEstudiante(est);
            TempData["mensaje"] = "Estudiante borrado correctamente";
            return RedirectToAction("Index");
        }
    }
}
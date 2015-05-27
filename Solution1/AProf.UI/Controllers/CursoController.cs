using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AProf.Repository.Repositorio;
using AProf.Data.Entidade;

namespace AProf.UI.Controllers
{
    public class CursoController : Controller
    {
        //
        // GET: /Curso/
        public ActionResult Index()
        {
            List<Curso> cursos = CursoRepositorio.GetAll();
            return View(cursos);
        }

        

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Curso curso)
        {
            CursoRepositorio.Create(curso);
            return View();
        }

        public ActionResult Edit(int id)
        {
            Curso curso = (Curso)CursoRepositorio.GetOne(id);
            return View(curso);
        }

        [HttpPost]
        public ActionResult Edit(Curso curso)
        {
            CursoRepositorio.Edit(curso);
            return View();
        }

        public ActionResult Delete(int id)
        {
            
            CursoRepositorio.Delete(id);
            return Redirect("/curso");
        }
	}
}
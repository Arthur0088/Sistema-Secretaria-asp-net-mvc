using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Secretaria.Model;
using Microsoft.EntityFrameworkCore;

namespace Secretaria.View.Controllers
{
    public class MatriculaController : Controller
    {
        Dbo_SecretariaContext odb;

        public MatriculaController()
        {
            odb = new();
           
        }       
        public IActionResult Index()
        {
            var List = odb.TbMatricula.Include(d => d.CursoIdCursoNavigation).Include(e => e.AlunoIdAlunoNavigation).AsNoTracking();
            return View(List);
    
        }

        public IActionResult Create()
        {
            var lista = new SelectList(odb.TbCurso.ToList(), "IdCurso", "NomeCurso");
            ViewBag.ListaCurso = lista;
            var lista2 = new SelectList(odb.TbAluno.ToList(), "IdAluno", "Nome");
            ViewBag.ListaAluno = lista2;
            return View();
        }
        public IActionResult Edit(int id)
        {
            var lista = new SelectList(odb.TbCurso.ToList(), "IdCurso", "NomeCurso");
            ViewBag.ListaCurso = lista;
            var lista2 = new SelectList(odb.TbAluno.ToList(), "IdAluno", "Nome");
            ViewBag.ListaAluno = lista2;
            TbMatricula oMatricula = odb.TbMatricula.Find(id);
            return View(oMatricula);
        }
        public IActionResult Delete(int id)
        {
            var lista = new SelectList(odb.TbCurso.ToList(), "IdCurso", "NomeCurso");
            ViewBag.ListaCurso = lista;
            var lista2 = new SelectList(odb.TbAluno.ToList(), "IdAluno", "Nome");
            ViewBag.ListaAluno = lista2;
            TbMatricula oMatricula = odb.TbMatricula.Find(id);
            return View(oMatricula);
        }
        public IActionResult Details(int id)
        {
            var lista = new SelectList(odb.TbCurso.ToList(), "IdCurso", "NomeCurso");
            ViewBag.ListaCurso = lista;
            var lista2 = new SelectList(odb.TbAluno.ToList(), "IdAluno", "Nome");
            ViewBag.ListaAluno = lista2;
            TbMatricula oMatricula = odb.TbMatricula.Find(id);
            return View(oMatricula);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int id, TbMatricula oMatricula)
        {
            TbMatricula omatricula = odb.TbMatricula.Find(id);
            return View(omatricula);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbMatricula oMatricula)
        {
            odb.Remove(oMatricula);
            odb.SaveChanges();
            return RedirectToAction("Index");

        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbMatricula oMatricula)
        { 
            odb.TbMatricula.Add(oMatricula);
            odb.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TbMatricula oMatricula)
        {
            var oMatriculaBanco = odb.TbMatricula.Find(id);
            oMatriculaBanco.AlunoIdAluno = oMatricula.AlunoIdAluno;
            oMatriculaBanco.CursoIdCurso = oMatricula.CursoIdCurso;
            oMatriculaBanco.Situacao=oMatricula.Situacao;
            odb.Entry(oMatriculaBanco).State = EntityState.Modified;
            odb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


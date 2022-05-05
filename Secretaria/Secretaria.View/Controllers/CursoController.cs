using Microsoft.AspNetCore.Mvc;
using Secretaria.Model;
using Microsoft.EntityFrameworkCore;

namespace Secretaria.View.Controllers
{
    public class CursoController : Controller
    {
        Dbo_SecretariaContext odb;

        public CursoController()
        {
            odb = new();
        }
        public IActionResult Index()
        {
            List<TbCurso> oLista = odb.TbCurso.ToList();
            return View(oLista);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            TbCurso oCurso = odb.TbCurso.Find(id);
            return View(oCurso);
        }
        public IActionResult Edit(int id)
        {
            TbCurso oCurso = odb.TbCurso.Find(id);
            return View(oCurso);
        }
        public IActionResult Details(int id)
        {
            TbCurso oCurso = odb.TbCurso.Find(id);
            return View(oCurso);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int id,TbCurso oCurso)
        {
            TbCurso ocurso = odb.TbCurso.Find();
            return View(ocurso);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbCurso oCurso)
        {
           
            odb.TbCurso.Add(oCurso);
            odb.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbCurso oCurso)
        {
            odb.Remove(oCurso);
            odb.SaveChanges();
            return RedirectToAction("Index");
        }

        public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TbCurso> GetEntityEntry(TbCurso oCurso)
        {
            return odb.Entry(oCurso);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TbCurso oCurso)
        {
            var oCursoBanco = odb.TbCurso.Find(id);
            oCursoBanco.NomeCurso = oCurso.NomeCurso;   
            oCursoBanco.Descricao = oCurso.Descricao;
            odb.Entry(oCursoBanco).State = EntityState.Modified;
            odb.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
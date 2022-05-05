using Microsoft.AspNetCore.Mvc;
using Secretaria.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Secretaria.View.Controllers
{
    public class AlunoController : Controller
    {
        Dbo_SecretariaContext odb;

        public AlunoController()
        {
            odb = new();
        }
        public IActionResult Index()
        {
            var oLista = odb.TbAluno.Include(d => d.CursoIdCursoNavigation).AsNoTracking();
            
            return View(oLista);
        }
        public IActionResult Create()
        {
            var lista = new SelectList(odb.TbCurso.ToList(), "IdCurso" , "NomeCurso");
            ViewBag.ListaCurso = lista;
            return View();
        }
        public IActionResult Delete(int id)
        {
            TbAluno oAluno = odb.TbAluno.Find(id);
            return View(oAluno);
        }
        public IActionResult Edit(int id)
        {
            var lista = new SelectList(odb.TbCurso.ToList(), "IdCurso", "NomeCurso");
            ViewBag.ListaCurso = lista;
            TbAluno oAluno = odb.TbAluno.Find(id);
            return View(oAluno);
        }
        public IActionResult Details(int id)
        {
            var lista = new SelectList(odb.TbCurso.ToList(), "IdCurso", "NomeCurso");
            ViewBag.ListaCurso = lista;
            TbAluno oAluno = odb.TbAluno.Find(id);
            return View(oAluno);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int id, TbAluno oAluno)
        {
            
            TbAluno oaluno = odb.TbAluno.Find(id);
            return View(oaluno);

        }
            [HttpPost]
            [ValidateAntiForgeryToken]
        public ActionResult Delete(TbAluno oAluno)
        {
            odb.Remove(oAluno);
            odb.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TbAluno oAluno)
        {
            var oAlunoBanco = odb.TbAluno.Find(id);
            oAlunoBanco.Nome= oAluno.Nome;
            oAlunoBanco.Cpf=oAluno.Cpf;
            oAlunoBanco.DataInicio= oAluno.DataInicio;
            odb.Entry(oAlunoBanco).State = EntityState.Modified;
            odb.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbAluno oAluno)
        {
            
            odb.TbAluno.Add(oAluno);
            odb.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

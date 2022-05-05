using Microsoft.AspNetCore.Mvc;
using Secretaria.Model;
using Microsoft.EntityFrameworkCore;

namespace Scretaria.View.Controllers
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
            List<TbAluno> oLista = odb.TbAluno.ToList();
            return View(oLista);
        }
    }
}

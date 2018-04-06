using FanSoftStore.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSoftStore.UI.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<ProdutoModel>()
            {
                new ProdutoModel(){Nome = "Picanha", Tipo = "Alimento", Valor = 80.90},
                new ProdutoModel(){Nome = "Paste de Dente", Tipo = "Higiene", Valor = 2.90},
                new ProdutoModel(){Nome = "Leite", Tipo = "Alimento", Valor = 1.90}
            };

            return View(model);
        }
    }
}

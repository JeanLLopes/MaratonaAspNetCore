using FanSoftStore.UI.Data;
using FanSoftStore.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSoftStore.UI.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly DataContext _dataContext;

        public ProdutosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            //LIST DATA TO DATABASE IN TABLE "PRODUTOS"
            //ADD TIPO DE PRODUTO
            var model = _dataContext.Produtos.Include(x => x.Tipo).ToList();
            return View(model);
        }
    }
}

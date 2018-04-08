using FanSoftStore.UI.Data;
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
        private readonly DataContext _dataContext;

        public ProdutosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            //LIST DATA TO DATABASE IN TABLE "PRODUTOS"
            var model = _dataContext.Produtos.ToList();
            return View(model);
        }
    }
}

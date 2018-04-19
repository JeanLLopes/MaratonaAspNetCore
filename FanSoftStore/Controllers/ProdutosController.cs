using FanSoftStore.UI.Data;
using FanSoftStore.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace FanSoftStore.UI.Controllers
{
    [Authorize]
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

        public IActionResult AddEdit(int? Id)
        {
            //GET A LIST OF PRODUCTS
            //x => new { x.Id, x.Nome } //SELECT ONLY SOME DATAS USING "SelectListItem"
            //GENERATE A SELECTLIST WITH SelectListItem
            var tipos = _dataContext.TipoProdutos.ToList().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });
            ViewBag.Tipo = tipos;

            //VEIRIFIED IF HAVE A ID PASSED BY PARAMETER
            var model = new ProdutoModel();
            if (Id != null)
            {
                //SEARCH BY PRIMARY KEY
                model = _dataContext.Produtos.Find(Id);
            }


            return View(model);
        }

        [HttpPost]
        public IActionResult AddEdit(ProdutoModel produtoModel)
        {

            if (ModelState.IsValid)
            {
                //ADD IN DATABASE
                _dataContext.Add(produtoModel);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }

            //GET A LIST OF PRODUCTS
            //x => new { x.Id, x.Nome } //SELECT ONLY SOME DATAS USING "SelectListItem"
            //GENERATE A SELECTLIST WITH SelectListItem
            var tipos = _dataContext.TipoProdutos.ToList().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nome });
            ViewBag.Tipo = tipos;
            return View(produtoModel);
            
        }


        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            try
            {
                var produto = _dataContext.Produtos.Find(id);

                if (produto != null)
                {
                    _dataContext.Produtos.Remove(produto);
                    _dataContext.SaveChanges();

                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(string.Format("{0} removido com sucesso", produto.Nome.ToUpper()));
                }
                return NotFound("produto não encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using FanSoftStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanSoftStore.UI.Data
{
    public static class DbInitializer
    {
        //DATABASE INITIALIZER
        public static void InitDb(DataContext dataContext)
        {
            //VERIFIA  CONXÃO COM O BANCO DE DAODOS
            dataContext.Database.EnsureCreated();


            if (!dataContext.Produtos.Any())
            {
                var Alimentacao = new TipoProdutoModel() { Nome = "Alimentação" };
                var Higiene = new TipoProdutoModel() { Nome = "Higiene" };


                //CASE NOT FOUND DATA ION DATABASE
                //HE GO CREATE A DATAS IN DATABASE
                var model = new List<ProdutoModel>()
                {
                    new ProdutoModel(){Nome = "Picanha", Tipo = Alimentacao, Valor = 80.90M},
                    new ProdutoModel(){Nome = "Paste de Dente", Tipo = Higiene, Valor = 2.90M},
                    new ProdutoModel(){Nome = "Leite", Tipo = Alimentacao, Valor = 1.90M}
                };
                
                //ADD DATA IN TABLE
                dataContext.AddRange(model);

                //SAVE DATA IN DATABASE
                dataContext.SaveChanges();
            }
        }
    }

}

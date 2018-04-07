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
                //CASE NOT FOUND DATA ION DATABASE
                //HE GO CREATE A DATAS IN DATABASE
                var model = new List<ProdutoModel>()
                {
                    new ProdutoModel(){Nome = "Picanha", Tipo = "Alimento", Valor = 80.90},
                    new ProdutoModel(){Nome = "Paste de Dente", Tipo = "Higiene", Valor = 2.90},
                    new ProdutoModel(){Nome = "Leite", Tipo = "Alimento", Valor = 1.90}
                };
                
                //ADD DATA IN TABLE
                dataContext.AddRange(model);

                //SAVE DATA IN DATABASE
                dataContext.SaveChanges();
            }
        }
    }

}

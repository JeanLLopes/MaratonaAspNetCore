using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanSoftStore.UI.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }
    }
}

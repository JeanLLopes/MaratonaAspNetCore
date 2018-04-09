using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSoftStore.UI.Models
{
    [Table("TipoProduto")]
    public class TipoProdutoModel : EntityModel
    {
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Nome { get; set; }

        public List<ProdutoModel> Produtos { get; set; } = new List<ProdutoModel>();
    }
}

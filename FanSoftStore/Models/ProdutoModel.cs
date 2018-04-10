using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FanSoftStore.UI.Models
{
    [Table("Produto")]
    public class ProdutoModel : EntityModel
    {
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Nome { get; set; }

        public int TipoProdutoId { get; set; }

        [Column(TypeName = "money")]
        public decimal Valor { get; set; }


        //CREATE A FOREING KEY
        [ForeignKey("TipoProdutoId")]
        public TipoProdutoModel Tipo { get; set; }

        [Column(TypeName ="varchar(300)")]
        public string Descricao { get; set; }
    }
}

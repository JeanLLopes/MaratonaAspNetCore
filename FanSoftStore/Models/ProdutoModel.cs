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
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int TipoProdutoId { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Campo Obrigatório")]

        public decimal Valor { get; set; }


        //CREATE A FOREING KEY
        [ForeignKey("TipoProdutoId")]
        public TipoProdutoModel Tipo { get; set; }

        [Column(TypeName ="varchar(300)")]
        [StringLength(300,ErrorMessage = "Máximo de 300 caracteres")]
        public string Descricao { get; set; }
    }
}

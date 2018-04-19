using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FanSoftStore.UI.Models
{
    [Table("Usuario")]
    public class UsuarioModel : EntityModel
    {
        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Senha { get; set; }
    }
}

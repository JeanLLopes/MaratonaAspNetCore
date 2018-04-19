using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FanSoftStore.UI.ViewModel
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "campo obrigatorio")]
        [StringLength(100, ErrorMessage = "tamanho excedido")]
        [EmailAddress(ErrorMessage = "email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "campo obrigatorio")]
        [StringLength(100, ErrorMessage = "tamanho excedido")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


        public bool Lembrar { get; set; } = true;

        public string ReturnUrl { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSoftStore.UI.Models
{
    public abstract class EntityModel
    {
        [Key]
        public int Id { get; set; }


        public DateTime DataCriacao { get; set; } = DateTime.Now;

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdapis.Shared.Modelo
{
    public class Anuncios
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Nombre { get; set; }
        public int Duracion { get; set; }
        [Required(ErrorMessage = "El valor es obligatorio")]
        public int Costo { get; set; }
        public virtual ICollection<Transmisiones>? Transmisiones { get; set; }
    }
}

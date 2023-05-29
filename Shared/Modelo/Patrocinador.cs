using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdapis.Shared.Modelo
{
    public class Patrocinador
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio"), MaxLength(100)]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El numero es obligatorio"), MaxLength(10), Phone]
        public string? Contacto { get; set; }
        [Required(ErrorMessage = "El tipo de patrocinador es obligatorio"), MaxLength(50)]
        public string? Tipo { get; set; }
        public virtual ICollection<Ingresos>? Ingresos { get; set; }

    }
}

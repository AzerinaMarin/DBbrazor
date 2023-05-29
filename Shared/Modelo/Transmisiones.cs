using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bdapis.Shared.Modelo
{
    public class Transmisiones
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Encuentro { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime? Fecha { get; set; }
        public string? Torneo { get; set; }
        public int AnuncioId { get; set; }
        public virtual Anuncios? Anuncios { get; set; }
    }
}
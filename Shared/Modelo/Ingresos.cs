using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdapis.Shared.Modelo
{
    public class Ingresos
    {
        public int Id { get; set; }
        public int AnuncioId { get; set; }
        public virtual Anuncios? Anuncios { get; set; }
        public int PatrocinadorId { get; set; }
        public virtual Patrocinador? Patrocinador { get; set; }
        [Required(ErrorMessage ="El monto es necesario")]
        public int Total { get; set; }
        public int Pagado { get; set; }
    }
}

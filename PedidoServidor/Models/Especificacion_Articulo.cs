using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoServidor.Models
{
    [Table("Especificacion_Articulo")]
    public class Especificacion_Articulo
    {
                 
        [Key]
        [Required]
        public string codigo{ get; set; }

        [StringLength(100)]
        [Required]
        public string Nombre { get; set; }

        [StringLength(100)]
        [Required]
        public string Descripcion { get; set; }        

        public string Imagen{ get; set; }
        
    }
}
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
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public String Nombre { get; set; }

        [StringLength(100)]
        [Required]
        public String Descripcion { get; set; }        

        public String Imagen{ get; set; }
        
    }
}
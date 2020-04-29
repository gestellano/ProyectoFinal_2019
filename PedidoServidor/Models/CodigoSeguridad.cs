using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PedidoServidor.Models
{
    [Table("CodigoSeguridad")]
    public class CodigoSeguridad
    {
        [Key]
        [Required]
        public String numCodigo { get; set; }

     
        [Required]
        public String codigo { get; set; }
    }
}
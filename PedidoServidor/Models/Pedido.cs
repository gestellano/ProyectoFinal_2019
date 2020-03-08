using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoServidor.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RutCliente{ get; set; }

        [Required]
        public string Fecha { get; set; }        

        public Boolean EstadoImpresion { get; set; }        

        [Required]
        public string CodigoProducto { get; set; }


        [StringLength(50)]
        [Required]
        public String TipoEnvio { get; set; }
        
    }
}
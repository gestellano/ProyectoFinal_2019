using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoServidor.Models
{
    [Table("Linea_Pedido")]
    public class Linea_Pedido
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public string  CodigoArticulo{ get; set; }
        
    }
}
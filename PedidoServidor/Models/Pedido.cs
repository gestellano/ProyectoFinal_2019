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
        [Required]
        public int Id { get; set; }

        [Required]
        public Cliente ClientePedido  { get; set; }

        [Required]
        public DateTime Fecha { get; set; }        

        public Boolean EstadoImpresion { get; set; }        

        [Required]
        public virtual IList<Linea_Pedido> ArticulosPedidos { get; set; }
       

        [StringLength(50)]
        [Required]
        public String TipoEnvio { get; set; }
        
    }
}
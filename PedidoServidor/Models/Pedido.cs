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
        public DateTime Fecha { get; set; }        

        public Boolean EstadoImpresion { get; set; }
        //anotacion para default FALSE en base de datos

        [Required]
        public List<Linea_Pedido> ArticulosPedidos { get; set; }
        //Se pasa una lista aca para entity?

        [StringLength(50)]
        [Required]
        public String TipoEnvio { get; set; }
        
    }
}
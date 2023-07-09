using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace asignacion.Models
{
        public class Ciudades
        {
            public Guid Id { get; set; }

            [StringLength(50)]
            public string Ciudad { get; set; }
        }

        public class Clientes
        {
            public Guid Id { get; set; }

            [StringLength(50)]
            public string Nombre { get; set; } 

            [StringLength(50)]
            public string Apellido { get; set; }

            [StringLength(100)]
            public string Domicilio { get; set; } 

            [StringLength(100)]
            public string Email { get; set; } 

            [StringLength(100)]
            public string Password { get; set; } 

            [ForeignKey("Ciudad")]
            public int CiudadId { get; set; }

            public bool Habilitado { get; set; }
        }

        public class Facturas
        {
            public Guid Id { get; set; }
            public int ClienteId { get; set; }

            [Column(TypeName = "datetime")]
            public DateTime Fecha { get; set; }

            [StringLength(200)]
            public string Detalle { get; set; }

            //[DecimalPrecision(18, 4)]
            public decimal Importe { get; set; }
        }
    }

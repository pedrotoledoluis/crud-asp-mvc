using System.ComponentModel.DataAnnotations;

namespace MovInventario.Application.Models
{
    public class MovInventario
    {
        [Required]
        public string CodCia { get; set; } = default!;

        [Required]
        public string CompaniaVenta3 { get; set; } = default!;

        [Required]
        public string AlmacenVenta { get; set; } = default!;

        [Required]
        public string TipoMovimiento { get; set; } = default!;

        [Required]
        public string? TipoDocumento { get; set; }

        [Required]
        [RegularExpression(@"^\d{6,8}$", ErrorMessage = "Debe tener entre 6 y 8 dígitos")]
        public string? NroDocumento { get; set; }

        [Required]
        public string CodItem2 { get; set; } = default!;

        public string? Proveedor { get; set; }
        public string? AlmacenDestino { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        public DateTime? FechaTransaccion { get; set; }
    }
}

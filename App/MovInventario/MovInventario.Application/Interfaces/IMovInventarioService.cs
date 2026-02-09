using MovInventario.Application.Models;

namespace MovInventario.Application.Interfaces
{
    public interface IMovInventarioService
    {
        IEnumerable<Models.MovInventario> ObtenerMovimientos(
            DateTime? fechaInicio,
            DateTime? fechaFin,
            string? tipoMovimiento,
            string? nroDocumento);

        void RegistrarMovimiento(Models.MovInventario movimiento);
        void ActualizarMovimiento(Models.MovInventario movimiento);
        void EliminarMovimiento(MovInventarioKey key);
    }
}

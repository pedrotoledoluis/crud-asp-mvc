using MovInventario.Application.Models;

namespace MovInventario.Application.Interfaces;

public interface IMovInventarioRepository
{
    IEnumerable<Models.MovInventario> GetAll(
        DateTime? fechaInicio,
        DateTime? fechaFin,
        string? tipoMovimiento,
        string? nroDocumento);

    void Insert(Models.MovInventario entity);
    void Update(Models.MovInventario entity);
    void Delete(MovInventarioKey key);
}

using MovInventario.Application.Interfaces;
using MovInventario.Application.Models;
using Models = MovInventario.Application.Models;

namespace MovInventario.Application.Services;

public class MovInventarioService : IMovInventarioService
{
    private readonly IMovInventarioRepository _repository;

    public MovInventarioService(IMovInventarioRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Models.MovInventario> ObtenerMovimientos(
        DateTime? fechaInicio,
        DateTime? fechaFin,
        string? tipoMovimiento,
        string? nroDocumento)
    {
        return _repository.GetAll(fechaInicio, fechaFin, tipoMovimiento, nroDocumento);
    }

    public void RegistrarMovimiento(Models.MovInventario movimiento)
    {
        _repository.Insert(movimiento);
    }

    public void ActualizarMovimiento(Models.MovInventario movimiento)
    {
        _repository.Update(movimiento);
    }

    public void EliminarMovimiento(MovInventarioKey key)
    {
        _repository.Delete(key);
    }
}

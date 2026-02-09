using Dapper;
using System.Data;
using MovInventario.Application.Interfaces;
using MovInventario.Application.Models;
using Models = MovInventario.Application.Models;

namespace MovInventario.Infrastructure.Repositories;

public class MovInventarioRepository : IMovInventarioRepository
{
    private readonly IDbConnection _connection;

    public MovInventarioRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Models.MovInventario> GetAll(
        DateTime? fechaInicio,
        DateTime? fechaFin,
        string? tipoMovimiento,
        string? nroDocumento)
    {
        return _connection.Query<Models.MovInventario>(
            "SP_MOV_INVENTARIO_GET",
            new
            {
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                TipoMovimiento = tipoMovimiento,
                NroDocumento = nroDocumento
            },
            commandType: CommandType.StoredProcedure
        );
    }

    public void Insert(Models.MovInventario entity)
    {
        _connection.Execute(
            "SP_MOV_INVENTARIO_INSERT",
            new
            {
                COD_CIA = entity.CodCia,
                COMPANIA_VENTA_3 = entity.CompaniaVenta3,
                ALMACEN_VENTA = entity.AlmacenVenta,
                TIPO_MOVIMIENTO = entity.TipoMovimiento,
                TIPO_DOCUMENTO = entity.TipoDocumento,
                NRO_DOCUMENTO = entity.NroDocumento,
                COD_ITEM_2 = entity.CodItem2,
                CANTIDAD = entity.Cantidad,
                FECHA_TRANSACCION = entity.FechaTransaccion
            },
            commandType: CommandType.StoredProcedure
        );
    }

    public void Update(Models.MovInventario entity)
    {
        _connection.Execute(
            "SP_MOV_INVENTARIO_UPDATE",
            new
            {
                COD_CIA = entity.CodCia,
                COMPANIA_VENTA_3 = entity.CompaniaVenta3,
                ALMACEN_VENTA = entity.AlmacenVenta,
                TIPO_MOVIMIENTO = entity.TipoMovimiento,
                TIPO_DOCUMENTO = entity.TipoDocumento,
                NRO_DOCUMENTO = entity.NroDocumento,
                COD_ITEM_2 = entity.CodItem2,
                CANTIDAD = entity.Cantidad
            },
            commandType: CommandType.StoredProcedure
        );
    }

    public void Delete(MovInventarioKey key)
    {
        _connection.Execute(
            "SP_MOV_INVENTARIO_DELETE",
            new
            {
                COD_CIA = key.CodCia,
                COMPANIA_VENTA_3 = key.CompaniaVenta3,
                ALMACEN_VENTA = key.AlmacenVenta,
                TIPO_MOVIMIENTO = key.TipoMovimiento,
                TIPO_DOCUMENTO = key.TipoDocumento,
                NRO_DOCUMENTO = key.NroDocumento,
                COD_ITEM_2 = key.CodItem2
            },
            commandType: CommandType.StoredProcedure
        );
    }
}

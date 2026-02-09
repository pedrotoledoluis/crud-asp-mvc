CREATE PROCEDURE dbo.SP_MOV_INVENTARIO_GET
(
    @FechaInicio DATE = NULL,
    @FechaFin DATE = NULL,
    @TipoMovimiento VARCHAR(2) = NULL,
    @NroDocumento VARCHAR(50) = NULL
)
AS
BEGIN
    SELECT *
    FROM MOV_INVENTARIO
    WHERE
        (@FechaInicio IS NULL OR FECHA_TRANSACCION >= @FechaInicio)
    AND (@FechaFin IS NULL OR FECHA_TRANSACCION <= @FechaFin)
    AND (@TipoMovimiento IS NULL OR TIPO_MOVIMIENTO = @TipoMovimiento)
    AND (@NroDocumento IS NULL OR NRO_DOCUMENTO = @NroDocumento)
END

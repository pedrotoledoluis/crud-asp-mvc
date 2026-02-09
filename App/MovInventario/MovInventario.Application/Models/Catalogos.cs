namespace MovInventario.Application.Models
{    
    public static class Catalogos
    {
        public static readonly Dictionary<string, string> Companias = new()
        {
            { "00100", "Compañía Alpha S.A." },
            { "00200", "Compañía Beta S.A." },
            { "00300", "Compañía Gamma S.A." }
        };

        public static readonly Dictionary<string, string> CompaniasVenta = new()
        {
            { "CV001", "Ventas Nacionales" },
            { "CV002", "Ventas Internacionales" },
            { "CV003", "Ventas Directas" }
        };

        public static readonly Dictionary<string, string> Almacenes = new()
        {
            { "ALM001", "Almacén Central" },
            { "ALM002", "Almacén Norte" },
            { "ALM003", "Almacén Sur" },
            { "ALM004", "Almacén Este" }
        };

        public static readonly Dictionary<string, string> TiposMovimiento = new()
        {
            { "CL", "Compra Local" },
            { "IN", "Ingreso" },
            { "SA", "Salida" }
        };

        public static readonly Dictionary<string, string> TiposDocumento = new()
        {
            { "FA", "Factura" },
            { "GR", "Guía de Remisión" },
            { "NC", "Nota de Crédito" },
            { "OC", "Orden de Compra" }
        };

        public static readonly Dictionary<string, string> Items = new()
        {
            { "ITM001", "Laptop HP ProBook" },
            { "ITM002", "Monitor Dell 24 pulgadas" },
            { "ITM003", "Teclado Mecánico RGB" },
            { "ITM004", "Mouse Inalámbrico" },
            { "ITM005", "Disco SSD 1TB" }
        };
    }
}

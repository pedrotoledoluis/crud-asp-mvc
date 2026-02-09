using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovInventario.Application.Interfaces;
using MovInventario.Application.Models;

namespace MovInventario.Web.Controllers
{
    public class MovInventarioController : Controller
    {
        private readonly IMovInventarioService _service;

        public MovInventarioController(IMovInventarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Carga los catálogos dummy en ViewBag para los selects.
        /// </summary>
        private void CargarCatalogos()
        {
            ViewBag.Companias = new SelectList(Catalogos.Companias, "Key", "Value");
            ViewBag.CompaniasVenta = new SelectList(Catalogos.CompaniasVenta, "Key", "Value");
            ViewBag.Almacenes = new SelectList(Catalogos.Almacenes, "Key", "Value");
            ViewBag.TiposMovimiento = new SelectList(Catalogos.TiposMovimiento, "Key", "Value");
            ViewBag.TiposDocumento = new SelectList(Catalogos.TiposDocumento, "Key", "Value");
            ViewBag.Items = new SelectList(Catalogos.Items, "Key", "Value");
        }

        // LISTADO
        public IActionResult Index(
            DateTime? fechaInicio,
            DateTime? fechaFin,
            string? tipoMovimiento,
            string? nroDocumento,
            string? codItem2)
        {
            var data = _service.ObtenerMovimientos(
                fechaInicio, fechaFin, tipoMovimiento, nroDocumento);

            // Filtro adicional por Item (se aplica en memoria)
            if (!string.IsNullOrEmpty(codItem2))
                data = data.Where(m => m.CodItem2 == codItem2);

            return View(data);
        }

        // CREATE 
        public IActionResult Create()
        {
            CargarCatalogos();
            var model = new Application.Models.MovInventario
            {
                FechaTransaccion = DateTime.Today
            };
            return View(model);
        }

        // CREATE 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Application.Models.MovInventario model)
        {
            if (!ModelState.IsValid)
            {
                CargarCatalogos();
                return View(model);
            }

            _service.RegistrarMovimiento(model);
            return RedirectToAction(nameof(Index));
        }

        // EDIT 
        public IActionResult Edit(
            string codCia,
            string companiaVenta3,
            string almacenVenta,
            string tipoMovimiento,
            string tipoDocumento,
            string nroDocumento,
            string codItem2)
        {
            var data = _service.ObtenerMovimientos(null, null, tipoMovimiento, nroDocumento)
                .FirstOrDefault(m =>
                    m.CodCia == codCia &&
                    m.CompaniaVenta3 == companiaVenta3 &&
                    m.AlmacenVenta == almacenVenta &&
                    m.TipoDocumento == tipoDocumento &&
                    m.CodItem2 == codItem2);

            if (data == null)
                return NotFound();

            CargarCatalogos();
            return View(data);
        }

        // EDIT 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Application.Models.MovInventario model)
        {
            if (!ModelState.IsValid)
            {
                CargarCatalogos();
                return View(model);
            }

            _service.ActualizarMovimiento(model);
            return RedirectToAction(nameof(Index));
        }

        // DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(MovInventarioKey key)
        {
            _service.EliminarMovimiento(key);
            return RedirectToAction(nameof(Index));
        }
    }
}

using ModelLayer;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ofertas.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Index()
        {
            List<Producto> productos = ProductoService.getAll();
            return View(productos);
        }

        public ActionResult crear()
        {
            List<Marca> marcasLista = MarcaService.getAllMarcas();
            
            SelectList lista = new SelectList(marcasLista, "id_marca","descripcion");
            ViewBag.listaMarcas = lista;

            return View();
        }

        public JsonResult registrar(Producto producto)
        {
            if(productoValido(producto))
            {
                Marca marca =  MarcaService.getMarca((int)producto.id_marca);
                producto.Marca = marca;

                bool creado = false;
                try
                {
                    creado = ProductoService.crear(producto);
                }
                catch (Exception)
                {
                    return Json(new Respuesta { error = true, mensaje = "Ocurrió un error al crear el producto. Intente nuevamente" }, JsonRequestBehavior.AllowGet);
                }
                

                if(creado)
                {
                    return Json(new Respuesta { error = true, mensaje = "Producto creado exitosamente." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new Respuesta { error = true, mensaje = "Error al crear el producto, codigo existente" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new Respuesta{error = true, mensaje="Datos incompletos"}, JsonRequestBehavior.AllowGet);
            }
            
        }

        private bool productoValido(Producto producto)
        {
            if(producto.id_marca == null || producto.id_marca == 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(producto.codigo))
                return false;
            if (string.IsNullOrEmpty(producto.nombre))
                return false;

            return true;
        }
    }
}
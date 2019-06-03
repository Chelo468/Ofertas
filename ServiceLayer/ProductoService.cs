using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ProductoService
    {
        public static Producto getProducto(string codigo_producto)
        {
            using (OfertasEntities contexto = new OfertasEntities())
            {
                return contexto.Producto.Where(x => x.codigo == codigo_producto).FirstOrDefault();
            }                
        }

        public static List<Producto> getAll()
        {
            using(OfertasEntities contexto = new OfertasEntities())
            {
                return contexto.Producto.Include("Marca").ToList();
            }
        }

        public static bool crear(Producto producto)
        {
            try
            {
                using (OfertasEntities contexto = new OfertasEntities())
                {
                    Producto productoExistente = contexto.Producto.Where(x => x.codigo == producto.codigo).FirstOrDefault();

                    if (productoExistente != null)
                    {
                        return false;
                    }

                    contexto.Producto.Add(producto);

                    contexto.SaveChanges();
                }                  
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return true;
            
        }
    }
}

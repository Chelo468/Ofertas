using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class MarcaService
    {
        public static Marca getMarca(int id_marca)
        {
            using(OfertasEntities contexto = new OfertasEntities())
            {
                return contexto.Marca.Where(x => x.id_marca == id_marca).FirstOrDefault();
            }
            //OfertasEntities contexto = new OfertasEntities();

            
        }

        public static List<Marca> getAllMarcas()
        {
            using (OfertasEntities contexto = new OfertasEntities())
            {
                return contexto.Marca.ToList();
            }                
        }
    }
}

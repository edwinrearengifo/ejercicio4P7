using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConexionDB;
namespace Clases
{
    public class ListaIP
    {
        public IQueryable mostrarDireccionIP()
        {
            DBUsuariosDataContext db = new DBUsuariosDataContext();
            var listaDireccionesIP = from TB in db.listaIP
                          select TB;
            return listaDireccionesIP;
        }

        /*public void eliminar(int m)
        {
            DBUsuariosDataContext db = new DBUsuariosDataContext();
            var cSelect = (from x in db.listaIP
                           where x.str_ip == m
                           select x).Single();

            db.listaIP.DeleteOnSubmit((listaIP)cSelect);
            db.SubmitChanges();
        }*/

    }
}

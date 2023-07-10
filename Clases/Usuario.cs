using ConexionDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{

    public class Usuario
    {
        public Usuario() { }

        public IQueryable mostrarUsuario()
        {
            DBUsuariosDataContext db = new DBUsuariosDataContext();
            var listaUsuario = from TB in db.usuario
                                select TB;
            return listaUsuario;
        }

        public void eliminar(int m)
        {
            DBUsuariosDataContext db = new DBUsuariosDataContext();
            var cSelect = (from x in db.usuario
                           where x.int_id == m
                           select x).Single();

            db.usuario.DeleteOnSubmit((usuario)cSelect);
            db.SubmitChanges();
        }

        public void insertar(string status, DateTime fecha, string nombre, string direccion, string departamento, int telefono)
        {
            DBUsuariosDataContext db = new DBUsuariosDataContext();
            usuario user = new usuario();
            user.str_status = status;
            user.dat_fecha = fecha;
            user.str_nombre = nombre;
            user.str_direccion = direccion;
            user.str_departamento = departamento;
            user.int_telefono = telefono;

            db.usuario.InsertOnSubmit(user); // Esta linea cambia el objetos
            db.SubmitChanges(); // reflejado EN SQL
        }

        public void guardar(int id, string status, DateTime fecha, string nombre, string direccion, string departamento, int telefono)
        {
            DBUsuariosDataContext db = new DBUsuariosDataContext();
            var query = (from a in db.usuario
                         where a.int_id == id
                         select a).FirstOrDefault();
            query.str_status = status;
            query.dat_fecha = fecha;
            query.str_nombre = nombre;
            query.str_direccion=direccion;
            query.str_departamento=departamento;
            query.int_telefono=telefono;
            db.SubmitChanges();
        }
    }
}

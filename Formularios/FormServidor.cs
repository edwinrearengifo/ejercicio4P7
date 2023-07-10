using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace Formularios
{
    public partial class FormServidor : Form
    {
        Usuario user = new Usuario();
        private bool Editar = false;
        private string idUsuario = null;

        public FormServidor()
        {
            InitializeComponent();
        }

        private void FormServidor_Load(object sender, EventArgs e)
        {
            mostrarUsuarios();
            txtID.Enabled = false;
            txtEstado.Enabled = false;
            txtFecha.Enabled = false;
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtDepartamento.Enabled = false;
            txtTelefono.Enabled = false;

            btnGuardar.Enabled = false;
            
            btnLimpiar.Enabled = false;
            btnInsertar.Enabled = false;
            dataGridView2.Enabled = false;
        }

        private void mostrarUsuarios()
        {
            Usuario user = new Usuario();
            dataGridView1.DataSource = user.mostrarUsuario();
        }

        public void mostrarDireccionesIP()
        {
            ListaIP listaIP = new ListaIP();
            dataGridView2.DataSource = listaIP.mostrarDireccionIP();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                user.eliminar(int.Parse(dataGridView1.CurrentRow.Cells["int_id"].Value.ToString()));
                MessageBox.Show("Borrado exitosamente");
                mostrarUsuarios();
            }
            else
            {
                MessageBox.Show("Seleccione el elemento que desea borrar");
            };
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                if (Editar == true)
                btnGuardar.Enabled = true;
                txtEstado.Text = dataGridView1.CurrentRow.Cells["str_status"].Value.ToString();
                txtFecha.Text = dataGridView1.CurrentRow.Cells["dat_fecha"].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells["str_nombre"].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells["str_direccion"].Value.ToString();
                txtDepartamento.Text = dataGridView1.CurrentRow.Cells["str_departamento"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["int_telefono"].Value.ToString();

                idUsuario  = dataGridView1.CurrentRow.Cells["int_id"].Value.ToString();
                txtID.Text = dataGridView1.CurrentRow.Cells["int_id"].Value.ToString();
                txtEstado.Enabled = true;
                txtFecha.Enabled = true;
                txtNombre.Enabled = true;
                txtDireccion.Enabled = true;
                txtDepartamento.Enabled = true;
                txtTelefono.Enabled = true;
                btnLimpiar.Enabled = true;
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            txtEstado.Enabled = true;
            txtFecha.Enabled = true;
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtDepartamento.Enabled = true;
            txtTelefono.Enabled = true;
            btnLimpiar.Enabled = true;
            btnInsertar.Enabled = true;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            btnNuevoRegistro.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtEstado.Text == "" || txtFecha.Text == "" || txtNombre.Text == "" || txtDireccion.Text == "" || txtDepartamento.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("El usuario que desea actualizar no existe");
            }
            else
            {
                user.guardar(int.Parse(txtID.Text), txtEstado.Text, DateTime.Parse(txtFecha.Text), txtNombre.Text, txtDireccion.Text, txtDepartamento.Text, int.Parse(txtTelefono.Text));
                MessageBox.Show("Usuario actualizado exitosamente");
                mostrarUsuarios();
                limpiar();
                btnGuardar.Enabled = false;
                txtNombre.Enabled = false;
                txtEstado.Enabled = false;
                txtDireccion.Enabled = false;
                txtDepartamento.Enabled = false;
                txtFecha.Enabled = false;
                txtTelefono.Enabled = false;
                btnLimpiar.Enabled = false;
            }
        }

        public void limpiar()
        {
            txtID.Text = " ";
            txtEstado.Text = " ";
            txtFecha.Text = " ";
            txtDireccion.Text = " ";
            txtDepartamento.Text = " ";
            txtTelefono.Text = " ";
            txtNombre.Text = " ";
            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtEstado.Text == "" || txtFecha.Text == "" || txtNombre.Text == "" || txtDireccion.Text == "" || txtDepartamento.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("Escriba el precio y el nombre del producto");
            }
            else
            {
                user.insertar(txtEstado.Text, DateTime.Parse(txtFecha.Text), txtNombre.Text, txtDireccion.Text, txtDepartamento.Text, int.Parse(txtTelefono.Text));
                MessageBox.Show("Usuario ingresado exitosamente");
                mostrarUsuarios();

                btnNuevoRegistro.Enabled = true;
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = true;
                txtNombre.Enabled = false;
                txtEstado.Enabled = false;
                txtDireccion.Enabled = false;
                txtDepartamento.Enabled = false;
                txtFecha.Enabled = false;
                txtTelefono.Enabled = false;
                
                txtNombre.Text = " ";
                txtEstado.Text = " ";
                txtDepartamento.Text = " ";
                txtDireccion.Text= " ";
                txtFecha.Text = " ";
                txtTelefono.Text = " ";

                btnLimpiar.Enabled = false;
                btnInsertar.Enabled = false;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnMostrarLista_Click(object sender, EventArgs e)
        {
            mostrarDireccionesIP();
        }

    }
}

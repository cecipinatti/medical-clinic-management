using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoClinica
{
    public partial class PacListado : Form
    {
        SqlConnection ConexionPAL;
        public PacListado(SqlConnection Conexion)
        {
            InitializeComponent();
            ConexionPAL = Conexion;
        }
        private void PacListado_Load(object sender, EventArgs e)
        {
            cmbBuscar.Items.Add("Nombre y Apellido");
            cmbBuscar.Items.Add("DNI");
            cmbBuscar.SelectedIndex = 0;
            txtBuscar.Focus();
            CargarPacientes();
        }

        //MOSTRAR REGISTROS (HASTA 20)
        private void CargarPacientes()
        {
            string columnaSeleccionada = "";

            if (cmbBuscar.SelectedIndex == 0)
            {
                columnaSeleccionada = "Nombre + ' ' + Apellido";
            }
            else if (cmbBuscar.SelectedIndex == 1)
            {
                columnaSeleccionada = "DNI";
            }

            ConexionPAL.Open();
            string cadena = "SELECT TOP 20 CONCAT(Nombre, ' ' , Apellido) AS 'Nombre y Apellido', DNI, FechaNac AS 'Fecha de Nacimiento', Tel AS 'Teléfono', Correo FROM Pacientes WHERE " +
                columnaSeleccionada + " LIKE '%' + @Buscar + '%'";

            SqlCommand comando = new SqlCommand(cadena, ConexionPAL);
            comando.Parameters.AddWithValue("@Buscar", txtBuscar.Text);

            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataSet conjunto = new DataSet();

            adaptador.Fill(conjunto, "Pacientes");
            lista.DataSource = conjunto.Tables["Pacientes"];
            ConexionPAL.Close();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarPacientes();

        }

        //ELIMINAR PACIENTE(S)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lista.SelectedRows.Count > 0)
            {
                int cantSeleccionada = lista.SelectedRows.Count;
                string mensaje;

                if (cantSeleccionada > 1)
                {
                    mensaje = "¿Estás seguro de eliminar los " + cantSeleccionada + " pacientes seleccionados?";
                }
                else
                {
                    mensaje = "¿Estás seguro de eliminar el paciente seleccionado?";
                }
                DialogResult resultado = MessageBox.Show(mensaje, "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        ConexionPAL.Open();
                        foreach (DataGridViewRow fila in lista.SelectedRows)
                        {
                            string dni = fila.Cells["DNI"].Value.ToString();
                            string cadena = "DELETE FROM Pacientes WHERE DNI = '" + dni + "'";

                            SqlCommand comand = new SqlCommand(cadena, ConexionPAL);
                            comand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Los pacientes se han eliminado correctamente.", "Pacientes eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ConexionPAL.Close();
                        CargarPacientes();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al eliminar los pacientes. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona uno o más pacientes para eliminar.", "Pacientes no seleccionados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //ACTUALIZAR PACIENTE
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lista.SelectedRows.Count == 1)
            {
                DataGridViewRow filaSeleccionada = lista.SelectedRows[0];

                string dni = filaSeleccionada.Cells["DNI"].Value.ToString();

                PacActualizar PAA = new PacActualizar(ConexionPAL, dni);
                PAA.ShowDialog();
                CargarPacientes();
            }
            else if (lista.SelectedRows.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una única fila.", "Selección inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Selecciona un paciente para actualizar.", "Pacientes no seleccionados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        // NUEVO PACIENTE
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PacNuevo PAN = new PacNuevo(ConexionPAL);
            PAN.Show();
        }

        private void PacListado_DoubleClick(object sender, EventArgs e)
        {
            lista.ClearSelection();
        }
    }
}

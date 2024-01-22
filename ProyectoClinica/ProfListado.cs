using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoClinica
{
    public partial class ProfListado : Form
    {
        SqlConnection ConexionPRL;
        public ProfListado(SqlConnection Conexion)
        {
            InitializeComponent();
            ConexionPRL = Conexion;
        }

        //MOSTRAR REGISTROS (HASTA 20)
        private void CargarProfesionales()
        {
            // Obtiene la columna seleccionada en el ComboBox
            string columnaSeleccionada = "";
            if (cmbBuscar.SelectedIndex == 0)
            {
                columnaSeleccionada = "Especialidad";
            }
            else if (cmbBuscar.SelectedIndex == 1)
            {
                columnaSeleccionada = "Nombre + ' ' + Apellido";
            }
            else if (cmbBuscar.SelectedIndex == 2)
            {
                columnaSeleccionada = "DNI";
            }

            ConexionPRL.Open();
            string cadena = "SELECT TOP 20 CONCAT(Nombre, ' ' , Apellido) AS 'Nombre y Apellido', DNI, Especialidad, DiaSemana AS 'Días de Atención', HoraInicio AS 'Hora inicio', HoraFin AS 'Hora fin', atencionesHora AS 'Atenciones / min' FROM Profesionales WHERE " +
                columnaSeleccionada + " LIKE '%' + @Buscar + '%'"; 

            SqlCommand comando = new SqlCommand(cadena, ConexionPRL);
            comando.Parameters.AddWithValue("@Buscar", txtBuscar.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataSet conjunto = new DataSet();
            adaptador.Fill(conjunto, "Profesionales");

            // Carga los datos en el control DataGridView
            lista.DataSource = conjunto.Tables["Profesionales"];
            ConexionPRL.Close();

            lista.Columns["Días de atención"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ELIMINAR PROFESIONAL(ES)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lista.SelectedRows.Count > 0)
            {
                int cantSeleccionada = lista.SelectedRows.Count;
                string mensaje;

                if (cantSeleccionada > 1)
                {
                    mensaje = "¿Estás seguro de eliminar los " + cantSeleccionada + " profesionales seleccionados?";
                }
                else
                {
                    mensaje = "¿Estás seguro de eliminar el profesional seleccionado?";
                }
                DialogResult resultado = MessageBox.Show(mensaje, "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        ConexionPRL.Open();
                        foreach (DataGridViewRow fila in lista.SelectedRows)
                        {
                            string dni = fila.Cells["DNI"].Value.ToString();
                            string cadena = "DELETE FROM Profesionales WHERE DNI = '" + dni + "'";

                            SqlCommand comand = new SqlCommand(cadena, ConexionPRL);
                            comand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Los profesionales se han eliminado correctamente.", "Profesionales eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ConexionPRL.Close();
                        CargarProfesionales();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al eliminar los profesionales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona uno o más profesionales para eliminar.", "Profesionales no seleccionados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //NUEVO PROFESIONAL
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Abre el formulario para agregar un nuevo profesional
            ProfNuevo PRN = new ProfNuevo(ConexionPRL);
            PRN.Show();
        }
        private void ProfListado_Load(object sender, EventArgs e)
        {
            cmbBuscar.Items.Add("Especialidad");
            cmbBuscar.Items.Add("Nombre y Apellido");
            cmbBuscar.Items.Add("DNI");
            cmbBuscar.SelectedIndex = 0;
            txtBuscar.Focus();
            CargarProfesionales();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Realiza una búsqueda cada vez que se modifica el texto en el campo de búsqueda
            CargarProfesionales();
        }

        private void ProfListado_DoubleClick(object sender, EventArgs e)
        {
            lista.ClearSelection();
        }

        //ACTUALIZAR PROFESIONAL
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lista.SelectedRows.Count == 1)
            {
                // Abre el formulario para actualizar un profesional si se selecciona una única fila
                DataGridViewRow filaSeleccionada = lista.SelectedRows[0];
                string dni = filaSeleccionada.Cells["DNI"].Value.ToString();
                ProfActualizar PRA = new ProfActualizar(ConexionPRL, dni);
                PRA.ShowDialog();
                CargarProfesionales();
            }
            else if (lista.SelectedRows.Count > 1)
            {
                MessageBox.Show("Debe seleccionar una única fila.", "Selección inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Selecciona un Profesional para actualizar.", "Profesionales no seleccionados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

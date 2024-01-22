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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoClinica
{
    public partial class CitaListado : Form
    {
        SqlConnection ConexionCL;
        public CitaListado(SqlConnection Conexion)
        {
            InitializeComponent();
            ConexionCL = Conexion;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CitaListado_Load(object sender, EventArgs e)
        {
            cmbBuscar.Items.Add("Especialidad");
            cmbBuscar.Items.Add("Nombre y Apellido");
            cmbBuscar.Items.Add("DNI");
            cmbBuscar.SelectedIndex = 0;
            rbtProximas.Checked = true;
            dtpSeleccion.Enabled = false;
            txtBuscar.Focus();
            CargarCitas(); // Carga las citas iniciales en la lista
        }

        private void CargarCitas()
        {
            // Realiza la carga de las citas en la lista según los filtros seleccionados
            //BÚSQUEDA SEGÚN PROFESIONAL
            string columnaSeleccionada = "";

            if (cmbBuscar.SelectedIndex == 0)
            {
                columnaSeleccionada = "Profesionales.Especialidad";
            }
            else if (cmbBuscar.SelectedIndex == 1)
            {
                columnaSeleccionada = "Profesionales.Nombre + ' ' + Profesionales.Apellido";
            }
            else if (cmbBuscar.SelectedIndex == 2)
            {
                columnaSeleccionada = "Profesionales.DNI";
            }

            string cadena = "SELECT CONCAT(Pacientes.nombre, ' ', Pacientes.Apellido) AS Paciente, " +
                            "CONCAT(Profesionales.Nombre, ' ', Profesionales.Apellido) AS Profesional, " +
                            "Profesionales.Especialidad AS Especialidad, fecha, hora FROM Citas " +
                            "INNER JOIN Pacientes ON Pacientes.IDPaciente = Citas.PacienteID " +
                            "INNER JOIN Profesionales ON Profesionales.IDProfesional = Citas.ProfesionalID";

            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                cadena += " WHERE " + columnaSeleccionada + " LIKE '%" + txtBuscar.Text + "%'";
            }
            
            //BÚSQUEDA SEGÚN FECHA
            if (rbtAntiguas.Checked)
            {
                cadena += " AND fecha < GETDATE()";
            }
            else if (rbtProximas.Checked)
            {
                cadena += " AND fecha >= CONVERT(date, GETDATE())";
            }
            else if (rbtSeleccion.Checked)
            {
                DateTime fechaSeleccionada = dtpSeleccion.Value.Date;
                cadena += " AND fecha = '" + fechaSeleccionada.ToString("yyyy-MM-dd") + "'";
            }

            SqlCommand comando = new SqlCommand(cadena, ConexionCL);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataSet conjunto = new DataSet();
            adaptador.Fill(conjunto, "Citas");
            lista.DataSource = conjunto.Tables["Citas"];
            
            ConexionCL.Close();
        }

        //AGENDAR NUEVA CITA
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Abre el formulario para agregar una nueva cit
            CitaNuevo CN = new CitaNuevo(ConexionCL);
            CN.Show();
        }

        //ELIMINAR CITAS
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lista.SelectedRows.Count > 0)
            {
                int cantSeleccionada = lista.SelectedRows.Count;
                string mensaje;

                if (cantSeleccionada > 1)
                {
                    mensaje = "¿Estás seguro de eliminar las " + cantSeleccionada + " citas seleccionadas?";
                }
                else
                {
                    mensaje = "¿Estás seguro de eliminar la cita seleccionada?";
                }
                DialogResult resultado = MessageBox.Show(mensaje, "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        ConexionCL.Open();
                        foreach (DataGridViewRow fila in lista.SelectedRows)
                        {
                            string paciente = fila.Cells["Paciente"].Value.ToString();
                            string profesional = fila.Cells["Profesional"].Value.ToString();

                            string consultaPaciente = "SELECT IDPaciente FROM Pacientes WHERE Nombre + ' ' + Apellido='" + paciente + "'";
                            SqlCommand commandPaciente = new SqlCommand(consultaPaciente, ConexionCL);
                            int pacienteID = (int)commandPaciente.ExecuteScalar();

                            string consultaProfesional = "SELECT IDProfesional FROM Profesionales WHERE Nombre + ' ' + Apellido='" + profesional + "'";
                            SqlCommand commandProfesional = new SqlCommand(consultaProfesional, ConexionCL);
                            int profesionalID = (int)commandProfesional.ExecuteScalar();

                            DateTime fechaCita = Convert.ToDateTime(fila.Cells["fecha"].Value);
                            TimeSpan horaCita = TimeSpan.Parse(fila.Cells["hora"].Value.ToString());

                            string cadena = "DELETE FROM Citas WHERE ProfesionalID = " + profesionalID + " AND PacienteID = " + pacienteID +
                                " AND Fecha = '" + fechaCita.ToString("yyyy-MM-dd") + "' AND Hora = '" + horaCita.ToString(@"hh\:mm") + "'";

                            SqlCommand comand = new SqlCommand(cadena, ConexionCL);
                            comand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Las citas se han eliminado correctamente.", "Citas eliminadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ConexionCL.Close();
                        CargarCitas();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al eliminar las citas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una o más citas para eliminar.", "Citas no seleccionadas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CitaListado_DoubleClick(object sender, EventArgs e)
        {
            lista.ClearSelection();
        }

        //ACTUALIZAR CITAS
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Abre el formulario de edición de citas para la cita seleccionada en la lista
            if (lista.SelectedRows.Count == 1)
            {
                DataGridViewRow filaSeleccionada = lista.SelectedRows[0];

                // Obtener los datos de la fila seleccionada
                string paciente = filaSeleccionada.Cells["Paciente"].Value.ToString();
                string profesional = filaSeleccionada.Cells["Profesional"].Value.ToString();
                DateTime fechaCita = Convert.ToDateTime(filaSeleccionada.Cells["fecha"].Value);
                TimeSpan horaCita = TimeSpan.Parse(filaSeleccionada.Cells["hora"].Value.ToString());

                // Pasar los datos al formulario de edición
                CitaActualizar CA = new CitaActualizar(ConexionCL, paciente, profesional, fechaCita, horaCita);
                CA.ShowDialog();

                CargarCitas();
            }
            else if (lista.SelectedRows.Count > 2)
            {
                MessageBox.Show("Selecciona una sola cita para editar.", "Selección múltiple", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                MessageBox.Show("Selecciona una cita para actualizar.", "Citas no seleccionadas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rbtAntiguas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAntiguas.Checked)
            {
                // Actualiza la lista de citas al seleccionar la opción de citas antiguas
                CargarCitas();
            }
        }

        private void rbtProximas_CheckedChanged(object sender, EventArgs e)
        {
            // Actualiza la lista de citas al seleccionar la opción de citas próximas
            if (rbtProximas.Checked)
            {
                CargarCitas();
            }
        }

        private void dtpSeleccion_ValueChanged(object sender, EventArgs e)
        {
            // Actualiza la lista de citas al cambiar la fecha seleccionada
            CargarCitas();
        }

        private void rbtSeleccion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtSeleccion.Checked)
            {
                dtpSeleccion.Enabled = true;
                // Actualiza la lista de citas al seleccionar la opción de selección de fecha
                CargarCitas();
            }
            else
            {
                dtpSeleccion.Enabled = false;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Actualiza la lista de citas al cambiar el texto de búsqueda
            CargarCitas();
        }
    }
}

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
    public partial class CitaNuevo : Form
    {
        SqlConnection ConexionCN;
        public CitaNuevo(SqlConnection ConexionCL)
        {
            InitializeComponent();
            ConexionCN = ConexionCL;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CitaNuevo_Load(object sender, EventArgs e)
        {
            Restringir();
            cmbBuscar.Items.Add("Especialidad");
            cmbBuscar.Items.Add("Nombre y Apellido");
            cmbBuscar.Items.Add("DNI");
            cmbBuscar.SelectedIndex = 0;
            txtBuscar.Focus();
            dtpFecha.MinDate = DateTime.Now;
        }

        public void Restringir()
        {
            dtpFecha.Enabled = false;
            cmbHora.Enabled = false;
            txtBuscar.Enabled = false;
            cmbBuscar.Enabled = false;
            btnAgendar.Enabled = false;
        }

        //PACIENTE
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                MessageBox.Show("Búsqueda inválida.\nPor favor, ingresar el DNI Paciente.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbnPaciente.Text = " ";
                Restringir();
            }
            else if (txtDNI.Text != "")
            {
                ConexionCN.Open();
                int DNI = Convert.ToInt32(txtDNI.Text);
                string cadena = "SELECT Nombre + ' ' + Apellido AS NombreCompleto FROM Pacientes WHERE (DNI=" + DNI + ")";

                SqlCommand comand = new SqlCommand(cadena, ConexionCN);

                SqlDataReader Leer = comand.ExecuteReader();
                if (Leer.Read())
                {
                    MessageBox.Show("Se encontró un usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbnPaciente.Text = Leer["NombreCompleto"].ToString();
                    txtBuscar.Enabled = true;
                    cmbBuscar.Enabled = true;
                    ConexionCN.Close();
                }
                else
                {
                    MessageBox.Show("Paciente inexistente.\nPor favor, grabe sus datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbnPaciente.Text = " ";
                    btnGrabar.Focus();
                    Restringir();
                }
                ConexionCN.Close();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            PacNuevo PAN = new PacNuevo(ConexionCN);
            PAN.Show();
        }

        //PROFESIONAL
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
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

            ConexionCN.Open();
            string cadena = "SELECT TOP 20 CONCAT(Nombre, ' ' , Apellido) AS 'Nombre y Apellido', DNI, Especialidad, DiaSemana AS 'Días de Atención', HoraInicio AS 'Hora inicio', HoraFin AS 'Hora fin', atencionesHora AS 'Atenciones / min' FROM Profesionales WHERE " +
                columnaSeleccionada + " LIKE '%' + @Buscar + '%'";

            SqlCommand comando = new SqlCommand(cadena, ConexionCN);
            comando.Parameters.AddWithValue("@Buscar", txtBuscar.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataSet conjunto = new DataSet();
            adaptador.Fill(conjunto, "Profesionales");
            lista.DataSource = conjunto.Tables["Profesionales"];
            ConexionCN.Close();

            lista.Columns["Días de atención"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void lista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtpFecha.Enabled = true;
                DataGridViewRow row = lista.Rows[e.RowIndex];
                lbnProfesional.Text = row.Cells["Nombre y Apellido"].Value.ToString();
            }
        }

        // Verifica si el día seleccionado es un día laboral para el profesional
        // y habilita los horarios disponibles en consecuencia.
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFecha.Value;
            string nombreDia = fechaSeleccionada.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));

            if (lista.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = lista.SelectedRows[0];
                string cadenaValores = filaSeleccionada.Cells["Días de atención"].Value.ToString().ToLower();
                string[] valores = cadenaValores.Split(' ');
                bool esDiaLaboral = false;

                foreach (string valor in valores)
                {
                    if (valor == nombreDia)
                    {
                        esDiaLaboral = true;
                        break;
                    }
                }
                if (esDiaLaboral)
                {
                    horarioDisponible();
                }
                else
                {
                    MessageBox.Show($"Registro inválido.\nEl profesional no trabaja el día {nombreDia}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbHora.Enabled = false;
                    lbnTurnos.Text = " ";
                    //btnAgendar.Enabled = false;
                }
            }
        }

        // Método que calcula los horarios disponibles para la fecha y profesional seleccionados
        // y los muestra en el control ComboBox "cmbHora".
        public void horarioDisponible()
        {
            DataGridViewRow filaSeleccionada = lista.SelectedRows[0];

            string horaInicioStr = filaSeleccionada.Cells["Hora Inicio"].Value.ToString();
            string horaFinStr = filaSeleccionada.Cells["Hora Fin"].Value.ToString();
            string atencionesHoraStr = filaSeleccionada.Cells["Atenciones / min"].Value.ToString();

            TimeSpan horaInicio = TimeSpan.Parse(horaInicioStr);
            TimeSpan horaFin = TimeSpan.Parse(horaFinStr);
            int atencionesHora = Convert.ToInt32(atencionesHoraStr);

            int duracionTotalMinutos = (int)(horaFin - horaInicio).TotalMinutes;
            int atencionesPorHora = atencionesHora;
            int cantidadIntervalos = duracionTotalMinutos / atencionesPorHora;

            DateTime fechaSeleccionada = dtpFecha.Value;
            string fechaFormateada = fechaSeleccionada.ToString("yyyy-MM-dd");

            ConexionCN.Open();
            string consulta = "SELECT Hora FROM citas where fecha = '" + fechaFormateada + "'";
            SqlCommand command = new SqlCommand(consulta, ConexionCN);
            cmbHora.Items.Clear();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<TimeSpan> horariosOcupados = new List<TimeSpan>();
                while (reader.Read())
                {
                    TimeSpan hora = reader.GetTimeSpan(reader.GetOrdinal("Hora"));
                    horariosOcupados.Add(hora);
                }

                for (int i = 0; i < cantidadIntervalos; i++)
                {
                    TimeSpan intervalo = horaInicio.Add(TimeSpan.FromMinutes(i * atencionesPorHora));
                    string intervaloStr = intervalo.ToString("hh\\:mm");
                    if (!horariosOcupados.Contains(intervalo))
                    {
                        cmbHora.Items.Add(intervaloStr);
                    }
                }
                if (cmbHora.Items.Count > 0)
                {
                    lbnTurnos.Text = "TURNOS DISPONIBLES";
                    cmbHora.Enabled = true;
                }
                else
                {
                    lbnTurnos.Text = "TURNOS AGOTADOS";
                    cmbHora.Enabled = false;
                }
            }
            ConexionCN.Close();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if (lbnPaciente.Text == " " || lbnProfesional.Text == " " || lbnFecha.Text == " " || lbnHora.Text == " ")
            {
                MessageBox.Show("Registro inválido.\nPor favor completar los datos en los campos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    ConexionCN.Open();
                    string paciente = lbnPaciente.Text;
                    string profesional = lbnProfesional.Text;
                    string fecha = lbnFecha.Text;
                    string hora = lbnHora.Text;

                    string consultaPaciente = "SELECT IDPaciente FROM Pacientes WHERE Nombre + ' ' + Apellido='" + paciente + "'";
                    SqlCommand commandPaciente = new SqlCommand(consultaPaciente, ConexionCN);
                    int pacienteID = (int)commandPaciente.ExecuteScalar();

                    string consultaProfesional = "SELECT IDProfesional FROM Profesionales WHERE Nombre + ' ' + Apellido='" + profesional + "'";
                    SqlCommand commandProfesional = new SqlCommand(consultaProfesional, ConexionCN);
                    int profesionalID = (int)commandProfesional.ExecuteScalar();

                    string cadena = "INSERT into Citas (ProfesionalID, PacienteID, Fecha, Hora) values" +
                        " ('" + profesionalID + "','" + pacienteID + "','" + fecha + "','" + hora + "')";

                    SqlCommand comando = new SqlCommand(cadena, ConexionCN);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("La cita se registró correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConexionCN.Close();
                    this.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("No se pudo agendar la cita", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                finally
                {
                    ConexionCN.Close();
                }
            }
        }

        private void cmbHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbnHora.Text = cmbHora.SelectedItem.ToString();
            lbnFecha.Text = dtpFecha.Value.ToString("yyyy-MM-dd");
            btnAgendar.Enabled = true;
        }
    }
}

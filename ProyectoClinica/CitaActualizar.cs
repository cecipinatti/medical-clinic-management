using System;
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

namespace ProyectoClinica
{
    public partial class CitaActualizar : Form
    {
        SqlConnection ConexionCA;
        public CitaActualizar(SqlConnection ConexionCL, string paciente, string profesional, DateTime fechaCita, TimeSpan horaCita)
        {
            InitializeComponent();
            ConexionCA = ConexionCL;

            Restringir();
            cmbBuscar.Items.Add("Especialidad");
            cmbBuscar.Items.Add("Nombre y Apellido");
            cmbBuscar.Items.Add("DNI");
            cmbBuscar.SelectedIndex = 0;
            txtBuscar.Enabled = true;
            cmbBuscar.Enabled = true;
            dtpFecha.MinDate = DateTime.Now;

            try
            {
                ConexionCA.Open();
                string cadena = "SELECT CONCAT(Pacientes.nombre, ' ', Pacientes.Apellido) AS Paciente, Pacientes.DNI, " +
                                "CONCAT(Profesionales.Nombre, ' ', Profesionales.Apellido) AS Profesional, " +
                                "Profesionales.Especialidad AS Especialidad, fecha, hora " +
                                "FROM Citas " +
                                "INNER JOIN Pacientes ON Pacientes.IDPaciente = Citas.PacienteID " +
                                "INNER JOIN Profesionales ON Profesionales.IDProfesional = Citas.ProfesionalID " +
                                "WHERE Pacientes.nombre + ' ' + Pacientes.Apellido = @Paciente " +
                                "AND fecha = @FechaCita " +
                                "AND hora = @HoraCita";

                SqlCommand comand = new SqlCommand(cadena, ConexionCA);
                comand.Parameters.AddWithValue("@Paciente", paciente);
                comand.Parameters.AddWithValue("@Profesional", profesional);
                comand.Parameters.AddWithValue("@FechaCita", fechaCita.Date);
                comand.Parameters.AddWithValue("@HoraCita", horaCita);

                SqlDataReader Leer = comand.ExecuteReader();
                if (Leer.Read())
                {
                    txtDNI.Text = Leer["DNI"].ToString();
                    lbnPaciente.Text = Leer["Paciente"].ToString();
                    lbnProfesional.Text = Leer["Profesional"].ToString();
                    DateTime fecha = Convert.ToDateTime(Leer["fecha"]);
                    lbnFecha.Text = fecha.ToString("dd/MM/yyyy");
                    lbnHora.Text = Leer["hora"].ToString();
                }
                Leer.Close();
                ConexionCA.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("No se pudo abrir los registros.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                ConexionCA.Close();
            }
        }


        //public void Verificar()
        //{
        //    ConexionCA.Open();
        //    string paciente = fila.Cells["Paciente"].Value.ToString();
        //    string profesional = fila.Cells["Profesional"].Value.ToString();

        //    string consultaPaciente = "SELECT IDPaciente FROM Pacientes WHERE Nombre + ' ' + Apellido='" + paciente + "'";
        //    SqlCommand commandPaciente = new SqlCommand(consultaPaciente, ConexionCA);
        //    int pacienteID = (int)commandPaciente.ExecuteScalar();

        //    string consultaProfesional = "SELECT IDProfesional FROM Profesionales WHERE Nombre + ' ' + Apellido='" + profesional + "'";
        //    SqlCommand commandProfesional = new SqlCommand(consultaProfesional, ConexionCA);
        //    int profesionalID = (int)commandProfesional.ExecuteScalar();

        //    DateTime fechaCita = Convert.ToDateTime(fila.Cells["fecha"].Value);
        //    TimeSpan horaCita = TimeSpan.Parse(fila.Cells["hora"].Value.ToString());

        //    string cadena = "DELETE FROM Citas WHERE ProfesionalID = " + profesionalID + " AND PacienteID = " + pacienteID +
        //        " AND Fecha = '" + fechaCita.ToString("yyyy-MM-dd") + "' AND Hora = '" + horaCita.ToString(@"hh\:mm") + "'";

        //    SqlCommand comand = new SqlCommand(cadena, ConexionCA);
        //    comand.ExecuteNonQuery();
        //    ConexionCA.Close();
        //}

        public void Restringir()
        {
            dtpFecha.Enabled = false;
            cmbHora.Enabled = false;
            txtBuscar.Enabled = false;
            cmbBuscar.Enabled = false;
            btnGrabar.Enabled = false;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ACTUALIZAR CITA (ERROR: SÓLO FECHA Y HORA)
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (lbnPaciente.Text == " " || lbnProfesional.Text == " " || lbnFecha.Text == " " || lbnHora.Text == " ")
            {
                MessageBox.Show("Registro inválido.\nPor favor completar los datos en los campos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    ConexionCA.Open();
                    string paciente = lbnPaciente.Text;
                    string profesional = lbnProfesional.Text;
                    string fecha = lbnFecha.Text;
                    string hora = lbnHora.Text;

                    string consultaPaciente = "SELECT IDPaciente FROM Pacientes WHERE Nombre + ' ' + Apellido='" + paciente + "'";
                    SqlCommand commandPaciente = new SqlCommand(consultaPaciente, ConexionCA);
                    int pacienteID = (int)commandPaciente.ExecuteScalar();

                    string consultaProfesional = "SELECT IDProfesional FROM Profesionales WHERE Nombre + ' ' + Apellido='" + profesional + "'";
                    SqlCommand commandProfesional = new SqlCommand(consultaProfesional, ConexionCA);
                    int profesionalID = (int)commandProfesional.ExecuteScalar();

                    string cadena = "UPDATE Citas SET Fecha = @Fecha, Hora = @Hora WHERE ProfesionalID = @ProfesionalID AND PacienteID = @PacienteID";

                    SqlCommand comando = new SqlCommand(cadena, ConexionCA);
                    comando.Parameters.AddWithValue("@Fecha", fecha);
                    comando.Parameters.AddWithValue("@Hora", hora);
                    comando.Parameters.AddWithValue("@ProfesionalID", profesionalID);
                    comando.Parameters.AddWithValue("@PacienteID", pacienteID);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("La cita se actualizó correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ConexionCA.Close();
                    this.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("No se pudo agendar la cita", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                finally
                {
                    ConexionCA.Close();
                }
            }
        }

        //ACTUALIZAR PACIENTE
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
                ConexionCA.Open();
                int DNI = Convert.ToInt32(txtDNI.Text);
                string cadena = "SELECT Nombre + ' ' + Apellido AS NombreCompleto FROM Pacientes WHERE (DNI=" + DNI + ")";

                SqlCommand comand = new SqlCommand(cadena, ConexionCA);

                SqlDataReader Leer = comand.ExecuteReader();
                if (Leer.Read())
                {
                    MessageBox.Show("Se encontró un usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbnPaciente.Text = Leer["NombreCompleto"].ToString();
                    txtBuscar.Enabled = true;
                    cmbBuscar.Enabled = true;
                    ConexionCA.Close();
                }
                else
                {
                    MessageBox.Show("Paciente inexistente.\nPor favor, grabe sus datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbnPaciente.Text = " ";
                    btnGrabar.Focus();
                    Restringir();
                }
                ConexionCA.Close();
            }
        }

        private void cmbHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbnHora.Text = cmbHora.SelectedItem.ToString();
            lbnFecha.Text = dtpFecha.Value.ToString("yyyy-MM-dd");
            btnGrabar.Enabled = true;
        }

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

            ConexionCA.Open();
            string cadena = "SELECT TOP 20 CONCAT(Nombre, ' ' , Apellido) AS 'Nombre y Apellido', DNI, Especialidad, DiaSemana AS 'Días de Atención', HoraInicio AS 'Hora inicio', HoraFin AS 'Hora fin', atencionesHora AS 'Atenciones / min' FROM Profesionales WHERE " +
                columnaSeleccionada + " LIKE '%' + @Buscar + '%'";

            SqlCommand comando = new SqlCommand(cadena, ConexionCA);
            comando.Parameters.AddWithValue("@Buscar", txtBuscar.Text);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataSet conjunto = new DataSet();
            adaptador.Fill(conjunto, "Profesionales");
            lista.DataSource = conjunto.Tables["Profesionales"];
            ConexionCA.Close();

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
                }
            }
        }
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

            ConexionCA.Open();
            string consulta = "SELECT Hora FROM citas where fecha = '" + fechaFormateada + "'";
            SqlCommand command = new SqlCommand(consulta, ConexionCA);
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
            ConexionCA.Close();
        }

    }
}

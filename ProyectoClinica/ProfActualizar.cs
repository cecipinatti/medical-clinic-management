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
    public partial class ProfActualizar : Form
    {
        SqlConnection ConexionPRA;
        
        // Constructor de la clase que recibe la conexión a la base de datos y el DNI del profesional a actualizar
        public ProfActualizar(SqlConnection ConexionPRL, string dni)
        {
            InitializeComponent();
            ConexionPRA = ConexionPRL;
            try
            {
                ConexionPRA.Open();
                // Consulta SQL para obtener los datos del profesional mediante su DNI
                string cadena = "SELECT * FROM Profesionales WHERE DNI = @DNI";
                SqlCommand comand = new SqlCommand(cadena, ConexionPRA);
                comand.Parameters.AddWithValue("@DNI", dni);

                SqlDataReader Leer = comand.ExecuteReader();
                // Si se encuentra el profesional, se asignan los datos a los campos del formulario
                if (Leer.Read())
                {
                    txtDNI.Text = Leer["DNI"].ToString();
                    txtNombre.Text = Leer["Nombre"].ToString();
                    txtApellido.Text = Leer["Apellido"].ToString();
                    txtEspecialidad.Text = Leer["Especialidad"].ToString();

                    // Obtener los días de la semana seleccionados
                    string cadenaValores = Leer["DiaSemana"].ToString();
                    string[] elementos = cadenaValores.Split(' ');

                    for (int i = 0; i < clbDiasSemana.Items.Count; i++)
                    {
                        string valorItem = clbDiasSemana.Items[i].ToString();
                        if (elementos.Contains(valorItem))
                        {
                            clbDiasSemana.SetItemChecked(i, true);
                           
                        }
                    }

                    dtpHoraInicio.Text = Leer["horaInicio"].ToString();
                    dtpHoraFin.Text = Leer["horaFin"].ToString();
                    txtAtenciones.Text = Leer["atencionesHora"].ToString();
                    txtCorreo.Text = Leer["Correo"].ToString();
                    txtTel.Text = Leer["Tel"].ToString();
                }

                Leer.Close();
                ConexionPRA.Close();
            }

            catch (SqlException)
            {
                MessageBox.Show("No se pudo abrir los registros.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                ConexionPRA.Close();
            }
        }

        private void btnGrabar_Click_1(object sender, EventArgs e)
        {
            if (txtDNI.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" || txtEspecialidad.Text == "" || txtCorreo.Text == "" ||
                txtTel.Text == "" || clbDiasSemana.CheckedItems.Count < 1 || txtAtenciones.Text == "")
            {
                MessageBox.Show("Inserción inválida!\nPor favor completar los datos en los campos...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDNI.Focus();
            }

            else
            {
                try
                {
                    ConexionPRA.Open();

                    int DNI = Convert.ToInt32(txtDNI.Text);
                    string Nombre = txtNombre.Text;
                    string Apellido = txtApellido.Text;
                    string Especialidad = txtEspecialidad.Text;
                    string horaInicio = dtpHoraInicio.Text;
                    string horaFin = dtpHoraFin.Text;
                    string atenciones = txtAtenciones.Text;

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < clbDiasSemana.CheckedItems.Count; i++)
                    {
                        sb.Append(clbDiasSemana.CheckedItems[i].ToString());
                        sb.Append(" ");
                    }

                    string Correo = txtCorreo.Text;
                    string Tel = txtTel.Text;
                   
                    string diasSemana = sb.ToString();
                    string cadena = "UPDATE Profesionales SET Nombre = @Nombre, Apellido = @Apellido, Especialidad = @Especialidad, diaSemana = @diaSemana, horaInicio = @horaInicio, horaFin = @horaFin, atencionesHora = @AtencionesHora, Correo = @Correo, Tel = @Tel WHERE DNI = @DNI";

                    SqlCommand comando = new SqlCommand(cadena, ConexionPRA);
                    comando.Parameters.AddWithValue("@DNI", DNI);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Apellido", Apellido);
                    comando.Parameters.AddWithValue("@Especialidad", Especialidad);
                    comando.Parameters.AddWithValue("@diaSemana", diasSemana);
                    comando.Parameters.AddWithValue("@horaInicio", horaInicio);
                    comando.Parameters.AddWithValue("@horaFin", horaFin);
                    comando.Parameters.AddWithValue("@AtencionesHora", atenciones);
                    comando.Parameters.AddWithValue("@Correo", Correo);
                    comando.Parameters.AddWithValue("@Tel", Tel);

                    comando.ExecuteNonQuery();
                    MessageBox.Show("La modificación se realizó correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ConexionPRA.Close();
                    this.Close();

                }
                catch (SqlException)
                {
                    MessageBox.Show("No se pudo realizar la actualización!!\nPor favor verifique los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ConexionPRA.Close();
                }
            }
        }

        private void ProfActualizar_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

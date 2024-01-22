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
    public partial class PacActualizar : Form
    {
        SqlConnection ConexionPAA;
        public PacActualizar(SqlConnection Conexion, string dni)
        {
            InitializeComponent();
            ConexionPAA = Conexion;
           
            try
            {
                ConexionPAA.Open();
                string cadena = "SELECT * FROM Pacientes WHERE DNI = @DNI";
                SqlCommand comand = new SqlCommand(cadena, ConexionPAA);
                comand.Parameters.AddWithValue("@DNI", dni);

                SqlDataReader Leer = comand.ExecuteReader();
                if (Leer.Read())
                {
                    txtDNI.Text = Leer["DNI"].ToString();
                    txtNombre.Text = Leer["Nombre"].ToString();
                    txtApellido.Text = Leer["Apellido"].ToString();
                    dtpFechaNac.Value = Convert.ToDateTime(Leer["FechaNac"]);
                    txtCorreo.Text = Leer["Correo"].ToString();
                    txtTel.Text = Leer["Tel"].ToString();
                }

                Leer.Close();
                ConexionPAA.Close();
            }

            catch (SqlException)
            {
                MessageBox.Show("No se pudo abrir los registros.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                ConexionPAA.Close();
            }
        }

        private void PacActualizar_Load(object sender, EventArgs e)
        {
            dtpFechaNac.MaxDate = DateTime.Today;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Today;
            if (txtDNI.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" ||
                (dtpFechaNac.Value.ToShortDateString() == fechaActual.ToShortDateString()) || txtCorreo.Text == "" || txtTel.Text == "")
            {
                MessageBox.Show("Inserción inválida!\nPor favor completar los datos en los campos...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDNI.Focus();
            }
            else
            {
                try
                {
                    ConexionPAA.Open();
                    int DNI = Convert.ToInt32(txtDNI.Text);
                    string Nombre = txtNombre.Text;
                    string Apellido = txtApellido.Text;
                    DateTime FechaNac = dtpFechaNac.Value;
                    string Correo = txtCorreo.Text;
                    string Tel = txtTel.Text;

                    string cadena = "UPDATE Pacientes SET Nombre = @Nombre, Apellido = @Apellido, Correo = @Correo, Tel = @Tel, FechaNac = @FechaNac WHERE DNI = @DNI";

                    SqlCommand comando = new SqlCommand(cadena, ConexionPAA);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Apellido", Apellido);
                    comando.Parameters.AddWithValue("@Correo", Correo);
                    comando.Parameters.AddWithValue("@Tel", Tel);
                    comando.Parameters.AddWithValue("@FechaNac", FechaNac);
                    comando.Parameters.AddWithValue("@DNI", DNI);

                    comando.ExecuteNonQuery();
                    MessageBox.Show("La modificación se realizó correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ConexionPAA.Close();
                    this.Close();

                }
                catch (SqlException)
                {
                    MessageBox.Show("No se pudo realizar la actualización!!\nPor favor verifique los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ConexionPAA.Close();
                }
            }
        }

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

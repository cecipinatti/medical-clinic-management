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
    public partial class PacNuevo : Form
    {
        SqlConnection ConexionPAN;
        public PacNuevo(SqlConnection Conexion)
        {
            InitializeComponent();
            ConexionPAN = Conexion;
        }

        private void PacNuevo_Load(object sender, EventArgs e)
        {
            dtpFechaNac.MaxDate = DateTime.Today;
        }
        public void Inicializar()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTel.Text = "";
            txtCorreo.Text = "";
            dtpFechaNac.Value = DateTime.Today;
            txtDNI.Focus();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;

            if (txtDNI.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" ||
            txtCorreo.Text == "" || txtTel.Text == "")
            {
                MessageBox.Show("Inserción inválida.\nPor favor, complete los datos en los campos.", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDNI.Focus();
            }
            else if (dtpFechaNac.Value.ToShortDateString() == fechaActual.ToShortDateString())
            {
                MessageBox.Show("Fecha de nacimiento inválida.\nDebe ser inferior a la fecha actual.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFechaNac.Focus();
            }
            else
            {
                try
                {
                    ConexionPAN.Open();

                    int DNI = Convert.ToInt32(txtDNI.Text);
                    string Nombre = txtNombre.Text;
                    string Apellido = txtApellido.Text;
                    DateTime FechaNac = dtpFechaNac.Value;
                    string Correo = txtCorreo.Text;
                    string Tel = txtTel.Text;

                    string cadena = "INSERT into Pacientes (DNI, Nombre, Apellido, Tel, Correo, FechaNac) values" +
                        " ('" + DNI + "','" + Nombre + "','" + Apellido + "','" + Tel + "','" + Correo + "','" + FechaNac.ToString("yyyy-MM-dd") + "')";

                    SqlCommand comando = new SqlCommand(cadena, ConexionPAN);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Los datos se guardaron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ConexionPAN.Close();
                    DialogResult mje = MessageBox.Show("Desea ingresar otro paciente?", "Ingresar paciente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (mje == DialogResult.Yes)
                    {
                        Inicializar();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("No se pudo realizar la operación!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                finally
                {
                    ConexionPAN.Close();
                }
            }
        }
    }
}

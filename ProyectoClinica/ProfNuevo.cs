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
    public partial class ProfNuevo : Form
    {
        SqlConnection ConexionPRN;  
        public ProfNuevo(SqlConnection ConexionPRL)
        {
            InitializeComponent();
            ConexionPRN = ConexionPRL;  
        }

        private void ProfNuevo_Load(object sender, EventArgs e)
        {
            // Agregar los días de la semana al control CheckedListBox
            clbDiasSemana.Items.Add("Lunes");
            clbDiasSemana.Items.Add("Martes");
            clbDiasSemana.Items.Add("Miércoles");
            clbDiasSemana.Items.Add("Jueves");
            clbDiasSemana.Items.Add("Viernes");
        }

        private void Inicializar()
        {
            // Reinicializar los campos del formulario
            // desmarcar los elementos seleccionados en clbDiasSemana
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEspecialidad.Text = "";
            txtAtenciones.Text = "";
            txtCorreo.Text = "";
            txtTel.Text = "";
            foreach (int indice in clbDiasSemana.CheckedIndices)
            {
                clbDiasSemana.SetItemChecked(indice, false);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (txtDNI.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" || txtEspecialidad.Text == "" || txtCorreo.Text == "" ||
                txtTel.Text == "" || clbDiasSemana.CheckedItems.Count < 1 || txtAtenciones.Text == "")
            {
                MessageBox.Show("Inserción inválida.\nPor favor, complete los datos en los campos.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDNI.Focus();
            }
            else
            {
                try
                {
                    ConexionPRN.Open();  

                    // Obtener los valores de los campos
                    int DNI = Convert.ToInt32(txtDNI.Text);
                    string Nombre = txtNombre.Text;
                    string Apellido = txtApellido.Text;
                    string Especialidad = txtEspecialidad.Text;

                    StringBuilder sb = new StringBuilder();

                    // Construir la cadena de días seleccionados
                    for (int i = 0; i < clbDiasSemana.CheckedItems.Count; i++)
                    {
                        sb.Append(clbDiasSemana.CheckedItems[i].ToString());
                        sb.Append(" ");
                    }
                    string diasSeleccionados = sb.ToString();

                    // Obtener la hora de inicio del intervalo
                    string HoraInicio = dtpHoraInicio.Text;
                    // Obtener la hora de fin del intervalo
                    string HoraFin = dtpHoraFin.Text;
                    // Obtener la cantidad de atenciones por intervalo
                    string Atenciones = txtAtenciones.Text;

                    string Correo = txtCorreo.Text;
                    string Tel = txtTel.Text;

                    string cadena = "INSERT into Profesionales (DNI, Nombre, Apellido, Especialidad, DiaSemana, HoraInicio, HoraFin, Correo, Tel, atencionesHora) values" +
                        " ('" + DNI + "','" + Nombre + "','" + Apellido + "','" + Especialidad + "','" + diasSeleccionados + "','"
                        + HoraInicio + "','" + HoraFin + "','" + Correo + "','" + Tel + "','" + Atenciones + "')";

                    SqlCommand comando = new SqlCommand(cadena, ConexionPRN);
                    comando.ExecuteNonQuery(); 

                    MessageBox.Show("Los datos se guardaron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConexionPRN.Close();  

                    DialogResult mje = MessageBox.Show("Desea ingresar otro profesional?", "Ingresar profesional", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (mje == DialogResult.Yes)
                    {
                        // Reinicializar los campos del formulario
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
                    ConexionPRN.Close();
                }
            }
        }
    }
}

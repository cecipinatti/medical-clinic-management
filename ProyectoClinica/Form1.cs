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
    public partial class Form1 : Form
    {

        SqlConnection Conexion = new SqlConnection("Data Source=DESKTOP-4K8BSKR\\SQLEXPRESS; database=DBProyecto; Integrated Security=true");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbnHora.Parent = pictureBox1;
            lbnFecha.Parent = pictureBox1;
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lbnHora.Text = DateTime.Now.ToLongTimeString();
            lbnFecha.Text = DateTime.Now.ToLongDateString();
        }

        //PACIENTES
        private void btnPacientes_Click(object sender, EventArgs e)
        {
            PacListado PAL = new PacListado(Conexion);
            PAL.Show();
        }

        //PROFESIONALES
        private void btnProfesionales_Click(object sender, EventArgs e)
        {
            ProfListado PRL = new ProfListado(Conexion);
            PRL.Show();
        }

        //CITAS
        private void btnCitas_Click(object sender, EventArgs e)
        {
            CitaListado CL = new CitaListado(Conexion);
            CL.Show();
        }
    }
}

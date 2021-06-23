using ProyectoFinal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPrueba
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //Irán validaciones para verificar que existe el usuario, que no pueda iniciar sesión sin haber ingresado algo
            DialogResult answer = MessageBox.Show("Fecha, hora y id de cabina han sido guardados", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            using (frmPrincipal newWindow = new frmPrincipal())
            {
                newWindow.ShowDialog();
            }
        }
    }
}

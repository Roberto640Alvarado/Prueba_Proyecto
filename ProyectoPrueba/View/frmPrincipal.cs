using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            tabControl.ItemSize = new Size(0, 1);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCritizenName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhoneNumer2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDirection_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSickness_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInstitution_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Los datos del ciudadano ha sido almacenada", "Datos almacenados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Posteriormente se le genera un mensaje para que aparezca la fecha de su cita

            //Se redirige a inicio porque no se sabe si se quiere hacer seguimiento de cita o registrar otro ciudadano
            tabControl.SelectedIndex = 0;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("¿Esta seguro que quiere cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                tabControl.SelectedIndex = 0;
                txtDuiRU.Text = "";
                txtCritizenName.Text = "";
                txtPhoneNumer2.Text = "";
                txtDirection.Text = "";
                txtEmail.Text = "";
                txtSickness.Text = "";
                txtInstitution.Text = "";
            }
        }
        private void toolStripHome_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void toolStripRegisterUser_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void toolStripDateProcess_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void toolStriptabVaccinationProcess_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

        private void toolStripPostVaccination_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 4;
        }

        private void btnCancelSC_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("¿Esta seguro que quiere cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(answer == DialogResult.Yes)
            {
                tabControl.SelectedIndex = 0;
                txtDui.Clear();
                lblNameShow.Text = "";
                lblPhoneNumber.Text = "";
                lblEmail.Text = "";
                lblDirection.Text = "";
                lblDiseases.Text = "";
                lblInstitution.Text = "";
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Se hará validación y si no retorna nada se deberá de sugerir si desea registrarse para que se le asigne una cita
        }

        private void btnNextSC_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("¿Esta seguro que quiere aplicarse la vacuna?", "Consentimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                tabControl.SelectedIndex = 3;
                pgrProgress.Value = pgrProgress.Minimum;
                tmrTimer.Enabled = true;
                btnNextPV.Enabled = false;
            }
            else
            {
                MessageBox.Show("El ciudadano no esta disupuesto a vacunarse", "Consentimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDui.Clear();
                lblNameShow.Text = "";
                lblPhoneNumber.Text = "";
                lblEmail.Text = "";
                lblDirection.Text = "";
                lblDiseases.Text = "";
                lblInstitution.Text = "";
                tabControl.SelectedIndex = 0;
            }
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            if (pgrProgress.Value == pgrProgress.Maximum)
            {
                //Detiene el temorizador
                tmrTimer.Enabled = false;
                btnNextPV.Enabled = true;

                //Cambia el lbl
                lblToolStrip.Text = "El ciudadano ha pasado a vacunarse";
            }
            else
            {
                pgrProgress.Value++;
            }
        }

        private void btnNextPV_Click(object sender, EventArgs e)
        {
            pgrProgress.Value = pgrProgress.Minimum;
            lblToolStrip.Text = "El ciudadano se encuentra en la fila de espera";
            tabControl.SelectedIndex = 4;
            MessageBox.Show("El ciudadano se ha aplicado la vacuna, ahora se digire " +
                "ser vigilado por 30 minutos", "Observación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSavePV_Click(object sender, EventArgs e)
        {
            //TO DO: Almacenar la hora y la fecha
        }

        private void btnCancelPV_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("¿Esta seguro que quiere cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                tabControl.SelectedIndex = 0;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha almacenado la información, el ciudadano " +
                "ya puede retirarse", "Última etapa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tabControl.SelectedIndex = 0;
            txtDui.Clear();
            lblNameShow.Text = "";
            lblPhoneNumber.Text = "";
            lblEmail.Text = "";
            lblDirection.Text = "";
            lblDiseases.Text = "";
            lblInstitution.Text = "";
            //En este caso se tendría que hacer una validación en donde se debe de haber ingresado la hora para que se pueda
            //dat siguiente
        }

        private void btnSaveSideEffects_Click(object sender, EventArgs e)
        {
            //TO DO: Almacenar los efectos secundarios
        }

        private void btnSaveApplicationTime_Click(object sender, EventArgs e)
        {
            //TO DO: Almacenar la hora
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

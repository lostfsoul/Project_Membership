using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasmaProject.Forms
{
    
    public partial class Frm_Menu : Form
    {

        UserControl1 u = new UserControl1();
        //Forms.Frm_Add_Edit ff = new Frm_Add_Edit();
        public Frm_Menu()
        {
            InitializeComponent();
            panel1.Size = new Size(215,444);
            pnlsett.Hide();
        }
         public void disableform()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btndeco.Enabled = false;
            btnco.Enabled = true;
        }
        public void enableform()
        {
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btndeco.Enabled = true;
            btnco.Enabled = false;
            pnlsett.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnluser.Show();
            pnlturn.Top = btn1.Top;
            if (!pnluser.Controls.Contains(UserControl1.instance))
            {
                pnluser.Controls.Add(UserControl1.instance);
                UserControl1.instance.Dock = DockStyle.Fill;
                UserControl1.instance.BringToFront();
                
            }
            else
            {
                UserControl1.instance.BringToFront();
            }
            UserControl1.instance.ActualiseDGV0();
            //ff.comboBox1.Text = "محو الامية";
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (panel1.Width== 215)
            {
                panel1.Size = new Size(79,444);
            }
            else
            {
                panel1.Size = new Size(215,444);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserControl1 u = new UserControl1();
            pnlturn.Top = btn2.Top;
            if (!pnluser.Controls.Contains(UserControl1.instance))
            {
                pnluser.Controls.Add(UserControl1.instance);
                UserControl1.instance.Dock = DockStyle.Fill;
                UserControl1.instance.BringToFront();
            }
            else
            {
                UserControl1.instance.BringToFront();
            }
            UserControl1.instance.ActualiseDGV1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pnlturn.Top = btn3.Top;
            if (!pnluser.Controls.Contains(UserControl1.instance))
            {
                pnluser.Controls.Add(UserControl1.instance);
                UserControl1.instance.Dock = DockStyle.Fill;
                UserControl1.instance.BringToFront();
            }
            else
            {
                UserControl1.instance.BringToFront();
            }
            UserControl1.instance.ActualiseDGV2();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pnlturn.Top = btn4.Top;
            if (!pnluser.Controls.Contains(UserControl1.instance))
            {
                pnluser.Controls.Add(UserControl1.instance);
                UserControl1.instance.Dock = DockStyle.Fill;
                UserControl1.instance.BringToFront();
            }
            else
            {
                UserControl1.instance.BringToFront();
            }
            UserControl1.instance.ActualiseDGV3();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pnlturn.Top = btn5.Top;
            if (!pnluser.Controls.Contains(UserControl1.instance))
            {
                pnluser.Controls.Add(UserControl1.instance);
                UserControl1.instance.Dock = DockStyle.Fill;
                UserControl1.instance.BringToFront();
            }
            else
            {
                UserControl1.instance.BringToFront();
            }
            UserControl1.instance.ActualiseDGV4();
            
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Menu_Load(object sender, EventArgs e)
        {
            disableform();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pnlsett.Size = new Size(443,36);
            pnlsett.Visible = !pnlsett.Visible;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Forms.Frm_Connecte f2 = new Forms.Frm_Connecte(this);
            f2.ShowDialog();
           
        }

        private void btndeco_Click(object sender, EventArgs e)
        {
            disableform();
            pnluser.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlturn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

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
    public partial class Frm_Connecte : Form
    {
        private DBBasma db;
        private Form frmmenu;
        Classes.Frm_Connection c = new Classes.Frm_Connection();
        public Frm_Connecte(Form menu)
        {
            this.frmmenu = menu;
            InitializeComponent();
            db = new DBBasma();
        }
        string testtyping()
        {
            if(textBox1.Text==""||textBox1.Text== "اسم المستخدم")
            {
                return "ادخل اسم المستخدم";
            }

            if (textBox2.Text == "" || textBox2.Text == "كلمة المرور")
            {
                return "ادخل كلمة المرور";
            }
            return null;
        }

        private void Frm_Connecte_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "اسم المستخدم")
            {
                textBox1.Text = "";
            }
        }
        private void textBox1_Leave(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "كلمة المرور")
            {
                textBox2.Text = "";
            }
        }
        private void textBox2_Leave(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "اسم المستخدم";
            }
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "كلمة المرور";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (testtyping() == null)
            {
                if (c.CennectionValide(db, textBox1.Text, textBox2.Text) == true)
                {
                    MessageBox.Show("تم الاتصال", "connection", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (frmmenu as Frm_Menu).enableform();
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("فشل الاتصال", "connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            else
            {
                MessageBox.Show(testtyping(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
    }
}

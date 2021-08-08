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
    public partial class Frm_Add_Edit : Form
    {
        private DBBasma db=new DBBasma();
        Forms.Frm_Menu mn = new Frm_Menu();
        public Frm_Add_Edit()
        {
            InitializeComponent();
        }
        string testForm()
        {
            if (txtname.Text=="اسم المستخدم" || txtname.Text=="")
            {
                return "ادخل اسم المستخدم";
            }
            if (txtnick.Text == "النسب" || txtnick.Text == "")
            {
                return "ادخل النسب";
            }
            if (txtphone.Text == "رقم الهاتف" || txtphone.Text == "")
            {
                return "ادخل رقم الهاتف";
            }
            if (txtadresse.Text == "العنوان" || txtadresse.Text == "")
            {
                return "ادخل العنوان";
            }
            return null;
        }
        public void fillcombo()
        {
            comboBox1.DataSource = db.Categoties.Select(p => new { ID_Cat = p.id_categorie, Nom_Cat = p.nom_categorie }).ToList();
            comboBox1.DisplayMember = "Nom_Cat";
            comboBox1.ValueMember = "ID_Cat";

        }
        private void Frm_Add_Edit_Load(object sender, EventArgs e)
        {
            fillcombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtname.Text == "اسم المستخدم")
            {
                txtname.Text = "";
                txtname.ForeColor = Color.White;
            }
        }

        private void txtnick_Enter(object sender, EventArgs e)
        {
            if (txtnick.Text == "النسب")
            {
                txtnick.Text = "";
                txtnick.ForeColor = Color.White;
            }
        }

        private void txtphone_Enter(object sender, EventArgs e)
        {
            if (txtphone.Text == "رقم الهاتف")
            {
                txtphone.Text = "";
                txtphone.ForeColor = Color.White;
            }
        }

        private void txtadresse_Enter(object sender, EventArgs e)
        {
            if (txtadresse.Text == "العنوان")
            {
                txtadresse.Text = "";
                txtadresse.ForeColor = Color.White;
            }
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                txtname.Text = "اسم المستخدم";
                txtname.ForeColor = Color.White;
            }
        }

        private void txtnick_Leave(object sender, EventArgs e)
        {
            if (txtnick.Text == "")
            {
                txtnick.Text = "النسب";
                txtnick.ForeColor = Color.White;
            }
        }

        private void txtphone_Leave(object sender, EventArgs e)
        {
            if (txtphone.Text == "")
            {
                txtphone.Text = "رقم الهاتف";
                txtphone.ForeColor = Color.White;
            }
        }

        private void txtadresse_Leave(object sender, EventArgs e)
        {
            if (txtadresse.Text == "")
            {
                txtadresse.Text = "العنوان";
                txtadresse.ForeColor = Color.White;
            }
        }

        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar<48 || e.KeyChar>57)
            {
                e.Handled = true;
            }
            if(e.KeyChar==8)
            {
                e.Handled = false;
            }
        }
        public int IDSelect;
        private void button3_Click(object sender, EventArgs e)
        {
            if (testForm()!=null)
            {
                MessageBox.Show(testForm(),"obligatoir",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if(label1.Text== "اضافة عضو")
            {
                Classes.CLS_Member m = new Classes.CLS_Member();
                if (m.add_member(txtname.Text,txtnick.Text,txtphone.Text,txtadresse.Text,comboBox1.Text)==true)
                {
                    MessageBox.Show("تمت اضافة عضو بنجاح", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (comboBox1.SelectedIndex==0)
                    {
                        UserControl1.usercntrl.ActualiseDGV0();
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        UserControl1.usercntrl.ActualiseDGV1();
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        UserControl1.usercntrl.ActualiseDGV2();
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        UserControl1.usercntrl.ActualiseDGV3();
                    }
                    if (comboBox1.SelectedIndex == 4)
                    {
                        UserControl1.usercntrl.ActualiseDGV4();
                    }

                }
                else
                {
                    MessageBox.Show("عضو موجود بالفعل", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //try { 
                //string Nom = txtname.Text;
                //Membre m = db.Membres.Where(x => x.nom_membre == Nom).First();
                //m.nom_membre = txtname.Text;
                //m.prenom_membre = txtnick.Text;
                //m.telephone_membre = txtphone.Text;
                //m.adresse_membre = txtadresse.Text;
                //m.categorie = comboBox1.Text; 
                //db.SaveChanges();
                //MessageBox.Show("تمت التعديل عضو بنجاح", "Modifie", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //}
                //catch
                //{
                //    MessageBox.Show("عضو غير موجود", "Modifie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                Classes.CLS_Member m = new Classes.CLS_Member();
                DialogResult r = MessageBox.Show("تريد بالفعل تعديل العضو", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r==DialogResult.Yes)
                {
                    m.EditMembre(IDSelect, txtname.Text, txtnick.Text, txtphone.Text, txtadresse.Text, comboBox1.Text); 
                    MessageBox.Show("تم التعديل بنجاح", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (comboBox1.SelectedIndex == 0)
                    {
                        UserControl1.usercntrl.ActualiseDGV0();
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        UserControl1.usercntrl.ActualiseDGV1();
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        UserControl1.usercntrl.ActualiseDGV2();
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        UserControl1.usercntrl.ActualiseDGV3();
                    }
                    if (comboBox1.SelectedIndex == 4)
                    {
                        UserControl1.usercntrl.ActualiseDGV4();
                    }
                }
                else
                {
                    MessageBox.Show("التعديل لم يتم بنجاح", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void lbltitle_Click(object sender, EventArgs e)
        {

        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {

        }
        private void Ref()
        {
            txtname.Text = "";
            txtnick.Text = "";
            txtadresse.Text = "";
            txtphone.Text = "";
            comboBox1.Text = "";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ref();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

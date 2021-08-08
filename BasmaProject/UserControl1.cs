using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasmaProject
{
    public partial class UserControl1 : UserControl
    {
        private DBBasma db;
        public static UserControl1 usercntrl;
        public static UserControl1 instance
        {
            get
            {
                if (usercntrl==null)
                {
                    usercntrl = new UserControl1();
                }
                return usercntrl;
            }
        }

        public UserControl1()
        {
            InitializeComponent();
            txtsearch.Enabled = false;
            
        }
        public void ActualiseDGV()
        {
            db = new DBBasma();
            dataGridView1.Rows.Clear();
            foreach (var x in db.Membres)
            {
                dataGridView1.Rows.Add(false, x.id_membre, x.nom_membre, x.prenom_membre, x.adresse_membre, x.telephone_membre, x.categorie);
            }

        }
        public void ActualiseDGV0()
        {
            db = new DBBasma();
            dataGridView1.Rows.Clear();
            foreach (var x in db.Membres.Where(n=>n.categorie== "محو الامية"))
            {
                dataGridView1.Rows.Add(false, x.id_membre, x.nom_membre, x.prenom_membre, x.adresse_membre, x.telephone_membre, x.categorie);
            }

        }
        public void ActualiseDGV1()
        {
            db = new DBBasma();
            dataGridView1.Rows.Clear();
            foreach (var x in db.Membres.Where(n => n.categorie == "الخياطة"))
            {
                dataGridView1.Rows.Add(false, x.id_membre, x.nom_membre, x.prenom_membre, x.adresse_membre, x.telephone_membre, x.categorie);
            }

        }
        public void ActualiseDGV2()
        {
            db = new DBBasma();
            dataGridView1.Rows.Clear();
            foreach (var x in db.Membres.Where(n => n.categorie == "الحرف اليدوية"))
            {
                dataGridView1.Rows.Add(false, x.id_membre, x.nom_membre, x.prenom_membre, x.adresse_membre, x.telephone_membre, x.categorie);
            }

        }
        public void ActualiseDGV3()
        {
            db = new DBBasma();
            dataGridView1.Rows.Clear();
            foreach (var x in db.Membres.Where(n => n.categorie == "الطبخ و الحلويات"))
            {
                dataGridView1.Rows.Add(false, x.id_membre, x.nom_membre, x.prenom_membre, x.adresse_membre, x.telephone_membre, x.categorie);
            }

        }
        public void ActualiseDGV4()
        {
            db = new DBBasma();
            dataGridView1.Rows.Clear();
            foreach (var x in db.Membres.Where(n => n.categorie == "الدعم المدرسي"))
            {
                dataGridView1.Rows.Add(false, x.id_membre, x.nom_membre, x.prenom_membre, x.adresse_membre, x.telephone_membre, x.categorie);
            }

        }
        public string VerifieLines()
        {
            int NumLines = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                {
                    NumLines++;
                }
            }
                if (NumLines==0)
                {
                    return "اختار الشخص االدي تريد تعديل معلوماته";
                }
                if (NumLines>1)
                {
                    return "المرجو اختيار شخص واحد";
                }

            return null;
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.Frm_Add_Edit f2 = new Forms.Frm_Add_Edit();
            if (VerifieLines()==null)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                    {
                        f2.IDSelect = (int)dataGridView1.Rows[i].Cells[1].Value;
                        f2.txtname.Text= dataGridView1.Rows[i].Cells[2].Value.ToString();
                        f2.txtnick.Text= dataGridView1.Rows[i].Cells[3].Value.ToString();
                        f2.txtadresse.Text= dataGridView1.Rows[i].Cells[4].Value.ToString();
                        f2.txtphone.Text= dataGridView1.Rows[i].Cells[5].Value.ToString();
                        f2.comboBox1.Text= dataGridView1.Rows[i].Cells[6].Value.ToString();
                    }
                }
                f2.label1.Text = "تعديل عضو";
                f2.button2.Visible = false;
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show(VerifieLines(), "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {
            if(txtsearch.Text== "بحث")
            {
                txtsearch.Text = "";
                txtsearch.ForeColor = Color.Black;
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            db = new DBBasma();
            var searchlist = db.Membres.ToList();
            if (txtsearch.Text!="")
            {
                switch (comboBox1.Text)
                {
                    case "الاسم":
                        searchlist = searchlist.Where(s=>s.nom_membre.IndexOf(txtsearch.Text,StringComparison.CurrentCultureIgnoreCase)!=-1).ToList();
                        break;
                    case "النسب":
                        searchlist = searchlist.Where(s => s.prenom_membre.IndexOf(txtsearch.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "العنوان":
                        searchlist = searchlist.Where(s => s.adresse_membre.IndexOf(txtsearch.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                    case "رقم الهاتف":
                        searchlist = searchlist.Where(s => s.telephone_membre.IndexOf(txtsearch.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        break;
                }
            }
            dataGridView1.Rows.Clear();
            foreach (var x in searchlist)
            {
                dataGridView1.Rows.Add(false, x.id_membre, x.nom_membre, x.prenom_membre, x.adresse_membre, x.telephone_membre, x.categorie);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Forms.Frm_Add_Edit f = new Forms.Frm_Add_Edit();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Classes.CLS_Member mbr = new Classes.CLS_Member();
            int select = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                {
                    select++;
                }
            }
            if (select==0)
            {
                MessageBox.Show("لم تختر اي عضو", "Suppresion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DialogResult R=
                MessageBox.Show("هل تريد بالفعل حدف العضو", "Suppresion", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (R==DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                        {
                            mbr.DeleteMembre(int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()));
                        }
                    }
                    MessageBox.Show("تم المسح", "Suppresion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dataGridView1.Update();
                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show("تم الغاء المسح", "Suppresion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } 

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsearch.Enabled = true;
            txtsearch.Text = "";
        }
    }
}

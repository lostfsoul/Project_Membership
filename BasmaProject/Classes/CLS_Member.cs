using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasmaProject.Classes
{
    class CLS_Member
    {
        Forms.Frm_Add_Edit f = new Forms.Frm_Add_Edit();
        private DBBasma db =new DBBasma();
        private Membre m;
        private Categotie c;
        public bool add_member(string Nom,string Prenom,string Telephone, string Adresse,string Categorie)
        {
            m = new Membre();
            m.nom_membre = Nom;
            m.prenom_membre = Prenom;
            m.telephone_membre = Telephone;
            m.adresse_membre = Adresse;
            m.categorie = Categorie;
            
            if (db.Membres.SingleOrDefault(s=>s.nom_membre==Nom && s.prenom_membre==Prenom)==null)
            {
                db.Membres.Add(m);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void EditMembre(int ID,string Nom, string Prenom, string Telephone, string Adresse, string Categorie)
        {
            m = new Membre();
            m = db.Membres.SingleOrDefault(x=>x.id_membre==ID);
            if (m!=null)
            {
                m.nom_membre = Nom;
                m.prenom_membre = Prenom;
                m.telephone_membre = Telephone;
                m.adresse_membre = Adresse;
                m.categorie = Categorie;
                db.SaveChanges();
            }

        }
        public void DeleteMembre(int id)
        {
            m = new Membre();
            m = db.Membres.SingleOrDefault(x => x.id_membre == id);
            if (m!=null)
            {
                db.Membres.Remove(m);
                db.SaveChanges();
            }

        }
        
    }
}

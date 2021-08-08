using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasmaProject.Classes
{
    class Frm_Connection
    {
        public bool CennectionValide(DBBasma db,string nom,string passwrd)
        {
            login l = new login();
            l.nom_user = nom;
            l.motdepass = passwrd;
            if (db.logins.SingleOrDefault(s=>s.nom_user==nom && s.motdepass==passwrd)!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

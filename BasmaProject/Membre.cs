//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BasmaProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Membre
    {
        public int id_membre { get; set; }
        public string nom_membre { get; set; }
        public string prenom_membre { get; set; }
        public string adresse_membre { get; set; }
        public string telephone_membre { get; set; }
        public Nullable<int> id_categorie { get; set; }
        public string categorie { get; set; }
    
        public virtual Categotie Categotie { get; set; }
    }
}
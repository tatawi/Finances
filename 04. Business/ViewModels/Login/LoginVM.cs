using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Login
{
    public class LoginVM
    {
        public string Utilisateur { get; set; }
        public string mdp { get; set; }

        public bool Authentifie { get; set; }




        //Ajout nouvel utilisateur
        public string newNom { get; set; }
        public string newPrenom { get; set; }
        public string newMail { get; set; }
        public string newMdp { get; set; }
        public string newConfirmMdp { get; set; }
        public bool isActif { get; set; }
        public string Message { get; set; }


    }
}

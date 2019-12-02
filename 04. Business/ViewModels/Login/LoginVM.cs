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
    }
}

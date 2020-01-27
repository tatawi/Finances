using Finance.Data.bdd;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Managers
{
    public class UtilisateurManager
    {

        private bdd_Utilisateur bdd_Utilisateur { get; set; }

        public UtilisateurManager()
        {
            this.bdd_Utilisateur = new bdd_Utilisateur();
        }



        //Récupére un utilisateur en base de données
        public Utilisateur GetUtilisateur (string email)
        {
            try
            {
                return this.bdd_Utilisateur.Get_Utilisateur(email);
            }
            catch (Exception)
            {
                return null;
            }

        }


        //Ajout d'un utilisateur en base de données
        public bool AddUtilisateur(Utilisateur user)
        {
            try
            {
                //Vérification de l'unicité de l'adresse mail
                if (bdd_Utilisateur.IsUtilisateurPresent(user.Email))
                    return false;

                //Ajout
                this.bdd_Utilisateur.Add_Utilisateur(user);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Vérification de l'unicité d'un utilisateur
        public bool IsUtilisateurPresent(string email)
        {
            bool isPresent;
            try
            {
                isPresent = this.bdd_Utilisateur.IsUtilisateurPresent(email);
            }    
            catch(Exception)
            {
                return false;
            }
                
            return isPresent;
        }

        //Met à jour un utilisateur
        public bool MajUtilisateur(Utilisateur user)
        {
            try
            {
                if (this.IsUtilisateurPresent(user.Email))
                {
                    this.bdd_Utilisateur.Maj_Utilisateur(user);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Controle de la conformité du mot de passe
        public bool IsMotDePasseConforme(string mdp)
        {
            return true;
        }

        //Crypter une chaine de caractére
        public string Encrypt(string data)
        {
            SHA256Managed shaM = new SHA256Managed();
            Convert.ToBase64String(shaM.ComputeHash(Encoding.ASCII.GetBytes(data)));
            byte[] eNcData = Encoding.ASCII.GetBytes(data);
            string eNcStr = Convert.ToBase64String(eNcData);
            return eNcStr;
        }


        //Génére un mot de passe aléatoire
        public string GenererMotDePasse()
        {
            string mdp = "";
            Random rnd = new Random();
            for (int i = 0; i < 12; i++)
            {
                int nb = 0;
                if (i == 0)
                {
                    //nb = this.GetRandomInt(65, 90);
                    nb = rnd.Next(65, 90);
                }
                else if (i == 5)
                {
                    //nb = this.GetRandomInt(33, 46);
                    nb = rnd.Next(33, 46);
                }
                else
                {
                    //nb = this.GetRandomInt(97, 122);
                    nb = rnd.Next(97, 122);
                }
                char c = (char)nb;
                mdp = mdp + c;

            }

            return mdp;
        }

    }
}

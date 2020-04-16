using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Finance.Business.Managers
{
    public class ApplicationManager
    {

        private static UtilisateurManager utilisateurManager;
        private static Utilisateur user;

        public ApplicationManager()
        {
            utilisateurManager = new UtilisateurManager();
        }


        public static Utilisateur CurrentUser
        {
            get
            {
                if (user == null)
                    SetupUser(HttpContext.Current.User.Identity.Name);

                return user;
            }
        }



        public static void SetupUser(string login)
        {
            if (utilisateurManager == null)
                utilisateurManager = new UtilisateurManager();

            user = utilisateurManager.GetUtilisateur(login);
        }

    }
}

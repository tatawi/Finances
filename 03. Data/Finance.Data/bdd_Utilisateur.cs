using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.bdd
{
    public class bdd_Utilisateur : bdd
    {

        public bdd_Utilisateur()
        {

        }





        //------------------------------------------------------------------------------------------------------------
        // GET 
        //------------------------------------------------------------------------------------------------------------

        //Get Utilisateurs
        public List<Utilisateur> Get_All()
        {
            List<Utilisateur> list = new List<Utilisateur>(); ;
            string sql = "SELECT UtilisateurId, Nom, Prenom, Email, MotDePasse, DoitChangerMdp, IsAdmin, IsActif FROM Utilisateur";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Utilisateur user = new Utilisateur();
                            user.UtilisateurId = reader.GetInt32(0);
                            user.Nom = reader.GetString(1);
                            user.Prenom = reader.GetString(2);
                            user.Email = reader.GetString(3);
                            user.MotDePasse = reader.GetString(4);
                            user.DoitChangerMdp = reader.GetBoolean(5);
                            user.IsAdmin = reader.GetBoolean(6);
                            user.IsActif = reader.GetBoolean(7);
                            list.Add(user);
                        }
                    }
                }
                conn.Close();
            }
            return list;
        }

        //Get Utilisateur via login (email)
        public Utilisateur Get_Utilisateur(string email)
        {
            Utilisateur user = null;
            string sql = "SELECT UtilisateurId, Nom, Prenom, Email, MotDePasse, DoitChangerMdp, IsAdmin, IsActif FROM Utilisateur WHERE Email = @paramMail";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramMail", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = new Utilisateur();
                            user.UtilisateurId = reader.GetInt32(0);
                            user.Nom = reader.GetString(1);
                            user.Prenom = reader.GetString(2);
                            user.Email = reader.GetString(3);
                            user.MotDePasse = reader.GetString(4);
                            user.DoitChangerMdp = reader.GetBoolean(5);
                            user.IsAdmin = reader.GetBoolean(6);
                            user.IsActif = reader.GetBoolean(7);
                        }
                    }
                }
                conn.Close();
            }
            return user;
        }


        //------------------------------------------------------------------------------------------------------------
        // INSERT
        //------------------------------------------------------------------------------------------------------------
        public void Add_Utilisateur(Utilisateur user)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Utilisateur (Nom, Prenom, Email, MotDePasse, DoitChangerMdp, IsAdmin, IsActif) VALUES(@Nom, @Prenom, @Email, @MotDePasse, @DoitChangerMdp, @IsAdmin, @IsActif)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Nom", SqlDbType.VarChar).Value = user.Nom;
                cmd.Parameters.Add("@Prenom", SqlDbType.VarChar).Value = user.Prenom;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
                cmd.Parameters.Add("@MotDePasse", SqlDbType.VarChar).Value = user.MotDePasse;
                cmd.Parameters.Add("@DoitChangerMdp", SqlDbType.Bit).Value = user.DoitChangerMdp;
                cmd.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = user.IsAdmin;
                cmd.Parameters.Add("@IsActif", SqlDbType.Bit).Value = user.IsActif;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }



        //------------------------------------------------------------------------------------------------------------
        // UPDATE
        //------------------------------------------------------------------------------------------------------------
        public void Maj_Utilisateur(Utilisateur user)
        {
            //SELECT ConsoEauId, Annee, Type, Emplacement, Conso, Montant FROM ConsoEau
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "UPDATE Utilisateur SET Nom=@Nom, Prenom=@Prenom, MotDePasse=@MotDePasse, DoitChangerMdp=@DoitChangerMdp," +
                    " IsActif=@IsActif, IsAdmin=@IsAdmin WHERE Email=@Email";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Nom", SqlDbType.VarChar).Value = user.Nom;
                cmd.Parameters.Add("@Prenom", SqlDbType.VarChar).Value = user.Prenom;
                cmd.Parameters.Add("@MotDePasse", SqlDbType.VarChar).Value = user.MotDePasse;
                cmd.Parameters.Add("@DoitChangerMdp", SqlDbType.Bit).Value = user.DoitChangerMdp;
                cmd.Parameters.Add("@IsActif", SqlDbType.Bit).Value = user.IsActif;
                cmd.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = user.IsAdmin;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }


        //------------------------------------------------------------------------------------------------------------
        // AUTRE
        //------------------------------------------------------------------------------------------------------------
        public bool IsUtilisateurPresent(string email)
        {
            bool isPresent = true;

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Count(*) FROM Utilisateur WHERE Email=@paramMail", conn))
                {
                    cmd.Parameters.AddWithValue("paramMail", email);

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    if (count == 0) isPresent = false;

                }
                conn.Close();
            }

            return isPresent;
        }
    }
}

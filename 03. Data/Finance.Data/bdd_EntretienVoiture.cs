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
    public class bdd_EntretienVoiture : bdd
    {

        public int utilisateurId;


        public bdd_EntretienVoiture()
        {

        }

        public void SetUser(int user)
        {
            this.utilisateurId = user;
        }


        //------------------------------------------------------------------------------------------------------------
        // GET 
        //------------------------------------------------------------------------------------------------------------

        //Get all infos pour une année
        public List<EntretienVoiture> get_All()
        {
            List<EntretienVoiture> list_infos = new List<EntretienVoiture>();
            string sql = "SELECT EntretienVoitureId, Date, Km, Cout, Type, Description, Effectue FROM EntretienVoiture WHERE UtilisateurId = @paramUserId";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUserId", this.utilisateurId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EntretienVoiture info = new EntretienVoiture();

                            info.EntretienVoitureId = reader.GetInt32(0);
                            info.Date = reader.GetDateTime(1);
                            info.Km = reader.GetInt32(2);
                            info.Cout = reader.GetInt32(3);
                            info.Type = reader.GetString(4);
                            info.Description = reader.GetString(5);
                            info.Effectue = reader.GetBoolean(6);
                            
                            list_infos.Add(info);
                        }
                    }
                }
                conn.Close();
            }
            return list_infos;
        }



        //Get all infos pour une année
        public List<EntretienVoiture> get_AllForYear(int annee)
        {
            List<EntretienVoiture> list_infos = new List<EntretienVoiture>();
            string sql = "SELECT EntretienVoitureId, Date, Km, Cout, Type, Description, Effectue FROM EntretienVoiture WHERE UtilisateurId = @paramUserId AND Year(Date) = @paramDate";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramDate", annee);
                    cmd.Parameters.AddWithValue("paramUserId", this.utilisateurId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EntretienVoiture info = new EntretienVoiture();

                            info.EntretienVoitureId = reader.GetInt32(0);
                            info.Date = reader.GetDateTime(1);
                            info.Km = reader.GetInt32(2);
                            info.Cout = reader.GetInt32(3);
                            info.Type = reader.GetString(4);
                            info.Description = reader.GetString(5);
                            info.Effectue = reader.GetBoolean(6);

                            list_infos.Add(info);
                        }
                    }
                }
                conn.Close();
            }
            return list_infos;
        }


        public List<EntretienVoiture> get_ProchainsEntretiens()
        {
            List<EntretienVoiture> list_infos = new List<EntretienVoiture>();
            string sql = "SELECT EntretienVoitureId, Date, Km, Cout, Type, Description, Effectue FROM EntretienVoiture WHERE UtilisateurId = @paramUserId AND Effectue = 0";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUserId", this.utilisateurId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EntretienVoiture info = new EntretienVoiture();

                            info.EntretienVoitureId = reader.GetInt32(0);
                            info.Date = reader.GetDateTime(1);
                            info.Km = reader.GetInt32(2);
                            info.Cout = reader.GetInt32(3);
                            info.Type = reader.GetString(4);
                            info.Description = reader.GetString(5);
                            info.Effectue = reader.GetBoolean(6);

                            list_infos.Add(info);
                        }
                    }
                }
                conn.Close();
            }
            return list_infos;
        }


        //------------------------------------------------------------------------------------------------------------
        // INSERT
        //------------------------------------------------------------------------------------------------------------
        public void Add(EntretienVoiture conso)
        {
            //SELECT ConsoEauId, Annee, Type, Emplacement, Conso, Montant FROM ConsoEau
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO EntretienVoiture (Date, Km, Cout, Type, Description, Effectue, UtilisateurId) VALUES(@Date, @Km, @Cout, @Type, @Description, @Effectue, @UtilisateurId)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = conso.Date;
                cmd.Parameters.Add("@Km", SqlDbType.Int).Value = conso.Km;
                cmd.Parameters.Add("@Cout", SqlDbType.Int).Value = conso.Cout;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = conso.Type;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = conso.Description;
                cmd.Parameters.Add("@Effectue", SqlDbType.Bit).Value = conso.Effectue;
                cmd.Parameters.Add("@UtilisateurId", SqlDbType.Int).Value = this.utilisateurId;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
    }
}

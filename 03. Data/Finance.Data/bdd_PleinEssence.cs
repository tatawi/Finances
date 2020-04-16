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
    public class bdd_PleinEssence : bdd
    {
        public int utilisateurId;


        public bdd_PleinEssence()
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
        public List<PleinEssence> get_All()
        {
            List<PleinEssence> list_infos = new List<PleinEssence>();
            string sql = "SELECT PleinEssenceId, Date, Km, Litres, Prix, Type, Conso FROM PleinEssence WHERE UtilisateurId = @paramUserId";

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
                            PleinEssence info = new PleinEssence();

                            info.PleinEssenceId = reader.GetInt32(0);
                            info.Date = reader.GetDateTime(1);
                            info.Km = reader.GetInt32(2);
                            info.Litres = reader.GetInt32(3);
                            info.Prix = reader.GetInt32(4);
                            info.Type = reader.GetString(5);
                            info.Conso = reader.GetDecimal(6);

                            list_infos.Add(info);
                        }
                    }
                }
                conn.Close();
            }
            return list_infos;
        }

        //Retourne le dernier élement
        public PleinEssence get_Last()
        {
            PleinEssence info = new PleinEssence();
            string sql = "SELECT top(1) PleinEssenceId, Date, Km, Litres, Prix, Type, Conso FROM PleinEssence WHERE UtilisateurId = @paramUserId ORDER BY Date desc";

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
                            info.PleinEssenceId = reader.GetInt32(0);
                            info.Date = reader.GetDateTime(1);
                            info.Km = reader.GetInt32(2);
                            info.Litres = reader.GetInt32(3);
                            info.Prix = reader.GetInt32(4);
                            info.Type = reader.GetString(5);
                            info.Conso = reader.GetDecimal(6);
                        }
                    }
                }
                conn.Close();
            }
            return info;
        }


        //Retourne le premier élement
        public PleinEssence get_First()
        {
            PleinEssence info = new PleinEssence();
            string sql = "SELECT top(1) PleinEssenceId, Date, Km, Litres, Prix, Type, Conso FROM PleinEssence WHERE UtilisateurId = @paramUserId ORDER BY Date";

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
                            info.PleinEssenceId = reader.GetInt32(0);
                            info.Date = reader.GetDateTime(1);
                            info.Km = reader.GetInt32(2);
                            info.Litres = reader.GetInt32(3);
                            info.Prix = reader.GetInt32(4);
                            info.Type = reader.GetString(5);
                            info.Conso = reader.GetDecimal(6);
                        }
                    }
                }
                conn.Close();
            }
            return info;
        }

        //Retourne la somme des litres consommés
        public int get_SommeLitres()
        {
            int listres = 0 ;
            string sql = "SELECT Sum (Litres) FROM PleinEssence WHERE UtilisateurId = @paramUserId";

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
                            try
                            {
                                listres = reader.GetInt32(0);
                            }
                            catch (Exception)
                            {
                                listres = 0;
                            }
                        }
                    }
                }
                conn.Close();
            }
            return listres;
        }


        //Get all infos pour une année
        public List<PleinEssence> get_AllForYear(int annee)
        {
            List<PleinEssence> list_infos = new List<PleinEssence>();
            string sql = "SELECT PleinEssenceId, Date, Km, Litres, Prix, Type, Conso FROM PleinEssence WHERE UtilisateurId = @paramUserId AND Year(Date) = @paramDate";

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
                            PleinEssence info = new PleinEssence();

                            info.PleinEssenceId = reader.GetInt32(0);
                            info.Date = reader.GetDateTime(1);
                            info.Km = reader.GetInt32(2);
                            info.Litres = reader.GetInt32(3);
                            info.Prix = reader.GetInt32(4);
                            info.Type = reader.GetString(5);
                            info.Conso = reader.GetDecimal(6);

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
        public void Add(PleinEssence conso)
        {
            //SELECT ConsoEauId, Annee, Type, Emplacement, Conso, Montant FROM ConsoEau
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO PleinEssence (Date, Km, Litres, Prix, Type, Conso, UtilisateurId) VALUES(@Date, @Km, @Litres, @Prix, @Type, @Conso, @UtilisateurId)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = conso.Date;
                cmd.Parameters.Add("@Km", SqlDbType.Int).Value = conso.Km;
                cmd.Parameters.Add("@Litres", SqlDbType.Int).Value = conso.Litres;
                cmd.Parameters.Add("@Prix", SqlDbType.Int).Value = conso.Prix;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = conso.Type;
                cmd.Parameters.Add("@Conso", SqlDbType.Decimal).Value = conso.Conso;
                cmd.Parameters.Add("@UtilisateurId", SqlDbType.Int).Value = this.utilisateurId;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

    }
}

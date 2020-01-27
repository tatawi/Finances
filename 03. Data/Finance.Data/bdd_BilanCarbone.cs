using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Finance.Data.bdd
{
    public class bdd_BilanCarbone : bdd
    {

        public int utilisateurId;


        public bdd_BilanCarbone()
        {
        }

        public bdd_BilanCarbone(int paramUserName)
        {
            this.utilisateurId = paramUserName;
        }

        public void SetUser(int user)
        {
            this.utilisateurId = user;
        }


        //------------------------------------------------------------------------------------------------------------
        // GET 
        //------------------------------------------------------------------------------------------------------------

        //Get all infos
        public List<BilanCarbone> Get_All()
        {
            List<BilanCarbone> list_vals = new List<BilanCarbone>();
            string sql = "SELECT BilanCarboneId, Annee, Logement, Transports, Alimentation, Dechets, Achats, Finance, ServicePublique FROM BilanCarbone WHERE UtilisateurId = @paramUserId";

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
                            BilanCarbone info = new BilanCarbone();

                            info.BilanCarboneId = reader.GetInt32(0);
                            info.Annee = reader.GetInt32(1);
                            info.Logement = reader.GetDecimal(2);
                            info.Transports = reader.GetDecimal(3);
                            info.Alimentation = reader.GetDecimal(4);
                            info.Dechets = reader.GetDecimal(5);
                            info.Achats = reader.GetDecimal(6);
                            info.Finance = reader.GetDecimal(7);
                            info.ServicePublique = reader.GetDecimal(8);
                            info.Total = info.Logement + info.Transports + info.Alimentation + info.Dechets + info.Achats + info.Finance + info.ServicePublique;


                            list_vals.Add(info);
                        }
                    }
                }
                conn.Close();
            }
            return list_vals;
        }

        //Get info année
        public BilanCarbone Get_BilanCarboneForYear(int annee)
        {
            BilanCarbone info = new BilanCarbone();
            string sql = "SELECT BilanCarboneId, Annee, Logement, Transports, Alimentation, Dechets, Achats, Finance, ServicePublique FROM BilanCarbone WHERE UtilisateurId = @paramUserId AND Annee = @paramDate";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUserId", this.utilisateurId);
                    cmd.Parameters.AddWithValue("paramDate", annee);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            info = new BilanCarbone();
                            info.BilanCarboneId = reader.GetInt32(0);
                            info.Annee = reader.GetInt32(1);
                            info.Logement = reader.GetDecimal(2);
                            info.Transports = reader.GetDecimal(3);
                            info.Alimentation = reader.GetDecimal(4);
                            info.Dechets = reader.GetDecimal(5);
                            info.Achats = reader.GetDecimal(6);
                            info.Finance = reader.GetDecimal(7);
                            info.ServicePublique = reader.GetDecimal(8);
                            info.Total = info.Logement + info.Transports + info.Alimentation + info.Dechets + info.Achats + info.Finance + info.ServicePublique;

                        }
                    }
                }
                conn.Close();
            }
            return info;
        }


        //------------------------------------------------------------------------------------------------------------
        // INSERT
        //------------------------------------------------------------------------------------------------------------
        public void Add_BilanCarbone(BilanCarbone info)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO BilanCarbone (Annee, Logement, Transports, Alimentation, Dechets, Achats, Finance, ServicePublique, UtilisateurId) VALUES(@Annee, @Logement, @Transports, @Alimentation, @Dechets, @Achats, @Finance, @ServicePublique, @paramUserId)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Annee", SqlDbType.Int).Value = info.Annee;
                cmd.Parameters.Add("@Logement", SqlDbType.Decimal).Value = info.Logement;
                cmd.Parameters.Add("@Transports", SqlDbType.Decimal).Value = info.Transports;
                cmd.Parameters.Add("@Alimentation", SqlDbType.Decimal).Value = info.Alimentation;
                cmd.Parameters.Add("@Dechets", SqlDbType.Decimal).Value = info.Dechets;
                cmd.Parameters.Add("@Achats", SqlDbType.Decimal).Value = info.Achats;
                cmd.Parameters.Add("@Finance", SqlDbType.Decimal).Value = info.Finance;
                cmd.Parameters.Add("@ServicePublique", SqlDbType.Decimal).Value = info.ServicePublique;
                cmd.Parameters.Add("@paramUserId", SqlDbType.VarChar).Value = this.utilisateurId;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        //------------------------------------------------------------------------------------------------------------
        // UPDATE
        //------------------------------------------------------------------------------------------------------------
        public void Maj_BilanCarbone(BilanCarbone bilan)
        {
            //SELECT ConsoEauId, Annee, Type, Emplacement, Conso, Montant FROM ConsoEau
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "UPDATE BilanCarbone SET Logement=@Logement, Transports=@Transports, Alimentation=@Alimentation, Dechets=@Dechets," +
                    " Achats=@Achats, Finance=@Finance, ServicePublique=@ServicePublique WHERE Annee=@Annee AND UtilisateurId=@paramUserId";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Logement", SqlDbType.Decimal).Value = bilan.Logement;
                cmd.Parameters.Add("@Transports", SqlDbType.Decimal).Value = bilan.Transports;
                cmd.Parameters.Add("@Alimentation", SqlDbType.Decimal).Value = bilan.Alimentation;
                cmd.Parameters.Add("@Dechets", SqlDbType.Decimal).Value = bilan.Dechets;
                cmd.Parameters.Add("@Achats", SqlDbType.Decimal).Value = bilan.Achats;
                cmd.Parameters.Add("@Finance", SqlDbType.Decimal).Value = bilan.Finance;
                cmd.Parameters.Add("@ServicePublique", SqlDbType.Decimal).Value = bilan.ServicePublique;
                cmd.Parameters.Add("@Annee", SqlDbType.Int).Value = bilan.Annee;
                cmd.Parameters.Add("@paramUserId", SqlDbType.VarChar).Value = this.utilisateurId;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }



        //------------------------------------------------------------------------------------------------------------
        // AUTRE
        //------------------------------------------------------------------------------------------------------------
        public bool IsBilanCarbonePresent(BilanCarbone c)
        {
            bool isPresent = true;

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Count(*) FROM BilanCarbone WHERE Annee=@Annee AND UtilisateurId=@paramUserId", conn))
                {
                    cmd.Parameters.AddWithValue("Annee", c.Annee);
                    cmd.Parameters.AddWithValue("paramUserId", this.utilisateurId);

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    if (count == 0) isPresent = false;

                }
                conn.Close();
            }

            return isPresent;
        }
    }
}
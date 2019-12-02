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
    public class bdd_ConsoEau : bdd
    {
        public bdd_ConsoEau()
        {

        }




        //------------------------------------------------------------------------------------------------------------
        // GET 
        //------------------------------------------------------------------------------------------------------------

        //Get all infos pour une année
        public List<ConsoEau> get_AllListConsoEau()
        {
            List<ConsoEau> list_infos = new List<ConsoEau>();
            string sql = "SELECT ConsoEauId, Annee, Type, Emplacement, Consommation, Montant FROM ConsoEau";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ConsoEau info = new ConsoEau();

                            info.ConsoEauId = reader.GetInt32(0);
                            info.Annee = reader.GetInt32(1);
                            info.Type = reader.GetString(2);
                            info.Emplacement = reader.GetString(3);
                            info.Conso = reader.GetDecimal(4);
                            info.Montant = reader.GetDecimal(5);

                            list_infos.Add(info);
                        }
                    }
                }
                conn.Close();
            }
            return list_infos;
        }



        //Get all infos pour une année
        public List<ConsoEau> get_ListConsoEauForYear(int annee)
        {
            List<ConsoEau> list_infos = new List<ConsoEau>();
            string sql = "SELECT ConsoEauId, Annee, Type, Emplacement, Consommation, Montant FROM ConsoEau WHERE Annee = @paramDate";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramDate", annee);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ConsoEau info = new ConsoEau();

                            info.ConsoEauId = reader.GetInt32(0);
                            info.Annee = reader.GetInt32(1);
                            info.Type = reader.GetString(2);
                            info.Emplacement = reader.GetString(3);
                            info.Conso = reader.GetDecimal(4);
                            info.Montant = reader.GetDecimal(5);

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
        public void Add_ConsoEau(ConsoEau conso)
        {
            //SELECT ConsoEauId, Annee, Type, Emplacement, Conso, Montant FROM ConsoEau
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO ConsoEau (Annee, Type, Emplacement, Consommation, Montant) VALUES(@Annee, @Type, @Emplacement, @Conso, @Montant)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Annee", SqlDbType.Int).Value = conso.Annee;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = conso.Type;
                cmd.Parameters.Add("@Emplacement", SqlDbType.VarChar).Value = conso.Emplacement;
                cmd.Parameters.Add("@Conso", SqlDbType.Decimal).Value = conso.Conso;
                cmd.Parameters.Add("@Montant", SqlDbType.Decimal).Value = conso.Montant;


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }


        //------------------------------------------------------------------------------------------------------------
        // UPDATE
        //------------------------------------------------------------------------------------------------------------
        public void Maj_ConsoEau(ConsoEau conso)
        {
            //SELECT ConsoEauId, Annee, Type, Emplacement, Conso, Montant FROM ConsoEau
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "UPDATE ConsoEau SET Consommation=@Conso, Montant=@Montant WHERE Annee=@Annee AND Type=@Type AND Emplacement=@Emplacement";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Annee", SqlDbType.Int).Value = conso.Annee;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = conso.Type;
                cmd.Parameters.Add("@Emplacement", SqlDbType.VarChar).Value = conso.Emplacement;
                cmd.Parameters.Add("@Conso", SqlDbType.Decimal).Value = conso.Conso;
                cmd.Parameters.Add("@Montant", SqlDbType.Decimal).Value = conso.Montant;


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }




        //------------------------------------------------------------------------------------------------------------
        // AUTRE
        //------------------------------------------------------------------------------------------------------------
        public bool IsConsoPresente(ConsoEau c)
        {
            bool isPresent = true;

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Count(*) FROM ConsoEau WHERE Annee=@paramAnnee AND Type=@paramType AND Emplacement=@paramEmplacement", conn))
                {
                    cmd.Parameters.AddWithValue("paramAnnee", c.Annee);
                    cmd.Parameters.AddWithValue("paramType", c.Type);
                    cmd.Parameters.AddWithValue("paramEmplacement", c.Emplacement);


                    Int32 count = (Int32)cmd.ExecuteScalar();
                    if (count == 0) isPresent = false;

                }
                conn.Close();
            }

            return isPresent;
        }
    }
}

using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Finance.Data.bdd
{
    public class bdd_ConsoChauffage : bdd
    {
        public bdd_ConsoChauffage()
        { 

        }




        //------------------------------------------------------------------------------------------------------------
        // GET Infos
        //------------------------------------------------------------------------------------------------------------

        //Get all infos
        public List<ConsoChauffage> get_All()
        {
            List<ConsoChauffage> list_infos = new List<ConsoChauffage>();
            string sql = "SELECT ChauffageId, Annee, ConsoTotale ,ConsoPerso ,CoutTotal ,CoutPerso ,KwhTotal,KwhPerso ,CoutKwh FROM ConsoChauffage";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ConsoChauffage info = new ConsoChauffage();

                            info.ConsoChauffageId = reader.GetInt32(0);
                            info.Annee = reader.GetInt32(1);
                            info.ConsoTotale = reader.GetInt32(2);
                            info.ConsoPerso = reader.GetInt32(3);
                            info.CoutTotal = reader.GetInt32(4);
                            info.CoutPerso = reader.GetInt32(5);
                            info.KwhTotal = reader.GetInt32(6);
                            info.KwhPerso = reader.GetInt32(7);
                            info.CoutKwh = reader.GetDecimal(8);

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
        public void Add_Chauffage(ConsoChauffage info)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO ConsoChauffage (Annee, ConsoTotale, ConsoPerso, CoutTotal, CoutPerso, KwhTotal ,KwhPerso, CoutKwh) VALUES(@Annee, @ConsoTotale, @ConsoPerso, @CoutTotal, @CoutPerso, @KwhTotal, @KwhPerso, @CoutKwh)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Annee", SqlDbType.Int).Value = info.Annee;
                cmd.Parameters.Add("@ConsoTotale", SqlDbType.Int).Value = info.ConsoTotale;
                cmd.Parameters.Add("@ConsoPerso", SqlDbType.Int).Value = info.ConsoPerso;
                cmd.Parameters.Add("@CoutTotal", SqlDbType.Int).Value = info.CoutTotal;
                cmd.Parameters.Add("@CoutPerso", SqlDbType.Int).Value = info.CoutPerso;
                cmd.Parameters.Add("@KwhTotal", SqlDbType.Int).Value = info.KwhTotal;
                cmd.Parameters.Add("@KwhPerso", SqlDbType.Int).Value = info.KwhPerso;
                cmd.Parameters.Add("@CoutKwh", SqlDbType.Decimal).Value = info.CoutKwh;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        //------------------------------------------------------------------------------------------------------------
        // UPDATE
        //------------------------------------------------------------------------------------------------------------
        public void Maj_Chauffage(ConsoChauffage conso)
        {
            //SELECT ConsoEauId, Annee, Type, Emplacement, Conso, Montant FROM ConsoEau
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "UPDATE ConsoChauffage SET Annee=@Annee, ConsoTotale=@ConsoTotale, ConsoPerso=@ConsoPerso," +
                    " CoutTotal=@CoutTotal, CoutPerso=@CoutPerso, KwhTotal=@KwhTotal, KwhPerso=@KwhPerso, CoutKwh=@CoutKwh, " +
                    " WHERE Year(Date)=@Annee AND Month(Date)=@Mois  AND UserName=@user";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Annee", SqlDbType.Int).Value = conso.Annee;
                cmd.Parameters.Add("@ConsoTotale", SqlDbType.Int).Value = conso.ConsoTotale;
                cmd.Parameters.Add("@ConsoPerso", SqlDbType.Int).Value = conso.ConsoPerso;
                cmd.Parameters.Add("@CoutTotal", SqlDbType.Int).Value = conso.CoutTotal;
                cmd.Parameters.Add("@CoutPerso", SqlDbType.Int).Value = conso.CoutPerso;
                cmd.Parameters.Add("@KwhTotal", SqlDbType.Int).Value = conso.KwhTotal;
                cmd.Parameters.Add("@KwhPerso", SqlDbType.Int).Value = conso.KwhPerso;
                cmd.Parameters.Add("@CoutKwh", SqlDbType.Decimal).Value = conso.CoutKwh;



                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }




        //------------------------------------------------------------------------------------------------------------
        // AUTRE
        //------------------------------------------------------------------------------------------------------------
        public bool IsChauffagePresent(ConsoChauffage c)
        {
            bool isPresent = true;

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Count(*) FROM ConsoChauffage WHERE Annee=@Annee", conn))
                {
                    cmd.Parameters.AddWithValue("Annee", c.Annee);

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    if (count == 0) isPresent = false;

                }
                conn.Close();
            }

            return isPresent;
        }




    }
}
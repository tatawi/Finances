using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Finance.Data.bdd
{
    public class bdd_CategorieDepense : bdd
    {

        //------------------------------------------------------------------------------------------------------------
        // SELECT
        //------------------------------------------------------------------------------------------------------------

        //Get all infos
        public List<CategorieDepense> get_All()
        {
            List<CategorieDepense> list_infos = new List<CategorieDepense>();
            string sql = "SELECT CategorieDepenseId, libelle, CategorieId, SousCategorieId FROM CategorieDepense";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CategorieDepense info = new CategorieDepense();

                            info.CategorieDepenseId = reader.GetInt32(0);
                            info.Libelle = reader.GetString(1);
                            info.CategorieId = reader.GetInt32(2);
                            info.SousCategorieId = reader.GetInt32(3);
                            //info.UpdateCat();

                            list_infos.Add(info);
                        }
                    }
                }
                conn.Close();
            }
            return list_infos;
        }



        public bool IsLibellePresent(string libelle)
        {
            bool isPresent = true;

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Count(*) FROM CategorieDepense WHERE libelle=@paramLib", conn))
                {
                    cmd.Parameters.AddWithValue("paramLib", libelle);

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    if (count == 0) isPresent = false;

                }
                conn.Close();
            }

            return isPresent;
        }



        //------------------------------------------------------------------------------------------------------------
        // INSERT
        //------------------------------------------------------------------------------------------------------------
        public void Add_CategorieDepense(CategorieDepense corresp)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO CategorieDepense (libelle, CategorieId, SousCategorieId) VALUES(@lib, @catId, @ssCatId)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@lib", SqlDbType.VarChar).Value = corresp.Libelle;
                cmd.Parameters.Add("@catId", SqlDbType.Int).Value = corresp.CategorieId;
                cmd.Parameters.Add("@ssCatId", SqlDbType.Int).Value = corresp.SousCategorieId;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }


    }
}
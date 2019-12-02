using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Finance.Data.bdd
{
    public class bdd_InfosAppartement : bdd
    {
        public string userName;


        public bdd_InfosAppartement()
        {

        }


        public bdd_InfosAppartement(string paramUserName)
        {
            //this.connectionString = ConfigurationManager.ConnectionStrings["FinanceConnection"].ConnectionString;
            this.userName = paramUserName;
        }

        public void SetUser(string paramUserName)
        {
            this.userName = paramUserName;
        }

        //------------------------------------------------------------------------------------------------------------
        // GET Infos
        //------------------------------------------------------------------------------------------------------------


        public int Get_ValeurApptPourAnnee(int annee)
        {
            decimal montant = 0;
            string sql = "SELECT TOP(1) Montant FROM InfosAppartement WHERE UserName = @paramUser AND Year(Date) = @paramAnnee ORDER BY Date desc";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUser", this.userName);
                    cmd.Parameters.AddWithValue("paramAnnee", annee);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            montant = reader.GetDecimal(0)/2;
                        }
                    }
                }
                conn.Close();
            }
            return Decimal.ToInt32(montant);
        }

        //Get all infos
        public List<InfoAppartement> Get_InfosAppartementForType(string type)
        {
            List<InfoAppartement> list_infos = new List<InfoAppartement>();
            string sql = "SELECT InfosAppartementId, Montant, Date, Description, Type FROM InfosAppartement WHERE  UserName = @paramUser AND Type = @paramType ";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUser", this.userName);
                    cmd.Parameters.AddWithValue("paramType", type);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InfoAppartement info = new InfoAppartement();

                            info.InfoAppartementId = reader.GetInt32(0);
                            info.Montant = reader.GetDecimal(1);
                            info.Date = reader.GetDateTime(2);
                            info.Description = reader.GetString(3);
                            info.Type = reader.GetString(4);

                            list_infos.Add(info);
                        }
                    }
                }
                conn.Close();
            }
            return list_infos;
        }

        //Get info année
        public List<InfoAppartement> get_InfosAppartementForTypeAndYear(string type, int annee)
        {
            List<InfoAppartement> list_infos = new List<InfoAppartement>();
            string sql = "SELECT InfosAppartementId, Montant, Date, Description, Type FROM InfosAppartement WHERE  UserName = @paramUser AND Type = @paramType AND Year(Date) = @paramDate order by Date";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUser", this.userName);
                    cmd.Parameters.AddWithValue("paramType", type);
                    cmd.Parameters.AddWithValue("paramDate", annee);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InfoAppartement info = new InfoAppartement();

                            info.InfoAppartementId = reader.GetInt32(0);
                            info.Montant = reader.GetDecimal(1);
                            info.Date = reader.GetDateTime(2);
                            info.Description = reader.GetString(3);
                            info.Type = reader.GetString(4);

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
        public void Add_InfoAppartement(InfoAppartement info)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO InfosAppartement VALUES(@Montant, @Date, @Description, @UserName, @Type)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Montant", SqlDbType.Decimal).Value = info.Montant;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = info.Date;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = info.Description;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = this.userName;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = info.Type;


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }


    }
}
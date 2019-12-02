using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Finance.Data.bdd
{
    public class bdd_Electricite : bdd
    {

        public string userName;


        public bdd_Electricite()
        {
        }

        public bdd_Electricite(string paramUserName)
        {
            this.userName = paramUserName;
        }

        public void setUser(string user)
        {
            this.userName = user;
        }


        //------------------------------------------------------------------------------------------------------------
        // GET Infos
        //------------------------------------------------------------------------------------------------------------

        //Get all infos
        public List<Electricite> get_All()
        {
            List<Electricite> list_infos = new List<Electricite>();
            string sql = "SELECT ElectriciteId, Montant, Consommation, Date, Description, PrixKwh FROM ConsoElectricite WHERE  UserName = @paramUser";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUser", this.userName);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Electricite info = new Electricite();

                            info.ElectriciteId = reader.GetInt32(0);
                            info.Montant = reader.GetDecimal(1);
                            info.Consommation = reader.GetInt32(2);
                            info.Date = reader.GetDateTime(3);
                            info.Description = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            info.PrixKwh = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);

                            list_infos.Add(info);
                        }
                    }
                }
                conn.Close();
            }
            return list_infos;
        }

        //Get info année
        public List<Electricite> get_ElectriciteForYear(int annee)
        {
            List<Electricite> list_infos = new List<Electricite>();
            string sql = "SELECT ElectriciteId, Montant, Consommation, Date, Description, PrixKwh FROM ConsoElectricite WHERE  UserName = @paramUser AND Year(Date) = @paramDate order by Date";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUser", this.userName);
                    cmd.Parameters.AddWithValue("paramDate", annee);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Electricite info = new Electricite();

                            info.ElectriciteId = reader.GetInt32(0);
                            info.Montant = reader.GetDecimal(1);
                            info.Consommation = reader.GetInt32(2);
                            info.Date = reader.GetDateTime(3);
                            info.Description = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            info.PrixKwh = reader.IsDBNull(5) ? 0: reader.GetDecimal(5);

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
        public void Add_Electricite(Electricite info)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO ConsoElectricite (Montant, Date, Description, userName, Consommation, PrixKwh) VALUES(@Montant, @Date, @Description, @UserName, @Consommation, @PrixKwh)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Montant", SqlDbType.Decimal).Value = info.Montant;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = info.Date;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = info.Description;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = this.userName;
                cmd.Parameters.Add("@Consommation", SqlDbType.Int).Value = info.Consommation;
                cmd.Parameters.Add("@PrixKwh", SqlDbType.VarChar).Value = info.PrixKwh;


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }

        //------------------------------------------------------------------------------------------------------------
        // UPDATE
        //------------------------------------------------------------------------------------------------------------
        public void Maj_Electricite(Electricite conso)
        {
            //SELECT ConsoEauId, Annee, Type, Emplacement, Conso, Montant FROM ConsoEau
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "UPDATE ConsoElectricite SET Consommation=@Conso, Montant=@Montant, Date=@Date, UserName=@user WHERE Year(Date)=@Annee AND Month(Date)=@Mois  AND UserName=@user";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Conso", SqlDbType.Int).Value = conso.Consommation;
                cmd.Parameters.Add("@Montant", SqlDbType.Decimal).Value = conso.Montant;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = conso.Date;
                cmd.Parameters.Add("@Annee", SqlDbType.Int).Value = conso.Date.Value.Year;
                cmd.Parameters.Add("@Mois", SqlDbType.Int).Value = conso.Date.Value.Month;
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = this.userName;



                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }




        //------------------------------------------------------------------------------------------------------------
        // AUTRE
        //------------------------------------------------------------------------------------------------------------
        public bool IsElectricitePresente(Electricite c)
        {
            bool isPresent = true;

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Count(*) FROM ConsoElectricite WHERE Year(Date)=@Annee AND Month(Date)=@Mois  AND UserName=@user", conn))
                {
                    cmd.Parameters.AddWithValue("Annee", c.Date.Value.Year);
                    cmd.Parameters.AddWithValue("Mois", c.Date.Value.Month);
                    cmd.Parameters.AddWithValue("user", this.userName);


                    Int32 count = (Int32)cmd.ExecuteScalar();
                    if (count == 0) isPresent = false;

                }
                conn.Close();
            }

            return isPresent;
        }
    }
}
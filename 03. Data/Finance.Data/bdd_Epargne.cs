using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Finance.Data.bdd
{
    public class bdd_Epargne : bdd
    {

        public string userName;


        public bdd_Epargne(string paramUserName)
        {
            this.userName = paramUserName;
        }

        public bdd_Epargne()
        {
        }

        public void SetUser(string paramUserName)
        {
            this.userName = paramUserName;
        }



        //------------------------------------------------------------------------------------------------------------
        // GET Infos
        //------------------------------------------------------------------------------------------------------------

        //Get all infos
        public List<Ref_Compte> Get_Comptes()
        {
            List<Ref_Compte> list_cpt = new List<Ref_Compte>();
            string sql = "SELECT Ref_CompteId, Compte, IsActif, Montant FROM Ref_Compte WHERE  UserName = @paramUser";

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
                            Ref_Compte cpt = new Ref_Compte();

                            cpt.Ref_CompteId = reader.GetInt32(0);
                            cpt.Compte = reader.GetString(1);
                            cpt.IsActif = reader.GetBoolean(2);
                            cpt.Montant = reader.GetInt32(3);

                            list_cpt.Add(cpt);
                        }
                    }
                }
                conn.Close();
            }
            return list_cpt;
        }


        //Get all infos
        public Ref_Compte get_CompteFromId(int compteId)
        {
            Ref_Compte cpt = new Ref_Compte();
            string sql = "SELECT Ref_CompteId, Compte, IsActif, Montant FROM Ref_Compte WHERE  Ref_CompteId = @paramRef_CompteId";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramRef_CompteId", compteId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            cpt.Ref_CompteId = reader.GetInt32(0);
                            cpt.Compte = reader.GetString(1);
                            cpt.IsActif = reader.GetBoolean(2);
                            cpt.Montant = reader.GetInt32(3);
                        }
                    }
                }
                conn.Close();
            }
            return cpt;
        }

       

        public int Get_MontantCompte(int compteId)
        {
            int montant = 0;
            string sql = "SELECT Montant FROM Ref_Compte WHERE  Ref_CompteId = @paramRef_CompteId";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramRef_CompteId", compteId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            montant = reader.GetInt32(0);
                        }
                    }
                }
                conn.Close();
            }
            return montant;
        }

        //Get all infos
        public Epargne Get_DerniereEpargnePourAnnee(int compteId, int annee)
        {
            Epargne ep = new Epargne();
            string sql = "SELECT TOP(1) EpargneId, CompteId, Montant, Date FROM Epargne WHERE CompteId = @paramRef_CompteId AND YEAR(DATE)= @paramAnnee ORDER BY Date desc";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramRef_CompteId", compteId);
                    cmd.Parameters.AddWithValue("paramAnnee", annee);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            ep.EpargneId = reader.GetInt32(0);
                            ep.CompteId = reader.GetInt32(1);
                            ep.Montant = reader.GetInt32(2);
                            ep.Date = reader.GetDateTime(3);
                        }
                    }
                }
                conn.Close();
            }
            return ep;
        }


        //Get all infos
        public List<Epargne> get_EpargnesFromCompteId(int compteId)
        {
            List<Epargne> list_cpt = new List<Epargne>();
            string sql = "SELECT EpargneId, CompteId, Montant, Date FROM Epargne WHERE  CompteId = @paramCompteId";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramCompteId", compteId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Epargne cpt = new Epargne();

                            cpt.EpargneId = reader.GetInt32(0);
                            cpt.CompteId = reader.GetInt32(1);
                            cpt.Montant = reader.GetInt32(2);
                            cpt.Date = reader.GetDateTime(3);

                            cpt.Compte = this.get_CompteFromId(cpt.CompteId);
                            list_cpt.Add(cpt);
                        }
                    }
                }
                conn.Close();
            }
            return list_cpt;
        }






        public List<Epargne> get_EpargnesForYear(int annee)
        {
            List<Epargne> list_cpt = new List<Epargne>();
            string sql = "SELECT EpargneId, CompteId, Montant, Date FROM Epargne WHERE Year(Date) = @paramDate order by Date";

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
                            Epargne cpt = new Epargne();

                            cpt.EpargneId = reader.GetInt32(0);
                            cpt.CompteId = reader.GetInt32(1);
                            cpt.Montant = reader.GetInt32(2);
                            cpt.Date = reader.GetDateTime(3);

                            cpt.Compte = this.get_CompteFromId(cpt.CompteId);
                            list_cpt.Add(cpt);
                        }
                    }
                }
                conn.Close();
            }
            return list_cpt;
        }

        public List<Epargne> Get_EpargnesForYearAndDecember(int annee)
        {
            List<Epargne> list_cpt = new List<Epargne>();
            string sql = "SELECT EpargneId, CompteId, Montant, Date FROM Epargne WHERE Year(Date) = @paramDate OR (Year(Date) = @paramDate2 and Month(Date)=12) order by Date";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramDate", annee);
                    cmd.Parameters.AddWithValue("paramDate2", annee-1);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Epargne cpt = new Epargne();

                            cpt.EpargneId = reader.GetInt32(0);
                            cpt.CompteId = reader.GetInt32(1);
                            cpt.Montant = reader.GetInt32(2);
                            cpt.Date = reader.GetDateTime(3);

                            cpt.Compte = this.get_CompteFromId(cpt.CompteId);
                            list_cpt.Add(cpt);
                        }
                    }
                }
                conn.Close();
            }
            return list_cpt;
        }

        //------------------------------------------------------------------------------------------------------------
        // INSERT
        //------------------------------------------------------------------------------------------------------------

        public void Add_Operation(Epargne epargne)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Epargne (CompteId, Montant, Date) VALUES(@CompteId, @Montant, @Date)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@CompteId", SqlDbType.Int).Value = epargne.CompteId;
                cmd.Parameters.Add("@Montant", SqlDbType.Int).Value = epargne.Montant;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = epargne.Date;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            this.Update_MajCompte(epargne.CompteId, epargne.Montant.Value);
        }

        public void Add_Compte(Ref_Compte cpt)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Ref_Compte (Compte, UserName, IsActif, Montant) VALUES(@Compte, @UserName, @IsActif, @Montant)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Compte", SqlDbType.VarChar).Value = cpt.Compte;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = this.userName;
                cmd.Parameters.Add("@IsActif", SqlDbType.Bit).Value = cpt.IsActif;
                cmd.Parameters.Add("@Montant", SqlDbType.Int).Value = cpt.Montant;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }



        //------------------------------------------------------------------------------------------------------------
        // UPDATE
        //------------------------------------------------------------------------------------------------------------
        public void Del_UpdateCompteMontant(int compteId, int montant)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "UPDATE Ref_Compte SET Montant = @paramMontant WHERE CompteId = @paramId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@paramId", SqlDbType.Int).Value = compteId;
                cmd.Parameters.Add("@paramMontant", SqlDbType.Int).Value = montant;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }


        private void Update_MajCompte(int compteId, int montant)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "UPDATE Ref_Compte SET Montant = @paramMontant WHERE Ref_CompteId = @paramId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@paramId", SqlDbType.Int).Value = compteId;
                cmd.Parameters.Add("@paramMontant", SqlDbType.Int).Value = montant;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }



        //------------------------------------------------------------------------------------------------------------
        // DELETE
        //------------------------------------------------------------------------------------------------------------

        public void Del_Compte(int compteId)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "DELETE from Ref_Compte WHERE Ref_CompteId = @paramId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@paramId", SqlDbType.VarChar).Value = compteId;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }


    }
}
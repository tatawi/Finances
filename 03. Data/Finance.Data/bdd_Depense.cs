using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Finance.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Finance.Poco;
using Finance.Code.Enums;

namespace Finance.Data.bdd
{
    public class Bdd_Depense : bdd
    {
        public int userId;
        public string compte;


        public Bdd_Depense(int UtilisateurId, bool paramComptePerso)
        {
            this.userId = UtilisateurId;
            this.compte = paramComptePerso ? "perso" : "commun";
        }

        public Bdd_Depense()
        {

        }

        public void setUser (int UtilisateurId)
        {
            this.userId = UtilisateurId;
        }

        public void setCompte(bool isCptPerso)
        {
            this.compte = isCptPerso ? "perso" : "commun";
        }


        //------------------------------------------------------------------------------------------------------------
        // GET DEPENSES
        //------------------------------------------------------------------------------------------------------------

        public Depense get_DepenseFromId(int DepenseId)
        {
            Depense dep = new Depense();
            dep.DepenseId = DepenseId;

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Montant, Date, Libelle, Categorie, SousCategorie, Reconductible FROM Depense WHERE DepenseId=@paramDepenseId", conn))
                {
                    cmd.Parameters.AddWithValue("paramDepenseId", DepenseId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dep.Montant = reader.GetDecimal(0);
                            dep.Date = reader.GetDateTime(1);
                            dep.Libelle = reader.GetString(2);
                            dep.Categorie = reader.GetString(3);
                            dep.SousCategorie = reader.GetString(4);
                            dep.Reconductible = reader.GetString(5);
                        }
                    }
                }
                conn.Close();
            }

            return dep;
        }

        public List<Depense>get_DepensesMois(int annnee, int mois)
        {
            List<Depense> list_depenses = new List<Depense>();
            string sql = "SELECT DepenseId, Montant, Date, Libelle, Categorie, SousCategorie, Reconductible FROM Depense WHERE  UtilisateurId = @paramUserId AND compte = @paramCompte AND YEAR(Date) = @paramAnnee AND MONTH(Date)= @paramMois ";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUserId", this.userId);
                    cmd.Parameters.AddWithValue("paramCompte", this.compte);
                    cmd.Parameters.AddWithValue("paramAnnee", annnee);
                    cmd.Parameters.AddWithValue("paramMois", mois);
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Depense dep = new Depense();

                            dep.DepenseId = reader.GetInt32(0);
                            dep.Montant = reader.GetDecimal(1);
                            dep.Date = reader.GetDateTime(2);
                            dep.Libelle = reader.GetString(3);
                            dep.Categorie = reader.GetString(4);
                            dep.SousCategorie = reader.GetString(5);
                            dep.Reconductible = reader.GetString(6);

                            list_depenses.Add(dep);
                        }
                    }
                }
                conn.Close();
            }
            return list_depenses;
        }

        public List<Depense> get_DepensesMoisByCat(int annnee, int mois, string cat)
        {
            List<Depense> list_depenses = new List<Depense>();
            string sql = "SELECT DepenseId, Montant, Date, Libelle, Categorie, SousCategorie, Reconductible FROM Depense WHERE UtilisateurId = @paramUserId AND compte = @paramCompte AND Categorie = @paramCat AND YEAR(Date) = @paramAnnee AND MONTH(Date)= @paramMois";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUserId", this.userId);
                    cmd.Parameters.AddWithValue("paramCompte", this.compte);
                    cmd.Parameters.AddWithValue("paramAnnee", annnee);
                    cmd.Parameters.AddWithValue("paramMois", mois);
                    cmd.Parameters.AddWithValue("paramCat", cat);
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Depense dep = new Depense();

                            dep.DepenseId = reader.GetInt32(0);
                            dep.Montant = reader.GetDecimal(1);
                            dep.Date = reader.GetDateTime(2);
                            dep.Libelle = reader.GetString(3);
                            dep.Categorie = reader.GetString(4);
                            dep.SousCategorie = reader.GetString(5);
                            dep.Reconductible = reader.GetString(6);

                            list_depenses.Add(dep);
                        }
                    }
                }
                conn.Close();
            }
            return list_depenses;
        }

        public List<Depense> get_DepensesMoisBySousCat(int annnee, int mois, string sousCat)
        {
            List<Depense> list_depenses = new List<Depense>();
            string sql = "SELECT DepenseId, Montant, Date, Libelle, Categorie, SousCategorie, Reconductible FROM Depense WHERE UtilisateurId = @paramUserId AND compte = @paramCompte AND SousCategorie = @paramSsCat AND YEAR(Date)=@paramAnnee AND MONTH(Date)=@paramMois";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUserId", this.userId);
                    cmd.Parameters.AddWithValue("paramCompte", this.compte);
                    cmd.Parameters.AddWithValue("paramAnnee", annnee);
                    cmd.Parameters.AddWithValue("paramMois", mois);
                    cmd.Parameters.AddWithValue("paramSsCat", sousCat);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Depense dep = new Depense();

                            dep.DepenseId = reader.GetInt32(0);
                            dep.Montant = reader.GetDecimal(1);
                            dep.Date = reader.GetDateTime(2);
                            dep.Libelle = reader.GetString(3);
                            dep.Categorie = reader.GetString(4);
                            dep.SousCategorie = reader.GetString(5);
                            dep.Reconductible = reader.GetString(6);

                            list_depenses.Add(dep);
                        }
                    }
                }
                conn.Close();
            }
            return list_depenses;
        }

        public bool IsDepensePresente(Depense d, bool? forceComptePerso = false)
        {
            if (forceComptePerso.Value) this.compte = "perso";
            bool isPresent = true;

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Count(*) FROM Depense WHERE compte=@paramCompte AND UtilisateurId=@paramUserId AND Year(Date)=@paramDateY AND Month(Date)=@paramDateM AND Libelle=@paramLibelle AND Categorie=@paramCategorie AND SousCategorie=@paramSousCategorie", conn))
                {
                    cmd.Parameters.Add("@paramCompte", SqlDbType.VarChar).Value = this.compte;
                    cmd.Parameters.Add("@paramUserId", SqlDbType.VarChar).Value = this.userId;
                    cmd.Parameters.AddWithValue("paramDateY", d.Date.Value.Year);
                    cmd.Parameters.AddWithValue("paramDateM", d.Date.Value.Month);
                    cmd.Parameters.AddWithValue("paramLibelle", "[Commun] " + d.Libelle);
                    cmd.Parameters.AddWithValue("paramCategorie", d.Categorie);
                    cmd.Parameters.AddWithValue("paramSousCategorie", d.SousCategorie);

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    if (count==0) isPresent = false;

                }
                conn.Close();
            }

            return isPresent;
        }

        public bool IsDepensePresenteByDateAndLib(Depense d, bool? forceComptePerso = false)
        {
            if (forceComptePerso.Value) this.compte = "perso";
            bool isPresent = true;

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Count(*) FROM Depense WHERE compte=@paramCompte AND UtilisateurId=@paramUserId AND Year(Date)=@paramDateY AND Month(Date)=@paramDateM AND Day(Date)=@paramDateD AND Libelle=@paramLibelle", conn))
                {
                    cmd.Parameters.Add("@paramCompte", SqlDbType.VarChar).Value = this.compte;
                    cmd.Parameters.Add("@paramUserId", SqlDbType.VarChar).Value = this.userId;
                    cmd.Parameters.AddWithValue("paramDateY", d.Date.Value.Year);
                    cmd.Parameters.AddWithValue("paramDateM", d.Date.Value.Month);
                    cmd.Parameters.AddWithValue("paramDateD", d.Date.Value.Day);
                    cmd.Parameters.AddWithValue("paramLibelle",d.Libelle);

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    if (count == 0) isPresent = false;

                }
                conn.Close();
            }

            return isPresent;
        }


        //------------------------------------------------------------------------------------------------------------
        // CALCUL MONTANTS
        //------------------------------------------------------------------------------------------------------------

        public decimal get_MontantCatAnnee(int annee, string cat)
        {
            decimal montant = 0;
            string sql = "SELECT sum(Montant) FROM Depense WHERE UtilisateurId = @paramUserId AND compte = @paramCompte AND Categorie = @paramCat AND YEAR(Date) = @paramAnnee";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUserId", this.userId);
                    cmd.Parameters.AddWithValue("paramCompte", this.compte);
                    cmd.Parameters.AddWithValue("paramAnnee", annee);
                    cmd.Parameters.AddWithValue("paramCat", cat);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                montant = reader.GetDecimal(0);
                            }
                            catch (Exception ex)
                            {
                                montant = 0;
                            }
                        }
                    }
                }
                conn.Close();
            }
            return montant;
        }

        public decimal get_MontantCatMois(int annee, int mois, string cat)
        {
            decimal montant = 0;
            string sql = "SELECT sum(Montant) FROM Depense WHERE UtilisateurId = @paramUserId AND compte = @paramCompte AND Categorie = @paramCat AND YEAR(Date) = @paramAnnee AND MONTH(Date)= @paramMois";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUserId", this.userId);
                    cmd.Parameters.AddWithValue("paramCompte", this.compte);
                    cmd.Parameters.AddWithValue("paramAnnee", annee);
                    cmd.Parameters.AddWithValue("paramMois", mois);
                    cmd.Parameters.AddWithValue("paramCat", cat);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                montant = reader.GetDecimal(0);
                            }
                            catch (Exception ex)
                            {
                                montant = 0;
                            }
                        }
                    }
                }
                conn.Close();
            }
            return montant;
        }

        public decimal get_MontantSsCatAnnee(int annee, string ssCat)
        {
            decimal montant = 0;
            string sql = "SELECT sum(Montant) FROM Depense WHERE UtilisateurId = @paramUserId AND compte = @paramCompte AND SousCategorie = @paramSsCat AND YEAR(Date) = @paramAnnee";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUserId", this.userId);
                    cmd.Parameters.AddWithValue("paramCompte", this.compte);
                    cmd.Parameters.AddWithValue("paramAnnee", annee);
                    cmd.Parameters.AddWithValue("paramSsCat", ssCat);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                montant = reader.GetDecimal(0);
                            }
                            catch(Exception ex)
                            {
                                montant = 0;
                            }
                        }
                    }
                }
                conn.Close();
            }
            return montant;
        }

        public decimal get_MontantSsCatMois(int annee, int mois, string ssCat)
        {
            decimal montant = 0;
            string sql = "SELECT sum(Montant) FROM Depense WHERE UtilisateurId = @paramUserId AND compte = @paramCompte AND SousCategorie = @paramSsCat AND YEAR(Date) = @paramAnnee AND MONTH(Date)= @paramMois";

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("paramUserId", this.userId);
                    cmd.Parameters.AddWithValue("paramCompte", this.compte);
                    cmd.Parameters.AddWithValue("paramAnnee", annee);
                    cmd.Parameters.AddWithValue("paramMois", mois);
                    cmd.Parameters.AddWithValue("paramSsCat", ssCat);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                montant = reader.GetDecimal(0);
                            }
                            catch (Exception ex)
                            {
                                montant = 0;
                            }
                        }
                    }
                }
                conn.Close();
            }
            return montant;
        }



        //------------------------------------------------------------------------------------------------------------
        // INSERT
        //------------------------------------------------------------------------------------------------------------
        public void Add_Depense(Depense d, bool? forceComptePerso = false)
        {
            if (forceComptePerso.Value) this.compte = "perso";

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Depense VALUES(@Montant,@Date,@Libelle,@Categorie,@SousCategorie,@Reconductible,@compte, @UserNameId)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Montant", SqlDbType.Int).Value = d.Montant;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = d.Date;
                cmd.Parameters.Add("@Libelle", SqlDbType.VarChar).Value = d.Libelle;
                cmd.Parameters.Add("@Categorie", SqlDbType.VarChar).Value = d.Categorie;
                cmd.Parameters.Add("@SousCategorie", SqlDbType.VarChar).Value = d.SousCategorie;
                cmd.Parameters.Add("@Reconductible", SqlDbType.VarChar).Value = d.Reconductible;
                cmd.Parameters.Add("@compte", SqlDbType.VarChar).Value = this.compte;
                cmd.Parameters.Add("@UserNameId", SqlDbType.Int).Value = this.userId;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }

        //------------------------------------------------------------------------------------------------------------
        // CALCULS
        //------------------------------------------------------------------------------------------------------------

        //Calcul les champs calculables pour un mois donné
       /* public void calculer_TOTAUX(int annee, int mois)
        {
            List<Depense> list_DepenseMois = new List<Depense>();
            list_DepenseMois = this.get_DepensesMois(annee, mois);

            Calculate_TotalImpotsFor(annee, mois, list_DepenseMois);
            decimal dep = Calculate_TotalDepensesFor(annee, mois, list_DepenseMois);
            Calculate_SoldeFor(annee, mois, list_DepenseMois, dep);

        }*/

        //Calcul et met à jour la catégorie TOTAL IMPOTS pour le mois donné
        public void Calculate_TotalImpotsFor(int annee, int mois, List<Depense> list_DepenseMois)
        {
            double montantImpots = 0;

            #region calcul impots

            decimal sumMoisTvaH = (list_DepenseMois.Where(dep => dep.SousCategorie.Equals(EnumSousCategorie.Logement_Internet)
                                                            || dep.SousCategorie.Equals(EnumSousCategorie.Logement_Deco)
                                                            || dep.SousCategorie.Equals(EnumSousCategorie.Logement_Charges)
                                                            || dep.Categorie.Equals(EnumCategorie.Voiture)
                                                            || dep.Categorie.Equals(EnumCategorie.Transport)
                                                            || dep.Categorie.Equals(EnumCategorie.Loisirs)
                                                            || dep.Categorie.Equals(EnumCategorie.Voyages)
                                                            || dep.Categorie.Equals(EnumCategorie.Cadeaux)
                                                            || dep.Categorie.Equals(EnumCategorie.Achats)
                                                            || dep.Categorie.Equals(EnumCategorie.Vetements)
                                                            ).Sum(d => d.Montant).Value);
            montantImpots += ((0.20) * (double)sumMoisTvaH);

            decimal sumMoisTva = (list_DepenseMois.Where(dep => dep.Categorie.Equals(EnumCategorie.Alimentaire)
                                                            || dep.SousCategorie.Equals(EnumSousCategorie.Logement_Electricite))
                                                            .Sum(d => d.Montant).Value);
            montantImpots += ((0.07) * (double)sumMoisTva);

            decimal sumMoisImp = (list_DepenseMois.Where(dep => dep.Categorie.Equals(EnumCategorie.Impots)).Sum(d => d.Montant).Value);
            montantImpots += (double)sumMoisImp;
            #endregion

            Depense totalImpot = new Depense();
            totalImpot.Date = new DateTime(annee, mois, 25);
            totalImpot.Categorie = EnumCategorie.TOTALImpots;
            totalImpot.Libelle = EnumCategorie.TOTALImpots;
            totalImpot.SousCategorie = EnumSousCategorie.Vide;
            totalImpot.Montant = (decimal)montantImpots;
            totalImpot.Reconductible = "Non";
            this.Replace_Depense(totalImpot);
        }


        //Calcul et met à jour la catégorie TOTAL DEPENSES pour le mois donné
        public decimal Calculate_TotalDepensesFor(int annee, int mois, List<Depense> list_DepenseMois)
        {
            decimal totalDepenses = (list_DepenseMois.Where(deps => deps.Categorie.Equals(EnumCategorie.Logement)
                                                            || deps.Categorie.Equals(EnumCategorie.Alimentaire)
                                                            || deps.Categorie.Equals(EnumCategorie.Voiture)
                                                            || deps.Categorie.Equals(EnumCategorie.Transport)
                                                            || deps.Categorie.Equals(EnumCategorie.Loisirs)
                                                            || deps.Categorie.Equals(EnumCategorie.Voyages)
                                                            || deps.Categorie.Equals(EnumCategorie.Cadeaux)
                                                            || deps.Categorie.Equals(EnumCategorie.Achats)
                                                            || deps.Categorie.Equals(EnumCategorie.Vetements)
                                                            || deps.Categorie.Equals(EnumCategorie.Sante)
                                                            || deps.Categorie.Equals(EnumCategorie.Impots)
                                                            || deps.Categorie.Equals(EnumCategorie.FraisBancaires)
                                                            || deps.Categorie.Equals(EnumCategorie.Emprunts)
                                                            ).Sum(d => d.Montant).Value);

           
            Depense dep = new Depense();
            dep.Date = new DateTime(annee, mois, 25);
            dep.Categorie = EnumCategorie.TOTALDepenses;
            dep.Libelle = EnumCategorie.TOTALDepenses;
            dep.SousCategorie = EnumSousCategorie.Vide;
            dep.Montant = totalDepenses;
            dep.Reconductible = "Non";
            this.Replace_Depense(dep);

            return totalDepenses;
        }


        //Calcul et met à jour la catégorie SOLDE pour le mois donné
        public void Calculate_SoldeFor(int annee, int mois, List<Depense> list_DepenseMois, decimal totalDepenses)
        {
            decimal totalRevenus = (list_DepenseMois.Where(d => d.Categorie.Equals(EnumCategorie.Revenus)).Sum(d => d.Montant).Value);

            Depense dep = new Depense();
            dep.Date = new DateTime(annee, mois, 25);
            dep.Categorie = EnumCategorie.SOLDE;
            dep.Libelle = EnumCategorie.SOLDE;
            dep.SousCategorie = EnumSousCategorie.Vide;
            dep.Montant = (totalDepenses + totalRevenus);
            dep.Reconductible = "Non";
            this.Replace_Depense(dep);
        }



        //------------------------------------------------------------------------------------------------------------
        // Replace
        //------------------------------------------------------------------------------------------------------------
        public void Replace_Depense(Depense d)
        {

            Del_Depense(d.Date.Value.Year, d.Date.Value.Month, d.Categorie, d.SousCategorie);
            Add_Depense(d);

        }
        //------------------------------------------------------------------------------------------------------------
        // DELETE
        //------------------------------------------------------------------------------------------------------------
        private void Del_Depense(int annee, int mois, string Cat, string ssCat)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "DELETE from Depense WHERE UtilisateurId = @paramUserId AND compte = @paramCompte AND YEAR(Date) = @paramAnnee AND MONTH(Date) = @paramMois AND Categorie= @paramCat AND SousCategorie = @paramSsCat";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("paramUserId", this.userId);
                cmd.Parameters.AddWithValue("paramCompte", this.compte);
                cmd.Parameters.Add("@paramAnnee", SqlDbType.Int).Value = annee;
                cmd.Parameters.Add("@paramMois", SqlDbType.Int).Value = mois;
                cmd.Parameters.Add("@paramCat", SqlDbType.VarChar).Value = Cat;
                cmd.Parameters.Add("@paramSsCat", SqlDbType.VarChar).Value = ssCat;
                

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }


        public void Del_Depense(int depenseid)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "DELETE from Depense WHERE DepenseId = @paramId";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@paramId", SqlDbType.VarChar).Value = depenseid;


                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();

            }
        }






    }
}
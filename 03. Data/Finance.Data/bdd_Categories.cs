using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Finance.Data;
using System.Data.SqlClient;
using System.Configuration;
using Finance.Poco;

namespace Finance.Data.bdd
{
    public class bdd_Categories : bdd
    {
        //public string connectionString;


        public bdd_Categories()
        {
            //this.connectionString = ConfigurationManager.ConnectionStrings["FinanceConnection"].ConnectionString;
            //string text = System.IO.File.ReadAllText(HostingEnvironment.MapPath(@"~/App_Data/conn.txt"));
            //this.connectionString = text;
        }


        public List<string> get_Categories()
        {
            List<string> list_categories = new List<string>();

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Nom FROM Ref_Categorie Order by Rang", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string val = reader.GetString(0);
                            list_categories.Add(val);
                        }
                    }
                }
                conn.Close();
            }

            return list_categories;
        }


        public bool isCategorie(string cat)
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Nom FROM Ref_Categorie WHERE Nom=@paramCategorie", conn))
                {
                    cmd.Parameters.AddWithValue("paramCategorie", cat);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetString(0);
                            if (result.Length>1)
                                return true;
                            else
                                return false;
                        }
                    }
                }
                conn.Close();
            }
            return false;
        }


        public string getCategorieFromSsCategorie(string ssCat)
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Categorie FROM Ref_SsCategorie WHERE Nom=@paramCategorie", conn))
                {
                    cmd.Parameters.AddWithValue("paramCategorie", ssCat);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetString(0);
                        }
                    }
                }
                conn.Close();
            }
            return "";
        }




        public List<string> get_SousCategoriesFromCategorieString(string categorie)
        {
            List<string> list_sscategories = new List<string>();

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Nom FROM Ref_SsCategorie WHERE Categorie=@paramCategorie", conn))
                {
                    cmd.Parameters.AddWithValue("paramCategorie", categorie);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string val = reader.GetString(0);
                            list_sscategories.Add(val);
                        }
                    }
                }
                conn.Close();
            }

            return list_sscategories;
        }


        public Ref_Categorie get_CategoriesFromString(string Categorie)
        {
            Ref_Categorie categories = new Ref_Categorie();

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Ref_CategorieId, Nom FROM Ref_Categorie WHERE Nom=@paramCategorieStr", conn))
                {
                    cmd.Parameters.AddWithValue("paramCategorieStr", Categorie);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Ref_CategorieId = reader.GetInt32(0);
                            categories.Nom = reader.GetString(1);

                        }
                    }
                }
                conn.Close();
            }

            return categories;
        }


        public Ref_SsCategorie get_SousCategoriesFromString(string ssCategorie)
        {
            Ref_SsCategorie sscategories = new Ref_SsCategorie();

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Ref_SsCategorieId, Nom, Categorie FROM Ref_SsCategorie WHERE Nom=@paramSsCategorieStr", conn))
                {
                    cmd.Parameters.AddWithValue("paramSsCategorieStr", ssCategorie);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sscategories.Ref_SsCategorieId = reader.GetInt32(0);
                            sscategories.Nom = reader.GetString(1);
                            sscategories.Categorie = reader.GetString(2);
                        }
                    }
                }
                conn.Close();
            }

            return sscategories;
        }

        public Ref_Categorie get_CategoriesFromCategorieId(int id)
        {
            Ref_Categorie cat = new Ref_Categorie();

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Nom FROM Ref_Categorie WHERE Ref_CategorieId=@paramCategorieId", conn))
                {
                    cmd.Parameters.AddWithValue("paramCategorieId", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cat.Nom = reader.GetString(0);
                        }
                    }
                }
                conn.Close();
            }

            return cat;
        }


        public Ref_SsCategorie get_SsCategoriesFromSsCategorieId(int id)
        {
            Ref_SsCategorie sscat = new Ref_SsCategorie();

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Nom, Categorie, rang FROM Ref_SsCategorie WHERE Ref_SsCategorieId=@paramSsCategorieId", conn))
                {
                    cmd.Parameters.AddWithValue("paramSsCategorieId", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sscat.Nom = reader.GetString(0);
                            sscat.Categorie = reader.GetString(1);
                           // sscat.rang = reader.GetInt16(2);
                        }
                    }
                }
                conn.Close();
            }

            return sscat;
        }







    }
}
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Finance.Data.bdd
{
    public class bdd_BilanCarboneDetails : bdd
    {

        public int utilisateurId;


        public bdd_BilanCarboneDetails()
        {
        }

        public bdd_BilanCarboneDetails(int paramUserName)
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


        //Get Bilan pour année
        public BilanCarboneDetails Get_BilanCarboneForYear(int annee)
        {
            BilanCarboneDetails info = new BilanCarboneDetails();
            string sql = "SELECT BilanCarboneDetailsId, Annee, UserName, NbPersonnes, Surface, ConsoElectricite, ConsoElectriciteVerte, ConsoGaz, " +
                "ConsoFioul, ConsoEau, KmVoiture, NbDansVoiture, ConsoVoiture, HeuresAvion, KmTrain, HeuresBus, HeuresMetro, ViandeBoeuf, " +
                "ViandePorc, ViandeVolaille, ViandePoisson, LaitageFromage, Laitages, lait, FruitsHorsSaison, FruitsAvion, FruitsSaison, " +
                "PlatsCuisines, FeculentsPain, FeculentsRiz, BoissonAlcool, BoissonSodas, EauBouteille, DechetsOrga, DechetsPapiers, " +
                "DechetsPlastiques, DechetsVerre, DechetsMetal, DechetsAutres, BiensManufactures, Vetements, Electro, Internet, Ordinateur, " +
                "Smartphone, AppPhoto, Television, BiensAutres, FinanceClassique, FinanceVerte, ServicePublic FROM BilanCarboneDetails " +
                "WHERE UtilisateurId = @paramUserId AND Annee = @paramDate";

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
                            info = new BilanCarboneDetails();
                            info.BilanCarboneDetailsId = reader.GetInt32(0);
                            info.Annee = reader.GetInt32(1);
                            info.UserName = reader.GetString(2);
                            info.NbPersonnes = reader.GetString(3);
                            info.Surface = reader.GetString(4);
                            info.ConsoElectricite = reader.GetString(5);
                            info.ConsoElectriciteVerte = reader.GetString(6);
                            info.ConsoGaz = reader.GetString(7);
                            info.ConsoFioul = reader.GetString(8);
                            info.ConsoEau = reader.GetString(9);
                            info.KmVoiture = reader.GetString(10);
                            info.NbDansVoiture = reader.GetString(11);
                            info.ConsoVoiture = reader.GetString(12);
                            info.HeuresAvion = reader.GetString(13);
                            info.KmTrain = reader.GetString(14);
                            info.HeuresBus = reader.GetString(15);
                            info.HeuresMetro = reader.GetString(16);
                            info.ViandeBoeuf = reader.GetString(17);
                            info.ViandePorc = reader.GetString(18);
                            info.ViandeVolaille = reader.GetString(19);
                            info.ViandePoisson = reader.GetString(20);
                            info.LaitageFromage = reader.GetString(21);
                            info.Laitages = reader.GetString(22);
                            info.lait = reader.GetString(23);
                            info.FruitsHorsSaison = reader.GetString(24);
                            info.FruitsAvion = reader.GetString(25);
                            info.FruitsSaison = reader.GetString(26);
                            info.PlatsCuisines = reader.GetString(27);
                            info.FeculentsPain = reader.GetString(28);
                            info.FeculentsRiz = reader.GetString(29);
                            info.BoissonAlcool = reader.GetString(30);
                            info.BoissonSodas = reader.GetString(31);
                            info.EauBouteille = reader.GetString(32);
                            info.DechetsOrga = reader.GetString(33);
                            info.DechetsPapiers = reader.GetString(34);
                            info.DechetsPlastiques = reader.GetString(35);
                            info.DechetsVerre = reader.GetString(36);
                            info.DechetsMetal = reader.GetString(37);
                            info.DechetsAutres = reader.GetString(38);
                            info.BiensManufactures = reader.GetString(39);
                            info.Vetements = reader.GetString(40);
                            info.Electro = reader.GetString(41);
                            info.Internet = reader.GetString(42);
                            info.Ordinateur = reader.GetString(43);
                            info.Smartphone = reader.GetString(44);
                            info.AppPhoto = reader.GetString(45);
                            info.Television = reader.GetString(46);
                            info.BiensAutres = reader.GetString(47);
                            info.FinanceClassique = reader.GetString(48);
                            info.FinanceVerte = reader.GetString(49);
                            info.ServicePublic = reader.GetString(50);

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
        public void Add_BilanCarbone(BilanCarboneDetails info)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO BilanCarboneDetails (" +
                "Annee, UtilisateurId, Surface, NbPersonnes, ConsoElectricite, ConsoElectriciteVerte, ConsoGaz, " +
                "ConsoFioul, ConsoEau, KmVoiture, NbDansVoiture, ConsoVoiture, HeuresAvion, KmTrain, HeuresBus, HeuresMetro, ViandeBoeuf, " +
                "ViandePorc, ViandeVolaille, ViandePoisson, LaitageFromage, Laitages, lait, FruitsHorsSaison, FruitsAvion, FruitsSaison, " +
                "PlatsCuisines, FeculentsPain, FeculentsRiz, BoissonAlcool, BoissonSodas, EauBouteille, DechetsOrga, DechetsPapiers, " +
                "DechetsPlastiques, DechetsVerre, DechetsMetal, DechetsAutres, BiensManufactures, Vetements, Electro, Internet, Ordinateur, " +
                "Smartphone, AppPhoto, Television, BiensAutres, FinanceClassique, FinanceVerte, ServicePublic) " +
                " VALUES(@Annee, @paramUserId, @Surface, @NbPersonnes, @ConsoElectricite, @ConsoElectriciteVerte, @ConsoGaz, @ConsoFioul, @ConsoEau, @KmVoiture," +
                " @NbDansVoiture, @ConsoVoiture, @HeuresAvion, @KmTrain, @HeuresBus, @HeuresMetro, @ViandeBoeuf, @ViandePorc, @ViandeVolaille," +
                " @ViandePoisson, @LaitageFromage, @Laitages, @lait, @FruitsHorsSaison, @FruitsAvion, @FruitsSaison, @PlatsCuisines," +
                " @FeculentsPain, @FeculentsRiz, @BoissonAlcool, @BoissonSodas, @EauBouteille, @DechetsOrga, @DechetsPapiers, @DechetsPlastiques," +
                " @DechetsVerre, @DechetsMetal, @DechetsAutres, @BiensManufactures, @Vetements, @Electro, @Internet, @Ordinateur, @Smartphone, " +
                "@AppPhoto, @Television, @BiensAutres, @FinanceClassique, @FinanceVerte, @ServicePublic)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Annee", SqlDbType.Int).Value = info.Annee;
                cmd.Parameters.Add("@paramUserId", SqlDbType.VarChar).Value = this.utilisateurId;
                cmd.Parameters.Add("@NbPersonnes", SqlDbType.VarChar).Value = info.NbPersonnes??"";
                cmd.Parameters.Add("@Surface", SqlDbType.VarChar).Value = info.Surface ?? "";
                cmd.Parameters.Add("@ConsoElectricite", SqlDbType.VarChar).Value = info.ConsoElectricite ?? "";
                cmd.Parameters.Add("@ConsoElectriciteVerte", SqlDbType.VarChar).Value = info.ConsoElectriciteVerte ?? "";
                cmd.Parameters.Add("@ConsoGaz", SqlDbType.VarChar).Value = info.ConsoGaz ?? "";
                cmd.Parameters.Add("@ConsoFioul", SqlDbType.VarChar).Value = info.ConsoFioul ?? "";
                cmd.Parameters.Add("@ConsoEau", SqlDbType.VarChar).Value = info.ConsoEau ?? "";
                cmd.Parameters.Add("@KmVoiture", SqlDbType.VarChar).Value = info.KmVoiture ?? "";
                cmd.Parameters.Add("@NbDansVoiture", SqlDbType.VarChar).Value = info.NbDansVoiture ?? "";
                cmd.Parameters.Add("@ConsoVoiture", SqlDbType.VarChar).Value = info.ConsoVoiture ?? "";
                cmd.Parameters.Add("@HeuresAvion", SqlDbType.VarChar).Value = info.HeuresAvion ?? "";
                cmd.Parameters.Add("@KmTrain", SqlDbType.VarChar).Value = info.KmTrain ?? "";
                cmd.Parameters.Add("@HeuresBus", SqlDbType.VarChar).Value = info.HeuresBus ?? "";
                cmd.Parameters.Add("@HeuresMetro", SqlDbType.VarChar).Value = info.HeuresMetro ?? "";
                cmd.Parameters.Add("@ViandeBoeuf", SqlDbType.VarChar).Value = info.ViandeBoeuf ?? "";
                cmd.Parameters.Add("@ViandePorc", SqlDbType.VarChar).Value = info.ViandePorc ?? "";
                cmd.Parameters.Add("@ViandeVolaille", SqlDbType.VarChar).Value = info.ViandeVolaille ?? "";
                cmd.Parameters.Add("@ViandePoisson", SqlDbType.VarChar).Value = info.ViandePoisson ?? "";
                cmd.Parameters.Add("@LaitageFromage", SqlDbType.VarChar).Value = info.LaitageFromage ?? "";
                cmd.Parameters.Add("@Laitages", SqlDbType.VarChar).Value = info.Laitages ?? "";
                cmd.Parameters.Add("@lait", SqlDbType.VarChar).Value = info.lait ?? "";
                cmd.Parameters.Add("@FruitsHorsSaison", SqlDbType.VarChar).Value = info.FruitsHorsSaison ?? "";
                cmd.Parameters.Add("@FruitsAvion", SqlDbType.VarChar).Value = info.FruitsAvion ?? "";
                cmd.Parameters.Add("@FruitsSaison", SqlDbType.VarChar).Value = info.FruitsSaison ?? "";
                cmd.Parameters.Add("@PlatsCuisines", SqlDbType.VarChar).Value = info.PlatsCuisines ?? "";
                cmd.Parameters.Add("@FeculentsPain", SqlDbType.VarChar).Value = info.FeculentsPain ?? "";
                cmd.Parameters.Add("@FeculentsRiz", SqlDbType.VarChar).Value = info.FeculentsRiz ?? "";
                cmd.Parameters.Add("@BoissonAlcool", SqlDbType.VarChar).Value = info.BoissonAlcool ?? "";
                cmd.Parameters.Add("@BoissonSodas", SqlDbType.VarChar).Value = info.BoissonSodas ?? "";
                cmd.Parameters.Add("@EauBouteille", SqlDbType.VarChar).Value = info.EauBouteille ?? "";
                cmd.Parameters.Add("@DechetsOrga", SqlDbType.VarChar).Value = info.DechetsOrga ?? "";
                cmd.Parameters.Add("@DechetsPapiers", SqlDbType.VarChar).Value = info.DechetsPapiers ?? "";
                cmd.Parameters.Add("@DechetsPlastiques", SqlDbType.VarChar).Value = info.DechetsPlastiques ?? "";
                cmd.Parameters.Add("@DechetsVerre", SqlDbType.VarChar).Value = info.DechetsVerre ?? "";
                cmd.Parameters.Add("@DechetsMetal", SqlDbType.VarChar).Value = info.DechetsMetal ?? "";
                cmd.Parameters.Add("@DechetsAutres", SqlDbType.VarChar).Value = info.DechetsAutres ?? "";
                cmd.Parameters.Add("@BiensManufactures", SqlDbType.VarChar).Value = info.BiensManufactures ?? "";
                cmd.Parameters.Add("@Vetements", SqlDbType.VarChar).Value = info.Vetements ?? "";
                cmd.Parameters.Add("@Electro", SqlDbType.VarChar).Value = info.Electro ?? "";
                cmd.Parameters.Add("@Internet", SqlDbType.VarChar).Value = info.Internet ?? "";
                cmd.Parameters.Add("@Ordinateur", SqlDbType.VarChar).Value = info.Ordinateur ?? "";
                cmd.Parameters.Add("@Smartphone", SqlDbType.VarChar).Value = info.Smartphone ?? "";
                cmd.Parameters.Add("@AppPhoto", SqlDbType.VarChar).Value = info.AppPhoto ?? "";
                cmd.Parameters.Add("@Television", SqlDbType.VarChar).Value = info.Television ?? "";
                cmd.Parameters.Add("@BiensAutres", SqlDbType.VarChar).Value = info.BiensAutres ?? "";
                cmd.Parameters.Add("@FinanceClassique", SqlDbType.VarChar).Value = info.FinanceClassique ?? "";
                cmd.Parameters.Add("@FinanceVerte", SqlDbType.VarChar).Value = info.FinanceVerte ?? "";
                cmd.Parameters.Add("@ServicePublic", SqlDbType.VarChar).Value = info.ServicePublic ?? "";

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        //------------------------------------------------------------------------------------------------------------
        // UPDATE
        //------------------------------------------------------------------------------------------------------------
        public void Maj_BilanCarbone(BilanCarboneDetails info)
        {
            //SELECT ConsoEauId, Annee, Type, Emplacement, Conso, Montant FROM ConsoEau
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                string sql = "UPDATE BilanCarboneDetails SET " +
                     "NbPersonnes=@NbPersonnes, Surface=@Surface, ConsoElectricite=@ConsoElectricite, ConsoElectriciteVerte=@ConsoElectriciteVerte, ConsoGaz=@ConsoGaz, " +
                    "ConsoFioul=@ConsoFioul, ConsoEau=@ConsoEau, KmVoiture=@KmVoiture, NbDansVoiture=@NbDansVoiture, ConsoVoiture=@ConsoVoiture, HeuresAvion=@HeuresAvion, KmTrain=@KmTrain, HeuresBus=@HeuresBus, HeuresMetro=@HeuresMetro, ViandeBoeuf=@ViandeBoeuf, " +
                    "ViandePorc=@ViandePorc, ViandeVolaille=@ViandeVolaille, ViandePoisson=@ViandePoisson, LaitageFromage=@LaitageFromage, Laitages=@Laitages, lait=@lait, FruitsHorsSaison=@FruitsHorsSaison, FruitsAvion=@FruitsAvion, FruitsSaison=@FruitsSaison, " +
                    "PlatsCuisines=@PlatsCuisines, FeculentsPain=@FeculentsPain, FeculentsRiz=@FeculentsRiz, BoissonAlcool=@BoissonAlcool, BoissonSodas=@BoissonSodas, EauBouteille=@EauBouteille, DechetsOrga=@DechetsOrga, DechetsPapiers=@DechetsPapiers, " +
                    "DechetsPlastiques=@DechetsPlastiques, DechetsVerre=@DechetsVerre, DechetsMetal=@DechetsMetal, DechetsAutres=@DechetsAutres, BiensManufactures=@BiensManufactures, Vetements=@Vetements, Electro=@Electro, Internet=@Internet, Ordinateur=@Ordinateur, " +
                    "Smartphone=@Smartphone, AppPhoto=@AppPhoto, Television=@Television, BiensAutres=@BiensAutres, FinanceClassique=@FinanceClassique, FinanceVerte=@FinanceVerte, ServicePublic=@ServicePublic " +
                    " WHERE Annee=@Annee AND UtilisateurId=@paramUserId";

                //{"The parameterized query '(@Annee int,@UserName varchar(6),@NbPersonnes varchar(1),@Surfac' expects the parameter '@Surface', which was not supplied."}

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Annee", SqlDbType.Int).Value = info.Annee;
                cmd.Parameters.Add("@paramUserId", SqlDbType.VarChar).Value = this.utilisateurId;
                cmd.Parameters.Add("@NbPersonnes", SqlDbType.VarChar).Value = info.NbPersonnes;
                cmd.Parameters.Add("@Surface", SqlDbType.VarChar).Value = info.Surface;
                cmd.Parameters.Add("@ConsoElectricite", SqlDbType.VarChar).Value = info.ConsoElectricite;
                cmd.Parameters.Add("@ConsoElectriciteVerte", SqlDbType.VarChar).Value = info.ConsoElectriciteVerte;
                cmd.Parameters.Add("@ConsoGaz", SqlDbType.VarChar).Value = info.ConsoGaz;
                cmd.Parameters.Add("@ConsoFioul", SqlDbType.VarChar).Value = info.ConsoFioul;
                cmd.Parameters.Add("@ConsoEau", SqlDbType.VarChar).Value = info.ConsoEau;
                cmd.Parameters.Add("@KmVoiture", SqlDbType.VarChar).Value = info.KmVoiture;
                cmd.Parameters.Add("@NbDansVoiture", SqlDbType.VarChar).Value = info.NbDansVoiture;
                cmd.Parameters.Add("@ConsoVoiture", SqlDbType.VarChar).Value = info.ConsoVoiture;
                cmd.Parameters.Add("@HeuresAvion", SqlDbType.VarChar).Value = info.HeuresAvion;
                cmd.Parameters.Add("@KmTrain", SqlDbType.VarChar).Value = info.KmTrain;
                cmd.Parameters.Add("@HeuresBus", SqlDbType.VarChar).Value = info.HeuresBus;
                cmd.Parameters.Add("@HeuresMetro", SqlDbType.VarChar).Value = info.HeuresMetro;
                cmd.Parameters.Add("@ViandeBoeuf", SqlDbType.VarChar).Value = info.ViandeBoeuf;
                cmd.Parameters.Add("@ViandePorc", SqlDbType.VarChar).Value = info.ViandePorc;
                cmd.Parameters.Add("@ViandeVolaille", SqlDbType.VarChar).Value = info.ViandeVolaille;
                cmd.Parameters.Add("@ViandePoisson", SqlDbType.VarChar).Value = info.ViandePoisson;
                cmd.Parameters.Add("@LaitageFromage", SqlDbType.VarChar).Value = info.LaitageFromage;
                cmd.Parameters.Add("@Laitages", SqlDbType.VarChar).Value = info.Laitages;
                cmd.Parameters.Add("@lait", SqlDbType.VarChar).Value = info.lait;
                cmd.Parameters.Add("@FruitsHorsSaison", SqlDbType.VarChar).Value = info.FruitsHorsSaison;
                cmd.Parameters.Add("@FruitsAvion", SqlDbType.VarChar).Value = info.FruitsAvion;
                cmd.Parameters.Add("@FruitsSaison", SqlDbType.VarChar).Value = info.FruitsSaison;
                cmd.Parameters.Add("@PlatsCuisines", SqlDbType.VarChar).Value = info.PlatsCuisines;
                cmd.Parameters.Add("@FeculentsPain", SqlDbType.VarChar).Value = info.FeculentsPain;
                cmd.Parameters.Add("@FeculentsRiz", SqlDbType.VarChar).Value = info.FeculentsRiz;
                cmd.Parameters.Add("@BoissonAlcool", SqlDbType.VarChar).Value = info.BoissonAlcool;
                cmd.Parameters.Add("@BoissonSodas", SqlDbType.VarChar).Value = info.BoissonSodas;
                cmd.Parameters.Add("@EauBouteille", SqlDbType.VarChar).Value = info.EauBouteille;
                cmd.Parameters.Add("@DechetsOrga", SqlDbType.VarChar).Value = info.DechetsOrga;
                cmd.Parameters.Add("@DechetsPapiers", SqlDbType.VarChar).Value = info.DechetsPapiers;
                cmd.Parameters.Add("@DechetsPlastiques", SqlDbType.VarChar).Value = info.DechetsPlastiques;
                cmd.Parameters.Add("@DechetsVerre", SqlDbType.VarChar).Value = info.DechetsVerre;
                cmd.Parameters.Add("@DechetsMetal", SqlDbType.VarChar).Value = info.DechetsMetal;
                cmd.Parameters.Add("@DechetsAutres", SqlDbType.VarChar).Value = info.DechetsAutres;
                cmd.Parameters.Add("@BiensManufactures", SqlDbType.VarChar).Value = info.BiensManufactures;
                cmd.Parameters.Add("@Vetements", SqlDbType.VarChar).Value = info.Vetements;
                cmd.Parameters.Add("@Electro", SqlDbType.VarChar).Value = info.Electro;
                cmd.Parameters.Add("@Internet", SqlDbType.VarChar).Value = info.Internet;
                cmd.Parameters.Add("@Ordinateur", SqlDbType.VarChar).Value = info.Ordinateur;
                cmd.Parameters.Add("@Smartphone", SqlDbType.VarChar).Value = info.Smartphone;
                cmd.Parameters.Add("@AppPhoto", SqlDbType.VarChar).Value = info.AppPhoto;
                cmd.Parameters.Add("@Television", SqlDbType.VarChar).Value = info.Television;
                cmd.Parameters.Add("@BiensAutres", SqlDbType.VarChar).Value = info.BiensAutres;
                cmd.Parameters.Add("@FinanceClassique", SqlDbType.VarChar).Value = info.FinanceClassique;
                cmd.Parameters.Add("@FinanceVerte", SqlDbType.VarChar).Value = info.FinanceVerte;
                cmd.Parameters.Add("@ServicePublic", SqlDbType.VarChar).Value = info.ServicePublic;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }



        //------------------------------------------------------------------------------------------------------------
        // AUTRE
        //------------------------------------------------------------------------------------------------------------
        public bool IsBilanCarbonePresent(BilanCarboneDetails c)
        {
            bool isPresent = true;

            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Count(*) FROM BilanCarboneDetails WHERE Annee=@Annee AND UtilisateurId=@paramUserId", conn))
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
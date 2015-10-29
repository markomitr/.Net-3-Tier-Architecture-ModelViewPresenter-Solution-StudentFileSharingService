using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL.Interface;
using ClassDLL.SysPart;

namespace DAL.DBAccess
{
    public class NasokaDB : IDBNasoki
    {
        //Kolekcija od parametri - ova objekt se prefla vo funciite od BazaDB
        LinkedList<SqlParameter> parametriKomanda;

        //SqlParametar objekt
        SqlParameter SqlParam;

        //DateSet za rezultat 
        DataSet dsKomanda;

        /// <summary>
        /// Dodavanje na nova nasoka vo baza.
        /// </summary>
        /// <param name="Ime">Ime na nasoka.</param>
        /// <param name="Opis">Opis na nasoka.</param>
        /// <param name="Oblast_ID">Oblast ID na koja pripagja nasokata.</param>
        /// <returns>Ishod od dodavanje na nasokata.</returns>
        public RezultatKomanda addNasoka(string Ime, string Opis, int Oblast_ID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @Ime  = Ime
                //Input Parametar
                SqlParam = new SqlParameter("@Ime", SqlDbType.NVarChar);
                SqlParam.Value = Ime;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Opis = Opis
                //Input Parametar
                SqlParam = new SqlParameter("@Opis", SqlDbType.NVarChar);
                SqlParam.Value = Opis;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @Oblast_ID = Oblast_ID
                //Input Parametar
                SqlParam = new SqlParameter("@Oblast_ID", SqlDbType.Int);
                SqlParam.Value = Oblast_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);



                //Parametar za @StatusOUT   
                //Output Parametar
                //SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                //SqlParam.Direction = ParameterDirection.Output;
                //SqlParam.Value = "OUTPUT";
                //SqlParam.Size = 50;
                //parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajNasoka", sqlCn: null);

                //string pricina = parametriKomanda.Last.Value.Value.ToString();


                //if (pricina.ToUpper() == "POSTOI")
                //{
                //    //Korisnikot veke postoi
                //    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                //    rezultat.Pricina = "Veke postoi takov korisnik";

                //}
                //else
                //{
                //    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                //}
                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;

                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                rezultat.Pricina = ex.Message;
                return rezultat;
            }
        }

        /// <summary>
        /// Dodavanje na nasoka vo baza.
        /// </summary>
        /// <param name="nasokaObj">Nasoka koja kje bide dodadena vo baza.</param>
        /// <returns>Ishod od dodavanje.</returns>
        public RezultatKomanda addNasoka(Nasoka nasokaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                if (nasokaObj != null)
                {
                    rezultat = addNasoka(nasokaObj.Ime, nasokaObj.Opis, nasokaObj.Oblast_ID);
                }
                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                rezultat.Pricina = ex.Message;
                return rezultat;
            }
        }

        /// <summary>
        /// Ureduvanje na Nasoka vo baza.
        /// </summary>
        /// <param name="ID">ID na nasoka koja kje se ureduva.</param>
        /// <param name="Oblast_ID">Oblast na koja pripagja nasokata.</param>
        /// <param name="Ime">Ime na nasoka.</param>
        /// <param name="Opis">Opis na nasoka.</param>
        /// <returns>Ishod od ureduvanje na nasoka.</returns>
        public RezultatKomanda updateNasoka(int ID, int Oblast_ID, string Ime, string Opis)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @ID =ID 
                //Input Parametar
                SqlParam = new SqlParameter("@ID", SqlDbType.Int);
                SqlParam.Value = ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Ime  = Ime
                //Input Parametar
                SqlParam = new SqlParameter("@Ime", SqlDbType.NVarChar);
                SqlParam.Value = Ime;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Opis = Opis
                //Input Parametar
                SqlParam = new SqlParameter("@Opis", SqlDbType.NVarChar);
                SqlParam.Value = Opis;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @Oblast_ID = Oblast_ID
                //Input Parametar
                SqlParam = new SqlParameter("@Oblast_ID", SqlDbType.Int);
                SqlParam.Value = Oblast_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);



                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_IzmeniNasoka", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Ne postoi taa nasoka
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi taa nasoka.";

                }

                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                rezultat.Pricina = ex.Message;
                return rezultat;
            }
        }

        /// <summary>
        /// Ureduvanje na nasoka
        /// </summary>
        /// <param name="nasokaObj">Objekt koj kje bide ureden.</param>
        /// <returns>Ishod od ureduvanjeto na nasoka.</returns>
        public RezultatKomanda updateNasoka(Nasoka nasokaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                if (nasokaObj != null)
                {
                    rezultat = updateNasoka(nasokaObj.NasokaID, nasokaObj.Oblast_ID, nasokaObj.Ime, nasokaObj.Opis);
                }
                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                rezultat.Pricina = ex.Message;
                return rezultat;
            }
        }

        /// <summary>
        /// Brisenje na nasoka od baza.
        /// </summary>
        /// <param name="ID">ID na nasoka koja kje bide izbrisana.</param>
        /// <returns>Ishod od brisenje na nasoka.</returns>
        public RezultatKomanda deleteNasoka(int ID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @ID  = ID
                //Input Parametar
                SqlParam = new SqlParameter("@ID", SqlDbType.Int);
                SqlParam.Value = ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_BrisiNasoka", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Ne postoi taa nasoka
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi taa nasoka";

                }
                

                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                rezultat.Pricina = ex.Message;
                return rezultat;
            }
        }

        /// <summary>
        /// Brisenje na nasoka od baza.
        /// </summary>
        /// <param name="nasokaObj">Nasoka koja treba da bide izbrisana.</param>
        /// <returns>Ishod od brisenje na nasoka.</returns>
        public RezultatKomanda deleteNasoka(Nasoka nasokaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
       
            try
            {
                if (nasokaObj != null)
                {
                    rezultat = deleteNasoka(nasokaObj.NasokaID);
                }
                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                rezultat.Pricina = ex.Message;
                return rezultat;
            }
        }

        /// <summary>
        /// Prebaruvanje na nasoka spored ID
        /// </summary>
        /// <param name="ID">ID na nasoka koja se prebaruva.</param>
        /// <param name="nasokaObj">NasokaObj objekt koj se menuva po referenca.</param>
        /// <returns></returns>
        public RezultatKomanda getNasoka(int ID, ref Nasoka nasokaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @ID  = ID
                //Input Parametar
                SqlParam = new SqlParameter("@ID", SqlDbType.Int);
                SqlParam.Value = ID;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniNasoka1", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    DataRow red = dsKomanda.Tables[0].Rows[0];

                    nasokaObj = new Nasoka();
                    nasokaObj.NasokaID = BazaDB.DataRowVoInt(red, "ID");
                    nasokaObj.Oblast_ID = BazaDB.DataRowVoInt(red, "Oblast_ID");
                    nasokaObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                    nasokaObj.Opis = BazaDB.DataRowVoString(red, "Opis");
                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    rezultat.Pricina = "Ne postoi takva nasoka - ID";
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                }
                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Pricina = ex.Message;
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                return rezultat;
            }

        }

        public RezultatKomanda getNasoki(ref List<Nasoka> nasokiLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniNasoki8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    nasokiLista = new List<Nasoka>();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {

                        Nasoka nasokaObj = new Nasoka();
                        nasokaObj.NasokaID = BazaDB.DataRowVoInt(red, "ID");
                        nasokaObj.Oblast_ID = BazaDB.DataRowVoInt(red, "Oblast_ID");
                        nasokaObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                        nasokaObj.Opis = BazaDB.DataRowVoString(red, "Opis");


                        nasokiLista.Add(nasokaObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu edna nasoka
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema Nasoki";
                }
                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                rezultat.Pricina = ex.Message;
                return rezultat;
            }
        }

        public RezultatKomanda getNasokiPoOblast(int Oblast_ID, ref List<Nasoka> nasokiLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @Oblast_ID = Oblast_ID
                //Input Parametar
                SqlParam = new SqlParameter("@Oblast_ID", SqlDbType.Int);
                SqlParam.Value = Oblast_ID;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniNasoki8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    nasokiLista = new List<Nasoka>();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {

                        Nasoka nasokaObj = new Nasoka();
                        nasokaObj.NasokaID = BazaDB.DataRowVoInt(red, "ID");
                        nasokaObj.Oblast_ID = BazaDB.DataRowVoInt(red, "Oblast_ID");
                        nasokaObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                        nasokaObj.Opis = BazaDB.DataRowVoString(red, "Opis");


                        nasokiLista.Add(nasokaObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu edna nasoka
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema Nasoki";
                }
                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                rezultat.Pricina = ex.Message;
                return rezultat;
            }
        }


        //Da se vidi kaj da se stavat
        //------------------------------
        public RezultatKomanda addPredmetPoNasoka(int Nasoka_ID, int Predmet_ID, string Ime, string Kod, int Krediti)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();


                //Parametar za @Nasoka_ID =Nasoka_ID 
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = Nasoka_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Predmet_ID =Predmet_ID 
                //Input Parametar
                SqlParam = new SqlParameter("@Predmet_ID", SqlDbType.Int);
                SqlParam.Value = Predmet_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Ime  = Ime
                //Input Parametar
                SqlParam = new SqlParameter("@Ime", SqlDbType.NVarChar);
                SqlParam.Value = Ime;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Kod = Kod
                //Input Parametar
                SqlParam = new SqlParameter("@Kod", SqlDbType.NVarChar);
                SqlParam.Value = Kod;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @TipPredmet_ID = TipPredmet_ID
                //Input Parametar
                SqlParam = new SqlParameter("@TipPredmet_ID", SqlDbType.Int);
                SqlParam.Value = 1;
                parametriKomanda.AddLast(SqlParam);

                
                //Parametar za @Krediti = Krediti
                //Input Parametar
                SqlParam = new SqlParameter("@Krediti", SqlDbType.SmallInt);
                SqlParam.Value = Krediti;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);



                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajNasokaPredmet", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();


                if (pricina.ToUpper() == "POSTOI")
                {
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Veke postoi za taa nasoka takov predmet";

                }
                else
                {
                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                rezultat.Pricina = ex.Message;
                return rezultat;
            }
        }

        public RezultatKomanda getPredmetiPoNasoka(int Nasoka_ID, ref List<PredmetNasoka> predmetiPoNasokaLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();


                //Parametar za @Nasoka_ID =Nasoka_ID 
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = Nasoka_ID;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniNasokaPredmeti8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    predmetiPoNasokaLista = new List<PredmetNasoka>();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {

                        PredmetNasoka pnObj = new PredmetNasoka();
                        pnObj.NasokaID = BazaDB.DataRowVoInt(red, "NasokiID");
                        pnObj.NasokaIme = BazaDB.DataRowVoString(red, "NasokiIme");
                        pnObj.PredmetID = BazaDB.DataRowVoInt(red, "PredmetiID");
                        pnObj.PredmetIme = BazaDB.DataRowVoString(red, "PredmetiIme");
                        pnObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                        pnObj.Kod = BazaDB.DataRowVoString(red, "Kod");
                        pnObj.Krediti = BazaDB.DataRowVoInt(red, "Krediti");
                        predmetiPoNasokaLista.Add(pnObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu edna nasoka
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema Predmeti za Nasoka";
                }
                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                rezultat.Pricina = ex.Message;
                return rezultat;
            }
        }

        public RezultatKomanda addDeloviZaPredmetPoNasoka(int Nasoka_ID, int Predmet_ID, int Delovi_ID, int Stuff_ID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();


                //Parametar za @Nasoka_ID =Nasoka_ID 
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = Nasoka_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Predmet_ID =Predmet_ID 
                //Input Parametar
                SqlParam = new SqlParameter("@Predmet_ID", SqlDbType.Int);
                SqlParam.Value = Predmet_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Delovi_ID =Delovi_ID 
                //Input Parametar
                SqlParam = new SqlParameter("@Delovi_ID", SqlDbType.Int);
                SqlParam.Value = Delovi_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Stuff_ID =Stuff_ID 
                //Input Parametar
                SqlParam = new SqlParameter("@Stuff_ID", SqlDbType.Int);
                SqlParam.Value = Stuff_ID;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);



                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajDeloviNasoka", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();


                if (pricina.ToUpper() == "POSTOI")
                {
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Veke postoi za taa nasoka-predmet takov del";

                }
                else
                {
                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                rezultat.Pricina = ex.Message;
                return rezultat;
            }
        }

        public RezultatKomanda getDeloviZaPredmetPoNasoka(int? Nasoka_ID, int? Predmet_ID, ref List<DeloviPredmetNasoka> delPredmetNasokaList)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                if (Nasoka_ID != null)
                {
                    //Parametar za @Nasoka_ID =Nasoka_ID 
                    //Input Parametar
                    SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                    SqlParam.Value = Nasoka_ID;
                    parametriKomanda.AddLast(SqlParam);
                }

                if (Predmet_ID != null)
                {
                    //Parametar za @Predmet_ID =Predmet_ID 
                    //Input Parametar
                    SqlParam = new SqlParameter("@Predmet_ID ", SqlDbType.Int);
                    SqlParam.Value = Predmet_ID;
                    parametriKomanda.AddLast(SqlParam);
                }

                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniDeloviNasoka8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    delPredmetNasokaList = new List<DeloviPredmetNasoka>();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {

                        DeloviPredmetNasoka dpnObj = new DeloviPredmetNasoka();
                        dpnObj.Del_ID = BazaDB.DataRowVoInt(red, "Del_ID");
                        dpnObj.Del_Ime = BazaDB.DataRowVoString(red, "Del_Ime");
                        dpnObj.Predmet_ID = BazaDB.DataRowVoInt(red, "Predmet_ID");
                        dpnObj.Predmet_Ime = BazaDB.DataRowVoString(red, "Predmet_Ime");
                        dpnObj.Nasoka_ID = BazaDB.DataRowVoInt(red, "Nasoka_ID");
                        dpnObj.Nasoka_Ime = BazaDB.DataRowVoString(red, "Nasoka_Ime");
                        dpnObj.Stuff_ID = BazaDB.DataRowVoInt(red, "Stuff_ID");
                        dpnObj.Aktiven = BazaDB.DataRowVoChar(red, "Aktiven");

                        delPredmetNasokaList.Add(dpnObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu edna nasoka
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema Delovi  za odbpran Predmet po  Nasoka";
                }
                return rezultat;
            }
            catch (Exception ex)
            {
                rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                rezultat.Pricina = ex.Message;
                return rezultat;
            }
        }
    }
}

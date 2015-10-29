using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ClassDLL.GreskiEX;
using ClassDLL.SysPart;
using DAL.Interface;
namespace DAL.DBAccess
{
    public class PredmetiNasokaDB : IDBPredmetiNasoka
    {
        //Kolekcija od parametri - ova objekt se prefla vo funciite od BazaDB
        LinkedList<SqlParameter> parametriKomanda;

        //SqlParametar objekt
        SqlParameter SqlParam;

        //DateSet za rezultat 
        DataSet dsKomanda;

        public RezultatKomanda addPredmetNasoka(int nasokaID, int predmetID, int tipPredmet)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @nasoka_ID  = nasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@nasoka_ID", SqlDbType.Int);
                SqlParam.Value = nasokaID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @predmet_ID  = predmetID
                //Input Parametar
                SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                SqlParam.Value = predmetID;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @predmet_ID  = predmetID
                //Input Parametar
                SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                SqlParam.Value = predmetID;
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
                    //Posti toj predmet za taa nasoka
                    //Posti Matematika na programski inzenerstvo
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Veke postoi predmetot za izbranata nasoka";

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

        public RezultatKomanda addPredmetNasoka(int nasokaID, int predmetID, int tipPredmet, string kod, int krediti, string ime)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @nasoka_ID  = nasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@nasoka_ID", SqlDbType.Int);
                SqlParam.Value = nasokaID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @predmet_ID  = predmetID
                //Input Parametar
                SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                SqlParam.Value = predmetID;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @predmet_ID  = predmetID
                //Input Parametar
                SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                SqlParam.Value = predmetID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @Kod  = kod
                //Input Parametar
                SqlParam = new SqlParameter("@Kod", SqlDbType.NVarChar);
                SqlParam.Value = kod;
                parametriKomanda.AddLast(SqlParam);



                //Parametar za @Krediti  = Krediti
                //Input Parametar
                SqlParam = new SqlParameter("@Krediti", SqlDbType.NVarChar);
                SqlParam.Value = krediti;
                parametriKomanda.AddLast(SqlParam);



                //Parametar za @Ime  = ime
                //Input Parametar
                SqlParam = new SqlParameter("@Ime", SqlDbType.NVarChar);
                SqlParam.Value = ime;
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
                    //Posti toj predmet za taa nasoka
                    //Posti Matematika na programski inzenerstvo
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Veke postoi predmetot za izbranata nasoka";

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

        public RezultatKomanda addPredmetNasoka(PredmetNasoka predmetNasokaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);

            try
            {
                if (predmetNasokaObj != null)
                {
                    rezultat = addPredmetNasoka(predmetNasokaObj.NasokaID, predmetNasokaObj.PredmetID, predmetNasokaObj.TipPredmet, predmetNasokaObj.Kod, predmetNasokaObj.Krediti, predmetNasokaObj.Ime);
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


        public RezultatKomanda updatePredmetNasoka(int nasokaID, int predmetID, int? tipPredmet, string kod, int? krediti, string ime)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @nasoka_ID  = nasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@nasoka_ID", SqlDbType.Int);
                SqlParam.Value = nasokaID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @predmet_ID  = predmetID
                //Input Parametar
                SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                SqlParam.Value = predmetID;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @predmet_ID  = predmetID
                //Input Parametar
                SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                SqlParam.Value = predmetID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);

                if (!String.IsNullOrEmpty(kod.Trim()))
                {
                    //Parametar za @Kod  = kod
                    //Input Parametar
                    SqlParam = new SqlParameter("@Kod", SqlDbType.NVarChar);
                    SqlParam.Value = kod;
                    parametriKomanda.AddLast(SqlParam);
                }

                if (krediti != null)
                {
                    //Parametar za @Krediti  = Krediti
                    //Input Parametar
                    SqlParam = new SqlParameter("@Krediti", SqlDbType.NVarChar);
                    SqlParam.Value = krediti;
                    parametriKomanda.AddLast(SqlParam);
                }

                if (!String.IsNullOrEmpty(ime.Trim()))
                {
                    //Parametar za @Ime  = ime
                    //Input Parametar
                    SqlParam = new SqlParameter("@Ime", SqlDbType.NVarChar);
                    SqlParam.Value = ime;
                    parametriKomanda.AddLast(SqlParam);
                }

                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_IzmeniNasokaPredmet", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();


                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Ne posti takov predmet/nasoka
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi toj predmet/nasoka.";

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
        public RezultatKomanda updatePredmetNasoka(PredmetNasoka predmetNasokaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);

            try
            {
                if (predmetNasokaObj != null)
                {
                    rezultat = updatePredmetNasoka(predmetNasokaObj.NasokaID, predmetNasokaObj.PredmetID, predmetNasokaObj.TipPredmet, predmetNasokaObj.Kod, predmetNasokaObj.Krediti, predmetNasokaObj.Ime);
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

        public RezultatKomanda deletePredmetNasoka(int nasokaID, int predmetID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @nasoka_ID  = nasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@nasoka_ID", SqlDbType.Int);
                SqlParam.Value = nasokaID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @predmet_ID  = predmetID
                //Input Parametar
                SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                SqlParam.Value = nasokaID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_BrisiNasokaPredmet", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Ne postoi toj predmet/nasoka
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi toj predmet/nasoka";

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

        public RezultatKomanda deletePredmetNasoka(PredmetNasoka predmetNasokaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);

            try
            {
                if (predmetNasokaObj != null)
                {
                    rezultat = deletePredmetNasoka(predmetNasokaObj.NasokaID, predmetNasokaObj.PredmetID);
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

        public RezultatKomanda getPredmetNasoka(int nasokaID, int predmetID, ref PredmetNasoka predmetNasokaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();


                //Parametar za @nasoka_ID  = nasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = nasokaID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @predmet_ID  = predmetID
                //Input Parametar
                SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                SqlParam.Value = predmetID;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniNasokaPredmeti8", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    DataRow red = dsKomanda.Tables[0].Rows[0];

                    predmetNasokaObj = new PredmetNasoka();
                    predmetNasokaObj.PredmetID = BazaDB.DataRowVoInt(red, "PredmetiID");
                    predmetNasokaObj.PredmetIme = BazaDB.DataRowVoString(red, "PredmetiIme");

                    predmetNasokaObj.NasokaID = BazaDB.DataRowVoInt(red, "NasokiID");
                    predmetNasokaObj.NasokaIme = BazaDB.DataRowVoString(red, "NasokiIme");

                    predmetNasokaObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                    predmetNasokaObj.Kod = BazaDB.DataRowVoString(red, "Kod");
                    predmetNasokaObj.Krediti = BazaDB.DataRowVoInt(red, "Krediti");
                    predmetNasokaObj.TipPredmet = BazaDB.DataRowVoInt(red, "TipPredmet_ID");
                    predmetNasokaObj.Aktiven = BazaDB.DataRowVoChar(red, "Aktiven");


                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {

                    rezultat.Pricina = "Ne postoi takov  predmetiID , nasokaID";
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

        public RezultatKomanda getPredmetiNasoka(int? nasokaID, int? predmetID, ref List<PredmetNasoka> predmetiLista)
        {


            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();
                if (nasokaID != null)
                {
                    //Parametar za @nasoka_ID  = nasokaID
                    //Input Parametar
                    SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                    SqlParam.Value = nasokaID;
                    parametriKomanda.AddLast(SqlParam);
                }

                if (predmetID != null)
                {
                    //Parametar za @predmet_ID  = predmetID
                    //Input Parametar
                    SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                    SqlParam.Value = predmetID;
                    parametriKomanda.AddLast(SqlParam);
                }

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniNasokaPredmeti8", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    predmetiLista = new List<PredmetNasoka>();
                    PredmetNasoka predmetNasokaObj;
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {
                        predmetNasokaObj = new PredmetNasoka();
                        predmetNasokaObj.PredmetID = BazaDB.DataRowVoInt(red, "PredmetiID");
                        predmetNasokaObj.PredmetIme = BazaDB.DataRowVoString(red, "PredmetiIme");

                        predmetNasokaObj.NasokaID = BazaDB.DataRowVoInt(red, "NasokiID");
                        predmetNasokaObj.NasokaIme = BazaDB.DataRowVoString(red, "NasokiIme");

                        predmetNasokaObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                        predmetNasokaObj.Kod = BazaDB.DataRowVoString(red, "Kod");
                        predmetNasokaObj.Krediti = BazaDB.DataRowVoInt(red, "Krediti");
                        predmetNasokaObj.TipPredmet = BazaDB.DataRowVoInt(red, "TipPredmet_ID");
                        predmetNasokaObj.Aktiven = BazaDB.DataRowVoChar(red, "Aktiven");

                        predmetiLista.Add(predmetNasokaObj);
                    }


                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {

                    rezultat.Pricina = "Ne postoi takov predmetid,nasokaID - ID";
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


        //del za pretlata na korisnici na odreden predmet
        #region KorisnikPredmet
        public RezultatKomanda addKorisnikPredmet(int nasokaID, int predmetID, string korisnikID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @nasoka_ID  = nasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@nasoka_ID", SqlDbType.Int);
                SqlParam.Value = nasokaID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @predmet_ID  = predmetID
                //Input Parametar
                SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                SqlParam.Value = predmetID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Korisnik_ID  = korisnikID
                //Input Parametar
                SqlParam = new SqlParameter("@Korisnik_ID", SqlDbType.NVarChar);
                SqlParam.Value = korisnikID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajKorisnikPredmet", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "POSTOI")
                {
                    //Korisnikot e veke pretplaten na toj predmet
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Korisnikot e veke pretplaten na toj predmet.";
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

        public RezultatKomanda addKorisnikPredmet(int nasokaID, int predmetID, Korisnik korisnikObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);

            try
            {
                if (korisnikObj != null)
                {
                    rezultat = addKorisnikPredmet(nasokaID, predmetID, korisnikObj.UserID);
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

        public RezultatKomanda addKorisnikPredmet(PredmetNasoka predmetNasokaObj, string korisnikID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);

            try
            {
                if (predmetNasokaObj != null)
                {
                    rezultat = addKorisnikPredmet(predmetNasokaObj.NasokaID, predmetNasokaObj.PredmetID, korisnikID);
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

        public RezultatKomanda addKorisnikPredmet(PredmetNasoka predmetNasokaObj, Korisnik korisnikObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);

            try
            {
                if (predmetNasokaObj != null && korisnikObj != null)
                {
                    rezultat = addKorisnikPredmet(predmetNasokaObj.NasokaID, predmetNasokaObj.PredmetID, korisnikObj.UserID);
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

        public RezultatKomanda deleteKorisnikPredmet(int nasokaID, int predmetID, string korisnikID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @nasoka_ID  = nasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@nasoka_ID", SqlDbType.Int);
                SqlParam.Value = nasokaID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @predmet_ID  = predmetID
                //Input Parametar
                SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                SqlParam.Value = predmetID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Korisnik_ID  = korisnikID
                //Input Parametar
                SqlParam = new SqlParameter("@Korisnik_ID", SqlDbType.NVarChar);
                SqlParam.Value = korisnikID;
                parametriKomanda.AddLast(SqlParam);

                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_BrisiKorisnikPredmet", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Korisnikot e veke pretplaten na toj predmet
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Korisnikot ne e pretplaten na toj predmet";
                }
                else if (pricina.ToUpper() == "NEAKTIVEN")
                {
                    //Korisnikot e neaktiven/izbrisan
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Korisnikot e veke izbrisan od predmetot.";
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

        public RezultatKomanda deleteKorisniciOdPredmet(int nasokaID, int predmetID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @nasoka_ID  = nasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@nasoka_ID", SqlDbType.Int);
                SqlParam.Value = nasokaID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @predmet_ID  = predmetID
                //Input Parametar
                SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                SqlParam.Value = predmetID;
                parametriKomanda.AddLast(SqlParam);

                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_BrisiKorisniciPredmet", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

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

        public RezultatKomanda deleteKorisniciOdPredmet(PredmetNasoka predmetNasokaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);

            try
            {
                if (predmetNasokaObj != null)
                {
                    rezultat = deleteKorisniciOdPredmet(predmetNasokaObj.NasokaID, predmetNasokaObj.PredmetID);
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

        public RezultatKomanda getKorisniciPredmet(int nasokaID, int predmetID, ref List<Korisnik> korLista)
        {

            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @nasoka_ID  = nasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = nasokaID;
                parametriKomanda.AddLast(SqlParam);



                //Parametar za @predmet_ID  = predmetID
                //Input Parametar
                SqlParam = new SqlParameter("@predmet_ID", SqlDbType.Int);
                SqlParam.Value = predmetID;
                parametriKomanda.AddLast(SqlParam);


                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniKorisnikPredmet8", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    korLista = new List<Korisnik>();
                    Korisnik korObj;
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {
                        korObj = new Korisnik();
                        korObj.UserID = BazaDB.DataRowVoString(red, "K_UserID");
                        korObj.Ime = BazaDB.DataRowVoString(red, "K_Ime");
                        korObj.Prezime = BazaDB.DataRowVoString(red, "K_Prezime");
                        korObj.Lozinka = BazaDB.DataRowVoString(red, "K_Lozinka");
                        korObj.KorTip_ID = BazaDB.DataRowVoString(red, "K_KorTip_ID");
                        korObj.DodadenNa = BazaDB.DataRowVoDateTime(red, "K_DodadenNa");
                        korObj.AktivenChar = BazaDB.DataRowVoChar(red, "K_Aktiven");

                        korLista.Add(korObj);
                    }


                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    rezultat.Pricina = "Ne pretplateni korisnici na predmetot.";
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

        public RezultatKomanda getKorisniciPredmet(PredmetNasoka predmetNasokaObj, ref List<Korisnik> korLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);

            try
            {
                if (predmetNasokaObj != null)
                {
                    rezultat = getKorisniciPredmet(predmetNasokaObj.NasokaID, predmetNasokaObj.PredmetID, ref korLista);
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
        public RezultatKomanda getKorisnikPredmeti(string korisnikID, ref List<PretplatenPredmet> listaPredmeti)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                //Parametar za @Korisnik_ID  = korisnikID
                //Input Parametar
                SqlParam = new SqlParameter("@Korisnik_ID", SqlDbType.VarChar);
                SqlParam.Value = korisnikID;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniKorisnikPretplateniPredmeti", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    listaPredmeti = new List<PretplatenPredmet>();
                    PretplatenPredmet predmetObj;
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {
                        predmetObj = new PretplatenPredmet();
                        predmetObj.PredmetNasoka.NasokaID = BazaDB.DataRowVoInt(red, "N_ID");
                        predmetObj.PredmetNasoka.NasokaIme = BazaDB.DataRowVoString(red, "N_Ime");
                        predmetObj.PredmetNasoka.PredmetID = BazaDB.DataRowVoInt(red, "P_ID");
                        predmetObj.PredmetNasoka.PredmetIme = BazaDB.DataRowVoString(red, "P_Ime");
                        predmetObj.PredmetNasoka.PredmetOpis = BazaDB.DataRowVoString(red, "P_Opis");
                        predmetObj.PredmetNasoka.Kod = BazaDB.DataRowVoString(red, "NP_Kod");
                        predmetObj.PredmetNasoka.Krediti = BazaDB.DataRowVoInt(red, "NP_Krediti");

                        predmetObj.Korisnik.UserID = korisnikID;
                        predmetObj.DatumPretplata = BazaDB.DataRowVoDateTime(red, "KP_DodadenNa");
                        predmetObj.Aktiven = BazaDB.DataRowVoChar(red, "KP_Aktiven");

                        listaPredmeti.Add(predmetObj);
                    }


                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    rezultat.Pricina = "Korisnikot ne e pretlapten na nitu eden predmet.";
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

        public RezultatKomanda getPredmetiNasokaNepetplaten(int? oblastID,int? nasokaID, string KorisnikID, ref List<PredmetNasoka> predmetiLista)
        {

            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                if (oblastID != null)
                {
                    //Parametar za @oblast_ID  = oblastID
                    //Input Parametar
                    SqlParam = new SqlParameter("@oblast_ID", SqlDbType.Int);
                    SqlParam.Value = oblastID;
                    parametriKomanda.AddLast(SqlParam);
                }
                if (nasokaID != null)
                {
                    //Parametar za @nasoka_ID  = nasokaID
                    //Input Parametar
                    SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                    SqlParam.Value = nasokaID;
                    parametriKomanda.AddLast(SqlParam);
                }

                //Parametar za @korisnik_ID  = korisnikID
                //Input Parametar
                SqlParam = new SqlParameter("@korisnik_ID", SqlDbType.NVarChar);
                SqlParam.Value = KorisnikID;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniKorisnikNePretplateniPredmeti", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    predmetiLista = new List<PredmetNasoka>();
                    PredmetNasoka predmetNasokaObj;
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {
                        predmetNasokaObj = new PredmetNasoka();
                        predmetNasokaObj.PredmetID = BazaDB.DataRowVoInt(red, "PredmetiID");
                        predmetNasokaObj.PredmetIme = BazaDB.DataRowVoString(red, "PredmetiIme");
                        predmetNasokaObj.PredmetOpis  = BazaDB.DataRowVoString(red, "PredmetiOpis");


                        predmetNasokaObj.NasokaID = BazaDB.DataRowVoInt(red, "NasokiID");
                        predmetNasokaObj.NasokaIme = BazaDB.DataRowVoString(red, "NasokiIme");

                        predmetNasokaObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                        predmetNasokaObj.Kod = BazaDB.DataRowVoString(red, "Kod");
                        predmetNasokaObj.Krediti = BazaDB.DataRowVoInt(red, "Krediti");
                        predmetNasokaObj.TipPredmet = BazaDB.DataRowVoInt(red, "TipPredmet_ID");
                        predmetNasokaObj.Aktiven = BazaDB.DataRowVoChar(red, "Aktiven");

                        predmetiLista.Add(predmetNasokaObj);
                    }


                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {

                    rezultat.Pricina = "Nema predmeti za koi sto moze da se pretplatite vo izbranata nasoka/oblast.";
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
        #endregion
    }
}

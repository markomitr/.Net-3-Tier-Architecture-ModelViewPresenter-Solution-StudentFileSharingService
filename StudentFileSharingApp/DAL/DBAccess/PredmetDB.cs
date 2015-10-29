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
    public class PredmetDB : IDBPredmet
    {
        //Kolekcija od parametri - ova objekt se prefla vo funciite od BazaDB
        LinkedList<SqlParameter> parametriKomanda;

        //SqlParametar objekt
        SqlParameter SqlParam;

        //DateSet za rezultat 
        DataSet dsKomanda;

        public RezultatKomanda addPredmet(string Ime, string Opis)
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


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajPredmet", sqlCn: null);

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

        public RezultatKomanda addPredmet(Predmet predmetObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            
            try
            {
                if (predmetObj != null)
                {
                    rezultat = addPredmet(predmetObj.Ime, predmetObj.Opis);
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

        public RezultatKomanda updatePredmet(int ID, string Ime, string Opis)
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


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_IzmeniPredmet", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Ne potstoi toj predmet
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi toj predmet";

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

        public RezultatKomanda updatePredmet(Predmet predmetObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            
            try
            {
                if (predmetObj != null)
                {
                    rezultat = updatePredmet(predmetObj.PredmetID, predmetObj.Ime, predmetObj.Opis);
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

        public RezultatKomanda deletePredmet(int ID)
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


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_BrisiPredmet", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Ne postoi toj predmet
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi toj predmet";

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

        public RezultatKomanda deletePredmet(Predmet predmetObj)
        {

            RezultatKomanda rezultat = new RezultatKomanda(false);
            
            try
            {

                if (predmetObj != null)
                {
                    rezultat = deletePredmet(predmetObj.PredmetID);
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

        public RezultatKomanda getPredmet(int ID, ref Predmet predmetObj)
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

          
                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniPredmet1", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    DataRow red = dsKomanda.Tables[0].Rows[0];

                    predmetObj = new Predmet();
                    predmetObj.PredmetID = BazaDB.DataRowVoInt(red, "ID");
                    predmetObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                    predmetObj.Opis = BazaDB.DataRowVoString(red, "Opis");

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                   
                    rezultat.Pricina = "Ne postoi takvo predmet - ID";
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

        public RezultatKomanda getPredmeti(ref List<Predmet> predmetiLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniPredmet8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    predmetiLista = new List<Predmet>();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {

                        Predmet predmetObj = new Predmet();
                        predmetObj.PredmetID = BazaDB.DataRowVoInt(red, "ID");
                        predmetObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                        predmetObj.Opis = BazaDB.DataRowVoString(red, "Opis");


                        predmetiLista.Add(predmetObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu eden predmet
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema Predmeti";
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

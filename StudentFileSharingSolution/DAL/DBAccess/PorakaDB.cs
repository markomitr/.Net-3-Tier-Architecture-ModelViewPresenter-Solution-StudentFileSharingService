using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL.Interface;
using ClassDLL.SysPart;
using ClassDLL.GreskiEX;
namespace DAL.DBAccess
{
    public class PorakaDB : IDBPoraka
    {
        //Kolekcija od parametri - ova objekt se prefla vo funciite od BazaDB
        LinkedList<SqlParameter> parametriKomanda;

        //SqlParametar objekt
        SqlParameter SqlParam;

        //DateSet za rezultat 
        DataSet dsKomanda;

        #region PorakaPredmet
        public RezultatKomanda addPorakaPredmet(int Predmet_ID, int Nasoka_ID, string DodadenaOd, string Sodrzina, char? validna)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();


                //Parametar za @Predmet_ID  = PredmetID
                //Input Parametar
                SqlParam = new SqlParameter("@Predmet_ID", SqlDbType.Int);
                SqlParam.Value = Predmet_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Nasoka_ID  = NasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = Nasoka_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @DodadenaOd = DodadenaOd
                //Input Parametar
                SqlParam = new SqlParameter("@DodadenaOd", SqlDbType.VarChar);
                SqlParam.Value = DodadenaOd;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @Sodrzina = Sodrzina
                //Input Parametar
                SqlParam = new SqlParameter("@Sodrzina", SqlDbType.NVarChar);
                SqlParam.Value = Sodrzina;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktivna", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);

                if (validna != null)
                {
                    //Parametar za @Validna
                    //Input Parametar
                    SqlParam = new SqlParameter("@Validna", SqlDbType.Char);
                    SqlParam.Value = validna;
                    parametriKomanda.AddLast(SqlParam);
                }



                ////Parametar za @StatusOUT   
                ////Output Parametar
                //SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                //SqlParam.Direction = ParameterDirection.Output;
                //SqlParam.Value = "OUTPUT";
                //SqlParam.Size = 50;
                //parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajPorakaPredmet", sqlCn: null);

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

        public RezultatKomanda addPorakaPredmet(int Predmet_ID, int Nasoka_ID, Poraka porakaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();


                //Parametar za @Predmet_ID  = PredmetID
                //Input Parametar
                SqlParam = new SqlParameter("@Predmet_ID", SqlDbType.Int);
                SqlParam.Value = Predmet_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Nasoka_ID  = NasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = Nasoka_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @DodadenaOd = DodadenaOd
                //Input Parametar
                SqlParam = new SqlParameter("@DodadenaOd", SqlDbType.VarChar);
                SqlParam.Value = porakaObj.DodadenaOd;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @Sodrzina = Sodrzina
                //Input Parametar
                SqlParam = new SqlParameter("@Sodrzina", SqlDbType.NVarChar);
                SqlParam.Value = porakaObj.Sodrzina;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);



                ////Parametar za @StatusOUT   
                ////Output Parametar
                //SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                //SqlParam.Direction = ParameterDirection.Output;
                //SqlParam.Value = "OUTPUT";
                //SqlParam.Size = 50;
                //parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajPorakaPredmet", sqlCn: null);

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

        public RezultatKomanda addPorakaPredmet(PorakaPredmet porakaPredmetObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();


                //Parametar za @Predmet_ID  = PredmetID
                //Input Parametar
                SqlParam = new SqlParameter("@Predmet_ID", SqlDbType.Int);
                SqlParam.Value = porakaPredmetObj.Predmet_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Nasoka_ID  = NasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = porakaPredmetObj.Nasoka_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @DodadenaOd = DodadenaOd
                //Input Parametar
                SqlParam = new SqlParameter("@DodadenaOd", SqlDbType.VarChar);
                SqlParam.Value = porakaPredmetObj.DodadenaOd;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @Sodrzina = Sodrzina
                //Input Parametar
                SqlParam = new SqlParameter("@Sodrzina", SqlDbType.NVarChar);
                SqlParam.Value = porakaPredmetObj.Sodrzina;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);



                ////Parametar za @StatusOUT   
                ////Output Parametar
                //SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                //SqlParam.Direction = ParameterDirection.Output;
                //SqlParam.Value = "OUTPUT";
                //SqlParam.Size = 50;
                //parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajPorakaPredmet", sqlCn: null);

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

        public RezultatKomanda getPorakiPredmet(int Predmet_ID, int Nasoka_ID, ref List<PorakaPredmet> ppList)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @Predmet_ID  = PredmetID
                //Input Parametar
                SqlParam = new SqlParameter("@Predmet_ID", SqlDbType.Int);
                SqlParam.Value = Predmet_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Nasoka_ID  = NasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = Nasoka_ID;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniPorakiPredmet8", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {

                    ppList = new List<PorakaPredmet>();

                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {
                        PorakaPredmet ppObj = new PorakaPredmet();
                        ppObj.PorakaID = BazaDB.DataRowVoInt(red, "Poraka_ID");
                        ppObj.Predmet_ID = BazaDB.DataRowVoInt(red, "Predmet_ID");
                        ppObj.Nasoka_ID = BazaDB.DataRowVoInt(red, "Nasoka_ID");
                        ppObj.Sodrzina = BazaDB.DataRowVoString(red, "Sodrzina");
                        ppObj.Rejting = BazaDB.DataRowVoDecimal(red, "Rejting");
                        ppObj.DodadenaOd = BazaDB.DataRowVoString(red, "DodadenaOd");
                        ppObj.DodadenaNa = BazaDB.DataRowVoDateTime(red, "DodadenaNa");
                        ppObj.IzmenetaOd = BazaDB.DataRowVoString(red, "IzmenetaOd");
                        ppObj.IzmenetaNa = BazaDB.DataRowVoDateTime(red, "IzmenetaNa");
                        ppObj.Aktivna = BazaDB.DataRowVoChar(red, "Aktivna");                       
                        ppList.Add(ppObj);
                    }


                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {

                    rezultat.Pricina = "Nema poraki za toj predmet-nasoka";
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

        public RezultatKomanda getPorakiPredmet(int Predmet_ID, int Nasoka_ID, char Aktivna, ref List<PorakaPredmet> ppList)
        {
            throw new NotImplementedException();
        }

        public RezultatKomanda getPorakiPredmet(int Predmet_ID, int Nasoka_ID, string DodadenaOd, ref List<PorakaPredmet> ppList)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @Predmet_ID  = PredmetID
                //Input Parametar
                SqlParam = new SqlParameter("@Predmet_ID", SqlDbType.Int);
                SqlParam.Value = Predmet_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Nasoka_ID  = NasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = Nasoka_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @DodadenaOd = DodadenaOd
                //Input Parametar
                SqlParam = new SqlParameter("@DodadenaOd", SqlDbType.VarChar);
                SqlParam.Value = DodadenaOd;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniPorakiPredmet8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {

                    ppList = new List<PorakaPredmet>();
                    PorakaPredmet ppObj = new PorakaPredmet();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {
                        ppObj.PorakaID = BazaDB.DataRowVoInt(red, "Poraka_ID");
                        ppObj.Predmet_ID = BazaDB.DataRowVoInt(red, "Predmet_ID");
                        ppObj.Nasoka_ID = BazaDB.DataRowVoInt(red, "Nasoka_ID");
                        ppObj.Sodrzina = BazaDB.DataRowVoString(red, "Sodrzina");
                        ppObj.Rejting = BazaDB.DataRowVoDecimal(red, "Rejting");
                        ppObj.DodadenaOd = BazaDB.DataRowVoString(red, "DodadenaOd");
                        ppObj.DodadenaNa = BazaDB.DataRowVoDateTime(red, "DodadenaNa");
                        ppObj.IzmenetaOd = BazaDB.DataRowVoString(red, "IzmenetaOd");
                        ppObj.IzmenetaNa = BazaDB.DataRowVoDateTime(red, "IzmenetaNa");
                        ppObj.Aktivna = BazaDB.DataRowVoChar(red, "Aktivna");
                        ppList.Add(ppObj);
                    }


                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {

                    rezultat.Pricina = "Nema poraki za toj predmet-nasoka";
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

        public RezultatKomanda getPorakiPredmet(int Predmet_ID, int Nasoka_ID, string DodadenOd, char Aktivna, ref List<PorakaPredmet> ppList)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

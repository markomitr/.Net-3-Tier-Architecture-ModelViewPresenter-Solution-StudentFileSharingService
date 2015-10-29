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

    public class UstanovaDB : IDBUstanovi
    {
        //Kolekcija od parametri - ova objekt se prefla vo funciite od BazaDB
        LinkedList<SqlParameter> parametriKomanda;

        //SqlParametar objekt
        SqlParameter SqlParam;

        //DateSet za rezultat 
        DataSet dsKomanda;

        public RezultatKomanda addUstanova(string Ime, string Adresa, string WebStrana, int Institucija_ID)
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

                //Parametar za @Adresa = Adresa
                //Input Parametar
                SqlParam = new SqlParameter("@Adresa", SqlDbType.NVarChar);
                SqlParam.Value = Adresa;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @WebAdresa = WebAdresa
                //Input Parametar
                SqlParam = new SqlParameter("@WebStrana", SqlDbType.NVarChar);
                SqlParam.Value = WebStrana;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Institucija_ID  = Institucija_ID
                //Input Parametar
                SqlParam = new SqlParameter("@Institucija_ID", SqlDbType.Int);
                SqlParam.Value = Institucija_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajUstanova", sqlCn: null);


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

        public RezultatKomanda addUstanova(Ustanova ustanovaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                if (ustanovaObj != null)
                {
                    rezultat = addUstanova(ustanovaObj.Ime, ustanovaObj.Adresa, ustanovaObj.WebStrana, ustanovaObj.Institucija_ID);
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

        public RezultatKomanda updateUstanova(int UstanovaID, int Institucija_ID, string Ime, string Adresa, string WebStrana)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
       
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @UstanovaID  = UstanovaID
                //Input Parametar
                SqlParam = new SqlParameter("@UstanovaID", SqlDbType.Int);
                SqlParam.Value = UstanovaID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Ime  = Ime
                //Input Parametar
                SqlParam = new SqlParameter("@Ime", SqlDbType.NVarChar);
                SqlParam.Value = Ime;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Adresa = Adresa
                //Input Parametar
                SqlParam = new SqlParameter("@Adresa", SqlDbType.NVarChar);
                SqlParam.Value = Adresa;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @WebAdresa = WebAdresa
                //Input Parametar
                SqlParam = new SqlParameter("@WebStrana", SqlDbType.NVarChar);
                SqlParam.Value = WebStrana;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Institucija_ID  = Institucija_ID
                //Input Parametar
                SqlParam = new SqlParameter("@Institucija_ID", SqlDbType.Int);
                SqlParam.Value = Institucija_ID;
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


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_IzmeniUstanova", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Taa ustanova ne postoi
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Taa ustanova ne postoi";

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

        public RezultatKomanda updateUstanova(Ustanova ustanovaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            
            try
            {
                if (ustanovaObj != null)
                {
                    rezultat = updateUstanova(ustanovaObj.UstanovaID, ustanovaObj.Institucija_ID, ustanovaObj.Ime, ustanovaObj.Adresa, ustanovaObj.WebStrana);
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

        public RezultatKomanda deleteUstanova(int UstanovaID)
        {
           RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @UstanovaID  = UstanovaID
                //Input Parametar
                SqlParam = new SqlParameter("@UstanovaID", SqlDbType.Int);
                SqlParam.Value = UstanovaID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_BrisiUstanova", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Ne postoi taa ustanova
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi taa ustanova";

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

        public RezultatKomanda deleteUstanova(Ustanova ustanovaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                if (ustanovaObj != null)
                {
                    rezultat = deleteUstanova(ustanovaObj.UstanovaID);
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

        public RezultatKomanda getUstanova(int UstanovaID, ref Ustanova ustanovaObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @UstanovaID  = UstanovaID
                //Input Parametar
                SqlParam = new SqlParameter("@UstanovaID", SqlDbType.Int);
                SqlParam.Value = UstanovaID;
                parametriKomanda.AddLast(SqlParam);

               
                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniUstanova1", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    DataRow red = dsKomanda.Tables[0].Rows[0];

                    ustanovaObj = new Ustanova();
                    ustanovaObj.UstanovaID = BazaDB.DataRowVoInt(red, "UstanovaID");
                    ustanovaObj.Institucija_ID = BazaDB.DataRowVoInt(red, "Institucija_ID");
                    ustanovaObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                    ustanovaObj.Adresa = BazaDB.DataRowVoString(red, "Adresa");
                    ustanovaObj.WebStrana = BazaDB.DataRowVoString(red, "WebStrana");
                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    
                    rezultat.Pricina = "Ne postoi takva ustanova - ID";
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

        public RezultatKomanda getUstanovi(ref List<Ustanova> ustanoviLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniUstanovi8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    ustanoviLista = new List<Ustanova>();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {

                        Ustanova ustanovaObj = new Ustanova();
                        ustanovaObj.UstanovaID = BazaDB.DataRowVoInt(red, "UstanovaID");
                        ustanovaObj.Institucija_ID = BazaDB.DataRowVoInt(red, "Institucija_ID");
                        ustanovaObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                        ustanovaObj.Adresa = BazaDB.DataRowVoString(red, "Adresa");
                        ustanovaObj.WebStrana = BazaDB.DataRowVoString(red, "WebStrana");


                        ustanoviLista.Add(ustanovaObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu edna ustanova
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema ustanovi";
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

        public RezultatKomanda getUstanoviPoInstitucii(int Institucija_ID, ref List<Ustanova> ustanoviLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @Institucija_ID  = Institucija_ID
                //Input Parametar
                SqlParam = new SqlParameter("@Institucija_ID", SqlDbType.Int);
                SqlParam.Value = Institucija_ID;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniUstanovi8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    ustanoviLista = new List<Ustanova>();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {

                        Ustanova ustanovaObj = new Ustanova();
                        ustanovaObj.UstanovaID = BazaDB.DataRowVoInt(red, "UstanovaID");
                        ustanovaObj.Institucija_ID = BazaDB.DataRowVoInt(red, "Institucija_ID");
                        ustanovaObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                        ustanovaObj.Adresa = BazaDB.DataRowVoString(red, "Adresa");
                        ustanovaObj.WebStrana = BazaDB.DataRowVoString(red, "WebStrana");


                        ustanoviLista.Add(ustanovaObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu edna ustanova
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema ustanovi";
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

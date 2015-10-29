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
    public class OblastDB : IDBOblasti
    {
        //Kolekcija od parametri - ova objekt se prefla vo funciite od BazaDB
        LinkedList<SqlParameter> parametriKomanda;

        //SqlParametar objekt
        SqlParameter SqlParam;

        //DateSet za rezultat 
        DataSet dsKomanda;


        /// <summary>
        /// Funkcija koja e odgovorna za dodavanje na novi oblasti vo bazata so podatoci.
        /// </summary>
        /// <param name="Ime">Ime na oblast vo ramki na edna institucija.</param>
        /// <param name="Adresa">Adresa na institucijata koja ja podrzuva naznacenata oblast.</param>
        /// <param name="WebStrana">Web strana na institucijata koja ja podrzuva naznacenata oblast.</param>
        /// <param name="Ustanova_ID">Unikatna identifikacija na ustanovata vo cij sklop pripagja dadenata oblast.</param>
        /// <returns>Ishod od dodavanjeto na oblasta.</returns>
        public RezultatKomanda addOblast(string Ime, string Adresa, string WebStrana, int Ustanova_ID)
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
                SqlParam = new SqlParameter("@Ustanova_ID", SqlDbType.Int);
                SqlParam.Value = Ustanova_ID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);

                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajOblast", sqlCn: null);

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
        /// Funkcija koja e odgovorna za dodavanje na novi oblasti vo bazata so podatoci.
        /// </summary>
        /// <param name="oblastObj">Objekt od tip oblast</param>
        /// <returns>Ishod od dodavanjeto na oblasta.</returns>
        /// 
        public RezultatKomanda addOblast(Oblast oblastObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            
            try
            {
                if (oblastObj != null)
                {
                    rezultat = addOblast(oblastObj.Ime, oblastObj.Adresa, oblastObj.WebStrana, oblastObj.Ustanova_ID);
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
        /// Funkcija koja e odgovorna za ureduvanje na oblasti vo bazata so podatoci.
        /// </summary>
        /// <param name="Oblast_ID">Unikatna identifikacija na oblast koja sto kje se ureduva.</param>
        /// <param name="Ustanova_ID">Unikatna identifikacija na ustanovata vo cij sklop pripagja dadenata oblast koja kje se ureduva.</param>
        /// <param name="Ime">Ime na oblast vo ramki na edna institucija koja kje se ureduva.</param>
        /// <param name="Adresa">Adresa na institucijata koja ja podrzuva naznacenata oblast.</param>
        /// <param name="WebStrana">Web strana na institucijata koja ja podrzuva naznacenata oblast.</param>
        /// <returns>Ishod od ureduvanjeto na oblasta.</returns>
        /// 
        public RezultatKomanda updateOblast(int OblastID, int Ustanova_ID, string Ime, string Adresa, string WebStrana)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
          
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @UstanovaID  = UstanovaID
                //Input Parametar
                SqlParam = new SqlParameter("@OblastID", SqlDbType.Int);
                SqlParam.Value = OblastID;
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
                SqlParam = new SqlParameter("@Ustanova_ID", SqlDbType.Int);
                SqlParam.Value = Ustanova_ID;
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


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_IzmeniOblast", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Ne postoi taa oblast
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi taa oblast";

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
        /// Funkcija koja e odgovorna za ureduvanje na oblasti vo bazata so podatoci.
        /// </summary>
        /// <param name="oblastObj">Objekt od tip oblast, koj kje bide cel na ureduvanje</param>
        /// <returns>Ishod od ureduvanjeto na oblasta.</returns>
        /// 

        public RezultatKomanda updateOblast(Oblast oblastObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);

            try
            {
                if (oblastObj != null)
                {
                    rezultat = updateOblast(oblastObj.OblastID, oblastObj.Ustanova_ID, oblastObj.Ime, oblastObj.Adresa, oblastObj.WebStrana);
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
        /// Funkcija koja e odgovorna za brisenje na oblast so zadaden identifikator za soodvetnata oblast.
        /// </summary>
        /// <param name="OblastID">Identifikator za oblasta koja kje se brise.</param>
        /// <returns>Ishod od brisenjeto na oblasta.</returns>

        public RezultatKomanda deleteOblast(int OblastID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @OblastID  = OblastID
                //Input Parametar
                SqlParam = new SqlParameter("@OblastID", SqlDbType.Int);
                SqlParam.Value = OblastID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_BrisiOblast", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;

                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Ne postoi taa oblast
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi taa oblast";
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
        /// Funkcija koja e zadolzena za brisenje na opredelena oblast, za daden objekt od tip Oblast.
        /// </summary>
        /// <param name="oblastObj">Oblast koja kje bide izbrisana</param>
        /// <returns>Ishod od brisenjeto na oblasta.</returns>

        public RezultatKomanda deleteOblast(Oblast oblastObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            
            try
            {
                if (oblastObj != null)
                {
                    rezultat = deleteOblast(oblastObj.OblastID);
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
        /// Funkcija koja prebaruva oblast za daden identifikator.
        /// </summary>
        /// <param name="OblastID">Identifikator na oblast koja sto se bara.</param>
        /// <param name="oblastObj">Referenca kon najdeniot objekt.</param>
        /// <returns>Ishod od prebaruvanje na oblasta.</returns>
        public RezultatKomanda getOblast(int OblastID, ref Oblast oblastObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @OblastID  = OblastID
                //Input Parametar
                SqlParam = new SqlParameter("@OblastID", SqlDbType.Int);
                SqlParam.Value = OblastID;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniOblast1", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    DataRow red = dsKomanda.Tables[0].Rows[0];

                    oblastObj = new Oblast();
                    oblastObj.OblastID = BazaDB.DataRowVoInt(red, "OblastID");
                    oblastObj.Ustanova_ID = BazaDB.DataRowVoInt(red, "Ustanova_ID");
                    oblastObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                    oblastObj.Adresa = BazaDB.DataRowVoString(red, "Adresa");
                    oblastObj.WebStrana = BazaDB.DataRowVoString(red, "WebStrana");
                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    rezultat.Pricina = "Ne postoi takva oblast - ID";
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

        /// <summary>
        /// Funkcija koja kreira lista od oblasti pd daden dataSet..
        /// </summary>
        /// <param name="oblastiLista">Lista koja se menuva po referenca.</param>
        /// <returns>Ishod od kreiranjeto na listata so Oblasti.</returns>
        public RezultatKomanda getOblasti(ref List<Oblast> oblastiLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniOblasti8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    oblastiLista = new List<Oblast>();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {

                        Oblast oblastObj = new Oblast();
                        oblastObj.OblastID = BazaDB.DataRowVoInt(red, "OblastID");
                        oblastObj.Ustanova_ID = BazaDB.DataRowVoInt(red, "Ustanova_ID");
                        oblastObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                        oblastObj.Adresa = BazaDB.DataRowVoString(red, "Adresa");
                        oblastObj.WebStrana = BazaDB.DataRowVoString(red, "WebStrana");


                        oblastiLista.Add(oblastObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu edna oblast
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema oblasti";
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
        /// Za dadena ustanova po referenca se vrakjaat oblastite koi se odvivaat vo sklop na taa ustanova.
        /// </summary>
        /// <param name="Ustanova_ID">Ustanova na koja pripagja oblasta.</param>
        /// <param name="oblastiLista">Lista od oblasti koja po referenca se polni od DataSet.</param>
        /// <returns>Ishod od formiranje na lista so oblasti.</returns>
        public RezultatKomanda getOblastiPoUstanova(int Ustanova_ID, ref List<Oblast> oblastiLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @Institucija_ID  = Institucija_ID
                //Input Parametar
                SqlParam = new SqlParameter("@Ustanova_ID", SqlDbType.Int);
                SqlParam.Value = Ustanova_ID;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniOblasti8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    oblastiLista = new List<Oblast>();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {

                        Oblast oblastObj = new Oblast();
                        oblastObj.OblastID = BazaDB.DataRowVoInt(red, "OblastID");
                        oblastObj.Ustanova_ID = BazaDB.DataRowVoInt(red, "Ustanova_ID");
                        oblastObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                        oblastObj.Adresa = BazaDB.DataRowVoString(red, "Adresa");
                        oblastObj.WebStrana = BazaDB.DataRowVoString(red, "WebStrana");


                        oblastiLista.Add(oblastObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu edna ustanova
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema oblasti";
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

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


    public class InstituciiDB : IDBInstitucii
    {

        //Kolekcija od parametri - ova objekt se prefla vo funciite od BazaDB
        LinkedList<SqlParameter> parametriKomanda;

        //SqlParametar objekt
        SqlParameter SqlParam;

        //DateSet za rezultat 
        DataSet dsKomanda;

        /// <summary>
        /// Dodavanje na institucija vo baza.
        /// </summary>
        /// <param name="Ime">Ime na institucija.</param>
        /// <param name="Adresa">Adresa na institucija.</param>
        /// <param name="Kratenka">Kratenka za institucija.</param>
        /// <returns>Ishod od dodavanje na institucija.</returns>
        public RezultatKomanda addInstitucija(string Ime, string Adresa, string Kratenka)
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

                //Parametar za @Kratenka  = Kratenka
                //Input Parametar
                SqlParam = new SqlParameter("@Kratenka", SqlDbType.NVarChar);
                SqlParam.Value = Kratenka;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);

                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajInstitucija", sqlCn: null);
                
          
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
        /// Dodavanje na institucija vo baza
        /// </summary>
        /// <param name="instObj">Objekt od tip institucija koj kje bide dodaden vo baza.</param>
        /// <returns>Ishod od dodavanje na nova institucija.</returns>
        public RezultatKomanda addInstitucija(Institucija instObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                if (instObj != null)
                {
                    rezultat = addInstitucija(instObj.Ime, instObj.Adresa, instObj.Kratenka);
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
        /// Ureduvanje na institucija vo baza.
        /// </summary>
        /// <param name="ID">Id na institucija sto se ureduva.</param>
        /// <param name="Ime">Ime na institucija.</param>
        /// <param name="Adresa">Adresa na institucija.</param>
        /// <param name="Kratenka">Kratenka za institucija.</param>
        /// <returns>Ishod od ureduvanje na institucijata.</returns>
        public RezultatKomanda updateInstitucija(int ID, string Ime, string Adresa, string Kratenka)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @InstitucijaID  = ID
                //Input Parametar
                SqlParam = new SqlParameter("@ID", SqlDbType.Int);
                SqlParam.Value = ID;
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

                //Parametar za @Kratenka  = Kratenka
                //Input Parametar
                SqlParam = new SqlParameter("@Kratenka", SqlDbType.NVarChar);
                SqlParam.Value = Kratenka;
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


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_IzmeniInstitucija", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Ne postoi takva institucija
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi taa institucija";

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
        /// Ureduvanje na institucija vo baza.
        /// </summary>
        /// <param name="instObj">Objekt od tip institucija koj kje se ureduva.</param>
        /// <returns>Ishod od ureduvanjeto na institucija.</returns>
        public RezultatKomanda updateInstitucija(Institucija instObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            
            try
            {
                if (instObj != null)
                {
                    rezultat = updateInstitucija(instObj.ID, instObj.Ime, instObj.Adresa, instObj.Kratenka);
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
        /// Brisenje na institucija od baza.
        /// </summary>
        /// <param name="ID">Identifikator na institucija koja kje se brise.</param>
        /// <returns>Ishod od brisenje na institucija.</returns>
        public RezultatKomanda deleteInstitucija(int ID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @InstitucijaID  = ID
                //Input Parametar
                SqlParam = new SqlParameter("@ID", SqlDbType.Int);
                SqlParam.Value = ID;
                parametriKomanda.AddLast(SqlParam);


                ////Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_BrisiInstitucija", sqlCn: null);
                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                string pricina = parametriKomanda.Last.Value.Value.ToString();
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Nema takva institucija
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi taa institucija";

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
        /// Brisenje na institucija od baza.
        /// </summary>
        /// <param name="instObj">Institucija koja sakame da ja izbriseme.</param>
        /// <returns>Ishod od brisenjeto na institucija.</returns>
        public RezultatKomanda deleteInstitucija(Institucija instObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            
            try
            {
                if (instObj != null)
                {
                    rezultat = deleteInstitucija(instObj.ID);
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
        /// Prebaruvanje na institucija so soodveten ID.
        /// </summary>
        /// <param name="ID">ID na institucija koja se bara.</param>
        /// <param name="instObj">Objekt od tip Institucija koj kje se menuva po referenca.</param>
        /// <returns>Ishod od prebaruvanje na Institucija.</returns>
        public RezultatKomanda getInstitucija(int ID, ref Institucija instObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @InstitucijaID  = ID
                //Input Parametar
                SqlParam = new SqlParameter("@ID", SqlDbType.Int);
                SqlParam.Value = ID;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniInstitucija1", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    DataRow red = dsKomanda.Tables[0].Rows[0];

                    instObj = new Institucija();
                    instObj.ID = BazaDB.DataRowVoInt(red, "ID");
                    instObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                    instObj.Adresa = BazaDB.DataRowVoString(red, "Adresa");
                    instObj.Kratenka = BazaDB.DataRowVoString(red, "Kratenka");
                 
                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    rezultat.Pricina = "Ne postoi takva institucija - ID";
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
        /// Formiranje na lista od institucii.
        /// </summary>
        /// <param name="instLista">Lista od institucii koja se menuva po referenca.</param>
        /// <returns>Ishod od formiranjeto na listata so institucii.</returns>
        public RezultatKomanda getInstitucii(ref List<Institucija> instLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniInstitucija8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    instLista = new List<Institucija>();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {
                        Institucija instObj = new Institucija();
                        instObj.ID = BazaDB.DataRowVoInt(red, "ID");
                        instObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                        instObj.Adresa = BazaDB.DataRowVoString(red, "Adresa");
                        instObj.Kratenka = BazaDB.DataRowVoString(red, "Kratenka");

                        instLista.Add(instObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu edea institucija
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema institucii";
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ClassDLL.GreskiEX;
using ClassDLL.Interface;
using ClassDLL.SysPart;
using DAL.Interface;
namespace DAL.DBAccess
{
    public class DeloviDB:IDBDelovi 
    {
        //Kolekcija od parametri - ova objekt se prefla vo funciite od BazaDB
        LinkedList<SqlParameter> parametriKomanda;

        //SqlParametar objekt
        SqlParameter SqlParam;

        //DateSet za rezultat 
        DataSet dsKomanda;
        public DeloviDB() { }

        /// <summary>
        /// Dodavanje na del vo baza.
        /// </summary>
        /// <param name="Ime">Ime na del</param>
        /// <param name="ImaPredavac">Dali delot ima predavac</param>
        /// <param name="Vid_Izgled">Izgled na delot</param>
        /// <returns>Ishod od dodavanje na del.</returns>
        public RezultatKomanda addDel(string Ime, char ImaPredavac, int Vid_Izgled)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @Ime  = Ime
                //Input Parametar
                SqlParam = new SqlParameter("@Ime", SqlDbType.NVarChar);
                SqlParam.Value = Ime;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @ImaPredavac = ImaPredavac
                //Input Parametar
                SqlParam = new SqlParameter("@ImaPredavac", SqlDbType.Char);
                SqlParam.Value = ImaPredavac;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Vid_Izgled  = Vid_Izgled
                //Input Parametar
                SqlParam = new SqlParameter("@Vid_Izgled", SqlDbType.Int);
                SqlParam.Value = Vid_Izgled ;
                parametriKomanda.AddLast(SqlParam);

                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajDel", sqlCn: null);


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
        /// Dodavanje na del vo baza.
        /// </summary>
        /// <param name="delObj">Objekt od tip Del koj kje bide dodaden vo baza.</param>
        /// <returns>Ishod od dodavanje na del.</returns>
        public RezultatKomanda addDel(Del delObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                if (delObj != null)
                {
                    rezultat = addDel(delObj.Ime, delObj.ImaPredavac, delObj.Vid_Izgled);
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
        /// Ureduvanje na del.
        /// </summary>
        /// <param name="ID">Identifikator za del baza.</param>
        /// <param name="ime">Ime na del.</param>
        /// <param name="ImaPredavac">Dali delot ima precavac.</param>
        /// <param name="Vid_Izgled">Kakov e izgledot na del.</param>
        /// <param name="aktiven">Dali del e aktiven.</param>
        /// <returns>Ishod od ureduvanje na del.</returns>
        public RezultatKomanda updateDel(int ID, string ime, char ImaPredavac, int Vid_Izgled,char aktiven)
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

                //Parametar za @Ime  = Ime
                //Input Parametar
                SqlParam = new SqlParameter("@Ime", SqlDbType.NVarChar);
                SqlParam.Value = ime;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Adresa = Adresa
                //Input Parametar
                SqlParam = new SqlParameter("@ImaPredavac", SqlDbType.Char);
                SqlParam.Value = ImaPredavac ;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Vid_Izgled  = Vid_Izgled
                //Input Parametar
                SqlParam = new SqlParameter("@Vid_Izgled", SqlDbType.Int);
                SqlParam.Value = Vid_Izgled;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = aktiven;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_IzmeniDel", sqlCn: null);

                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Ne postoi toj del
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi toj del";

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
        /// Ureduvanje na del vo baza.
        /// </summary>
        /// <param name="delObj">Objekt od tipot del koj treba da bide ureden.</param>
        /// <returns>Ishod od ureduvanje na del.</returns>
        public RezultatKomanda updateDel(Del delObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);

            try
            {
                if (delObj != null)
                {
                    rezultat = updateDel(delObj.ID,delObj.Ime,delObj.ImaPredavac,delObj.Vid_Izgled,delObj.Aktiven);
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
        /// Brisenje na del od baza.
        /// </summary>
        /// <param name="ID">Identifikator na del sto treba da se izbrise.</param>
        /// <returns>Ishod od brisenjeto na del.</returns>
        public RezultatKomanda deleteDel(int ID)
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


                ////Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_BrisiDel", sqlCn: null);
                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                string pricina = parametriKomanda.Last.Value.Value.ToString();
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Nema takov del
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi toj del";

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
        /// Brisenje na del od baza.
        /// </summary>
        /// <param name="delObj">Objekt od tip Del koj treba da se izbrise.</param>
        /// <returns>Ishod od brisenjeto na objektot Del.</returns>
        public RezultatKomanda deleteDel(Del delObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);

            try
            {
                if (delObj != null)
                {
                    rezultat = deleteDel(delObj.ID);
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
        /// Prebaruvanje na objekt od tip del
        /// </summary>
        /// <param name="ID">Identifikator na posakuvaniot del objekt.</param>
        /// <param name="delObj">Promenliva koja po referenca kje go sodrzi objektot koj se bara.</param>
        /// <returns>Ishod od prebaruvanje.</returns>
        public RezultatKomanda getDel(int ID, ref Del delObj)
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

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniDel1", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    DataRow red = dsKomanda.Tables[0].Rows[0];

                    delObj = new Del();
                    delObj.ID = BazaDB.DataRowVoInt(red, "ID");
                    delObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                    delObj.ImaPredavac = BazaDB.DataRowVoChar(red, "ImaPredavac");
                    delObj.Vid_Izgled = BazaDB.DataRowVoInt(red, "Vid_Izgled");
                    delObj.Aktiven = BazaDB.DataRowVoChar(red,"Aktiven");

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    rezultat.Pricina = "Ne postoi tekov del - ID";
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
        /// Formiranje na lista od posakuvani delovi 
        /// </summary>
        /// <param name="deloviLista">lista koja po referenca kje gi sodrzi posakuvanite delovi.</param>
        /// <returns>Ishod od formiranje na lista so delovi.</returns>
        public RezultatKomanda getDelovi(ref List<Del> deloviLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniDelovi8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    deloviLista  = new List<Del>();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {
                        Del delObj = new Del();
                        delObj.ID = BazaDB.DataRowVoInt(red, "ID");
                        delObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                        delObj.ImaPredavac = BazaDB.DataRowVoChar(red, "ImaPredavac");
                        delObj.Vid_Izgled = BazaDB.DataRowVoInt(red, "Vid_Izgled");
                        delObj.Aktiven = BazaDB.DataRowVoChar(red,"Aktiven");

                        deloviLista.Add(delObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu eden del
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema delovi";
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DAL.Interface;
using ClassDLL.GreskiEX;
using ClassDLL.SysPart;
namespace DAL.DBAccess
{
    public class KorisnikDB : IDBKorisnik
    {
        //Kolekcija od parametri - ova objekt se prefla vo funciite od BazaDB
        LinkedList<SqlParameter>  parametriKomanda;

        //SqlParametar objekt
        SqlParameter SqlParam;

        //DateSet za rezultat 
        DataSet dsKomanda;

        //Objekt od korisnik
        Korisnik korisnikNov;

        /// <summary>
        /// Dodavanje na korisnik vo baza.
        /// </summary>
        /// <param name="id">Identifikator za dodaden korisnik.</param>
        /// <param name="pass">Password za dodaden korisnik.</param>
        /// <param name="email">Email za dodaden korisnik.</param>
        /// <returns>Ishod od dodavanje na korisnik.</returns>
        public RezultatKomanda addKorisnik(String id, String pass, String email) 
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @UserId  = id
                //Input Parametar
                SqlParam = new SqlParameter("@UserID", SqlDbType.VarChar);
                SqlParam.Value = id;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Lozinka  = pass
                //Input Parametar
                SqlParam = new SqlParameter("@Lozinka", SqlDbType.VarChar);
                SqlParam.Value = pass;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Email  = email
                //Input Parametar
                SqlParam = new SqlParameter("@Email", SqlDbType.VarChar);
                SqlParam.Value = email;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @KorTipID  = po default e student
                //Input Parametar
                SqlParam = new SqlParameter("@KorTipID", SqlDbType.VarChar);
                SqlParam.Value = "student";
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajKorisnik", sqlCn: null);
                string pricina = parametriKomanda.Last.Value.Value.ToString();


                if (pricina.ToUpper() == "POSTOI")
                {
                    //Korisnikot veke postoi
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Veke postoi takov korisnik";

                }
                else
                {
                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                
                return rezultat;
            }
            catch (KonekcijaEX greskaSqlKonekcija)
            {
                throw greskaSqlKonekcija;
            }
            catch (NemaKolonaEX nemaKolonaEx)
            {
                throw nemaKolonaEx;
            }
            catch (Exception greskaKomanda)
            {
                throw new KomandaKorisiniciEX("Momentalno ne moze da napravite nov korisnik.", "Greska pri kreiranje  na nov korisnik addKorisnik(String id, String pass, String email)  ", greskaKomanda.Message, 0);
            }
        }

        /// <summary>
        /// Dodavanje na korisnik vo baza.
        /// </summary>
        /// <param name="id">ID za korisnik</param>
        /// <param name="pass">Lozinka za korisnik</param>
        /// <param name="email">Email za korisnik</param>
        /// <param name="Ime">Ime za korisnik</param>
        /// <param name="Prezime">Prezime za korisnik</param>
        /// <returns>Ishod od dodavanje na korisnik.</returns>
        public RezultatKomanda addKorisnik(String id, String pass, String email, String Ime, String Prezime)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @UserId  = id
                //Input Parametar
                SqlParam = new SqlParameter("@UserID", SqlDbType.VarChar);
                SqlParam.Value = id;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Lozinka  = pass
                //Input Parametar
                SqlParam = new SqlParameter("@Lozinka", SqlDbType.VarChar);
                SqlParam.Value = pass;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Email  = email
                //Input Parametar
                SqlParam = new SqlParameter("@Email", SqlDbType.VarChar);
                SqlParam.Value = email;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Ime  = ime
                //Input Parametar
                SqlParam = new SqlParameter("@Ime", SqlDbType.NVarChar);
                SqlParam.Value = Ime;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Prezime  = Prezime
                //Input Parametar
                SqlParam = new SqlParameter("@Prezime", SqlDbType.NVarChar);
                SqlParam.Value = Prezime;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @KorTipID  = po default e student
                //Input Parametar
                SqlParam = new SqlParameter("@KorTipID", SqlDbType.VarChar);
                SqlParam.Value = "student";
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajKorisnik", sqlCn: null);
                string pricina = parametriKomanda.Last.Value.Value.ToString();


                if (pricina.ToUpper() == "POSTOI")
                {
                    //Korisnikot veke postoi
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Veke postoi takov korisnik";

                }
                else
                {
                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }

                return rezultat;
            }
            catch (KonekcijaEX greskaSqlKonekcija)
            {
                throw greskaSqlKonekcija;
            }
            catch (NemaKolonaEX nemaKolonaEx)
            {
                throw nemaKolonaEx;
            }
            catch (Exception greskaKomanda)
            {
                throw new KomandaKorisiniciEX("Momentalno ne moze da napravite nov korisnik.", "Greska pri kreiranje  na nov korisnik addKorisnik(String id, String pass, String email,String Ime,String Prezime)  ", greskaKomanda.Message, 0);
            }
        }

        public bool addKorisnik(Object korisnikObj) { return false; }

        /// <summary>
        /// Ureduvanje na korisnik vo baza.
        /// </summary>
        /// <param name="korisnikObj">Korisnik koj treba da se uredi.</param>
        /// <returns>Ishod za ureden korisnik</returns>
        public RezultatKomanda updateKorisnik(Korisnik  korisnikObj) 
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @UserId  = id
                //Input Parametar
                SqlParam = new SqlParameter("@UserID", SqlDbType.VarChar);
                SqlParam.Value = korisnikObj.UserID;
                parametriKomanda.AddLast(SqlParam);

                ////Parametar za @Lozinka  = pass
                //Input Parametar
                SqlParam = new SqlParameter("@Lozinka", SqlDbType.VarChar);
                SqlParam.Value = korisnikObj.Lozinka;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Email  = email
                //Input Parametar
                SqlParam = new SqlParameter("@Email", SqlDbType.VarChar);
                SqlParam.Value = korisnikObj.Email;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Ime  = ime
                //Input Parametar
                SqlParam = new SqlParameter("@Ime", SqlDbType.NVarChar);
                SqlParam.Value = korisnikObj.Ime;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Prezime  = Prezime
                //Input Parametar
                SqlParam = new SqlParameter("@Prezime", SqlDbType.NVarChar);
                SqlParam.Value = korisnikObj.Prezime;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Aktiven  = D
                //Input Parametar
                SqlParam = new SqlParameter("@Aktiven", SqlDbType.Char);
                SqlParam.Value = 'D';
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @KorTipID  = po default e student
                //Input Parametar
                SqlParam = new SqlParameter("@KorTipID", SqlDbType.VarChar);
                SqlParam.Value = "student";
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @StatusOUT   
                //Output Parametar
                //SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                //SqlParam.Direction = ParameterDirection.Output;
                //SqlParam.Value = "OUTPUT";
                //SqlParam.Size = 50;
                //parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajIzmeniKorisnik", sqlCn: null);
                string pricina = parametriKomanda.Last.Value.Value.ToString();


                if (pricina.ToUpper() == "POSTOI")
                {
                    //Korisnikot veke postoi
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Veke postoi takov korisnik";

                }
                else
                {
                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }

                return rezultat;
            }
            catch (KonekcijaEX greskaSqlKonekcija)
            {
                throw greskaSqlKonekcija;
            }
            catch (NemaKolonaEX nemaKolonaEx)
            {
                throw nemaKolonaEx;
            }
            catch (Exception greskaKomanda)
            {
                throw new KomandaKorisiniciEX("Momentalno ne moze da napravite nov korisnik.", "Greska pri kreiranje  na nov korisnik addKorisnik(String id, String pass, String email,String Ime,String Prezime)  ", greskaKomanda.Message, 0);
            }
        }
        public bool updateKorisnici(List<Object> korisniciList) { return false; }


        public bool updatePassKorisnik(Object korisnikObj, String newPass) { return false; }
        public bool updatePassKorisnik(String id, String oldPass, String newPass) { return false; }

        /// <summary>
        /// Prebaruvanje na korisnik za daden ID.
        /// </summary>
        /// <param name="id">ID na korisnik sto se bara</param>
        /// <param name="korisnikObj">Objekt koj po referenca go dobiva korisnikot koj se bara.</param>
        /// <returns></returns>
        public RezultatKomanda getKorisnik(String id, ref Korisnik korisnikObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @UserId  = id
                //Input Parametar
                SqlParam = new SqlParameter("@UserID", SqlDbType.VarChar);
                SqlParam.Value = id;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @StatusOUT   
                //Output Parametar
                //SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                //SqlParam.Direction = ParameterDirection.Output;
                //SqlParam.Value = "OUTPUT";
                //SqlParam.Size = 50;
                //parametriKomanda.AddLast(SqlParam);


                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniKorisnikPoID1", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    DataRow red = dsKomanda.Tables[0].Rows[0];
                    korisnikObj = new Korisnik();
                    korisnikObj.UserID = BazaDB.DataRowVoString(red, "UserID");
                    korisnikObj.Lozinka = BazaDB.DataRowVoString(red, "Lozinka");
                    korisnikObj.Email = BazaDB.DataRowVoString(red, "Email");
                    korisnikObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                    korisnikObj.Prezime = BazaDB.DataRowVoString(red, "Prezime");
                    korisnikObj.DodadenNa = BazaDB.DataRowVoDateTime(red, "DodadenNa");
                    korisnikObj.IzmenetNa = BazaDB.DataRowVoDateTime(red, "IzmenetNa");
                    korisnikObj.IzmenetOd = BazaDB.DataRowVoString(red, "IzmenetOd");
                    korisnikObj.KorTip_ID = BazaDB.DataRowVoString(red, "KorTip_ID");
                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    string pricina = parametriKomanda.Last.Value.Value.ToString();
                    //if (pricina.ToUpper() == "NEAKTIVEN")
                    //{
                    //    //Korisnikot ne e aktiven
                    //    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    //    rezultat.Pricina = "Korisnikot ne e aktiven";

                    //}
                    if (pricina.ToUpper() == "GRESEN")
                    {
                        //Pogreseni podatoci 
                        rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                        rezultat.Pricina = "Pogresno korisnicko ime ili lozinka";
                    }
                }
                return rezultat;
            }
            catch (KonekcijaEX greskaSqlKonekcija)
            {
                throw greskaSqlKonekcija;
            }
            catch (NemaKolonaEX nemaKolonaEx)
            {
                throw nemaKolonaEx;
            }
            catch (Exception greskaKomanda)
            {
                throw new KomandaKorisiniciEX("Sistemot momentalno ima problemi", "Greska pri izvrzuvanje na getKorisnik ", greskaKomanda.Message, 0);
            }
        }
        /// <summary>
        /// Proverka na aktivnost na korisnik
        /// </summary>
        /// <param name="id">ID na korisnik.</param>
        /// <param name="pass">Password na korisnik.</param>
        /// <param name="korisnikObj">Izmena na korisnik po referenca.</param>
        /// <returns>Ishod od proverkata na kroisnikot.</returns>
        public RezultatKomanda  getKorisnik(String id, String pass, ref Korisnik korisnikObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @UserId  = id
                //Input Parametar
                SqlParam = new SqlParameter("@UserID", SqlDbType.VarChar);
                SqlParam.Value = id;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Lozinka  = pass
                //Input Parametar
                SqlParam = new SqlParameter("@Lozinka", SqlDbType.VarChar);
                SqlParam.Value = pass;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);
                
                
                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniKorisnikLogin", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    DataRow red = dsKomanda.Tables[0].Rows[0];
                    korisnikObj = new Korisnik();
                    korisnikObj.UserID = BazaDB.DataRowVoString(red, "UserID");
                    korisnikObj.Lozinka = BazaDB.DataRowVoString(red, "Lozinka");
                    korisnikObj.Email = BazaDB.DataRowVoString(red, "Email");
                    korisnikObj.Ime = BazaDB.DataRowVoString(red, "Ime");
                    korisnikObj.Prezime = BazaDB.DataRowVoString(red, "Prezime");
                    korisnikObj.DodadenNa = BazaDB.DataRowVoDateTime(red, "DodadenNa");
                    korisnikObj.IzmenetNa = BazaDB.DataRowVoDateTime(red, "IzmenetNa");
                    korisnikObj.IzmenetOd = BazaDB.DataRowVoString(red, "IzmenetOd");
                    korisnikObj.KorTip_ID = BazaDB.DataRowVoString(red, "KorTip_ID");
                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh ;
                }
                else
                {
                    string pricina = parametriKomanda.Last.Value.Value.ToString();
                    if (pricina.ToUpper() == "NEAKTIVEN")
                    {
                        //Korisnikot ne e aktiven
                        rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                        rezultat.Pricina = "Korisnikot ne e aktiven";

                    }
                    else if (pricina.ToUpper() == "GRESEN")
                    {
                        //Pogreseni podatoci 
                        rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                        rezultat.Pricina = "Pogresno korisnicko ime ili lozinka";
                    }
                }
                return rezultat;
            }
            catch (KonekcijaEX greskaSqlKonekcija)
            {
                throw greskaSqlKonekcija;
            }
            catch (NemaKolonaEX nemaKolonaEx)
            {
                throw nemaKolonaEx;
            }
            catch (Exception greskaKomanda)
            {
                throw new KomandaKorisiniciEX("Sistemot momentalno ima problemi", "Greska pri izvrzuvanje na getKorisnik ", greskaKomanda.Message, 0);
            }

        }

        /// <summary>
        /// Formiranje na lista na korisnici
        /// </summary>
        /// <param name="korisniciLista">Lista od korisnici koja se menuva po referenca.</param>
        /// <returns>Ishod od kreiranje na lista.</returns>
        public RezultatKomanda getKorisnici(ref List<Korisnik> korisniciLista) {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniKorisnik8", sqlCn:null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    korisniciLista = new List<Korisnik>();
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {
                        korisnikNov = new Korisnik();
                        korisnikNov.UserID = BazaDB.DataRowVoString(red, "UserID");
                        korisnikNov.Lozinka = BazaDB.DataRowVoString(red, "Lozinka");
                        korisnikNov.Email = BazaDB.DataRowVoString(red, "Email");
                        korisnikNov.Ime = BazaDB.DataRowVoString(red, "Ime");
                        korisnikNov.Prezime = BazaDB.DataRowVoString(red, "Prezime");
                        korisnikNov.DodadenNa = BazaDB.DataRowVoDateTime(red, "DodadenNa");
                        korisnikNov.IzmenetNa = BazaDB.DataRowVoDateTime(red, "IzmenetNa");
                        korisnikNov.IzmenetOd = BazaDB.DataRowVoString(red, "IzmenetOd");
                        korisnikNov.KorTip_ID = BazaDB.DataRowVoString(red, "KorTip_ID");

                        korisniciLista.Add(korisnikNov);
                    }
                  
                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu eden korisnik
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema korisnici";
                }
                return rezultat;
            }
            catch (KonekcijaEX greskaSqlKonekcija)
            {
                throw greskaSqlKonekcija;
            }
            catch (NemaKolonaEX nemaKolonaEx)
            {
                throw nemaKolonaEx;
            }
            catch (Exception greskaKomanda)
            {
                throw new KomandaKorisiniciEX("Greska pri prikazuvanje na korisnicite!", "Greska pri izvrsuvanje na getKorisnici(ref List<Korisnik> korisniciLista) ", greskaKomanda.Message, 0);
            }

        }
        public bool getKorisniciAktiven(String aktiven, ref List<Object> korisniciLista) { return false; }
        public bool getKorisniciTip(String tipID, ref List<Object> korisniciLista) { return false; }
        public bool getKorisniciAktiven_Tip(String aktiven, String tipID, ref List<Object> korisniciLista) { return false; }

        public bool getLiveKorisnikID(String id, ref List<Object> korisniciLista) { return false; }
        public bool getLiveKorisnikIme(String ime, ref List<Object> korisniciLista) { return false; }
        public bool getLiveKorisnikPrezime(String prezime, ref List<Object> korisniciLista) { return false; }
        public bool getLiveKorisnik(Object korisnikObj, ref List<Object> korisniciLista) { return false; }
        //Predlog
        public bool getKorisniciGrad(String gradID, ref List<Object> korisniciLista) { return false; }
        public bool getKorisniciUstanova(String ustanovaID, ref List<Object> korisniciLista) { return false; }
        public bool getKorisniciRole(String roleID, ref List<Object> korisniciLista) { return false; }
        public bool getKorisnici(String roleID, String ustanovaID, String gradID, String aktiven, ref List<Object> korisniciLista) { return false; }

        public bool deactivateKorisnik(String id) { return false; }
        public bool deactivateKorisnik(Object korisnikObj) { return false; }
        public bool deactivateKorisnici(List<Object> korisniciList) { return false; }

        public bool daliPostoiKorisnik(String id) { return false; }
        public bool daliPostoiKorisnik(String id, String pass) { return false; }
        public bool daliPostoiKorisnk(Object korisnikObj) { return false; }
  

    }
}

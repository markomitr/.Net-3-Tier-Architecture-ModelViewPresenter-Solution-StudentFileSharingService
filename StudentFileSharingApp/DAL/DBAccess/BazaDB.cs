using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;
using ClassDLL.GreskiEX;

namespace DAL.DBAccess
{
    public class BazaDB
    {

        /// <summary>
        /// Property koe vrakja fiksen konekciski string.
        /// </summary>
        public static string KonekcijaString
        {
            get {
                    String cnString="";
                    cnString = "Data Source=tfsServerSK.dyndns.org;User ID=InternetStudent;Password=ST2005internet";
                    return cnString;    
                    //try
                    //{
                    //    cnString =ConfigurationSettings.AppSettings["cnString"];
                    //    return cnString;
                    //}
                    //catch(Exception  e)
                    //{
                    //    throw new KonekcijaStringEX("Problem so povrzuvanje so baza", "Greska vo citanje na connString",e.Message, 100);
                    //}
            }
        }

        /// <summary>
        /// Property koe zema konekciski string predefiniran vo app.config.
        /// </summary>
        private static string ConnectionString
        {
            get
            {
                String cnString = "";
                try
                {
                    cnString = ConfigurationSettings.AppSettings["cnString"];
                    return cnString;
                }
                catch (Exception e)
                {
                    throw new KonekcijaStringEX("Problem so povrzuvanje so baza", "Greska vo citanje na connString", e.Message, 100);
                }
            }
        }

        /// <summary>
        /// Metoda koja vrakja SqlConnection so predefiniran konekciski string.
        /// </summary>
        /// <returns>Objekt od tip SqlConnection, so predefinirna konekciski string.</returns>
        public static SqlConnection vratiKonekcija()
        {
            try
            {
                SqlConnection cnSql = new SqlConnection();
                cnSql.ConnectionString = BazaDB.KonekcijaString;
                return cnSql;
            }
            catch (KonekcijaStringEX cnStringEx)
            {
                throw cnStringEx;
            }

        }

        /// <summary>
        /// Metoda koja vrakja SqlConnection i pritoa pravi testiranje na na nejzinata funkcionalnost.
        /// Dokolku ne moze da se vospostavi konekcija se frlaat soodvetni greski za rakuvanje.
        /// </summary>
        /// <returns>Uspesno testirana konekcija vrakja objekt od tip cnSql so predefiniran konekciski string.</returns>
        public static SqlConnection vratiKonekcijaSoTest()
        {
            try
            {
                SqlConnection cnSql = new SqlConnection();
                cnSql.ConnectionString = BazaDB.KonekcijaString;
                BazaDB.proveriKonekcija(cnSql);
                return cnSql;
            }
            catch (KonekcijaStringEX cnStringEx)
            {
                throw cnStringEx;
            }
            catch (KonekcijaEX connEx)
            {
                throw connEx;
            }
        }

        /// <summary>
        /// Metoda koja pravi testiranje na funkcionalnosta na konekcijata. Najprvo vospostavuva konekcija, 
        /// a potoa ja prekinuva konekcijata i vrakja vistinita vrednost za statusot na funkcionalnost na konekcija. 
        /// Vo sprotivno frla predefiniran isklucok, so koj korisnikot kje treba da se spravi.
        /// </summary>
        /// <param name="sqlCn">Konekcija koja se stava na test</param>
        /// <returns>Pozitivna dokolku konekcijata funkcionira, ili pak negativna vrednost dokolku 
        /// konekcijata e vo nemoznost da se vospostavi.</returns>
        public static bool proveriKonekcija(SqlConnection sqlCn)
        {
            try
            {
                sqlCn.Open();
                sqlCn.Close();
                return true;
            }
            catch (Exception e)
            {
                sqlCn.Close();
                throw new KonekcijaEX("Problem so povrzuvanje so baza", "Greska vo testiranje na konekcija", e.Message, 101);
            }
        }

        /// <summary>
        /// Metoda koja vrsi otvaranje na konekcijata, vo sprotivno frla greska za spravuvanje so problemot.
        /// </summary>
        /// <param name="sqlCn">Konekcija koja treba da bide otvorena</param>
        /// <returns>Vrakja vistinita vrednost dokolku otvaranjeto na konekcijata e uspesno, 
        /// vo sprotivno frla greska za spravuvanje so problemot.</returns>
        public static bool otvoriKonekcija(ref SqlConnection sqlCn)
        {
            try
            {
                sqlCn.Open();

                return true;
            }
            catch (Exception e)
            {
                sqlCn.Close();
                throw new KonekcijaOpenEX("Problem so povrzuvanje so baza", "Problem pri otvaranje na konekcija", e.Message, 102);
            }
        }

        /// <summary>
        /// Metoda koja vrsi zatvoranje na konekcijata, vo sprotivno frla greska za spravuvanje so problemot.
        /// </summary>
        /// <param name="sqlCn">Konekcija koja treba da bide zatvorena</param>
        /// <returns>Vrakja vistinita vrednost dokolku zatvoranjeto na konekcijata e uspesno, 
        /// vo sprotivno frla greska za spravuvanje so problemot.</returns>
        public static bool zatvoriKonekcija(ref SqlConnection sqlCn)
        {
            try
            {
                sqlCn.Close();

                return true;
            }
            catch (Exception e)
            {
                sqlCn.Close();
                throw new KonekcijaCloseEX("Problem so povrzuvanje so baza", "Problem pri zatvoranje na konekcija", e.Message, 103);
            }

        }

        /// <summary>
        /// Metoda koja izvrsuva opredelen sql izraz i kako povratna informacija vrakja broj na redici koi go
        /// zadovoluvaat sql izrazot.
        /// </summary>
        /// <param name="paramArray">Niza od parametri za sql konekcija.</param>
        /// <param name="imeSP">Komanden tekst za sql konekcija.</param>
        /// <param name="sqlCn">sql konekcija</param>
        /// <returns>Broj na redici pri izvrsuvanje na komanden tekst.</returns>
 
        public static int ExecuteNonQuery(Array paramArray, string imeSP, [Optional] SqlConnection sqlCn)
        {
            SqlConnection _sqlCn;
            SqlCommand _sqlCm;
            try
            {

                if (sqlCn != null)
                {
                    _sqlCn = sqlCn;
                }
                else
                {
                    _sqlCn = BazaDB.vratiKonekcijaSoTest();
                }

                _sqlCm = new SqlCommand();
                _sqlCm.CommandType = CommandType.StoredProcedure;
                _sqlCm.CommandText = imeSP;
                _sqlCm.Connection = _sqlCn;
                _sqlCm.Parameters.AddRange(paramArray);

                int value;

                if (sqlCn == null)
                {
                    BazaDB.otvoriKonekcija(ref _sqlCn);
                    //_sqlCn.Open();

                    value = _sqlCm.ExecuteNonQuery();

                    BazaDB.zatvoriKonekcija(ref _sqlCn);
                    //_sqlCn.Close();
                }
                else
                {
                    if (_sqlCn.State != ConnectionState.Open)
                    {
                        BazaDB.otvoriKonekcija(ref _sqlCn);

                        value = _sqlCm.ExecuteNonQuery();

                        BazaDB.zatvoriKonekcija(ref _sqlCn);
                    }
                    else
                    {
                        value = _sqlCm.ExecuteNonQuery();
                    }
                }

                return value;

            }
            catch (KonekcijaStringEX cnStringEX)
            {
                throw cnStringEX;
            }
            catch (KonekcijaEX connEx)
            {
                throw connEx;
            }
            catch (KonekcijaOpenEX connOpenEx)
            {
                throw connOpenEx;
            }
            catch (KonekcijaCloseEX connCloseEx)
            {
                throw connCloseEx;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        /// <summary>
        /// Metoda koja izvrsuva opredelen sql izraz i kako povratna informacija vrakja objekt koj e 
        /// prvata kolona od prvata redica za soodvetniot izraz.
        /// </summary>
        /// <param name="paramArray">Niza od parametri za sql konekcija.</param>
        /// <param name="imeSP">Komanden tekst za sql konekcija.</param>
        /// <param name="sqlCn">sql konekcija</param>
        /// <returns>Broj na redici pri izvrsuvanje na komanden tekst.</returns>
        public static object ExecuteScalar(Array paramArray, string imeSP, [Optional] SqlConnection sqlCn)
        {

            SqlConnection _sqlCn;
            SqlCommand _sqlCm;
            try
            {

                if (sqlCn != null)
                {
                    _sqlCn = sqlCn;
                }
                else
                {
                    _sqlCn = BazaDB.vratiKonekcijaSoTest();
                }

                _sqlCm = new SqlCommand();
                _sqlCm.CommandType = CommandType.StoredProcedure;
                _sqlCm.CommandText = imeSP;
                _sqlCm.Connection = _sqlCn;
                _sqlCm.Parameters.AddRange(paramArray);

                object value;
                if (sqlCn == null)
                {
                    BazaDB.otvoriKonekcija(ref _sqlCn);
                    //_sqlCn.Open();

                    value = _sqlCm.ExecuteScalar();

                    BazaDB.zatvoriKonekcija(ref _sqlCn);
                    //_sqlCn.Close();
                }
                else
                {
                    if (_sqlCn.State != ConnectionState.Open)
                    {
                        BazaDB.otvoriKonekcija(ref _sqlCn);

                        value = _sqlCm.ExecuteScalar();

                        BazaDB.zatvoriKonekcija(ref _sqlCn);
                    }
                    else
                    {
                        value = _sqlCm.ExecuteScalar();
                    }

                }

                return value;

            }
            catch (KonekcijaStringEX cnStringEX)
            {
                throw cnStringEX;
            }
            catch (KonekcijaEX connEx)
            {
                throw connEx;
            }
            catch (KonekcijaOpenEX connOpenEx)
            {
                throw connOpenEx;
            }
            catch (KonekcijaCloseEX connCloseEx)
            {
                throw connCloseEx;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metoda koja izvrsuva opredelen sql izraz i kako povratna informacija vrakja DataReader object cija sostojba
        /// e soodvetna za dadeniot sql izraz.
        /// </summary>
        /// <param name="paramArray">Niza od parametri za sql konekcija.</param>
        /// <param name="imeSP">Komanden tekst za sql konekcija.</param>
        /// <param name="sqlCn">sql konekcija</param>
        /// <returns>Broj na redici pri izvrsuvanje na komanden tekst.</returns>

        protected SqlDataReader ExecuteReader(Array paramArray, string imeSP, [Optional] SqlConnection sqlCn)
        {
            SqlConnection _sqlCn;
            SqlCommand _sqlCm;
            try
            {

                if (sqlCn != null)
                {
                    _sqlCn = sqlCn;
                }
                else
                {
                    _sqlCn = BazaDB.vratiKonekcijaSoTest();
                }

                _sqlCm = new SqlCommand();
                _sqlCm.CommandType = CommandType.StoredProcedure;
                _sqlCm.CommandText = imeSP;
                _sqlCm.Connection = _sqlCn;
                _sqlCm.Parameters.AddRange(paramArray);

                SqlDataReader _sqlDr;

                if (sqlCn == null)
                {
                    BazaDB.otvoriKonekcija(ref _sqlCn);
                    //_sqlCn.Open();

                    _sqlDr = _sqlCm.ExecuteReader();

                    BazaDB.zatvoriKonekcija(ref _sqlCn);
                    //_sqlCn.Close();
                }
                else
                {
                    if (_sqlCn.State != ConnectionState.Open)
                    {
                        BazaDB.otvoriKonekcija(ref _sqlCn);

                        _sqlDr = _sqlCm.ExecuteReader();

                        BazaDB.zatvoriKonekcija(ref _sqlCn);
                    }
                    else
                    {
                        _sqlDr = _sqlCm.ExecuteReader();
                    }

                }

                return _sqlDr;

            }
            catch (KonekcijaStringEX cnStringEX)
            {
                throw cnStringEX;
            }
            catch (KonekcijaEX connEx)
            {
                throw connEx;
            }
            catch (KonekcijaOpenEX connOpenEx)
            {
                throw connOpenEx;
            }
            catch (KonekcijaCloseEX connCloseEx)
            {
                throw connCloseEx;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Metoda koja izvrsuva opredelen sql izraz i kako povratna informacija vrakja DataSet object cija sostojba
        /// e soodvetna za dadeniot sql izraz.
        /// </summary>
        /// <param name="paramArray">Niza od parametri za sql konekcija.</param>
        /// <param name="imeSP">Komanden tekst za sql konekcija.</param>
        /// <param name="sqlCn">sql konekcija</param>
        /// <returns>Broj na redici pri izvrsuvanje na komanden tekst.</returns>
        /// 
        public static DataSet GetDataSet(Array paramArray, string imeSP, [Optional] SqlConnection sqlCn)
        {

            SqlConnection _sqlCn;
            SqlCommand _sqlCm;
            SqlDataAdapter _sqlDa;
            try
            {

                if (sqlCn != null)
                {
                    _sqlCn = sqlCn;
                }
                else
                {
                    _sqlCn = BazaDB.vratiKonekcijaSoTest();
                }

                _sqlCm = new SqlCommand();
                _sqlCm.CommandType = CommandType.StoredProcedure;
                _sqlCm.CommandText = imeSP;
                _sqlCm.Connection = _sqlCn;
                _sqlCm.Parameters.AddRange(paramArray);

                _sqlDa = new SqlDataAdapter(_sqlCm);

                DataSet ds = new DataSet();

                if (sqlCn == null)
                {
                    BazaDB.otvoriKonekcija(ref _sqlCn);
                    //_sqlCn.Open();

                    _sqlDa.Fill(ds);

                    BazaDB.zatvoriKonekcija(ref _sqlCn);
                    //_sqlCn.Close();
                }
                else
                {
                    if (_sqlCn.State != ConnectionState.Open)
                    {
                        BazaDB.otvoriKonekcija(ref _sqlCn);

                        _sqlDa.Fill(ds);

                        BazaDB.zatvoriKonekcija(ref _sqlCn);
                    }
                    else
                    {
                        _sqlDa.Fill(ds);
                    }

                }

                return ds;

            }
            catch (KonekcijaStringEX cnStringEX)
            {
                throw cnStringEX;
            }
            catch (KonekcijaEX connEx)
            {
                throw connEx;
            }
            catch (KonekcijaOpenEX connOpenEx)
            {
                throw connOpenEx;
            }
            catch (KonekcijaCloseEX connCloseEx)
            {
                throw connCloseEx;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Metoda koja za soodvetna redica i ime na kolona, ja vrakja vrednosta na kolonata vo String format.
        /// </summary>
        /// <param name="red">Redica vo koja se naogja podatokot koj sakame da go procitame.</param>
        /// <param name="imeKolona">Kolona od koja sakame da go procitame podatokot.</param>
        /// <returns>Podatok koj se naogja vo soodvetnata redica, vo naznacenata kolona.</returns>
        public static String DataRowVoString(DataRow red, String imeKolona)
        {
            String rezultat = "";

            try
            {
                if (!(red[imeKolona] is DBNull))
                {
                    rezultat = red[imeKolona].ToString().Trim();
                }
            }
            catch (Exception e)
            {

                throw new NemaKolonaEX("Problem so podatoci", "Greska pri zemanje podatoci od DataRow[" + imeKolona + "] - Nema kolona " + imeKolona, e.Message, 117);
            }

            return rezultat;
        }

        /// <summary>
        /// Metoda koja za soodvetna redica i ime na kolona, ja vrakja vrednosta na kolonata vo char format.
        /// </summary>
        /// <param name="red">Redica vo koja se naogja podatokot koj sakame da go procitame.</param>
        /// <param name="imeKolona">Kolona od koja sakame da go procitame podatokot.</param>
        /// <returns>Podatok koj se naogja vo soodvetnata redica, vo naznacenata kolona.</returns>
        public static char DataRowVoChar(DataRow red, String imeKolona)
        {
            char rezultat =' ';
            try
            {
                if (!(red[imeKolona] is DBNull))
                {
                    rezultat = char.Parse(red[imeKolona].ToString().Trim());
                }
            }
            catch (Exception e)
            {

                throw new NemaKolonaEX("Problem so podatoci", "Greska pri zemanje podatoci od DataRow[" + imeKolona + "] - Nema kolona " + imeKolona, e.Message, 117);
            }

            return rezultat;
        }

        /// <summary>
        /// Metoda koja za soodvetna redica i ime na kolona, ja vrakja vrednosta na kolonata vo int format.
        /// </summary>
        /// <param name="red">Redica vo koja se naogja podatokot koj sakame da go procitame.</param>
        /// <param name="imeKolona">Kolona od koja sakame da go procitame podatokot.</param>
        /// <returns>Podatok koj se naogja vo soodvetnata redica, vo naznacenata kolona.</returns>
        /// 
        public static int DataRowVoInt(DataRow red, String imeKolona)
        {
            int rezultat = -1;
            try
            {
                if (!(red[imeKolona] is DBNull))
                {
                    rezultat = Int32.Parse(red[imeKolona].ToString().Trim());
                }
            }
            catch (Exception e)
            {

                throw new NemaKolonaEX("Problem so podatoci", "Greska pri zemanje podatoci od DataRow[" + imeKolona + "] - Nema kolona " + imeKolona, e.Message, 117);
            }

            return rezultat;
        }

        /// <summary>
        /// Metoda koja za soodvetna redica i ime na kolona, ja vrakja vrednosta na kolonata vo decimal format.
        /// </summary>
        /// <param name="red">Redica vo koja se naogja podatokot koj sakame da go procitame.</param>
        /// <param name="imeKolona">Kolona od koja sakame da go procitame podatokot.</param>
        /// <returns>Podatok koj se naogja vo soodvetnata redica, vo naznacenata kolona.</returns>
        /// 
        public static decimal DataRowVoDecimal(DataRow red, String imeKolona)
        {
            decimal rezultat = -1;
            try
            {
                if (!(red[imeKolona] is DBNull))
                {
                    rezultat = Decimal.Parse(red[imeKolona].ToString().Trim());
                }
            }
            catch (Exception e)
            {

                throw new NemaKolonaEX("Problem so podatoci", "Greska pri zemanje podatoci od DataRow[" + imeKolona + "] - Nema kolona " + imeKolona, e.Message, 117);
            }

            return rezultat;
        }

        /// <summary>
        /// Metoda koja za soodvetna redica i ime na kolona, ja vrakja vrednosta na kolonata vo DateTime format.
        /// </summary>
        /// <param name="red">Redica vo koja se naogja podatokot koj sakame da go procitame.</param>
        /// <param name="imeKolona">Kolona od koja sakame da go procitame podatokot.</param>
        /// <returns>Podatok koj se naogja vo soodvetnata redica, vo naznacenata kolona.</returns>
        public static DateTime DataRowVoDateTime(DataRow red, String imeKolona)
        {
            DateTime rezultat;
            try
            {
                if (!(red[imeKolona] is DBNull))
                {
                    rezultat = DateTime.Parse(red[imeKolona].ToString().Trim());
                }
                else return DateTime.MinValue;
                
            }
            catch (Exception e)
            {
                throw new NemaKolonaEX("Problem so podatoci", "Greska pri zemanje podatoci od DataRow[" + imeKolona + "] - Nema kolona " + imeKolona, e.Message, 117);
            }

            return rezultat;
        }
    }
}

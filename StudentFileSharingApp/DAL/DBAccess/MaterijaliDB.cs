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
    public class MaterijaliDB:IDBMaterijali 
    {
        //Kolekcija od parametri - ova objekt se prefla vo funciite od BazaDB
        LinkedList<SqlParameter> parametriKomanda;

        //SqlParametar objekt
        SqlParameter SqlParam;

        //DateSet za rezultat 
        DataSet dsKomanda;

        public RezultatKomanda addMaterijal(string Naslov, string Opis, string DodadenOd, string Slika, string Pateka,String Type)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @Naslov  = Naslov
                //Input Parametar
                SqlParam = new SqlParameter("@Naslov", SqlDbType.NVarChar);
                SqlParam.Value = Naslov;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Opis = Opis
                //Input Parametar
                SqlParam = new SqlParameter("@Opis", SqlDbType.NVarChar);
                SqlParam.Value = Opis;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @DodadenOd  = DodadenOd
                //Input Parametar
                SqlParam = new SqlParameter("@DodadenOd", SqlDbType.VarChar);
                SqlParam.Value = DodadenOd;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Slika  = Slika
                //Input Parametar
                SqlParam = new SqlParameter("@Slika", SqlDbType.NVarChar);
                SqlParam.Value = Slika ;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Pateka  = Pateka
                //Input Parametar
                SqlParam = new SqlParameter("@Pateka", SqlDbType.NVarChar);
                SqlParam.Value = Pateka;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Type = Type
                //Input Parametar
                SqlParam = new SqlParameter("@Type", SqlDbType.NVarChar);
                SqlParam.Value = Type;
                parametriKomanda.AddLast(SqlParam);

                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajMaterijal", sqlCn: null);


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

        public RezultatKomanda addMaterijal(Materijal materijalObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                if (materijalObj != null)
                {
                    rezultat = addMaterijal(materijalObj.Naslov, materijalObj.Opis, materijalObj.DodadenOd, materijalObj.Slika, materijalObj.Pateka,materijalObj.Type);
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

        public RezultatKomanda updateMaterijal(int MaterijalID, string Naslov, string Opis, string DodadenOd, string Slika, string Pateka,string Type)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @MaterijalID  = MaterijalID
                //Input Parametar
                SqlParam = new SqlParameter("@MaterijalID", SqlDbType.Int);
                SqlParam.Value = MaterijalID;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @Naslov  = Naslov
                //Input Parametar
                SqlParam = new SqlParameter("@Naslov", SqlDbType.NVarChar);
                SqlParam.Value = Naslov;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Opis = Opis
                //Input Parametar
                SqlParam = new SqlParameter("@Opis", SqlDbType.NVarChar);
                SqlParam.Value = Opis;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @DodadenOd  = DodadenOd
                //Input Parametar
                SqlParam = new SqlParameter("@DodadenOd", SqlDbType.VarChar);
                SqlParam.Value = DodadenOd;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Slika  = Slika
                //Input Parametar
                SqlParam = new SqlParameter("@Slika", SqlDbType.NVarChar);
                SqlParam.Value = Slika;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Pateka  = Pateka
                //Input Parametar
                SqlParam = new SqlParameter("@Pateka", SqlDbType.NVarChar);
                SqlParam.Value = Pateka;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Type  = Type
                //Input Parametar
                SqlParam = new SqlParameter("@Type", SqlDbType.NVarChar);
                SqlParam.Value = Type;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @StatusOUT   
                //Output Parametar
                SqlParam = new SqlParameter("@StatusOUT", SqlDbType.NVarChar);
                SqlParam.Direction = ParameterDirection.Output;
                SqlParam.Value = "OUTPUT";
                SqlParam.Size = 50;
                parametriKomanda.AddLast(SqlParam);

                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_IzmeniMaterijal", sqlCn: null);


                string pricina = parametriKomanda.Last.Value.Value.ToString();

                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Ne postoi toj materijal
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi toj materijal";

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

        public RezultatKomanda updateMaterijal(Materijal materijalObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                if (materijalObj != null)
                {
                    rezultat = updateMaterijal(materijalObj.MaterijalID,materijalObj.Naslov, materijalObj.Opis, materijalObj.DodadenOd, materijalObj.Slika, materijalObj.Pateka,materijalObj.Type);
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

        public RezultatKomanda deleteMaterijal(int ID)
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


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_MaterijalDel", sqlCn: null);
                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                string pricina = parametriKomanda.Last.Value.Value.ToString();
                if (pricina.ToUpper() == "NEPOSTOI")
                {
                    //Nema takov materijal
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Ne postoi toj materijal";

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

        public RezultatKomanda deleteMaterijal(Materijal materijalObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);

            try
            {
                if (materijalObj != null)
                {
                    rezultat = deleteMaterijal(materijalObj.MaterijalID);
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

        public RezultatKomanda getMaterijal(int ID, ref Materijal materijalObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            dsKomanda = null;
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @MaterijalID  = ID
                //Input Parametar
                SqlParam = new SqlParameter("@MaterijalID", SqlDbType.Int);
                SqlParam.Value = ID;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniMaterijal1", sqlCn: null);
                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    DataRow red = dsKomanda.Tables[0].Rows[0];

                    materijalObj = new Materijal();
                    materijalObj.MaterijalID = BazaDB.DataRowVoInt(red, "MaterijalID");
                    materijalObj.Naslov = BazaDB.DataRowVoString(red, "Naslov");
                    materijalObj.DodadenOd = BazaDB.DataRowVoString(red, "DodadenOd");
                    materijalObj.DodadenNa  = BazaDB.DataRowVoDateTime(red, "DodadenNa");
                    materijalObj.Opis  = BazaDB.DataRowVoString(red, "Opis");
                    materijalObj.Pateka = BazaDB.DataRowVoString(red, "Pateka");
                    materijalObj.Slika = BazaDB.DataRowVoString(red, "Slika");
                    materijalObj.Aktiven = BazaDB.DataRowVoChar(red, "Aktiven");
                    materijalObj.Type = BazaDB.DataRowVoString(red, "Type");

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    rezultat.Pricina = "Ne postoi tekov materijal - ID";
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

        public RezultatKomanda getMaterijali(ref List<Materijal> marerijaliLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniMaterijali8", sqlCn: null);

                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    marerijaliLista = new List<Materijal>();
                    Materijal materijalObj;
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {
                        materijalObj = new Materijal();
                        materijalObj.MaterijalID = BazaDB.DataRowVoInt(red, "MaterijalID");
                        materijalObj.Naslov = BazaDB.DataRowVoString(red, "Naslov");
                        materijalObj.DodadenOd = BazaDB.DataRowVoString(red, "DodadenOd");
                        materijalObj.DodadenNa = BazaDB.DataRowVoDateTime(red, "DodadenNa");
                        materijalObj.Opis = BazaDB.DataRowVoString(red, "Opis");
                        materijalObj.Pateka = BazaDB.DataRowVoString(red, "Pateka");
                        materijalObj.Slika = BazaDB.DataRowVoString(red, "Slika");
                        materijalObj.Aktiven = BazaDB.DataRowVoChar(red, "Aktiven");
                        materijalObj.Type = BazaDB.DataRowVoString(red, "Type");

                        marerijaliLista.Add(materijalObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu eden materijal
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema materijali";
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


        public RezultatKomanda getMaterijali(string DodadenOd, ref List<Materijal> marerijaliLista)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();


                //Parametar za @DodadenOD  = DodadenOD
                //Input Parametar
                SqlParam = new SqlParameter("@DodadenOD", SqlDbType.Int);
                SqlParam.Value = DodadenOd;
                parametriKomanda.AddLast(SqlParam);

                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniMaterijali8", sqlCn: null);


                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    marerijaliLista = new List<Materijal>();
                    Materijal materijalObj;
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {
                        materijalObj = new Materijal();
                        materijalObj.MaterijalID = BazaDB.DataRowVoInt(red, "MaterijalID");
                        materijalObj.Naslov = BazaDB.DataRowVoString(red, "Naslov");
                        materijalObj.DodadenOd = BazaDB.DataRowVoString(red, "DodadenOd");
                        materijalObj.DodadenNa = BazaDB.DataRowVoDateTime(red, "DodadenNa");
                        materijalObj.Opis = BazaDB.DataRowVoString(red, "Opis");
                        materijalObj.Pateka = BazaDB.DataRowVoString(red, "Pateka");
                        materijalObj.Slika = BazaDB.DataRowVoString(red, "Slika");
                        materijalObj.Aktiven = BazaDB.DataRowVoChar(red, "Aktiven");
                        materijalObj.Type = BazaDB.DataRowVoString(red, "Type");

                        marerijaliLista.Add(materijalObj);
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu eden materijal
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema materijali";
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

        public RezultatKomanda getMaterijali(int NasokaID, int PredmetID, int? DeloviID, ref MaterijaliGrupirani grupiranMaterijali)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();


                //Parametar za @Nasoka_ID  = NasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = NasokaID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Predmet_ID  = PredmetID
                //Input Parametar
                SqlParam = new SqlParameter("@Predmet_ID", SqlDbType.Int);
                SqlParam.Value = PredmetID;
                parametriKomanda.AddLast(SqlParam);

                if (DeloviID != null)
                {
                    //Parametar za @Delovi_ID  = DeloviID
                    //Input Parametar
                    SqlParam = new SqlParameter("@Delovi_ID", SqlDbType.Int);
                    SqlParam.Value = DeloviID;
                    parametriKomanda.AddLast(SqlParam);

                }
                dsKomanda = BazaDB.GetDataSet(parametriKomanda.ToArray(), "sp_PodigniMaterijaliPoDelovi", sqlCn: null);


                if (dsKomanda.Tables.Count > 0 && dsKomanda.Tables[0].Rows.Count > 0)
                {
                    Nasoka tekNasoka = new Nasoka();
                    tekNasoka.NasokaID = BazaDB.DataRowVoInt(dsKomanda.Tables[0].Rows[0], "NA_NasokaID");
                    tekNasoka.Ime = BazaDB.DataRowVoString(dsKomanda.Tables[0].Rows[0], "NA_NasokaIme");
                    
                    Del tekovenDel;
                    Materijal materijalObj;
                    if (DeloviID != null)
                    {
                        grupiranMaterijali = new MaterijaliGrupirani(tekNasoka, new Predmet(PredmetID), true);
                       
                    }
                    else
                    {
                        grupiranMaterijali = new MaterijaliGrupirani(tekNasoka, new Predmet(PredmetID), false);
                    }

           
                    foreach (DataRow red in dsKomanda.Tables[0].Rows)
                    {
                        materijalObj = new Materijal();
                        
                        materijalObj.MaterijalID = BazaDB.DataRowVoInt(red, "M_MaterijalID");
                        materijalObj.Naslov = BazaDB.DataRowVoString(red, "M_Naslov");
                        materijalObj.DodadenOd = BazaDB.DataRowVoString(red, "M_DodadenOD");
                        materijalObj.DodadenNa = BazaDB.DataRowVoDateTime(red, "M_DodadenNa");
                        materijalObj.Opis = BazaDB.DataRowVoString(red, "M_Opis");
                        materijalObj.Pateka = BazaDB.DataRowVoString(red, "M_Pateka");
                        materijalObj.Slika = BazaDB.DataRowVoString(red, "M_Slika");
                        materijalObj.Aktiven = BazaDB.DataRowVoChar(red, "M_Aktiven");
                        materijalObj.Type = BazaDB.DataRowVoString(red, "M_Type");
                        materijalObj.Prevzemen = BazaDB.DataRowVoInt(red, "Prevzemen");
                        materijalObj.DobarRejting = BazaDB.DataRowVoInt(red, "DobarRejting");
                        materijalObj.LosRejting = BazaDB.DataRowVoInt(red, "LosRejting");

                        if (DeloviID != null)
                        {
                            tekovenDel = new Del(BazaDB.DataRowVoInt(red, "DEL_ID"), BazaDB.DataRowVoString(red, "DEL_Ime"), ' ');
                            tekovenDel.Vid_Izgled = BazaDB.DataRowVoInt(red, "DEL_Vid_Izgled");
                            grupiranMaterijali.DodadiMaterijalPoDel(tekovenDel, materijalObj);
                        }
                        else
                        {
                            grupiranMaterijali.DodadiSamoMaterijal(materijalObj);
                        }
                    }

                    rezultat.Rezultat = RezultatKomandaEnum.Uspeh;
                }
                else
                {
                    //Nema nitu eden materijal
                    rezultat.Rezultat = RezultatKomandaEnum.Neuspeh;
                    rezultat.Pricina = "Nema materijali";
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

        public RezultatKomanda addMaterijalPredmet(int MaterijalID, int NasokaID, int PredmetID, int DelID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @MaterijalID = MaterijalID
                //Input Parametar
                SqlParam = new SqlParameter("@MaterijalID", SqlDbType.Int);
                SqlParam.Value = MaterijalID ;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @NasokaID = NasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@NasokaID", SqlDbType.Int);
                SqlParam.Value = NasokaID;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @PredmetID = PredmetID
                //Input Parametar
                SqlParam = new SqlParameter("@PredmetID", SqlDbType.Int);
                SqlParam.Value = PredmetID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @DelID = DelID
                //Input Parametar
                SqlParam = new SqlParameter("@DelID", SqlDbType.Int);
                SqlParam.Value = DelID;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajMaterijalPredmet", sqlCn: null);


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

        public RezultatKomanda addMaterijalPredmet(int MaterijalID, PredmetNasoka predmetNasokaObj, int DelID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                if (predmetNasokaObj != null)
                {
                    rezultat = addMaterijalPredmet(MaterijalID, predmetNasokaObj.NasokaID, predmetNasokaObj.PredmetID, DelID);
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

        public RezultatKomanda addMaterijalPredmet(Materijal matObj, int NasokaID, int PredmetID, int DelID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                if (matObj != null)
                {
                    rezultat = addMaterijalPredmet(matObj.MaterijalID, NasokaID, PredmetID, DelID);
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

        public RezultatKomanda addMaterijalPredmet(Materijal matObj, PredmetNasoka predmetNasokaObj, Del delObj)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                if (matObj != null && predmetNasokaObj !=null && delObj != null)
                {
                    rezultat = addMaterijalPredmet(matObj.MaterijalID, predmetNasokaObj.NasokaID, predmetNasokaObj.PredmetID, delObj.ID);
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

        public RezultatKomanda deleteMaterijalOdPredmet(int MaterijalID, int NasokaID, int PredmetID, int DelID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @MaterijalID = MaterijalID
                //Input Parametar
                SqlParam = new SqlParameter("@MaterijalID", SqlDbType.Int);
                SqlParam.Value = MaterijalID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @NasokaID = NasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@NasokaID", SqlDbType.Int);
                SqlParam.Value = NasokaID;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @PredmetID = PredmetID
                //Input Parametar
                SqlParam = new SqlParameter("@PredmetID", SqlDbType.Int);
                SqlParam.Value = PredmetID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @DelID = DelID
                //Input Parametar
                SqlParam = new SqlParameter("@DelID", SqlDbType.Int);
                SqlParam.Value = DelID;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_BrisiMaterijalPredmet", sqlCn: null);


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

        public RezultatKomanda deleteMaterijalOdPredmet(Materijal matObj, int NasokaID, int PredmetID, int DelID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                if (matObj != null)
                {
                    rezultat = deleteMaterijalOdPredmet(matObj.MaterijalID, NasokaID, PredmetID, DelID);
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

        public RezultatKomanda deleteMaterijalOdPredmet(int MaterijalID, PredmetNasoka predmetNasokaObj, int DelID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                if (predmetNasokaObj != null)
                {
                    rezultat = deleteMaterijalOdPredmet(MaterijalID,predmetNasokaObj.NasokaID,predmetNasokaObj.PredmetID, DelID);
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

        public RezultatKomanda deleteMaterijalOdPredmet(Materijal matObj, PredmetNasoka predmetNasokaObj, int DelID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                if (predmetNasokaObj != null && predmetNasokaObj != null)
                {
                    rezultat = deleteMaterijalOdPredmet(matObj.MaterijalID, predmetNasokaObj.NasokaID, predmetNasokaObj.PredmetID, DelID);
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



        public RezultatKomanda addDownloadCount(int MaterijalID, int NasokaID, int PredmetID, int DelID)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @MaterijalID = MaterijalID
                //Input Parametar
                SqlParam = new SqlParameter("@Materijal_ID", SqlDbType.Int);
                SqlParam.Value = MaterijalID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @NasokaID = NasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = NasokaID;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @PredmetID = PredmetID
                //Input Parametar
                SqlParam = new SqlParameter("@Predmet_ID", SqlDbType.Int);
                SqlParam.Value = PredmetID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @DelID = DelID
                //Input Parametar
                SqlParam = new SqlParameter("@Del_ID", SqlDbType.Int);
                SqlParam.Value = DelID;
                parametriKomanda.AddLast(SqlParam);


                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZgolemiDownloadMaterjalPredmet", sqlCn: null);

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


        public RezultatKomanda addRejting(int MaterijalID, int NasokaID, int PredmetID, int DelID, RejtingTip tipRejting)
        {
            RezultatKomanda rezultat = new RezultatKomanda(false);
            try
            {
                parametriKomanda = new LinkedList<SqlParameter>();

                parametriKomanda.Clear();

                //Parametar za @MaterijalID = MaterijalID
                //Input Parametar
                SqlParam = new SqlParameter("@Materijal_ID", SqlDbType.Int);
                SqlParam.Value = MaterijalID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @NasokaID = NasokaID
                //Input Parametar
                SqlParam = new SqlParameter("@Nasoka_ID", SqlDbType.Int);
                SqlParam.Value = NasokaID;
                parametriKomanda.AddLast(SqlParam);


                //Parametar za @PredmetID = PredmetID
                //Input Parametar
                SqlParam = new SqlParameter("@Predmet_ID", SqlDbType.Int);
                SqlParam.Value = PredmetID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @DelID = DelID
                //Input Parametar
                SqlParam = new SqlParameter("@Del_ID", SqlDbType.Int);
                SqlParam.Value = DelID;
                parametriKomanda.AddLast(SqlParam);

                //Parametar za @Tip = Tip
                //Input Parametar
                SqlParam = new SqlParameter("@Tip", SqlDbType.Char);
                    if(tipRejting == RejtingTip.Negativen)
                    {
                        SqlParam.Value = "L";

                    }
                    else if (tipRejting == RejtingTip.Pozitiven)
                    {
                        SqlParam.Value = "D";
                    }
                parametriKomanda.AddLast(SqlParam);

                BazaDB.ExecuteScalar(parametriKomanda.ToArray(), "sp_ZacuvajRejtingMaterjalPredmet", sqlCn: null);

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
    }
}

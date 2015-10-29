using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;

namespace DAL.Interface
{
    /*
     * Interfejs za komunikacija na entitetot
     * Korisnici so bazata(Add,Edti,Update,Delete)
    */
    interface IDBKorisnik
    {
        //ADD
        //-------------------------------------------------------------------------
        /*
         * addKorisnik(String id, String pass,String email) e func. koja
         * e ednostavna i kreira korisnik samo so najpotrebnite podatoci za
         * sekoj korisnik
        */

        RezultatKomanda addKorisnik(String id, String pass, String email);
        RezultatKomanda addKorisnik(String id, String pass, String email,String ime,String Prezime);

        //--------------------------------------------------------------------------
        /*
         * addKorisnik(Object korisnikObj) e func. koja
         * prima objekt od tipot korisnik, vo koj se sodrzat site informacii,
         * i vrz osnova na tie podatoci se kreira korisnik
        */

        bool addKorisnik(Object korisnikObj);
        //*************************************************************************

        //UPDATE
        //------------------------------------------------------------------------
        /*
         * updateKorisnik(Object korisnikObj)/ updateKorisnici(List<Object> korisniciList) e func. koja
         * prima objekt/i od tipot korisnik, vo koj se sodrzat site informacii,
         * i vrz osnova na tie podatoci se izmenuva korisnikot/korisnicite.
        */

        RezultatKomanda updateKorisnik(Korisnik korisnikObj);
        bool updateKorisnici(List<Object> korisniciList);

        //------------------------------------------------------------------------
        /*
         *updatePassKorisnik() e func. koja
         * ima edna zadaca - da ja promeni lozinkata na korisnikot
        */

        bool updatePassKorisnik(Object korisnikObj, String newPass);
        bool updatePassKorisnik(String id, String oldPass, String newPass);
        //*************************************************************************

        //GET
        //------------------------------------------------------------------------
        /*
         * getKorisnik/ci func. immat za cel da prevzemat podatoci od bazta za korisnicite
         * vrz osnova na vnesen kriterium.
        */
        RezultatKomanda getKorisnik(String id, ref Korisnik  korisnikObj);
        RezultatKomanda getKorisnik(String id, String pass, ref Korisnik korisnikObj);
        RezultatKomanda getKorisnici(ref List<Korisnik> korisniciLista);
        bool getKorisniciAktiven(String aktiven, ref List<Object> korisniciLista);
        bool getKorisniciTip(String tipID, ref List<Object> korisniciLista);
        bool getKorisniciAktiven_Tip(String aktiven, String tipID, ref List<Object> korisniciLista);
        //GET LIVE - AJAX
        /*
         * getLive - Ajax se povikuvat koga se pravi asinhroni obrakajna do baza
         * za etc. prebaruvanje
         */
        bool getLiveKorisnikID(String id, ref List<Object> korisniciLista);
        bool getLiveKorisnikIme(String ime, ref List<Object> korisniciLista);
        bool getLiveKorisnikPrezime(String prezime, ref List<Object> korisniciLista);
        bool getLiveKorisnik(Object korisnikObj, ref List<Object> korisniciLista);
        //Predlog
        //bool getKorisniciGrad(String gradID, ref List<Object> korisniciLista);
        //bool getKorisniciUstanova(String ustanovaID, ref List<Object> korisniciLista);
        //bool getKorisniciRole(String roleID, ref List<Object> korisniciLista);
        //bool getKorisnici(String roleID, String ustanovaID, String gradID, String aktiven, ref List<Object> korisniciLista);
        //************************************************************************

        //DEACTIVATE
        //------------------------------------------------------------------------
        /*
         * deactivateKorisnik/ci() sluzi za da zabrani pristap na korisnikot do
         * aplikacijata t.e se deaktivriat.
        */
        bool deactivateKorisnik(String id);
        bool deactivateKorisnik(Object korisnikObj);
        bool deactivateKorisnici(List<Object> korisniciList);
        //*************************************************************************

        //Proverki
        //------------------------------------------------------------------------
        /*
         *  Proverki koi bi koristele za korisnicite.
        */
        bool daliPostoiKorisnik(String id);
        bool daliPostoiKorisnik(String id, String pass);
        bool daliPostoiKorisnk(Object korisnikObj);
        //************************************************************************
    }
}

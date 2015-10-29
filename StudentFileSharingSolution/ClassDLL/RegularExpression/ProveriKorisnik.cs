using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ClassDLL.SysPart;
using ClassDLL.Interface;


namespace ClassDLL.RegularExpression
{
    /// <summary>
    /// Klasa koja e zadolzena preku regularni izrazi da gi proveri osnovnite podatoci za korisnikot:
    /// -ID, Lozinka, Email, Ime, Prezime
    /// </summary>
   public class ProveriKorisnik
    {
       /// <summary>
       /// Proverka na korektnost korisnicki ID.
        /// Dozvolena struktura: alfabeta (a-z A-Z), brojki, _, so dolzina od minimum 5 a maksimum 45 karakteri.
       /// </summary>
       /// <param name="userID">Korisnicki ID koj kje bide cel na proverka.</param>
        /// <returns>Objekt od tip RegExNas, koj vo sebe go sodrzi rezultatot od proverkata.</returns>
       public IRegEx ProveriUserID(String userID)
       {
           RegExNas rezultat = new RegExNas(userID);
           Regex reg = new Regex(@"^[a-zA-Z0-9_]{5}(\w){0,45}$");
           if (reg.IsMatch(userID))
           {
               rezultat.uspeh = true;
           }
           else
           {
               rezultat.poraka = "Корисничкото име треба да содржи минимум 5 карактери од латиницата, бројки или долна црта, а максимум 45 карактери";
           }

           return rezultat;

       }

       /// <summary>
       /// Proverka na korektnost korisnicka lozinka.
       /// Dozvolena struktura: site karakteri, so dolzina nad 8 karakteri so zadolzitelno koristenje na eden ili poveke broevi.
       /// </summary>
       /// <param name="lozinka">Korisnicka lozinka koj kje bide cel na proverka.</param>
       /// <returns>Objekt od tip RegExNas, koj vo sebe go sodrzi rezultatot od proverkata.</returns>
       public IRegEx ProveriLozinka(String lozinka)
       {
           RegExNas rezultat = new RegExNas(lozinka);
           Regex reg = new Regex(@"^(\w|\d){8,50}$");
           Regex reg2 = new Regex(@"\d");
           if (reg.IsMatch(lozinka) && reg2.IsMatch(lozinka))
           {
               rezultat.uspeh = true;
           }
           else
           {
               rezultat.poraka = "Лозинката треба да има минимум 8, а максимум 50 карактери и мора да содржи барем една цифра";
           }
           return rezultat;
       }

       /// <summary>
       /// Proverka na korektnost korisnicki email.
       /// Dozvolena struktura: ex_a344.mple@exam129ple.com
       /// </summary>
       /// <param name="mail">Korisnicki email koj kje bide cel na proverka.</param>
       /// <returns>Objekt od tip RegExNas, koj vo sebe go sodrzi rezultatot od proverkata.</returns>
       public IRegEx ProveriEmail(String mail)
       {
           RegExNas rezultat = new RegExNas(mail);
           Regex reg = new Regex(@"^(([^<>()[\]\\.,;:\s@\""]+"
                        + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                        + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                        + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                        + @"[a-zA-Z]{2,}))$");
           if (reg.IsMatch(mail))
           {
               rezultat.uspeh = true;
           }
           else
           {
               rezultat.poraka = "Внесете валидна email адреса";
           }

           return rezultat;
       }

       /// <summary>
       /// Proverka na korektnost korisnicko ime.
       /// Dozvolena struktura: kirilicna azbuka, so dolzina od minimum 1 a maksimum 30 karakteri.
       /// </summary>
       /// <param name="ime">Korisnicko ime koj kje bide cel na proverka.</param>
       /// <returns>Objekt od tip RegExNas, koj vo sebe go sodrzi rezultatot od proverkata.</returns>

       public IRegEx ProveriIme(String ime)
       {
           RegExNas rezultat = new RegExNas(ime);
           Regex reg = new Regex(@"^[аАбБвВгГдДѓЃеЕжЖзЗѕЅиИјЈкКлЛљЉмМнНњЊоОпПрРсСтТќЌуУфФхХцЦчЧџЏшШ]{1,30}$");
           if (reg.IsMatch(ime))
           {
               rezultat.uspeh = true;
           }
           else
           {
               rezultat.poraka = "Внесете го вашето име со кирилична поддршка (дозволени се максимум 30 букви)";
           }
           return rezultat;
       }

       /// <summary>
       /// Proverka na korektnost korisnicko prezime.
       /// Dozvolena struktura: kirilicna azbuka, so dolzina od minimum 1 a maksimum 30 karakteri.
       /// </summary>
       /// <param name="prezime">Korisnicko prezime koj kje bide cel na proverka.</param>
       /// <returns>Objekt od tip RegExNas, koj vo sebe go sodrzi rezultatot od proverkata.</returns>
       public IRegEx ProveriPrezime(String prezime)
       {
           RegExNas rezultat = new RegExNas(prezime);
           Regex reg = new Regex(@"^[аАбБвВгГдДѓЃеЕжЖзЗѕЅиИјЈкКлЛљЉмМнНњЊоОпПрРсСтТќЌуУфФхХцЦчЧџЏшШ]{1,50}$");
           if (reg.IsMatch(prezime))
           {
               rezultat.uspeh = true;
           }
           else
           {
               rezultat.poraka = "Внесете го вашето презиме со кирилична поддршка (дозволени се максимум 50 букви)";
           }
           return rezultat;
       }

          
    }
}

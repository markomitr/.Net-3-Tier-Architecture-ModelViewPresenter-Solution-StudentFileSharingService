using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
using ClassDLL.SysPart;
namespace ClassDLL.RegularExpression
{
    public  class FactoryRegEx
    {
        /// <summary>
        /// Funkcijata ima za cel da go opredeli tipot na validatorot i spored toa da vrati soodveten 
        /// regularen izraz.
        /// </summary>
        /// <param name="v">Tip na validator.</param>
        /// <param name="o">Objekt nad koj moze da se pravi validacija.</param>
        /// <returns>Regularen izraz, za opredeleniot tip na validator.</returns>
        public IRegEx Produce(ValidatorEnum v, object o)
        {
            RegExNas regex = new RegExNas();
            ProveriKorisnik korValidator;
            ProveriMaterijal matValidator;
            ProveriPoraka porValidator;
            if (v == ValidatorEnum.Korisnik_UserID)
            {
                korValidator = new ProveriKorisnik();
                regex.FunkcijaValidiraj = new RegExNas.ValidateObject(korValidator.ProveriUserID);
            }
            else if (v == ValidatorEnum.Korisnik_Lozinka)
            {
                korValidator = new ProveriKorisnik();
                regex.FunkcijaValidiraj = new RegExNas.ValidateObject(korValidator.ProveriLozinka);
            }
            else if (v == ValidatorEnum.Korisnik_Email)
            {
               korValidator = new ProveriKorisnik();
               regex.FunkcijaValidiraj = new RegExNas.ValidateObject(korValidator.ProveriEmail);
            }
            else if (v == ValidatorEnum.Korisnik_Ime)
            {
                korValidator = new ProveriKorisnik();
                regex.FunkcijaValidiraj = new RegExNas.ValidateObject(korValidator.ProveriIme);
            }
            else if (v == ValidatorEnum.Korisnik_Prezime)
            {
                korValidator = new ProveriKorisnik();
                regex.FunkcijaValidiraj = new RegExNas.ValidateObject(korValidator.ProveriPrezime);
            }
            else if (v == ValidatorEnum.Materijal_Naslov)
            {
                matValidator = new ProveriMaterijal();
                regex.FunkcijaValidiraj = new RegExNas.ValidateObject(matValidator.ProveriNaslov);
            }
            else if (v == ValidatorEnum.Materijal_Opis)
            {
                matValidator = new ProveriMaterijal();
                regex.FunkcijaValidiraj = new RegExNas.ValidateObject(matValidator.ProveriOpis);
            }
            else if (v == ValidatorEnum.Poraka_Sodrzina)
            {
                porValidator = new ProveriPoraka();
                regex.FunkcijaValidiraj = new RegExNas.ValidateObject(porValidator.ProveriPorakaSodrzina);
            }
            return regex;
            
        }
    }
}

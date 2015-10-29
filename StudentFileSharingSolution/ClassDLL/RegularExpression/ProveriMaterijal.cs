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
    /// Klasa koja ima za cel da cenzurira odredeni sodrzini koi imaat nedolicni zborovi za upotreba, koi
    /// bi mozele da voznemirat odredena celna grupa ili individua.
    /// </summary>
    public class ProveriMaterijal
    {
        /// <summary>
        /// Cenzuriranje na nedozvoleni sodrzini vo ramki na naslovot za postaven materjal.
        /// </summary>
        /// <param name="naslov">Naslov koj kje bide cel na proverka.</param>
        /// <returns>Objekt od tip RegExNas, koj vo sebe go sodrzi rezultatot od proverkata.</returns>
        public IRegEx ProveriNaslov(String naslov)
        {

            RegExNas rezultat = new RegExNas(naslov);
            Regex reg = new Regex(@"^[-0-9аАбБвВгГдДѓЃеЕжЖзЗѕЅиИјЈкКлЛљЉмМнНњЊоОпПрРсСтТќЌуУфФхХцЦчЧџЏшШ,\.!/:;?'+*)(\[\]\{\} ^_^]{1,50}$");
            
            const String CensoredText = "^_^";
            const String PatternTemplate = @"\b({0})(s?)\b";
            const RegexOptions Options = RegexOptions.IgnoreCase;

            String[] badWords = new[] { "глуп", "глупа", "глупав", "глупава", "глупави", "вол", "мрсул", "г'з", "лајно", "лајна", "лигуш", "мрсули", "курва", "кур", "пичка", "пички", "ороспија", "сељак", "гомно", "гомна", "курви", "ороспии", "простак", "простачка", "курвар", "гад", "цицка", "цицки", "дебил", "дебили", "недоделкан", "недоквакан", "ебе", "ебаго", "ебем", "пичка ти", "пичкати", "мамето", "мамата", "материна", "гз", "идиот" };

            Boolean sodrziZbor=false;
            foreach (String zbor in badWords)
            {
                if (naslov.ToLower().Contains(zbor))
                {
                    sodrziZbor = true;
                    break;
                }
            }
            if (sodrziZbor == true)
            {
                IEnumerable<Regex> badWordMatchers = badWords.Select(x => new Regex(string.Format(PatternTemplate, x), Options));

                String input = naslov;
                String output = badWordMatchers.Aggregate(input, (current, matcher) => matcher.Replace(current, CensoredText));
                naslov = output;
                rezultat.IzmenetVlez = naslov;
            }
            
            
            if (reg.IsMatch(naslov))
            {
                if (sodrziZbor == false)
                {
                    rezultat.uspeh = true;
                }
                else {
                    rezultat.uspeh = false;
                    rezultat.poraka = "Насловот е со несоодветна содржина";
                }
                
            }
            else
            {
                rezultat.poraka = "Насловот може да содржи максимум 50 кирилични букви";
            }
            return rezultat;
        }


        /// <summary>
        /// Cenzuriranje na nedozvoleni sodrzini vo ramki na opisot za postaven materjal.
        /// </summary>
        /// <param name="opis">Opis koj kje bide cel na proverka.</param>
        /// <returns>Objekt od tip IRegEx, koj vo sebe go sodrzi rezultatot od proverkata.</returns>
        public IRegEx ProveriOpis(String opis)
        {
           
            RegExNas rezultat = new RegExNas(opis);
            Regex reg = new Regex(@"^[-0-9аАбБвВгГдДѓЃеЕжЖзЗѕЅиИјЈкКлЛљЉмМнНњЊоОпПрРсСтТќЌуУфФхХцЦчЧџЏшШ,\.!/:;?'+*)(\[\]\{\} ^_^]{1,500}$");

            const String CensoredText = "^_^";
            const String PatternTemplate = @"\b({0})(s?)\b";
            const RegexOptions Options = RegexOptions.IgnoreCase;

            String[] badWords = new[] { "глуп", "глупа", "глупав", "глупава", "глупави", "вол", "мрсул", "г'з", "лајно", "лајна", "лигуш", "мрсули", "курва", "кур", "пичка", "пички", "ороспија", "сељак", "гомно", "гомна", "курви", "ороспии", "простак", "простачка", "курвар", "гад", "цицка", "цицки", "дебил", "дебили", "недоделкан", "недоквакан", "ебе", "ебаго", "ебем", "пичка ти", "пичкати", "мамето", "мамата", "материна", "гз", "идиот" };
            Boolean sodrziZbor = false;
            foreach (String zbor in badWords)
            {
                if (opis.ToLower().Contains(zbor))
                {
                    sodrziZbor = true;
                    break;
                }
            }
            if (sodrziZbor == true)
            {
                IEnumerable<Regex> badWordMatchers = badWords.Select(x => new Regex(string.Format(PatternTemplate, x), Options));

                String input = opis;
                String output = badWordMatchers.Aggregate(input, (current, matcher) => matcher.Replace(current, CensoredText));
                opis = output;
                rezultat.IzmenetVlez = opis;
                rezultat.poraka = "Описот содржи несоодвтени зборови и истите беа заменети.";
            }
            if (reg.IsMatch(opis))
            {
                rezultat.uspeh = true;
            }
            else
            {
                rezultat.uspeh = false;
                rezultat.poraka = "Описот може да содржи максимум 500 кирилични букви.";
            }
            return rezultat;
        }
    }
}

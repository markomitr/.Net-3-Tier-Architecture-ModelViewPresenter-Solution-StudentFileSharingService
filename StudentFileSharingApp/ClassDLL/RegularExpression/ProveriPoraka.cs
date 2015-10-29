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
    class ProveriPoraka
    {
        /// <summary>
        /// Cenzuriranje na nedozvoleni sodrzini vo ramki na postavena poraka.
        /// </summary>
        /// <param name="poraka">Poraka koja kje bide cel na proverka.</param>
        /// <returns>Objekt od tip RegExNas, koj vo sebe go sodrzi rezultatot od proverkata.</returns>
        public IRegEx ProveriPorakaSodrzina(String poraka)
        {
            RegExNas rezultat = new RegExNas(poraka);
            Regex reg = new Regex(@"^[-0-9аАбБвВгГдДѓЃеЕжЖзЗѕЅиИјЈкКлЛљЉмМнНњЊоОпПрРсСтТќЌуУфФхХцЦчЧџЏшШa-zA-Z,\.!/:;?'+*)(\[\]\{\} ^_^]{1,50}$");

            const String CensoredText = "^_^";
            const String PatternTemplate = @"\b({0})(s?)\b";
            const RegexOptions Options = RegexOptions.IgnoreCase;

            String[] badWords = new[] { "глуп", "глупа", "глупав", "глупава", "глупави", "вол", "мрсул", "г'з", "лајно", "лајна", "лигуш", "мрсули", "курва", "кур", "пичка", "пички", "ороспија", "сељак", "гомно", "гомна", "курви", "ороспии", "простак", "простачка", "курвар", "гад", "цицка", "цицки", "дебил", "дебили", "недоделкан", "недоквакан", "ебе", "ебаго", "ебем", "пичка ти", "пичкати", "мамето", "мамата", "материна", "гз", "идиот" };

            Boolean sodrziZbor = false;
            foreach (String zbor in badWords)
            {
                if (poraka.ToLower().Contains(zbor))
                {
                    sodrziZbor = true;
                    break;
                }
            }
            if (sodrziZbor == true)
            {
                IEnumerable<Regex> badWordMatchers = badWords.Select(x => new Regex(string.Format(PatternTemplate, x), Options));

                String input = poraka;
                String output = badWordMatchers.Aggregate(input, (current, matcher) => matcher.Replace(current, CensoredText));
                poraka = output;
                rezultat.IzmenetVlez = poraka;
            }

            if (reg.IsMatch(poraka))
            {
                if (sodrziZbor == false)
                {
                    rezultat.uspeh = true;
                }
                else
                {
                    rezultat.uspeh = false;
                    rezultat.poraka = "Пораката е со несоодветна содржина";
                }

            }
            else
            {
                rezultat.poraka = "Пораката содржи некои специјални знаци";
                rezultat.IzmenetVlez = "F";
            }
            return rezultat;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankautomat
{
    public class interagierenMitKonto
    {
        public static void Kontooptionen()
        {
            Console.ResetColor();
            Console.WriteLine("Was möchtest du tun?");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("1: Geld abheben");
            Console.WriteLine("2: Geld einzahlen");
            Console.WriteLine("3: Kontostand anzeigen lassen");
            Console.WriteLine("4: Zugriffsrechte für das Konto überprüfen");
            Console.WriteLine("5: Beenden");
            Console.WriteLine("------------------------------------------------------------");

            KontooptionAuswaehlen();
        }
        static void KontooptionAuswaehlen() {
            var pressedKey = Console.ReadKey();
            if(pressedKey.KeyChar == 49) {
                GeldAbheben();
            } else if(pressedKey.KeyChar == 50) {
                GeldEinzahlen();
            } else if(pressedKey.KeyChar == 51) {
                KontostandAnzeigen();
            } else if(pressedKey.KeyChar == 52) {
                KontoZugriffsrechte();
            } else if(pressedKey.KeyChar == 53) {
                System.Environment.Exit(1);
            } else {
                Console.Clear();
                Console.WriteLine("Ungültige Eingabe");
                Kontooptionen();
            }
        }

        static void GeldAbheben() {
            Console.WriteLine("Gib den Geldbetrag ein, welchen du abheben möchtest");
        }

        static void GeldEinzahlen() {

        }

        static void KontostandAnzeigen() {

        }

        static void KontoZugriffsrechte() {

        }
    }
}

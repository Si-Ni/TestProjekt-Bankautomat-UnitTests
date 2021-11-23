using System;
using System.IO;

namespace Bankautomat
{
    public class Program
    {
        public static Benutzer benutzer = new Benutzer();
        static void Main(string[] args)
        {
            setInputVorname();
            setInputNachname();
            KontoErstellenUndFortfahren();
        }

        public static void setInputVorname()
        {
            Console.WriteLine("Erstellen eines neuen Kontos...");
            Console.WriteLine("Gib deinen Vornamen ein:");
            Console.WriteLine("------------------------------------------------------------");
            String input = "";
            while (input == "")
            {
                input = Console.ReadLine();
            }
            benutzer.setVorname(input);
            try
            {
                Console.Clear();
            }
            catch(Exception e)
            {
                Console.WriteLine("Open console window");
            }
        }

        static void setInputNachname()
        {
            Console.WriteLine("Erstellen eines neuen Kontos...");
            Console.WriteLine("Gib deinen Nachnamen ein:");
            Console.WriteLine("------------------------------------------------------------");
            String input = "";
            while (input == "")
            {
                input = Console.ReadLine();
            }
            benutzer.setNachname(input);
            Console.Clear();
        }

        static void KontoErstellenUndFortfahren()
        {
            Console.WriteLine("Erstellen eines neuen Kontos...");
            Console.WriteLine("Gib deinen aktuellen Kontostand ein:");
            Console.WriteLine("------------------------------------------------------------");
            Double input = 0;
            try
            {
                input = Convert.ToDouble(Console.ReadLine());
                Konto konto = new Konto(input, benutzer);
                interagierenMitKonto.Kontooptionen(konto);
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ungültige Einfabe - versuche es erneut");
                Console.ResetColor();
                KontoErstellenUndFortfahren();
            }
        }
    }
}


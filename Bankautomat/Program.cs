using System;
using System.IO;

namespace Bankautomat
{
    public class Program
    {
        public static Benutzer benutzer = new Benutzer();
        public static Konto konto;
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

            //Try Catch hier Notwendig (sonst wird Fehler ausgelöst, da Test kein Konsolenfenster öffnet)
            try
            {
                Console.Clear();
            }
            catch(Exception e)
            {
                Console.WriteLine("Open console window");
            }
        }

        public static void setInputNachname()
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

            //Try Catch hier Notwendig (sonst wird Fehler ausgelöst, da Test kein Konsolenfenster öffnet)
            try
            {
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("Open console window");
            }
        }

        public static void KontoErstellenUndFortfahren()
        {
            Console.WriteLine("Erstellen eines neuen Kontos...");
            Console.WriteLine("Gib deinen aktuellen Kontostand ein:");
            Console.WriteLine("------------------------------------------------------------");
            String input;
            try
            {
                input = Console.ReadLine();
                int countDecimalDigits = input[(input.IndexOf(".") + 1)..].Length;
                if (countDecimalDigits > 2)
                {
                    throw new FormatException();
                }
                double inputDouble = Convert.ToDouble(input);
                konto = new Konto(inputDouble, benutzer);
                interagierenMitKonto.Kontooptionen();

                //Try Catch hier Notwendig (sonst wird Fehler ausgelöst, da Test kein Konsolenfenster öffnet)
                try
                {
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Open console window");
                }
            }
            catch (FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nur 2 Nachkommastellen möglich - erneut versuchen");
                Console.ResetColor();
                KontoErstellenUndFortfahren();
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


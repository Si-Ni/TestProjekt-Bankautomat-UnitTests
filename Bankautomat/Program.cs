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
            KontoInputLesenUndFortfahren();

            interagierenMitKonto.Kontooptionen();
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

            TryToClearConsole();
        }
        static void TryToClearConsole()
        {
            //Try Catch hier Notwendig (sonst wird Fehler ausgelöst, da Tests kein Konsolenfenster öffnen)
            try
            {
                Console.Clear();
            }
            catch (Exception)
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

            TryToClearConsole();
        }

        public static void KontoInputLesenUndFortfahren()
        {
            Console.WriteLine("Erstellen eines neuen Kontos...");
            Console.WriteLine("Gib deinen aktuellen Kontostand ein:");
            Console.WriteLine("------------------------------------------------------------");
            KontoInputVerarbeiten();

            TryToClearConsole();
        }

        public static void KontoInputVerarbeiten()
        {
            try
            {
                KontoErstellen();
            }
            catch (FormatException)
            {
                FehlerAusgebenMehrAls2Nachkommastellen();
                KontoErstellen();
            }
            catch (Exception)
            {
                FehlerAusgebenInvalidInput();
                KontoErstellen();
            }
        }

        static void KontoErstellen()
        {
            String input = Console.ReadLine();
            int countDecimalDigits = input[(input.IndexOf(".") + 1)..].Length;
            if (countDecimalDigits > 2)
            {
                throw new FormatException();
            }
            double inputDouble = Convert.ToDouble(input);
            konto = new Konto(inputDouble, benutzer);
        }

        static void FehlerAusgebenMehrAls2Nachkommastellen()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nur 2 Nachkommastellen möglich - erneut versuchen");
            Console.ResetColor();
        }

        static void FehlerAusgebenInvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ungültige Einfabe - versuche es erneut");
            Console.ResetColor();
        }
    }
}


using NUnit.Framework;
using System;
using System.IO;

namespace TestBankautomat.UnitTests
{
    public class Tests
    {
        [Test]
        public void KontodatenBenutzerVorname_GetVorname_ReturnsVorname()
        {
            var benutzer = new Bankautomat.Benutzer();
            benutzer.setVorname("TestVorname");

            string result = benutzer.getVorname();

            Assert.AreEqual("TestVorname", result);
        }

        [Test]
        public void KontodatenBenutzerNachname_GetNachname_ReturnsNachname()
        {
            var benutzer = new Bankautomat.Benutzer();
            benutzer.setNachname("TestNachname");

            string result = benutzer.getNachname();

            Assert.AreEqual("TestNachname", result);
        }

        [Test]
        public void KontodatenKontoKontostand_getKontostand_ReturnsKontostand()
        {
            var benutzer = new Bankautomat.Benutzer();
            double preSetKontostand = 3000;
            var konto = new Bankautomat.Konto(preSetKontostand, benutzer);

            double result = konto.getKontostand();

            Assert.AreEqual(3000, result);
        }

        [Test]
        public void KontodatenKontoKontostand_changeKontostand_ChangesKontostand()
        {
            var benutzer = new Bankautomat.Benutzer();
            double preSetKontostand = 3000;
            var konto = new Bankautomat.Konto(preSetKontostand, benutzer);
            double changeKontostandBy = -150.56;
            konto.changeKontostand(changeKontostandBy);

            double result = konto.getKontostand();
            double expectedResult = preSetKontostand + changeKontostandBy;

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void KontodatenKontoKannZugegriffenWerdenVon_UserIsOwner_ReturnsTrue()
        {
            var besitzer = new Bankautomat.Benutzer();
            var konto = new Bankautomat.Konto(3000, besitzer);

            bool result = konto.kannZugegriffenWerdenVon(besitzer);

            Assert.IsTrue(result);
        }

        [Test]
        public void KontodatenKontoKannZugegriffenWerdenVon_UserIsNotOwner_ReturnsFalse()
        {
            var besitzer = new Bankautomat.Benutzer();
            var konto = new Bankautomat.Konto(3000, besitzer);
            var andererBenutzer = new Bankautomat.Benutzer();

            bool result = konto.kannZugegriffenWerdenVon(andererBenutzer);

            Assert.IsFalse(result);
        }

        [Test]
        public void Program_SetInputVorname_VornameCorrectlySet()
        {
            String testName = "testVorname";
            var stringReader = new StringReader(testName);
            Console.SetIn(stringReader);

            Bankautomat.Program.setInputVorname();

            String result = Bankautomat.Program.benutzer.getVorname();
            Assert.AreEqual(testName, result);
        }

        [Test]
        public void Program_SetInputNachname_NachnameCorrectlySet()
        {
            String testName = "testNachname";
            var stringReader = new StringReader(testName);
            Console.SetIn(stringReader);

            Bankautomat.Program.setInputNachname();

            String result = Bankautomat.Program.benutzer.getNachname();
            Assert.AreEqual(testName, result);
        }

        [Test]
        public void ProgramKontoErstellen_ValidInput_KontoErstellenUndKontostandSetzen()
        {
            String testKontostand = "315.79";
            var stringReader = new StringReader(testKontostand);
            Console.SetIn(stringReader);

            Bankautomat.Program.KontoErstellenUndFortfahren();

            Double result = Bankautomat.Program.konto.getKontostand();
            Assert.AreEqual(Convert.ToDouble(testKontostand), result);
        }

    }
}
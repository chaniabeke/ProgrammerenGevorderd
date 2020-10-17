using Microsoft.VisualStudio.TestTools.UnitTesting;
using Covid19;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;
using Covid19Tests;

namespace Covid19.Tests
{
    [TestClass()]
    public class ImporterTests
    {
        private Importer _importer;
        private Exporter _exporter;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Executes once before the test run. (Optional)
        }

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            // Executes once for the test class. (Optional)
        }

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
            _importer = new Importer();
            _exporter = new Exporter();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // Executes once after the test run. (Optional)
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            // Runs once after all tests in this class are executed. (Optional)
            // Not guaranteed that it executes instantly after all tests from the class.
        }

        [TestCleanup]
        public void TearDown()
        {
            // Runs after each test. (Optional)
        }

        [TestMethod]
        public void GetMortality_ShouldReturnMortalityList_IfMortalityWasDownloadedCorrectly()
        {
            var expected = _importer.GetMortality();
            Assert.IsInstanceOfType(expected, typeof(List<Mortality>));
        }

        [TestMethod]
        public void ReadMortalityFromJsonFile_ShouldBeSameCountAsGetMortality_IfJsonWasImportedCorrectly()
        {
            var expected = _importer.GetMortality();
            _exporter.WriteJsonFile(expected, @"mortality.json");
            var jsonActual = _importer.ReadMortalityFromJsonFile(@"mortality.json");
            
            Assert.AreEqual(expected.Count, jsonActual.Count);
        }
        [TestMethod]
        public void ReadMortalityFromJsonFile_FirstMortalityObjectShouldBeOfSameValues_IfJsonWasImportedCorrectly()
        {
            var expected = _importer.GetMortality();
            _exporter.WriteJsonFile(expected, @"mortality.json");
            var jsonActual = _importer.ReadMortalityFromJsonFile(@"mortality.json");

            var expectedFirstMortality = expected.First();
            var jsonFirstMortality = jsonActual.First();
            Assert.AreEqual(expectedFirstMortality.AgeGroup, jsonFirstMortality.AgeGroup);
            Assert.AreEqual(expectedFirstMortality.Date, jsonFirstMortality.Date);
            Assert.AreEqual(expectedFirstMortality.DeathCount, jsonFirstMortality.DeathCount);
            Assert.AreEqual(expectedFirstMortality.Region, jsonFirstMortality.Region);
            Assert.AreEqual(expectedFirstMortality.Sex, jsonFirstMortality.Sex);
        }
        [TestMethod]
        public void ReadMortalityFromJsonFile_MortalityListsObjectShouldHaveSameDates_IfJsonWasImportedCorrectly()
        {
            var expected = _importer.GetMortality();
            _exporter.WriteJsonFile(expected, @"mortality.json");
            var jsonActual = _importer.ReadMortalityFromJsonFile(@"mortality.json");

            CollectionAssert.AreEqual(expected, jsonActual, new MortalityComparer());
        }

        public void ReadMortalityFromXmlFile_ShouldBeSameCountAsGetMortality_IfXmlWasImportedCorrectly()
        {
            var expected = _importer.GetMortality();
            _exporter.WriteXmlFile(expected, @"mortality.xml");
            var xmlActual = _importer.ReadMortalityFromXmlFile(@"mortality.xml");

            Assert.AreEqual(expected.Count, xmlActual.Count);
        }
        [TestMethod]
        public void ReadMortalityFromXmlFile_FirstMortalityObjectShouldBeOfSameValues_IfXmlWasImportedCorrectly()
        {
            var expected = _importer.GetMortality();
            _exporter.WriteXmlFile(expected, @"mortality.xml");
            var xmlActual = _importer.ReadMortalityFromXmlFile(@"mortality.xml");

            var expectedFirstMortality = expected.First();
            var xmlFirstMortality = xmlActual.First();
            Assert.AreEqual(expectedFirstMortality.AgeGroup, xmlFirstMortality.AgeGroup);
            Assert.AreEqual(expectedFirstMortality.Date, xmlFirstMortality.Date);
            Assert.AreEqual(expectedFirstMortality.DeathCount, xmlFirstMortality.DeathCount);
            Assert.AreEqual(expectedFirstMortality.Region, xmlFirstMortality.Region);
            Assert.AreEqual(expectedFirstMortality.Sex, xmlFirstMortality.Sex);
        }
        [TestMethod]
        public void ReadMortalityFromXmlFile_MortalityListsObjectShouldHaveSameDates_IfXmlWasImportedCorrectly()
        {
            var expected = _importer.GetMortality();
            _exporter.WriteXmlFile(expected, @"mortality.xml");
            var xmlActual = _importer.ReadMortalityFromXmlFile(@"mortality.xml");

            CollectionAssert.AreEqual(expected, xmlActual, new MortalityComparer());
        }

        [TestMethod]
        public void GetCases_ShouldReturnCasesList_IfCasesWasDownloadedCorrectly()
        {
            var expected = _importer.GetCases();
            Assert.IsInstanceOfType(expected, typeof(List<Case>));
        }

        [TestMethod]
        public void ReadCasesFromJsonFile_ShouldBeSameCountAsGetCases_IfJsonWasImportedCorrectly()
        {
            var expected = _importer.GetCases();
            _exporter.WriteJsonFile(expected, @"cases.json");
            var jsonActual = _importer.ReadCasesFromJsonFile(@"cases.json");

            Assert.AreEqual(expected.Count, jsonActual.Count);
        }
        [TestMethod]
        public void ReadCasesFromJsonFile_FirstCasesObjectShouldBeOfSameValues_IfJsonWasImportedCorrectly()
        {
            var expected = _importer.GetCases();
            _exporter.WriteJsonFile(expected, @"cases.json");
            var jsonActual = _importer.ReadCasesFromJsonFile(@"cases.json");

            var expectedFirstCase = expected.First();
            var jsonFirstCase = jsonActual.First();
            Assert.AreEqual(expectedFirstCase.Arrondissement_FR, jsonFirstCase.Arrondissement_FR);
            Assert.AreEqual(expectedFirstCase.Arrondissement_NL, jsonFirstCase.Arrondissement_NL);
            Assert.AreEqual(expectedFirstCase.Cases, jsonFirstCase.Cases);
            Assert.AreEqual(expectedFirstCase.Date, jsonFirstCase.Date);
            Assert.AreEqual(expectedFirstCase.Niss, jsonFirstCase.Niss);
            Assert.AreEqual(expectedFirstCase.Province, jsonFirstCase.Province);
            Assert.AreEqual(expectedFirstCase.Region, jsonFirstCase.Region);
            Assert.AreEqual(expectedFirstCase.Town_FR, jsonFirstCase.Town_FR);
            Assert.AreEqual(expectedFirstCase.Town_NL, jsonFirstCase.Town_NL);
        }
        [TestMethod]
        public void ReadCasesFromJsonFile_CasesListsObjectShouldHaveSameNiss_IfJsonWasImportedCorrectly()
        {
            var expected = _importer.GetCases();
            _exporter.WriteJsonFile(expected, @"cases.json");
            var jsonActual = _importer.ReadCasesFromJsonFile(@"cases.json");

            CollectionAssert.AreEqual(expected, jsonActual, new CasesComparer());
        }

        public void ReadCasesFromXmlFile_ShouldBeSameCountAsGetCases_IfXmlWasImportedCorrectly()
        {
            var expected = _importer.GetCases();
            _exporter.WriteXmlFile(expected, @"cases.xml");
            var xmlActual = _importer.ReadMortalityFromXmlFile(@"cases.xml");

            Assert.AreEqual(expected.Count, xmlActual.Count);
        }
        [TestMethod]
        public void ReadCasesFromXmlFile_FirstCaseObjectShouldBeOfSameValues_IfXmlWasImportedCorrectly()
        {
            var expected = _importer.GetCases();
            _exporter.WriteXmlFile(expected, @"cases.xml");
            var xmlActual = _importer.ReadCasesFromXmlFile(@"cases.xml");

            var expectedFirstCase = expected.First();
            var xmlFirstCase = xmlActual.First();
            Assert.AreEqual(expectedFirstCase.Arrondissement_FR, xmlFirstCase.Arrondissement_FR);
            Assert.AreEqual(expectedFirstCase.Arrondissement_NL, xmlFirstCase.Arrondissement_NL);
            Assert.AreEqual(expectedFirstCase.Cases, xmlFirstCase.Cases);
            Assert.AreEqual(expectedFirstCase.Date, xmlFirstCase.Date);
            Assert.AreEqual(expectedFirstCase.Niss, xmlFirstCase.Niss);
            Assert.AreEqual(expectedFirstCase.Province, xmlFirstCase.Province);
            Assert.AreEqual(expectedFirstCase.Region, xmlFirstCase.Region);
            Assert.AreEqual(expectedFirstCase.Town_FR, xmlFirstCase.Town_FR);
            Assert.AreEqual(expectedFirstCase.Town_NL, xmlFirstCase.Town_NL);
        }
        [TestMethod]
        public void ReadCasesFromXmlFile_CasesListsObjectShouldHaveSameNiss_IfXmlWasImportedCorrectly()
        {
            var expected = _importer.GetCases();
            _exporter.WriteXmlFile(expected, @"cases.xml");
            var xmlActual = _importer.ReadCasesFromXmlFile(@"cases.xml");

            CollectionAssert.AreEqual(expected, xmlActual, new CasesComparer());
        }
    }
}
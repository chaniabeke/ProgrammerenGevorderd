using BusinessLayer;
using BusinessLayer.Events;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayerTests
{
    [TestClass]
    public class EventTests
    {

        [TestMethod]
        public void Bestel_BijCorrecteBestelling_ZouBestellingEventMoetenOpgeroepenZijn()
        {
            BestellingsSysteem bestellingsSysteem = new BestellingsSysteem();
            Bel bel = new Bel();
            Klant klant1 = new Klant("Piet");

            Ober ober = new Ober("Jan")
            {
                BestellingsSysteem = bestellingsSysteem,
                Bel = bel,
            };
            Kok kok = new Kok("Marie")
            {
                BestellingsSysteem = bestellingsSysteem,
                Bel = bel,
            };

            using (var monitoredSubject = bestellingsSysteem.Monitor())
            {
                klant1.Bestel(ober, "Hoegaarden");
                monitoredSubject.Should().Raise("BestellingEvent");
            }
        }
    }
}

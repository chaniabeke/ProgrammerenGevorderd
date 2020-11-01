using BusinessLayer.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Kok
    {
        #region Properties
        public string Naam { get; set; }

        private BestellingsSysteem _bestellingsSysteem;
        public BestellingsSysteem BestellingsSysteem
        {
            get
            {
                return _bestellingsSysteem;
            }
            set
            {
                if (_bestellingsSysteem != null) _bestellingsSysteem.BestellingEvent -= BestellingOntvangen;
                _bestellingsSysteem = value;
                _bestellingsSysteem.BestellingEvent += BestellingOntvangen;
            }
        }
        public Bel Bel { get; set; }
        #endregion

        #region Ctor
        public Kok(string naam)
        {
            Naam = naam;
        }
        #endregion

        #region Method
        public void BestellingOntvangen(object sender, BestelEventArgs args)
        {
            if (args == null || string.IsNullOrEmpty(args.Product)) return;

            System.Console.WriteLine(args.Product + " in voorbereiding");
            System.Threading.Thread.Sleep(5000);
            Bel.Ring(args);
        }
        #endregion
    }
}
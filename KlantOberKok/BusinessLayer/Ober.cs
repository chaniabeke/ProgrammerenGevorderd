using BusinessLayer.Events;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Ober
    {
        #region Properties
        private List<Klant> _klanten = new List<Klant>();

        public string Naam { get; set; }

        public BestellingsSysteem BestellingsSysteem { get; set; }

        private Bel _bel;

        public Bel Bel
        {
            get
            {
                return this._bel;
            }

            set
            {
                if (this._bel != null) this._bel.RingEvent -= this.BelGehoord;
                this._bel = value;
                this._bel.RingEvent += this.BelGehoord;
            }
        }
        #endregion

        #region Properties
        public Ober(string naam)
        {
            Naam = naam;
        }
        #endregion

        #region Methods
        public void BrengBestelling(Klant klant, string product)
        {
            if (klant == null || string.IsNullOrEmpty(product)) return;

            if (!_klanten.Contains(klant))
                _klanten.Add(klant);

            BestellingsSysteem.GeefBestellingIn(new BestelEventArgs { Klant = klant.Naam, Product = product });
        }
        private void BelGehoord(object sender, BestelEventArgs args)
        {
            var klant = this._klanten.Where(k => k.Naam == args.Klant).FirstOrDefault();
            if (klant == null) return;
            klant.Betaal(args.Product);
            klant.Consumeer(args.Product);
        }
        #endregion
    }
}

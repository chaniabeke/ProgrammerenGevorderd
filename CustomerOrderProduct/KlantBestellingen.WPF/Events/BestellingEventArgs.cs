using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KlantBestellingen.WPF.Events
{
    public class BestellingEventArgs : EventArgs
    {
        public Order Bestelling { get; set; }
    }
}

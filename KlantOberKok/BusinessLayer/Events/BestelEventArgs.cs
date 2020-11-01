using System;

namespace BusinessLayer.Events
{
    public class BestelEventArgs : EventArgs
    {
        public string Klant { get; set; }

        public string Product { get; set; }
    }
}

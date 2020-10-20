using System;

namespace EventsWinkelStockOef
{
    public class WinkelEventArgs : EventArgs
    {
        public Bestelling Bestelling { get; set; }
    }
}
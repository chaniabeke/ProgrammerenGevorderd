﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EventsWinkelStockOef
{
   public class StockbeheerEventArgs : EventArgs
    {
        public Bestelling Bestelling { get; set; }
    }
}

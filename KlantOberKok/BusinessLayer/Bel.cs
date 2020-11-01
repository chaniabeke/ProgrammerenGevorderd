using BusinessLayer.Events;
using System;

namespace BusinessLayer
{
    public class Bel
    {
        #region Events
        public event EventHandler<BestelEventArgs> RingEvent;
        #endregion

        #region Methods
        public void Ring(BestelEventArgs args)
        {
            RingEvent?.Invoke(this, args);
        }
        #endregion
    }
}

using Covid19;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Tests
{
    public class MortalityComparer : Comparer<Mortality>
    {
        public override int Compare(Mortality x, Mortality y)
        {
            return x.Date.CompareTo(y.Date);
        }
    }
}

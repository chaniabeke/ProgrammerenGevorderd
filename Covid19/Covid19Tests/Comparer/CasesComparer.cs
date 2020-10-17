using Covid19;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Tests
{
    public class CasesComparer : Comparer<Case>
    {
        public override int Compare(Case x, Case y)
        {
            return x.Date.CompareTo(y.Date);
        }
    }
}

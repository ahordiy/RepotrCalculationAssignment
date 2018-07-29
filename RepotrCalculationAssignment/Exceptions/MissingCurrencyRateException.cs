using System;
using System.Collections.Generic;
using System.Text;

namespace ReportCalculationAssignment.Exceptions
{
    public class MissingCurrencyRateException
        : Exception
    {
        public CurrencyEnum Currency { get; private set; }

        public MissingCurrencyRateException( CurrencyEnum currency )
        {
            Currency = currency;
        }
    }
}

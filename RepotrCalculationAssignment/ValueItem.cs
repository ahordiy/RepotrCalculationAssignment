using System;
using System.Collections.Generic;
using System.Text;

namespace ReportCalculationAssignment
{
    public class ValueItem
    {
        public CurrencyEnum Currency { get; private set; }
        public decimal Value { get; private set; }

        private ValueItem(){}

        public ValueItem( CurrencyEnum currency, decimal value )
        {
            Currency = currency;
            Value = value;
        }
    }
}

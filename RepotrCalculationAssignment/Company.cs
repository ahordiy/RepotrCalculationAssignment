using System;
using System.Collections.Generic;
using System.Text;

namespace ReportCalculationAssignment
{
    public class Company
    {
        public string Name { get; set; }

        public long Shares { get; set; }
        public ValueItem Price { get; set; }

        public ValueItem TotalPrice
        {
            get
            {
                return new ValueItem( Price.Currency, Price.Value * Shares );
            }
        }
    }
}

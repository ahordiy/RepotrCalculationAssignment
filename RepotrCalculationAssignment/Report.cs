using System;
using System.Collections.Generic;
using System.Text;

namespace ReportCalculationAssignment
{
    public class Report
    {
        ICurrencyExchanger _exchangingService;
        ICompanyProvider _dataProvider;

        public Report( ICurrencyExchanger exchangingService, ICompanyProvider dataProvider )
        {
            if ( null == exchangingService ) throw new ArgumentNullException( "exchangingService" );
            if ( null == dataProvider ) throw new ArgumentNullException( "dataProvider" );

            _exchangingService = exchangingService;
            _dataProvider = dataProvider;            
        }

        public ValueItem CalculateSharesTotal( CurrencyEnum currency = CurrencyEnum.USD )
        {
            decimal total = 0m; 
            foreach ( var company in _dataProvider.GetCompanies() )
            {
                total += _exchangingService.GetValueInCurrency( company.TotalPrice, currency );
            }

            return new ValueItem( currency, total );
        }
    }
}

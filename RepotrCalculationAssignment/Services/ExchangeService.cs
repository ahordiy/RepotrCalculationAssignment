using ReportCalculationAssignment.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportCalculationAssignment.Services
{
    public class ExchangeService
        : ICurrencyExchanger
    {
        Dictionary<CurrencyEnum, decimal> _rates;

        public CurrencyEnum BasicCurrency { get; private set; }

        public ExchangeService( CurrencyEnum basicCurrency )
        {
            _rates = new Dictionary<CurrencyEnum, decimal>();
            BasicCurrency = basicCurrency;
            _rates.Add( basicCurrency, 1m );
        }
        
        public void AssignRate( CurrencyEnum currency, decimal rate )
        {
            if ( rate <=0 )
            {
                throw new ArgumentOutOfRangeException( "rate", rate, "Positive values only" );
            }

            if ( BasicCurrency == currency )
            {
                throw new ArgumentException( "currency", "Basic currency cannot have the excange rate" );
            }

            if ( _rates.ContainsKey( currency ) )
            {
                _rates[ currency ] = rate;
            }
            else
            {
                _rates.Add( currency, rate );
            }
        }

        public decimal GetValueInCurrency( ValueItem val, CurrencyEnum currency )
        {
            if ( !_rates.ContainsKey( val.Currency ) ) throw new MissingCurrencyRateException( val.Currency );
            if ( !_rates.ContainsKey( currency ) ) throw new MissingCurrencyRateException( currency );

            var destRate = _rates[ currency ];
            var srcRate = _rates[ val.Currency ];

            var res = val.Value * destRate / srcRate;


            return res;
        }
    }
}

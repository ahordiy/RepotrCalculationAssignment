using Moq;
using ReportCalculationAssignment.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace ReportCalculationAssignment.XUnitTests
{
    public class Report_Should
    {
        [Fact]
        public void CalculateTotal()
        {
            var dataMoq = new Mock<ICompanyProvider>();
            dataMoq.Setup( c => c.GetCompanies() ).Returns( new List<Company>() {
                //new Company() { Name = "Postbuzz", Price = new ValueItem(CurrencyEnum.EUR, 1 ), Shares = 1 },
                //new Company() { Name = "Zara", Price = new ValueItem(CurrencyEnum.USD, 1 ), Shares = 1 },
                new Company() { Name = "Blizenko", Price = new ValueItem(CurrencyEnum.UAH, 100 ), Shares = 100 },
                //new Company() { Name = "Cat", Price = new ValueItem(CurrencyEnum.CHF, 1 ), Shares = 1 },
            } );

            var exchangeService = new ExchangeService( CurrencyEnum.USD );

            exchangeService.AssignRate( CurrencyEnum.EUR, 0.85m );
            exchangeService.AssignRate( CurrencyEnum.UAH, 26.78m );
            exchangeService.AssignRate( CurrencyEnum.CHF, 1m );

            /*exchangeService.AssignRate( CurrencyEnum.EUR, 0.857818m );
            exchangeService.AssignRate( CurrencyEnum.UAH, 26.78m );
            exchangeService.AssignRate( CurrencyEnum.CHF, 0.99m );
            */

            var reportCurrency = CurrencyEnum.EUR;
            Report rep = new Report( exchangeService, dataMoq.Object );

            var result = rep.CalculateSharesTotal( );
            
            Debug.Assert( result.Currency == reportCurrency && result.Value > 0 );
        }
    }
}

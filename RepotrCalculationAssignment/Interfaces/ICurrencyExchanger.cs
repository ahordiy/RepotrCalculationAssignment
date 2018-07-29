namespace ReportCalculationAssignment
{
    public interface ICurrencyExchanger
    {
        decimal GetValueInCurrency( ValueItem val, CurrencyEnum currency );
    }
}
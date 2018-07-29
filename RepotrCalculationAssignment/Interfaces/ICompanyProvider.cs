using System.Collections.Generic;

namespace ReportCalculationAssignment
{
    public interface ICompanyProvider
    {
        IEnumerable<Company> GetCompanies();
    }
}
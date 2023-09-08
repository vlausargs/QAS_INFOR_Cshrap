using System;

namespace CSI.Reporting
{
    public interface IRpt_SalesVATRegisterGetInvHdrTaxDate
    {
        DateTime? GetInvHdrTaxDate(string ReportType, DateTime? InvTaxInvDate, DateTime? InvHdrTaxDate, int? PolandCountryPack);
    }
}

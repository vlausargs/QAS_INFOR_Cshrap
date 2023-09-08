using CSI.Data;
using System;

namespace CSI.Reporting
{
    public class Rpt_SalesVATRegisterGetInvHdrTaxDate : IRpt_SalesVATRegisterGetInvHdrTaxDate
    {
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IConvertToUtil convertToUtil;

        public Rpt_SalesVATRegisterGetInvHdrTaxDate(ISQLValueComparerUtil sQLUtil, IConvertToUtil convertToUtil)
        {
            this.sQLUtil = sQLUtil ?? throw new ArgumentNullException(nameof(sQLUtil));
            this.convertToUtil = convertToUtil ?? throw new ArgumentNullException(nameof(convertToUtil));
        }

        public DateTime? GetInvHdrTaxDate(string ReportType, DateTime? InvTaxInvDate, DateTime? InvHdrTaxDate, int? PolandCountryPack)
        {
            if((sQLUtil.SQLNotEqual(ReportType, "Standard") == true))
            {
                InvHdrTaxDate = convertToUtil.ToDateTime(InvTaxInvDate);
            }
            else
            {
                if ((sQLUtil.SQLEqual(PolandCountryPack, 1) == true))
                {
                    if (InvHdrTaxDate == null)
                    {
                        InvHdrTaxDate = convertToUtil.ToDateTime(InvTaxInvDate);
                    }
                }
                else
                {
                    InvHdrTaxDate = convertToUtil.ToDateTime(InvTaxInvDate);
                }
            }

            return InvHdrTaxDate;
        }
    }
}

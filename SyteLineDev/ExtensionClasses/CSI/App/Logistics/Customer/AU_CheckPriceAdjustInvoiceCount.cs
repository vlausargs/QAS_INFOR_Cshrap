//PROJECT NAME: CSICustomer
//CLASS NAME: AU_CheckPriceAdjustInvoiceCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IAU_CheckPriceAdjustInvoiceCount
    {
        int AU_CheckPriceAdjustInvoiceCountSp(RowPointerType SessionID,
                                              ref IntType InvoiceCount);
    }

    public class AU_CheckPriceAdjustInvoiceCount : IAU_CheckPriceAdjustInvoiceCount
    {
        readonly IApplicationDB appDB;

        public AU_CheckPriceAdjustInvoiceCount(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AU_CheckPriceAdjustInvoiceCountSp(RowPointerType SessionID,
                                                     ref IntType InvoiceCount)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AU_CheckPriceAdjustInvoiceCountSp";

                appDB.AddCommandParameter(cmd, "SessionID", SessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvoiceCount", InvoiceCount, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

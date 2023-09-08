//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_ResidualInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICLM_ResidualInvoice
    {
        DataTable CLM_ResidualInvoiceSp(InvNumType PStartingInvNum,
                                        InvNumType PEndingInvNum,
                                        CustNumType PStartingCustNum,
                                        CustNumType PEndingCustNum,
                                        DateTimeType PStartingInvDate,
                                        DateTimeType PEndingInvDate,
                                        AmountType PStartingAmount,
                                        AmountType PEndingAmount,
                                        CurrCodeType PCurrencyCode);
    }

    public class CLM_ResidualInvoice : ICLM_ResidualInvoice
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_ResidualInvoice(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_ResidualInvoiceSp(InvNumType PStartingInvNum,
                                               InvNumType PEndingInvNum,
                                               CustNumType PStartingCustNum,
                                               CustNumType PEndingCustNum,
                                               DateTimeType PStartingInvDate,
                                               DateTimeType PEndingInvDate,
                                               AmountType PStartingAmount,
                                               AmountType PEndingAmount,
                                               CurrCodeType PCurrencyCode)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_ResidualInvoiceSp";

                    appDB.AddCommandParameter(cmd, "PStartingInvNum", PStartingInvNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PEndingInvNum", PEndingInvNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PStartingCustNum", PStartingCustNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PEndingCustNum", PEndingCustNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PStartingInvDate", PStartingInvDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PEndingInvDate", PEndingInvDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PStartingAmount", PStartingAmount, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PEndingAmount", PEndingAmount, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PCurrencyCode", PCurrencyCode, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
                }
            }
            finally
            {
                bunchedLoadCollection.EndBunching();
            }
        }
    }
}

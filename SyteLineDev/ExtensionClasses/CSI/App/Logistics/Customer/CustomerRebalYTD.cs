//PROJECT NAME: CSICustomer
//CLASS NAME: CustomerRebalYTD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICustomerRebalYTD
    {
        DataTable CustomerRebalYTDSp(string StartingCustomer,
                                     string EndingCustomer,
                                     DateTime? YearStart,
                                     DateTime? YearEnd,
                                     DateTime? PeriodStart,
                                     DateTime? PeriodEnd,
                                     DateTime? LastYearStart,
                                     DateTime? LastYearEnd,
                                     byte? ResetSalesYTD,
                                     byte? ResetSalesLstYr,
                                     byte? ResetSalesPTD,
                                     byte? ResetDiscYTD,
                                     byte? ResetDiscLstYr,
                                     string ProcessVar,
                                     byte? ExceptionsOnly);
    }

    public class CustomerRebalYTD : ICustomerRebalYTD
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CustomerRebalYTD(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CustomerRebalYTDSp(string StartingCustomer,
                                            string EndingCustomer,
                                            DateTime? YearStart,
                                            DateTime? YearEnd,
                                            DateTime? PeriodStart,
                                            DateTime? PeriodEnd,
                                            DateTime? LastYearStart,
                                            DateTime? LastYearEnd,
                                            byte? ResetSalesYTD,
                                            byte? ResetSalesLstYr,
                                            byte? ResetSalesPTD,
                                            byte? ResetDiscYTD,
                                            byte? ResetDiscLstYr,
                                            string ProcessVar,
                                            byte? ExceptionsOnly)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                CustNumType _StartingCustomer = StartingCustomer;
                CustNumType _EndingCustomer = EndingCustomer;
                DateType _YearStart = YearStart;
                DateType _YearEnd = YearEnd;
                DateType _PeriodStart = PeriodStart;
                DateType _PeriodEnd = PeriodEnd;
                DateType _LastYearStart = LastYearStart;
                DateType _LastYearEnd = LastYearEnd;
                ListYesNoType _ResetSalesYTD = ResetSalesYTD;
                ListYesNoType _ResetSalesLstYr = ResetSalesLstYr;
                ListYesNoType _ResetSalesPTD = ResetSalesPTD;
                ListYesNoType _ResetDiscYTD = ResetDiscYTD;
                ListYesNoType _ResetDiscLstYr = ResetDiscLstYr;
                StringType _ProcessVar = ProcessVar;
                ListYesNoType _ExceptionsOnly = ExceptionsOnly;

                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CustomerRebalYTDSp";

                    appDB.AddCommandParameter(cmd, "StartingCustomer", _StartingCustomer, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "EndingCustomer", _EndingCustomer, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "YearStart", _YearStart, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "YearEnd", _YearEnd, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PeriodStart", _PeriodStart, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PeriodEnd", _PeriodEnd, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "LastYearStart", _LastYearStart, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "LastYearEnd", _LastYearEnd, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ResetSalesYTD", _ResetSalesYTD, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ResetSalesLstYr", _ResetSalesLstYr, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ResetSalesPTD", _ResetSalesPTD, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ResetDiscYTD", _ResetDiscYTD, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ResetDiscLstYr", _ResetDiscLstYr, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ProcessVar", _ProcessVar, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExceptionsOnly", _ExceptionsOnly, ParameterDirection.Input);

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

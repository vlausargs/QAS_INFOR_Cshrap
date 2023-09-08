//PROJECT NAME: CSICustomer
//CLASS NAME: CustExchRateValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICustExchRateValid
    {
        int CustExchRateValidSp(string CustNum,
                                string CurrCode,
                                decimal? ExchRate,
                                DateTime? InvoiceDate,
                                ref string Infobar);
    }

    public class CustExchRateValid : ICustExchRateValid
    {
        readonly IApplicationDB appDB;

        public CustExchRateValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CustExchRateValidSp(string CustNum,
                                       string CurrCode,
                                       decimal? ExchRate,
                                       DateTime? InvoiceDate,
                                       ref string Infobar)
        {
            CustNumType _CustNum = CustNum;
            CurrCodeType _CurrCode = CurrCode;
            ExchRateType _ExchRate = ExchRate;
            DateType _InvoiceDate = InvoiceDate;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CustExchRateValidSp";

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}

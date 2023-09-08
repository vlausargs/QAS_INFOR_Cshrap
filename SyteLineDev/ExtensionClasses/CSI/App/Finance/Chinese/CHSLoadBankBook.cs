//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSLoadBankBook.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSLoadBankBook
    {
        int CHSLoadBankBookSp(BankCodeType PBankCode,
                              DateType PDateFrom,
                              DateType PDateTo,
                              ref GenericIntType PReadCount);
    }

    public class CHSLoadBankBook : ICHSLoadBankBook
    {
        readonly IApplicationDB appDB;

        public CHSLoadBankBook(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSLoadBankBookSp(BankCodeType PBankCode,
                                     DateType PDateFrom,
                                     DateType PDateTo,
                                     ref GenericIntType PReadCount)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSLoadBankBookSp";

                appDB.AddCommandParameter(cmd, "PBankCode", PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDateFrom", PDateFrom, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDateTo", PDateTo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PReadCount", PReadCount, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}


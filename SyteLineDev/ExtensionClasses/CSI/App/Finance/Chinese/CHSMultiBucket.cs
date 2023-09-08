//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSMultiBucket.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSMultiBucket
    {
        int CHSMultiBucketSp(SequenceType BookKey,
                             RfDefaultType BookType,
                             AcctType BeginAccount,
                             AcctType EndAccount,
                             UnitCode1Type BegUnit1,
                             UnitCode1Type EndUnit1,
                             UnitCode2Type BegUnit2,
                             UnitCode2Type EndUnit2,
                             UnitCode3Type BegUnit3,
                             UnitCode3Type EndUnit3,
                             UnitCode4Type BegUnit4,
                             UnitCode4Type EndUnit4,
                             DateType BeginDate,
                             DateType EndDate,
                             ListYesNoType PrintDayTotal,
                             ListYesNoType IncludeZeroBalAccount,
                             RowPointerType RptSessionID,
                             ref IntType BGTaskCount);
    }

    public class CHSMultiBucket : ICHSMultiBucket
    {
        readonly IApplicationDB appDB;

        public CHSMultiBucket(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSMultiBucketSp(SequenceType BookKey,
                                    RfDefaultType BookType,
                                    AcctType BeginAccount,
                                    AcctType EndAccount,
                                    UnitCode1Type BegUnit1,
                                    UnitCode1Type EndUnit1,
                                    UnitCode2Type BegUnit2,
                                    UnitCode2Type EndUnit2,
                                    UnitCode3Type BegUnit3,
                                    UnitCode3Type EndUnit3,
                                    UnitCode4Type BegUnit4,
                                    UnitCode4Type EndUnit4,
                                    DateType BeginDate,
                                    DateType EndDate,
                                    ListYesNoType PrintDayTotal,
                                    ListYesNoType IncludeZeroBalAccount,
                                    RowPointerType RptSessionID,
                                    ref IntType BGTaskCount)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSMultiBucketSp";

                appDB.AddCommandParameter(cmd, "BookKey", BookKey, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BookType", BookType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BeginAccount", BeginAccount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndAccount", EndAccount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegUnit1", BegUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndUnit1", EndUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegUnit2", BegUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndUnit2", EndUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegUnit3", BegUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndUnit3", EndUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegUnit4", BegUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndUnit4", EndUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BeginDate", BeginDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndDate", EndDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintDayTotal", PrintDayTotal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IncludeZeroBalAccount", IncludeZeroBalAccount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RptSessionID", RptSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BGTaskCount", BGTaskCount, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}


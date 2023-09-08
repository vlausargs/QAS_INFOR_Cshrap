//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSCustNumVarCredit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSCustNumVarCredit
    {
        int SSSFSCustNumVarCreditSp(CustNumType CustNum,
                                    ref CustSeqType CustSeq,
                                    ref NameType CustName,
                                    ref ListYesNoType CreditHold,
                                    ref ReasonCodeType CreditHoldReason,
                                    ref DescriptionType CreditHoldDescription);
    }

    public class SSSFSCustNumVarCredit : ISSSFSCustNumVarCredit
    {
        readonly IApplicationDB appDB;

        public SSSFSCustNumVarCredit(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSCustNumVarCreditSp(CustNumType CustNum,
                                           ref CustSeqType CustSeq,
                                           ref NameType CustName,
                                           ref ListYesNoType CreditHold,
                                           ref ReasonCodeType CreditHoldReason,
                                           ref DescriptionType CreditHoldDescription)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSCustNumVarCreditSp";

                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustSeq", CustSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustName", CustName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditHold", CreditHold, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditHoldReason", CreditHoldReason, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditHoldDescription", CreditHoldDescription, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

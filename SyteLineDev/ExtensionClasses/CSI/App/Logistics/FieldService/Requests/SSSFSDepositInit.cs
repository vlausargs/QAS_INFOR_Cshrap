//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSDepositInit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSDepositInit
    {
        int SSSFSDepositInitSp(ref AcctType CreditAcct,
                               ref UnitCode1Type CreditAcctUnit1,
                               ref UnitCode2Type CreditAcctUnit2,
                               ref UnitCode3Type CreditAcctUnit3,
                               ref UnitCode4Type CreditAcctUnit4,
                               ref AcctType DebitAcct,
                               ref UnitCode1Type DebitAcctUnit1,
                               ref UnitCode2Type DebitAcctUnit2,
                               ref UnitCode3Type DebitAcctUnit3,
                               ref UnitCode4Type DebitAcctUnit4,
                               ref UnitCodeAccessType CreditChtAccessUnit1,
                               ref UnitCodeAccessType CreditChtAccessUnit2,
                               ref UnitCodeAccessType CreditChtAccessUnit3,
                               ref UnitCodeAccessType CreditChtAccessUnit4,
                               ref DescriptionType CreditChtDescription,
                               ref UnitCodeAccessType DebitChtAccessUnit1,
                               ref UnitCodeAccessType DebitChtAccessUnit2,
                               ref UnitCodeAccessType DebitChtAccessUnit3,
                               ref UnitCodeAccessType DebitChtAccessUnit4,
                               ref DescriptionType DebitChtDescription,
                               ref ListYesNoType CreditChtIsControl,
                               ref ListYesNoType DebitChtIsControl,
                               ref InfobarType Infobar);
    }

    public class SSSFSDepositInit : ISSSFSDepositInit
    {
        readonly IApplicationDB appDB;

        public SSSFSDepositInit(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSDepositInitSp(ref AcctType CreditAcct,
                                      ref UnitCode1Type CreditAcctUnit1,
                                      ref UnitCode2Type CreditAcctUnit2,
                                      ref UnitCode3Type CreditAcctUnit3,
                                      ref UnitCode4Type CreditAcctUnit4,
                                      ref AcctType DebitAcct,
                                      ref UnitCode1Type DebitAcctUnit1,
                                      ref UnitCode2Type DebitAcctUnit2,
                                      ref UnitCode3Type DebitAcctUnit3,
                                      ref UnitCode4Type DebitAcctUnit4,
                                      ref UnitCodeAccessType CreditChtAccessUnit1,
                                      ref UnitCodeAccessType CreditChtAccessUnit2,
                                      ref UnitCodeAccessType CreditChtAccessUnit3,
                                      ref UnitCodeAccessType CreditChtAccessUnit4,
                                      ref DescriptionType CreditChtDescription,
                                      ref UnitCodeAccessType DebitChtAccessUnit1,
                                      ref UnitCodeAccessType DebitChtAccessUnit2,
                                      ref UnitCodeAccessType DebitChtAccessUnit3,
                                      ref UnitCodeAccessType DebitChtAccessUnit4,
                                      ref DescriptionType DebitChtDescription,
                                      ref ListYesNoType CreditChtIsControl,
                                      ref ListYesNoType DebitChtIsControl,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSDepositInitSp";

                appDB.AddCommandParameter(cmd, "CreditAcct", CreditAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditAcctUnit1", CreditAcctUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditAcctUnit2", CreditAcctUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditAcctUnit3", CreditAcctUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditAcctUnit4", CreditAcctUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DebitAcct", DebitAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DebitAcctUnit1", DebitAcctUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DebitAcctUnit2", DebitAcctUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DebitAcctUnit3", DebitAcctUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DebitAcctUnit4", DebitAcctUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditChtAccessUnit1", CreditChtAccessUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditChtAccessUnit2", CreditChtAccessUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditChtAccessUnit3", CreditChtAccessUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditChtAccessUnit4", CreditChtAccessUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditChtDescription", CreditChtDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DebitChtAccessUnit1", DebitChtAccessUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DebitChtAccessUnit2", DebitChtAccessUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DebitChtAccessUnit3", DebitChtAccessUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DebitChtAccessUnit4", DebitChtAccessUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DebitChtDescription", DebitChtDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditChtIsControl", CreditChtIsControl, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DebitChtIsControl", DebitChtIsControl, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

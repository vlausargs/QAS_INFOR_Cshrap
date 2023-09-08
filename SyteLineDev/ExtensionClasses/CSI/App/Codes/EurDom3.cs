//PROJECT NAME: CSICodes
//CLASS NAME: EurDom3.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface IEurDom3
    {
        int EurDom3Sp(DescriptionType FormName,
                      FlagNyType TUseStandard,
                      AcctType InAcct,
                      UnitCode1Type InAcctUnit1,
                      UnitCode2Type InAcctUnit2,
                      UnitCode3Type InAcctUnit3,
                      UnitCode4Type InAcctUnit4,
                      AcctType AnaInAcct,
                      UnitCode1Type AnaInAcctUnit1,
                      UnitCode2Type AnaInAcctUnit2,
                      UnitCode3Type AnaInAcctUnit3,
                      UnitCode4Type AnaInAcctUnit4,
                      ref InfobarType Infobar);
    }

    public class EurDom3 : IEurDom3
    {
        readonly IApplicationDB appDB;

        public EurDom3(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EurDom3Sp(DescriptionType FormName,
                             FlagNyType TUseStandard,
                             AcctType InAcct,
                             UnitCode1Type InAcctUnit1,
                             UnitCode2Type InAcctUnit2,
                             UnitCode3Type InAcctUnit3,
                             UnitCode4Type InAcctUnit4,
                             AcctType AnaInAcct,
                             UnitCode1Type AnaInAcctUnit1,
                             UnitCode2Type AnaInAcctUnit2,
                             UnitCode3Type AnaInAcctUnit3,
                             UnitCode4Type AnaInAcctUnit4,
                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EurDom3Sp";

                appDB.AddCommandParameter(cmd, "FormName", FormName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TUseStandard", TUseStandard, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InAcct", InAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InAcctUnit1", InAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InAcctUnit2", InAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InAcctUnit3", InAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InAcctUnit4", InAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AnaInAcct", AnaInAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AnaInAcctUnit1", AnaInAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AnaInAcctUnit2", AnaInAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AnaInAcctUnit3", AnaInAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AnaInAcctUnit4", AnaInAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

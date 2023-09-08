//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSAccountUnitAccessibility.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSAccountUnitAccessibility
    {
        int CHSAccountUnitAccessibilitySp(AcctType Account,
                                          ref UnitCodeAccessType AccessUnit1,
                                          ref UnitCodeAccessType AccessUnit2,
                                          ref UnitCodeAccessType AccessUnit3,
                                          ref UnitCodeAccessType AccessUnit4,
                                          ref InfobarType Infobar);
    }

    public class CHSAccountUnitAccessibility : ICHSAccountUnitAccessibility
    {
        readonly IApplicationDB appDB;

        public CHSAccountUnitAccessibility(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSAccountUnitAccessibilitySp(AcctType Account,
                                                 ref UnitCodeAccessType AccessUnit1,
                                                 ref UnitCodeAccessType AccessUnit2,
                                                 ref UnitCodeAccessType AccessUnit3,
                                                 ref UnitCodeAccessType AccessUnit4,
                                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSAccountUnitAccessibilitySp";

                appDB.AddCommandParameter(cmd, "Account", Account, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AccessUnit1", AccessUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit2", AccessUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit3", AccessUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit4", AccessUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}


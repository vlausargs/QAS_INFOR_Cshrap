//PROJECT NAME: CSIFinance
//CLASS NAME: JournalBuilderValidateAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IJournalBuilderValidateAcct
    {
        int JournalBuilderValidateAcctSp(AcctType Acct,
                                         DateType TransactionDate,
                                         SiteType SiteRef,
                                         GroupnameType GroupName,
                                         TokenType UserId,
                                         ListYesNoType IsSecureCtlAcct,
                                         ref UnitCodeAccessType AccessUnit1,
                                         ref UnitCodeAccessType AccessUnit2,
                                         ref UnitCodeAccessType AccessUnit3,
                                         ref UnitCodeAccessType AccessUnit4,
                                         ref DescriptionType Description,
                                         ref InfobarType Infobar);
    }

    public class JournalBuilderValidateAcct : IJournalBuilderValidateAcct
    {
        readonly IApplicationDB appDB;

        public JournalBuilderValidateAcct(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JournalBuilderValidateAcctSp(AcctType Acct,
                                                DateType TransactionDate,
                                                SiteType SiteRef,
                                                GroupnameType GroupName,
                                                TokenType UserId,
                                                ListYesNoType IsSecureCtlAcct,
                                                ref UnitCodeAccessType AccessUnit1,
                                                ref UnitCodeAccessType AccessUnit2,
                                                ref UnitCodeAccessType AccessUnit3,
                                                ref UnitCodeAccessType AccessUnit4,
                                                ref DescriptionType Description,
                                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JournalBuilderValidateAcctSp";

                appDB.AddCommandParameter(cmd, "Acct", Acct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransactionDate", TransactionDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteRef", SiteRef, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "GroupName", GroupName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserId", UserId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IsSecureCtlAcct", IsSecureCtlAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AccessUnit1", AccessUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit2", AccessUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit3", AccessUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit4", AccessUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Description", Description, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
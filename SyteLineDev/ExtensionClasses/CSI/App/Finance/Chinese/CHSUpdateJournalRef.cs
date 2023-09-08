//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSUpdateJournalRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSUpdateJournalRef
    {
        int CHSUpdateJournalRefSp(GenericMedCodeType CHVounum,
                                  DateType TransDate,
                                  ReferenceType Ref,
                                  ref InfobarType Infobar);
    }

    public class CHSUpdateJournalRef : ICHSUpdateJournalRef
    {
        readonly IApplicationDB appDB;

        public CHSUpdateJournalRef(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSUpdateJournalRefSp(GenericMedCodeType CHVounum,
                                         DateType TransDate,
                                         ReferenceType Ref,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSUpdateJournalRefSp";

                appDB.AddCommandParameter(cmd, "CHVounum", CHVounum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDate", TransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Ref", Ref, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}


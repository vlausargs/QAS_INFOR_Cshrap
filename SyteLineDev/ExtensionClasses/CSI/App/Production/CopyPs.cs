//PROJECT NAME: CSIProduct
//CLASS NAME: CopyPs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ICopyPs
    {
        int CopyPsSp(PsNumType PsFrom,
                     PsNumType PsTo,
                     ItemType BegItem,
                     ItemType EndItem,
                     DateType BegDate,
                     DateType EndDate,
                     JobStatusType PsRelStatP,
                     JobStatusType PsRelStatR,
                     JobStatusType PsRelStatC,
                     IntType DaysLookback,
                     ListYesNoType CopyBomPs,
                     ref InfobarType Infobar);
    }

    public class CopyPs : ICopyPs
    {
        readonly IApplicationDB appDB;

        public CopyPs(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CopyPsSp(PsNumType PsFrom,
                            PsNumType PsTo,
                            ItemType BegItem,
                            ItemType EndItem,
                            DateType BegDate,
                            DateType EndDate,
                            JobStatusType PsRelStatP,
                            JobStatusType PsRelStatR,
                            JobStatusType PsRelStatC,
                            IntType DaysLookback,
                            ListYesNoType CopyBomPs,
                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CopyPsSp";

                appDB.AddCommandParameter(cmd, "PsFrom", PsFrom, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PsTo", PsTo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegItem", BegItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndItem", EndItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegDate", BegDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndDate", EndDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PsRelStatP", PsRelStatP, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PsRelStatR", PsRelStatR, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PsRelStatC", PsRelStatC, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DaysLookback", DaysLookback, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CopyBomPs", CopyBomPs, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

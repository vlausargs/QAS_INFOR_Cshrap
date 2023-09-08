//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_CheckQAStartDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Automotive
{
    public interface IAU_CheckQAStartDate
    {
        int AU_CheckQAStartDateSp(AU_QAProcessIDType ProcessID,
                                  DateType StartDate,
                                  SequenceType Sequence,
                                  ref InfobarType Infobar);
    }

    public class AU_CheckQAStartDate : IAU_CheckQAStartDate
    {
        readonly IApplicationDB appDB;

        public AU_CheckQAStartDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AU_CheckQAStartDateSp(AU_QAProcessIDType ProcessID,
                                         DateType StartDate,
                                         SequenceType Sequence,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AU_CheckQAStartDateSp";

                appDB.AddCommandParameter(cmd, "ProcessID", ProcessID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartDate", StartDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Sequence", Sequence, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

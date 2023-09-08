//PROJECT NAME: CSIProduct
//CLASS NAME: SWcmachI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ISWcmachI
    {
        int SWcmachISp(WcType PWorkCenter,
                       TotalHoursType PTotalHours,
                       TimeSecondsType PStartTime,
                       TimeSecondsType PEndTime,
                       ShiftType PShift,
                       DateType PTransDate,
                       EmpNumType PEmpNum,
                       UserCodeType PUserID,
                       RowPointerType SessionID,
                       ref ListYesNoType TCoby,
                       ref HugeTransNumType JobtranTransNum,
                       ref InfobarType Infobar);
    }

    public class SWcmachI : ISWcmachI
    {
        readonly IApplicationDB appDB;

        public SWcmachI(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SWcmachISp(WcType PWorkCenter,
                              TotalHoursType PTotalHours,
                              TimeSecondsType PStartTime,
                              TimeSecondsType PEndTime,
                              ShiftType PShift,
                              DateType PTransDate,
                              EmpNumType PEmpNum,
                              UserCodeType PUserID,
                              RowPointerType SessionID,
                              ref ListYesNoType TCoby,
                              ref HugeTransNumType JobtranTransNum,
                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SWcmachISp";

                appDB.AddCommandParameter(cmd, "PWorkCenter", PWorkCenter, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTotalHours", PTotalHours, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PStartTime", PStartTime, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEndTime", PEndTime, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PShift", PShift, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTransDate", PTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEmpNum", PEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PUserID", PUserID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SessionID", SessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TCoby", TCoby, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobtranTransNum", JobtranTransNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

//PROJECT NAME: MG.MGCore
//CLASS NAME: BGTaskSubmit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class BGTaskSubmit : IBGTaskSubmit
    {
        IApplicationDB appDB;


        public BGTaskSubmit(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar,
        decimal? TaskID,
        Guid? TaskHistoryRowPointer,
        int? PreviewInterval) BGTaskSubmitSp(string TaskName,
        string TaskParms1,
        string TaskParms2,
        string Infobar,
        decimal? TaskID = 0,
        string TaskStatusCode = "READY",
        string StringTable = null,
        string RequestingUser = null,
        int? PrintPreview = 0,
        Guid? TaskHistoryRowPointer = null,
        int? PreviewInterval = null,
        DateTime? SchedStartDateTime = null,
        DateTime? SchedEndDateTime = null,
        int? SchedFreqType = 1,
        int? SchedFreqInterval = 1,
        int? SchedFreqSubDayType = 1,
        int? SchedFreqSubDayInterval = 1,
        int? SchedFreqRelativeInterval = 1,
        int? SchedFreqRecurrenceFactor = 1,
        int? SchedIsEnabled = 0)
        {
            BGTaskNameType _TaskName = TaskName;
            BGTaskParmsHugeType _TaskParms1 = TaskParms1;
            BGTaskParmsHugeType _TaskParms2 = TaskParms2;
            InfobarType _Infobar = Infobar;
            TokenType _TaskID = TaskID;
            GenericMedCodeType _TaskStatusCode = TaskStatusCode;
            StringType _StringTable = StringTable;
            UsernameType _RequestingUser = RequestingUser;
            FlagNyType _PrintPreview = PrintPreview;
            RowPointerType _TaskHistoryRowPointer = TaskHistoryRowPointer;
            GenericIntType _PreviewInterval = PreviewInterval;
            DateTimeType _SchedStartDateTime = SchedStartDateTime;
            DateTimeType _SchedEndDateTime = SchedEndDateTime;
            SchedFreqTypeType _SchedFreqType = SchedFreqType;
            SchedFreqIntervalType _SchedFreqInterval = SchedFreqInterval;
            SchedFreqSubDayTypeType _SchedFreqSubDayType = SchedFreqSubDayType;
            SchedFreqSubDayIntervalType _SchedFreqSubDayInterval = SchedFreqSubDayInterval;
            SchedFreqRelativeIntervalType _SchedFreqRelativeInterval = SchedFreqRelativeInterval;
            SchedFreqRecurrenceFactorType _SchedFreqRecurrenceFactor = SchedFreqRecurrenceFactor;
            ListYesNoType _SchedIsEnabled = SchedIsEnabled;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BGTaskSubmitSp";

                appDB.AddCommandParameter(cmd, "TaskName", _TaskName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaskParms1", _TaskParms1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaskParms2", _TaskParms2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaskID", _TaskID, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaskStatusCode", _TaskStatusCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StringTable", _StringTable, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RequestingUser", _RequestingUser, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintPreview", _PrintPreview, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaskHistoryRowPointer", _TaskHistoryRowPointer, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PreviewInterval", _PreviewInterval, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SchedStartDateTime", _SchedStartDateTime, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchedEndDateTime", _SchedEndDateTime, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchedFreqType", _SchedFreqType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchedFreqInterval", _SchedFreqInterval, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchedFreqSubDayType", _SchedFreqSubDayType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchedFreqSubDayInterval", _SchedFreqSubDayInterval, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchedFreqRelativeInterval", _SchedFreqRelativeInterval, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchedFreqRecurrenceFactor", _SchedFreqRecurrenceFactor, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchedIsEnabled", _SchedIsEnabled, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;
                TaskID = _TaskID;
                TaskHistoryRowPointer = _TaskHistoryRowPointer;
                PreviewInterval = _PreviewInterval;

                return (Severity, Infobar, TaskID, TaskHistoryRowPointer, PreviewInterval);
            }
        }
    }
}

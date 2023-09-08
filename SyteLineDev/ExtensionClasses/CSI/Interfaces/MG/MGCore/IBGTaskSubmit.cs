//PROJECT NAME: MG.MGCore
//CLASS NAME: IBGTaskSubmit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IBGTaskSubmit
    {
        (int? ReturnCode, string Infobar,
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
        int? SchedIsEnabled = 0);
    }
}


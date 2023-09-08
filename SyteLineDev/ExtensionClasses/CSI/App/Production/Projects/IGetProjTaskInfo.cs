//PROJECT NAME: Production
//CLASS NAME: IGetProjTaskInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
    public interface IGetProjTaskInfo
    {
            (int? ReturnCode,
            DateTime? StartDate,
        DateTime? EndDate) GetProjTaskInfoSp(
            string ProjNum,
            int? TaskNum,
            DateTime? StartDate,
            DateTime? EndDate);
    }
}


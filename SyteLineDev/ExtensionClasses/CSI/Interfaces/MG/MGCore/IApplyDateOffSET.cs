//PROJECT NAME: MG.MGCore
//CLASS NAME: IApplyDateOffset.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IApplyDateOffset
    {
        (int? ReturnCode, DateTime? Date) ApplyDateOffsetSp(DateTime? Date,
        int? Offset = null,
        int? IsEndDate = null);
    }
}


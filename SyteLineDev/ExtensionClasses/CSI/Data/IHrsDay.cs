using System;

namespace CSI.Data
{
    public interface IHrsDay
    {
        (int? ReturnCode, decimal? HrsPerDay, string Infobar) HrsDaySp(string PShiftID, DateTime? PDate, decimal? HrsPerDay, string Infobar);
    }
}
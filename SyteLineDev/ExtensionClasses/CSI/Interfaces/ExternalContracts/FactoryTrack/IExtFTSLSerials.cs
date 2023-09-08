using System;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLSerials
    {
        int BflushSerialSaveSp(decimal? TransNum, string Whse, string Lot, byte? Selected, string Job, short? Suffix, int? OperNum, short? Sequence, string EmpNum, string JobMatlItem, string Loc, decimal? QtyNeeded, decimal? QtyRequired, string JobRouteWc, string TransClass,  int? TransSeq, string SerNum, ref string Infobar);
        int DeleteTmpSerSp(Guid? TmpSerId);
        int GetCurDate(ref DateTime? CurrentDate);
        int SerialSaveSp(string SerNum,  Guid? TmpSerId,  string RefStr, ref string Infobar,  DateTime? ManufacturedDate,  DateTime? ExpirationDate, [DefaultParameterValue(null)] string TrxRestrictCode);
    }
}
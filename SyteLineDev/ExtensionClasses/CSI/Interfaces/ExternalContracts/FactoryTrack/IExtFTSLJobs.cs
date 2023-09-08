using System;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLJobs
    {
        int ExpandValidateRJobSp(string Job, short? Suffix, byte? PostMatlIssues, ref string Item, ref string Infobar);
        int JobReceiptGetQtySp(string Job, short? Suffix, string Item, int? OperNum, ref decimal? QtyMoved, ref decimal? QtyComplete, ref string ItemSerialPrefix, ref string Infobar);
        int JobReceiptPostSetVarsSp(string SET, string Job, short? Suffix, string Item, int? OperNum, decimal? Qty, string Loc, string Lot, DateTime? TransDate, byte? Override, ref int? CanOverride, ref string Infobar,  string DocumentNum,  string ImportDocId,  string EmpNum,  string ContainerNum);
        int JobReceiptValidateJobSp(string Job, short? Suffix, ref int? JobrouteOperNum, ref decimal? QtyMoved, ref decimal? QtyComplete, ref int? ItemLotTracked, ref int? ItemSerialTracked, ref string Infobar,  ref string Prompt,  ref string PromptButtons);
    }
}
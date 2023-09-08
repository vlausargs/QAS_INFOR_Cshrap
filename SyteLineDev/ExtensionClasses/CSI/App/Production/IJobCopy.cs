//PROJECT NAME: Production
//CLASS NAME: IJobCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobCopy
	{
		(int? ReturnCode, string ToJob,
		int? ToSuffix,
		string Infobar) JobCopySp(string FromType,
		string FromJob,
		int? FromSuffix,
		int? FromOperNumStart,
		int? FromOperNumEnd,
		string FromOpt,
		string FromRevision,
		string ToType,
		string ToItem,
		string ToJob,
		int? ToSuffix,
		DateTime? EffectDate,
		string ToOpt,
		int? InsertOperNum,
		int? SetQtyAllocJob = 1,
		int? OverwriteExistingJobroute = 1,
		Guid? SessionID = null,
		string Infobar = null,
		int? FromMRP = 0,
		string PLN_Ref_Type = null,
		string PLN_Ref_Num = null,
		int? PLN_ref_suf = null,
		int? CopyUetValues = 0);
	}
}


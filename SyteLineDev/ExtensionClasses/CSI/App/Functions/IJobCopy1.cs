//PROJECT NAME: Data
//CLASS NAME: IJobCopy1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobCopy1
	{
		(int? ReturnCode,
			string ToJob,
			int? ToSuffix,
			string Infobar) JobCopy1Sp(
			string FromType,
			string FromJob,
			int? FromSuffix,
			int? FromOperNumStart,
			int? FromOperNumEnd,
			string FromOpt,
			string ToType,
			string ToItem,
			string ToJob,
			int? ToSuffix,
			string ToStat = null,
			DateTime? EffectDate = null,
			string ToOpt = null,
			int? InsertOperNum = null,
			int? SetQtyAllocJob = 1,
			int? OverwriteExistingJobroute = 1,
			int? ToJobCoProductMix = null,
			int? FromJobCoProductMix = null,
			decimal? FromJobQtyReleased = null,
			Guid? PSessionID = null,
			string Infobar = null,
			int? FromMRP = 0,
			string PLN_Ref_Type = null,
			string PLN_Ref_Num = null,
			int? PLN_ref_suf = null,
			int? CopyUetValues = 0);
	}
}


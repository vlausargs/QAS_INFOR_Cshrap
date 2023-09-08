//PROJECT NAME: Data
//CLASS NAME: IJobCopyIndented.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobCopyIndented
	{
		(int? ReturnCode,
			string NewJob,
			int? NewSuffix,
			string Infobar) JobCopyIndentedSp(
			string FromType,
			int? ExtScrap,
			string ToType,
			string FromJob,
			int? FromSuffix,
			DateTime? EffectDate,
			string NewJob,
			int? NewSuffix,
			int? MinOper,
			int? MaxOper,
			Guid? PSessionID = null,
			string Site = null,
			int? FromMRP = 0,
			string PLN_Ref_Type = null,
			string PLN_Ref_Num = null,
			int? PLN_Ref_Suf = null,
			decimal? HrsPerDay = 8M,
			int? CalcSubJobDates = 0,
			string Infobar = null,
			int? CopyUetValues = 0);
	}
}


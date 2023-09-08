//PROJECT NAME: Data
//CLASS NAME: IJobmatlCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobmatlCopy
	{
		(int? ReturnCode,
			int? ToSequence,
			string Infobar) JobmatlCopySp(
			string FromType,
			string FromJob,
			int? FromSuffix,
			int? FromOperStart,
			int? FromOperEnd,
			decimal? FromQtyReleased,
			DateTime? EffectDate,
			string ToType,
			string ToItem,
			string ToJob,
			int? ToSuffix,
			int? ToOperNum,
			int? ToSequence,
			decimal? MatlQty,
			string Units,
			decimal? ScrapFact,
			int? SetQtyAllocJob = 1,
			Guid? PSessionID = null,
			string Infobar = null,
			string Site = null,
			int? PostponeJobmatlInsert = 0,
			int? FromMRP = 0,
			string PLN_Ref_Type = null,
			string PLN_Ref_Num = null,
			int? PLN_ref_suf = null,
			string FeatStr = null,
			int? CopyUetValues = 0,
			string UseJobmatlFeature = null,
			string UseJobmatlOptCode = null,
			string CoNum = null,
			int? CoLine = null);
	}
}


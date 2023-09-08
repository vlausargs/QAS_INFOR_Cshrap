//PROJECT NAME: Data
//CLASS NAME: ICopyCpjb.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICopyCpjb
	{
		(int? ReturnCode,
			string ToJob,
			int? ToSuffix,
			string Infobar) CopyCpjbSp(
			string FromJobCategory,
			string FromJob,
			int? FromSuffix,
			int? StartOper,
			int? EndOper,
			string Revision,
			int? ScrapFactor,
			string ToJobCategory,
			string ToJob,
			int? ToSuffix,
			DateTime? EffectDate,
			int? IsCalledFromFirmJob = 0,
			Guid? SessionID = null,
			string Infobar = null,
			int? FromMRP = 0,
			string PLN_Ref_Type = null,
			string PLN_Ref_Num = null,
			int? PLN_ref_suf = null,
			int? CopyUetValues = 0);
	}
}


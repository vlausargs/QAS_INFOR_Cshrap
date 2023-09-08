//PROJECT NAME: Production
//CLASS NAME: ICopyBomDoProcess.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICopyBomDoProcess
	{
		(int? ReturnCode, string ToJob,
		int? ToSuffix,
		string Infobar) CopyBomDoProcessSp(string FromJobCategory,
		string FromJob,
		int? FromSuffix,
		string FromItem,
		int? StartOper,
		int? EndOper,
		string LMBVar,
		string Revision,
		int? ScrapFactor,
		int? CopyBom,
		string ToJobCategory,
		string ToItem,
		string ToJob,
		int? ToSuffix,
		DateTime? EffectDate,
		string OptionType,
		int? AfterOper,
		int? CopyToPSReleaseBOM,
		string Infobar,
		int? CopyUetValues = 0);
	}
}


//PROJECT NAME: Production
//CLASS NAME: IGeneratePs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IGeneratePs
	{
		(int? ReturnCode, string PsNum,
		string Infobar,
		int? PsReleasecount) GeneratePsSp(string Item,
		decimal? GenQty,
		decimal? RatePerDay,
		string PsGenType,
		DateTime? MDate,
		int? MdayNum,
		int? PsGenFreq,
		string PsGenStat,
		string PsNum,
		string UpdateJobRel,
		string PsPrefix = null,
		Guid? SessionID = null,
		string Infobar = null,
		int? FromMRP = 0,
		string PLN_Ref_Type = null,
		string PLN_Ref_Num = null,
		int? PLN_ref_suf = null,
		int? CopyToPSItemBOM = null,
		int? CopyToReleaseBOM = null,
		int? PsReleasecount = null);
	}
}


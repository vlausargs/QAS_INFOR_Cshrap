//PROJECT NAME: Material
//CLASS NAME: IMtCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMtCode
	{
		(int? ReturnCode,
			string Ref,
			string RefDesc,
			string Job,
			string Loc,
			string LocCode,
			string Reason,
			string ReasonDesc,
			string Type,
			string From,
			string To,
			decimal? TotPost,
			string Infobar) MtCodeSp(
			string Site = null,
			decimal? TransNum = null,
			string Ref = null,
			string RefDesc = null,
			string Job = null,
			string Loc = null,
			string LocCode = null,
			string Reason = null,
			string ReasonDesc = null,
			string Type = null,
			string From = null,
			string To = null,
			decimal? TotPost = null,
			string Infobar = null,
			int? PostJour = null);
	}
}


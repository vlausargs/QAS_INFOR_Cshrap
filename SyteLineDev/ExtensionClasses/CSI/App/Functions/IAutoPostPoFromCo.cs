//PROJECT NAME: Data
//CLASS NAME: IAutoPostPoFromCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAutoPostPoFromCo
	{
		(int? ReturnCode,
			string Infobar) AutoPostPoFromCoSp(
			string ToSite,
			string FromSite,
			string DemandingPO,
			string CoNum,
			int? CoLine,
			string Infobar = null,
			decimal? MatltranTransNum = null);
	}
}


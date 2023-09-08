//PROJECT NAME: Data
//CLASS NAME: IRmatSsd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRmatSsd
	{
		(int? ReturnCode,
			string Infobar) RmatSsdSp(
			string ParamRmaNum,
			int? ParamRmaLine,
			DateTime? ParamTransDate,
			decimal? ParamQty,
			string ParamReasonCode,
			string Infobar);
	}
}


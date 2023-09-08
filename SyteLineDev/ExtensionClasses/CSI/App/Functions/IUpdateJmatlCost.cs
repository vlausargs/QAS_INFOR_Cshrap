//PROJECT NAME: Data
//CLASS NAME: IUpdateJmatlCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdateJmatlCost
	{
		(int? ReturnCode,
			string Infobar) UpdateJmatlCostSp(
			string PReqNum,
			int? PReqLine,
			string PVendNum,
			decimal? PPlanCostConv,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			string PItem,
			string PUM,
			string Infobar);
	}
}


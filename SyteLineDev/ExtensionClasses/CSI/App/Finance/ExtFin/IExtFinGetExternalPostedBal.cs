//PROJECT NAME: Finance
//CLASS NAME: IExtFinGetExternalPostedBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinGetExternalPostedBal
	{
		(int? ReturnCode,
			decimal? PostedBalance,
			string Infobar) ExtFinGetExternalPostedBalSp(
			string Customer,
			decimal? PostedBalance,
			string Infobar);
	}
}


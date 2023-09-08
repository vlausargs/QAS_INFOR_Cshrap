//PROJECT NAME: Logistics
//CLASS NAME: IRebalCu.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRebalCu
	{
		(int? ReturnCode, int? CustomersDone,
		string Infobar) RebalCuSp(string StartCustNum,
		string EndCustNum,
		string SiteGroup,
		int? CustomersDone,
		string Infobar,
		int? SetPostedBalancetoZero);
	}
}


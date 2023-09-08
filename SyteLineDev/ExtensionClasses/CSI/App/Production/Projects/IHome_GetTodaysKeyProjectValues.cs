//PROJECT NAME: Production
//CLASS NAME: IHome_GetTodaysKeyProjectValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IHome_GetTodaysKeyProjectValues
	{
		(int? ReturnCode,
		decimal? InvoiceAmountTot,
		decimal? RevenueAmountTot) Home_GetTodaysKeyProjectValuesSp(
			decimal? InvoiceAmountTot,
			decimal? RevenueAmountTot);
	}
}


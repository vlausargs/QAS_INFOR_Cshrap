//PROJECT NAME: Finance
//CLASS NAME: IExtFinGetIGFCustomerPostedBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinGetIGFCustomerPostedBal
	{
		(int? ReturnCode,
			string Infobar) ExtFinGetIGFCustomerPostedBalSp(
			string StartingCustNum = null,
			string EndingCustNum = null,
			string Infobar = null);
	}
}


//PROJECT NAME: Logistics
//CLASS NAME: IPreqitemValidateVendNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPreqitemValidateVendNum
	{
		(int? ReturnCode, string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		decimal? PPlanCostConv,
		string PVendCurrCode,
		string Infobar) PreqitemValidateVendNumSp(string PVendNum,
		string POldVendNum,
		string PItem,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		decimal? PPlanCostConv,
		string PVendCurrCode,
		string Infobar);
	}
}


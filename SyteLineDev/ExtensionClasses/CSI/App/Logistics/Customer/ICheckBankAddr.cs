//PROJECT NAME: Logistics
//CLASS NAME: ICheckBankAddr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICheckBankAddr
	{
		(int? ReturnCode, string Infobar) CheckBankAddrSp(string bankcode = null,
		string PayType = null,
		string CustBank = null,
		int? PrintDraft = null,
		string Infobar = null,
		string PSite = null);
	}
}


//PROJECT NAME: Logistics
//CLASS NAME: IGetCoNonInvAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetCoNonInvAcct
	{
		(int? ReturnCode, string NonInvAcct,
		string NonInvAcctUnit1,
		string NonInvAcctUnit2,
		string NonInvAcctUnit3,
		string NonInvAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		int? PostJour,
		string Infobar,
		int? IsControl) GetCoNonInvAcctSp(string CoNum,
		string CustNum,
		string Item,
		string Whse,
		string NonInvAcct,
		string NonInvAcctUnit1,
		string NonInvAcctUnit2,
		string NonInvAcctUnit3,
		string NonInvAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		int? PostJour,
		string Infobar,
		string Site = null,
		int? IsControl = null);
	}
}


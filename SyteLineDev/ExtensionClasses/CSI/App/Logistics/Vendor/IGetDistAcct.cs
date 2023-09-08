//PROJECT NAME: Logistics
//CLASS NAME: IGetDistAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetDistAcct
	{
		(int? ReturnCode, string DistAcct,
		string DistAcctUnit1,
		string DistAcctUnit2,
		string DistAcctUnit3,
		string DistAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string Infobar,
		int? AcctIsControl) GetDistAcctSp(string Item,
		string Whse,
		string DistAcct,
		string DistAcctUnit1,
		string DistAcctUnit2,
		string DistAcctUnit3,
		string DistAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string Infobar,
		string Site = null,
		int? AcctIsControl = null);
	}
}


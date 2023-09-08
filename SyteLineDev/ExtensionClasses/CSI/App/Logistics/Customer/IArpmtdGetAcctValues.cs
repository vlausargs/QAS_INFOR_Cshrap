//PROJECT NAME: Logistics
//CLASS NAME: IArpmtdGetAcctValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArpmtdGetAcctValues
	{
		(int? ReturnCode, string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string Infobar,
		int? PIsControl) ArpmtdGetAcctValuesSp(decimal? PAmt,
		string PType,
		string PArpmtdType,
		string PCustCurrCode,
		int? PReapp,
		string POpenType,
		string PArpmtdSite,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string Infobar,
		int? PIsControl);
	}
}


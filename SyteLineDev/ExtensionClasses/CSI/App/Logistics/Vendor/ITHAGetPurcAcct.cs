//PROJECT NAME: Logistics
//CLASS NAME: ITHAGetPurcAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ITHAGetPurcAcct
	{
		(int? ReturnCode, string Acct,
		string Unit1,
		string Unit2,
		string Unit3,
		string Unit4,
		string Desc,
		string Infobar) THAGetPurcAcctSp(string Acct,
		string Unit1,
		string Unit2,
		string Unit3,
		string Unit4,
		string Desc,
		string Infobar);
	}
}


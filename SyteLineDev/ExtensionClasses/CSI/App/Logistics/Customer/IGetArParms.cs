//PROJECT NAME: Logistics
//CLASS NAME: IGetArParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetArParms
	{
		(int? ReturnCode, string Acct,
		string UnitCode1,
		string UnitCode2,
		string UnitCode3,
		string UnitCode4,
		string Infobar,
		string Description) GetArParmsSp(string AcctType,
		string Acct,
		string UnitCode1,
		string UnitCode2,
		string UnitCode3,
		string UnitCode4,
		string Infobar,
		string Description = null);
	}
}


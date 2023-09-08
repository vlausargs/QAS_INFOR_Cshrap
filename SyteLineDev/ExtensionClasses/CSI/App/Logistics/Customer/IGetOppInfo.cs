//PROJECT NAME: Logistics
//CLASS NAME: IGetOppInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetOppInfo
	{
		(int? ReturnCode, string Slsperson,
		string TerritoryCode,
		string TerritoryDesc,
		string CurrencyID,
		string Infobar) GetOppInfoSp(string CustNum,
		string ProspectID,
		string Slsperson,
		string TerritoryCode,
		string TerritoryDesc,
		string CurrencyID,
		string Infobar);
	}
}


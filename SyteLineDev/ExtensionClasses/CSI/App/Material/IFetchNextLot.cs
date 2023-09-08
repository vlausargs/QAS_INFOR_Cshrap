//PROJECT NAME: Material
//CLASS NAME: IFetchNextLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IFetchNextLot
	{
		(int? ReturnCode, string Infobar,
		string Key) FetchNextLotSp(string Item,
		string Prefix,
		string Infobar,
		string Key,
		string Site = null);
	}
}


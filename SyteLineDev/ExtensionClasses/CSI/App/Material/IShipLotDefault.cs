//PROJECT NAME: Material
//CLASS NAME: IShipLotDefault.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IShipLotDefault
	{
		(int? ReturnCode, string Lot,
		string Infobar,
		string ImportDocId) ShipLotDefaultSp(string Site = null,
		string Whse = null,
		string Item = null,
		string Loc = null,
		string Lot = null,
		string Infobar = null,
		string ImportDocId = null);
	}
}


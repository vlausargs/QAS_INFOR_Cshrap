//PROJECT NAME: Material
//CLASS NAME: IShipLocDefault.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IShipLocDefault
	{
		(int? ReturnCode, string Loc,
		string Lot,
		string Infobar,
		string ImportDocId,
		string TrxRestrictCode) ShipLocDefaultSp(string Site = null,
		string Whse = null,
		string Item = null,
		string Loc = null,
		string Lot = null,
		string Infobar = null,
		string ImportDocId = null,
		string TrxRestrictCode = null);
	}
}


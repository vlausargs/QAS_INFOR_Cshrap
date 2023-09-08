//PROJECT NAME: Material
//CLASS NAME: ITrnShipLotReference.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITrnShipLotReference
	{
		(ICollectionLoadResponse Data, int? ReturnCode) TrnShipLotReferenceSp(string Item,
		string TOSite,
		string RefNum,
		int? RefLineSuf,
		string Whse,
		string Loc);
	}
}


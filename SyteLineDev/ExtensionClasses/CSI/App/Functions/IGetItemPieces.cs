//PROJECT NAME: Data
//CLASS NAME: IGetItemPieces.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetItemPieces
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GetItemPiecesSp(
			string Item,
			string Whse,
			string Loc,
			string Lot);
	}
}


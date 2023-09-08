//PROJECT NAME: Material
//CLASS NAME: IUpateItemPiecesForPurchaseOrderReveicing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IUpateItemPiecesForPurchaseOrderReveicing
	{
		(int? ReturnCode, string Infobar) UpateItemPiecesForPurchaseOrderReveicingSp(string RefNum,
		int? RefLineSuffix,
		int? RefRelease,
		Guid? ItempieceRowPointer,
		int? Change,
		string NewWhse,
		string NewLoc,
		string Infobar);
	}
}


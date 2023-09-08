//PROJECT NAME: Material
//CLASS NAME: IUpdateOverrideForItemPiecesAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IUpdateOverrideForItemPiecesAll
	{
		(int? ReturnCode, string Infobar) UpdateOverrideForItemPiecesAllSp(Guid? ItempieceRowPointer,
		int? Change,
		string NewWhse,
		string NewLoc,
		string SiteRef = null,
		string Infobar = null);
	}
}


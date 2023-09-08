//PROJECT NAME: Material
//CLASS NAME: IUpdateOverrideForItemPieces.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IUpdateOverrideForItemPieces
	{
		(int? ReturnCode, string Infobar) UpdateOverrideForItemPiecesSp(Guid? ItempieceRowPointer,
		int? Change,
		string NewWhse,
		string NewLoc,
		string Infobar,
		int? ExitImmediately = 0,
		int? CurrentPieceCount = 0);
	}
}


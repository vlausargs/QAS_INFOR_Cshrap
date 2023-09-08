//PROJECT NAME: Production
//CLASS NAME: IUpdateOverrideForJobTranPieces.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IUpdateOverrideForJobTranPieces
	{
		(int? ReturnCode, string Infobar) UpdateOverrideForJobTranPiecesSp(Guid? JobTranPieceRowPointer,
		int? CompletedPieceCount,
		string Infobar);
	}
}


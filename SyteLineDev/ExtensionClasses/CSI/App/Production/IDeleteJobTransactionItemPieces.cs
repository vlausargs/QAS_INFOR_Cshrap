//PROJECT NAME: Production
//CLASS NAME: IDeleteJobTransactionItemPieces.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IDeleteJobTransactionItemPieces
	{
		(int? ReturnCode, string Infobar) DeleteJobTransactionItemPiecesSp(decimal? PTransNum,
		string PItem = null,
		string Infobar = null);
	}
}


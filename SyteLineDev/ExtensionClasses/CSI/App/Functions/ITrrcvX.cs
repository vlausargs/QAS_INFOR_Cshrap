//PROJECT NAME: Data
//CLASS NAME: ITrrcvX.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITrrcvX
	{
		(int? ReturnCode,
			string Infobar) TrrcvXSp(
			string PTrnNum,
			int? PTrnLine,
			decimal? PQty,
			string PToLoc,
			string PToLot,
			string Infobar,
			string PImportDocId);
	}
}


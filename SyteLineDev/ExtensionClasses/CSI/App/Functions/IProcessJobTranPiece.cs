//PROJECT NAME: Data
//CLASS NAME: IProcessJobTranPiece.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IProcessJobTranPiece
	{
		(int? ReturnCode,
			string Infobar) ProcessJobTranPieceSp(
			decimal? PTransNum,
			string Infobar);
	}
}


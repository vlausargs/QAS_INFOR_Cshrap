//PROJECT NAME: Data
//CLASS NAME: ITritemXJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITritemXJob
	{
		(int? ReturnCode,
			string CurJob,
			int? CurSuffix,
			string Infobar) TritemXJobSp(
			string TrnitemTrnNum,
			int? TrnitemTrnLine,
			string TrnitemFrmRefType,
			string TrnitemFrmRefNum,
			int? TrnitemFrmRefLineSuf,
			int? TrnitemFrmRefRelease,
			string TrnitemItem,
			string TrnitemStat,
			decimal? TrnitemQtyReq,
			DateTime? TrnitemSchShipDate,
			string TransferStat,
			string TransferFromWhse,
			string CurJob,
			int? CurSuffix,
			string Infobar,
			string ExportType);
	}
}


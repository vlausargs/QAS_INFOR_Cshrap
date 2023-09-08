//PROJECT NAME: Data
//CLASS NAME: TritemXJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TritemXJob : ITritemXJob
	{
		readonly IApplicationDB appDB;
		
		public TritemXJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string ExportType)
		{
			TrnNumType _TrnitemTrnNum = TrnitemTrnNum;
			TrnLineType _TrnitemTrnLine = TrnitemTrnLine;
			RefTypeIJPRType _TrnitemFrmRefType = TrnitemFrmRefType;
			JobPoReqNumType _TrnitemFrmRefNum = TrnitemFrmRefNum;
			SuffixPoReqLineType _TrnitemFrmRefLineSuf = TrnitemFrmRefLineSuf;
			PoReleaseType _TrnitemFrmRefRelease = TrnitemFrmRefRelease;
			ItemType _TrnitemItem = TrnitemItem;
			TransferStatusType _TrnitemStat = TrnitemStat;
			QtyUnitType _TrnitemQtyReq = TrnitemQtyReq;
			DateType _TrnitemSchShipDate = TrnitemSchShipDate;
			TransferStatusType _TransferStat = TransferStat;
			WhseType _TransferFromWhse = TransferFromWhse;
			JobType _CurJob = CurJob;
			SuffixType _CurSuffix = CurSuffix;
			InfobarType _Infobar = Infobar;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TritemXJobSp";
				
				appDB.AddCommandParameter(cmd, "TrnitemTrnNum", _TrnitemTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemTrnLine", _TrnitemTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemFrmRefType", _TrnitemFrmRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemFrmRefNum", _TrnitemFrmRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemFrmRefLineSuf", _TrnitemFrmRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemFrmRefRelease", _TrnitemFrmRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemItem", _TrnitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemStat", _TrnitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemQtyReq", _TrnitemQtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemSchShipDate", _TrnitemSchShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferStat", _TransferStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFromWhse", _TransferFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurJob", _CurJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurSuffix", _CurSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurJob = _CurJob;
				CurSuffix = _CurSuffix;
				Infobar = _Infobar;
				
				return (Severity, CurJob, CurSuffix, Infobar);
			}
		}
	}
}

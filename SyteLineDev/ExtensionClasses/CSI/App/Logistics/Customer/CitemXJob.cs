//PROJECT NAME: Logistics
//CLASS NAME: CitemXJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CitemXJob : ICitemXJob
	{
		readonly IApplicationDB appDB;
		
		public CitemXJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CurJob,
			int? CurSuffix,
			string Infobar) CitemXJobSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Item,
			decimal? QtyOrdered,
			DateTime? DueDate,
			string Whse,
			string CurJob,
			int? CurSuffix,
			string Infobar,
			string ExportType)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			RefTypeIJPRType _RefType = RefType;
			JobPoReqNumType _RefNum = RefNum;
			SuffixPoReqLineType _RefLineSuf = RefLineSuf;
			PoReleaseType _RefRelease = RefRelease;
			ItemType _Item = Item;
			QtyUnitType _QtyOrdered = QtyOrdered;
			DateType _DueDate = DueDate;
			WhseType _Whse = Whse;
			JobType _CurJob = CurJob;
			SuffixType _CurSuffix = CurSuffix;
			InfobarType _Infobar = Infobar;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CitemXJobSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
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

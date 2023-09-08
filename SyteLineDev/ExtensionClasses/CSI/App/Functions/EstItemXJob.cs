//PROJECT NAME: Data
//CLASS NAME: EstItemXJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EstItemXJob : IEstItemXJob
	{
		readonly IApplicationDB appDB;
		
		public EstItemXJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CurEstJob,
			int? CurEstSuffix,
			string Infobar) EstItemXJobSp(
			string EstNum,
			int? EstLine,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Item,
			decimal? QtyOrdered,
			DateTime? DueDate,
			string Whse,
			string CurEstJob,
			int? CurEstSuffix,
			string Infobar)
		{
			CoNumType _EstNum = EstNum;
			CoLineType _EstLine = EstLine;
			RefTypeIJPRType _RefType = RefType;
			JobPoReqNumType _RefNum = RefNum;
			SuffixPoReqLineType _RefLineSuf = RefLineSuf;
			PoReleaseType _RefRelease = RefRelease;
			ItemType _Item = Item;
			QtyUnitType _QtyOrdered = QtyOrdered;
			DateType _DueDate = DueDate;
			WhseType _Whse = Whse;
			JobType _CurEstJob = CurEstJob;
			SuffixType _CurEstSuffix = CurEstSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstItemXJobSp";
				
				appDB.AddCommandParameter(cmd, "EstNum", _EstNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstLine", _EstLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurEstJob", _CurEstJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurEstSuffix", _CurEstSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurEstJob = _CurEstJob;
				CurEstSuffix = _CurEstSuffix;
				Infobar = _Infobar;
				
				return (Severity, CurEstJob, CurEstSuffix, Infobar);
			}
		}
	}
}

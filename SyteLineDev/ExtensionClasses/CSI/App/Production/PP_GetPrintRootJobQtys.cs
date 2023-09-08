//PROJECT NAME: Production
//CLASS NAME: PP_GetPrintRootJobQtys.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PP_GetPrintRootJobQtys : IPP_GetPrintRootJobQtys
	{
		readonly IApplicationDB appDB;
		
		
		public PP_GetPrintRootJobQtys(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? JobQtyReleased,
		decimal? PPJobMinSheetCount,
		string Infobar) PP_GetPrintRootJobQtysSp(string Job,
		int? Suffix,
		decimal? JobQtyReleased,
		decimal? PPJobMinSheetCount,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			QtyUnitType _JobQtyReleased = JobQtyReleased;
			PP_SheetCountType _PPJobMinSheetCount = PPJobMinSheetCount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_GetPrintRootJobQtysSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobQtyReleased", _JobQtyReleased, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPJobMinSheetCount", _PPJobMinSheetCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				JobQtyReleased = _JobQtyReleased;
				PPJobMinSheetCount = _PPJobMinSheetCount;
				Infobar = _Infobar;
				
				return (Severity, JobQtyReleased, PPJobMinSheetCount, Infobar);
			}
		}
	}
}

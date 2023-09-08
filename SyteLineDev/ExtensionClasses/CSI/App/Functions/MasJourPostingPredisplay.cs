//PROJECT NAME: Data
//CLASS NAME: MasJourPostingPredisplay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MasJourPostingPredisplay : IMasJourPostingPredisplay
	{
		readonly IApplicationDB appDB;
		
		public MasJourPostingPredisplay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? RStartDate,
			DateTime? REndDate,
			DateTime? FiscalYearStartDate,
			DateTime? FiscalYearEndDate,
			int? FiscalYear,
			string ROutOfRange,
			string RToPost,
			string RToPrint,
			string RPosted,
			string REmpty,
			string Infobar) MasJourPostingPredisplaySP(
			DateTime? RStartDate,
			DateTime? REndDate,
			DateTime? FiscalYearStartDate = null,
			DateTime? FiscalYearEndDate = null,
			int? FiscalYear = null,
			string ROutOfRange = null,
			string RToPost = null,
			string RToPrint = null,
			string RPosted = null,
			string REmpty = null,
			string Infobar = null)
		{
			DateType _RStartDate = RStartDate;
			DateType _REndDate = REndDate;
			DateType _FiscalYearStartDate = FiscalYearStartDate;
			DateType _FiscalYearEndDate = FiscalYearEndDate;
			FiscalYearType _FiscalYear = FiscalYear;
			InfobarType _ROutOfRange = ROutOfRange;
			InfobarType _RToPost = RToPost;
			InfobarType _RToPrint = RToPrint;
			InfobarType _RPosted = RPosted;
			InfobarType _REmpty = REmpty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MasJourPostingPredisplaySP";
				
				appDB.AddCommandParameter(cmd, "RStartDate", _RStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "REndDate", _REndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearStartDate", _FiscalYearStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearEndDate", _FiscalYearEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ROutOfRange", _ROutOfRange, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RToPost", _RToPost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RToPrint", _RToPrint, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RPosted", _RPosted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "REmpty", _REmpty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RStartDate = _RStartDate;
				REndDate = _REndDate;
				FiscalYearStartDate = _FiscalYearStartDate;
				FiscalYearEndDate = _FiscalYearEndDate;
				FiscalYear = _FiscalYear;
				ROutOfRange = _ROutOfRange;
				RToPost = _RToPost;
				RToPrint = _RToPrint;
				RPosted = _RPosted;
				REmpty = _REmpty;
				Infobar = _Infobar;
				
				return (Severity, RStartDate, REndDate, FiscalYearStartDate, FiscalYearEndDate, FiscalYear, ROutOfRange, RToPost, RToPrint, RPosted, REmpty, Infobar);
			}
		}
	}
}

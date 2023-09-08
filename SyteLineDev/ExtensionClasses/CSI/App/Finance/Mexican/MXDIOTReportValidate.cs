//PROJECT NAME: CSIVATTransfer
//CLASS NAME: MXDIOTReportValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public interface IMXDIOTReportValidate
	{
		(int? ReturnCode, string BGTaskName, string Infobar) MXDIOTReportValidateSp(DateTime? ReconDateStarting = null,
		DateTime? ReconDateEnding = null,
		byte? EndPeriod = null,
		short? FiscalYear = null,
		byte? Reprint = (byte)0,
		string BGTaskName = null,
		string Infobar = null);
	}
	
	public class MXDIOTReportValidate : IMXDIOTReportValidate
	{
		readonly IApplicationDB appDB;
		
		public MXDIOTReportValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string BGTaskName, string Infobar) MXDIOTReportValidateSp(DateTime? ReconDateStarting = null,
		DateTime? ReconDateEnding = null,
		byte? EndPeriod = null,
		short? FiscalYear = null,
		byte? Reprint = (byte)0,
		string BGTaskName = null,
		string Infobar = null)
		{
			DateType _ReconDateStarting = ReconDateStarting;
			DateType _ReconDateEnding = ReconDateEnding;
			FinPeriodType _EndPeriod = EndPeriod;
			FiscalYearType _FiscalYear = FiscalYear;
			ByteType _Reprint = Reprint;
			BGTaskNameType _BGTaskName = BGTaskName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MXDIOTReportValidateSp";
				
				appDB.AddCommandParameter(cmd, "ReconDateStarting", _ReconDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReconDateEnding", _ReconDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPeriod", _EndPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reprint", _Reprint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGTaskName", _BGTaskName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BGTaskName = _BGTaskName;
				Infobar = _Infobar;
				
				return (Severity, BGTaskName, Infobar);
			}
		}
	}
}

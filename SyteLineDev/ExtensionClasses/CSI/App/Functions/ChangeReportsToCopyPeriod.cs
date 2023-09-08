//PROJECT NAME: Data
//CLASS NAME: ChangeReportsToCopyPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChangeReportsToCopyPeriod : IChangeReportsToCopyPeriod
	{
		readonly IApplicationDB appDB;
		
		public ChangeReportsToCopyPeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ChangeReportsToCopyPeriodSp(
			int? Parm1Value,
			int? Parm2Value,
			int? Parm3Value,
			DateTime? Parm4Value,
			DateTime? Parm5Value,
			DateTime? Parm6Value,
			DateTime? Parm7Value,
			DateTime? Parm8Value,
			DateTime? Parm9Value,
			DateTime? Parm10Value,
			DateTime? Parm11Value,
			DateTime? Parm12Value,
			DateTime? Parm13Value,
			DateTime? Parm14Value,
			DateTime? Parm15Value,
			DateTime? Parm16Value,
			DateTime? Parm17Value,
			DateTime? Parm18Value,
			DateTime? Parm19Value,
			DateTime? Parm20Value,
			DateTime? Parm21Value,
			DateTime? Parm22Value,
			DateTime? Parm23Value,
			DateTime? Parm24Value,
			DateTime? Parm25Value,
			DateTime? Parm26Value,
			DateTime? Parm27Value,
			DateTime? Parm28Value,
			DateTime? Parm29Value,
			string Parm30Value,
			string Parm31Value,
			string Parm32Value,
			string Parm33Value,
			string Parm34Value,
			string Parm35Value,
			string Parm36Value,
			string Parm37Value,
			string Parm38Value,
			string Parm39Value,
			string Parm40Value,
			string Parm41Value,
			string Parm42Value,
			string Infobar)
		{
			FiscalYearType _Parm1Value = Parm1Value;
			FinPeriodType _Parm2Value = Parm2Value;
			ListYesNoType _Parm3Value = Parm3Value;
			DateType _Parm4Value = Parm4Value;
			DateType _Parm5Value = Parm5Value;
			DateType _Parm6Value = Parm6Value;
			DateType _Parm7Value = Parm7Value;
			DateType _Parm8Value = Parm8Value;
			DateType _Parm9Value = Parm9Value;
			DateType _Parm10Value = Parm10Value;
			DateType _Parm11Value = Parm11Value;
			DateType _Parm12Value = Parm12Value;
			DateType _Parm13Value = Parm13Value;
			DateType _Parm14Value = Parm14Value;
			DateType _Parm15Value = Parm15Value;
			DateType _Parm16Value = Parm16Value;
			DateType _Parm17Value = Parm17Value;
			DateType _Parm18Value = Parm18Value;
			DateType _Parm19Value = Parm19Value;
			DateType _Parm20Value = Parm20Value;
			DateType _Parm21Value = Parm21Value;
			DateType _Parm22Value = Parm22Value;
			DateType _Parm23Value = Parm23Value;
			DateType _Parm24Value = Parm24Value;
			DateType _Parm25Value = Parm25Value;
			DateType _Parm26Value = Parm26Value;
			DateType _Parm27Value = Parm27Value;
			DateType _Parm28Value = Parm28Value;
			DateType _Parm29Value = Parm29Value;
			PeriodStatusType _Parm30Value = Parm30Value;
			PeriodStatusType _Parm31Value = Parm31Value;
			PeriodStatusType _Parm32Value = Parm32Value;
			PeriodStatusType _Parm33Value = Parm33Value;
			PeriodStatusType _Parm34Value = Parm34Value;
			PeriodStatusType _Parm35Value = Parm35Value;
			PeriodStatusType _Parm36Value = Parm36Value;
			PeriodStatusType _Parm37Value = Parm37Value;
			PeriodStatusType _Parm38Value = Parm38Value;
			PeriodStatusType _Parm39Value = Parm39Value;
			PeriodStatusType _Parm40Value = Parm40Value;
			PeriodStatusType _Parm41Value = Parm41Value;
			PeriodStatusType _Parm42Value = Parm42Value;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangeReportsToCopyPeriodSp";
				
				appDB.AddCommandParameter(cmd, "Parm1Value", _Parm1Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm2Value", _Parm2Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm3Value", _Parm3Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm4Value", _Parm4Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm5Value", _Parm5Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm6Value", _Parm6Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm7Value", _Parm7Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm8Value", _Parm8Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm9Value", _Parm9Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm10Value", _Parm10Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm11Value", _Parm11Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm12Value", _Parm12Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm13Value", _Parm13Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm14Value", _Parm14Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm15Value", _Parm15Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm16Value", _Parm16Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm17Value", _Parm17Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm18Value", _Parm18Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm19Value", _Parm19Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm20Value", _Parm20Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm21Value", _Parm21Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm22Value", _Parm22Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm23Value", _Parm23Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm24Value", _Parm24Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm25Value", _Parm25Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm26Value", _Parm26Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm27Value", _Parm27Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm28Value", _Parm28Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm29Value", _Parm29Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm30Value", _Parm30Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm31Value", _Parm31Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm32Value", _Parm32Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm33Value", _Parm33Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm34Value", _Parm34Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm35Value", _Parm35Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm36Value", _Parm36Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm37Value", _Parm37Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm38Value", _Parm38Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm39Value", _Parm39Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm40Value", _Parm40Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm41Value", _Parm41Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm42Value", _Parm42Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

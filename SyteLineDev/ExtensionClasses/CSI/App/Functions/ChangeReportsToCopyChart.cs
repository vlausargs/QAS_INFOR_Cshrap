//PROJECT NAME: Data
//CLASS NAME: ChangeReportsToCopyChart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChangeReportsToCopyChart : IChangeReportsToCopyChart
	{
		readonly IApplicationDB appDB;
		
		public ChangeReportsToCopyChart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ChangeReportsToCopyChartSp(
			string Parm1Value,
			string Parm2Value,
			string Parm3Value,
			DateTime? Parm4Value,
			DateTime? Parm5Value,
			string Parm6Value,
			string Parm7Value,
			string Parm8Value,
			string Parm9Value,
			string Parm10Value,
			string Parm11Value,
			int? Parm12Value,
			Guid? Parm13Value,
			string pFromSite,
			string Infobar)
		{
			AcctType _Parm1Value = Parm1Value;
			ChartTypeType _Parm2Value = Parm2Value;
			DescriptionType _Parm3Value = Parm3Value;
			DateType _Parm4Value = Parm4Value;
			DateType _Parm5Value = Parm5Value;
			UnitCodeAccessType _Parm6Value = Parm6Value;
			UnitCodeAccessType _Parm7Value = Parm7Value;
			UnitCodeAccessType _Parm8Value = Parm8Value;
			UnitCodeAccessType _Parm9Value = Parm9Value;
			AcctType _Parm10Value = Parm10Value;
			CurrTransMethodType _Parm11Value = Parm11Value;
			ListBuySellType _Parm12Value = Parm12Value;
			RowPointerType _Parm13Value = Parm13Value;
			SiteType _pFromSite = pFromSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangeReportsToCopyChartSp";
				
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
				appDB.AddCommandParameter(cmd, "pFromSite", _pFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubCalcWorkDuration.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubCalcWorkDuration : ISSSFSConInvSubCalcWorkDuration
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubCalcWorkDuration(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? OMonths,
			int? OWeeks,
			int? ODays,
			decimal? OHours,
			string Infobar) SSSFSConInvSubCalcWorkDurationSp(
			string IUnitOfRate,
			DateTime? IStartDate,
			DateTime? IEndDate,
			int? OMonths,
			int? OWeeks,
			int? ODays,
			decimal? OHours,
			string Infobar)
		{
			FSContUnitOfRateType _IUnitOfRate = IUnitOfRate;
			DateTimeType _IStartDate = IStartDate;
			DateTimeType _IEndDate = IEndDate;
			IntType _OMonths = OMonths;
			IntType _OWeeks = OWeeks;
			IntType _ODays = ODays;
			DecimalType _OHours = OHours;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubCalcWorkDurationSp";
				
				appDB.AddCommandParameter(cmd, "IUnitOfRate", _IUnitOfRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IStartDate", _IStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IEndDate", _IEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OMonths", _OMonths, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OWeeks", _OWeeks, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ODays", _ODays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OHours", _OHours, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OMonths = _OMonths;
				OWeeks = _OWeeks;
				ODays = _ODays;
				OHours = _OHours;
				Infobar = _Infobar;
				
				return (Severity, OMonths, OWeeks, ODays, OHours, Infobar);
			}
		}
	}
}

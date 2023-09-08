//PROJECT NAME: Data
//CLASS NAME: CheckPermissionOnTransDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CheckPermissionOnTransDate : ICheckPermissionOnTransDate
	{
		readonly IApplicationDB appDB;
		
		public CheckPermissionOnTransDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? OutOfPeriod,
			int? CanTransact,
			int? Closed,
			int? FiscalYear,
			int? TransPeriod,
			string Infobar,
			DateTime? ZBegRange,
			DateTime? ZEndRange) CheckPermissionOnTransDateSp(
			DateTime? PTransDate,
			string Site = null,
			int? OutOfPeriod = 0,
			int? CanTransact = 0,
			int? Closed = 0,
			int? FiscalYear = null,
			int? TransPeriod = null,
			string Infobar = null,
			DateTime? ZBegRange = null,
			DateTime? ZEndRange = null)
		{
			CurrentDateType _PTransDate = PTransDate;
			SiteType _Site = Site;
			ListYesNoType _OutOfPeriod = OutOfPeriod;
			ListYesNoType _CanTransact = CanTransact;
			ListYesNoType _Closed = Closed;
			FiscalYearType _FiscalYear = FiscalYear;
			FinPeriodType _TransPeriod = TransPeriod;
			InfobarType _Infobar = Infobar;
			CurrentDateType _ZBegRange = ZBegRange;
			CurrentDateType _ZEndRange = ZEndRange;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckPermissionOnTransDateSp";
				
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutOfPeriod", _OutOfPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanTransact", _CanTransact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Closed", _Closed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransPeriod", _TransPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ZBegRange", _ZBegRange, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ZEndRange", _ZEndRange, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutOfPeriod = _OutOfPeriod;
				CanTransact = _CanTransact;
				Closed = _Closed;
				FiscalYear = _FiscalYear;
				TransPeriod = _TransPeriod;
				Infobar = _Infobar;
				ZBegRange = _ZBegRange;
				ZEndRange = _ZEndRange;
				
				return (Severity, OutOfPeriod, CanTransact, Closed, FiscalYear, TransPeriod, Infobar, ZBegRange, ZEndRange);
			}
		}
	}
}

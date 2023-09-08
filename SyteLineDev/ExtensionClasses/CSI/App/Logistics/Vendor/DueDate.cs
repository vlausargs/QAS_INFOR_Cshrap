//PROJECT NAME: Logistics
//CLASS NAME: DueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class DueDate : IDueDate
	{
		readonly IApplicationDB appDB;
		
		
		public DueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? DueDate,
		DateTime? DiscDate) DueDateSp(DateTime? InvoiceDate,
		int? DueDays,
		int? ProxCode,
		int? ProxDay,
		string pTermsCode,
		int? ProxMonthToForward,
		int? CutoffDay,
		string HolidayOffsetMethod,
		int? ProxDiscMonthToForward,
		int? ProxDiscDay,
		int? DiscDays,
		DateTime? DueDate,
		DateTime? DiscDate)
		{
			GenericDateType _InvoiceDate = InvoiceDate;
			GenericNoType _DueDays = DueDays;
			GenericNoType _ProxCode = ProxCode;
			GenericNoType _ProxDay = ProxDay;
			TermsCodeType _pTermsCode = pTermsCode;
			ProxMonthToForwardType _ProxMonthToForward = ProxMonthToForward;
			CutoffDayType _CutoffDay = CutoffDay;
			HolidayOffsetMethodType _HolidayOffsetMethod = HolidayOffsetMethod;
			ProxDiscMonthToForwardType _ProxDiscMonthToForward = ProxDiscMonthToForward;
			ProxDiscDayType _ProxDiscDay = ProxDiscDay;
			DiscDaysType _DiscDays = DiscDays;
			GenericDateType _DueDate = DueDate;
			GenericDateType _DiscDate = DiscDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DueDateSp";
				
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDays", _DueDays, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProxCode", _ProxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProxDay", _ProxDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTermsCode", _pTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProxMonthToForward", _ProxMonthToForward, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDay", _CutoffDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HolidayOffsetMethod", _HolidayOffsetMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProxDiscMonthToForward", _ProxDiscMonthToForward, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProxDiscDay", _ProxDiscDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscDays", _DiscDays, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DiscDate", _DiscDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DueDate = _DueDate;
				DiscDate = _DiscDate;
				
				return (Severity, DueDate, DiscDate);
			}
		}
	}
}

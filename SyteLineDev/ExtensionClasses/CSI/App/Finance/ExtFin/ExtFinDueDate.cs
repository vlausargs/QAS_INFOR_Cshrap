//PROJECT NAME: Finance
//CLASS NAME: ExtFinDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinDueDate : IExtFinDueDate
	{
		readonly IApplicationDB appDB;
		
		public ExtFinDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? DueDate) ExtFinDueDateSp(
			DateTime? InvoiceDate,
			int? DueDays,
			int? ProxCode,
			int? ProxDay,
			string pTermsCode,
			DateTime? DueDate = null)
		{
			GenericDateType _InvoiceDate = InvoiceDate;
			GenericNoType _DueDays = DueDays;
			GenericNoType _ProxCode = ProxCode;
			GenericNoType _ProxDay = ProxDay;
			TermsCodeType _pTermsCode = pTermsCode;
			GenericDateType _DueDate = DueDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinDueDateSp";
				
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDays", _DueDays, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProxCode", _ProxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProxDay", _ProxDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTermsCode", _pTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DueDate = _DueDate;
				
				return (Severity, DueDate);
			}
		}
	}
}

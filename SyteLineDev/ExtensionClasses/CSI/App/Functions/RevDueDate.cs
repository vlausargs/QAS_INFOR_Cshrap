//PROJECT NAME: Data
//CLASS NAME: RevDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RevDueDate : IRevDueDate
	{
		readonly IApplicationDB appDB;
		
		public RevDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? DueDate) RevDueDateSp(
			string CustomerNumber,
			string InvoicNumber,
			int? InvoiceSequence,
			DateTime? InvoiceDate,
			string TermsCode,
			int? DueDays,
			int? ProxCode,
			int? ProxDay,
			DateTime? DueDate)
		{
			CustNumType _CustomerNumber = CustomerNumber;
			InvNumType _InvoicNumber = InvoicNumber;
			ArInvSeqType _InvoiceSequence = InvoiceSequence;
			GenericDateType _InvoiceDate = InvoiceDate;
			TermsCodeType _TermsCode = TermsCode;
			GenericNoType _DueDays = DueDays;
			GenericNoType _ProxCode = ProxCode;
			GenericNoType _ProxDay = ProxDay;
			GenericDateType _DueDate = DueDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RevDueDateSp";
				
				appDB.AddCommandParameter(cmd, "CustomerNumber", _CustomerNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoicNumber", _InvoicNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceSequence", _InvoiceSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDays", _DueDays, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProxCode", _ProxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProxDay", _ProxDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DueDate = _DueDate;
				
				return (Severity, DueDate);
			}
		}
	}
}

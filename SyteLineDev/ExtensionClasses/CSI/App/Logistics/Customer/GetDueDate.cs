//PROJECT NAME: Logistics
//CLASS NAME: GetDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetDueDate : IGetDueDate
	{
		readonly IApplicationDB appDB;
		
		
		public GetDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? DueDate,
		string Infobar) GetDueDateSp(string ArinvType,
		string TermsCode,
		DateTime? InvoiceDate,
		DateTime? DueDate,
		string Infobar)
		{
			ArinvTypeType _ArinvType = ArinvType;
			TermsCodeType _TermsCode = TermsCode;
			DateType _InvoiceDate = InvoiceDate;
			DateType _DueDate = DueDate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDueDateSp";
				
				appDB.AddCommandParameter(cmd, "ArinvType", _ArinvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DueDate = _DueDate;
				Infobar = _Infobar;
				
				return (Severity, DueDate, Infobar);
			}
		}
	}
}

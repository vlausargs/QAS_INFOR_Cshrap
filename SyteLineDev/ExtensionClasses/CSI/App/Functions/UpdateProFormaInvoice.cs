//PROJECT NAME: Data
//CLASS NAME: UpdateProFormaInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdateProFormaInvoice : IUpdateProFormaInvoice
	{
		readonly IApplicationDB appDB;
		
		public UpdateProFormaInvoice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) UpdateProFormaInvoiceSp(
			string PInvoiceNumber = null,
			Guid? PSessionID = null,
			string PInvoiceCreditType = null,
			string PCustNum = null,
			string POrderNumber = null,
			DateTime? PTransactionDate = null,
			string ActionExpression = null,
			string Infobar = null,
			string ApplyToInvoice = null)
		{
			InvNumType _PInvoiceNumber = PInvoiceNumber;
			RowPointerType _PSessionID = PSessionID;
			DefaultCharType _PInvoiceCreditType = PInvoiceCreditType;
			CustNumType _PCustNum = PCustNum;
			CoNumType _POrderNumber = POrderNumber;
			DateTimeType _PTransactionDate = PTransactionDate;
			StringType _ActionExpression = ActionExpression;
			InfobarType _Infobar = Infobar;
			InvNumType _ApplyToInvoice = ApplyToInvoice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateProFormaInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "PInvoiceNumber", _PInvoiceNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvoiceCreditType", _PInvoiceCreditType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderNumber", _POrderNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransactionDate", _PTransactionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ApplyToInvoice", _ApplyToInvoice, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

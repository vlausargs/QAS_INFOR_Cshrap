//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBMXProcessInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBMXProcessInvoice : ILoadESBMXProcessInvoice
	{
		readonly IApplicationDB appDB;
		
		public LoadESBMXProcessInvoice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LoadESBMXProcessInvoiceSp(
			string ActionExpression = null,
			string ProcessInvoice = null,
			string UUID = null,
			string Status = null,
			string ErrMessage = null,
			string FileName = null,
			string Infobar = null)
		{
			StringType _ActionExpression = ActionExpression;
			VendInvNumType _ProcessInvoice = ProcessInvoice;
			StringType _UUID = UUID;
			StringType _Status = Status;
			MessageType _ErrMessage = ErrMessage;
			StringType _FileName = FileName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBMXProcessInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessInvoice", _ProcessInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UUID", _UUID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrMessage", _ErrMessage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FileName", _FileName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

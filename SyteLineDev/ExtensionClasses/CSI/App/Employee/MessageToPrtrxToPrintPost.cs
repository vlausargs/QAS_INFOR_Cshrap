//PROJECT NAME: Employee
//CLASS NAME: MessageToPrtrxToPrintPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class MessageToPrtrxToPrintPost : IMessageToPrtrxToPrintPost
	{
		readonly IApplicationDB appDB;
		
		
		public MessageToPrtrxToPrintPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MessageToPrtrxToPrintPostSp(Guid? pSessionID,
		Guid? pPrtrxRowPointer,
		string pMessage,
		string Infobar)
		{
			RowPointerType _pSessionID = pSessionID;
			RowPointerType _pPrtrxRowPointer = pPrtrxRowPointer;
			InfobarType _pMessage = pMessage;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MessageToPrtrxToPrintPostSp";
				
				appDB.AddCommandParameter(cmd, "pSessionID", _pSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrtrxRowPointer", _pPrtrxRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMessage", _pMessage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

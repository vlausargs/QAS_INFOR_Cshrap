//PROJECT NAME: Logistics
//CLASS NAME: MessageToAppmtToPrintPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class MessageToAppmtToPrintPost : IMessageToAppmtToPrintPost
	{
		readonly IApplicationDB appDB;
		
		
		public MessageToAppmtToPrintPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MessageToAppmtToPrintPostSp(Guid? PSessionID,
		Guid? AppmtRowPointer,
		string Message,
		string Infobar)
		{
			RowPointerType _PSessionID = PSessionID;
			RowPointerType _AppmtRowPointer = AppmtRowPointer;
			InfobarType _Message = Message;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MessageToAppmtToPrintPostSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtRowPointer", _AppmtRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Message", _Message, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

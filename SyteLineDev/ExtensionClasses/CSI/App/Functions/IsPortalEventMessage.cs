//PROJECT NAME: Data
//CLASS NAME: IsPortalEventMessage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsPortalEventMessage : IIsPortalEventMessage
	{
		readonly IApplicationDB appDB;
		
		public IsPortalEventMessage(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsPortalEventMessageFn(
			Guid? EventMessageRowPointer)
		{
			RowPointerType _EventMessageRowPointer = EventMessageRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsPortalEventMessage](@EventMessageRowPointer)";
				
				appDB.AddCommandParameter(cmd, "EventMessageRowPointer", _EventMessageRowPointer, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}

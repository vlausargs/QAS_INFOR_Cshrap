//PROJECT NAME: Data
//CLASS NAME: IsPortalEventState.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsPortalEventState : IIsPortalEventState
	{
		readonly IApplicationDB appDB;
		
		public IsPortalEventState(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsPortalEventStateFn(
			Guid? EventStateRowPointer)
		{
			RowPointerType _EventStateRowPointer = EventStateRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsPortalEventState](@EventStateRowPointer)";
				
				appDB.AddCommandParameter(cmd, "EventStateRowPointer", _EventStateRowPointer, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}

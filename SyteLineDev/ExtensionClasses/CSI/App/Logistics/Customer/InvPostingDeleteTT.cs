//PROJECT NAME: Logistics
//CLASS NAME: InvPostingDeleteTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvPostingDeleteTT : IInvPostingDeleteTT
	{
		readonly IApplicationDB appDB;
		
		
		public InvPostingDeleteTT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InvPostingDeleteTTSp(Guid? PSessionID)
		{
			RowPointer _PSessionID = PSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvPostingDeleteTTSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}

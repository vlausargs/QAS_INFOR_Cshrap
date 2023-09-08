//PROJECT NAME: Logistics
//CLASS NAME: ARFinChgPostDeleteTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARFinChgPostDeleteTT : IARFinChgPostDeleteTT
	{
		readonly IApplicationDB appDB;
		
		
		public ARFinChgPostDeleteTT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ARFinChgPostDeleteTTSp(Guid? PSessionID)
		{
			RowPointer _PSessionID = PSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARFinChgPostDeleteTTSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}

//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTTTClearSessionTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTTTClearSessionTables
	{
		int FTTTClearSessionTablesSp(Guid? SessionID);
	}
	
	public class FTTTClearSessionTables : IFTTTClearSessionTables
	{
		readonly IApplicationDB appDB;
		
		public FTTTClearSessionTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTTTClearSessionTablesSp(Guid? SessionID)
		{
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTTTClearSessionTablesSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}

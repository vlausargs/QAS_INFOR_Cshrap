//PROJECT NAME: Data
//CLASS NAME: FloorStkReplenCel06L3I.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FloorStkReplenCel06L3I : IFloorStkReplenCel06L3I
	{
		readonly IApplicationDB appDB;
		
		public FloorStkReplenCel06L3I(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FloorStkReplenCel06L3ISp(
			string pWhse)
		{
			WhseType _pWhse = pWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FloorStkReplenCel06L3ISp";
				
				appDB.AddCommandParameter(cmd, "pWhse", _pWhse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}

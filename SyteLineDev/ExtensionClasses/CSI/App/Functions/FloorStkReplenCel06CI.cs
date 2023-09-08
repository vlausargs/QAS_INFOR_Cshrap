//PROJECT NAME: Data
//CLASS NAME: FloorStkReplenCel06CI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FloorStkReplenCel06CI : IFloorStkReplenCel06CI
	{
		readonly IApplicationDB appDB;
		
		public FloorStkReplenCel06CI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FloorStkReplenCel06CISp(
			string TPostMat)
		{
			LongListType _TPostMat = TPostMat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FloorStkReplenCel06CISp";
				
				appDB.AddCommandParameter(cmd, "TPostMat", _TPostMat, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}

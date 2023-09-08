//PROJECT NAME: Finance
//CLASS NAME: GlPostDeleteTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GlPostDeleteTT : IGlPostDeleteTT
	{
		readonly IApplicationDB appDB;
		
		
		public GlPostDeleteTT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GlPostDeleteTTSp(Guid? PSessionID)
		{
			RowPointer _PSessionID = PSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlPostDeleteTTSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}

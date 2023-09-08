//PROJECT NAME: CSIMaterial
//CLASS NAME: PlanningDetailDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IPlanningDetailDelete
	{
		int PlanningDetailDeleteSp(Guid? SessionID);
	}
	
	public class PlanningDetailDelete : IPlanningDetailDelete
	{
		readonly IApplicationDB appDB;
		
		public PlanningDetailDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PlanningDetailDeleteSp(Guid? SessionID)
		{
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PlanningDetailDeleteSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}

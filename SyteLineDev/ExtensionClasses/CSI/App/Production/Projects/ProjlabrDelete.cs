//PROJECT NAME: CSIProjects
//CLASS NAME: ProjlabrDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjlabrDelete
	{
		int ProjlabrDeleteSp(Guid? PSessionID);
	}
	
	public class ProjlabrDelete : IProjlabrDelete
	{
		readonly IApplicationDB appDB;
		
		public ProjlabrDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProjlabrDeleteSp(Guid? PSessionID)
		{
			RowPointer _PSessionID = PSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjlabrDeleteSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}

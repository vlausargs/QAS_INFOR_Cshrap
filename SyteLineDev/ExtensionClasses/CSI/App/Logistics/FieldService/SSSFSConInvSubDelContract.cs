//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSConInvSubDelContract.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubDelContract
	{
		int SSSFSConInvSubDelContractSp(Guid? SessionId);
	}
	
	public class SSSFSConInvSubDelContract : ISSSFSConInvSubDelContract
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubDelContract(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSConInvSubDelContractSp(Guid? SessionId)
		{
			RowPointerType _SessionId = SessionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubDelContractSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}

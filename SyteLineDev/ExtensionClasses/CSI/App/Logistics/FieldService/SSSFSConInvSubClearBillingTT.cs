//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSConInvSubClearBillingTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubClearBillingTT
	{
		int SSSFSConInvSubClearBillingTTSp(Guid? SessionId);
	}
	
	public class SSSFSConInvSubClearBillingTT : ISSSFSConInvSubClearBillingTT
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubClearBillingTT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSConInvSubClearBillingTTSp(Guid? SessionId)
		{
			RowPointerType _SessionId = SessionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubClearBillingTTSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}

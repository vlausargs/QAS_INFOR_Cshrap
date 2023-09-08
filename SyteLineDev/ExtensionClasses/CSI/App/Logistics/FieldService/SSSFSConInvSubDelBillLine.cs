//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubDelBillLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubDelBillLine : ISSSFSConInvSubDelBillLine
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubDelBillLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConInvSubDelBillLineSp(
			Guid? SessionId)
		{
			RowPointerType _SessionId = SessionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubDelBillLineSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}

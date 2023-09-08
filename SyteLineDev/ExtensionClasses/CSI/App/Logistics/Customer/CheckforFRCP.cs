//PROJECT NAME: Logistics
//CLASS NAME: CheckforFRCP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CheckforFRCP : ICheckforFRCP
	{
		readonly IApplicationDB appDB;
		
		
		public CheckforFRCP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? FRCP) CheckforFRCPSp(int? FRCP)
		{
			ListYesNoType _FRCP = FRCP;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckforFRCPSp";
				
				appDB.AddCommandParameter(cmd, "FRCP", _FRCP, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FRCP = _FRCP;
				
				return (Severity, FRCP);
			}
		}
	}
}

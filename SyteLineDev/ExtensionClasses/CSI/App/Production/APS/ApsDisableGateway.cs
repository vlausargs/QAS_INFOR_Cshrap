//PROJECT NAME: Production
//CLASS NAME: ApsDisableGateway.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsDisableGateway : IApsDisableGateway
	{
		readonly IApplicationDB appDB;
		
		public ApsDisableGateway(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsDisableGatewaySp(
			string AltNo)
		{
			StringType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsDisableGatewaySp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}

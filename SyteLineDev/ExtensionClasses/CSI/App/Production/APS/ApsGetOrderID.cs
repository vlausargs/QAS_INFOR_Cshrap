//PROJECT NAME: Production
//CLASS NAME: ApsGetOrderID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetOrderID : IApsGetOrderID
	{
		readonly IApplicationDB appDB;
		
		public ApsGetOrderID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsGetOrderIDFn(
			string DemandType,
			string DemandRef)
		{
			RefType _DemandType = DemandType;
			OrderRefStrType _DemandRef = DemandRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGetOrderID](@DemandType, @DemandRef)";
				
				appDB.AddCommandParameter(cmd, "DemandType", _DemandType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandRef", _DemandRef, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}

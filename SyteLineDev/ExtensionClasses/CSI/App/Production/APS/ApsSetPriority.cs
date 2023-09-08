//PROJECT NAME: Production
//CLASS NAME: ApsSetPriority.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSetPriority : IApsSetPriority
	{
		readonly IApplicationDB appDB;
		
		public ApsSetPriority(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSetPrioritySp(
			int? POrderType)
		{
			IntType _POrderType = POrderType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsSetPrioritySp](@POrderType)";
				
				appDB.AddCommandParameter(cmd, "POrderType", _POrderType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}

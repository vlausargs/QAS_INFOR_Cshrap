//PROJECT NAME: Production
//CLASS NAME: ApsGetSeqOrderType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetSeqOrderType : IApsGetSeqOrderType
	{
		readonly IApplicationDB appDB;
		
		public ApsGetSeqOrderType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsGetSeqOrderTypeFn(
			string POrderTypeVal)
		{
			ApsRulevalType _POrderTypeVal = POrderTypeVal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGetSeqOrderType](@POrderTypeVal)";
				
				appDB.AddCommandParameter(cmd, "POrderTypeVal", _POrderTypeVal, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}

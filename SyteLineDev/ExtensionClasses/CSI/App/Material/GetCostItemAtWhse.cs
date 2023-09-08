//PROJECT NAME: Material
//CLASS NAME: GetCostItemAtWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetCostItemAtWhse : IGetCostItemAtWhse
	{
		readonly IApplicationDB appDB;
		
		
		public GetCostItemAtWhse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CostItemAtWhse) GetCostItemAtWhseSP(int? CostItemAtWhse)
		{
			ListYesNoType _CostItemAtWhse = CostItemAtWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCostItemAtWhseSP";
				
				appDB.AddCommandParameter(cmd, "CostItemAtWhse", _CostItemAtWhse, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CostItemAtWhse = _CostItemAtWhse;
				
				return (Severity, CostItemAtWhse);
			}
		}
	}
}

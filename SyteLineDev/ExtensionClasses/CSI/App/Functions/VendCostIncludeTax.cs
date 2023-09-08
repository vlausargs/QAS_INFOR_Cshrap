//PROJECT NAME: Data
//CLASS NAME: VendCostIncludeTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class VendCostIncludeTax : IVendCostIncludeTax
	{
		readonly IApplicationDB appDB;
		
		public VendCostIncludeTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? POIncludeCost) VendCostIncludeTaxSp(
			string VendNum,
			int? POIncludeCost)
		{
			VendNumType _VendNum = VendNum;
			ListYesNoType _POIncludeCost = POIncludeCost;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendCostIncludeTaxSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POIncludeCost", _POIncludeCost, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				POIncludeCost = _POIncludeCost;
				
				return (Severity, POIncludeCost);
			}
		}
	}
}

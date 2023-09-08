//PROJECT NAME: Data
//CLASS NAME: GetProdcode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetProdcode : IGetProdcode
	{
		readonly IApplicationDB appDB;
		
		public GetProdcode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PProdcode,
			string PPricecode,
			string PPricecodeDesc,
			decimal? PUnitCost,
			decimal? PCurUCost) GetProdcodeSp(
			string PItem,
			string PProdcode,
			string PPricecode,
			string PPricecodeDesc,
			decimal? PUnitCost,
			decimal? PCurUCost)
		{
			ItemType _PItem = PItem;
			ProductCodeType _PProdcode = PProdcode;
			PriceCodeType _PPricecode = PPricecode;
			DescriptionType _PPricecodeDesc = PPricecodeDesc;
			CostPrcType _PUnitCost = PUnitCost;
			CostPrcType _PCurUCost = PCurUCost;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetProdcodeSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProdcode", _PProdcode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPricecode", _PPricecode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPricecodeDesc", _PPricecodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitCost", _PUnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCurUCost", _PCurUCost, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PProdcode = _PProdcode;
				PPricecode = _PPricecode;
				PPricecodeDesc = _PPricecodeDesc;
				PUnitCost = _PUnitCost;
				PCurUCost = _PCurUCost;
				
				return (Severity, PProdcode, PPricecode, PPricecodeDesc, PUnitCost, PCurUCost);
			}
		}
	}
}

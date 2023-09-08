//PROJECT NAME: Material
//CLASS NAME: CanUpdateCosts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CanUpdateCosts : ICanUpdateCosts
	{
		readonly IApplicationDB appDB;
		
		
		public CanUpdateCosts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PCanUpdateCosts,
		int? PCanPromptCost1,
		int? PCanPromptCost2,
		int? PDisplayUnitCosts,
		int? CanUpdateCur) CanUpdateCostsSp(string PItem,
		string PCostType,
		string PCostMethod,
		string PPMTCode,
		string PJob = "",
		int? PSuffix = null,
		int? PCanUpdateCosts = null,
		int? PCanPromptCost1 = null,
		int? PCanPromptCost2 = null,
		int? PDisplayUnitCosts = null,
		int? CanUpdateCur = null,
		string Whse = null)
		{
			ItemType _PItem = PItem;
			CostTypeType _PCostType = PCostType;
			CostMethodType _PCostMethod = PCostMethod;
			PMTCodeType _PPMTCode = PPMTCode;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			Flag _PCanUpdateCosts = PCanUpdateCosts;
			Flag _PCanPromptCost1 = PCanPromptCost1;
			Flag _PCanPromptCost2 = PCanPromptCost2;
			Flag _PDisplayUnitCosts = PDisplayUnitCosts;
			Flag _CanUpdateCur = CanUpdateCur;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CanUpdateCostsSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostType", _PCostType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostMethod", _PCostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPMTCode", _PPMTCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCanUpdateCosts", _PCanUpdateCosts, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCanPromptCost1", _PCanPromptCost1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCanPromptCost2", _PCanPromptCost2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDisplayUnitCosts", _PDisplayUnitCosts, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanUpdateCur", _CanUpdateCur, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCanUpdateCosts = _PCanUpdateCosts;
				PCanPromptCost1 = _PCanPromptCost1;
				PCanPromptCost2 = _PCanPromptCost2;
				PDisplayUnitCosts = _PDisplayUnitCosts;
				CanUpdateCur = _CanUpdateCur;
				
				return (Severity, PCanUpdateCosts, PCanPromptCost1, PCanPromptCost2, PDisplayUnitCosts, CanUpdateCur);
			}
		}
	}
}

//PROJECT NAME: Logistics
//CLASS NAME: CoItemSumJobOperCosts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoItemSumJobOperCosts : ICoItemSumJobOperCosts
	{
		readonly IApplicationDB appDB;
		
		public CoItemSumJobOperCosts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? SetupCost,
			decimal? RunCost,
			decimal? FixOvhdCost,
			decimal? VarOvhdCost,
			decimal? OutSideCost,
			string InfoBar) CoItemSumJobOperCostsSp(
			string CoNum,
			int? CoLine,
			decimal? ProdCycles,
			decimal? SetupCost,
			decimal? RunCost,
			decimal? FixOvhdCost,
			decimal? VarOvhdCost,
			decimal? OutSideCost,
			string InfoBar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			QtyUnitType _ProdCycles = ProdCycles;
			AmountType _SetupCost = SetupCost;
			AmountType _RunCost = RunCost;
			AmountType _FixOvhdCost = FixOvhdCost;
			AmountType _VarOvhdCost = VarOvhdCost;
			AmountType _OutSideCost = OutSideCost;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoItemSumJobOperCostsSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdCycles", _ProdCycles, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupCost", _SetupCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RunCost", _RunCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FixOvhdCost", _FixOvhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VarOvhdCost", _VarOvhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutSideCost", _OutSideCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SetupCost = _SetupCost;
				RunCost = _RunCost;
				FixOvhdCost = _FixOvhdCost;
				VarOvhdCost = _VarOvhdCost;
				OutSideCost = _OutSideCost;
				InfoBar = _InfoBar;
				
				return (Severity, SetupCost, RunCost, FixOvhdCost, VarOvhdCost, OutSideCost, InfoBar);
			}
		}
	}
}

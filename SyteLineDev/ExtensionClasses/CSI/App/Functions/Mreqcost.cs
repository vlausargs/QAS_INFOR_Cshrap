//PROJECT NAME: Data
//CLASS NAME: Mreqcost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Mreqcost : IMreqcost
	{
		readonly IApplicationDB appDB;
		
		public Mreqcost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? MatlCost,
			decimal? LaborCost,
			decimal? OtherCost,
			decimal? OvhCost,
			decimal? GaCost,
			decimal? TTotCost) MreqcostSp(
			string IProjNum,
			string IMsNum,
			int? CalcAct,
			decimal? MatlCost,
			decimal? LaborCost,
			decimal? OtherCost,
			decimal? OvhCost,
			decimal? GaCost,
			decimal? TTotCost)
		{
			ProjNumType _IProjNum = IProjNum;
			ProjMsNumType _IMsNum = IMsNum;
			FlagNyType _CalcAct = CalcAct;
			AmountType _MatlCost = MatlCost;
			AmountType _LaborCost = LaborCost;
			AmountType _OtherCost = OtherCost;
			AmountType _OvhCost = OvhCost;
			AmountType _GaCost = GaCost;
			AmountType _TTotCost = TTotCost;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MreqcostSp";
				
				appDB.AddCommandParameter(cmd, "IProjNum", _IProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IMsNum", _IMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcAct", _CalcAct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LaborCost", _LaborCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OtherCost", _OtherCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OvhCost", _OvhCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GaCost", _GaCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TTotCost", _TTotCost, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MatlCost = _MatlCost;
				LaborCost = _LaborCost;
				OtherCost = _OtherCost;
				OvhCost = _OvhCost;
				GaCost = _GaCost;
				TTotCost = _TTotCost;
				
				return (Severity, MatlCost, LaborCost, OtherCost, OvhCost, GaCost, TTotCost);
			}
		}
	}
}

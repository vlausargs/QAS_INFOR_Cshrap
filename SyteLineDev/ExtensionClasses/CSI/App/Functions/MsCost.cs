//PROJECT NAME: Data
//CLASS NAME: MsCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MsCost : IMsCost
	{
		readonly IApplicationDB appDB;
		
		public MsCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? OActMatlCost,
			decimal? OActLaborCost,
			decimal? OActOvhCost,
			decimal? OActGaCost,
			decimal? OActOtherCost,
			decimal? TTotCost) MsCostSp(
			string IProjNum,
			string IMsNum,
			int? CalcAct,
			decimal? OActMatlCost,
			decimal? OActLaborCost,
			decimal? OActOvhCost,
			decimal? OActGaCost,
			decimal? OActOtherCost,
			decimal? TTotCost)
		{
			ProjNumType _IProjNum = IProjNum;
			ProjMsNumType _IMsNum = IMsNum;
			FlagNyType _CalcAct = CalcAct;
			AmountType _OActMatlCost = OActMatlCost;
			AmountType _OActLaborCost = OActLaborCost;
			AmountType _OActOvhCost = OActOvhCost;
			AmountType _OActGaCost = OActGaCost;
			AmountType _OActOtherCost = OActOtherCost;
			AmountType _TTotCost = TTotCost;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MsCostSp";
				
				appDB.AddCommandParameter(cmd, "IProjNum", _IProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IMsNum", _IMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcAct", _CalcAct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OActMatlCost", _OActMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OActLaborCost", _OActLaborCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OActOvhCost", _OActOvhCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OActGaCost", _OActGaCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OActOtherCost", _OActOtherCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TTotCost", _TTotCost, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OActMatlCost = _OActMatlCost;
				OActLaborCost = _OActLaborCost;
				OActOvhCost = _OActOvhCost;
				OActGaCost = _OActGaCost;
				OActOtherCost = _OActOtherCost;
				TTotCost = _TTotCost;
				
				return (Severity, OActMatlCost, OActLaborCost, OActOvhCost, OActGaCost, OActOtherCost, TTotCost);
			}
		}
	}
}

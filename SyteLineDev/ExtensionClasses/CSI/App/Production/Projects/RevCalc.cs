//PROJECT NAME: Production
//CLASS NAME: RevCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class RevCalc : IRevCalc
	{
		readonly IApplicationDB appDB;
		
		
		public RevCalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? OActRev,
		decimal? OActMatlCost,
		decimal? OActLaborCost,
		decimal? OActOvhCost,
		decimal? OActGaCost,
		decimal? OActOtherCost,
		DateTime? OPlanDate) RevCalcSp(string IProjNum,
		string IMsNum,
		int? CalcAct,
		decimal? OActRev,
		decimal? OActMatlCost,
		decimal? OActLaborCost,
		decimal? OActOvhCost,
		decimal? OActGaCost,
		decimal? OActOtherCost,
		DateTime? OPlanDate = null)
		{
			ProjNumType _IProjNum = IProjNum;
			ProjMsNumType _IMsNum = IMsNum;
			FlagNyType _CalcAct = CalcAct;
			AmountType _OActRev = OActRev;
			AmountType _OActMatlCost = OActMatlCost;
			AmountType _OActLaborCost = OActLaborCost;
			AmountType _OActOvhCost = OActOvhCost;
			AmountType _OActGaCost = OActGaCost;
			AmountType _OActOtherCost = OActOtherCost;
			DateType _OPlanDate = OPlanDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RevCalcSp";
				
				appDB.AddCommandParameter(cmd, "IProjNum", _IProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IMsNum", _IMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcAct", _CalcAct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OActRev", _OActRev, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OActMatlCost", _OActMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OActLaborCost", _OActLaborCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OActOvhCost", _OActOvhCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OActGaCost", _OActGaCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OActOtherCost", _OActOtherCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OPlanDate", _OPlanDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OActRev = _OActRev;
				OActMatlCost = _OActMatlCost;
				OActLaborCost = _OActLaborCost;
				OActOvhCost = _OActOvhCost;
				OActGaCost = _OActGaCost;
				OActOtherCost = _OActOtherCost;
				OPlanDate = _OPlanDate;
				
				return (Severity, OActRev, OActMatlCost, OActLaborCost, OActOvhCost, OActGaCost, OActOtherCost, OPlanDate);
			}
		}
	}
}

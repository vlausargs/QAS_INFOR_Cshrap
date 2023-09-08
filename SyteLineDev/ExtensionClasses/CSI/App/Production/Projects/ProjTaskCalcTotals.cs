//PROJECT NAME: Production
//CLASS NAME: ProjTaskCalcTotals.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjTaskCalcTotals : IProjTaskCalcTotals
	{
		readonly IApplicationDB appDB;
		
		public ProjTaskCalcTotals(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ProjTaskCalcTotalsFn(
			string CalcType,
			string ProjNum,
			int? TaskNum,
			int? Seq,
			string CostCodeType,
			decimal? OvhRate,
			decimal? GARate,
			string type)
		{
			GenericCodeType _CalcType = CalcType;
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _Seq = Seq;
			CostCodeTypeType _CostCodeType = CostCodeType;
			ProjRateType _OvhRate = OvhRate;
			ProjRateType _GARate = GARate;
			ProjCostTypeType _type = type;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ProjTaskCalcTotals](@CalcType, @ProjNum, @TaskNum, @Seq, @CostCodeType, @OvhRate, @GARate, @type)";
				
				appDB.AddCommandParameter(cmd, "CalcType", _CalcType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCodeType", _CostCodeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OvhRate", _OvhRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GARate", _GARate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "type", _type, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}

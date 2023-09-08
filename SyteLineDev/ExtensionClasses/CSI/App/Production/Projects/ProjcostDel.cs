//PROJECT NAME: Production
//CLASS NAME: ProjcostDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjcostDel : IProjcostDel
	{
		readonly IApplicationDB appDB;
		
		
		public ProjcostDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProjcostDelSp(string ProjNum,
		int? TaskNum,
		int? Seq,
		string CostCode,
		decimal? Units,
		decimal? FcstCost,
		string CostCodeType,
		decimal? FcstCostAcc,
		string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _Seq = Seq;
			CostCodeType _CostCode = CostCode;
			ProjUnitsType _Units = Units;
			AmountType _FcstCost = FcstCost;
			CostCodeTypeType _CostCodeType = CostCodeType;
			AmountType _FcstCostAcc = FcstCostAcc;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjcostDelSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Units", _Units, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FcstCost", _FcstCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCodeType", _CostCodeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FcstCostAcc", _FcstCostAcc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

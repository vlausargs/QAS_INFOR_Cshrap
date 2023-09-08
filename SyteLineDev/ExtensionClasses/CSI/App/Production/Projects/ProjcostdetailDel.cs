//PROJECT NAME: Production
//CLASS NAME: ProjcostdetailDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjcostdetailDel : IProjcostdetailDel
	{
		readonly IApplicationDB appDB;
		
		
		public ProjcostdetailDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProjcostdetailDelSp(string ProjNum,
		int? TaskNum,
		int? Seq,
		string CostCode,
		string CostCodeType,
		int? Year,
		int? Month,
		decimal? FcstCost,
		decimal? FcstCostAcc,
		string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _Seq = Seq;
			CostCodeType _CostCode = CostCode;
			CostCodeTypeType _CostCodeType = CostCodeType;
			FiscalYearType _Year = Year;
			ProjcostDetailPeriodType _Month = Month;
			AmountType _FcstCost = FcstCost;
			AmountType _FcstCostAcc = FcstCostAcc;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjcostdetailDelSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCodeType", _CostCodeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Year", _Year, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Month", _Month, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FcstCost", _FcstCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FcstCostAcc", _FcstCostAcc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

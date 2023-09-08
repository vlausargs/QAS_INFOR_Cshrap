//PROJECT NAME: Production
//CLASS NAME: ProjCostRollupUpdateProjCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjCostRollupUpdateProjCost : IProjCostRollupUpdateProjCost
	{
		readonly IApplicationDB appDB;
		
		public ProjCostRollupUpdateProjCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ProjCostRollupUpdateProjCostSp(
			int? ProjtaskTaskNum,
			string CostCode,
			int? ProjmatlSeq,
			string CostCodeType,
			int? Year,
			int? Period,
			decimal? Amount,
			int? CurrencyPlaces,
			string ProjType,
			string Infobar)
		{
			TaskNumType _ProjtaskTaskNum = ProjtaskTaskNum;
			CostCodeType _CostCode = CostCode;
			ProjmatlSeqType _ProjmatlSeq = ProjmatlSeq;
			CostCodeTypeType _CostCodeType = CostCodeType;
			FiscalYearType _Year = Year;
			ProjcostDetailPeriodType _Period = Period;
			AmountType _Amount = Amount;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			ProjTypeType _ProjType = ProjType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjCostRollupUpdateProjCostSp";
				
				appDB.AddCommandParameter(cmd, "ProjtaskTaskNum", _ProjtaskTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjmatlSeq", _ProjmatlSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCodeType", _CostCodeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Year", _Year, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjType", _ProjType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

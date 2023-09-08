//PROJECT NAME: Material
//CLASS NAME: MrpWbSummary.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpWbSummary : IMrpWbSummary
	{
		readonly IApplicationDB appDB;
		
		
		public MrpWbSummary(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PoCostWb,
		decimal? PrCostWb,
		decimal? JobCostWb,
		decimal? PsCostWb,
		decimal? MpsCostWb,
		decimal? ToCostWb,
		decimal? TotalCostWb,
		decimal? PoCostSelected,
		decimal? PrCostSelected,
		decimal? JobCostSelected,
		decimal? PsCostSelected,
		decimal? MpsCostSelected,
		decimal? ToCostSelected,
		decimal? TotalCostSelected,
		int? PoOrders,
		int? JobOrders,
		int? PsOrders,
		int? MpsOrders,
		int? ToOrders,
		int? PoLines,
		int? PrLines,
		int? PsLines,
		int? MpsLines,
		int? ToLines) MrpWbSummarySp(decimal? UserId,
		decimal? PoCostWb,
		decimal? PrCostWb,
		decimal? JobCostWb,
		decimal? PsCostWb,
		decimal? MpsCostWb,
		decimal? ToCostWb,
		decimal? TotalCostWb,
		decimal? PoCostSelected,
		decimal? PrCostSelected,
		decimal? JobCostSelected,
		decimal? PsCostSelected,
		decimal? MpsCostSelected,
		decimal? ToCostSelected,
		decimal? TotalCostSelected,
		int? PoOrders,
		int? JobOrders,
		int? PsOrders,
		int? MpsOrders,
		int? ToOrders,
		int? PoLines,
		int? PrLines,
		int? PsLines,
		int? MpsLines,
		int? ToLines)
		{
			TokenType _UserId = UserId;
			AmtTotType _PoCostWb = PoCostWb;
			AmtTotType _PrCostWb = PrCostWb;
			AmtTotType _JobCostWb = JobCostWb;
			AmtTotType _PsCostWb = PsCostWb;
			AmtTotType _MpsCostWb = MpsCostWb;
			AmtTotType _ToCostWb = ToCostWb;
			AmtTotType _TotalCostWb = TotalCostWb;
			AmtTotType _PoCostSelected = PoCostSelected;
			AmtTotType _PrCostSelected = PrCostSelected;
			AmtTotType _JobCostSelected = JobCostSelected;
			AmtTotType _PsCostSelected = PsCostSelected;
			AmtTotType _MpsCostSelected = MpsCostSelected;
			AmtTotType _ToCostSelected = ToCostSelected;
			AmtTotType _TotalCostSelected = TotalCostSelected;
			IntType _PoOrders = PoOrders;
			IntType _JobOrders = JobOrders;
			IntType _PsOrders = PsOrders;
			IntType _MpsOrders = MpsOrders;
			IntType _ToOrders = ToOrders;
			IntType _PoLines = PoLines;
			IntType _PrLines = PrLines;
			IntType _PsLines = PsLines;
			IntType _MpsLines = MpsLines;
			IntType _ToLines = ToLines;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpWbSummarySp";
				
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoCostWb", _PoCostWb, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrCostWb", _PrCostWb, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobCostWb", _JobCostWb, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PsCostWb", _PsCostWb, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MpsCostWb", _MpsCostWb, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToCostWb", _ToCostWb, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotalCostWb", _TotalCostWb, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoCostSelected", _PoCostSelected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrCostSelected", _PrCostSelected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobCostSelected", _JobCostSelected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PsCostSelected", _PsCostSelected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MpsCostSelected", _MpsCostSelected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToCostSelected", _ToCostSelected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotalCostSelected", _TotalCostSelected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoOrders", _PoOrders, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobOrders", _JobOrders, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PsOrders", _PsOrders, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MpsOrders", _MpsOrders, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToOrders", _ToOrders, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoLines", _PoLines, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrLines", _PrLines, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PsLines", _PsLines, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MpsLines", _MpsLines, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToLines", _ToLines, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoCostWb = _PoCostWb;
				PrCostWb = _PrCostWb;
				JobCostWb = _JobCostWb;
				PsCostWb = _PsCostWb;
				MpsCostWb = _MpsCostWb;
				ToCostWb = _ToCostWb;
				TotalCostWb = _TotalCostWb;
				PoCostSelected = _PoCostSelected;
				PrCostSelected = _PrCostSelected;
				JobCostSelected = _JobCostSelected;
				PsCostSelected = _PsCostSelected;
				MpsCostSelected = _MpsCostSelected;
				ToCostSelected = _ToCostSelected;
				TotalCostSelected = _TotalCostSelected;
				PoOrders = _PoOrders;
				JobOrders = _JobOrders;
				PsOrders = _PsOrders;
				MpsOrders = _MpsOrders;
				ToOrders = _ToOrders;
				PoLines = _PoLines;
				PrLines = _PrLines;
				PsLines = _PsLines;
				MpsLines = _MpsLines;
				ToLines = _ToLines;
				
				return (Severity, PoCostWb, PrCostWb, JobCostWb, PsCostWb, MpsCostWb, ToCostWb, TotalCostWb, PoCostSelected, PrCostSelected, JobCostSelected, PsCostSelected, MpsCostSelected, ToCostSelected, TotalCostSelected, PoOrders, JobOrders, PsOrders, MpsOrders, ToOrders, PoLines, PrLines, PsLines, MpsLines, ToLines);
			}
		}
	}
}

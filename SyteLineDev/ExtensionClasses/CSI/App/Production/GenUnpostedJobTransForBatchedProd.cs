//PROJECT NAME: Production
//CLASS NAME: GenUnpostedJobTransForBatchedProd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class GenUnpostedJobTransForBatchedProd : IGenUnpostedJobTransForBatchedProd
	{
		readonly IApplicationDB appDB;
		
		
		public GenUnpostedJobTransForBatchedProd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GenUnpostedJobTransForBatchedProdSp(int? ProdBatchId,
		string TransType,
		DateTime? TransDate,
		decimal? QtyComplete,
		decimal? QtyScrapped,
		decimal? AHrs,
		string EmpNum,
		int? StartTimeHrs,
		int? EndTimeHrs,
		string IndCode,
		string PayRate,
		decimal? QtyMoved,
		string UserCode,
		decimal? PrRate,
		decimal? JobRate,
		string Shift,
		string ReasonCode,
		string Loc,
		string ContainerNum,
		string Lot,
		string CostCode,
		string Infobar)
		{
			ApsBatchNumberType _ProdBatchId = ProdBatchId;
			JobtranTypeType _TransType = TransType;
			DateType _TransDate = TransDate;
			QtyUnitType _QtyComplete = QtyComplete;
			QtyUnitType _QtyScrapped = QtyScrapped;
			TotalHoursType _AHrs = AHrs;
			EmpNumType _EmpNum = EmpNum;
			TimeSecondsType _StartTimeHrs = StartTimeHrs;
			TimeSecondsType _EndTimeHrs = EndTimeHrs;
			IndCodeType _IndCode = IndCode;
			PayBasisType _PayRate = PayRate;
			QtyUnitType _QtyMoved = QtyMoved;
			UserCodeType _UserCode = UserCode;
			PayRateType _PrRate = PrRate;
			PayRateType _JobRate = JobRate;
			ShiftType _Shift = Shift;
			ReasonCodeType _ReasonCode = ReasonCode;
			LocType _Loc = Loc;
			ContainerNumType _ContainerNum = ContainerNum;
			LotType _Lot = Lot;
			CostCodeType _CostCode = CostCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenUnpostedJobTransForBatchedProdSp";
				
				appDB.AddCommandParameter(cmd, "ProdBatchId", _ProdBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyComplete", _QtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyScrapped", _QtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AHrs", _AHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTimeHrs", _StartTimeHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTimeHrs", _EndTimeHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IndCode", _IndCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayRate", _PayRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyMoved", _QtyMoved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserCode", _UserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrRate", _PrRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRate", _JobRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

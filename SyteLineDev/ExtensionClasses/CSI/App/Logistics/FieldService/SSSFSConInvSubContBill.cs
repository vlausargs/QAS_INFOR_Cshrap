//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubContBill.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubContBill : ISSSFSConInvSubContBill
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubContBill(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? iOrigStartDay,
			DateTime? oBegDate,
			DateTime? oEndDate,
			decimal? oAmount,
			int? oFinished,
			string Infobar) SSSFSConInvSubContBillSp(
			DateTime? iBillingThruDate,
			string iContract,
			int? iContLine,
			int? iFirstTime,
			int? iPlaces,
			string iBillingFreq,
			string iUnitOfRate,
			string iProrateUnitOfRate,
			int? iRatePeriods,
			int? iOrigStartDay,
			DateTime? iActStartDate,
			DateTime? iActEndDate,
			DateTime? iActBilledThruDate,
			decimal? iRate,
			decimal? iProrateRate,
			decimal? iQty,
			DateTime? iBegDate,
			DateTime? oBegDate,
			DateTime? oEndDate,
			decimal? oAmount,
			int? oFinished,
			string Infobar)
		{
			DateType _iBillingThruDate = iBillingThruDate;
			FSContractType _iContract = iContract;
			FSContLineType _iContLine = iContLine;
			ListYesNoType _iFirstTime = iFirstTime;
			DecimalPlacesType _iPlaces = iPlaces;
			FSContBillFreqType _iBillingFreq = iBillingFreq;
			FSContUnitOfRateType _iUnitOfRate = iUnitOfRate;
			FSContUnitOfRateType _iProrateUnitOfRate = iProrateUnitOfRate;
			ShortType _iRatePeriods = iRatePeriods;
			IntType _iOrigStartDay = iOrigStartDay;
			DateType _iActStartDate = iActStartDate;
			DateType _iActEndDate = iActEndDate;
			DateType _iActBilledThruDate = iActBilledThruDate;
			AmountType _iRate = iRate;
			AmountType _iProrateRate = iProrateRate;
			QtyUnitType _iQty = iQty;
			DateType _iBegDate = iBegDate;
			DateType _oBegDate = oBegDate;
			DateType _oEndDate = oEndDate;
			AmountType _oAmount = oAmount;
			ListYesNoType _oFinished = oFinished;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubContBillSp";
				
				appDB.AddCommandParameter(cmd, "iBillingThruDate", _iBillingThruDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iContract", _iContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iContLine", _iContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFirstTime", _iFirstTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPlaces", _iPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iBillingFreq", _iBillingFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUnitOfRate", _iUnitOfRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iProrateUnitOfRate", _iProrateUnitOfRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iRatePeriods", _iRatePeriods, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOrigStartDay", _iOrigStartDay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iActStartDate", _iActStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iActEndDate", _iActEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iActBilledThruDate", _iActBilledThruDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iRate", _iRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iProrateRate", _iProrateRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iQty", _iQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iBegDate", _iBegDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oBegDate", _oBegDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oEndDate", _oEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oAmount", _oAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oFinished", _oFinished, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				iOrigStartDay = _iOrigStartDay;
				oBegDate = _oBegDate;
				oEndDate = _oEndDate;
				oAmount = _oAmount;
				oFinished = _oFinished;
				Infobar = _Infobar;
				
				return (Severity, iOrigStartDay, oBegDate, oEndDate, oAmount, oFinished, Infobar);
			}
		}
	}
}

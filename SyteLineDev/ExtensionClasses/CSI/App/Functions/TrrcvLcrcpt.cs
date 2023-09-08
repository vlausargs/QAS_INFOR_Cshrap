//PROJECT NAME: Data
//CLASS NAME: TrrcvLcrcpt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TrrcvLcrcpt : ITrrcvLcrcpt
	{
		readonly IApplicationDB appDB;
		
		public TrrcvLcrcpt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TrrcvLcrcptSp(
			string TrnNum,
			int? TrnLine,
			decimal? TrnitemUnitDutyCost,
			decimal? TrnitemUnitFreightCost,
			decimal? TrnitemUnitBrokerageCost,
			decimal? TrnitemUnitInsuranceCost,
			decimal? TrnitemUnitLocFrtCost,
			DateTime? TTransDate,
			decimal? TrnitemQtyReq,
			decimal? TQtyReceived,
			string TransferDutyVendor,
			string TransferFreightVendor,
			string TransferBrokerageVendor,
			string TransferInsuranceVendor,
			string TransferLocFrtVendor,
			decimal? TExchRate,
			string Infobar)
		{
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			CostPrcType _TrnitemUnitDutyCost = TrnitemUnitDutyCost;
			CostPrcType _TrnitemUnitFreightCost = TrnitemUnitFreightCost;
			CostPrcType _TrnitemUnitBrokerageCost = TrnitemUnitBrokerageCost;
			CostPrcType _TrnitemUnitInsuranceCost = TrnitemUnitInsuranceCost;
			CostPrcType _TrnitemUnitLocFrtCost = TrnitemUnitLocFrtCost;
			DateType _TTransDate = TTransDate;
			QtyUnitType _TrnitemQtyReq = TrnitemQtyReq;
			QtyUnitType _TQtyReceived = TQtyReceived;
			VendNumType _TransferDutyVendor = TransferDutyVendor;
			VendNumType _TransferFreightVendor = TransferFreightVendor;
			VendNumType _TransferBrokerageVendor = TransferBrokerageVendor;
			VendNumType _TransferInsuranceVendor = TransferInsuranceVendor;
			VendNumType _TransferLocFrtVendor = TransferLocFrtVendor;
			ExchRateType _TExchRate = TExchRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrrcvLcrcptSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitDutyCost", _TrnitemUnitDutyCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitFreightCost", _TrnitemUnitFreightCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitBrokerageCost", _TrnitemUnitBrokerageCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitInsuranceCost", _TrnitemUnitInsuranceCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitLocFrtCost", _TrnitemUnitLocFrtCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemQtyReq", _TrnitemQtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQtyReceived", _TQtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferDutyVendor", _TransferDutyVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFreightVendor", _TransferFreightVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferBrokerageVendor", _TransferBrokerageVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferInsuranceVendor", _TransferInsuranceVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferLocFrtVendor", _TransferLocFrtVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TExchRate", _TExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

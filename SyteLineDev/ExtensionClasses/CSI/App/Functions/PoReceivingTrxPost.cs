//PROJECT NAME: Data
//CLASS NAME: PoReceivingTrxPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PoReceivingTrxPost : IPoReceivingTrxPost
	{
		readonly IApplicationDB appDB;
		
		public PoReceivingTrxPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? GRNExists,
			int? GrnLine,
			string Infobar) PoReceivingTrxPostSp(
			DateTime? TransDate,
			string Whse,
			string PoNum,
			int? PoLine,
			int? PoRelease,
			decimal? QtyToReceive,
			decimal? QtyToReject,
			string Tran1UM = null,
			int? Return = null,
			string EcCode = null,
			int? HaveItem = null,
			string Item = null,
			string Loc = null,
			string Lot = null,
			string ReasonCode = null,
			decimal? Cost = null,
			decimal? Material = null,
			decimal? Duty = null,
			decimal? Freight = null,
			decimal? Brokerage = null,
			decimal? Insurance = null,
			decimal? LocFrt = null,
			decimal? TranCost = null,
			decimal? TranMaterial = null,
			decimal? TranDuty = null,
			decimal? TranFreight = null,
			decimal? TranBrokerage = null,
			decimal? TranInsurance = null,
			decimal? TranLocFrt = null,
			decimal? FreightExchRate = 1M,
			decimal? DutyExchRate = 1M,
			decimal? BrokerageExchRate = 1M,
			decimal? InsuranceExchRate = 1M,
			decimal? LocFrtExchRate = 1M,
			int? Consign = null,
			string PackNum = "0",
			string WorkKey = null,
			int? GRNExists = 0,
			string GrnNum = null,
			int? GrnLine = 0,
			string Infobar = null,
			string ImportDocId = null,
			decimal? TaxAmount = null,
			decimal? TaxAmountConv = null,
			string EmpNum = null,
			string ManufacturerId = null,
			string ManufacturerItem = null,
			string ContainerNum = null,
			string VendInvNum = null,
			decimal? UserID = null,
			string CallFrom = null,
			string DocumentNum = null)
		{
			DateType _TransDate = TransDate;
			WhseType _Whse = Whse;
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			QtyUnitType _QtyToReceive = QtyToReceive;
			QtyUnitType _QtyToReject = QtyToReject;
			UMType _Tran1UM = Tran1UM;
			ListYesNoType _Return = Return;
			EcCodeType _EcCode = EcCode;
			ListYesNoType _HaveItem = HaveItem;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			ReasonCodeType _ReasonCode = ReasonCode;
			CostPrcType _Cost = Cost;
			CostPrcType _Material = Material;
			CostPrcType _Duty = Duty;
			CostPrcType _Freight = Freight;
			CostPrcType _Brokerage = Brokerage;
			CostPrcType _Insurance = Insurance;
			CostPrcType _LocFrt = LocFrt;
			CostPrcType _TranCost = TranCost;
			CostPrcType _TranMaterial = TranMaterial;
			CostPrcType _TranDuty = TranDuty;
			CostPrcType _TranFreight = TranFreight;
			CostPrcType _TranBrokerage = TranBrokerage;
			CostPrcType _TranInsurance = TranInsurance;
			CostPrcType _TranLocFrt = TranLocFrt;
			ExchRateType _FreightExchRate = FreightExchRate;
			ExchRateType _DutyExchRate = DutyExchRate;
			ExchRateType _BrokerageExchRate = BrokerageExchRate;
			ExchRateType _InsuranceExchRate = InsuranceExchRate;
			ExchRateType _LocFrtExchRate = LocFrtExchRate;
			ListYesNoType _Consign = Consign;
			GrnPackNumType _PackNum = PackNum;
			RefStrType _WorkKey = WorkKey;
			ListYesNoType _GRNExists = GRNExists;
			GrnNumType _GrnNum = GrnNum;
			GrnLineType _GrnLine = GrnLine;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			AmountType _TaxAmount = TaxAmount;
			AmountType _TaxAmountConv = TaxAmountConv;
			EmpNumType _EmpNum = EmpNum;
			ManufacturerIdType _ManufacturerId = ManufacturerId;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			ContainerNumType _ContainerNum = ContainerNum;
			TH_VendInvNumType _VendInvNum = VendInvNum;
			TokenType _UserID = UserID;
			StringType _CallFrom = CallFrom;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoReceivingTrxPostSp";
				
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToReceive", _QtyToReceive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToReject", _QtyToReject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Tran1UM", _Tran1UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Return", _Return, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcCode", _EcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HaveItem", _HaveItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cost", _Cost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Material", _Material, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Duty", _Duty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Freight", _Freight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Brokerage", _Brokerage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Insurance", _Insurance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocFrt", _LocFrt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranCost", _TranCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranMaterial", _TranMaterial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranDuty", _TranDuty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranFreight", _TranFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranBrokerage", _TranBrokerage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranInsurance", _TranInsurance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranLocFrt", _TranLocFrt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightExchRate", _FreightExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DutyExchRate", _DutyExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrokerageExchRate", _BrokerageExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsuranceExchRate", _InsuranceExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocFrtExchRate", _LocFrtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Consign", _Consign, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkKey", _WorkKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GRNExists", _GRNExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GrnNum", _GrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnLine", _GrnLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxAmount", _TaxAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxAmountConv", _TaxAmountConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerId", _ManufacturerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerItem", _ManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendInvNum", _VendInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallFrom", _CallFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				GRNExists = _GRNExists;
				GrnLine = _GrnLine;
				Infobar = _Infobar;
				
				return (Severity, GRNExists, GrnLine, Infobar);
			}
		}
	}
}

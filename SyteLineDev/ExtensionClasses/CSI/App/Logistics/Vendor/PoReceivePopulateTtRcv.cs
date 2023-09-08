//PROJECT NAME: Logistics
//CLASS NAME: PoReceivePopulateTtRcv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoReceivePopulateTtRcv : IPoReceivePopulateTtRcv
	{
		readonly IApplicationDB appDB;
		
		
		public PoReceivePopulateTtRcv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PoReceivePopulateTtRcvSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		string GrnNum,
		int? GrnLine = (int)0,
		string Whse = null,
		DateTime? UbTransDate = null,
		string Item = null,
		int? DerItemExists = null,
		string UM = null,
		decimal? UbQtyReceived = null,
		decimal? UbQtyRejected = null,
		decimal? UbQtyReceivedConv = null,
		decimal? UbQtyRejectedConv = null,
		string UbPackNum = null,
		int? UbDRRt = null,
		string UbLot = null,
		string UbLoc = null,
		string UbReasonCode = null,
		decimal? UnitMatCost = null,
		decimal? UnitDutyCost = null,
		decimal? UnitBrokerageCost = null,
		decimal? UnitFreightCost = null,
		decimal? UnitMatCostConv = null,
		decimal? UnitDutyCostConv = null,
		decimal? UnitBrokerageCostConv = null,
		decimal? UnitFreightCostConv = null,
		decimal? UnitInsuranceCost = null,
		decimal? UnitLocFrtCost = null,
		decimal? UnitInsuranceCostConv = null,
		decimal? UnitLocFrtCostConv = null,
		decimal? FreightExchRate = null,
		decimal? DutyExchRate = null,
		decimal? BrokerageExchRate = null,
		decimal? InsuranceExchRate = null,
		decimal? LocFrtExchRate = null,
		int? UbByCons = null,
		string UbWorkKey = null,
		int? UbSequence = null,
		Guid? RowPointer = null,
		int? UbGrnExists = null,
		string ImportDocId = null,
		string EcCode = null,
		string ManufacturerId = null,
		string ManufacturerItem = null,
		string ContainerNum = null,
		Guid? EsigRowPointer = null,
		string EsigUsername = null,
		string EsigEncryptedPassword = null,
		string EsigReasonCode = null,
		string VendInvNum = null)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			GrnNumType _GrnNum = GrnNum;
			GrnLineType _GrnLine = GrnLine;
			WhseType _Whse = Whse;
			DateType _UbTransDate = UbTransDate;
			ItemType _Item = Item;
			ListYesNoType _DerItemExists = DerItemExists;
			UMType _UM = UM;
			QtyUnitType _UbQtyReceived = UbQtyReceived;
			QtyUnitType _UbQtyRejected = UbQtyRejected;
			QtyUnitType _UbQtyReceivedConv = UbQtyReceivedConv;
			QtyUnitType _UbQtyRejectedConv = UbQtyRejectedConv;
			GrnPackNumType _UbPackNum = UbPackNum;
			ListYesNoType _UbDRRt = UbDRRt;
			LotType _UbLot = UbLot;
			LocType _UbLoc = UbLoc;
			ReasonCodeType _UbReasonCode = UbReasonCode;
			CostPrcType _UnitMatCost = UnitMatCost;
			CostPrcType _UnitDutyCost = UnitDutyCost;
			CostPrcType _UnitBrokerageCost = UnitBrokerageCost;
			CostPrcType _UnitFreightCost = UnitFreightCost;
			CostPrcType _UnitMatCostConv = UnitMatCostConv;
			CostPrcType _UnitDutyCostConv = UnitDutyCostConv;
			CostPrcType _UnitBrokerageCostConv = UnitBrokerageCostConv;
			CostPrcType _UnitFreightCostConv = UnitFreightCostConv;
			CostPrcType _UnitInsuranceCost = UnitInsuranceCost;
			CostPrcType _UnitLocFrtCost = UnitLocFrtCost;
			CostPrcType _UnitInsuranceCostConv = UnitInsuranceCostConv;
			CostPrcType _UnitLocFrtCostConv = UnitLocFrtCostConv;
			ExchRateType _FreightExchRate = FreightExchRate;
			ExchRateType _DutyExchRate = DutyExchRate;
			ExchRateType _BrokerageExchRate = BrokerageExchRate;
			ExchRateType _InsuranceExchRate = InsuranceExchRate;
			ExchRateType _LocFrtExchRate = LocFrtExchRate;
			ListYesNoType _UbByCons = UbByCons;
			RefStrType _UbWorkKey = UbWorkKey;
			IntType _UbSequence = UbSequence;
			RowPointerType _RowPointer = RowPointer;
			ListYesNoType _UbGrnExists = UbGrnExists;
			ImportDocIdType _ImportDocId = ImportDocId;
			EcCodeType _EcCode = EcCode;
			ManufacturerIdType _ManufacturerId = ManufacturerId;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			ContainerNumType _ContainerNum = ContainerNum;
			RowPointerType _EsigRowPointer = EsigRowPointer;
			UsernameType _EsigUsername = EsigUsername;
			EncryptedClientPasswordType _EsigEncryptedPassword = EsigEncryptedPassword;
			ReasonCodeType _EsigReasonCode = EsigReasonCode;
			TH_VendInvNumType _VendInvNum = VendInvNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoReceivePopulateTtRcvSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnNum", _GrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnLine", _GrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbTransDate", _UbTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerItemExists", _DerItemExists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbQtyReceived", _UbQtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbQtyRejected", _UbQtyRejected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbQtyReceivedConv", _UbQtyReceivedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbQtyRejectedConv", _UbQtyRejectedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbPackNum", _UbPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbDRRt", _UbDRRt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbLot", _UbLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbLoc", _UbLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbReasonCode", _UbReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitMatCost", _UnitMatCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitDutyCost", _UnitDutyCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCost", _UnitBrokerageCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitFreightCost", _UnitFreightCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitMatCostConv", _UnitMatCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitDutyCostConv", _UnitDutyCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCostConv", _UnitBrokerageCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitFreightCostConv", _UnitFreightCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCost", _UnitInsuranceCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCost", _UnitLocFrtCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCostConv", _UnitInsuranceCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCostConv", _UnitLocFrtCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightExchRate", _FreightExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DutyExchRate", _DutyExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrokerageExchRate", _BrokerageExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsuranceExchRate", _InsuranceExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocFrtExchRate", _LocFrtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbByCons", _UbByCons, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbWorkKey", _UbWorkKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbSequence", _UbSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbGrnExists", _UbGrnExists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcCode", _EcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerId", _ManufacturerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerItem", _ManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EsigRowPointer", _EsigRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EsigUsername", _EsigUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EsigEncryptedPassword", _EsigEncryptedPassword, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EsigReasonCode", _EsigReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendInvNum", _VendInvNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}

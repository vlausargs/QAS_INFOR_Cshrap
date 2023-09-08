//PROJECT NAME: Logistics
//CLASS NAME: IPoReceivePopulateTtRcv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoReceivePopulateTtRcv
	{
		int? PoReceivePopulateTtRcvSp(string PoNum,
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
		string VendInvNum = null);
	}
}


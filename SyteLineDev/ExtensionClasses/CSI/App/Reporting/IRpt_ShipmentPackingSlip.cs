//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ShipmentPackingSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ShipmentPackingSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ShipmentPackingSlipSp(int? PrintBlankPickupDate = null,
		int? IncludeSerialNumbers = null,
		int? PrintShipmentSequenceText = null,
		int? DisplayShipmentSeqNotes = null,
		int? DisplayShipmentPackageNotes = null,
		decimal? MinShipNum = null,
		decimal? MaxShipNum = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? ShiptoStarting = null,
		int? ShiptoEnding = null,
		DateTime? PickupDateStarting = null,
		DateTime? PickupDateEnding = null,
		int? DateStartingOffset = null,
		int? DateEndingOffset = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		string pSite = null,
		int? PrintDescription = null,
		int? pPrintHeaderOnAllPages = null,
		int? pPageBetweenPackages = null,
		int? pPrintCertificateOfConformance = null,
		int? pPrintPackageWeight = null,
		int? pPrintDeliveryIncoTerms = null,
		int? pPrintEUDetails = null,
		int? pPrintKitComponents = null,
		int? pPrintLotNumbers = null);
	}
}


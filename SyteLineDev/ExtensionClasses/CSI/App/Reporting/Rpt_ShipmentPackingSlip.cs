//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ShipmentPackingSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ShipmentPackingSlip : IRpt_ShipmentPackingSlip
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ShipmentPackingSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ShipmentPackingSlipSp(int? PrintBlankPickupDate = null,
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
		int? pPrintLotNumbers = null)
		{
			FlagNyType _PrintBlankPickupDate = PrintBlankPickupDate;
			ListYesNoType _IncludeSerialNumbers = IncludeSerialNumbers;
			FlagNyType _PrintShipmentSequenceText = PrintShipmentSequenceText;
			FlagNyType _DisplayShipmentSeqNotes = DisplayShipmentSeqNotes;
			FlagNyType _DisplayShipmentPackageNotes = DisplayShipmentPackageNotes;
			ShipmentIDType _MinShipNum = MinShipNum;
			ShipmentIDType _MaxShipNum = MaxShipNum;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			CustSeqType _ShiptoStarting = ShiptoStarting;
			CustSeqType _ShiptoEnding = ShiptoEnding;
			DateType _PickupDateStarting = PickupDateStarting;
			DateType _PickupDateEnding = PickupDateEnding;
			DateOffsetType _DateStartingOffset = DateStartingOffset;
			DateOffsetType _DateEndingOffset = DateEndingOffset;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			ListYesNoType _PrintDescription = PrintDescription;
			ListYesNoType _pPrintHeaderOnAllPages = pPrintHeaderOnAllPages;
			ListYesNoType _pPageBetweenPackages = pPageBetweenPackages;
			ListYesNoType _pPrintCertificateOfConformance = pPrintCertificateOfConformance;
			ListYesNoType _pPrintPackageWeight = pPrintPackageWeight;
			ListYesNoType _pPrintDeliveryIncoTerms = pPrintDeliveryIncoTerms;
			ListYesNoType _pPrintEUDetails = pPrintEUDetails;
			ListYesNoType _pPrintKitComponents = pPrintKitComponents;
			ListYesNoType _pPrintLotNumbers = pPrintLotNumbers;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ShipmentPackingSlipSp";
				
				appDB.AddCommandParameter(cmd, "PrintBlankPickupDate", _PrintBlankPickupDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeSerialNumbers", _IncludeSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintShipmentSequenceText", _PrintShipmentSequenceText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayShipmentSeqNotes", _DisplayShipmentSeqNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayShipmentPackageNotes", _DisplayShipmentPackageNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MinShipNum", _MinShipNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxShipNum", _MaxShipNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShiptoStarting", _ShiptoStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShiptoEnding", _ShiptoEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateStarting", _PickupDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickupDateEnding", _PickupDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingOffset", _DateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEndingOffset", _DateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDescription", _PrintDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintHeaderOnAllPages", _pPrintHeaderOnAllPages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPageBetweenPackages", _pPageBetweenPackages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintCertificateOfConformance", _pPrintCertificateOfConformance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintPackageWeight", _pPrintPackageWeight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintDeliveryIncoTerms", _pPrintDeliveryIncoTerms, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintEUDetails", _pPrintEUDetails, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintKitComponents", _pPrintKitComponents, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintLotNumbers", _pPrintLotNumbers, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}

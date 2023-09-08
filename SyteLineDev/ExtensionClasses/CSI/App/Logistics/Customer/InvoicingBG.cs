//PROJECT NAME: Logistics
//CLASS NAME: InvoicingBG.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvoicingBG : IInvoicingBG
	{
		readonly IApplicationDB appDB;
		
		
		public InvoicingBG(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string StartInvNum,
		string EndInvNum,
		string Infobar,
		string DoHdrList,
		int? PrintConInvReport) InvoicingBGSp(Guid? SessionID,
		string InvoiceType,
		string BGTaskName,
		string InvType = "R",
		string InvCred = "I",
		DateTime? InvDate = null,
		string StartCustomer = null,
		string EndCustomer = null,
		string StartOrderNum = null,
		string EndOrderNum = null,
		int? StartLine = null,
		int? EndLine = null,
		int? StartRelease = null,
		int? EndRelease = null,
		DateTime? StartLastShipDate = null,
		DateTime? EndLastShipDate = null,
		int? StartPackNum = null,
		int? EndPackNum = null,
		int? CreateFromPackSlip = 0,
		string pMooreForms = "N",
		int? pNonDraftCust = 0,
		string SelectedStartInvNum = null,
		int? CheckShipItemActiveFlag = 0,
		string StartInvNum = "",
		string EndInvNum = "",
		string PrintItemCustomerItem = "CI",
		int? TransToDomCurr = 0,
		int? PrintSerialNumbers = 1,
		int? PrintPlanItemMaterial = 0,
		string PrintConfigurationDetail = "N",
		int? PrintEuro = 0,
		int? PrintCustomerNotes = 1,
		int? PrintOrderNotes = 1,
		int? PrintOrderLineNotes = 1,
		int? PrintOrderBlanketLineNotes = 1,
		int? PrintProgressiveBillingNotes = 0,
		int? PrintInternalNotes = 1,
		int? PrintExternalNotes = 1,
		int? PrintItemOverview = 0,
		int? DisplayHeader = 1,
		int? PrintLineReleaseDescription = 1,
		int? PrintStandardOrderText = 1,
		int? PrintBillToNotes = 1,
		string LangCode = null,
		int? PrintDiscountAmt = 0,
		int? BatchId = null,
		string BGSessionId = null,
		decimal? UserId = null,
		string Infobar = null,
		int? LCRVar = null,
		string pBegDoNum = null,
		string pEndDoNum = null,
		string pBegCustPo = null,
		string pEndCustPo = null,
		string DoHdrList = null,
		int? PItemTypeCust = null,
		int? PItemTypeItem = null,
		int? PrintConInvReport = null,
		string PInvNum = null,
		int? POrderNums = null,
		decimal? PMiscCharges = null,
		decimal? PSalesTax = null,
		decimal? PFreight = null,
		string TCustPT = null,
		string PApplyToInvNum = null,
		string TOpt = null,
		int? UseProfile = null,
		string Mode = "PROCESS",
		int? PrintLotNumbers = 1,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string CurrentCultureName = null,
		decimal? StartingShipment = null,
		decimal? EndingShipment = null,
		string CalledFrom = null,
		Guid? InvoicBuilderProcessID = null,
		int? PrintDrawingNumber = 0,
		int? PrintTax = 0,
		int? PrintCurrencyCode = 0,
		int? PrintDeliveryIncoTerms = 0,
		int? PrintEUDetails = 0,
		int? PrintHeaderOnAllPages = 0,
		int? CreateFromShipment = 0,
		int? PrintTaxID = 0)
		{
			RowPointerType _SessionID = SessionID;
			StringType _InvoiceType = InvoiceType;
			BGTaskNameType _BGTaskName = BGTaskName;
			StringType _InvType = InvType;
			StringType _InvCred = InvCred;
			DateType _InvDate = InvDate;
			CustNumType _StartCustomer = StartCustomer;
			CustNumType _EndCustomer = EndCustomer;
			CoNumType _StartOrderNum = StartOrderNum;
			CoNumType _EndOrderNum = EndOrderNum;
			CoLineType _StartLine = StartLine;
			CoLineType _EndLine = EndLine;
			CoReleaseType _StartRelease = StartRelease;
			CoReleaseType _EndRelease = EndRelease;
			DateType _StartLastShipDate = StartLastShipDate;
			DateType _EndLastShipDate = EndLastShipDate;
			PackNumType _StartPackNum = StartPackNum;
			PackNumType _EndPackNum = EndPackNum;
			ListYesNoType _CreateFromPackSlip = CreateFromPackSlip;
			StringType _pMooreForms = pMooreForms;
			ListYesNoType _pNonDraftCust = pNonDraftCust;
			InvNumType _SelectedStartInvNum = SelectedStartInvNum;
			ListYesNoType _CheckShipItemActiveFlag = CheckShipItemActiveFlag;
			InvNumType _StartInvNum = StartInvNum;
			InvNumType _EndInvNum = EndInvNum;
			StringType _PrintItemCustomerItem = PrintItemCustomerItem;
			ListYesNoType _TransToDomCurr = TransToDomCurr;
			ListYesNoType _PrintSerialNumbers = PrintSerialNumbers;
			ListYesNoType _PrintPlanItemMaterial = PrintPlanItemMaterial;
			StringType _PrintConfigurationDetail = PrintConfigurationDetail;
			ListYesNoType _PrintEuro = PrintEuro;
			ListYesNoType _PrintCustomerNotes = PrintCustomerNotes;
			ListYesNoType _PrintOrderNotes = PrintOrderNotes;
			ListYesNoType _PrintOrderLineNotes = PrintOrderLineNotes;
			ListYesNoType _PrintOrderBlanketLineNotes = PrintOrderBlanketLineNotes;
			ListYesNoType _PrintProgressiveBillingNotes = PrintProgressiveBillingNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PrintLineReleaseDescription = PrintLineReleaseDescription;
			ListYesNoType _PrintStandardOrderText = PrintStandardOrderText;
			ListYesNoType _PrintBillToNotes = PrintBillToNotes;
			LangCodeType _LangCode = LangCode;
			ListYesNoType _PrintDiscountAmt = PrintDiscountAmt;
			BatchIdType _BatchId = BatchId;
			StringType _BGSessionId = BGSessionId;
			TokenType _UserId = UserId;
			InfobarType _Infobar = Infobar;
			ListYesNoType _LCRVar = LCRVar;
			DoNumType _pBegDoNum = pBegDoNum;
			DoNumType _pEndDoNum = pEndDoNum;
			CustPoType _pBegCustPo = pBegCustPo;
			CustPoType _pEndCustPo = pEndCustPo;
			LongListType _DoHdrList = DoHdrList;
			ListYesNoType _PItemTypeCust = PItemTypeCust;
			ListYesNoType _PItemTypeItem = PItemTypeItem;
			ListYesNoType _PrintConInvReport = PrintConInvReport;
			InvNumType _PInvNum = PInvNum;
			ListYesNoType _POrderNums = POrderNums;
			AmountType _PMiscCharges = PMiscCharges;
			AmountType _PSalesTax = PSalesTax;
			AmountType _PFreight = PFreight;
			CustPayTypeType _TCustPT = TCustPT;
			InvNumType _PApplyToInvNum = PApplyToInvNum;
			StringType _TOpt = TOpt;
			ListYesNoType _UseProfile = UseProfile;
			StringType _Mode = Mode;
			ListYesNoType _PrintLotNumbers = PrintLotNumbers;
			DateType _StartInvDate = StartInvDate;
			DateType _EndInvDate = EndInvDate;
			LanguageIDType _CurrentCultureName = CurrentCultureName;
			ShipmentIDType _StartingShipment = StartingShipment;
			ShipmentIDType _EndingShipment = EndingShipment;
			InfobarType _CalledFrom = CalledFrom;
			RowPointerType _InvoicBuilderProcessID = InvoicBuilderProcessID;
			ListYesNoType _PrintDrawingNumber = PrintDrawingNumber;
			ListYesNoType _PrintTax = PrintTax;
			ListYesNoType _PrintCurrencyCode = PrintCurrencyCode;
			ListYesNoType _PrintDeliveryIncoTerms = PrintDeliveryIncoTerms;
			ListYesNoType _PrintEUDetails = PrintEUDetails;
			ListYesNoType _PrintHeaderOnAllPages = PrintHeaderOnAllPages;
			FlagNyType _CreateFromShipment = CreateFromShipment;
			ListYesNoType _PrintTaxID = PrintTaxID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvoicingBGSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceType", _InvoiceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGTaskName", _BGTaskName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvType", _InvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustomer", _StartCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustomer", _EndCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrderNum", _StartOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderNum", _EndOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLine", _StartLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLine", _EndLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartRelease", _StartRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRelease", _EndRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLastShipDate", _StartLastShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLastShipDate", _EndLastShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPackNum", _StartPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPackNum", _EndPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateFromPackSlip", _CreateFromPackSlip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMooreForms", _pMooreForms, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNonDraftCust", _pNonDraftCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectedStartInvNum", _SelectedStartInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckShipItemActiveFlag", _CheckShipItemActiveFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvNum", _StartInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndInvNum", _EndInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintItemCustomerItem", _PrintItemCustomerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransToDomCurr", _TransToDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSerialNumbers", _PrintSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPlanItemMaterial", _PrintPlanItemMaterial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintConfigurationDetail", _PrintConfigurationDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuro", _PrintEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustomerNotes", _PrintCustomerNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderNotes", _PrintOrderNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderLineNotes", _PrintOrderLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderBlanketLineNotes", _PrintOrderBlanketLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProgressiveBillingNotes", _PrintProgressiveBillingNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseDescription", _PrintLineReleaseDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintStandardOrderText", _PrintStandardOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBillToNotes", _PrintBillToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LangCode", _LangCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDiscountAmt", _PrintDiscountAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BatchId", _BatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LCRVar", _LCRVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegDoNum", _pBegDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDoNum", _pEndDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegCustPo", _pBegCustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustPo", _pEndCustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoHdrList", _DoHdrList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemTypeCust", _PItemTypeCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemTypeItem", _PItemTypeItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintConInvReport", _PrintConInvReport, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderNums", _POrderNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscCharges", _PMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCustPT", _TCustPT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PApplyToInvNum", _PApplyToInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOpt", _TOpt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseProfile", _UseProfile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLotNumbers", _PrintLotNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvDate", _StartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDate", _EndInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentCultureName", _CurrentCultureName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingShipment", _StartingShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingShipment", _EndingShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoicBuilderProcessID", _InvoicBuilderProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDrawingNumber", _PrintDrawingNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTax", _PrintTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCurrencyCode", _PrintCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDeliveryIncoTerms", _PrintDeliveryIncoTerms, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEUDetails", _PrintEUDetails, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintHeaderOnAllPages", _PrintHeaderOnAllPages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateFromShipment", _CreateFromShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTaxID", _PrintTaxID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StartInvNum = _StartInvNum;
				EndInvNum = _EndInvNum;
				Infobar = _Infobar;
				DoHdrList = _DoHdrList;
				PrintConInvReport = _PrintConInvReport;
				
				return (Severity, StartInvNum, EndInvNum, Infobar, DoHdrList, PrintConInvReport);
			}
		}
	}
}

//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderInvoicingCreditMemo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_OrderInvoicingCreditMemo : IRpt_OrderInvoicingCreditMemo
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_OrderInvoicingCreditMemo(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderInvoicingCreditMemoSp(string pSessionIDChar = null,
		string InvType = "RBP",
		string Mode = "REPRINT",
		string StartInvNum = null,
		string EndInvNum = null,
		string StartOrderNum = null,
		string EndOrderNum = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string StartCustNum = null,
		string EndCustNum = null,
		string PrintItemCustomerItem = "CI",
		int? TransToDomCurr = 0,
		string InvCred = "I",
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
		string BGSessionId = null,
		int? PrintDiscountAmt = 0,
		int? PrintLotNumbers = 1,
		string pSite = null,
		string CalledFrom = null,
		Guid? InvoicBuilderProcessID = null,
		string StartBuilderInvNum = null,
		string EndBuilderInvNum = null,
		int? pPrintDrawingNumber = 0,
		int? pPrintDeliveryIncoTerms = 0,
		int? pPrintTax = 0,
		int? pPrintEUDetails = 0,
		int? pPrintCurrCode = 0,
		int? pPrintHeaderOnAllPages = 0)
		{
			StringType _pSessionIDChar = pSessionIDChar;
			StringType _InvType = InvType;
			StringType _Mode = Mode;
			InvNumType _StartInvNum = StartInvNum;
			InvNumType _EndInvNum = EndInvNum;
			CoNumType _StartOrderNum = StartOrderNum;
			CoNumType _EndOrderNum = EndOrderNum;
			DateType _StartInvDate = StartInvDate;
			DateType _EndInvDate = EndInvDate;
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			StringType _PrintItemCustomerItem = PrintItemCustomerItem;
			FlagNyType _TransToDomCurr = TransToDomCurr;
			StringType _InvCred = InvCred;
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
			StringType _BGSessionId = BGSessionId;
			ListYesNoType _PrintDiscountAmt = PrintDiscountAmt;
			ListYesNoType _PrintLotNumbers = PrintLotNumbers;
			SiteType _pSite = pSite;
			InfobarType _CalledFrom = CalledFrom;
			RowPointerType _InvoicBuilderProcessID = InvoicBuilderProcessID;
			BuilderInvNumType _StartBuilderInvNum = StartBuilderInvNum;
			BuilderInvNumType _EndBuilderInvNum = EndBuilderInvNum;
			ListYesNoType _pPrintDrawingNumber = pPrintDrawingNumber;
			ListYesNoType _pPrintDeliveryIncoTerms = pPrintDeliveryIncoTerms;
			ListYesNoType _pPrintTax = pPrintTax;
			ListYesNoType _pPrintEUDetails = pPrintEUDetails;
			ListYesNoType _pPrintCurrCode = pPrintCurrCode;
			ListYesNoType _pPrintHeaderOnAllPages = pPrintHeaderOnAllPages;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_OrderInvoicingCreditMemoSp";
				
				appDB.AddCommandParameter(cmd, "pSessionIDChar", _pSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvType", _InvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvNum", _StartInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvNum", _EndInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrderNum", _StartOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderNum", _EndOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvDate", _StartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDate", _EndInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemCustomerItem", _PrintItemCustomerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransToDomCurr", _TransToDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDiscountAmt", _PrintDiscountAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLotNumbers", _PrintLotNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoicBuilderProcessID", _InvoicBuilderProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartBuilderInvNum", _StartBuilderInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndBuilderInvNum", _EndBuilderInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintDrawingNumber", _pPrintDrawingNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintDeliveryIncoTerms", _pPrintDeliveryIncoTerms, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintTax", _pPrintTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintEUDetails", _pPrintEUDetails, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintCurrCode", _pPrintCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintHeaderOnAllPages", _pPrintHeaderOnAllPages, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}

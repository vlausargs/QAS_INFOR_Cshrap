//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ConsolidatedInvoicing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ConsolidatedInvoicing : IRpt_ConsolidatedInvoicing
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ConsolidatedInvoicing(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ConsolidatedInvoicingSp(string pSessionIdChar = null,
		string pMode = "REPRINT",
		string pBegCustNum = null,
		string pEndCustNum = null,
		string pBegDoNum = null,
		string pEndDoNum = null,
		string pBegCustPo = null,
		string pEndCustPo = null,
		string pBegInvNum = null,
		string pEndInvNum = null,
		DateTime? pBegInvoiceDate = null,
		DateTime? pEndInvoiceDate = null,
		string pItemType = "CI",
		string pInvoiceOrCreditMemo = "I",
		string pConfigurationDetails = "E",
		string pInvoiceType = "RB",
		int? pEuroTotal = 0,
		int? pTranslateToDomestic = 0,
		int? PrintSerialNumbers = 1,
		int? pPlanningItemMaterials = 0,
		int? pLCR = 1,
		int? pOrderNumbers = 0,
		int? PrintOrderLineNotes = 0,
		int? PrintLineReleaseDescription = 0,
		int? PrintStandardOrderText = 0,
		int? PrintBillToNotes = 0,
		int? PrintInternalNotes = 1,
		int? PrintExternalNotes = 1,
		int? PrintItemOverview = 0,
		int? PrintDiscountAmt = 0,
		int? PrintLotNumbers = 1,
		decimal? pBegShipment = null,
		decimal? pEndShipment = null,
		string pSite = null,
		string BGUser = null)
		{
			StringType _pSessionIdChar = pSessionIdChar;
			StringType _pMode = pMode;
			CustNumType _pBegCustNum = pBegCustNum;
			CustNumType _pEndCustNum = pEndCustNum;
			DoNumType _pBegDoNum = pBegDoNum;
			DoNumType _pEndDoNum = pEndDoNum;
			CustPoType _pBegCustPo = pBegCustPo;
			CustPoType _pEndCustPo = pEndCustPo;
			InvNumType _pBegInvNum = pBegInvNum;
			InvNumType _pEndInvNum = pEndInvNum;
			DateType _pBegInvoiceDate = pBegInvoiceDate;
			DateType _pEndInvoiceDate = pEndInvoiceDate;
			StringType _pItemType = pItemType;
			BillingTypeType _pInvoiceOrCreditMemo = pInvoiceOrCreditMemo;
			StringType _pConfigurationDetails = pConfigurationDetails;
			StringType _pInvoiceType = pInvoiceType;
			ListYesNoType _pEuroTotal = pEuroTotal;
			ListYesNoType _pTranslateToDomestic = pTranslateToDomestic;
			ListYesNoType _PrintSerialNumbers = PrintSerialNumbers;
			ListYesNoType _pPlanningItemMaterials = pPlanningItemMaterials;
			ListYesNoType _pLCR = pLCR;
			ListYesNoType _pOrderNumbers = pOrderNumbers;
			ListYesNoType _PrintOrderLineNotes = PrintOrderLineNotes;
			ListYesNoType _PrintLineReleaseDescription = PrintLineReleaseDescription;
			ListYesNoType _PrintStandardOrderText = PrintStandardOrderText;
			ListYesNoType _PrintBillToNotes = PrintBillToNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			ListYesNoType _PrintDiscountAmt = PrintDiscountAmt;
			ListYesNoType _PrintLotNumbers = PrintLotNumbers;
			ShipmentIDType _pBegShipment = pBegShipment;
			ShipmentIDType _pEndShipment = pEndShipment;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ConsolidatedInvoicingSp";
				
				appDB.AddCommandParameter(cmd, "pSessionIdChar", _pSessionIdChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMode", _pMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegCustNum", _pBegCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum", _pEndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegDoNum", _pBegDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDoNum", _pEndDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegCustPo", _pBegCustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustPo", _pEndCustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegInvNum", _pBegInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndInvNum", _pEndInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegInvoiceDate", _pBegInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndInvoiceDate", _pEndInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItemType", _pItemType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvoiceOrCreditMemo", _pInvoiceOrCreditMemo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfigurationDetails", _pConfigurationDetails, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvoiceType", _pInvoiceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEuroTotal", _pEuroTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTranslateToDomestic", _pTranslateToDomestic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSerialNumbers", _PrintSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPlanningItemMaterials", _pPlanningItemMaterials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLCR", _pLCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOrderNumbers", _pOrderNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderLineNotes", _PrintOrderLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseDescription", _PrintLineReleaseDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintStandardOrderText", _PrintStandardOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBillToNotes", _PrintBillToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDiscountAmt", _PrintDiscountAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLotNumbers", _PrintLotNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegShipment", _pBegShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndShipment", _pEndShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}

//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PurchaseOrder : IRpt_PurchaseOrder
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PurchaseOrder(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseOrderSp(string pPoType = null,
		string pPoStat = null,
		string pPoitemStat = null,
		int? pPostFlag = null,
		DateTime? pPODate = null,
		int? pRoundPlaces = null,
		string pPrintItemVI = null,
		int? pPrPoTxt = null,
		int? pPrPoBlnNote = null,
		int? pPrPoLineNote = null,
		int? pPrPoBlnDesc = null,
		int? pPrPoLineDesc = null,
		int? pPrPONote = null,
		int? pTransDomCurr = null,
		int? pPrintEuro = null,
		string pStartPoNum = null,
		string pEndPoNum = null,
		int? pStartPoLine = null,
		int? pEndPoLine = null,
		int? pStartPoRElease = null,
		int? pEndPoRelease = null,
		DateTime? pStartDueDate = null,
		DateTime? pEndDueDate = null,
		string pStartvendor = null,
		string pEndVendor = null,
		DateTime? pStartorderDate = null,
		DateTime? pEndOrderDate = null,
		string pReviewPrint = null,
		int? pPODateOffset = null,
		int? pStartDueDateOffset = null,
		int? pEndDueDateOffset = null,
		int? pStartOrderDateOffset = null,
		int? pEndOrderDateOffset = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? IncludeBlnsWOReleases = 0,
		string FmSessionId = null,
		int? pPrintManufacturerItem = 0,
		decimal? UserID = null,
		int? TaskID = null,
		string BGSessionId = null,
		string pSite = null,
		int? pPrintDrawingNumber = 0,
		int? pPrintDeliveryIncoTerms = 0,
		int? pPrintEUCode = 0,
		int? pPrintOriginCode = 0,
		int? pPrintCommodityCode = 0,
		int? pPrintHeaderOnAllPages = 0,
		int? pPrintAuthorizationSignatures = 0,
		int? pPrintItemOverview = 0,
		int? ProfileExists = null,
		int? UseProfile = null,
		string Method = null,
		string Destination = null)
		{
			StringType _pPoType = pPoType;
			StringType _pPoStat = pPoStat;
			StringType _pPoitemStat = pPoitemStat;
			ListYesNoType _pPostFlag = pPostFlag;
			GenericDateType _pPODate = pPODate;
			GenericIntType _pRoundPlaces = pRoundPlaces;
			StringType _pPrintItemVI = pPrintItemVI;
			ListYesNoType _pPrPoTxt = pPrPoTxt;
			ListYesNoType _pPrPoBlnNote = pPrPoBlnNote;
			ListYesNoType _pPrPoLineNote = pPrPoLineNote;
			ListYesNoType _pPrPoBlnDesc = pPrPoBlnDesc;
			ListYesNoType _pPrPoLineDesc = pPrPoLineDesc;
			ListYesNoType _pPrPONote = pPrPONote;
			ListYesNoType _pTransDomCurr = pTransDomCurr;
			ListYesNoType _pPrintEuro = pPrintEuro;
			PoNumType _pStartPoNum = pStartPoNum;
			PoNumType _pEndPoNum = pEndPoNum;
			PoLineType _pStartPoLine = pStartPoLine;
			PoLineType _pEndPoLine = pEndPoLine;
			PoReleaseType _pStartPoRElease = pStartPoRElease;
			PoReleaseType _pEndPoRelease = pEndPoRelease;
			DateType _pStartDueDate = pStartDueDate;
			DateType _pEndDueDate = pEndDueDate;
			VendNumType _pStartvendor = pStartvendor;
			VendNumType _pEndVendor = pEndVendor;
			DateType _pStartorderDate = pStartorderDate;
			DateType _pEndOrderDate = pEndOrderDate;
			StringType _pReviewPrint = pReviewPrint;
			DateOffsetType _pPODateOffset = pPODateOffset;
			DateOffsetType _pStartDueDateOffset = pStartDueDateOffset;
			DateOffsetType _pEndDueDateOffset = pEndDueDateOffset;
			DateOffsetType _pStartOrderDateOffset = pStartOrderDateOffset;
			DateOffsetType _pEndOrderDateOffset = pEndOrderDateOffset;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			ListYesNoType _IncludeBlnsWOReleases = IncludeBlnsWOReleases;
			StringType _FmSessionId = FmSessionId;
			ListYesNoType _pPrintManufacturerItem = pPrintManufacturerItem;
			TokenType _UserID = UserID;
			TaskNumType _TaskID = TaskID;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			ListYesNoType _pPrintDrawingNumber = pPrintDrawingNumber;
			ListYesNoType _pPrintDeliveryIncoTerms = pPrintDeliveryIncoTerms;
			ListYesNoType _pPrintEUCode = pPrintEUCode;
			ListYesNoType _pPrintOriginCode = pPrintOriginCode;
			ListYesNoType _pPrintCommodityCode = pPrintCommodityCode;
			ListYesNoType _pPrintHeaderOnAllPages = pPrintHeaderOnAllPages;
			ListYesNoType _pPrintAuthorizationSignatures = pPrintAuthorizationSignatures;
			ListYesNoType _pPrintItemOverview = pPrintItemOverview;
			ListYesNoType _ProfileExists = ProfileExists;
			ListYesNoType _UseProfile = UseProfile;
			OutputMethodType _Method = Method;
			DestinationType _Destination = Destination;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PurchaseOrderSp";
				
				appDB.AddCommandParameter(cmd, "pPoType", _pPoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoStat", _pPoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoitemStat", _pPoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostFlag", _pPostFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPODate", _pPODate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRoundPlaces", _pRoundPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintItemVI", _pPrintItemVI, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrPoTxt", _pPrPoTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrPoBlnNote", _pPrPoBlnNote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrPoLineNote", _pPrPoLineNote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrPoBlnDesc", _pPrPoBlnDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrPoLineDesc", _pPrPoLineDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrPONote", _pPrPONote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDomCurr", _pTransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintEuro", _pPrintEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoNum", _pStartPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoNum", _pEndPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoLine", _pStartPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoLine", _pEndPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartPoRElease", _pStartPoRElease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPoRelease", _pEndPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDueDate", _pStartDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDueDate", _pEndDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartvendor", _pStartvendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendor", _pEndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartorderDate", _pStartorderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndOrderDate", _pEndOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pReviewPrint", _pReviewPrint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPODateOffset", _pPODateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDueDateOffset", _pStartDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDueDateOffset", _pEndDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartOrderDateOffset", _pStartOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndOrderDateOffset", _pEndOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeBlnsWOReleases", _IncludeBlnsWOReleases, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FmSessionId", _FmSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintManufacturerItem", _pPrintManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskID", _TaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintDrawingNumber", _pPrintDrawingNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintDeliveryIncoTerms", _pPrintDeliveryIncoTerms, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintEUCode", _pPrintEUCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintOriginCode", _pPrintOriginCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintCommodityCode", _pPrintCommodityCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintHeaderOnAllPages", _pPrintHeaderOnAllPages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintAuthorizationSignatures", _pPrintAuthorizationSignatures, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintItemOverview", _pPrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProfileExists", _ProfileExists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseProfile", _UseProfile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Method", _Method, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Destination", _Destination, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}

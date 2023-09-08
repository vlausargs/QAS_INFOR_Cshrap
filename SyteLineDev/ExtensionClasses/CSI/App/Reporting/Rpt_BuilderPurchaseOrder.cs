//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BuilderPurchaseOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_BuilderPurchaseOrder
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_BuilderPurchaseOrderSp(Guid? process_id = null,
		string pPoType = null,
		string pPoStat = null,
		string pPoitemStat = null,
		byte? pPostFlag = null,
		DateTime? pPODate = null,
		int? pRoundPlaces = null,
		string pPrintItemVI = null,
		byte? pPrPoTxt = null,
		byte? pPrPoBlnNote = null,
		byte? pPrPoLineNote = null,
		byte? pPrPoBlnDesc = null,
		byte? pPrPoLineDesc = null,
		byte? pPrPONote = null,
		byte? pTransDomCurr = null,
		byte? pPrintEuro = null,
		string pStartBuilderPoNum = null,
		string pEndBuilderPoNum = null,
		short? pStartPoLine = null,
		short? pEndPoLine = null,
		short? pStartPoRElease = null,
		short? pEndPoRelease = null,
		DateTime? pStartDueDate = null,
		DateTime? pEndDueDate = null,
		string pStartvendor = null,
		string pEndVendor = null,
		DateTime? pStartorderDate = null,
		DateTime? pEndOrderDate = null,
		string pReviewPrint = null,
		short? pPODateOffset = null,
		short? pStartDueDateOffset = null,
		short? pEndDueDateOffset = null,
		short? pStartOrderDateOffset = null,
		short? pEndOrderDateOffset = null,
		byte? ShowInternal = (byte)1,
		byte? ShowExternal = (byte)1,
		byte? IncludeBlnsWOReleases = (byte)0,
		string orig_site = null,
		byte? pPrintManufacturerItem = (byte)0,
		string BGSessionId = null,
		string pSite = null);
	}
	
	public class Rpt_BuilderPurchaseOrder : IRpt_BuilderPurchaseOrder
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_BuilderPurchaseOrder(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_BuilderPurchaseOrderSp(Guid? process_id = null,
		string pPoType = null,
		string pPoStat = null,
		string pPoitemStat = null,
		byte? pPostFlag = null,
		DateTime? pPODate = null,
		int? pRoundPlaces = null,
		string pPrintItemVI = null,
		byte? pPrPoTxt = null,
		byte? pPrPoBlnNote = null,
		byte? pPrPoLineNote = null,
		byte? pPrPoBlnDesc = null,
		byte? pPrPoLineDesc = null,
		byte? pPrPONote = null,
		byte? pTransDomCurr = null,
		byte? pPrintEuro = null,
		string pStartBuilderPoNum = null,
		string pEndBuilderPoNum = null,
		short? pStartPoLine = null,
		short? pEndPoLine = null,
		short? pStartPoRElease = null,
		short? pEndPoRelease = null,
		DateTime? pStartDueDate = null,
		DateTime? pEndDueDate = null,
		string pStartvendor = null,
		string pEndVendor = null,
		DateTime? pStartorderDate = null,
		DateTime? pEndOrderDate = null,
		string pReviewPrint = null,
		short? pPODateOffset = null,
		short? pStartDueDateOffset = null,
		short? pEndDueDateOffset = null,
		short? pStartOrderDateOffset = null,
		short? pEndOrderDateOffset = null,
		byte? ShowInternal = (byte)1,
		byte? ShowExternal = (byte)1,
		byte? IncludeBlnsWOReleases = (byte)0,
		string orig_site = null,
		byte? pPrintManufacturerItem = (byte)0,
		string BGSessionId = null,
		string pSite = null)
		{
			RowPointerType _process_id = process_id;
			StringType _pPoType = pPoType;
			StringType _pPoStat = pPoStat;
			StringType _pPoitemStat = pPoitemStat;
			ListYesNoType _pPostFlag = pPostFlag;
			GenericDateType _pPODate = pPODate;
			GenericIntType _pRoundPlaces = pRoundPlaces;
			StringType _pPrintItemVI = pPrintItemVI;
			FlagNyType _pPrPoTxt = pPrPoTxt;
			FlagNyType _pPrPoBlnNote = pPrPoBlnNote;
			FlagNyType _pPrPoLineNote = pPrPoLineNote;
			FlagNyType _pPrPoBlnDesc = pPrPoBlnDesc;
			FlagNyType _pPrPoLineDesc = pPrPoLineDesc;
			FlagNyType _pPrPONote = pPrPONote;
			ListYesNoType _pTransDomCurr = pTransDomCurr;
			ListYesNoType _pPrintEuro = pPrintEuro;
			BuilderPoNumType _pStartBuilderPoNum = pStartBuilderPoNum;
			BuilderPoNumType _pEndBuilderPoNum = pEndBuilderPoNum;
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
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _IncludeBlnsWOReleases = IncludeBlnsWOReleases;
			SiteType _orig_site = orig_site;
			FlagNyType _pPrintManufacturerItem = pPrintManufacturerItem;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_BuilderPurchaseOrderSp";
				
				appDB.AddCommandParameter(cmd, "process_id", _process_id, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "pStartBuilderPoNum", _pStartBuilderPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndBuilderPoNum", _pEndBuilderPoNum, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "orig_site", _orig_site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintManufacturerItem", _pPrintManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}

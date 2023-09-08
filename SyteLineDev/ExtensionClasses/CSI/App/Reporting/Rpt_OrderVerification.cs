//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderVerification.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_OrderVerification
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderVerificationSp(byte? CoTypeRegular = null,
		byte? CoTypeBlanket = null,
        string CoStatus = null,
		string CoLineReleaseStat = null,
		string PrintItemCustItem = null,
		byte? PrintOrderText = null,
		byte? PrintStandardOrderText = null,
		byte? PrintCompanyName = null,
		string DisplayDate = null,
		DateTime? DateToAppear = null,
		short? DateToAppearOffset = null,
		byte? PrintBlanketLineText = null,
		byte? PrintBlanketLineDes = null,
		byte? PrintLineReleaseNotes = null,
		byte? PrintLineReleaseDes = null,
		byte? PrintShipToNotes = null,
		byte? printBillToNotes = null,
		byte? PrintPlanningItemMaterials = null,
		byte? IncludeSerialNumbers = null,
		byte? PrintEuroValue = null,
		byte? PrintPrice = null,
		string Sortby = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string SalespersonStarting = null,
		string SalespersonEnding = null,
		int? OrderLineStarting = null,
		int? OrderReleaseStarting = null,
		int? OrderLineEnding = null,
		int? OrderReleaseEnding = null,
		byte? ShowInternal = null,
		byte? ShowExternal = null,
		byte? PrintItemOverview = null,
		byte? DisplayHeader = null,
		string ConfigDetails = null,
		int? TaskId = null,
		string pSite = null,
		byte? PrintDrawingNumber = null,
		byte? PrintTax = null,
		byte? PrintDeliveryIncoTerms = null,
		byte? PrintEUCode = null,
		byte? PrintOriginCode = null,
		byte? PrintCommodityCode = null,
		byte? PrintCurrencyCode = null,
		byte? PrintHeaderOnAllPages = null,
		byte? PrintEndUserItem = null);
	}
	
	public class Rpt_OrderVerification : IRpt_OrderVerification
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_OrderVerification(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderVerificationSp(byte? CoTypeRegular = null,
		byte? CoTypeBlanket = null,
        string CoStatus = null,
		string CoLineReleaseStat = null,
		string PrintItemCustItem = null,
		byte? PrintOrderText = null,
		byte? PrintStandardOrderText = null,
		byte? PrintCompanyName = null,
		string DisplayDate = null,
		DateTime? DateToAppear = null,
		short? DateToAppearOffset = null,
		byte? PrintBlanketLineText = null,
		byte? PrintBlanketLineDes = null,
		byte? PrintLineReleaseNotes = null,
		byte? PrintLineReleaseDes = null,
		byte? PrintShipToNotes = null,
		byte? printBillToNotes = null,
		byte? PrintPlanningItemMaterials = null,
		byte? IncludeSerialNumbers = null,
		byte? PrintEuroValue = null,
		byte? PrintPrice = null,
		string Sortby = null,
		string OrderStarting = null,
		string OrderEnding = null,
		string SalespersonStarting = null,
		string SalespersonEnding = null,
		int? OrderLineStarting = null,
		int? OrderReleaseStarting = null,
		int? OrderLineEnding = null,
		int? OrderReleaseEnding = null,
		byte? ShowInternal = null,
		byte? ShowExternal = null,
		byte? PrintItemOverview = null,
		byte? DisplayHeader = null,
		string ConfigDetails = null,
		int? TaskId = null,
		string pSite = null,
		byte? PrintDrawingNumber = null,
		byte? PrintTax = null,
		byte? PrintDeliveryIncoTerms = null,
		byte? PrintEUCode = null,
		byte? PrintOriginCode = null,
		byte? PrintCommodityCode = null,
		byte? PrintCurrencyCode = null,
		byte? PrintHeaderOnAllPages = null,
		byte? PrintEndUserItem = null)
		{
			ListYesNoType _CoTypeRegular = CoTypeRegular;
			ListYesNoType _CoTypeBlanket = CoTypeBlanket;
            StringType _CoStatus = CoStatus;
			StringType _CoLineReleaseStat = CoLineReleaseStat;
			StringType _PrintItemCustItem = PrintItemCustItem;
			ListYesNoType _PrintOrderText = PrintOrderText;
			ListYesNoType _PrintStandardOrderText = PrintStandardOrderText;
			ListYesNoType _PrintCompanyName = PrintCompanyName;
			StringType _DisplayDate = DisplayDate;
			DateType _DateToAppear = DateToAppear;
			DateOffsetType _DateToAppearOffset = DateToAppearOffset;
			ListYesNoType _PrintBlanketLineText = PrintBlanketLineText;
			ListYesNoType _PrintBlanketLineDes = PrintBlanketLineDes;
			ListYesNoType _PrintLineReleaseNotes = PrintLineReleaseNotes;
			ListYesNoType _PrintLineReleaseDes = PrintLineReleaseDes;
			ListYesNoType _PrintShipToNotes = PrintShipToNotes;
			ListYesNoType _printBillToNotes = printBillToNotes;
			ListYesNoType _PrintPlanningItemMaterials = PrintPlanningItemMaterials;
			ListYesNoType _IncludeSerialNumbers = IncludeSerialNumbers;
			ListYesNoType _PrintEuroValue = PrintEuroValue;
			ListYesNoType _PrintPrice = PrintPrice;
			StringType _Sortby = Sortby;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			SlsmanType _SalespersonStarting = SalespersonStarting;
			SlsmanType _SalespersonEnding = SalespersonEnding;
			GenericIntType _OrderLineStarting = OrderLineStarting;
			GenericIntType _OrderReleaseStarting = OrderReleaseStarting;
			GenericIntType _OrderLineEnding = OrderLineEnding;
			GenericIntType _OrderReleaseEnding = OrderReleaseEnding;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _ConfigDetails = ConfigDetails;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			ListYesNoType _PrintDrawingNumber = PrintDrawingNumber;
			ListYesNoType _PrintTax = PrintTax;
			ListYesNoType _PrintDeliveryIncoTerms = PrintDeliveryIncoTerms;
			ListYesNoType _PrintEUCode = PrintEUCode;
			ListYesNoType _PrintOriginCode = PrintOriginCode;
			ListYesNoType _PrintCommodityCode = PrintCommodityCode;
			ListYesNoType _PrintCurrencyCode = PrintCurrencyCode;
			ListYesNoType _PrintHeaderOnAllPages = PrintHeaderOnAllPages;
			ListYesNoType _PrintEndUserItem = PrintEndUserItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_OrderVerificationSp";
				
				appDB.AddCommandParameter(cmd, "CoTypeRegular", _CoTypeRegular, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoTypeBlanket", _CoTypeBlanket, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoStatus", _CoStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLineReleaseStat", _CoLineReleaseStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemCustItem", _PrintItemCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderText", _PrintOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintStandardOrderText", _PrintStandardOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCompanyName", _PrintCompanyName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayDate", _DisplayDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateToAppear", _DateToAppear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateToAppearOffset", _DateToAppearOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBlanketLineText", _PrintBlanketLineText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBlanketLineDes", _PrintBlanketLineDes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseNotes", _PrintLineReleaseNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseDes", _PrintLineReleaseDes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintShipToNotes", _PrintShipToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "printBillToNotes", _printBillToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPlanningItemMaterials", _PrintPlanningItemMaterials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeSerialNumbers", _IncludeSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuroValue", _PrintEuroValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sortby", _Sortby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalespersonStarting", _SalespersonStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalespersonEnding", _SalespersonEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineStarting", _OrderLineStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderReleaseStarting", _OrderReleaseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineEnding", _OrderLineEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderReleaseEnding", _OrderReleaseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConfigDetails", _ConfigDetails, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDrawingNumber", _PrintDrawingNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTax", _PrintTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDeliveryIncoTerms", _PrintDeliveryIncoTerms, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEUCode", _PrintEUCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOriginCode", _PrintOriginCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCommodityCode", _PrintCommodityCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCurrencyCode", _PrintCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintHeaderOnAllPages", _PrintHeaderOnAllPages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEndUserItem", _PrintEndUserItem, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}

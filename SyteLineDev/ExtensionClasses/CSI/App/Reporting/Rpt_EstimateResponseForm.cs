//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateResponseForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_EstimateResponseForm
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EstimateResponseFormSp(byte? EstimateText = (byte)1,
		byte? StdOrderText = (byte)1,
		string ConfigDetails = "E",
		string PrintItemType = null,
		byte? PrintLineReleaseText = null,
		byte? PrintBillTo = null,
		byte? PrintShipTo = null,
		byte? PrintPlanningItemMaterials = (byte)1,
		byte? PrintEuroTotal = (byte)0,
		byte? PrintPrice = (byte)0,
		byte? DisplayHeader = (byte)0,
		string EstimateStarting = null,
		string EstimateEnding = null,
		byte? ShowInternal = (byte)1,
		byte? ShowExternal = (byte)1,
		byte? PrintItemOverview = (byte)0,
		byte? PrintDrawingNumber = (byte)0,
		byte? PrintEndUserItem = (byte)0,
		byte? PrintHeaderOnAllPages = (byte)0,
		byte? PrintDueDate = (byte)0,
		byte? PrintProjectedDate = (byte)0,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_EstimateResponseForm : IRpt_EstimateResponseForm
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_EstimateResponseForm(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EstimateResponseFormSp(byte? EstimateText = (byte)1,
		byte? StdOrderText = (byte)1,
		string ConfigDetails = "E",
		string PrintItemType = null,
		byte? PrintLineReleaseText = null,
		byte? PrintBillTo = null,
		byte? PrintShipTo = null,
		byte? PrintPlanningItemMaterials = (byte)1,
		byte? PrintEuroTotal = (byte)0,
		byte? PrintPrice = (byte)0,
		byte? DisplayHeader = (byte)0,
		string EstimateStarting = null,
		string EstimateEnding = null,
		byte? ShowInternal = (byte)1,
		byte? ShowExternal = (byte)1,
		byte? PrintItemOverview = (byte)0,
		byte? PrintDrawingNumber = (byte)0,
		byte? PrintEndUserItem = (byte)0,
		byte? PrintHeaderOnAllPages = (byte)0,
		byte? PrintDueDate = (byte)0,
		byte? PrintProjectedDate = (byte)0,
		string pSite = null,
		string BGUser = null)
		{
			ListYesNoType _EstimateText = EstimateText;
			ListYesNoType _StdOrderText = StdOrderText;
			StringType _ConfigDetails = ConfigDetails;
			StringType _PrintItemType = PrintItemType;
			ListYesNoType _PrintLineReleaseText = PrintLineReleaseText;
			ListYesNoType _PrintBillTo = PrintBillTo;
			ListYesNoType _PrintShipTo = PrintShipTo;
			ListYesNoType _PrintPlanningItemMaterials = PrintPlanningItemMaterials;
			ListYesNoType _PrintEuroTotal = PrintEuroTotal;
			ListYesNoType _PrintPrice = PrintPrice;
			ListYesNoType _DisplayHeader = DisplayHeader;
			CoNumType _EstimateStarting = EstimateStarting;
			CoNumType _EstimateEnding = EstimateEnding;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			FlagNyType _PrintItemOverview = PrintItemOverview;
			ListYesNoType _PrintDrawingNumber = PrintDrawingNumber;
			ListYesNoType _PrintEndUserItem = PrintEndUserItem;
			ListYesNoType _PrintHeaderOnAllPages = PrintHeaderOnAllPages;
			ListYesNoType _PrintDueDate = PrintDueDate;
			ListYesNoType _PrintProjectedDate = PrintProjectedDate;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_EstimateResponseFormSp";
				
				appDB.AddCommandParameter(cmd, "EstimateText", _EstimateText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StdOrderText", _StdOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConfigDetails", _ConfigDetails, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemType", _PrintItemType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseText", _PrintLineReleaseText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBillTo", _PrintBillTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintShipTo", _PrintShipTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPlanningItemMaterials", _PrintPlanningItemMaterials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuroTotal", _PrintEuroTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstimateStarting", _EstimateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstimateEnding", _EstimateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDrawingNumber", _PrintDrawingNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEndUserItem", _PrintEndUserItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintHeaderOnAllPages", _PrintHeaderOnAllPages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDueDate", _PrintDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProjectedDate", _PrintProjectedDate, ParameterDirection.Input);
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

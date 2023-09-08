//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CycleCountSheet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_CycleCountSheet
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CycleCountSheetSp(string CycleType = null,
		string ABCCode = null,
		string SortBy = null,
		byte? PageBreak = (byte)0,
		byte? pr_cut_off_qty = (byte)0,
		string ItemStarting = null,
		string ItemEnding = null,
		string LocStarting = null,
		string LocEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string PlanCodeStarting = null,
		string PlanCodeEnding = null,
		byte? PrintBarcodeFormat = null,
		byte? DisplayHeader = (byte)1,
		string Whse = null,
		byte? PrintPieces = (byte)0,
		string BGSessionId = null,
		string pSite = null);
	}
	
	public class Rpt_CycleCountSheet : IRpt_CycleCountSheet
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CycleCountSheet(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CycleCountSheetSp(string CycleType = null,
		string ABCCode = null,
		string SortBy = null,
		byte? PageBreak = (byte)0,
		byte? pr_cut_off_qty = (byte)0,
		string ItemStarting = null,
		string ItemEnding = null,
		string LocStarting = null,
		string LocEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string PlanCodeStarting = null,
		string PlanCodeEnding = null,
		byte? PrintBarcodeFormat = null,
		byte? DisplayHeader = (byte)1,
		string Whse = null,
		byte? PrintPieces = (byte)0,
		string BGSessionId = null,
		string pSite = null)
		{
			InfobarType _CycleType = CycleType;
			InfobarType _ABCCode = ABCCode;
			InfobarType _SortBy = SortBy;
			ListYesNoType _PageBreak = PageBreak;
			ListYesNoType _pr_cut_off_qty = pr_cut_off_qty;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			LocType _LocStarting = LocStarting;
			LocType _LocEnding = LocEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			UserCodeType _PlanCodeStarting = PlanCodeStarting;
			UserCodeType _PlanCodeEnding = PlanCodeEnding;
			ListYesNoType _PrintBarcodeFormat = PrintBarcodeFormat;
			FlagNyType _DisplayHeader = DisplayHeader;
			WhseType _Whse = Whse;
			ListYesNoType _PrintPieces = PrintPieces;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CycleCountSheetSp";
				
				appDB.AddCommandParameter(cmd, "CycleType", _CycleType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBreak", _PageBreak, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pr_cut_off_qty", _pr_cut_off_qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocStarting", _LocStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocEnding", _LocEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCodeStarting", _PlanCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCodeEnding", _PlanCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBarcodeFormat", _PrintBarcodeFormat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPieces", _PrintPieces, ParameterDirection.Input);
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

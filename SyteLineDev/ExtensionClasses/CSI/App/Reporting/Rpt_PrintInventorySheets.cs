//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintInventorySheets.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PrintInventorySheets : IRpt_PrintInventorySheets
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PrintInventorySheets(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintInventorySheetsSp(string PSessionIDChar = null,
		string Whse = null,
		int? bPrintBlankSheets = null,
		int? bPrintBarcodeFormat = null,
		int? bPrintZeroQty = null,
		string sStartLoc = null,
		string sEndLoc = null,
		string sStartLot = null,
		string sEndLot = null,
		int? sStartSheet = null,
		int? sEndSheet = null,
		int? DisplayHeader = null,
		int? PrintPieces = 0,
		string BGSessionId = null,
		string pSite = null)
		{
			StringType _PSessionIDChar = PSessionIDChar;
			WhseType _Whse = Whse;
			ListYesNoType _bPrintBlankSheets = bPrintBlankSheets;
			ListYesNoType _bPrintBarcodeFormat = bPrintBarcodeFormat;
			ListYesNoType _bPrintZeroQty = bPrintZeroQty;
			LocType _sStartLoc = sStartLoc;
			LocType _sEndLoc = sEndLoc;
			LotType _sStartLot = sStartLot;
			LotType _sEndLot = sEndLot;
			SheetTagNumType _sStartSheet = sStartSheet;
			SheetTagNumType _sEndSheet = sEndSheet;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PrintPieces = PrintPieces;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PrintInventorySheetsSp";
				
				appDB.AddCommandParameter(cmd, "PSessionIDChar", _PSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPrintBlankSheets", _bPrintBlankSheets, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPrintBarcodeFormat", _bPrintBarcodeFormat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPrintZeroQty", _bPrintZeroQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sStartLoc", _sStartLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sEndLoc", _sEndLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sStartLot", _sStartLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sEndLot", _sEndLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sStartSheet", _sStartSheet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sEndSheet", _sEndSheet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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

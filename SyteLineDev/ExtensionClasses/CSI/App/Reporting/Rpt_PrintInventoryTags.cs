//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintInventoryTags.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PrintInventoryTags : IRpt_PrintInventoryTags
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PrintInventoryTags(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintInventoryTagsSp(string PSessionIDChar = null,
		string Whse = null,
		int? bPrintBlankTags = null,
		int? bPrintBarcodeFormat = null,
		int? bPrintZeroQty = null,
		string sStartLoc = null,
		string sEndLoc = null,
		string sStartLot = null,
		string sEndLot = null,
		int? sStartTag = null,
		int? sEndTag = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null)
		{
			StringType _PSessionIDChar = PSessionIDChar;
			WhseType _Whse = Whse;
			ListYesNoType _bPrintBlankTags = bPrintBlankTags;
			ListYesNoType _bPrintBarcodeFormat = bPrintBarcodeFormat;
			ListYesNoType _bPrintZeroQty = bPrintZeroQty;
			LocType _sStartLoc = sStartLoc;
			LocType _sEndLoc = sEndLoc;
			LotType _sStartLot = sStartLot;
			LotType _sEndLot = sEndLot;
			SheetTagNumType _sStartTag = sStartTag;
			SheetTagNumType _sEndTag = sEndTag;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PrintInventoryTagsSp";
				
				appDB.AddCommandParameter(cmd, "PSessionIDChar", _PSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPrintBlankTags", _bPrintBlankTags, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPrintBarcodeFormat", _bPrintBarcodeFormat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPrintZeroQty", _bPrintZeroQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sStartLoc", _sStartLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sEndLoc", _sEndLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sStartLot", _sStartLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sEndLot", _sEndLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sStartTag", _sStartTag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sEndTag", _sEndTag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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

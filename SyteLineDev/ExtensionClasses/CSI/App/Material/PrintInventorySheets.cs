//PROJECT NAME: Material
//CLASS NAME: PrintInventorySheets.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PrintInventorySheets : IPrintInventorySheets
	{
		readonly IApplicationDB appDB;
		
		public PrintInventorySheets(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PrintInventorySheetsSp(
			string Whse,
			int? bPrintBlankSheets,
			int? bPRintBarcodeFormat,
			int? bPrintZeroQty,
			string sStartLoc,
			string sEndLoc,
			string sStartLot,
			string sEndLot,
			int? sStartSheet,
			int? sEndSheet,
			string Infobar)
		{
			WhseType _Whse = Whse;
			ListYesNoType _bPrintBlankSheets = bPrintBlankSheets;
			ListYesNoType _bPRintBarcodeFormat = bPRintBarcodeFormat;
			ListYesNoType _bPrintZeroQty = bPrintZeroQty;
			LocType _sStartLoc = sStartLoc;
			LocType _sEndLoc = sEndLoc;
			LotType _sStartLot = sStartLot;
			LotType _sEndLot = sEndLot;
			SheetTagNumType _sStartSheet = sStartSheet;
			SheetTagNumType _sEndSheet = sEndSheet;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrintInventorySheetsSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPrintBlankSheets", _bPrintBlankSheets, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPRintBarcodeFormat", _bPRintBarcodeFormat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPrintZeroQty", _bPrintZeroQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sStartLoc", _sStartLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sEndLoc", _sEndLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sStartLot", _sStartLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sEndLot", _sEndLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sStartSheet", _sStartSheet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sEndSheet", _sEndSheet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

//PROJECT NAME: CSIMaterial
//CLASS NAME: SelectInventorySheets.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface ISelectInventorySheets
	{
		int SelectInventorySheetsSp(Guid? PSessionID,
		                            string Whse,
		                            byte? bPrintBlankSheets,
		                            byte? bPrintBarcodeFormat,
		                            byte? bPrintZeroQty,
		                            string sStartLoc,
		                            string sEndLoc,
		                            string sStartLot,
		                            string sEndLot,
		                            int? sStartSheet,
		                            int? sEndSheet,
		                            ref int? PNumSheets);
	}
	
	public class SelectInventorySheets : ISelectInventorySheets
	{
		readonly IApplicationDB appDB;
		
		public SelectInventorySheets(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SelectInventorySheetsSp(Guid? PSessionID,
		                                   string Whse,
		                                   byte? bPrintBlankSheets,
		                                   byte? bPrintBarcodeFormat,
		                                   byte? bPrintZeroQty,
		                                   string sStartLoc,
		                                   string sEndLoc,
		                                   string sStartLot,
		                                   string sEndLot,
		                                   int? sStartSheet,
		                                   int? sEndSheet,
		                                   ref int? PNumSheets)
		{
			RowPointer _PSessionID = PSessionID;
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
			IntType _PNumSheets = PNumSheets;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SelectInventorySheetsSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "PNumSheets", _PNumSheets, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PNumSheets = _PNumSheets;
				
				return Severity;
			}
		}
	}
}

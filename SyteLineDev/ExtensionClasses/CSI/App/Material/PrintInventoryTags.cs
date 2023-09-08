//PROJECT NAME: Material
//CLASS NAME: PrintInventoryTags.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PrintInventoryTags : IPrintInventoryTags
	{
		readonly IApplicationDB appDB;
		
		public PrintInventoryTags(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PrintInventoryTagsSp(
			string Whse,
			int? bPrintBlankTags,
			int? bPRintBarcodeFormat,
			int? bPrintZeroQty,
			string sStartLoc,
			string sEndLoc,
			string sStartLot,
			string sEndLot,
			int? sStartTag,
			int? sEndTag,
			string Infobar)
		{
			WhseType _Whse = Whse;
			ListYesNoType _bPrintBlankTags = bPrintBlankTags;
			ListYesNoType _bPRintBarcodeFormat = bPRintBarcodeFormat;
			ListYesNoType _bPrintZeroQty = bPrintZeroQty;
			LocType _sStartLoc = sStartLoc;
			LocType _sEndLoc = sEndLoc;
			LotType _sStartLot = sStartLot;
			LotType _sEndLot = sEndLot;
			SheetTagNumType _sStartTag = sStartTag;
			SheetTagNumType _sEndTag = sEndTag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrintInventoryTagsSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPrintBlankTags", _bPrintBlankTags, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPRintBarcodeFormat", _bPRintBarcodeFormat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bPrintZeroQty", _bPrintZeroQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sStartLoc", _sStartLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sEndLoc", _sEndLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sStartLot", _sStartLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sEndLot", _sEndLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sStartTag", _sStartTag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sEndTag", _sEndTag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

//PROJECT NAME: CSIMaterial
//CLASS NAME: SelectInventoryTags.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface ISelectInventoryTags
	{
		int SelectInventoryTagsSp(Guid? PSessionID,
		                          string Whse,
		                          byte? bPrintBlankTags,
		                          byte? bPRintBarcodeFormat,
		                          byte? bPrintZeroQty,
		                          string sStartLoc,
		                          string sEndLoc,
		                          string sStartLot,
		                          string sEndLot,
		                          int? sStartTag,
		                          int? sEndTag);
	}
	
	public class SelectInventoryTags : ISelectInventoryTags
	{
		readonly IApplicationDB appDB;
		
		public SelectInventoryTags(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SelectInventoryTagsSp(Guid? PSessionID,
		                                 string Whse,
		                                 byte? bPrintBlankTags,
		                                 byte? bPRintBarcodeFormat,
		                                 byte? bPrintZeroQty,
		                                 string sStartLoc,
		                                 string sEndLoc,
		                                 string sStartLot,
		                                 string sEndLot,
		                                 int? sStartTag,
		                                 int? sEndTag)
		{
			RowPointer _PSessionID = PSessionID;
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
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SelectInventoryTagsSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
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
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}

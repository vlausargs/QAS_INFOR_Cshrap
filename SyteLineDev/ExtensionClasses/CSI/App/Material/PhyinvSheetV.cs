//PROJECT NAME: Material
//CLASS NAME: PhyinvSheetV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PhyinvSheetV : IPhyinvSheetV
	{
		readonly IApplicationDB appDB;
		
		
		public PhyinvSheetV(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? TagXref,
		string Infobar) PhyinvSheetVSp(string Whse,
		string Item,
		string Loc,
		string Lot,
		string SerNum,
		int? LotTracked,
		int? SerialTracked,
		int? SheetNum,
		int? NewSheet,
		int? TagXref,
		string Infobar,
		string ImportDocId,
		int? TaxFreeMatl)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			SerNumType _SerNum = SerNum;
			ListYesNoType _LotTracked = LotTracked;
			ListYesNoType _SerialTracked = SerialTracked;
			SheetTagNumType _SheetNum = SheetNum;
			ListYesNoType _NewSheet = NewSheet;
			SheetTagNumType _TagXref = TagXref;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _TaxFreeMatl = TaxFreeMatl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PhyinvSheetVSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SheetNum", _SheetNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewSheet", _NewSheet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TagXref", _TagXref, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxFreeMatl", _TaxFreeMatl, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TagXref = _TagXref;
				Infobar = _Infobar;
				
				return (Severity, TagXref, Infobar);
			}
		}
	}
}

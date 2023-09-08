//PROJECT NAME: CSIMaterial
//CLASS NAME: ChgReplaceTag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IChgReplaceTag
	{
		int ChgReplaceTagSp(string Whse,
		                    int? TagXref,
		                    int? CurTag,
		                    ref int? Tag,
		                    ref string Item,
		                    ref string Loc,
		                    ref string Lot,
		                    ref string SerNum,
		                    ref int? SheetNum,
		                    ref decimal? CountQty,
		                    ref string PostStat,
		                    ref string DerPostStat,
		                    ref byte? Approved,
		                    ref string CntStat,
		                    ref string PhyType,
		                    ref string Stat,
		                    ref byte? LotTracked,
		                    ref byte? SerialTracked,
		                    ref byte? LotEnable,
		                    ref byte? SerialEnable,
		                    ref string Infobar,
		                    string ImportDocId,
		                    ref byte? TaxFreeMatl);
	}
	
	public class ChgReplaceTag : IChgReplaceTag
	{
		readonly IApplicationDB appDB;
		
		public ChgReplaceTag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ChgReplaceTagSp(string Whse,
		                           int? TagXref,
		                           int? CurTag,
		                           ref int? Tag,
		                           ref string Item,
		                           ref string Loc,
		                           ref string Lot,
		                           ref string SerNum,
		                           ref int? SheetNum,
		                           ref decimal? CountQty,
		                           ref string PostStat,
		                           ref string DerPostStat,
		                           ref byte? Approved,
		                           ref string CntStat,
		                           ref string PhyType,
		                           ref string Stat,
		                           ref byte? LotTracked,
		                           ref byte? SerialTracked,
		                           ref byte? LotEnable,
		                           ref byte? SerialEnable,
		                           ref string Infobar,
		                           string ImportDocId,
		                           ref byte? TaxFreeMatl)
		{
			WhseType _Whse = Whse;
			SheetTagNumType _TagXref = TagXref;
			SheetTagNumType _CurTag = CurTag;
			SheetTagNumType _Tag = Tag;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			SerNumType _SerNum = SerNum;
			SheetTagNumType _SheetNum = SheetNum;
			QtyUnitNoNegType _CountQty = CountQty;
			PhyinvPostStatusType _PostStat = PostStat;
			PhyinvPostStatusType _DerPostStat = DerPostStat;
			ListYesNoType _Approved = Approved;
			PhyinvCntStatusType _CntStat = CntStat;
			PhyinvTypeType _PhyType = PhyType;
			PhyinvStatusType _Stat = Stat;
			ListYesNoType _LotTracked = LotTracked;
			ListYesNoType _SerialTracked = SerialTracked;
			ListYesNoType _LotEnable = LotEnable;
			ListYesNoType _SerialEnable = SerialEnable;
			Infobar _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _TaxFreeMatl = TaxFreeMatl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChgReplaceTagSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TagXref", _TagXref, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurTag", _CurTag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Tag", _Tag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SheetNum", _SheetNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CountQty", _CountQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostStat", _PostStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DerPostStat", _DerPostStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Approved", _Approved, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CntStat", _CntStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PhyType", _PhyType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotEnable", _LotEnable, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialEnable", _SerialEnable, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxFreeMatl", _TaxFreeMatl, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Tag = _Tag;
				Item = _Item;
				Loc = _Loc;
				Lot = _Lot;
				SerNum = _SerNum;
				SheetNum = _SheetNum;
				CountQty = _CountQty;
				PostStat = _PostStat;
				DerPostStat = _DerPostStat;
				Approved = _Approved;
				CntStat = _CntStat;
				PhyType = _PhyType;
				Stat = _Stat;
				LotTracked = _LotTracked;
				SerialTracked = _SerialTracked;
				LotEnable = _LotEnable;
				SerialEnable = _SerialEnable;
				Infobar = _Infobar;
				TaxFreeMatl = _TaxFreeMatl;
				
				return Severity;
			}
		}
	}
}

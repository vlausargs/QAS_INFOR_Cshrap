//PROJECT NAME: Data
//CLASS NAME: ItemQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemQty : IItemQty
	{
		readonly IApplicationDB appDB;
		
		public ItemQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ItemQtySp(
			string TransType,
			string WhseType,
			string Whse,
			string Item,
			decimal? DeltaQty,
			string Loc,
			string Lot = null,
			decimal? UnitCost = null,
			decimal? MatlCost = null,
			decimal? LbrCost = null,
			decimal? FovhdCost = null,
			decimal? VovhdCost = null,
			decimal? OutCost = null,
			int? MrbFlag = 0,
			string TrnNum = null,
			int? TrnLine = null,
			decimal? TransNum = null,
			decimal? RsvdNum = null,
			string InSerialStat = "I",
			int? AllQtys = 1,
			string Workkey = null,
			string Infobar = null,
			string ImportDocId = null,
			int? UpdateTaxFreeImportQty = 1,
			int? ValidateImportDocId = 1,
			string ContainerNum = null)
		{
			StringType _TransType = TransType;
			StringType _WhseType = WhseType;
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			QtyUnitType _DeltaQty = DeltaQty;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			CostPrcType _UnitCost = UnitCost;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			ListYesNoType _MrbFlag = MrbFlag;
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			HugeTransNumType _TransNum = TransNum;
			RsvdNumType _RsvdNum = RsvdNum;
			SerialStatusType _InSerialStat = InSerialStat;
			IntType _AllQtys = AllQtys;
			RefStrType _Workkey = Workkey;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			FlagNyType _UpdateTaxFreeImportQty = UpdateTaxFreeImportQty;
			FlagNyType _ValidateImportDocId = ValidateImportDocId;
			ContainerNumType _ContainerNum = ContainerNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemQtySp";
				
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseType", _WhseType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeltaQty", _DeltaQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrbFlag", _MrbFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RsvdNum", _RsvdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSerialStat", _InSerialStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllQtys", _AllQtys, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Workkey", _Workkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateTaxFreeImportQty", _UpdateTaxFreeImportQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ValidateImportDocId", _ValidateImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

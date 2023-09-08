//PROJECT NAME: Data
//CLASS NAME: ItemWhseCostsIup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemWhseCostsIup : IItemWhseCostsIup
	{
		readonly IApplicationDB appDB;
		
		public ItemWhseCostsIup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ItemWhseCostsIupSp(
			string Item,
			string ItemUtil,
			int? InsertFlag,
			int? NewLotTracked,
			int? MatltranAvail,
			decimal? QtyOnHand,
			decimal? QtyMrb,
			Guid? RowPointer,
			string OldCostMethod,
			string NewCostMethod,
			string OldCostType,
			string NewCostType,
			string OldPMTCode,
			string NewPMTCode,
			string OldMatlType,
			string NewMatlType,
			string Infobar)
		{
			ItemType _Item = Item;
			ShortDescType _ItemUtil = ItemUtil;
			ListYesNoType _InsertFlag = InsertFlag;
			ListYesNoType _NewLotTracked = NewLotTracked;
			ListYesNoType _MatltranAvail = MatltranAvail;
			QtyTotlType _QtyOnHand = QtyOnHand;
			QtyTotlType _QtyMrb = QtyMrb;
			RowPointerType _RowPointer = RowPointer;
			CostMethodType _OldCostMethod = OldCostMethod;
			CostMethodType _NewCostMethod = NewCostMethod;
			CostTypeType _OldCostType = OldCostType;
			CostTypeType _NewCostType = NewCostType;
			PMTCodeType _OldPMTCode = OldPMTCode;
			PMTCodeType _NewPMTCode = NewPMTCode;
			MatlTypeType _OldMatlType = OldMatlType;
			MatlTypeType _NewMatlType = NewMatlType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemWhseCostsIupSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemUtil", _ItemUtil, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsertFlag", _InsertFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewLotTracked", _NewLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranAvail", _MatltranAvail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyMrb", _QtyMrb, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCostMethod", _OldCostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewCostMethod", _NewCostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCostType", _OldCostType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewCostType", _NewCostType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldPMTCode", _OldPMTCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewPMTCode", _NewPMTCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldMatlType", _OldMatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewMatlType", _NewMatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

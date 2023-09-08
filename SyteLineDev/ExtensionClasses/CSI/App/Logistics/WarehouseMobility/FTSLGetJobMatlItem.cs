//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetJobMatlItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetJobMatlItem
	{
		(int? ReturnCode, string item_UM,
		string item_Description,
		byte? ItemNotExists,
		double? UMConvFactor,
		byte? JobmatlNotExists,
		decimal? item_MatlCost,
		decimal? item_MatlCostConv,
		byte? item_SerialTracked,
		byte? item_LotTracked,
		decimal? ReqQty,
		decimal? ReqQtyConv,
		decimal? QtyIssued,
		decimal? QtyIssuedConv,
		string Infobar) FTSLGetJobMatlItemSp(string Item = null,
		string UM = null,
		string Job = null,
		short? Suffix = null,
		int? OperNum = null,
		short? Sequence = null,
		byte? ExtByScrap = null,
		string item_UM = null,
		string item_Description = null,
		byte? ItemNotExists = null,
		double? UMConvFactor = null,
		byte? JobmatlNotExists = null,
		decimal? item_MatlCost = null,
		decimal? item_MatlCostConv = null,
		byte? item_SerialTracked = null,
		byte? item_LotTracked = null,
		decimal? ReqQty = null,
		decimal? ReqQtyConv = null,
		decimal? QtyIssued = null,
		decimal? QtyIssuedConv = null,
		string Infobar = null);
	}
	
	public class FTSLGetJobMatlItem : IFTSLGetJobMatlItem
	{
		readonly IApplicationDB appDB;
		
		public FTSLGetJobMatlItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string item_UM,
		string item_Description,
		byte? ItemNotExists,
		double? UMConvFactor,
		byte? JobmatlNotExists,
		decimal? item_MatlCost,
		decimal? item_MatlCostConv,
		byte? item_SerialTracked,
		byte? item_LotTracked,
		decimal? ReqQty,
		decimal? ReqQtyConv,
		decimal? QtyIssued,
		decimal? QtyIssuedConv,
		string Infobar) FTSLGetJobMatlItemSp(string Item = null,
		string UM = null,
		string Job = null,
		short? Suffix = null,
		int? OperNum = null,
		short? Sequence = null,
		byte? ExtByScrap = null,
		string item_UM = null,
		string item_Description = null,
		byte? ItemNotExists = null,
		double? UMConvFactor = null,
		byte? JobmatlNotExists = null,
		decimal? item_MatlCost = null,
		decimal? item_MatlCostConv = null,
		byte? item_SerialTracked = null,
		byte? item_LotTracked = null,
		decimal? ReqQty = null,
		decimal? ReqQtyConv = null,
		decimal? QtyIssued = null,
		decimal? QtyIssuedConv = null,
		string Infobar = null)
		{
			ItemType _Item = Item;
			UMType _UM = UM;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			JobmatlSequenceType _Sequence = Sequence;
			ListYesNoType _ExtByScrap = ExtByScrap;
			UMType _item_UM = item_UM;
			DescriptionType _item_Description = item_Description;
			ListYesNoType _ItemNotExists = ItemNotExists;
			UMConvFactorType _UMConvFactor = UMConvFactor;
			ListYesNoType _JobmatlNotExists = JobmatlNotExists;
			CostPrcType _item_MatlCost = item_MatlCost;
			CostPrcType _item_MatlCostConv = item_MatlCostConv;
			ListYesNoType _item_SerialTracked = item_SerialTracked;
			ListYesNoType _item_LotTracked = item_LotTracked;
			QtyTotlType _ReqQty = ReqQty;
			QtyTotlType _ReqQtyConv = ReqQtyConv;
			QtyPerType _QtyIssued = QtyIssued;
			QtyPerType _QtyIssuedConv = QtyIssuedConv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLGetJobMatlItemSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtByScrap", _ExtByScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "item_UM", _item_UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "item_Description", _item_Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemNotExists", _ItemNotExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UMConvFactor", _UMConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlNotExists", _JobmatlNotExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "item_MatlCost", _item_MatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "item_MatlCostConv", _item_MatlCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "item_SerialTracked", _item_SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "item_LotTracked", _item_LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReqQty", _ReqQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReqQtyConv", _ReqQtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyIssued", _QtyIssued, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyIssuedConv", _QtyIssuedConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				item_UM = _item_UM;
				item_Description = _item_Description;
				ItemNotExists = _ItemNotExists;
				UMConvFactor = _UMConvFactor;
				JobmatlNotExists = _JobmatlNotExists;
				item_MatlCost = _item_MatlCost;
				item_MatlCostConv = _item_MatlCostConv;
				item_SerialTracked = _item_SerialTracked;
				item_LotTracked = _item_LotTracked;
				ReqQty = _ReqQty;
				ReqQtyConv = _ReqQtyConv;
				QtyIssued = _QtyIssued;
				QtyIssuedConv = _QtyIssuedConv;
				Infobar = _Infobar;
				
				return (Severity, item_UM, item_Description, ItemNotExists, UMConvFactor, JobmatlNotExists, item_MatlCost, item_MatlCostConv, item_SerialTracked, item_LotTracked, ReqQty, ReqQtyConv, QtyIssued, QtyIssuedConv, Infobar);
			}
		}
	}
}

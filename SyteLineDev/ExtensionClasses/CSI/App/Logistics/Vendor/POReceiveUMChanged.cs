//PROJECT NAME: CSIVendor
//CLASS NAME: POReceiveUMChanged.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPOReceiveUMChanged
	{
		int POReceiveUMChangedSp(ref decimal? UnitMatCostConv,
		                         ref decimal? UnitBrokerageCostConv,
		                         ref decimal? UnitDutyCostConv,
		                         ref decimal? UnitFreightCostConv,
		                         ref decimal? ItemCostConv,
		                         ref decimal? QtyOrdered,
		                         ref decimal? QtyReceived,
		                         ref decimal? QtyRejected,
		                         string Item,
		                         string OldUM,
		                         string NewUM,
		                         string VendNum,
		                         ref string Infobar);
	}
	
	public class POReceiveUMChanged : IPOReceiveUMChanged
	{
		readonly IApplicationDB appDB;
		
		public POReceiveUMChanged(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int POReceiveUMChangedSp(ref decimal? UnitMatCostConv,
		                                ref decimal? UnitBrokerageCostConv,
		                                ref decimal? UnitDutyCostConv,
		                                ref decimal? UnitFreightCostConv,
		                                ref decimal? ItemCostConv,
		                                ref decimal? QtyOrdered,
		                                ref decimal? QtyReceived,
		                                ref decimal? QtyRejected,
		                                string Item,
		                                string OldUM,
		                                string NewUM,
		                                string VendNum,
		                                ref string Infobar)
		{
			CostPrcType _UnitMatCostConv = UnitMatCostConv;
			CostPrcType _UnitBrokerageCostConv = UnitBrokerageCostConv;
			CostPrcType _UnitDutyCostConv = UnitDutyCostConv;
			CostPrcType _UnitFreightCostConv = UnitFreightCostConv;
			CostPrcType _ItemCostConv = ItemCostConv;
			QtyUnitNoNegType _QtyOrdered = QtyOrdered;
			QtyUnitNoNegType _QtyReceived = QtyReceived;
			QtyUnitNoNegType _QtyRejected = QtyRejected;
			ItemType _Item = Item;
			UMType _OldUM = OldUM;
			UMType _NewUM = NewUM;
			VendNumType _VendNum = VendNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POReceiveUMChangedSp";
				
				appDB.AddCommandParameter(cmd, "UnitMatCostConv", _UnitMatCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCostConv", _UnitBrokerageCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitDutyCostConv", _UnitDutyCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitFreightCostConv", _UnitFreightCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCostConv", _ItemCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyReceived", _QtyReceived, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyRejected", _QtyRejected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldUM", _OldUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewUM", _NewUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UnitMatCostConv = _UnitMatCostConv;
				UnitBrokerageCostConv = _UnitBrokerageCostConv;
				UnitDutyCostConv = _UnitDutyCostConv;
				UnitFreightCostConv = _UnitFreightCostConv;
				ItemCostConv = _ItemCostConv;
				QtyOrdered = _QtyOrdered;
				QtyReceived = _QtyReceived;
				QtyRejected = _QtyRejected;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}

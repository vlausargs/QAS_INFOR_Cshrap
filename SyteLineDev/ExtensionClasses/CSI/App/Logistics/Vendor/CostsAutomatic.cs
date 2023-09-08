//PROJECT NAME: Logistics
//CLASS NAME: CostsAutomatic.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CostsAutomatic : ICostsAutomatic
	{
		readonly IApplicationDB appDB;
		
		
		public CostsAutomatic(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? TcCprMatCostConv,
		decimal? TcCprBrokerageCostConv,
		decimal? TcCprDutyCostConv,
		decimal? TcCprFreightCostConv,
		decimal? TcCprInsuranceCostConv,
		decimal? TcCprLocFrtCostConv,
		string Infobar) CostsAutomaticSp(string NewPoItem,
		string Whse,
		string PVendNum,
		decimal? InPoQty,
		string PUM,
		DateTime? EffectiveDate,
		decimal? TcCprMatCostConv,
		decimal? TcCprBrokerageCostConv,
		decimal? TcCprDutyCostConv,
		decimal? TcCprFreightCostConv,
		decimal? TcCprInsuranceCostConv,
		decimal? TcCprLocFrtCostConv,
		string Infobar)
		{
			ItemType _NewPoItem = NewPoItem;
			WhseType _Whse = Whse;
			VendNumType _PVendNum = PVendNum;
			QtyTotlNoNegType _InPoQty = InPoQty;
			UMType _PUM = PUM;
			DateType _EffectiveDate = EffectiveDate;
			CostPrcType _TcCprMatCostConv = TcCprMatCostConv;
			CostPrcType _TcCprBrokerageCostConv = TcCprBrokerageCostConv;
			CostPrcType _TcCprDutyCostConv = TcCprDutyCostConv;
			CostPrcType _TcCprFreightCostConv = TcCprFreightCostConv;
			CostPrcType _TcCprInsuranceCostConv = TcCprInsuranceCostConv;
			CostPrcType _TcCprLocFrtCostConv = TcCprLocFrtCostConv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CostsAutomaticSp";
				
				appDB.AddCommandParameter(cmd, "NewPoItem", _NewPoItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InPoQty", _InPoQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcCprMatCostConv", _TcCprMatCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcCprBrokerageCostConv", _TcCprBrokerageCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcCprDutyCostConv", _TcCprDutyCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcCprFreightCostConv", _TcCprFreightCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcCprInsuranceCostConv", _TcCprInsuranceCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcCprLocFrtCostConv", _TcCprLocFrtCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TcCprMatCostConv = _TcCprMatCostConv;
				TcCprBrokerageCostConv = _TcCprBrokerageCostConv;
				TcCprDutyCostConv = _TcCprDutyCostConv;
				TcCprFreightCostConv = _TcCprFreightCostConv;
				TcCprInsuranceCostConv = _TcCprInsuranceCostConv;
				TcCprLocFrtCostConv = _TcCprLocFrtCostConv;
				Infobar = _Infobar;
				
				return (Severity, TcCprMatCostConv, TcCprBrokerageCostConv, TcCprDutyCostConv, TcCprFreightCostConv, TcCprInsuranceCostConv, TcCprLocFrtCostConv, Infobar);
			}
		}
	}
}

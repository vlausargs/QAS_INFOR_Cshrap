//PROJECT NAME: Logistics
//CLASS NAME: ICostsAutomatic.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICostsAutomatic
	{
		(int? ReturnCode, decimal? TcCprMatCostConv,
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
		string Infobar);
	}
}


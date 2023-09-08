//PROJECT NAME: Material
//CLASS NAME: MsmpPmu.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MsmpPmu : IMsmpPmu
	{
		readonly IApplicationDB appDB;
		
		public MsmpPmu(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? ProfitMarkup,
			string Infobar) MsmpPmuSp(
			string Item,
			DateTime? EffDate,
			string Pricecode,
			decimal? QtyMoved,
			decimal? TotalCost,
			decimal? TotalOrderedQty,
			decimal? ProfitMarkup,
			string Infobar,
			string FromSite = null,
			string ToSite = null,
			decimal? TransferExchRate = null)
		{
			ItemType _Item = Item;
			DateType _EffDate = EffDate;
			PriceCodeType _Pricecode = Pricecode;
			QtyTotlType _QtyMoved = QtyMoved;
			CostPrcType _TotalCost = TotalCost;
			QtyTotlType _TotalOrderedQty = TotalOrderedQty;
			CostPrcType _ProfitMarkup = ProfitMarkup;
			InfobarType _Infobar = Infobar;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			ExchRateType _TransferExchRate = TransferExchRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MsmpPmuSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffDate", _EffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyMoved", _QtyMoved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalCost", _TotalCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalOrderedQty", _TotalOrderedQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProfitMarkup", _ProfitMarkup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferExchRate", _TransferExchRate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProfitMarkup = _ProfitMarkup;
				Infobar = _Infobar;
				
				return (Severity, ProfitMarkup, Infobar);
			}
		}
	}
}

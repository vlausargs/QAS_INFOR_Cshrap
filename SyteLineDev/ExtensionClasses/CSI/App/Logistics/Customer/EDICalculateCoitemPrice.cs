//PROJECT NAME: Logistics
//CLASS NAME: EDICalculateCoitemPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EDICalculateCoitemPrice : IEDICalculateCoitemPrice
	{
		readonly IApplicationDB appDB;
		
		
		public EDICalculateCoitemPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PriceConv,
		string Infobar) EDICalculateCoitemPriceSp(string CoNum,
		string CustNum,
		string Item,
		string UM,
		DateTime? EffDate,
		DateTime? ExpDate,
		decimal? QtyConv,
		string CurrCode,
		string PriceCode,
		decimal? PriceConv,
		string Infobar,
		string ItemWhse = null)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			UMType _UM = UM;
			DateType _EffDate = EffDate;
			DateType _ExpDate = ExpDate;
			QtyUnitType _QtyConv = QtyConv;
			CurrCodeType _CurrCode = CurrCode;
			PriceCodeType _PriceCode = PriceCode;
			AmountType _PriceConv = PriceConv;
			Infobar _Infobar = Infobar;
			WhseType _ItemWhse = ItemWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EDICalculateCoitemPriceSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffDate", _EffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpDate", _ExpDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceCode", _PriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemWhse", _ItemWhse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PriceConv = _PriceConv;
				Infobar = _Infobar;
				
				return (Severity, PriceConv, Infobar);
			}
		}
	}
}

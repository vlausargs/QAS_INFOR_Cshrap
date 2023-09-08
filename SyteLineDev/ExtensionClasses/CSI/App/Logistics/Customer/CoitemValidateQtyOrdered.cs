//PROJECT NAME: Logistics
//CLASS NAME: CoitemValidateQtyOrdered.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemValidateQtyOrdered : ICoitemValidateQtyOrdered
	{
		readonly IApplicationDB appDB;
		
		
		public CoitemValidateQtyOrdered(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? QtyReady,
		string Infobar,
		int? DispMsg) CoitemValidateQtyOrderedSp(int? NewRecord,
		string CoNum,
		int? CoLine,
		string Item,
		string UM,
		string CoCustNum,
		string CurrCode,
		string ItemPriceCode,
		decimal? QtyOrderedConv,
		string CustItem,
		string ShipSite,
		DateTime? CoOrderDate,
		string Whse,
		string RefType,
		decimal? Price,
		decimal? QtyReady,
		string Infobar,
		int? DispMsg = 0)
		{
			Flag _NewRecord = NewRecord;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			ItemType _Item = Item;
			UMType _UM = UM;
			CustNumType _CoCustNum = CoCustNum;
			CurrCodeType _CurrCode = CurrCode;
			PriceCodeType _ItemPriceCode = ItemPriceCode;
			QtyUnitType _QtyOrderedConv = QtyOrderedConv;
			ItemType _CustItem = CustItem;
			SiteType _ShipSite = ShipSite;
			GenericDateType _CoOrderDate = CoOrderDate;
			WhseType _Whse = Whse;
			RefTypeIJKPRTType _RefType = RefType;
			AmountType _Price = Price;
			QtyUnitNoNegType _QtyReady = QtyReady;
			InfobarType _Infobar = Infobar;
			ListYesNoType _DispMsg = DispMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemValidateQtyOrderedSp";
				
				appDB.AddCommandParameter(cmd, "NewRecord", _NewRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPriceCode", _ItemPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoOrderDate", _CoOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReady", _QtyReady, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DispMsg", _DispMsg, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyReady = _QtyReady;
				Infobar = _Infobar;
				DispMsg = _DispMsg;
				
				return (Severity, QtyReady, Infobar, DispMsg);
			}
		}
	}
}

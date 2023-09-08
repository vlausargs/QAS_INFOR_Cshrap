//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCoitemValidateQtyOrdered.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IEdiCoitemValidateQtyOrdered
	{
		(int? ReturnCode, decimal? PriceConv, string Infobar) EdiCoitemValidateQtyOrderedSp(byte? NewRecord,
		string CoNum,
		short? CoLine,
		string Item,
		string UM,
		string CustNum,
		string CurrCode,
		string ItemPriceCode,
		decimal? QtyOrderedConv,
		string CustItem,
		DateTime? OrderDate,
		decimal? PriceConv,
		string Infobar,
		string ItemWhse = null);
	}
	
	public class EdiCoitemValidateQtyOrdered : IEdiCoitemValidateQtyOrdered
	{
		readonly IApplicationDB appDB;
		
		public EdiCoitemValidateQtyOrdered(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PriceConv, string Infobar) EdiCoitemValidateQtyOrderedSp(byte? NewRecord,
		string CoNum,
		short? CoLine,
		string Item,
		string UM,
		string CustNum,
		string CurrCode,
		string ItemPriceCode,
		decimal? QtyOrderedConv,
		string CustItem,
		DateTime? OrderDate,
		decimal? PriceConv,
		string Infobar,
		string ItemWhse = null)
		{
			Flag _NewRecord = NewRecord;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			ItemType _Item = Item;
			UMType _UM = UM;
			CustNumType _CustNum = CustNum;
			CurrCodeType _CurrCode = CurrCode;
			PriceCodeType _ItemPriceCode = ItemPriceCode;
			QtyUnitType _QtyOrderedConv = QtyOrderedConv;
			ItemType _CustItem = CustItem;
			GenericDateType _OrderDate = OrderDate;
			AmountType _PriceConv = PriceConv;
			InfobarType _Infobar = Infobar;
			WhseType _ItemWhse = ItemWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiCoitemValidateQtyOrderedSp";
				
				appDB.AddCommandParameter(cmd, "NewRecord", _NewRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPriceCode", _ItemPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDate", _OrderDate, ParameterDirection.Input);
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

//PROJECT NAME: Data
//CLASS NAME: InventoryConstoCustOrderLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InventoryConstoCustOrderLine : IInventoryConstoCustOrderLine
	{
		readonly IApplicationDB appDB;
		
		public InventoryConstoCustOrderLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			Guid? RowPointer,
			string Infobar) InventoryConstoCustOrderLineSp(
			string pCoNum,
			int? pCoLine,
			string pStat,
			string pItem,
			decimal? pQtyOrderedConv,
			string pUM,
			string CoCustNum,
			int? CoCustSeq,
			string CoShipFromSite = null,
			decimal? ItemPriceConv = null,
			decimal? ItemPrice = null,
			DateTime? ColProjectedDate = null,
			DateTime? ColDueDate = null,
			DateTime? ColPromiseDate = null,
			Guid? RowPointer = null,
			string Infobar = null)
		{
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			StringType _pStat = pStat;
			ItemType _pItem = pItem;
			QtyPerType _pQtyOrderedConv = pQtyOrderedConv;
			UMType _pUM = pUM;
			CustNumType _CoCustNum = CoCustNum;
			CustSeqType _CoCustSeq = CoCustSeq;
			SiteType _CoShipFromSite = CoShipFromSite;
			AmountType _ItemPriceConv = ItemPriceConv;
			AmountType _ItemPrice = ItemPrice;
			DateType _ColProjectedDate = ColProjectedDate;
			DateType _ColDueDate = ColDueDate;
			DateType _ColPromiseDate = ColPromiseDate;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InventoryConstoCustOrderLineSp";
				
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStat", _pStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQtyOrderedConv", _pQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUM", _pUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustSeq", _CoCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoShipFromSite", _CoShipFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPriceConv", _ItemPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPrice", _ItemPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColProjectedDate", _ColProjectedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColDueDate", _ColDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColPromiseDate", _ColPromiseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RowPointer = _RowPointer;
				Infobar = _Infobar;
				
				return (Severity, RowPointer, Infobar);
			}
		}
	}
}

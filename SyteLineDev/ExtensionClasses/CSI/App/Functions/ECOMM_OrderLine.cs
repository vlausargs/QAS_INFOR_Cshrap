//PROJECT NAME: Data
//CLASS NAME: ECOMM_OrderLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ECOMM_OrderLine : IECOMM_OrderLine
	{
		readonly IApplicationDB appDB;
		
		public ECOMM_OrderLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? ErrorOccured,
			string Infobar) ECOMM_OrderLineSp(
			string OrdNumber,
			int? SequenceNumber,
			string ItemID,
			decimal? OrderQty,
			decimal? Cost,
			decimal? ActualSellPrice,
			DateTime? DueDate,
			string WarehouseID,
			string UnitOfMeasure,
			string ItemDescription1,
			string Comment,
			int? ErrorOccured,
			string Infobar)
		{
			CoNumType _OrdNumber = OrdNumber;
			CoLineType _SequenceNumber = SequenceNumber;
			ItemType _ItemID = ItemID;
			QtyUnitType _OrderQty = OrderQty;
			CostPrcType _Cost = Cost;
			CostPrcType _ActualSellPrice = ActualSellPrice;
			DateType _DueDate = DueDate;
			WhseType _WarehouseID = WarehouseID;
			UMType _UnitOfMeasure = UnitOfMeasure;
			DescriptionType _ItemDescription1 = ItemDescription1;
			OleObjectType _Comment = Comment;
			ListYesNoType _ErrorOccured = ErrorOccured;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ECOMM_OrderLineSp";
				
				appDB.AddCommandParameter(cmd, "OrdNumber", _OrdNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SequenceNumber", _SequenceNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemID", _ItemID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderQty", _OrderQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cost", _Cost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActualSellPrice", _ActualSellPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarehouseID", _WarehouseID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitOfMeasure", _UnitOfMeasure, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDescription1", _ItemDescription1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Comment", _Comment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorOccured", _ErrorOccured, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ErrorOccured = _ErrorOccured;
				Infobar = _Infobar;
				
				return (Severity, ErrorOccured, Infobar);
			}
		}
	}
}

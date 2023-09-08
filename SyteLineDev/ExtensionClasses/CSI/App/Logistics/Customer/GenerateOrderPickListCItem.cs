//PROJECT NAME: Logistics
//CLASS NAME: GenerateOrderPickListCItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateOrderPickListCItem : IGenerateOrderPickListCItem
	{
		readonly IApplicationDB appDB;
		
		public GenerateOrderPickListCItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GenerateOrderPickListCItemSp(
			Guid? PSessionID,
			int? PCoitemCoLine,
			string PCoitemCoNum,
			int? PCoitemCoRelease,
			string PCoitemItem,
			decimal? PCoitemQtyOrdered,
			decimal? PCoitemQtyShipped,
			string PCoitemWhse,
			Guid? PCoitemRowPointer,
			int? PItemLotTracked,
			string PItemUM,
			string PItemlocLoc,
			Guid? PItemlocRowPointer,
			int? PListByLoc,
			string PLotLocLot,
			Guid? PLotLocRowPointer,
			string Infobar)
		{
			RowPointerType _PSessionID = PSessionID;
			CoLineType _PCoitemCoLine = PCoitemCoLine;
			CoNumType _PCoitemCoNum = PCoitemCoNum;
			CoReleaseType _PCoitemCoRelease = PCoitemCoRelease;
			ItemType _PCoitemItem = PCoitemItem;
			QtyUnitType _PCoitemQtyOrdered = PCoitemQtyOrdered;
			QtyUnitType _PCoitemQtyShipped = PCoitemQtyShipped;
			WhseType _PCoitemWhse = PCoitemWhse;
			RowPointerType _PCoitemRowPointer = PCoitemRowPointer;
			ListYesNoType _PItemLotTracked = PItemLotTracked;
			UMType _PItemUM = PItemUM;
			LocType _PItemlocLoc = PItemlocLoc;
			RowPointerType _PItemlocRowPointer = PItemlocRowPointer;
			ListYesNoType _PListByLoc = PListByLoc;
			LotType _PLotLocLot = PLotLocLot;
			RowPointerType _PLotLocRowPointer = PLotLocRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateOrderPickListCItemSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoLine", _PCoitemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoNum", _PCoitemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoRelease", _PCoitemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemItem", _PCoitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemQtyOrdered", _PCoitemQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemQtyShipped", _PCoitemQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemWhse", _PCoitemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemRowPointer", _PCoitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemLotTracked", _PItemLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemUM", _PItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemlocLoc", _PItemlocLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemlocRowPointer", _PItemlocRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PListByLoc", _PListByLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLotLocLot", _PLotLocLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLotLocRowPointer", _PLotLocRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

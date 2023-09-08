//PROJECT NAME: Logistics
//CLASS NAME: GenerateOrderPickListDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateOrderPickListDetail : IGenerateOrderPickListDetail
	{
		readonly IApplicationDB appDB;
		
		public GenerateOrderPickListDetail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PRsvdInvQtyRsvd,
			Guid? PRsvdInvRowPointer,
			decimal? PRsvdInvRsvdNum,
			Guid? PItemlocRowPointer,
			Guid? PLotLocRowPointer,
			int? PTMoreResv,
			string PSLoc,
			string PSLot,
			decimal? PSQty,
			decimal? PTcQtudOnHand,
			decimal? PTcQtuRequired,
			decimal? PTcQtuRsvdQty,
			decimal? PTcQtuShort,
			string InfoBar) GenerateOrderPickListDetailSp(
			int? PCoitemCoLine,
			string PCoitemCoNum,
			int? PCoitemCoRelease,
			string PCoitemItem,
			string PCoitemWhse,
			string PItemIssueBy,
			string PItemItem,
			int? PItemLotTracked,
			int? PItemSerialTracked,
			int? PItemTaxFreeMatl,
			string PItemlocLoc,
			decimal? PItemlocQtyOnHand,
			decimal? PItemlocQtyRsvd,
			string PLotLocLot,
			decimal? PLotLocQtyOnHand,
			decimal? PLotLocQtyRsvd,
			decimal? PRsvdInvQtyRsvd,
			Guid? PRsvdInvRowPointer,
			decimal? PRsvdInvRsvdNum,
			Guid? PSessionId,
			DateTime? PTransDate,
			int? PTRsvdFlg,
			int? PPostMatlIssues,
			Guid? PItemlocRowPointer,
			Guid? PLotLocRowPointer,
			int? PTMoreResv,
			string PSLoc,
			string PSLot,
			decimal? PSQty,
			decimal? PTcQtudOnHand,
			decimal? PTcQtuRequired,
			decimal? PTcQtuRsvdQty,
			decimal? PTcQtuShort,
			string InfoBar)
		{
			CoLineType _PCoitemCoLine = PCoitemCoLine;
			CoNumType _PCoitemCoNum = PCoitemCoNum;
			CoReleaseType _PCoitemCoRelease = PCoitemCoRelease;
			ItemType _PCoitemItem = PCoitemItem;
			WhseType _PCoitemWhse = PCoitemWhse;
			ListLocLotType _PItemIssueBy = PItemIssueBy;
			ItemType _PItemItem = PItemItem;
			ListYesNoType _PItemLotTracked = PItemLotTracked;
			ListYesNoType _PItemSerialTracked = PItemSerialTracked;
			ListYesNoType _PItemTaxFreeMatl = PItemTaxFreeMatl;
			LocType _PItemlocLoc = PItemlocLoc;
			QtyUnitType _PItemlocQtyOnHand = PItemlocQtyOnHand;
			QtyUnitType _PItemlocQtyRsvd = PItemlocQtyRsvd;
			LotType _PLotLocLot = PLotLocLot;
			QtyUnitType _PLotLocQtyOnHand = PLotLocQtyOnHand;
			QtyUnitType _PLotLocQtyRsvd = PLotLocQtyRsvd;
			QtyUnitNoNegType _PRsvdInvQtyRsvd = PRsvdInvQtyRsvd;
			RowPointerType _PRsvdInvRowPointer = PRsvdInvRowPointer;
			RsvdNumType _PRsvdInvRsvdNum = PRsvdInvRsvdNum;
			RowPointerType _PSessionId = PSessionId;
			DateType _PTransDate = PTransDate;
			ListYesNoType _PTRsvdFlg = PTRsvdFlg;
			ListYesNoType _PPostMatlIssues = PPostMatlIssues;
			RowPointerType _PItemlocRowPointer = PItemlocRowPointer;
			RowPointerType _PLotLocRowPointer = PLotLocRowPointer;
			ListYesNoType _PTMoreResv = PTMoreResv;
			LocType _PSLoc = PSLoc;
			LotType _PSLot = PSLot;
			QtyUnitType _PSQty = PSQty;
			QtyUnitType _PTcQtudOnHand = PTcQtudOnHand;
			QtyUnitNoNegType _PTcQtuRequired = PTcQtuRequired;
			QtyUnitNoNegType _PTcQtuRsvdQty = PTcQtuRsvdQty;
			QtyUnitNoNegType _PTcQtuShort = PTcQtuShort;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateOrderPickListDetailSp";
				
				appDB.AddCommandParameter(cmd, "PCoitemCoLine", _PCoitemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoNum", _PCoitemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoRelease", _PCoitemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemItem", _PCoitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemWhse", _PCoitemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemIssueBy", _PItemIssueBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemItem", _PItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemLotTracked", _PItemLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemSerialTracked", _PItemSerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemTaxFreeMatl", _PItemTaxFreeMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemlocLoc", _PItemlocLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemlocQtyOnHand", _PItemlocQtyOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemlocQtyRsvd", _PItemlocQtyRsvd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLotLocLot", _PLotLocLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLotLocQtyOnHand", _PLotLocQtyOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLotLocQtyRsvd", _PLotLocQtyRsvd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRsvdInvQtyRsvd", _PRsvdInvQtyRsvd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRsvdInvRowPointer", _PRsvdInvRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRsvdInvRsvdNum", _PRsvdInvRsvdNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTRsvdFlg", _PTRsvdFlg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostMatlIssues", _PPostMatlIssues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemlocRowPointer", _PItemlocRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLotLocRowPointer", _PLotLocRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTMoreResv", _PTMoreResv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSLoc", _PSLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSLot", _PSLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSQty", _PSQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTcQtudOnHand", _PTcQtudOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTcQtuRequired", _PTcQtuRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTcQtuRsvdQty", _PTcQtuRsvdQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTcQtuShort", _PTcQtuShort, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PRsvdInvQtyRsvd = _PRsvdInvQtyRsvd;
				PRsvdInvRowPointer = _PRsvdInvRowPointer;
				PRsvdInvRsvdNum = _PRsvdInvRsvdNum;
				PItemlocRowPointer = _PItemlocRowPointer;
				PLotLocRowPointer = _PLotLocRowPointer;
				PTMoreResv = _PTMoreResv;
				PSLoc = _PSLoc;
				PSLot = _PSLot;
				PSQty = _PSQty;
				PTcQtudOnHand = _PTcQtudOnHand;
				PTcQtuRequired = _PTcQtuRequired;
				PTcQtuRsvdQty = _PTcQtuRsvdQty;
				PTcQtuShort = _PTcQtuShort;
				InfoBar = _InfoBar;
				
				return (Severity, PRsvdInvQtyRsvd, PRsvdInvRowPointer, PRsvdInvRsvdNum, PItemlocRowPointer, PLotLocRowPointer, PTMoreResv, PSLoc, PSLot, PSQty, PTcQtudOnHand, PTcQtuRequired, PTcQtuRsvdQty, PTcQtuShort, InfoBar);
			}
		}
	}
}

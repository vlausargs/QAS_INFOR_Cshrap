//PROJECT NAME: Logistics
//CLASS NAME: GenerateOrderPickListLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateOrderPickListLoc : IGenerateOrderPickListLoc
	{
		readonly IApplicationDB appDB;
		
		public GenerateOrderPickListLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PItemlocLoc,
			decimal? PItemlocQtyOnHand,
			decimal? PItemlocQtyRsvd,
			Guid? PItemlocRowPointer,
			string PLotLocLot,
			decimal? PLotLocQtyOnHand,
			decimal? PLotLocQtyRsvd,
			Guid? PLotLocRowPointer,
			Guid? PLotRowPointer,
			decimal? PRsvdInvQtyRsvd,
			Guid? PRsvdInvRowPointer,
			decimal? PRsvdInvRsvdNum,
			int? PTMoreResv,
			int? PTRsvdFlg) GenerateOrderPickListLocSp(
			int? PCoitemCoLine,
			string PCoitemCoNum,
			int? PCoitemCoRelease,
			string PCoitemItem,
			string PCoitemWhse,
			string PItemIssueBy,
			int? PItemLotTracked,
			int? PPostMatlIssues,
			string PItemlocLoc,
			decimal? PItemlocQtyOnHand,
			decimal? PItemlocQtyRsvd,
			Guid? PItemlocRowPointer,
			string PLotLocLot,
			decimal? PLotLocQtyOnHand,
			decimal? PLotLocQtyRsvd,
			Guid? PLotLocRowPointer,
			Guid? PLotRowPointer,
			decimal? PRsvdInvQtyRsvd,
			Guid? PRsvdInvRowPointer,
			decimal? PRsvdInvRsvdNum,
			int? PTMoreResv,
			int? PTRsvdFlg)
		{
			CoLineType _PCoitemCoLine = PCoitemCoLine;
			CoNumType _PCoitemCoNum = PCoitemCoNum;
			CoReleaseType _PCoitemCoRelease = PCoitemCoRelease;
			ItemType _PCoitemItem = PCoitemItem;
			WhseType _PCoitemWhse = PCoitemWhse;
			ListLocLotType _PItemIssueBy = PItemIssueBy;
			ListYesNoType _PItemLotTracked = PItemLotTracked;
			ListYesNoType _PPostMatlIssues = PPostMatlIssues;
			LocType _PItemlocLoc = PItemlocLoc;
			QtyUnitType _PItemlocQtyOnHand = PItemlocQtyOnHand;
			QtyUnitType _PItemlocQtyRsvd = PItemlocQtyRsvd;
			RowPointerType _PItemlocRowPointer = PItemlocRowPointer;
			LotType _PLotLocLot = PLotLocLot;
			QtyUnitType _PLotLocQtyOnHand = PLotLocQtyOnHand;
			QtyUnitType _PLotLocQtyRsvd = PLotLocQtyRsvd;
			RowPointerType _PLotLocRowPointer = PLotLocRowPointer;
			RowPointerType _PLotRowPointer = PLotRowPointer;
			QtyUnitType _PRsvdInvQtyRsvd = PRsvdInvQtyRsvd;
			RowPointerType _PRsvdInvRowPointer = PRsvdInvRowPointer;
			RsvdNumType _PRsvdInvRsvdNum = PRsvdInvRsvdNum;
			ListYesNoType _PTMoreResv = PTMoreResv;
			ListYesNoType _PTRsvdFlg = PTRsvdFlg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateOrderPickListLocSp";
				
				appDB.AddCommandParameter(cmd, "PCoitemCoLine", _PCoitemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoNum", _PCoitemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoRelease", _PCoitemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemItem", _PCoitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemWhse", _PCoitemWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemIssueBy", _PItemIssueBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemLotTracked", _PItemLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostMatlIssues", _PPostMatlIssues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemlocLoc", _PItemlocLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemlocQtyOnHand", _PItemlocQtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemlocQtyRsvd", _PItemlocQtyRsvd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemlocRowPointer", _PItemlocRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLotLocLot", _PLotLocLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLotLocQtyOnHand", _PLotLocQtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLotLocQtyRsvd", _PLotLocQtyRsvd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLotLocRowPointer", _PLotLocRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLotRowPointer", _PLotRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRsvdInvQtyRsvd", _PRsvdInvQtyRsvd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRsvdInvRowPointer", _PRsvdInvRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRsvdInvRsvdNum", _PRsvdInvRsvdNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTMoreResv", _PTMoreResv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTRsvdFlg", _PTRsvdFlg, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PItemlocLoc = _PItemlocLoc;
				PItemlocQtyOnHand = _PItemlocQtyOnHand;
				PItemlocQtyRsvd = _PItemlocQtyRsvd;
				PItemlocRowPointer = _PItemlocRowPointer;
				PLotLocLot = _PLotLocLot;
				PLotLocQtyOnHand = _PLotLocQtyOnHand;
				PLotLocQtyRsvd = _PLotLocQtyRsvd;
				PLotLocRowPointer = _PLotLocRowPointer;
				PLotRowPointer = _PLotRowPointer;
				PRsvdInvQtyRsvd = _PRsvdInvQtyRsvd;
				PRsvdInvRowPointer = _PRsvdInvRowPointer;
				PRsvdInvRsvdNum = _PRsvdInvRsvdNum;
				PTMoreResv = _PTMoreResv;
				PTRsvdFlg = _PTRsvdFlg;
				
				return (Severity, PItemlocLoc, PItemlocQtyOnHand, PItemlocQtyRsvd, PItemlocRowPointer, PLotLocLot, PLotLocQtyOnHand, PLotLocQtyRsvd, PLotLocRowPointer, PLotRowPointer, PRsvdInvQtyRsvd, PRsvdInvRowPointer, PRsvdInvRsvdNum, PTMoreResv, PTRsvdFlg);
			}
		}
	}
}

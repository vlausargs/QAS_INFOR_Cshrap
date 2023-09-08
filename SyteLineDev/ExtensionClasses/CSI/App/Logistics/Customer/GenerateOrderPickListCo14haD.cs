//PROJECT NAME: Logistics
//CLASS NAME: GenerateOrderPickListCo14haD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateOrderPickListCo14haD : IGenerateOrderPickListCo14haD
	{
		readonly IApplicationDB appDB;
		
		public GenerateOrderPickListCo14haD(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GenerateOrderPickListCo14haDSp(
			int? PBarLoc,
			int? PPostMatlIssues,
			int? PPrintBc,
			string PPrItemCi,
			int? PPrPlanItemMatl,
			int? PPrSerialNumbers,
			string PTtCoitem_Pickwarn,
			int? PCoitemCoLine,
			string PCoitemCoNum,
			int? PCoitemCoRelease,
			string PCoitemCustItem,
			DateTime? PCoitemDueDate,
			string PCoitemFeatStr,
			string PCoItemItem,
			DateTime? PCoitemPickDate,
			decimal? PCoitemQtyOrdered,
			Guid? PCoitemRowPointer,
			string PDescription,
			int? PCoitemNoteExistsFlag,
			string PManufacturerId,
			string PManufacturerItem,
			DateTime? PCoOrderDate,
			Guid? PCoRowPointer,
			string PInvparmsFbomBlank,
			string PInvparmsFeatTempl,
			int? PCoparmsPickwarnCo,
			string PItemFeatTempl,
			string PItemJob,
			int? PItemLotTracked,
			int? PItemPlanFlag,
			Guid? PItemRowPointer,
			int? PItemSerialTracked,
			int? PItemSuffix,
			string PItemUM,
			Guid? PSessionId,
			string PSWorkkey,
			string PSLoc,
			string PSLot,
			decimal? PTcQtudOnHand1,
			decimal? PTcQtuRequired1,
			decimal? PTcQtuRsvdQty1,
			decimal? PTcQtuShort1,
			decimal? PTcQtuSQty1,
			Guid? PItemlocRowPointer,
			Guid? PLotLocRowPointer,
			int? PFirstLoc,
			string Infobar)
		{
			ListYesNoType _PBarLoc = PBarLoc;
			ListYesNoType _PPostMatlIssues = PPostMatlIssues;
			ListYesNoType _PPrintBc = PPrintBc;
			StringType _PPrItemCi = PPrItemCi;
			ListYesNoType _PPrPlanItemMatl = PPrPlanItemMatl;
			ListYesNoType _PPrSerialNumbers = PPrSerialNumbers;
			LongListType _PTtCoitem_Pickwarn = PTtCoitem_Pickwarn;
			CoLineType _PCoitemCoLine = PCoitemCoLine;
			CoNumType _PCoitemCoNum = PCoitemCoNum;
			CoReleaseType _PCoitemCoRelease = PCoitemCoRelease;
			CustItemType _PCoitemCustItem = PCoitemCustItem;
			DateType _PCoitemDueDate = PCoitemDueDate;
			FeatStrType _PCoitemFeatStr = PCoitemFeatStr;
			ItemType _PCoItemItem = PCoItemItem;
			DateType _PCoitemPickDate = PCoitemPickDate;
			QtyUnitNoNegType _PCoitemQtyOrdered = PCoitemQtyOrdered;
			RowPointerType _PCoitemRowPointer = PCoitemRowPointer;
			DescriptionType _PDescription = PDescription;
			FlagNyType _PCoitemNoteExistsFlag = PCoitemNoteExistsFlag;
			ManufacturerIdType _PManufacturerId = PManufacturerId;
			ManufacturerItemType _PManufacturerItem = PManufacturerItem;
			DateType _PCoOrderDate = PCoOrderDate;
			RowPointerType _PCoRowPointer = PCoRowPointer;
			FeatBlankType _PInvparmsFbomBlank = PInvparmsFbomBlank;
			FeatTemplateType _PInvparmsFeatTempl = PInvparmsFeatTempl;
			ListYesNoType _PCoparmsPickwarnCo = PCoparmsPickwarnCo;
			FeatTemplateType _PItemFeatTempl = PItemFeatTempl;
			JobType _PItemJob = PItemJob;
			ListYesNoType _PItemLotTracked = PItemLotTracked;
			ListYesNoType _PItemPlanFlag = PItemPlanFlag;
			RowPointerType _PItemRowPointer = PItemRowPointer;
			ListYesNoType _PItemSerialTracked = PItemSerialTracked;
			SuffixType _PItemSuffix = PItemSuffix;
			UMType _PItemUM = PItemUM;
			RowPointerType _PSessionId = PSessionId;
			LongListType _PSWorkkey = PSWorkkey;
			LocType _PSLoc = PSLoc;
			LotType _PSLot = PSLot;
			QtyUnitType _PTcQtudOnHand1 = PTcQtudOnHand1;
			QtyUnitNoNegType _PTcQtuRequired1 = PTcQtuRequired1;
			QtyUnitNoNegType _PTcQtuRsvdQty1 = PTcQtuRsvdQty1;
			QtyUnitNoNegType _PTcQtuShort1 = PTcQtuShort1;
			QtyUnitType _PTcQtuSQty1 = PTcQtuSQty1;
			RowPointerType _PItemlocRowPointer = PItemlocRowPointer;
			RowPointerType _PLotLocRowPointer = PLotLocRowPointer;
			FlagNyType _PFirstLoc = PFirstLoc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateOrderPickListCo14haDSp";
				
				appDB.AddCommandParameter(cmd, "PBarLoc", _PBarLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostMatlIssues", _PPostMatlIssues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrintBc", _PPrintBc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrItemCi", _PPrItemCi, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrPlanItemMatl", _PPrPlanItemMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrSerialNumbers", _PPrSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTtCoitem_Pickwarn", _PTtCoitem_Pickwarn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoLine", _PCoitemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoNum", _PCoitemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCoRelease", _PCoitemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemCustItem", _PCoitemCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemDueDate", _PCoitemDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemFeatStr", _PCoitemFeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoItemItem", _PCoItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemPickDate", _PCoitemPickDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemQtyOrdered", _PCoitemQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemRowPointer", _PCoitemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDescription", _PDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoitemNoteExistsFlag", _PCoitemNoteExistsFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PManufacturerId", _PManufacturerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PManufacturerItem", _PManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoOrderDate", _PCoOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRowPointer", _PCoRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvparmsFbomBlank", _PInvparmsFbomBlank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvparmsFeatTempl", _PInvparmsFeatTempl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoparmsPickwarnCo", _PCoparmsPickwarnCo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemFeatTempl", _PItemFeatTempl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemJob", _PItemJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemLotTracked", _PItemLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemPlanFlag", _PItemPlanFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemRowPointer", _PItemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemSerialTracked", _PItemSerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemSuffix", _PItemSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemUM", _PItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSWorkkey", _PSWorkkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSLoc", _PSLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSLot", _PSLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcQtudOnHand1", _PTcQtudOnHand1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcQtuRequired1", _PTcQtuRequired1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcQtuRsvdQty1", _PTcQtuRsvdQty1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcQtuShort1", _PTcQtuShort1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcQtuSQty1", _PTcQtuSQty1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemlocRowPointer", _PItemlocRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLotLocRowPointer", _PLotLocRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFirstLoc", _PFirstLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}

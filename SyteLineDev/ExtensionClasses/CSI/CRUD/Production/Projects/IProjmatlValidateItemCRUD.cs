//PROJECT NAME: Production
//CLASS NAME: IProjmatlValidateItemCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjmatlValidateItemCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(int? CostItemAtWhse, int? rowCount) Dbo_InvparmsLoad(int? CostItemAtWhse);
		(Guid? ItemRowPointer,
			 string TItem,
			 string TItemDesc,
			 int? TSerTracked,
			 int? TLotTracked,
			 string ItemUM,
			 decimal? ItemUnitCost,
			 decimal? ItemCurUCost,
			 string ItemCostType,
			 string ItemCostMethod,
			 string ItemProductCode,
			 int? TTaxFreeMatl,
			 int? TTrackPieces,
			 string TDimensionGroup,
			 int? ItemTrackECN,
			 string Revision, int? rowCount) ItemLoad(string Item, string Whse, string TItem, string TItemDesc, int? TSerTracked, int? TLotTracked, int? TTaxFreeMatl, int? TTrackPieces, string TDimensionGroup, int? ItemTrackECN, string Revision, Guid? ItemRowPointer, string ItemUM, decimal? ItemUnitCost, decimal? ItemCurUCost, string ItemCostType, string ItemProductCode, string ItemCostMethod);
		(Guid? ItemRowPointer,
			 string TItem,
			 string TItemDesc,
			 int? TSerTracked,
			 int? TLotTracked,
			 string ItemUM,
			 decimal? ItemUnitCost,
			 decimal? ItemCurUCost,
			 string ItemCostType,
			 string ItemCostMethod,
			 string ItemProductCode,
			 int? TTaxFreeMatl,
			 int? TTrackPieces,
			 string TDimensionGroup,
			 int? ItemTrackECN,
			 string Revision, int? rowCount) Item1Load(string Item, string TItem, string TItemDesc, int? TSerTracked, int? TLotTracked, int? TTaxFreeMatl, int? TTrackPieces, string TDimensionGroup, int? ItemTrackECN, string Revision, Guid? ItemRowPointer, string ItemUM, decimal? ItemUnitCost, decimal? ItemCurUCost, string ItemCostType, string ItemProductCode, string ItemCostMethod);
		(string TItem, string TItemDesc, string ItemProductCode, string ItemUM, decimal? ItemUnitCost, decimal? ItemCurUCost, int? rowCount) Non_Inventory_ItemLoad(string Item, string TItem, string TItemDesc, string ItemUM, decimal? ItemUnitCost, decimal? ItemCurUCost, string ItemProductCode);
		(Guid? ProjmatlRowPointer,
			 int? ProjmatlSeq,
			 string ProjmatlCostCode,
			 decimal? ProjmatlCost,
			 string ProjmatlRefType,
			 string ProjmatlRefNum,
			 int? ProjmatlRefLineSuf, int? rowCount) ProjmatlLoad(string Item, string ProjNum, int? TaskNum, int? SeqNum, Guid? ProjmatlRowPointer, int? ProjmatlSeq, string ProjmatlCostCode, decimal? ProjmatlCost, string ProjmatlRefType, string ProjmatlRefNum, int? ProjmatlRefLineSuf);
		(Guid? ProjmatlRowPointer,
			 int? ProjmatlSeq,
			 string ProjmatlCostCode,
			 decimal? ProjmatlCost,
			 string ProjmatlRefType,
			 string ProjmatlRefNum,
			 int? ProjmatlRefLineSuf, int? rowCount) Projmatl1Load(string Item, string ProjNum, int? TaskNum, Guid? ProjmatlRowPointer, int? ProjmatlSeq, string ProjmatlCostCode, decimal? ProjmatlCost, string ProjmatlRefType, string ProjmatlRefNum, int? ProjmatlRefLineSuf);
		bool JobForExists(string ProjmatlRefNum, int? ProjmatlRefLineSuf);
		(Guid? ProdcodeRowPointer, string ProdcodeCostCode, int? rowCount) ProdcodeLoad(string ItemProductCode, Guid? ProdcodeRowPointer, string ProdcodeCostCode);
		(Guid? ItemwhseRowPointer, int? ItemwhseCntInProc, int? rowCount) ItemwhseLoad(string Item, string Whse, Guid? ItemwhseRowPointer, int? ItemwhseCntInProc);
		(decimal? ItemlocQtyOnHand, int? rowCount) ItemlocLoad(string Item, string Whse, string TLoc, decimal? ItemlocQtyOnHand);
		(string TNonInvAcct, int? rowCount) ApparmsLoad(string TNonInvAcct);
		bool Projmatl2ForExists(string Item, string ProjNum, int? TaskNum, int? SeqNum);
		(string TItemDesc, int? rowCount) Dbo_ProjmatlaspLoad(string Item, string ProjNum, int? TaskNum, int? SeqNum, string TItemDesc);
		(string TItemDesc, int? rowCount) Dbo_Projmatlasp1Load(string Item, string ProjNum, int? TaskNum, string TItemDesc);
		(decimal? TQtyShipped, int? rowCount) Dbo_Projmatlasp2Load(string Item, string ProjNum, int? TaskNum, int? TSeqNum, decimal? TQtyShipped);
		ICollectionLoadResponse ChartSelect(string TNonInvAcct);
		(int? ReturnCode, string TItem,int? TSeqNum,string TItemDesc,int? TSerTracked,int? TLotTracked,string TNonInvAcct,decimal? TNonInvCost,string TCostCode,string TLoc,string TLot,decimal? TRequired,decimal? TIssued,decimal? TOnHand,string TUM,decimal? UomConvFactor,decimal? TRequiredConv,decimal? TIssuedConv,decimal? TOnHandConv,decimal? TQty,decimal? TQtyConv,int? ItemAvailable,string PromptMsg1,string PromptButtons1,string PromptMsg2,string PromptButtons2,string Infobar,string TImportDocId,int? TTaxFreeMatl,int? TTrackPieces,string TDimensionGroup,decimal? TQtyShipped,int? IsControl,int? ItemTrackECN,string Revision) AltExtGen_ProjmatlValidateItemSp(string AltExtGenSp, string Item, string ProjNum, int? TaskNum, int? SeqNum, string Whse, string TItem, int? TSeqNum, string TItemDesc, int? TSerTracked, int? TLotTracked, string TNonInvAcct, decimal? TNonInvCost, string TCostCode, string TLoc, string TLot, decimal? TRequired, decimal? TIssued, decimal? TOnHand, string TUM, decimal? UomConvFactor, decimal? TRequiredConv, decimal? TIssuedConv, decimal? TOnHandConv, decimal? TQty, decimal? TQtyConv, int? ItemAvailable, string PromptMsg1, string PromptButtons1, string PromptMsg2, string PromptButtons2, string Infobar, string TImportDocId, int? TTaxFreeMatl, int? TTrackPieces, string TDimensionGroup, decimal? TQtyShipped, int? IsControl, int? ItemTrackECN, string Revision);
	}
}


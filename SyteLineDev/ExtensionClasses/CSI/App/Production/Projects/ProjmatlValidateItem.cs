//PROJECT NAME: Production
//CLASS NAME: ProjmatlValidateItem.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;
using System.Linq;
using CSI.Material;
using CSI.Logistics.Customer;
using CSI.DataCollection;

namespace CSI.Production.Projects
{
	public class ProjmatlValidateItem : IProjmatlValidateItem
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IPmatlSumMaterial iPmatlSumMaterial;
		readonly IShipLocDefault iShipLocDefault;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IUomConvAmt iUomConvAmt;
		readonly IUomConvQty iUomConvQty;
		readonly IStringUtil stringUtil;
		readonly IObsSlow iObsSlow;
		readonly IGetumcf iGetumcf;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly IMsgAsk iMsgAsk;
		readonly IMinQty iMinQty;
		readonly IMaxQty iMaxQty;
		readonly IProjmatlValidateItemCRUD iProjmatlValidateItemCRUD;
		
		public ProjmatlValidateItem(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IPmatlSumMaterial iPmatlSumMaterial,
			IShipLocDefault iShipLocDefault,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IUomConvAmt iUomConvAmt,
			IUomConvQty iUomConvQty,
			IStringUtil stringUtil,
			IObsSlow iObsSlow,
			IGetumcf iGetumcf,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			IMsgAsk iMsgAsk,
			IMinQty iMinQty,
			IMaxQty iMaxQty,
			IProjmatlValidateItemCRUD iProjmatlValidateItemCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iPmatlSumMaterial = iPmatlSumMaterial;
			this.iShipLocDefault = iShipLocDefault;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.iUomConvAmt = iUomConvAmt;
			this.iUomConvQty = iUomConvQty;
			this.stringUtil = stringUtil;
			this.iObsSlow = iObsSlow;
			this.iGetumcf = iGetumcf;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iMsgAsk = iMsgAsk;
			this.iMinQty = iMinQty;
			this.iMaxQty = iMaxQty;
			this.iProjmatlValidateItemCRUD = iProjmatlValidateItemCRUD;
		}
		
		public (
			int? ReturnCode,
			string TItem,
			int? TSeqNum,
			string TItemDesc,
			int? TSerTracked,
			int? TLotTracked,
			string TNonInvAcct,
			decimal? TNonInvCost,
			string TCostCode,
			string TLoc,
			string TLot,
			decimal? TRequired,
			decimal? TIssued,
			decimal? TOnHand,
			string TUM,
			decimal? UomConvFactor,
			decimal? TRequiredConv,
			decimal? TIssuedConv,
			decimal? TOnHandConv,
			decimal? TQty,
			decimal? TQtyConv,
			int? ItemAvailable,
			string PromptMsg1,
			string PromptButtons1,
			string PromptMsg2,
			string PromptButtons2,
			string Infobar,
			string TImportDocId,
			int? TTaxFreeMatl,
			int? TTrackPieces,
			string TDimensionGroup,
			decimal? TQtyShipped,
			int? IsControl,
			int? ItemTrackECN,
			string Revision)
		ProjmatlValidateItemSp (
			string Item,
			string ProjNum,
			int? TaskNum,
			int? SeqNum,
			string Whse,
			string TItem,
			int? TSeqNum,
			string TItemDesc,
			int? TSerTracked,
			int? TLotTracked,
			string TNonInvAcct,
			decimal? TNonInvCost,
			string TCostCode,
			string TLoc,
			string TLot,
			decimal? TRequired,
			decimal? TIssued,
			decimal? TOnHand,
			string TUM,
			decimal? UomConvFactor,
			decimal? TRequiredConv,
			decimal? TIssuedConv,
			decimal? TOnHandConv,
			decimal? TQty,
			decimal? TQtyConv,
			int? ItemAvailable,
			string PromptMsg1,
			string PromptButtons1,
			string PromptMsg2,
			string PromptButtons2,
			string Infobar,
			string TImportDocId,
			int? TTaxFreeMatl,
			int? TTrackPieces,
			string TDimensionGroup,
			decimal? TQtyShipped,
			int? IsControl,
			int? ItemTrackECN,
			string Revision)
		{
			
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			ItemType _TItem = TItem;
			DescriptionType _TItemDesc = TItemDesc;
			ListYesNoType _TSerTracked = TSerTracked;
			ListYesNoType _TLotTracked = TLotTracked;
			AcctType _TNonInvAcct = TNonInvAcct;
			LotType _TLot = TLot;
			QtyPerType _TQty = TQty;
			ListYesNoType _TTaxFreeMatl = TTaxFreeMatl;
			ListYesNoType _TTrackPieces = TTrackPieces;
			AttributeGroupType _TDimensionGroup = TDimensionGroup;
			QtyPerType _TQtyShipped = TQtyShipped;
			ListYesNoType _ItemTrackECN = ItemTrackECN;
			RevisionType _Revision = Revision;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			Guid? ProjmatlRowPointer = null;
			int? ProjmatlSeq = null;
			string ProjmatlCostCode = null;
			decimal? ProjmatlCost = null;
			string ProjmatlRefType = null;
			string ProjmatlRefNum = null;
			int? ProjmatlRefLineSuf = null;
			Guid? ItemRowPointer = null;
			string ItemUM = null;
			decimal? ItemUnitCost = null;
			decimal? ItemCurUCost = null;
			string ItemCostType = null;
			string ItemProductCode = null;
			string ItemCostMethod = null;
			Guid? ProdcodeRowPointer = null;
			string ProdcodeCostCode = null;
			Guid? ItemwhseRowPointer = null;
			int? ItemwhseCntInProc = null;
			decimal? ItemlocQtyOnHand = null;
			int? CostItemAtWhse = null;
			if (this.iProjmatlValidateItemCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iProjmatlValidateItemCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ProjmatlValidateItemSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iProjmatlValidateItemCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				
				while (this.iProjmatlValidateItemCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iProjmatlValidateItemCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iProjmatlValidateItemCRUD.AltExtGen_ProjmatlValidateItemSp (ALTGEN_SpName,
						Item,
						ProjNum,
						TaskNum,
						SeqNum,
						Whse,
						TItem,
						TSeqNum,
						TItemDesc,
						TSerTracked,
						TLotTracked,
						TNonInvAcct,
						TNonInvCost,
						TCostCode,
						TLoc,
						TLot,
						TRequired,
						TIssued,
						TOnHand,
						TUM,
						UomConvFactor,
						TRequiredConv,
						TIssuedConv,
						TOnHandConv,
						TQty,
						TQtyConv,
						ItemAvailable,
						PromptMsg1,
						PromptButtons1,
						PromptMsg2,
						PromptButtons2,
						Infobar,
						TImportDocId,
						TTaxFreeMatl,
						TTrackPieces,
						TDimensionGroup,
						TQtyShipped,
						IsControl,
						ItemTrackECN,
						Revision);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, TItem, TSeqNum, TItemDesc, TSerTracked, TLotTracked, TNonInvAcct, TNonInvCost, TCostCode, TLoc, TLot, TRequired, TIssued, TOnHand, TUM, UomConvFactor, TRequiredConv, TIssuedConv, TOnHandConv, TQty, TQtyConv, ItemAvailable, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, Infobar, TImportDocId, TTaxFreeMatl, TTrackPieces, TDimensionGroup, TQtyShipped, IsControl, ItemTrackECN, Revision);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iProjmatlValidateItemCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iProjmatlValidateItemCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ProjmatlValidateItemSp") != null)
			{
				var EXTGEN = this.iProjmatlValidateItemCRUD.AltExtGen_ProjmatlValidateItemSp("dbo.EXTGEN_ProjmatlValidateItemSp",
					Item,
					ProjNum,
					TaskNum,
					SeqNum,
					Whse,
					TItem,
					TSeqNum,
					TItemDesc,
					TSerTracked,
					TLotTracked,
					TNonInvAcct,
					TNonInvCost,
					TCostCode,
					TLoc,
					TLot,
					TRequired,
					TIssued,
					TOnHand,
					TUM,
					UomConvFactor,
					TRequiredConv,
					TIssuedConv,
					TOnHandConv,
					TQty,
					TQtyConv,
					ItemAvailable,
					PromptMsg1,
					PromptButtons1,
					PromptMsg2,
					PromptButtons2,
					Infobar,
					TImportDocId,
					TTaxFreeMatl,
					TTrackPieces,
					TDimensionGroup,
					TQtyShipped,
					IsControl,
					ItemTrackECN,
					Revision);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.TItem, EXTGEN.TSeqNum, EXTGEN.TItemDesc, EXTGEN.TSerTracked, EXTGEN.TLotTracked, EXTGEN.TNonInvAcct, EXTGEN.TNonInvCost, EXTGEN.TCostCode, EXTGEN.TLoc, EXTGEN.TLot, EXTGEN.TRequired, EXTGEN.TIssued, EXTGEN.TOnHand, EXTGEN.TUM, EXTGEN.UomConvFactor, EXTGEN.TRequiredConv, EXTGEN.TIssuedConv, EXTGEN.TOnHandConv, EXTGEN.TQty, EXTGEN.TQtyConv, EXTGEN.ItemAvailable, EXTGEN.PromptMsg1, EXTGEN.PromptButtons1, EXTGEN.PromptMsg2, EXTGEN.PromptButtons2, EXTGEN.Infobar, EXTGEN.TImportDocId, EXTGEN.TTaxFreeMatl, EXTGEN.TTrackPieces, EXTGEN.TDimensionGroup, EXTGEN.TQtyShipped, EXTGEN.IsControl, EXTGEN.ItemTrackECN, EXTGEN.Revision);
				}
			}
			
			Severity = 0;
			TItemDesc = null;
			TSerTracked = 0;
			TLotTracked = 0;
			TNonInvAcct = null;
			TNonInvCost = 0;
			TCostCode = null;
			TLoc = null;
			TLot = null;
			TRequired = 0;
			TIssued = 0;
			TOnHand = 0;
			TUM = null;
			TRequiredConv = 0;
			TIssuedConv = 0;
			TOnHandConv = 0;
			TQty = 0;
			TQtyConv = 0;
			ItemAvailable = 0;
			TQtyShipped = 0;
			PromptMsg1 = null;
			PromptButtons1 = null;
			PromptMsg2 = null;
			PromptButtons2 = null;
			TTaxFreeMatl = 0;
			TImportDocId = null;
			if (Item== null)
			{
				Infobar = null;
				
				#region CRUD ExecuteMethodCall
				
				var MsgApp = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NoCompare",
					Parm1: "@projmatl.item",
					Parm2: Item);
				Severity = MsgApp.ReturnCode;
				Infobar = MsgApp.Infobar;
				
				#endregion ExecuteMethodCall
				
				return (Severity, TItem, TSeqNum, TItemDesc, TSerTracked, TLotTracked, TNonInvAcct, TNonInvCost, TCostCode, TLoc, TLot, TRequired, TIssued, TOnHand, TUM, UomConvFactor, TRequiredConv, TIssuedConv, TOnHandConv, TQty, TQtyConv, ItemAvailable, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, Infobar, TImportDocId, TTaxFreeMatl, TTrackPieces, TDimensionGroup, TQtyShipped, IsControl, ItemTrackECN, Revision);
			}
			ItemRowPointer = null;
			(CostItemAtWhse, rowCount) = this.iProjmatlValidateItemCRUD.Dbo_InvparmsLoad(CostItemAtWhse);
			if (sQLUtil.SQLEqual(CostItemAtWhse, 1) == true)
			{
				(ItemRowPointer,
					 TItem,
					 TItemDesc,
					 TSerTracked,
					 TLotTracked,
					 ItemUM,
					 ItemUnitCost,
					 ItemCurUCost,
					 ItemCostType,
					 ItemCostMethod,
					 ItemProductCode,
					 TTaxFreeMatl,
					 TTrackPieces,
					 TDimensionGroup,
					 ItemTrackECN,
					 Revision, rowCount) = this.iProjmatlValidateItemCRUD.ItemLoad(Item,
					 Whse,
					 TItem,
					 TItemDesc,
					 TSerTracked,
					 TLotTracked,
					 TTaxFreeMatl,
					 TTrackPieces,
					 TDimensionGroup,
					 ItemTrackECN,
					 Revision,
					 ItemRowPointer,
					 ItemUM,
					 ItemUnitCost,
					 ItemCurUCost,
					 ItemCostType,
					 ItemProductCode,
					 ItemCostMethod);
				
			}
			else
			{
				(ItemRowPointer,
					 TItem,
					 TItemDesc,
					 TSerTracked,
					 TLotTracked,
					 ItemUM,
					 ItemUnitCost,
					 ItemCurUCost,
					 ItemCostType,
					 ItemCostMethod,
					 ItemProductCode,
					 TTaxFreeMatl,
					 TTrackPieces,
					 TDimensionGroup,
					 ItemTrackECN,
					 Revision, rowCount) = this.iProjmatlValidateItemCRUD.Item1Load(Item,
					 TItem,
					 TItemDesc,
					 TSerTracked,
					 TLotTracked,
					 TTaxFreeMatl,
					 TTrackPieces,
					 TDimensionGroup,
					 ItemTrackECN,
					 Revision,
					 ItemRowPointer,
					 ItemUM,
					 ItemUnitCost,
					 ItemCurUCost,
					 ItemCostType,
					 ItemProductCode,
					 ItemCostMethod);
				
			}
			if (ItemRowPointer!= null)
			{
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: ObsSlowSp
				var ObsSlow = this.iObsSlow.ObsSlowSp(
					Item: Item,
					WarnIfSlowMoving: 0,
					ErrorIfSlowMoving: 0,
					WarnIfObsolete: 0,
					ErrorIfObsolete: 1,
					Infobar: Infobar);
				Severity = ObsSlow.ReturnCode;
				Infobar = ObsSlow.Infobar;
				
				#endregion ExecuteMethodCall
				
				if (sQLUtil.SQLNotEqual(Severity, 0) == true)
				{
					return (Severity, TItem, TSeqNum, TItemDesc, TSerTracked, TLotTracked, TNonInvAcct, TNonInvCost, TCostCode, TLoc, TLot, TRequired, TIssued, TOnHand, TUM, UomConvFactor, TRequiredConv, TIssuedConv, TOnHandConv, TQty, TQtyConv, ItemAvailable, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, Infobar, TImportDocId, TTaxFreeMatl, TTrackPieces, TDimensionGroup, TQtyShipped, IsControl, ItemTrackECN, Revision);
				}
				
			}
			else
			{
				ItemUnitCost = 0;
				ItemCurUCost = 0;
				(TItem, TItemDesc, ItemProductCode, ItemUM, ItemUnitCost, ItemCurUCost, rowCount) = this.iProjmatlValidateItemCRUD.Non_Inventory_ItemLoad(Item, TItem, TItemDesc, ItemUM, ItemUnitCost, ItemCurUCost, ItemProductCode);
				
			}
			ProjmatlRowPointer = null;
			(ProjmatlRowPointer, ProjmatlSeq, ProjmatlCostCode, ProjmatlCost, ProjmatlRefType, ProjmatlRefNum, ProjmatlRefLineSuf, rowCount) = this.iProjmatlValidateItemCRUD.ProjmatlLoad(Item,
				 ProjNum,
				 TaskNum,
				 SeqNum,
				 ProjmatlRowPointer,
				 ProjmatlSeq,
				 ProjmatlCostCode,
				 ProjmatlCost,
				 ProjmatlRefType,
				 ProjmatlRefNum,
				 ProjmatlRefLineSuf);
			if (ProjmatlRowPointer== null)
			{
				ProjmatlRowPointer = null;
				(ProjmatlRowPointer, ProjmatlSeq, ProjmatlCostCode, ProjmatlCost, ProjmatlRefType, ProjmatlRefNum, ProjmatlRefLineSuf, rowCount) = this.iProjmatlValidateItemCRUD.Projmatl1Load(Item,
					 ProjNum,
					 TaskNum,
					 ProjmatlRowPointer,
					 ProjmatlSeq,
					 ProjmatlCostCode,
					 ProjmatlCost,
					 ProjmatlRefType,
					 ProjmatlRefNum,
					 ProjmatlRefLineSuf);
				
			}
			if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLEqual(ProjmatlRefType, "J"), sQLUtil.SQLNotEqual(ProjmatlRefNum, ""))))
			{
				if (sQLUtil.SQLBool(sQLUtil.SQLNot(this.iProjmatlValidateItemCRUD.JobForExists(ProjmatlRefNum, ProjmatlRefLineSuf))))
				{
					
					#region CRUD ExecuteMethodCall
					
					var MsgApp1 = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "E=IsCompare<>2",
						Parm1: "@job.stat",
						Parm2: "@:JobStatus:C",
						Parm3: "@job.job",
						Parm4: "@job.job",
						Parm5: ProjmatlRefNum,
						Parm6: "@job.suffix",
						Parm7: convertToUtil.ToString(ProjmatlRefLineSuf));
					Severity = MsgApp1.ReturnCode;
					Infobar = MsgApp1.Infobar;
					
					#endregion ExecuteMethodCall
					
					return (Severity, TItem, TSeqNum, TItemDesc, TSerTracked, TLotTracked, TNonInvAcct, TNonInvCost, TCostCode, TLoc, TLot, TRequired, TIssued, TOnHand, TUM, UomConvFactor, TRequiredConv, TIssuedConv, TOnHandConv, TQty, TQtyConv, ItemAvailable, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, Infobar, TImportDocId, TTaxFreeMatl, TTrackPieces, TDimensionGroup, TQtyShipped, IsControl, ItemTrackECN, Revision);
				}
				
			}
			if (ProjmatlRowPointer== null)
			{
				PromptMsg1 = null;
				PromptButtons1 = null;
				
				#region CRUD ExecuteMethodCall
				
				var MsgApp2 = this.iMsgApp.MsgAppSp(
					Infobar: PromptMsg1,
					BaseMsg: "I=NoExist3",
					Parm1: "@projmatl",
					Parm2: "@projmatl.proj_num",
					Parm3: ProjNum,
					Parm4: "@projmatl.task_num",
					Parm5: convertToUtil.ToString(TaskNum),
					Parm6: "@projmatl.item",
					Parm7: Item);
				Severity = MsgApp2.ReturnCode;
				PromptMsg1 = MsgApp2.Infobar;
				
				#endregion ExecuteMethodCall
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: MsgAskSp
				var MsgAsk = this.iMsgAsk.MsgAskSp(
					Infobar: PromptMsg1,
					Buttons: PromptButtons1,
					BaseMsg: "Q=AddMatPrjNoYes",
					Parm1: ProjNum);
				Severity = MsgAsk.ReturnCode;
				PromptMsg1 = MsgAsk.Infobar;
				PromptButtons1 = MsgAsk.Buttons;
				
				#endregion ExecuteMethodCall
				
				TSeqNum = 0;
				
			}
			else
			{
				TSeqNum = ProjmatlSeq;
				TCostCode = ProjmatlCostCode;
				
			}
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: PmatlSumMaterialSp
			var PmatlSumMaterial = this.iPmatlSumMaterial.PmatlSumMaterialSp(
				ProjNum: ProjNum,
				TaskNum: TaskNum,
				Seq: TSeqNum,
				Item: Item,
				Whse: Whse,
				TItemDesc: TItemDesc,
				TRequired: TRequired,
				TIssued: TIssued,
				TOnHand: TOnHand,
				TUM: TUM,
				TRequiredConv: TRequiredConv,
				TIssuedConv: TIssuedConv,
				TOnHandConv: TOnHandConv,
				TQty: TQty,
				TQtyConv: TQtyConv,
				Infobar: Infobar);
			Severity = PmatlSumMaterial.ReturnCode;
			TItemDesc = PmatlSumMaterial.TItemDesc;
			TRequired = PmatlSumMaterial.TRequired;
			TIssued = PmatlSumMaterial.TIssued;
			TOnHand = PmatlSumMaterial.TOnHand;
			TUM = PmatlSumMaterial.TUM;
			TRequiredConv = PmatlSumMaterial.TRequiredConv;
			TIssuedConv = PmatlSumMaterial.TIssuedConv;
			TOnHandConv = PmatlSumMaterial.TOnHandConv;
			TQty = PmatlSumMaterial.TQty;
			TQtyConv = PmatlSumMaterial.TQtyConv;
			Infobar = PmatlSumMaterial.Infobar;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				return (Severity, TItem, TSeqNum, TItemDesc, TSerTracked, TLotTracked, TNonInvAcct, TNonInvCost, TCostCode, TLoc, TLot, TRequired, TIssued, TOnHand, TUM, UomConvFactor, TRequiredConv, TIssuedConv, TOnHandConv, TQty, TQtyConv, ItemAvailable, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, Infobar, TImportDocId, TTaxFreeMatl, TTrackPieces, TDimensionGroup, TQtyShipped, IsControl, ItemTrackECN, Revision);
			}
			if (ItemRowPointer!= null)
			{
				ItemAvailable = 1;
				TUM = (ProjmatlRowPointer!= null ? TUM : ItemUM);
				if (TUM!= null)
				{
					
					#region CRUD ExecuteMethodCall
					
					//Please Generate the bounce for this stored procedure: GetumcfSp
					var Getumcf = this.iGetumcf.GetumcfSp(
						OtherUM: TUM,
						Item: Item,
						VendNum: null,
						Area: null,
						ConvFactor: UomConvFactor,
						Infobar: Infobar);
					Severity = Getumcf.ReturnCode;
					UomConvFactor = Getumcf.ConvFactor;
					Infobar = Getumcf.Infobar;
					
					#endregion ExecuteMethodCall
					
					if (sQLUtil.SQLNotEqual(Severity, 0) == true)
					{
						return (Severity, TItem, TSeqNum, TItemDesc, TSerTracked, TLotTracked, TNonInvAcct, TNonInvCost, TCostCode, TLoc, TLot, TRequired, TIssued, TOnHand, TUM, UomConvFactor, TRequiredConv, TIssuedConv, TOnHandConv, TQty, TQtyConv, ItemAvailable, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, Infobar, TImportDocId, TTaxFreeMatl, TTrackPieces, TDimensionGroup, TQtyShipped, IsControl, ItemTrackECN, Revision);
					}
					
				}
				else
				{
					UomConvFactor = 1M;
					
				}
				TNonInvAcct = null;
				if (ProjmatlRowPointer!= null)
				{
					TNonInvCost = convertToUtil.ToDecimal(this.iUomConvAmt.UomConvAmtFn(
						ProjmatlCost,
						UomConvFactor,
						"From Base"));
					
				}
				else
				{
					TNonInvCost = convertToUtil.ToDecimal((sQLUtil.SQLEqual(ItemCostType, "S") == true || sQLUtil.SQLEqual(ItemCostMethod, "A") == true ? ItemUnitCost : ItemCurUCost));
					
				}
				(ProdcodeRowPointer, ProdcodeCostCode, rowCount) = this.iProjmatlValidateItemCRUD.ProdcodeLoad(ItemProductCode, ProdcodeRowPointer, ProdcodeCostCode);
				if (ProdcodeRowPointer== null || ItemProductCode== null)
				{
					Infobar = null;
					
					#region CRUD ExecuteMethodCall
					
					var MsgApp3 = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "E=NoExistFor1",
						Parm1: "@prodcode",
						Parm2: "@item",
						Parm3: "@prodcode.product_code",
						Parm4: ItemProductCode);
					Severity = MsgApp3.ReturnCode;
					Infobar = MsgApp3.Infobar;
					
					#endregion ExecuteMethodCall
					
					return (Severity, TItem, TSeqNum, TItemDesc, TSerTracked, TLotTracked, TNonInvAcct, TNonInvCost, TCostCode, TLoc, TLot, TRequired, TIssued, TOnHand, TUM, UomConvFactor, TRequiredConv, TIssuedConv, TOnHandConv, TQty, TQtyConv, ItemAvailable, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, Infobar, TImportDocId, TTaxFreeMatl, TTrackPieces, TDimensionGroup, TQtyShipped, IsControl, ItemTrackECN, Revision);
				}
				if (ProjmatlRowPointer== null)
				{
					TCostCode = ProdcodeCostCode;
					
				}
				(ItemwhseRowPointer, ItemwhseCntInProc, rowCount) = this.iProjmatlValidateItemCRUD.ItemwhseLoad(Item, Whse, ItemwhseRowPointer, ItemwhseCntInProc);
				if (ItemwhseRowPointer== null)
				{
					Infobar = null;
					
					#region CRUD ExecuteMethodCall
					
					var MsgApp4 = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "E=NoExist2",
						Parm1: "@itemwhse",
						Parm2: "@itemwhse.item",
						Parm3: Item,
						Parm4: "@itemwhse.whse",
						Parm5: Whse);
					Severity = MsgApp4.ReturnCode;
					Infobar = MsgApp4.Infobar;
					
					#endregion ExecuteMethodCall
					
					return (Severity, TItem, TSeqNum, TItemDesc, TSerTracked, TLotTracked, TNonInvAcct, TNonInvCost, TCostCode, TLoc, TLot, TRequired, TIssued, TOnHand, TUM, UomConvFactor, TRequiredConv, TIssuedConv, TOnHandConv, TQty, TQtyConv, ItemAvailable, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, Infobar, TImportDocId, TTaxFreeMatl, TTrackPieces, TDimensionGroup, TQtyShipped, IsControl, ItemTrackECN, Revision);
				}
				if (sQLUtil.SQLEqual(ItemwhseCntInProc, 1) == true)
				{
					PromptMsg2 = null;
					PromptButtons2 = null;
					
					#region CRUD ExecuteMethodCall
					
					//Please Generate the bounce for this stored procedure: MsgAskSp
					var MsgAsk1 = this.iMsgAsk.MsgAskSp(
						Infobar: PromptMsg2,
						Buttons: PromptButtons2,
						BaseMsg: "Q=IsCompare2NoYes",
						Parm1: "@itemwhse.cnt_in_proc",
						Parm2: "@:logical:yes",
						Parm3: "@itemwhse",
						Parm4: "@itemwhse.item",
						Parm5: Item,
						Parm6: "@itemwhse.whse",
						Parm7: Whse);
					Severity = MsgAsk1.ReturnCode;
					PromptMsg2 = MsgAsk1.Infobar;
					PromptButtons2 = MsgAsk1.Buttons;
					
					#endregion ExecuteMethodCall
					
				}
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: ShipLocDefaultSp
				var ShipLocDefault = this.iShipLocDefault.ShipLocDefaultSp(
					Whse: Whse,
					Item: Item,
					Loc: TLoc,
					Lot: TLot,
					Infobar: Infobar,
					ImportDocId: TImportDocId);
				Severity = ShipLocDefault.ReturnCode;
				TLoc = ShipLocDefault.Loc;
				TLot = ShipLocDefault.Lot;
				Infobar = ShipLocDefault.Infobar;
				TImportDocId = ShipLocDefault.ImportDocId;
				
				#endregion ExecuteMethodCall
				
				if (sQLUtil.SQLNotEqual(Severity, 0) == true)
				{
					return (Severity, TItem, TSeqNum, TItemDesc, TSerTracked, TLotTracked, TNonInvAcct, TNonInvCost, TCostCode, TLoc, TLot, TRequired, TIssued, TOnHand, TUM, UomConvFactor, TRequiredConv, TIssuedConv, TOnHandConv, TQty, TQtyConv, ItemAvailable, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, Infobar, TImportDocId, TTaxFreeMatl, TTrackPieces, TDimensionGroup, TQtyShipped, IsControl, ItemTrackECN, Revision);
				}
				(ItemlocQtyOnHand, rowCount) = this.iProjmatlValidateItemCRUD.ItemlocLoad(Item, Whse, TLoc, ItemlocQtyOnHand);
				TOnHand = ItemlocQtyOnHand;
				TOnHandConv = convertToUtil.ToDecimal(this.iUomConvQty.UomConvQtyFn(
					TOnHand,
					UomConvFactor,
					"From Base"));
				TQty = (decimal?)(this.iMaxQty.MaxQtyFn(
					0.0M,
					this.iMinQty.MinQtyFn(
						TOnHand,
						TRequired - TIssued)));
				TQtyConv = convertToUtil.ToDecimal(this.iUomConvQty.UomConvQtyFn(
					TQty,
					UomConvFactor,
					"From Base"));
				
			}
			else
			{
				(TNonInvAcct, rowCount) = this.iProjmatlValidateItemCRUD.ApparmsLoad(TNonInvAcct);
				UomConvFactor = 1M;
				if (ProjmatlRowPointer!= null)
				{
					TNonInvCost = ProjmatlCost;
					
				}
				else
				{
					TNonInvCost = ItemUnitCost;
					
				}
				
			}
			if (this.iProjmatlValidateItemCRUD.Projmatl2ForExists(Item, ProjNum, TaskNum, SeqNum))
			{
				(TItemDesc, rowCount) = this.iProjmatlValidateItemCRUD.Dbo_ProjmatlaspLoad(Item, ProjNum, TaskNum, SeqNum, TItemDesc);
				
			}
			else
			{
				(TItemDesc, rowCount) = this.iProjmatlValidateItemCRUD.Dbo_Projmatlasp1Load(Item, ProjNum, TaskNum, TItemDesc);
				
			}
			(TQtyShipped, rowCount) = this.iProjmatlValidateItemCRUD.Dbo_Projmatlasp2Load(Item, ProjNum, TaskNum, TSeqNum, TQtyShipped);
			var chartLoadResponseForScalarSubQuery = this.iProjmatlValidateItemCRUD.ChartSelect(TNonInvAcct);
			IsControl = convertToUtil.ToInt32(((chartLoadResponseForScalarSubQuery.Items != null &&
			chartLoadResponseForScalarSubQuery.Items.Count != 0) ?
			(chartLoadResponseForScalarSubQuery.Items.FirstOrDefault().GetValue<int?>("is_control")) : null));
			return (Severity, TItem, TSeqNum, TItemDesc, TSerTracked, TLotTracked, TNonInvAcct, TNonInvCost, TCostCode, TLoc, TLot, TRequired, TIssued, TOnHand, TUM, UomConvFactor, TRequiredConv, TIssuedConv, TOnHandConv, TQty, TQtyConv, ItemAvailable, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, Infobar, TImportDocId, TTaxFreeMatl, TTrackPieces, TDimensionGroup, TQtyShipped, IsControl, ItemTrackECN, Revision);
			
		}
		
	}
}

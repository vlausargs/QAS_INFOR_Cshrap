//PROJECT NAME: Production
//CLASS NAME: ProjmatlValidateItemCRUD.cs

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

namespace CSI.Production.Projects
{
	public class ProjmatlValidateItemCRUD : IProjmatlValidateItemCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		
		public ProjmatlValidateItemCRUD(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ProjmatlValidateItemSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}
		
		public ICollectionLoadResponse Optional_Module1Select()
		{
			var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SpName","CAST (NULL AS NVARCHAR)"},
					{"u0","[om].[ModuleName]"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ProjmatlValidateItemSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(optional_module1LoadRequest);
		}
		
		public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
		{
			var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);
			
			this.appDB.Insert(optional_module1InsertRequest);
		}
		
		public bool Tv_ALTGENForExists()
		{
			return existsChecker.Exists(tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""));
		}
		
		public (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
		{
			StringType _ALTGEN_SpName = DBNull.Value;
			
			var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ALTGEN_SpName,"[SpName]"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
			if(tv_ALTGEN1LoadResponse.Items.Count > 0)
			{
				ALTGEN_SpName = _ALTGEN_SpName;
			}
			
			int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
			return (ALTGEN_SpName, rowCount);
		}
		
		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
		{
			var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"[SpName]","[SpName]"},
				},
                loadForChange: true, 
                lockingType: LockingType.None,
                tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}",ALTGEN_SpName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}
		
		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}
		
		public (int? CostItemAtWhse, int? rowCount) Dbo_InvparmsLoad(int? CostItemAtWhse)
		{
			ListYesNoType _CostItemAtWhse = DBNull.Value;
			
			var dbo_invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CostItemAtWhse,"cost_item_at_whse"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"dbo.invparms",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var dbo_invparmsLoadResponse = this.appDB.Load(dbo_invparmsLoadRequest);
			if(dbo_invparmsLoadResponse.Items.Count > 0)
			{
				CostItemAtWhse = _CostItemAtWhse;
			}
			
			int rowCount = dbo_invparmsLoadResponse.Items.Count;
			return (CostItemAtWhse, rowCount);
		}
		
		public (Guid? ItemRowPointer,
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
			string Revision, int? rowCount)
		ItemLoad(string Item,
			string Whse,
			string TItem,
			string TItemDesc,
			int? TSerTracked,
			int? TLotTracked,
			int? TTaxFreeMatl,
			int? TTrackPieces,
			string TDimensionGroup,
			int? ItemTrackECN,
			string Revision,
			Guid? ItemRowPointer,
			string ItemUM,
			decimal? ItemUnitCost,
			decimal? ItemCurUCost,
			string ItemCostType,
			string ItemProductCode,
			string ItemCostMethod)
		{
			RowPointerType _ItemRowPointer = DBNull.Value;
			ItemType _TItem = DBNull.Value;
			DescriptionType _TItemDesc = DBNull.Value;
			ListYesNoType _TSerTracked = DBNull.Value;
			ListYesNoType _TLotTracked = DBNull.Value;
			UMType _ItemUM = DBNull.Value;
			CostPrcType _ItemUnitCost = DBNull.Value;
			CostPrcType _ItemCurUCost = DBNull.Value;
			CostTypeType _ItemCostType = DBNull.Value;
			CostMethodType _ItemCostMethod = DBNull.Value;
			ProductCodeType _ItemProductCode = DBNull.Value;
			ListYesNoType _TTaxFreeMatl = DBNull.Value;
			ListYesNoType _TTrackPieces = DBNull.Value;
			AttributeGroupType _TDimensionGroup = DBNull.Value;
			ListYesNoType _ItemTrackECN = DBNull.Value;
			RevisionType _Revision = DBNull.Value;
			
			var itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ItemRowPointer,"item.RowPointer"},
					{_TItem,"item.item"},
					{_TItemDesc,"item.description"},
					{_TSerTracked,"item.serial_tracked"},
					{_TLotTracked,"item.lot_tracked"},
					{_ItemUM,"item.u_m"},
					{_ItemUnitCost,"itemwhse.unit_cost"},
					{_ItemCurUCost,"itemwhse.cur_u_cost"},
					{_ItemCostType,"item.cost_type"},
					{_ItemCostMethod,"item.cost_method"},
					{_ItemProductCode,"item.product_code"},
					{_TTaxFreeMatl,"item.tax_free_matl"},
					{_TTrackPieces,"item.track_pieces"},
					{_TDimensionGroup,"item.dimension_group"},
					{_ItemTrackECN,"item.track_ecn"},
					{_Revision,"(CASE WHEN item.track_ecn = '1' THEN item.revision ELSE NULL END)"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName:"item",
				fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN itemwhse ON item.item = itemwhse.item"),
				whereClause: collectionLoadRequestFactory.Clause("item.item = {0} AND itemwhse.whse = {1}",Item,Whse),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var itemLoadResponse = this.appDB.Load(itemLoadRequest);
			if(itemLoadResponse.Items.Count > 0)
			{
				ItemRowPointer = _ItemRowPointer;
				TItem = _TItem;
				TItemDesc = _TItemDesc;
				TSerTracked = _TSerTracked;
				TLotTracked = _TLotTracked;
				ItemUM = _ItemUM;
				ItemUnitCost = _ItemUnitCost;
				ItemCurUCost = _ItemCurUCost;
				ItemCostType = _ItemCostType;
				ItemCostMethod = _ItemCostMethod;
				ItemProductCode = _ItemProductCode;
				TTaxFreeMatl = _TTaxFreeMatl;
				TTrackPieces = _TTrackPieces;
				TDimensionGroup = _TDimensionGroup;
				ItemTrackECN = _ItemTrackECN;
				Revision = _Revision;
			}
			
			int rowCount = itemLoadResponse.Items.Count;
			return (ItemRowPointer, TItem, TItemDesc, TSerTracked, TLotTracked, ItemUM, ItemUnitCost, ItemCurUCost, ItemCostType, ItemCostMethod, ItemProductCode, TTaxFreeMatl, TTrackPieces, TDimensionGroup, ItemTrackECN, Revision, rowCount);
		}
		
		public (Guid? ItemRowPointer,
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
			string Revision, int? rowCount)
		Item1Load(string Item,
			string TItem,
			string TItemDesc,
			int? TSerTracked,
			int? TLotTracked,
			int? TTaxFreeMatl,
			int? TTrackPieces,
			string TDimensionGroup,
			int? ItemTrackECN,
			string Revision,
			Guid? ItemRowPointer,
			string ItemUM,
			decimal? ItemUnitCost,
			decimal? ItemCurUCost,
			string ItemCostType,
			string ItemProductCode,
			string ItemCostMethod)
		{
			RowPointerType _ItemRowPointer = DBNull.Value;
			ItemType _TItem = DBNull.Value;
			DescriptionType _TItemDesc = DBNull.Value;
			ListYesNoType _TSerTracked = DBNull.Value;
			ListYesNoType _TLotTracked = DBNull.Value;
			UMType _ItemUM = DBNull.Value;
			CostPrcType _ItemUnitCost = DBNull.Value;
			CostPrcType _ItemCurUCost = DBNull.Value;
			CostTypeType _ItemCostType = DBNull.Value;
			CostMethodType _ItemCostMethod = DBNull.Value;
			ProductCodeType _ItemProductCode = DBNull.Value;
			ListYesNoType _TTaxFreeMatl = DBNull.Value;
			ListYesNoType _TTrackPieces = DBNull.Value;
			AttributeGroupType _TDimensionGroup = DBNull.Value;
			ListYesNoType _ItemTrackECN = DBNull.Value;
			RevisionType _Revision = DBNull.Value;
			
			var item1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ItemRowPointer,"item.RowPointer"},
					{_TItem,"item.item"},
					{_TItemDesc,"item.description"},
					{_TSerTracked,"item.serial_tracked"},
					{_TLotTracked,"item.lot_tracked"},
					{_ItemUM,"item.u_m"},
					{_ItemUnitCost,"item.unit_cost"},
					{_ItemCurUCost,"item.cur_u_cost"},
					{_ItemCostType,"item.cost_type"},
					{_ItemCostMethod,"item.cost_method"},
					{_ItemProductCode,"item.product_code"},
					{_TTaxFreeMatl,"item.tax_free_matl"},
					{_TTrackPieces,"item.track_pieces"},
					{_TDimensionGroup,"item.dimension_group"},
					{_ItemTrackECN,"item.track_ecn"},
					{_Revision,"(CASE WHEN item.track_ecn = '1' THEN item.revision ELSE NULL END)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"item",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("item.item = {0}",Item),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var item1LoadResponse = this.appDB.Load(item1LoadRequest);
			if(item1LoadResponse.Items.Count > 0)
			{
				ItemRowPointer = _ItemRowPointer;
				TItem = _TItem;
				TItemDesc = _TItemDesc;
				TSerTracked = _TSerTracked;
				TLotTracked = _TLotTracked;
				ItemUM = _ItemUM;
				ItemUnitCost = _ItemUnitCost;
				ItemCurUCost = _ItemCurUCost;
				ItemCostType = _ItemCostType;
				ItemCostMethod = _ItemCostMethod;
				ItemProductCode = _ItemProductCode;
				TTaxFreeMatl = _TTaxFreeMatl;
				TTrackPieces = _TTrackPieces;
				TDimensionGroup = _TDimensionGroup;
				ItemTrackECN = _ItemTrackECN;
				Revision = _Revision;
			}
			
			int rowCount = item1LoadResponse.Items.Count;
			return (ItemRowPointer, TItem, TItemDesc, TSerTracked, TLotTracked, ItemUM, ItemUnitCost, ItemCurUCost, ItemCostType, ItemCostMethod, ItemProductCode, TTaxFreeMatl, TTrackPieces, TDimensionGroup, ItemTrackECN, Revision, rowCount);
		}
		
		public (string TItem, string TItemDesc, string ItemProductCode, string ItemUM, decimal? ItemUnitCost, decimal? ItemCurUCost, int? rowCount)
		Non_Inventory_ItemLoad(string Item,
			string TItem,
			string TItemDesc,
			string ItemUM,
			decimal? ItemUnitCost,
			decimal? ItemCurUCost,
			string ItemProductCode)
		{
			ItemType _TItem = DBNull.Value;
			DescriptionType _TItemDesc = DBNull.Value;
			ProductCodeType _ItemProductCode = DBNull.Value;
			UMType _ItemUM = DBNull.Value;
			CostPrcType _ItemUnitCost = DBNull.Value;
			CostPrcType _ItemCurUCost = DBNull.Value;
			
			var non_inventory_itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_TItem,"non_inventory_item.item"},
					{_TItemDesc,"non_inventory_item.description"},
					{_ItemProductCode,"non_inventory_item.product_code"},
					{_ItemUM,"non_inventory_item.u_m"},
					{_ItemUnitCost,"non_inventory_item.unit_cost"},
					{_ItemCurUCost,"non_inventory_item.unit_cost"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"non_inventory_item",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("item = {0}",Item),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var non_inventory_itemLoadResponse = this.appDB.Load(non_inventory_itemLoadRequest);
			if(non_inventory_itemLoadResponse.Items.Count > 0)
			{
				TItem = _TItem;
				TItemDesc = _TItemDesc;
				ItemProductCode = _ItemProductCode;
				ItemUM = _ItemUM;
				ItemUnitCost = _ItemUnitCost;
				ItemCurUCost = _ItemCurUCost;
			}
			
			int rowCount = non_inventory_itemLoadResponse.Items.Count;
			return (TItem, TItemDesc, ItemProductCode, ItemUM, ItemUnitCost, ItemCurUCost, rowCount);
		}
		
		public (Guid? ProjmatlRowPointer,
			int? ProjmatlSeq,
			string ProjmatlCostCode,
			decimal? ProjmatlCost,
			string ProjmatlRefType,
			string ProjmatlRefNum,
			int? ProjmatlRefLineSuf, int? rowCount)
		ProjmatlLoad(string Item,
			string ProjNum,
			int? TaskNum,
			int? SeqNum,
			Guid? ProjmatlRowPointer,
			int? ProjmatlSeq,
			string ProjmatlCostCode,
			decimal? ProjmatlCost,
			string ProjmatlRefType,
			string ProjmatlRefNum,
			int? ProjmatlRefLineSuf)
		{
			RowPointerType _ProjmatlRowPointer = DBNull.Value;
			ProjmatlSeqType _ProjmatlSeq = DBNull.Value;
			CostCodeType _ProjmatlCostCode = DBNull.Value;
			CostPrcType _ProjmatlCost = DBNull.Value;
			RefTypeIJPRType _ProjmatlRefType = DBNull.Value;
			JobPoReqNumType _ProjmatlRefNum = DBNull.Value;
			SuffixPoReqLineType _ProjmatlRefLineSuf = DBNull.Value;
			
			var projmatlLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ProjmatlRowPointer,"projmatl.RowPointer"},
					{_ProjmatlSeq,"projmatl.seq"},
					{_ProjmatlCostCode,"projmatl.cost_code"},
					{_ProjmatlCost,"projmatl.cost"},
					{_ProjmatlRefType,"projmatl.ref_type"},
					{_ProjmatlRefNum,"projmatl.ref_num"},
					{_ProjmatlRefLineSuf,"projmatl.ref_line_suf"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"projmatl",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("projmatl.proj_num = {0} AND projmatl.task_num = {1} AND projmatl.seq >= {2} AND projmatl.item = {3}",ProjNum,TaskNum,SeqNum,Item),
				orderByClause: collectionLoadRequestFactory.Clause(" projmatl.seq"));
			
			var projmatlLoadResponse = this.appDB.Load(projmatlLoadRequest);
			if(projmatlLoadResponse.Items.Count > 0)
			{
				ProjmatlRowPointer = _ProjmatlRowPointer;
				ProjmatlSeq = _ProjmatlSeq;
				ProjmatlCostCode = _ProjmatlCostCode;
				ProjmatlCost = _ProjmatlCost;
				ProjmatlRefType = _ProjmatlRefType;
				ProjmatlRefNum = _ProjmatlRefNum;
				ProjmatlRefLineSuf = _ProjmatlRefLineSuf;
			}
			
			int rowCount = projmatlLoadResponse.Items.Count;
			return (ProjmatlRowPointer, ProjmatlSeq, ProjmatlCostCode, ProjmatlCost, ProjmatlRefType, ProjmatlRefNum, ProjmatlRefLineSuf, rowCount);
		}
		
		public (Guid? ProjmatlRowPointer,
			int? ProjmatlSeq,
			string ProjmatlCostCode,
			decimal? ProjmatlCost,
			string ProjmatlRefType,
			string ProjmatlRefNum,
			int? ProjmatlRefLineSuf, int? rowCount)
		Projmatl1Load(string Item,
			string ProjNum,
			int? TaskNum,
			Guid? ProjmatlRowPointer,
			int? ProjmatlSeq,
			string ProjmatlCostCode,
			decimal? ProjmatlCost,
			string ProjmatlRefType,
			string ProjmatlRefNum,
			int? ProjmatlRefLineSuf)
		{
			RowPointerType _ProjmatlRowPointer = DBNull.Value;
			ProjmatlSeqType _ProjmatlSeq = DBNull.Value;
			CostCodeType _ProjmatlCostCode = DBNull.Value;
			CostPrcType _ProjmatlCost = DBNull.Value;
			RefTypeIJPRType _ProjmatlRefType = DBNull.Value;
			JobPoReqNumType _ProjmatlRefNum = DBNull.Value;
			SuffixPoReqLineType _ProjmatlRefLineSuf = DBNull.Value;
			
			var projmatl1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ProjmatlRowPointer,"projmatl.RowPointer"},
					{_ProjmatlSeq,"projmatl.seq"},
					{_ProjmatlCostCode,"projmatl.cost_code"},
					{_ProjmatlCost,"projmatl.cost"},
					{_ProjmatlRefType,"projmatl.ref_type"},
					{_ProjmatlRefNum,"projmatl.ref_num"},
					{_ProjmatlRefLineSuf,"projmatl.ref_line_suf"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"projmatl",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("projmatl.proj_num = {0} AND projmatl.task_num = {1} AND projmatl.item = {2}",ProjNum,TaskNum,Item),
				orderByClause: collectionLoadRequestFactory.Clause(" projmatl.seq"));
			
			var projmatl1LoadResponse = this.appDB.Load(projmatl1LoadRequest);
			if(projmatl1LoadResponse.Items.Count > 0)
			{
				ProjmatlRowPointer = _ProjmatlRowPointer;
				ProjmatlSeq = _ProjmatlSeq;
				ProjmatlCostCode = _ProjmatlCostCode;
				ProjmatlCost = _ProjmatlCost;
				ProjmatlRefType = _ProjmatlRefType;
				ProjmatlRefNum = _ProjmatlRefNum;
				ProjmatlRefLineSuf = _ProjmatlRefLineSuf;
			}
			
			int rowCount = projmatl1LoadResponse.Items.Count;
			return (ProjmatlRowPointer, ProjmatlSeq, ProjmatlCostCode, ProjmatlCost, ProjmatlRefType, ProjmatlRefNum, ProjmatlRefLineSuf, rowCount);
		}
		
		public bool JobForExists(string ProjmatlRefNum, int? ProjmatlRefLineSuf)
		{
            return existsChecker.Exists(tableName: "job",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("job.job = {1} AND job.suffix = {0} AND job.stat = 'C'", ProjmatlRefLineSuf, ProjmatlRefNum));
		}
		
		public (Guid? ProdcodeRowPointer, string ProdcodeCostCode, int? rowCount) ProdcodeLoad(string ItemProductCode, Guid? ProdcodeRowPointer, string ProdcodeCostCode)
		{
			RowPointerType _ProdcodeRowPointer = DBNull.Value;
			CostCodeType _ProdcodeCostCode = DBNull.Value;
			
			var prodcodeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ProdcodeRowPointer,"prodcode.RowPointer"},
					{_ProdcodeCostCode,"prodcode.cost_code"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"prodcode",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("prodcode.product_code = {0}",ItemProductCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prodcodeLoadResponse = this.appDB.Load(prodcodeLoadRequest);
			if(prodcodeLoadResponse.Items.Count > 0)
			{
				ProdcodeRowPointer = _ProdcodeRowPointer;
				ProdcodeCostCode = _ProdcodeCostCode;
			}
			
			int rowCount = prodcodeLoadResponse.Items.Count;
			return (ProdcodeRowPointer, ProdcodeCostCode, rowCount);
		}
		
		public (Guid? ItemwhseRowPointer, int? ItemwhseCntInProc, int? rowCount) ItemwhseLoad(string Item, string Whse, Guid? ItemwhseRowPointer, int? ItemwhseCntInProc)
		{
			RowPointerType _ItemwhseRowPointer = DBNull.Value;
			ListYesNoType _ItemwhseCntInProc = DBNull.Value;
			
			var itemwhseLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ItemwhseRowPointer,"itemwhse.RowPointer"},
					{_ItemwhseCntInProc,"itemwhse.cnt_in_proc"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"itemwhse",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("itemwhse.item = {0} AND itemwhse.whse = {1}",Item,Whse),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var itemwhseLoadResponse = this.appDB.Load(itemwhseLoadRequest);
			if(itemwhseLoadResponse.Items.Count > 0)
			{
				ItemwhseRowPointer = _ItemwhseRowPointer;
				ItemwhseCntInProc = _ItemwhseCntInProc;
			}
			
			int rowCount = itemwhseLoadResponse.Items.Count;
			return (ItemwhseRowPointer, ItemwhseCntInProc, rowCount);
		}
		
		public (decimal? ItemlocQtyOnHand, int? rowCount) ItemlocLoad(string Item, string Whse, string TLoc, decimal? ItemlocQtyOnHand)
		{
			QtyUnitType _ItemlocQtyOnHand = DBNull.Value;
			
			var itemlocLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ItemlocQtyOnHand,"itemloc.qty_on_hand"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"itemloc",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("itemloc.whse = {0} AND itemloc.item = {1} AND itemloc.loc = {2}",Whse,Item,TLoc),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var itemlocLoadResponse = this.appDB.Load(itemlocLoadRequest);
			if(itemlocLoadResponse.Items.Count > 0)
			{
				ItemlocQtyOnHand = _ItemlocQtyOnHand;
			}
			
			int rowCount = itemlocLoadResponse.Items.Count;
			return (ItemlocQtyOnHand, rowCount);
		}
		
		public (string TNonInvAcct, int? rowCount) ApparmsLoad(string TNonInvAcct)
		{
			AcctType _TNonInvAcct = DBNull.Value;
			
			var apparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_TNonInvAcct,"apparms.pur_acct"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"apparms",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("apparms.apparms_key = 0"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var apparmsLoadResponse = this.appDB.Load(apparmsLoadRequest);
			if(apparmsLoadResponse.Items.Count > 0)
			{
				TNonInvAcct = _TNonInvAcct;
			}
			
			int rowCount = apparmsLoadResponse.Items.Count;
			return (TNonInvAcct, rowCount);
		}
		
		public bool Projmatl2ForExists(string Item, string ProjNum, int? TaskNum, int? SeqNum)
		{
			return existsChecker.Exists(tableName:"projmatl",
				fromClause: collectionLoadRequestFactory.Clause("AS p"),
				whereClause: collectionLoadRequestFactory.Clause("p.item = {3} AND p.proj_num = {0} AND p.task_num = {1} AND p.seq = {2}",ProjNum,TaskNum,SeqNum,Item));
		}
		
		public (string TItemDesc, int? rowCount) Dbo_ProjmatlaspLoad(string Item, string ProjNum, int? TaskNum, int? SeqNum, string TItemDesc)
		{
			DescriptionType _TItemDesc = DBNull.Value;
			
			var dbo_projmatlASpLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_TItemDesc,"p.item_desc"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"dbo.projmatl AS p",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("p.item = {3} AND p.proj_num = {0} AND p.task_num = {1} AND p.seq = {2}",ProjNum,TaskNum,SeqNum,Item),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var dbo_projmatlASpLoadResponse = this.appDB.Load(dbo_projmatlASpLoadRequest);
			if(dbo_projmatlASpLoadResponse.Items.Count > 0)
			{
				TItemDesc = _TItemDesc;
			}
			
			int rowCount = dbo_projmatlASpLoadResponse.Items.Count;
			return (TItemDesc, rowCount);
		}
		
		public (string TItemDesc, int? rowCount) Dbo_Projmatlasp1Load(string Item, string ProjNum, int? TaskNum, string TItemDesc)
		{
			DescriptionType _TItemDesc = DBNull.Value;
			
			var dbo_projmatlASp1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_TItemDesc,"p.item_desc"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"dbo.projmatl AS p",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("p.item = {2} AND p.proj_num = {0} AND p.task_num = {1}",ProjNum,TaskNum,Item),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var dbo_projmatlASp1LoadResponse = this.appDB.Load(dbo_projmatlASp1LoadRequest);
			if(dbo_projmatlASp1LoadResponse.Items.Count > 0)
			{
				TItemDesc = _TItemDesc;
			}
			
			int rowCount = dbo_projmatlASp1LoadResponse.Items.Count;
			return (TItemDesc, rowCount);
		}
		
		public (decimal? TQtyShipped, int? rowCount) Dbo_Projmatlasp2Load(string Item, string ProjNum, int? TaskNum, int? TSeqNum, decimal? TQtyShipped)
		{
			QtyPerType _TQtyShipped = DBNull.Value;
			
			var dbo_projmatlASp2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_TQtyShipped,"p.qty_shipped"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"dbo.projmatl AS p",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("p.item = {3} AND p.proj_num = {0} AND p.task_num = {1} AND p.seq = {2}",ProjNum,TaskNum,TSeqNum,Item),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var dbo_projmatlASp2LoadResponse = this.appDB.Load(dbo_projmatlASp2LoadRequest);
			if(dbo_projmatlASp2LoadResponse.Items.Count > 0)
			{
				TQtyShipped = _TQtyShipped;
			}
			
			int rowCount = dbo_projmatlASp2LoadResponse.Items.Count;
			return (TQtyShipped, rowCount);
		}
		
		public ICollectionLoadResponse ChartSelect(string TNonInvAcct)
		{
			var chartLoadRequestForScalarSubQuery = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"is_control","is_control"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"chart",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("acct = {0}",TNonInvAcct),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(chartLoadRequestForScalarSubQuery);
		}
		
		public (int? ReturnCode,
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
		AltExtGen_ProjmatlValidateItemSp(
			string AltExtGenSp,
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
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _SeqNum = SeqNum;
			WhseType _Whse = Whse;
			ItemType _TItem = TItem;
			ProjmatlSeqType _TSeqNum = TSeqNum;
			DescriptionType _TItemDesc = TItemDesc;
			ListYesNoType _TSerTracked = TSerTracked;
			ListYesNoType _TLotTracked = TLotTracked;
			AcctType _TNonInvAcct = TNonInvAcct;
			CostPrcType _TNonInvCost = TNonInvCost;
			CostCodeType _TCostCode = TCostCode;
			LocType _TLoc = TLoc;
			LotType _TLot = TLot;
			QtyPerType _TRequired = TRequired;
			QtyPerType _TIssued = TIssued;
			QtyPerType _TOnHand = TOnHand;
			UMType _TUM = TUM;
			UMConvFactorType _UomConvFactor = UomConvFactor;
			QtyPerType _TRequiredConv = TRequiredConv;
			QtyPerType _TIssuedConv = TIssuedConv;
			QtyPerType _TOnHandConv = TOnHandConv;
			QtyPerType _TQty = TQty;
			QtyPerType _TQtyConv = TQtyConv;
			ListYesNoType _ItemAvailable = ItemAvailable;
			InfobarType _PromptMsg1 = PromptMsg1;
			InfobarType _PromptButtons1 = PromptButtons1;
			InfobarType _PromptMsg2 = PromptMsg2;
			InfobarType _PromptButtons2 = PromptButtons2;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _TImportDocId = TImportDocId;
			ListYesNoType _TTaxFreeMatl = TTaxFreeMatl;
			ListYesNoType _TTrackPieces = TTrackPieces;
			AttributeGroupType _TDimensionGroup = TDimensionGroup;
			QtyPerType _TQtyShipped = TQtyShipped;
			ListYesNoType _IsControl = IsControl;
			ListYesNoType _ItemTrackECN = ItemTrackECN;
			RevisionType _Revision = Revision;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SeqNum", _SeqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TSeqNum", _TSeqNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TItemDesc", _TItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TSerTracked", _TSerTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TLotTracked", _TLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TNonInvAcct", _TNonInvAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TNonInvCost", _TNonInvCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCostCode", _TCostCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TLoc", _TLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TRequired", _TRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TIssued", _TIssued, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TOnHand", _TOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TUM", _TUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TRequiredConv", _TRequiredConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TIssuedConv", _TIssuedConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TOnHandConv", _TOnHandConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TQtyConv", _TQtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemAvailable", _ItemAvailable, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg1", _PromptMsg1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons1", _PromptButtons1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg2", _PromptMsg2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons2", _PromptButtons2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TImportDocId", _TImportDocId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TTaxFreeMatl", _TTaxFreeMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TTrackPieces", _TTrackPieces, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDimensionGroup", _TDimensionGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TQtyShipped", _TQtyShipped, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsControl", _IsControl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemTrackECN", _ItemTrackECN, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TItem = _TItem;
				TSeqNum = _TSeqNum;
				TItemDesc = _TItemDesc;
				TSerTracked = _TSerTracked;
				TLotTracked = _TLotTracked;
				TNonInvAcct = _TNonInvAcct;
				TNonInvCost = _TNonInvCost;
				TCostCode = _TCostCode;
				TLoc = _TLoc;
				TLot = _TLot;
				TRequired = _TRequired;
				TIssued = _TIssued;
				TOnHand = _TOnHand;
				TUM = _TUM;
				UomConvFactor = _UomConvFactor;
				TRequiredConv = _TRequiredConv;
				TIssuedConv = _TIssuedConv;
				TOnHandConv = _TOnHandConv;
				TQty = _TQty;
				TQtyConv = _TQtyConv;
				ItemAvailable = _ItemAvailable;
				PromptMsg1 = _PromptMsg1;
				PromptButtons1 = _PromptButtons1;
				PromptMsg2 = _PromptMsg2;
				PromptButtons2 = _PromptButtons2;
				Infobar = _Infobar;
				TImportDocId = _TImportDocId;
				TTaxFreeMatl = _TTaxFreeMatl;
				TTrackPieces = _TTrackPieces;
				TDimensionGroup = _TDimensionGroup;
				TQtyShipped = _TQtyShipped;
				IsControl = _IsControl;
				ItemTrackECN = _ItemTrackECN;
				Revision = _Revision;
				
				return (Severity, TItem, TSeqNum, TItemDesc, TSerTracked, TLotTracked, TNonInvAcct, TNonInvCost, TCostCode, TLoc, TLot, TRequired, TIssued, TOnHand, TUM, UomConvFactor, TRequiredConv, TIssuedConv, TOnHandConv, TQty, TQtyConv, ItemAvailable, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, Infobar, TImportDocId, TTaxFreeMatl, TTrackPieces, TDimensionGroup, TQtyShipped, IsControl, ItemTrackECN, Revision);
			}
		}
		
	}
}

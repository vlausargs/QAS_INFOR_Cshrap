//PROJECT NAME: Logistics
//CLASS NAME: ChgPoLineRelStatCRUD.cs

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

namespace CSI.Logistics.Vendor
{
	public class ChgPoLineRelStatCRUD : IChgPoLineRelStatCRUD
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		
		public ChgPoLineRelStatCRUD(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ChgPoLineRelStatSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ChgPoLineRelStatSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
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
		
		public string Tv_ALTGEN1Load(string ALTGEN_SpName)
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
			
			return ALTGEN_SpName;
		}
		
		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
		{
			var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"[SpName]","[SpName]"},
				},
				tableName:"#tv_ALTGEN", 
                loadForChange: true, 
                lockingType: LockingType.None,
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
		
		public int? PoparmsLoad(int? PoParmsVendorReq)
		{
			ByteType _PoParmsVendorReq = DBNull.Value;
			
			var poparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PoParmsVendorReq,"vendor_required"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"poparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var poparmsLoadResponse = this.appDB.Load(poparmsLoadRequest);
			if(poparmsLoadResponse.Items.Count > 0)
			{
				PoParmsVendorReq = _PoParmsVendorReq;
			}
			
			return PoParmsVendorReq;
		}
		
		public ICollectionLoadResponse PoSelect(string IPoStat, string IPoType, string SPoNum, string EPoNum, string SPoVendNum, string EPoVendNum, DateTime? SPoOrderDate, DateTime? EPoOrderDate)
		{
			var PoSp1CrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"po.RowPointer","po.RowPointer"},
					{"po.po_num","po.po_num"},
					{"po.stat","po.stat"},
					{"po.type","po.type"},
					{"po.vend_num","po.vend_num"},
					{"po.order_date","po.order_date"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"po",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("(CHARINDEX(po.type, {4}) <> 0 OR {4} = 'T') AND po.po_num BETWEEN ISNULL({6}, po.po_num) AND ISNULL({7}, po.po_num) AND ((po.vend_num IS NULL AND {2} IS NULL) OR (po.vend_num BETWEEN ISNULL({2}, po.vend_num) AND ISNULL({3}, po.vend_num))) AND po.order_date BETWEEN ISNULL({0}, po.order_date) AND ISNULL({1}, po.order_date) AND ({5} = 'B' OR CHARINDEX(po.stat, {5}) <> 0)",SPoOrderDate,EPoOrderDate,SPoVendNum,EPoVendNum,IPoType,IPoStat,SPoNum,EPoNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			return this.appDB.Load(PoSp1CrsLoadRequestForCursor);
		}
		public ICollectionLoadResponse PoitemSelect(int? SPoLine, int? EPoLine, int? SPoRelease, int? EPoRelease, DateTime? SPoitemDueDate, DateTime? EPoitemDueDate, DateTime? SPoitemRelDate, DateTime? EPoitemRelDate, string PoType, string PoPoNum)
		{
			var PoitemSp1CrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"poitem.RowPointer","poitem.RowPointer"},
					{"poitem.po_num","poitem.po_num"},
					{"poitem.po_line","poitem.po_line"},
					{"poitem.po_release","poitem.po_release"},
					{"poitem.stat","poitem.stat"},
					{"poitem.release_date","poitem.release_date"},
					{"poitem.due_date","poitem.due_date"},
					{"poitem.item","poitem.item"},
					{"poitem.whse","poitem.whse"},
					{"poitem.qty_ordered","poitem.qty_ordered"},
					{"poitem.u_m","poitem.u_m"},
					{"poitem.item_cost","poitem.item_cost"},
					{"poitem.unit_mat_cost","poitem.unit_mat_cost"},
					{"poitem.unit_freight_cost","poitem.unit_freight_cost"},
					{"poitem.unit_duty_cost","poitem.unit_duty_cost"},
					{"poitem.unit_brokerage_cost","poitem.unit_brokerage_cost"},
					{"poitem.unit_loc_frt_cost","poitem.unit_loc_frt_cost"},
					{"poitem.unit_insurance_cost","poitem.unit_insurance_cost"},
					{"poitem.plan_cost","poitem.plan_cost"},
					{"poitem.promise_date","poitem.promise_date"},
					{"poitem.suppl_qty_conv_factor","poitem.suppl_qty_conv_factor"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName:"poitem",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("poitem.po_num = {6} AND poitem.stat = 'P' AND poitem.due_date BETWEEN ISNULL({0}, poitem.due_date) AND ISNULL({1}, poitem.due_date) AND (({9} = 'B' AND poitem.release_date BETWEEN ISNULL({2}, poitem.release_date) AND ISNULL({3}, poitem.release_date)) OR {9} <> 'B' AND poitem.release_date IS NULL) AND poitem.po_line BETWEEN ISNULL({7}, poitem.po_line) AND ISNULL({8}, poitem.po_line) AND poitem.po_release BETWEEN ISNULL({4}, poitem.po_release) AND ISNULL({5}, poitem.po_release)",SPoitemDueDate,EPoitemDueDate,SPoitemRelDate,EPoitemRelDate,SPoRelease,EPoRelease,PoPoNum,SPoLine,EPoLine,PoType),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			return this.appDB.Load(PoitemSp1CrsLoadRequestForCursor);
		}
		public (Guid? ItemRowPointer, string ItemItem) ItemLoad(string PoitemItem, Guid? ItemRowPointer, string ItemItem)
		{
			RowPointerType _ItemRowPointer = DBNull.Value;
			ItemType _ItemItem = DBNull.Value;
			
			var itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ItemRowPointer,"item.RowPointer"},
					{_ItemItem,"item.item"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"item",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("item.item = {0}",PoitemItem),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var itemLoadResponse = this.appDB.Load(itemLoadRequest);
			if(itemLoadResponse.Items.Count > 0)
			{
				ItemRowPointer = _ItemRowPointer;
				ItemItem = _ItemItem;
			}
			
			return (ItemRowPointer, ItemItem);
		}
		
		public string Poitem1Load(Guid? PoitemRowPointer, string PoitemStat)
		{
			PoitemStatType _PoitemStat = DBNull.Value;
			
			var poitem1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PoitemStat,"poitem.stat"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"poitem",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (UPDLOCK)"),
				whereClause: collectionLoadRequestFactory.Clause("poitem.RowPointer = {0}",PoitemRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var poitem1LoadResponse = this.appDB.Load(poitem1LoadRequest);
			if(poitem1LoadResponse.Items.Count > 0)
			{
				PoitemStat = _PoitemStat;
			}
			
			return PoitemStat;
		}
		
		public ICollectionLoadResponse Poitem2Select(Guid? PoitemRowPointer)
		{
			var poitem2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"stat","poitem.stat"},
				},
				tableName:"poitem", 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("poitem.RowPointer = {0}",PoitemRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(poitem2LoadRequest);
		}
		
		public void Poitem2Update(string PoitemStat, ICollectionLoadResponse poitem2LoadResponse)
		{
			foreach(var poitem2Item in poitem2LoadResponse.Items){
				poitem2Item.SetValue<string>("stat", PoitemStat);
			};
			
			var poitem2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "poitem",
				items: poitem2LoadResponse.Items);
			
			this.appDB.Update(poitem2RequestUpdate);
		}
		
		public string Po1Load(int? Severity,
			string PoitemPoNum,
			int? PoitemPoLine,
			int? PoitemPoRelease,
			string PoitemItem,
			string PoitemUM,
			decimal? PoitemQtyOrdered,
			decimal? PoitemItemCost,
			decimal? PoitemMaterialCost,
			decimal? PoitemFreightCost,
			decimal? PoitemDutyCost,
			decimal? PoitemBrokerageCost,
			decimal? PoitemInsuranceCost,
			decimal? PoitemLocalFreightCost,
			decimal? PoitemPlanCost,
			DateTime? PoitemDueDate,
			DateTime? PoitemPromiseDate,
			decimal? PoitemConvFactor,
			string Infobar,
			Guid? PoRowPointer,
			string PoStat)
		{
			PoStatType _PoStat = DBNull.Value;
			
			var po1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PoStat,"po.stat"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"po",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (UPDLOCK)"),
				whereClause: collectionLoadRequestFactory.Clause("po.RowPointer = {0}",PoRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var po1LoadResponse = this.appDB.Load(po1LoadRequest);
			if(po1LoadResponse.Items.Count > 0)
			{
				PoStat = _PoStat;
			}
			
			return PoStat;
		}
		
		public ICollectionLoadResponse Po2Select(Guid? PoRowPointer)
		{
			var po2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"stat","po.stat"},
				},
				tableName:"po", 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("po.RowPointer = {0}",PoRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(po2LoadRequest);
		}
		
		public void Po2Update(ICollectionLoadResponse po2LoadResponse)
		{
			foreach(var po2Item in po2LoadResponse.Items){
				po2Item.SetValue<string>("stat", "O");
			};
			
			var po2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "po",
				items: po2LoadResponse.Items);
			
			this.appDB.Update(po2RequestUpdate);
		}
		
		public (Guid? PoBlnRowPointer, string PoBlnStat) Po_BlnLoad(string PoitemPoNum, int? PoitemPoLine, Guid? PoBlnRowPointer, string PoBlnStat)
		{
			RowPointerType _PoBlnRowPointer = DBNull.Value;
			PoStatType _PoBlnStat = DBNull.Value;
			
			var po_blnLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PoBlnRowPointer,"po_bln.RowPointer"},
					{_PoBlnStat,"po_bln.stat"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"po_bln",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (UPDLOCK)"),
				whereClause: collectionLoadRequestFactory.Clause("po_bln.po_num = {1} AND po_bln.po_line = {0}",PoitemPoLine,PoitemPoNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var po_blnLoadResponse = this.appDB.Load(po_blnLoadRequest);
			if(po_blnLoadResponse.Items.Count > 0)
			{
				PoBlnRowPointer = _PoBlnRowPointer;
				PoBlnStat = _PoBlnStat;
			}
			
			return (PoBlnRowPointer, PoBlnStat);
		}
		
		public ICollectionLoadResponse Poitem3Select(Guid? PoitemRowPointer)
		{
			var poitem3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"stat","poitem.stat"},
				},
				tableName:"poitem", 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("poitem.RowPointer = {0}",PoitemRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(poitem3LoadRequest);
		}
		
		public void Poitem3Update(ICollectionLoadResponse poitem3LoadResponse)
		{
			foreach(var poitem3Item in poitem3LoadResponse.Items){
				poitem3Item.SetValue<string>("stat", "O");
			};
			
			var poitem3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "poitem",
				items: poitem3LoadResponse.Items);
			
			this.appDB.Update(poitem3RequestUpdate);
		}
		
		public ICollectionLoadResponse Po_Bln1Select(Guid? PoBlnRowPointer)
		{
			var po_bln1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"stat","po_bln.stat"},
				},
				tableName:"po_bln", 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("po_bln.RowPointer = {0}",PoBlnRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(po_bln1LoadRequest);
		}
		
		public void Po_Bln1Update(ICollectionLoadResponse po_bln1LoadResponse)
		{
			foreach(var po_bln1Item in po_bln1LoadResponse.Items){
				po_bln1Item.SetValue<string>("stat", "O");
			};
			
			var po_bln1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "po_bln",
				items: po_bln1LoadResponse.Items);
			
			this.appDB.Update(po_bln1RequestUpdate);
		}
		
		public ICollectionLoadResponse NontableSelect(string PoitemPoNum, int? PoitemPoLine, int? PoitemPoRelease, string TOldPoitemStat, string TNewPoitemStat, string TMsg)
		{
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "PoNum", PoitemPoNum},
					{ "PoLine", PoitemPoLine},
					{ "PoRelease", PoitemPoRelease},
					{ "OldStat", TOldPoitemStat},
					{ "NewStat", TNewPoitemStat},
					{ "TMsg", TMsg},
			});
			
			return this.appDB.Load(nonTableLoadRequest);
		}
		public void NontableInsert(ICollectionLoadResponse nonTableLoadResponse)
		{
			var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#ChgStat",
				items: nonTableLoadResponse.Items);
			
			this.appDB.Insert(nonTableInsertRequest);
		}
		
		public ICollectionLoadResponse DynamicparametersSelect(string SelectionClause, string FromClause, string WhereClause, string AdditionalClause, string KeyColumns, string FilterString)
		{
			var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SelectionClause",$"{variableUtil.GetQuotedValue<string>(SelectionClause)}"},
					{"FromClause",$"{variableUtil.GetQuotedValue<string>(FromClause)}"},
					{"WhereClause",$"{variableUtil.GetQuotedValue<string>(WhereClause)}"},
					{"AdditionalClause",$"{variableUtil.GetQuotedValue<string>(AdditionalClause)}"},
					{"KeyColumns",$"{variableUtil.GetQuotedValue<string>(KeyColumns)}"},
					{"FilterString",$"{variableUtil.GetQuotedValue<string>(FilterString)}"},
				},
				selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList"));
			
			return this.appDB.Load(DynamicParametersLoadRequest);
		}
		
		public void DynamicparametersInsert(ICollectionLoadResponse DynamicParametersLoadResponse)
		{
			var DynamicParametersInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#DynamicParameters",
				items: DynamicParametersLoadResponse.Items);
			
			this.appDB.Insert(DynamicParametersInsertRequest);
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode,
			string Infobar)
		AltExtGen_ChgPoLineRelStatSp(
			string AltExtGenSp,
			string ProcSel,
			string IPoStat,
			string IPoType,
			string SPoNum,
			string EPoNum,
			int? SPoLine,
			int? EPoLine,
			int? SPoRelease,
			int? EPoRelease,
			string SPoVendNum,
			string EPoVendNum,
			DateTime? SPoOrderDate,
			DateTime? EPoOrderDate,
			DateTime? SPoitemDueDate,
			DateTime? EPoitemDueDate,
			DateTime? SPoitemRelDate,
			DateTime? EPoitemRelDate,
			string Infobar,
			int? StartOrderDateOffset = null,
			int? EndOrderDateOffset = null,
			int? StartDueDateOffset = null,
			int? EndDueDateOffset = null,
			int? StartRelDateOffset = null,
			int? EndRelDateOffset = null)
		{
			LongListType _ProcSel = ProcSel;
			PoStatType _IPoStat = IPoStat;
			PoTypeType _IPoType = IPoType;
			PoNumType _SPoNum = SPoNum;
			PoNumType _EPoNum = EPoNum;
			PoLineType _SPoLine = SPoLine;
			PoLineType _EPoLine = EPoLine;
			PoReleaseType _SPoRelease = SPoRelease;
			PoReleaseType _EPoRelease = EPoRelease;
			VendNumType _SPoVendNum = SPoVendNum;
			VendNumType _EPoVendNum = EPoVendNum;
			DateType _SPoOrderDate = SPoOrderDate;
			DateType _EPoOrderDate = EPoOrderDate;
			DateType _SPoitemDueDate = SPoitemDueDate;
			DateType _EPoitemDueDate = EPoitemDueDate;
			DateType _SPoitemRelDate = SPoitemRelDate;
			DateType _EPoitemRelDate = EPoitemRelDate;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartOrderDateOffset = StartOrderDateOffset;
			DateOffsetType _EndOrderDateOffset = EndOrderDateOffset;
			DateOffsetType _StartDueDateOffset = StartDueDateOffset;
			DateOffsetType _EndDueDateOffset = EndDueDateOffset;
			DateOffsetType _StartRelDateOffset = StartRelDateOffset;
			DateOffsetType _EndRelDateOffset = EndRelDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "ProcSel", _ProcSel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IPoStat", _IPoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IPoType", _IPoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPoNum", _SPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPoNum", _EPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPoLine", _SPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPoLine", _EPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPoRelease", _SPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPoRelease", _EPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPoVendNum", _SPoVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPoVendNum", _EPoVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPoOrderDate", _SPoOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPoOrderDate", _EPoOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPoitemDueDate", _SPoitemDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPoitemDueDate", _EPoitemDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SPoitemRelDate", _SPoitemRelDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EPoitemRelDate", _EPoitemRelDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartOrderDateOffset", _StartOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderDateOffset", _EndOrderDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDueDateOffset", _StartDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDueDateOffset", _EndDueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartRelDateOffset", _StartRelDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRelDateOffset", _EndRelDateOffset, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
				var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;
				
				Infobar = _Infobar;
				
				return (resultSet, returnCode, Infobar);
			}
		}
		
	}
}

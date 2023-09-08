//PROJECT NAME: Material
//CLASS NAME: CopyCostingAnalysisAlternative.cs

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
using CSI.Production;

namespace CSI.Material
{
	public class CopyCostingAnalysisAlternative : ICopyCostingAnalysisAlternative
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IUndefineVariable iUndefineVariable;
		readonly IApsSyncImmediate iApsSyncImmediate;
		readonly IDefineVariable iDefineVariable;
		readonly IScalarFunction scalarFunction;
		readonly IApsSyncDefer iApsSyncDefer;
		readonly IConvertToUtil convertToUtil;
		readonly IStringUtil stringUtil;
		readonly IHighString highString;
		readonly ILowString lowString;
		readonly INextSjb iNextSjb;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly ICopyCostingAnalysisAlternativeCRUD iCopyCostingAnalysisAlternativeCRUD;
		
		public CopyCostingAnalysisAlternative(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IUndefineVariable iUndefineVariable,
			IApsSyncImmediate iApsSyncImmediate,
			IDefineVariable iDefineVariable,
			IScalarFunction scalarFunction,
			IApsSyncDefer iApsSyncDefer,
			IConvertToUtil convertToUtil,
			IStringUtil stringUtil,
			IHighString highString,
			ILowString lowString,
			INextSjb iNextSjb,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			ICopyCostingAnalysisAlternativeCRUD iCopyCostingAnalysisAlternativeCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iUndefineVariable = iUndefineVariable;
			this.iApsSyncImmediate = iApsSyncImmediate;
			this.iDefineVariable = iDefineVariable;
			this.scalarFunction = scalarFunction;
			this.iApsSyncDefer = iApsSyncDefer;
			this.convertToUtil = convertToUtil;
			this.stringUtil = stringUtil;
			this.highString = highString;
			this.lowString = lowString;
			this.iNextSjb = iNextSjb;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iCopyCostingAnalysisAlternativeCRUD = iCopyCostingAnalysisAlternativeCRUD;
		}
		
		public (
			int? ReturnCode,
			string Infobar)
		CopyCostingAnalysisAlternativeSp (
			string CostingAlt,
			string CostingAltDescription,
			string BOMType,
			string Whse,
			string CostingAltFrom,
			int? CopyRouting,
			string PMTCode,
			string ABCCode,
			string CostMethod,
			string MatlType,
			string ProductCodeStarting,
			string ProductCodeEnding,
			string ItemStarting,
			string ItemEnding,
			string Infobar)
		{
			
			WhseType _Whse = Whse;
			ListYesNoType _CopyRouting = CopyRouting;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			int? ItemCreated = null;
			int? ProdCodeCreated = null;
			int? DeptCreated = null;
			int? WcCreated = null;
			int? MaterialCreated = null;
			int? CostItemAtWhse = null;
			string DefaultWhse = null;
			int? CopyRoutingFlag = null;
			ItemType _Item = DBNull.Value;
			string Item = null;
			string CostType = null;
			int? Suffix = null;
			int? IsCAExists = null;
			string FromJob = null;
			string ToJob = null;
			int? NewJobFlag = null;
			string JobPrefix = null;
			int? FromSuffix = null;
			ICollectionLoadResponse itemCrsLoadResponseForCursor = null;
			int itemCrs_CursorFetch_Status = -1;
			int itemCrs_CursorCounter = -1;
			if (this.iCopyCostingAnalysisAlternativeCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CopyCostingAnalysisAlternativeSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCopyCostingAnalysisAlternativeCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCopyCostingAnalysisAlternativeCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCopyCostingAnalysisAlternativeCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCopyCostingAnalysisAlternativeCRUD.AltExtGen_CopyCostingAnalysisAlternativeSp (ALTGEN_SpName,
						CostingAlt,
						CostingAltDescription,
						BOMType,
						Whse,
						CostingAltFrom,
						CopyRouting,
						PMTCode,
						ABCCode,
						CostMethod,
						MatlType,
						ProductCodeStarting,
						ProductCodeEnding,
						ItemStarting,
						ItemEnding,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCopyCostingAnalysisAlternativeCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CopyCostingAnalysisAlternativeSp") != null)
			{
				var EXTGEN = this.iCopyCostingAnalysisAlternativeCRUD.AltExtGen_CopyCostingAnalysisAlternativeSp("dbo.EXTGEN_CopyCostingAnalysisAlternativeSp",
					CostingAlt,
					CostingAltDescription,
					BOMType,
					Whse,
					CostingAltFrom,
					CopyRouting,
					PMTCode,
					ABCCode,
					CostMethod,
					MatlType,
					ProductCodeStarting,
					ProductCodeEnding,
					ItemStarting,
					ItemEnding,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			this.sQLExpressionExecutor.Execute(@"SELECT item,
				       cost_type,
				       u_m,
				       drawing_nbr,
				       revision,
				       product_code,
				       matl_cost,
				       lbr_cost,
				       fovhd_cost,
				       vovhd_cost,
				       out_cost,
				       asm_setup,
				       asm_run,
				       asm_matl,
				       asm_tool,
				       asm_fixture,
				       asm_other,
				       asm_fixed,
				       asm_var,
				       asm_outside,
				       comp_setup,
				       comp_run,
				       comp_matl,
				       comp_tool,
				       comp_fixture,
				       comp_other,
				       comp_fixed,
				       comp_var,
				       comp_outside,
				       family_code
				INTO   #cai
				FROM   costing_alt_item WITH (READUNCOMMITTED)
				WHERE  1 = 2");
			
			this.sQLExpressionExecutor.Execute(@"Declare
				@Item ItemType
				,@FromJob JobType
				,@ToJob JobType
				,@FromSuffix SuffixType
				,@NewJobFlag ListYesNoType
				SELECT @Item AS alt_item,
				       @FromJob AS from_job,
				       @ToJob AS to_job,
				       @FromSuffix AS suffix,
				       @NewJobFlag AS NewJobFlag
				INTO   #route
				WHERE 1 = 2");
			var routeLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.RouteSelect(Item, FromJob, ToJob, FromSuffix, NewJobFlag);
			
			this.iCopyCostingAnalysisAlternativeCRUD.RouteInsert(routeLoadResponse);
			Severity = 0;
			ItemCreated = 0;
			ProdCodeCreated = 0;
			DeptCreated = 0;
			WcCreated = 0;
			MaterialCreated = 0;
			IsCAExists = 0;
			CopyRouting = (int?)(stringUtil.IsNull(
				CopyRouting,
				0));
			ProductCodeStarting = stringUtil.IsNull(
				ProductCodeStarting,
				lowString.LowStringFn("ProductCodeType"));
			ProductCodeEnding = stringUtil.IsNull(
				ProductCodeEnding,
				highString.HighStringFn("ProductCodeType"));
			ItemStarting = stringUtil.IsNull(
				ItemStarting,
				lowString.LowStringFn("ItemType"));
			ItemEnding = stringUtil.IsNull(
				ItemEnding,
				highString.HighStringFn("ItemType"));
			(CostItemAtWhse, DefaultWhse, rowCount) = this.iCopyCostingAnalysisAlternativeCRUD.InvparmsLoad(CostItemAtWhse, DefaultWhse);
			(JobPrefix, rowCount) = this.iCopyCostingAnalysisAlternativeCRUD.Invparms1Load(JobPrefix);
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: ApsSyncDeferSp
			var ApsSyncDefer = this.iApsSyncDefer.ApsSyncDeferSp(
				Infobar: null,
				Context: "CopyCostingAnalysisAlternativeSp");
			
			#endregion ExecuteMethodCall
			
			if (this.iCopyCostingAnalysisAlternativeCRUD.Costing_AltForExists(CostingAlt))
			{
				IsCAExists = 1;
				
			}
			if (CostingAltFrom!= null)
			{
				(CostType, CopyRoutingFlag, rowCount) = this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt1Load(CostingAltFrom, CopyRoutingFlag, CostType);
				if (CostType== null)
				{
					
					#region CRUD ExecuteMethodCall
					
					var MsgApp = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "E=NoExist1",
						Parm1: "@costing_alt",
						Parm2: "@costing_alt.costing_alt",
						Parm3: CostingAltFrom);
					Severity = MsgApp.ReturnCode;
					Infobar = MsgApp.Infobar;
					
					#endregion ExecuteMethodCall
					
					return (Severity, Infobar);
				}
				
			}
			if (sQLUtil.SQLNotEqual(IsCAExists, 1) == true)
			{
				var nonTableLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.NontableSelect(CostingAlt, CostingAltDescription, BOMType, CostType, Whse, DefaultWhse, CopyRouting);
				this.iCopyCostingAnalysisAlternativeCRUD.NontableInsert(nonTableLoadResponse);
				
			}
			if (BOMType!= null)
			{
				if (sQLUtil.SQLEqual(BOMType, "S") == true)
				{
					Suffix = 1;
					
				}
				else
				{
					Suffix = 0;
					
				}
				if (sQLUtil.SQLEqual(CostItemAtWhse, 1) == true && Whse!= null)
				{
					var itemLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.ItemSelect(PMTCode, ABCCode, CostMethod, MatlType, ProductCodeStarting, ProductCodeEnding, ItemStarting, ItemEnding, Whse, Suffix);
					foreach(var itemItem in itemLoadResponse.Items){
						itemItem.SetValue<string>("item", itemItem.GetValue<string>("item"));
						itemItem.SetValue<string>("cost_type", itemItem.GetValue<string>("cost_type"));
						itemItem.SetValue<string>("u_m", itemItem.GetValue<string>("u_m"));
						itemItem.SetValue<string>("drawing_nbr", itemItem.GetValue<string>("drawing_nbr"));
						itemItem.SetValue<string>("revision", itemItem.GetValue<string>("revision"));
						itemItem.SetValue<string>("product_code", itemItem.GetValue<string>("product_code"));
						itemItem.SetValue<decimal?>("matl_cost", (sQLUtil.SQLEqual(BOMType, "S") == true ? itemItem.GetValue<decimal?>("u0") : itemItem.GetValue<decimal?>("u1")));
						itemItem.SetValue<decimal?>("lbr_cost", (sQLUtil.SQLEqual(BOMType, "S") == true ? itemItem.GetValue<decimal?>("u2") : itemItem.GetValue<decimal?>("u3")));
						itemItem.SetValue<decimal?>("fovhd_cost", (sQLUtil.SQLEqual(BOMType, "S") == true ? itemItem.GetValue<decimal?>("u4") : itemItem.GetValue<decimal?>("u5")));
						itemItem.SetValue<decimal?>("vovhd_cost", (sQLUtil.SQLEqual(BOMType, "S") == true ? itemItem.GetValue<decimal?>("u6") : itemItem.GetValue<decimal?>("u7")));
						itemItem.SetValue<decimal?>("out_cost", (sQLUtil.SQLEqual(BOMType, "S") == true ? itemItem.GetValue<decimal?>("u8") : itemItem.GetValue<decimal?>("u9")));
						itemItem.SetValue<decimal?>("asm_setup", itemItem.GetValue<decimal?>("asm_setup"));
						itemItem.SetValue<decimal?>("asm_run", itemItem.GetValue<decimal?>("asm_run"));
						itemItem.SetValue<decimal?>("asm_matl", itemItem.GetValue<decimal?>("asm_matl"));
						itemItem.SetValue<decimal?>("asm_tool", itemItem.GetValue<decimal?>("asm_tool"));
						itemItem.SetValue<decimal?>("asm_fixture", itemItem.GetValue<decimal?>("asm_fixture"));
						itemItem.SetValue<decimal?>("asm_other", itemItem.GetValue<decimal?>("asm_other"));
						itemItem.SetValue<decimal?>("asm_fixed", itemItem.GetValue<decimal?>("asm_fixed"));
						itemItem.SetValue<decimal?>("asm_var", itemItem.GetValue<decimal?>("asm_var"));
						itemItem.SetValue<decimal?>("asm_outside", itemItem.GetValue<decimal?>("asm_outside"));
						itemItem.SetValue<decimal?>("comp_setup", itemItem.GetValue<decimal?>("comp_setup"));
						itemItem.SetValue<decimal?>("comp_run", itemItem.GetValue<decimal?>("comp_run"));
						itemItem.SetValue<decimal?>("comp_matl", itemItem.GetValue<decimal?>("comp_matl"));
						itemItem.SetValue<decimal?>("comp_tool", itemItem.GetValue<decimal?>("comp_tool"));
						itemItem.SetValue<decimal?>("comp_fixture", itemItem.GetValue<decimal?>("comp_fixture"));
						itemItem.SetValue<decimal?>("comp_other", itemItem.GetValue<decimal?>("comp_other"));
						itemItem.SetValue<decimal?>("comp_fixed", itemItem.GetValue<decimal?>("comp_fixed"));
						itemItem.SetValue<decimal?>("comp_var", itemItem.GetValue<decimal?>("comp_var"));
						itemItem.SetValue<decimal?>("comp_outside", itemItem.GetValue<decimal?>("comp_outside"));
						itemItem.SetValue<string>("family_code", itemItem.GetValue<string>("family_code"));
					};
					
					var itemRequiredColumns = new List<string>() {"item","cost_type","u_m","drawing_nbr","revision","product_code","matl_cost","lbr_cost","fovhd_cost","vovhd_cost","out_cost","asm_setup","asm_run","asm_matl","asm_tool","asm_fixture","asm_other","asm_fixed","asm_var","asm_outside","comp_setup","comp_run","comp_matl","comp_tool","comp_fixture","comp_other","comp_fixed","comp_var","comp_outside","family_code"};
					
					itemLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(itemLoadResponse, itemRequiredColumns);
					
					this.iCopyCostingAnalysisAlternativeCRUD.ItemInsert(itemLoadResponse);
					
				}
				else
				{
					var item1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Item1Select(PMTCode, ABCCode, CostMethod, MatlType, ProductCodeStarting, ProductCodeEnding, ItemStarting, ItemEnding, Suffix);
					foreach(var item1Item in item1LoadResponse.Items){
						item1Item.SetValue<string>("item", item1Item.GetValue<string>("item"));
						item1Item.SetValue<string>("cost_type", item1Item.GetValue<string>("cost_type"));
						item1Item.SetValue<string>("u_m", item1Item.GetValue<string>("u_m"));
						item1Item.SetValue<string>("drawing_nbr", item1Item.GetValue<string>("drawing_nbr"));
						item1Item.SetValue<string>("revision", item1Item.GetValue<string>("revision"));
						item1Item.SetValue<string>("product_code", item1Item.GetValue<string>("product_code"));
						item1Item.SetValue<decimal?>("matl_cost", (sQLUtil.SQLEqual(BOMType, "S") == true ? item1Item.GetValue<decimal?>("u0") : item1Item.GetValue<decimal?>("u1")));
						item1Item.SetValue<decimal?>("lbr_cost", (sQLUtil.SQLEqual(BOMType, "S") == true ? item1Item.GetValue<decimal?>("u2") : item1Item.GetValue<decimal?>("u3")));
						item1Item.SetValue<decimal?>("fovhd_cost", (sQLUtil.SQLEqual(BOMType, "S") == true ? item1Item.GetValue<decimal?>("u4") : item1Item.GetValue<decimal?>("u5")));
						item1Item.SetValue<decimal?>("vovhd_cost", (sQLUtil.SQLEqual(BOMType, "S") == true ? item1Item.GetValue<decimal?>("u6") : item1Item.GetValue<decimal?>("u7")));
						item1Item.SetValue<decimal?>("out_cost", (sQLUtil.SQLEqual(BOMType, "S") == true ? item1Item.GetValue<decimal?>("u8") : item1Item.GetValue<decimal?>("u9")));
						item1Item.SetValue<decimal?>("asm_setup", item1Item.GetValue<decimal?>("asm_setup"));
						item1Item.SetValue<decimal?>("asm_run", item1Item.GetValue<decimal?>("asm_run"));
						item1Item.SetValue<decimal?>("asm_matl", item1Item.GetValue<decimal?>("asm_matl"));
						item1Item.SetValue<decimal?>("asm_tool", item1Item.GetValue<decimal?>("asm_tool"));
						item1Item.SetValue<decimal?>("asm_fixture", item1Item.GetValue<decimal?>("asm_fixture"));
						item1Item.SetValue<decimal?>("asm_other", item1Item.GetValue<decimal?>("asm_other"));
						item1Item.SetValue<decimal?>("asm_fixed", item1Item.GetValue<decimal?>("asm_fixed"));
						item1Item.SetValue<decimal?>("asm_var", item1Item.GetValue<decimal?>("asm_var"));
						item1Item.SetValue<decimal?>("asm_outside", item1Item.GetValue<decimal?>("asm_outside"));
						item1Item.SetValue<decimal?>("comp_setup", item1Item.GetValue<decimal?>("comp_setup"));
						item1Item.SetValue<decimal?>("comp_run", item1Item.GetValue<decimal?>("comp_run"));
						item1Item.SetValue<decimal?>("comp_matl", item1Item.GetValue<decimal?>("comp_matl"));
						item1Item.SetValue<decimal?>("comp_tool", item1Item.GetValue<decimal?>("comp_tool"));
						item1Item.SetValue<decimal?>("comp_fixture", item1Item.GetValue<decimal?>("comp_fixture"));
						item1Item.SetValue<decimal?>("comp_other", item1Item.GetValue<decimal?>("comp_other"));
						item1Item.SetValue<decimal?>("comp_fixed", item1Item.GetValue<decimal?>("comp_fixed"));
						item1Item.SetValue<decimal?>("comp_var", item1Item.GetValue<decimal?>("comp_var"));
						item1Item.SetValue<decimal?>("comp_outside", item1Item.GetValue<decimal?>("comp_outside"));
						item1Item.SetValue<string>("family_code", item1Item.GetValue<string>("family_code"));
					};
					
					var item1RequiredColumns = new List<string>() {"item","cost_type","u_m","drawing_nbr","revision","product_code","matl_cost","lbr_cost","fovhd_cost","vovhd_cost","out_cost","asm_setup","asm_run","asm_matl","asm_tool","asm_fixture","asm_other","asm_fixed","asm_var","asm_outside","comp_setup","comp_run","comp_matl","comp_tool","comp_fixture","comp_other","comp_fixed","comp_var","comp_outside","family_code"};
					
					item1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(item1LoadResponse, item1RequiredColumns);
					
					this.iCopyCostingAnalysisAlternativeCRUD.Item1Insert(item1LoadResponse);
					
				}
				
			}
			else
			{
				var cai1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Cai1Select(CostingAltFrom, PMTCode, ABCCode, CostMethod, MatlType, ProductCodeStarting, ProductCodeEnding, ItemStarting, ItemEnding);
				this.iCopyCostingAnalysisAlternativeCRUD.Cai1Insert(cai1LoadResponse);
				
			}
			var costing_alt_itemLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_ItemSelect(CostingAlt);
			this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_ItemInsert(costing_alt_itemLoadResponse);
			ItemCreated = (int?)(costing_alt_itemLoadResponse.Items.Count + ItemCreated);
			(CostType, CopyRoutingFlag, rowCount) = this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt2Load(CostingAlt, CopyRoutingFlag, CostType);
			if (sQLUtil.SQLEqual(CostType, "S") == true)
			{
				Suffix = 1;
				
			}
			else
			{
				Suffix = 0;
				
			}
			if (this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Item1ForExists(CostingAltFrom))
			{
				#region Cursor Statement
				itemCrsLoadResponseForCursor = this.iCopyCostingAnalysisAlternativeCRUD.Cai2Select(CostingAlt, CostingAltFrom, Suffix);
				#endregion Cursor Statement
				
			}
			else
			{
				#region Cursor Statement
				itemCrsLoadResponseForCursor = this.iCopyCostingAnalysisAlternativeCRUD.Cai3Select(Suffix, CostingAlt);
				#endregion Cursor Statement
				
			}
			itemCrs_CursorFetch_Status = itemCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			itemCrs_CursorCounter = -1;
			
			while (sQLUtil.SQLEqual(Severity, 0) == true)
			{
				itemCrs_CursorCounter++;
				if(itemCrsLoadResponseForCursor.Items.Count > itemCrs_CursorCounter)
				{
					Item = itemCrsLoadResponseForCursor.Items[itemCrs_CursorCounter].GetValue<string>(0);
					FromJob = itemCrsLoadResponseForCursor.Items[itemCrs_CursorCounter].GetValue<string>(1);
					ToJob = itemCrsLoadResponseForCursor.Items[itemCrs_CursorCounter].GetValue<string>(2);
					FromSuffix = itemCrsLoadResponseForCursor.Items[itemCrs_CursorCounter].GetValue<int?>(3);
				}
				itemCrs_CursorFetch_Status = (itemCrs_CursorCounter == itemCrsLoadResponseForCursor.Items.Count ? -1 : 0);
				
				if (sQLUtil.SQLNotEqual(itemCrs_CursorFetch_Status, 0) == true)
				{
					
					break;
					
				}
				if (FromJob== null)
				{
					
					#region CRUD ExecuteMethodCall
					
					var MsgApp1 = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "E=NoExist2",
						Parm1: "@costing_alt_item",
						Parm2: "@costing_alt_item.costing_alt",
						Parm3: CostingAltFrom,
						Parm4: "@costing_alt_item.item",
						Parm5: Item);
					Infobar = MsgApp1.Infobar;
					
					#endregion ExecuteMethodCall
					
					continue;
					
				}
				if (ToJob== null)
				{
					NewJobFlag = 1;
					
					#region CRUD ExecuteMethodCall
					
					//Please Generate the bounce for this stored procedure: NextSjbSp
					var NextSjb = this.iNextSjb.NextSjbSp(
						PContext: "SJOB",
						PPrefix: JobPrefix,
						PKeyLength: 10,
						PKey: ToJob,
						Infobar: Infobar);
					ToJob = NextSjb.PKey;
					Infobar = NextSjb.Infobar;
					
					#endregion ExecuteMethodCall
					
					if (ToJob== null)
					{
						
						#region CRUD ExecuteMethodCall
						
						var MsgApp2 = this.iMsgApp.MsgAppSp(
							Infobar: Infobar,
							BaseMsg: "E=CmdFailed",
							Parm1: "@!Job");
						Severity = MsgApp2.ReturnCode;
						Infobar = MsgApp2.Infobar;
						
						#endregion ExecuteMethodCall
						
						continue;
						
					}
					
				}
				else
				{
					NewJobFlag = 0;
					
				}
				var nonTable1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Nontable1Select(Item, FromJob, ToJob, NewJobFlag, FromSuffix);
				this.iCopyCostingAnalysisAlternativeCRUD.Nontable1Insert(nonTable1LoadResponse);
				
			}
			//Deallocate Cursor itemCrs
			/*Needs to load at least one column from the table: jrtresourcegroup for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var jrtresourcegroupLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.JrtresourcegroupSelect(CopyRoutingFlag);
			this.iCopyCostingAnalysisAlternativeCRUD.JrtresourcegroupDelete(jrtresourcegroupLoadResponse);
			/*Needs to load at least one column from the table: jobmatl for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var jobmatlLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.JobmatlSelect(CopyRoutingFlag);
			this.iCopyCostingAnalysisAlternativeCRUD.JobmatlDelete(jobmatlLoadResponse);
			/*Needs to load at least one column from the table: jrt_sch for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var jrt_schLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Jrt_SchSelect(CopyRoutingFlag);
			this.iCopyCostingAnalysisAlternativeCRUD.Jrt_SchDelete(jrt_schLoadResponse);
			/*Needs to load at least one column from the table: jobroute for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var jobrouteLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.JobrouteSelect(CopyRoutingFlag);
			this.iCopyCostingAnalysisAlternativeCRUD.JobrouteDelete(jobrouteLoadResponse);
			/*Needs to load at least one column from the table: job_sch for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var job_schLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Job_SchSelect(CopyRoutingFlag);
			this.iCopyCostingAnalysisAlternativeCRUD.Job_SchDelete(job_schLoadResponse);
			/*Needs to load at least one column from the table: job for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var jobLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.JobSelect(CopyRoutingFlag);
			this.iCopyCostingAnalysisAlternativeCRUD.JobDelete(jobLoadResponse);
			var costing_alt_item2LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Item2Select(CostingAlt);
			this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Item2Update(costing_alt_item2LoadResponse);
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: DefineVariableSp
			var DefineVariable = this.iDefineVariable.DefineVariableSp(
				VariableName: "InsertJobSch",
				VariableValue: "0",
				Infobar: null);
			
			#endregion ExecuteMethodCall
			
			var job1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Job1Select(CopyRoutingFlag);
			this.iCopyCostingAnalysisAlternativeCRUD.Job1Insert(job1LoadResponse);
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: UndefineVariableSp
			var UndefineVariable = this.iUndefineVariable.UndefineVariableSp(
				VariableName: "InsertJobSch",
				Infobar: null);
			
			#endregion ExecuteMethodCall
			
			var job_sch1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Job_Sch1Select(CopyRoutingFlag);
			this.iCopyCostingAnalysisAlternativeCRUD.Job_Sch1Insert(job_sch1LoadResponse);
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: DefineVariableSp
			var DefineVariable1 = this.iDefineVariable.DefineVariableSp(
				VariableName: "InsertJrtSch",
				VariableValue: "0",
				Infobar: null);
			
			#endregion ExecuteMethodCall
			
			var jobroute1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Jobroute1Select(CopyRoutingFlag);
			this.iCopyCostingAnalysisAlternativeCRUD.Jobroute1Insert(jobroute1LoadResponse);
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: UndefineVariableSp
			var UndefineVariable1 = this.iUndefineVariable.UndefineVariableSp(
				VariableName: "InsertJrtSch",
				Infobar: null);
			
			#endregion ExecuteMethodCall
			
			var jrt_sch1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Jrt_Sch1Select(CopyRoutingFlag);
			this.iCopyCostingAnalysisAlternativeCRUD.Jrt_Sch1Insert(jrt_sch1LoadResponse);
			var jobmatl1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Jobmatl1Select(CopyRoutingFlag);
			this.iCopyCostingAnalysisAlternativeCRUD.Jobmatl1Insert(jobmatl1LoadResponse);
			var jrtresourcegroup1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Jrtresourcegroup1Select(CopyRoutingFlag);
			this.iCopyCostingAnalysisAlternativeCRUD.Jrtresourcegroup1Insert(jrtresourcegroup1LoadResponse);
			if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLEqual(Severity, 0), sQLUtil.SQLNotEqual(CopyRouting, 1))))
			{
				if (sQLUtil.SQLBool(sQLUtil.SQLOr(BOMType!= null, sQLUtil.SQLEqual(CopyRoutingFlag, 1))))
				{
					var costing_alt_wcLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_WcSelect(CostingAlt);
					this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_WcInsert(costing_alt_wcLoadResponse);
					
					WcCreated = (int?)(jrtresourcegroup1LoadResponse.Items.Count + WcCreated);
					
					var costing_alt_deptLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_DeptSelect(CostingAlt);
					this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_DeptInsert(costing_alt_deptLoadResponse);

					DeptCreated = (int?)(costing_alt_deptLoadResponse.Items.Count + DeptCreated);
					
					var costing_alt_materialLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_MaterialSelect(CostingAlt, Whse);
					this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_MaterialInsert(costing_alt_materialLoadResponse);

					MaterialCreated = (int?)(costing_alt_materialLoadResponse.Items.Count + MaterialCreated);
					
					var costing_alt_product_codeLoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Product_CodeSelect(CostingAlt);
					this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Product_CodeInsert(costing_alt_product_codeLoadResponse);
					
					ProdCodeCreated = (int?)(costing_alt_product_codeLoadResponse.Items.Count + ProdCodeCreated);
					
				}
				else
				{
					var costing_alt_product_code1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Product_Code1Select(CostingAlt, CostingAltFrom);
					this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Product_Code1Insert(costing_alt_product_code1LoadResponse);
					
					ProdCodeCreated = (int?)(costing_alt_product_code1LoadResponse.Items.Count + ProdCodeCreated);
					
					var costing_alt_wc1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Wc1Select(CostingAlt, CostingAltFrom);
					this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Wc1Insert(costing_alt_wc1LoadResponse);
					
					WcCreated = (int?)(costing_alt_wc1LoadResponse.Items.Count + WcCreated);
					
					var costing_alt_dept1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Dept1Select(CostingAlt, CostingAltFrom);
					this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Dept1Insert(costing_alt_dept1LoadResponse);
					
					DeptCreated = (int?)(costing_alt_dept1LoadResponse.Items.Count + DeptCreated);
					
					var costing_alt_material1LoadResponse = this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Material1Select(CostingAlt, CostingAltFrom);
					this.iCopyCostingAnalysisAlternativeCRUD.Costing_Alt_Material1Insert(costing_alt_material1LoadResponse);
					
					MaterialCreated = (int?)(costing_alt_material1LoadResponse.Items.Count + MaterialCreated);
					
				}
				
			}
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: ApsSyncImmediateSp
			var ApsSyncImmediate = this.iApsSyncImmediate.ApsSyncImmediateSp(
				Infobar: null,
				DropDeferred: Severity,
				Context: "CopyCostingAnalysisAlternativeSp");
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			var MsgApp3 = this.iMsgApp.MsgAppSp(
				Infobar: Infobar,
				BaseMsg: "E=Created",
				Parm1: "@costing_alt",
				Parm2: "@costing_alt.costing_alt",
				Parm3: CostingAlt);
			Infobar = MsgApp3.Infobar;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			var MsgApp4 = this.iMsgApp.MsgAppSp(
				Infobar: Infobar,
				BaseMsg: "I=#Created",
				Parm1: convertToUtil.ToString(ItemCreated),
				Parm2: "@costing_alt_item");
			Infobar = MsgApp4.Infobar;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			var MsgApp5 = this.iMsgApp.MsgAppSp(
				Infobar: Infobar,
				BaseMsg: "I=#Created",
				Parm1: convertToUtil.ToString(ProdCodeCreated),
				Parm2: "@costing_alt_product_code");
			Infobar = MsgApp5.Infobar;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			var MsgApp6 = this.iMsgApp.MsgAppSp(
				Infobar: Infobar,
				BaseMsg: "I=#Created",
				Parm1: convertToUtil.ToString(DeptCreated),
				Parm2: "@costing_alt_dept");
			Infobar = MsgApp6.Infobar;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			var MsgApp7 = this.iMsgApp.MsgAppSp(
				Infobar: Infobar,
				BaseMsg: "I=#Created",
				Parm1: convertToUtil.ToString(WcCreated),
				Parm2: "@costing_alt_wc");
			Infobar = MsgApp7.Infobar;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			var MsgApp8 = this.iMsgApp.MsgAppSp(
				Infobar: Infobar,
				BaseMsg: "I=#Created",
				Parm1: convertToUtil.ToString(MaterialCreated),
				Parm2: "@costing_alt_material");
			Infobar = MsgApp8.Infobar;
			
			#endregion ExecuteMethodCall
			
			return (Severity, Infobar);
			
		}
		
	}
}

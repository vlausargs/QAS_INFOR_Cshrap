//PROJECT NAME: Logistics
//CLASS NAME: CheckItemCost.cs

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
	public class CheckItemCost : ICheckItemCost
	{
		readonly IApplicationDB appDB;
		
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgAsk iMsgAsk;
		
		public CheckItemCost(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IMsgAsk iMsgAsk)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgAsk = iMsgAsk;
		}
		
		public (
			int? ReturnCode,
			string PromptMsg,
			string PromptButtons)
		CheckItemCostSp (
			string PItem,
			string PWhse,
			string PromptMsg,
			string PromptButtons)
		{
			
			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			ListYesNoType _CostItemAtWhse = DBNull.Value;
			int? CostItemAtWhse = null;
			RowPointerType _ItemRowPointer = DBNull.Value;
			Guid? ItemRowPointer = null;
			CostTypeType _ItemCostType = DBNull.Value;
			string ItemCostType = null;
			CostPrcType _ItemUnitMatCost = DBNull.Value;
			decimal? ItemUnitMatCost = null;
			CostPrcType _ItemUnitDutyCost = DBNull.Value;
			decimal? ItemUnitDutyCost = null;
			CostPrcType _ItemUnitFreightCost = DBNull.Value;
			decimal? ItemUnitFreightCost = null;
			CostPrcType _ItemUnitBrokerageCost = DBNull.Value;
			decimal? ItemUnitBrokerageCost = null;
			PMTCodeType _PMTCode = DBNull.Value;
			string PMTCode = null;
			CostPrcType _ItemUnitInsuranceCost = DBNull.Value;
			decimal? ItemUnitInsuranceCost = null;
			CostPrcType _ItemUnitLocFrtCost = DBNull.Value;
			decimal? ItemUnitLocFrtCost = null;
			if (existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CheckItemCostSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
			)
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				
				#region CRUD LoadToRecord
				var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"SpName","CAST (NULL AS NVARCHAR)"},
						{"u0","[om].[ModuleName]"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName:"optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CheckItemCostSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord
				
				#region CRUD InsertByRecords
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CheckItemCostSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);
				
				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords
				
				while (existsChecker.Exists(tableName:"#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""))
				)
				{
					//BEGIN
					
					#region CRUD LoadToVariable
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
					#endregion  LoadToVariable
					
					var ALTGEN = AltExtGen_CheckItemCostSp (ALTGEN_SpName,
						PItem,
						PWhse,
						PromptMsg,
						PromptButtons);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, PromptMsg, PromptButtons);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					#region CRUD LoadToRecord
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
					var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
					#endregion  LoadToRecord
					
					#region CRUD DeleteByRecord
					var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
						items: tv_ALTGEN2LoadResponse.Items);
					this.appDB.Delete(tv_ALTGEN2DeleteRequest);
					#endregion DeleteByRecord
					
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					//END
					
				}
				//END
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CheckItemCostSp") != null)
			{
				var EXTGEN = AltExtGen_CheckItemCostSp("dbo.EXTGEN_CheckItemCostSp",
					PItem,
					PWhse,
					PromptMsg,
					PromptButtons);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.PromptMsg, EXTGEN.PromptButtons);
				}
			}
			
			Severity = 0;
			
			#region CRUD LoadToVariable
			var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CostItemAtWhse,"cost_item_at_whse"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"invparms",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var invparmsLoadResponse = this.appDB.Load(invparmsLoadRequest);
			if(invparmsLoadResponse.Items.Count > 0)
			{
				CostItemAtWhse = _CostItemAtWhse;
			}
			#endregion  LoadToVariable
			
			PromptMsg = null;
			PromptButtons = null;
			PMTCode = null;
			if (PItem!= null)
			{
				//BEGIN
				ItemRowPointer = null;
				ItemCostType = null;
				ItemUnitMatCost = 0;
				ItemUnitDutyCost = 0;
				ItemUnitFreightCost = 0;
				ItemUnitBrokerageCost = 0;
				ItemUnitInsuranceCost = 0;
				ItemUnitLocFrtCost = 0;
				
				#region CRUD LoadToVariable
				var itemASitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_ItemRowPointer,"titem.RowPointer"},
						{_ItemCostType,"item.cost_type"},
						{_ItemUnitMatCost,"titem.unit_mat_cost"},
						{_ItemUnitDutyCost,"titem.unit_duty_cost"},
						{_ItemUnitFreightCost,"titem.unit_freight_cost"},
						{_ItemUnitBrokerageCost,"titem.unit_brokerage_cost"},
						{_ItemUnitInsuranceCost,"titem.unit_insurance_cost"},
						{_ItemUnitLocFrtCost,"titem.unit_loc_frt_cost"},
						{_PMTCode,"item.p_m_t_code"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName:"item AS item",
					fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN (SELECT rowpointer,
							item,
							unit_mat_cost,
							unit_duty_cost,
							unit_freight_cost,
							unit_brokerage_cost,
							unit_insurance_cost,
							unit_loc_frt_cost,
							0 AS cost_item_at_whse
							FROM   item
							UNION ALL
							SELECT rowpointer,
							item,
							unit_mat_cost,
							unit_duty_cost,
							unit_freight_cost,
							unit_brokerage_cost,
							unit_insurance_cost,
							unit_loc_frt_cost,
							1 AS cost_item_at_whse
							FROM   itemwhse
							WHERE  whse = {0}) AS titem ON item.item = titem.item",PWhse),
					whereClause: collectionLoadRequestFactory.Clause("item.item = {1} AND titem.cost_item_at_whse = {0}",CostItemAtWhse,PItem),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var itemASitemLoadResponse = this.appDB.Load(itemASitemLoadRequest);
				if(itemASitemLoadResponse.Items.Count > 0)
				{
					ItemRowPointer = _ItemRowPointer;
					ItemCostType = _ItemCostType;
					ItemUnitMatCost = _ItemUnitMatCost;
					ItemUnitDutyCost = _ItemUnitDutyCost;
					ItemUnitFreightCost = _ItemUnitFreightCost;
					ItemUnitBrokerageCost = _ItemUnitBrokerageCost;
					ItemUnitInsuranceCost = _ItemUnitInsuranceCost;
					ItemUnitLocFrtCost = _ItemUnitLocFrtCost;
					PMTCode = _PMTCode;
				}
				#endregion  LoadToVariable
				
				if (ItemRowPointer!= null)
				{
					//BEGIN
					if (sQLUtil.SQLEqual(ItemCostType, "S") == true && sQLUtil.SQLEqual(PMTCode, "P") == true && (sQLUtil.SQLEqual(ItemUnitMatCost + ItemUnitDutyCost + ItemUnitFreightCost + ItemUnitBrokerageCost + ItemUnitInsuranceCost + ItemUnitLocFrtCost, 0) == true))
					{
						
						#region CRUD ExecuteMethodCall
						
						//Please Generate the bounce for this stored procedure: MsgAskSp
						var MsgAsk = this.iMsgAsk.MsgAskSp(
							Infobar: PromptMsg,
							Buttons: PromptButtons,
							BaseMsg: "Q=IsCompare2NoYes",
							Parm1: "@item.unit_cost",
							Parm2: "0",
							Parm3: "@preqitem",
							Parm4: "@item",
							Parm5: PItem,
							Parm6: "@item.cost_type",
							Parm7: "@:CostType:S");
						Severity = MsgAsk.ReturnCode;
						PromptMsg = MsgAsk.Infobar;
						PromptButtons = MsgAsk.Buttons;
						
						#endregion ExecuteMethodCall
						
					}
					//END
					
				}
				//END
				
			}
			return (Severity, PromptMsg, PromptButtons);
			
		}
		public (int? ReturnCode,
			string PromptMsg,
			string PromptButtons)
		AltExtGen_CheckItemCostSp(
			string AltExtGenSp,
			string PItem,
			string PWhse,
			string PromptMsg,
			string PromptButtons)
		{
			ItemType _PItem = PItem;
			WhseType _PWhse = PWhse;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, PromptMsg, PromptButtons);
			}
		}
		
	}
}

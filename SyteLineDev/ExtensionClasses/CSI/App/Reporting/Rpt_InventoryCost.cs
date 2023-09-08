//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryCost.cs

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
using CSI.Adapters;
using CSI.Data.Cache;

namespace CSI.Reporting
{
	public class Rpt_InventoryCost : IRpt_InventoryCost
	{
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IGetWinRegDecGroup iGetWinRegDecGroup;
		readonly IFixMaskForCrystal iFixMaskForCrystal;
		readonly IDefineVariable iDefineVariable;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IHighCharacter highCharacter;
		readonly ILowCharacter lowCharacter;
		readonly IGetSiteDate iGetSiteDate;
		readonly IStringUtil stringUtil;
		readonly IGetCode iGetCode;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRpt_InventoryCostCRUD iRpt_InventoryCostCRUD;
		
		public Rpt_InventoryCost(IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IGetWinRegDecGroup iGetWinRegDecGroup,
			IFixMaskForCrystal iFixMaskForCrystal,
			IDefineVariable iDefineVariable,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IHighCharacter highCharacter,
			ILowCharacter lowCharacter,
			IGetSiteDate iGetSiteDate,
			IStringUtil stringUtil,
			IGetCode iGetCode,
			ISQLValueComparerUtil sQLUtil,
			IRpt_InventoryCostCRUD iRpt_InventoryCostCRUD)
		{
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iGetWinRegDecGroup = iGetWinRegDecGroup;
			this.iFixMaskForCrystal = iFixMaskForCrystal;
			this.iDefineVariable = iDefineVariable;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.highCharacter = highCharacter;
			this.lowCharacter = lowCharacter;
			this.iGetSiteDate = iGetSiteDate;
			this.stringUtil = stringUtil;
			this.iGetCode = iGetCode;
			this.sQLUtil = sQLUtil;
			this.iRpt_InventoryCostCRUD = iRpt_InventoryCostCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_InventoryCostSp (
			string ExbegWhse = null,
			string ExendWhse = null,
			string ExbegLoc = null,
			string ExendLoc = null,
			string ExbegProductcode = null,
			string ExendProductcode = null,
			string ExbegItem = null,
			string ExendItem = null,
			string ExOptgoItemStat = "AOS",
			string ExOptgoMatlType = "MTFO",
			string ExOptprPMTCode = "PMT",
			string ExOptszStocked = "B",
			string ExOptacAbcCode = "ABC",
			int? ExOptprPrZeroQty = 0,
			int? ShowDetail = 0,
			int? PrintCost = 0,
			int? DisplayHeader = null,
			string PMessageLanguage = null,
			string pSite = null,
			Guid? ProcessId = null)
		{
			if(bunchedLoadCollection != null)
			    bunchedLoadCollection.StartBunching();

			try
			{
				ICollectionLoadResponse Data = null;

				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				int? rowCount = null;
				string Infobar = null;
				string LowCharacter = null;
				string HighCharacter = null;
				int? CostItemAtWhse = null;
				int? Severity = null;
				int? TStock = null;
				DateTime? GetSiteDate = null;
				string ParmsCurrCode = null;
				string CostPriceFormat = null;
				int? CostPricePlaces = null;
				string Description = null;
				if (this.iRpt_InventoryCostCRUD.Optional_ModuleForExists())
				{
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");
					var optional_module1LoadResponse = this.iRpt_InventoryCostCRUD.Optional_Module1Select();
					var optional_module1RequiredColumns = new List<string>() { "SpName" };

					optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

					this.iRpt_InventoryCostCRUD.Optional_Module1Insert(optional_module1LoadResponse);
					while (this.iRpt_InventoryCostCRUD.Tv_ALTGENForExists())
					{
						(ALTGEN_SpName, rowCount) = this.iRpt_InventoryCostCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
						var ALTGEN = this.iRpt_InventoryCostCRUD.AltExtGen_Rpt_InventoryCostSp(ALTGEN_SpName,
							ExbegWhse,
							ExendWhse,
							ExbegLoc,
							ExendLoc,
							ExbegProductcode,
							ExendProductcode,
							ExbegItem,
							ExendItem,
							ExOptgoItemStat,
							ExOptgoMatlType,
							ExOptprPMTCode,
							ExOptszStocked,
							ExOptacAbcCode,
							ExOptprPrZeroQty,
							ShowDetail,
							PrintCost,
							DisplayHeader,
							PMessageLanguage,
							pSite,
							ProcessId);
						ALTGEN_Severity = ALTGEN.ReturnCode;

						if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
						{
							return (ALTGEN.Data, ALTGEN_Severity);
						}
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
						/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
						var tv_ALTGEN2LoadResponse = this.iRpt_InventoryCostCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
						this.iRpt_InventoryCostCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					}
				}
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_InventoryCostSp") != null)
				{
					var EXTGEN = this.iRpt_InventoryCostCRUD.AltExtGen_Rpt_InventoryCostSp("dbo.EXTGEN_Rpt_InventoryCostSp",
						ExbegWhse,
						ExendWhse,
						ExbegLoc,
						ExendLoc,
						ExbegProductcode,
						ExendProductcode,
						ExbegItem,
						ExendItem,
						ExOptgoItemStat,
						ExOptgoMatlType,
						ExOptprPMTCode,
						ExOptszStocked,
						ExOptacAbcCode,
						ExOptprPrZeroQty,
						ShowDetail,
						PrintCost,
						DisplayHeader,
						PMessageLanguage,
						pSite,
						ProcessId);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;

					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}

				if (ProcessId == null)
					ProcessId = new Guid();

				if (bunchedLoadCollection.LoadType == LoadType.First)
				{
					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: DefineVariableSp
					var DefineVariable = this.iDefineVariable.DefineVariableSp(
						VariableName: "MessageLanguage",
						VariableValue: PMessageLanguage,
						Infobar: Infobar);
					Infobar = DefineVariable.Infobar;

					#endregion ExecuteMethodCall

					LowCharacter = convertToUtil.ToString(lowCharacter.LowCharacterFn());
					HighCharacter = convertToUtil.ToString(highCharacter.HighCharacterFn());
					ExbegWhse = stringUtil.IsNull(
						ExbegWhse,
						LowCharacter);
					ExendWhse = stringUtil.IsNull(
						ExendWhse,
						HighCharacter);
					ExbegLoc = stringUtil.IsNull(
						ExbegLoc,
						LowCharacter);
					ExendLoc = stringUtil.IsNull(
						ExendLoc,
						HighCharacter);
					ExbegProductcode = stringUtil.IsNull(
						ExbegProductcode,
						LowCharacter);
					ExendProductcode = stringUtil.IsNull(
						ExendProductcode,
						HighCharacter);
					ExbegItem = stringUtil.IsNull(
						ExbegItem,
						LowCharacter);
					ExendItem = stringUtil.IsNull(
						ExendItem,
						HighCharacter);

					GetSiteDate = convertToUtil.ToDateTime(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE")));
					Severity = 0;
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @ItemGeneral TABLE (
					    whse                  WhseType       ,
					    item                  ItemType       ,
					    loc                   LocType        ,
					    lot                   LotType        ,
					    status                NVARCHAR (20)  ,
					    item_desc             DescriptionType,
					    item_stocked          ListYesNoType  ,
					    matl_type             MatlTypeType   ,
					    u_m                   UMType         ,
					    pmt_code              PMTCodeType    ,
					    product_code          ProductCodeType,
					    cost_type             CostTypeType   ,
					    cost_method           CostMethodType ,
					    itemloc_inv_acct      AcctType       ,
					    itemloc_lbr_acct      AcctType       ,
					    itemloc_fovhd_acct    AcctType       ,
					    itemloc_vovhd_acct    AcctType       ,
					    itemloc_out_acct      AcctType       ,
					    lot_tracked           ListYesNoType  ,
					    itemprice_unit_price1 AmtTotType      PRIMARY KEY (whse, item, loc, lot),
					    qty_on_hand           QtyTotlType    ,
					    cpr_cost              AmtTotType     ,
					    cpr_price             AmtTotType     ,
					    amt_price             AmtTotType     ,
					    matl_cost             AmtTotType     ,
					    lbr_cost              AmtTotType     ,
					    fovhd_cost            AmtTotType     ,
					    vovhd_cost            AmtTotType     ,
					    out_cost              AmtTotType     ,
					    itemlifo_qty          AmtTotType      DEFAULT 0,
					    itemlifo_unit_cost    AmtTotType     ,
					    itemlifo_matl_cost    AmtTotType     ,
					    itemlifo_lbr_cost     AmtTotType     ,
					    itemlifo_fovhd_cost   AmtTotType     ,
					    itemlifo_vovhd_cost   AmtTotType     ,
					    itemlifo_out_cost     AmtTotType     );
					SELECT * into #tv_ItemGeneral from @ItemGeneral;
					ALTER TABLE #tv_ItemGeneral ADD PRIMARY KEY (whse, item, loc, lot)");
					
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @MatlType TABLE (
					    matl_type             MatlTypeType    PRIMARY KEY,
					    matl_type_description DescriptionType);
					SELECT * into #tv_MatlType from @MatlType
					ALTER TABLE #tv_MatlType ADD PRIMARY KEY (matl_type)");
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @CostType TABLE (
					    cost_type             CostTypeType    PRIMARY KEY,
					    cost_type_description DescriptionType);
					SELECT * into #tv_CostType from @CostType
					ALTER TABLE #tv_CostType ADD PRIMARY KEY (cost_type)");
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @CostMethod TABLE (
					    cost_method             CostMethodType  PRIMARY KEY,
					    cost_method_description DescriptionType);
					SELECT * into #tv_CostMethod from @CostMethod
					ALTER TABLE #tv_CostMethod ADD PRIMARY KEY (cost_method)");

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: GetCodeSp
					var GetCode = this.iGetCode.GetCodeSp(
						PClass: "item.matl_type",
						PCode: "M",
						PDesc: Description);
					Description = GetCode.PDesc;

					#endregion ExecuteMethodCall

					var nonTableLoadResponse = this.iRpt_InventoryCostCRUD.NontableSelect(Description);
					this.iRpt_InventoryCostCRUD.NontableInsert(nonTableLoadResponse);

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: GetCodeSp
					var GetCode1 = this.iGetCode.GetCodeSp(
						PClass: "item.matl_type",
						PCode: "F",
						PDesc: Description);
					Description = GetCode1.PDesc;

					#endregion ExecuteMethodCall

					var nonTable1LoadResponse = this.iRpt_InventoryCostCRUD.Nontable1Select(Description);
					this.iRpt_InventoryCostCRUD.Nontable1Insert(nonTable1LoadResponse);

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: GetCodeSp
					var GetCode2 = this.iGetCode.GetCodeSp(
						PClass: "item.matl_type",
						PCode: "T",
						PDesc: Description);
					Description = GetCode2.PDesc;

					#endregion ExecuteMethodCall

					var nonTable2LoadResponse = this.iRpt_InventoryCostCRUD.Nontable2Select(Description);
					this.iRpt_InventoryCostCRUD.Nontable2Insert(nonTable2LoadResponse);

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: GetCodeSp
					var GetCode3 = this.iGetCode.GetCodeSp(
						PClass: "item.matl_type",
						PCode: "O",
						PDesc: Description);
					Description = GetCode3.PDesc;

					#endregion ExecuteMethodCall

					var nonTable3LoadResponse = this.iRpt_InventoryCostCRUD.Nontable3Select(Description);
					this.iRpt_InventoryCostCRUD.Nontable3Insert(nonTable3LoadResponse);

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: GetCodeSp
					var GetCode4 = this.iGetCode.GetCodeSp(
						PClass: "item.cost_type",
						PCode: "A",
						PDesc: Description);
					Description = GetCode4.PDesc;

					#endregion ExecuteMethodCall

					var nonTable4LoadResponse = this.iRpt_InventoryCostCRUD.Nontable4Select(Description);
					this.iRpt_InventoryCostCRUD.Nontable4Insert(nonTable4LoadResponse);

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: GetCodeSp
					var GetCode5 = this.iGetCode.GetCodeSp(
						PClass: "item.cost_type",
						PCode: "S",
						PDesc: Description);
					Description = GetCode5.PDesc;

					#endregion ExecuteMethodCall

					var nonTable5LoadResponse = this.iRpt_InventoryCostCRUD.Nontable5Select(Description);
					this.iRpt_InventoryCostCRUD.Nontable5Insert(nonTable5LoadResponse);

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: GetCodeSp
					var GetCode6 = this.iGetCode.GetCodeSp(
						PClass: "item.cost_method",
						PCode: "C",
						PDesc: Description);
					Description = GetCode6.PDesc;

					#endregion ExecuteMethodCall

					var nonTable6LoadResponse = this.iRpt_InventoryCostCRUD.Nontable6Select(Description);
					this.iRpt_InventoryCostCRUD.Nontable6Insert(nonTable6LoadResponse);

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: GetCodeSp
					var GetCode7 = this.iGetCode.GetCodeSp(
						PClass: "item.cost_method",
						PCode: "A",
						PDesc: Description);
					Description = GetCode7.PDesc;

					#endregion ExecuteMethodCall

					var nonTable7LoadResponse = this.iRpt_InventoryCostCRUD.Nontable7Select(Description);
					this.iRpt_InventoryCostCRUD.Nontable7Insert(nonTable7LoadResponse);

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: GetCodeSp
					var GetCode8 = this.iGetCode.GetCodeSp(
						PClass: "item.cost_method",
						PCode: "L",
						PDesc: Description);
					Description = GetCode8.PDesc;

					#endregion ExecuteMethodCall

					var nonTable8LoadResponse = this.iRpt_InventoryCostCRUD.Nontable8Select(Description);
					this.iRpt_InventoryCostCRUD.Nontable8Insert(nonTable8LoadResponse);

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: GetCodeSp
					var GetCode9 = this.iGetCode.GetCodeSp(
						PClass: "item.cost_method",
						PCode: "F",
						PDesc: Description);
					Description = GetCode9.PDesc;

					#endregion ExecuteMethodCall

					var nonTable9LoadResponse = this.iRpt_InventoryCostCRUD.Nontable9Select(Description);
					this.iRpt_InventoryCostCRUD.Nontable9Insert(nonTable9LoadResponse);

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: GetCodeSp
					var GetCode10 = this.iGetCode.GetCodeSp(
						PClass: "item.cost_method",
						PCode: "S",
						PDesc: Description);
					Description = GetCode10.PDesc;

					#endregion ExecuteMethodCall

					var nonTable10LoadResponse = this.iRpt_InventoryCostCRUD.Nontable10Select(Description);
					this.iRpt_InventoryCostCRUD.Nontable10Insert(nonTable10LoadResponse);

					if (sQLUtil.SQLEqual(ExOptszStocked, "Y") == true)
					{
						TStock = 1;
					}
					else
					{
						if (sQLUtil.SQLEqual(ExOptszStocked, "N") == true)
						{
							TStock = 0;
						}
						else
						{
							TStock = null;
						}
					}
					(ParmsCurrCode, rowCount) = this.iRpt_InventoryCostCRUD.CurrparmsLoad(ParmsCurrCode);
					(CostPricePlaces, CostPriceFormat, rowCount) = this.iRpt_InventoryCostCRUD.CurrencyLoad(ParmsCurrCode, CostPriceFormat, CostPricePlaces);
					CostPriceFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
						CostPriceFormat,
						this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
					(CostItemAtWhse, rowCount) = this.iRpt_InventoryCostCRUD.Dbo_InvparmsLoad(CostItemAtWhse);
					this.iRpt_InventoryCostCRUD.SelectInsert_Tv_ItemGeneral(ProcessId, ExbegWhse, ExendWhse, ExbegLoc, ExendLoc, ExbegProductcode, ExendProductcode, ExbegItem, ExendItem, ExOptgoItemStat, ExOptgoMatlType, ExOptprPMTCode, ExOptacAbcCode, TStock, ParmsCurrCode, GetSiteDate, ExOptprPrZeroQty, CostPriceFormat, CostPricePlaces);
					this.iRpt_InventoryCostCRUD.SelectInsert1_Tv_ItemGeneral(ProcessId, ExbegWhse, ExendWhse, ExbegLoc, ExendLoc, ExbegProductcode, ExendProductcode, ExbegItem, ExendItem, ExOptgoItemStat, ExOptgoMatlType, ExOptprPMTCode, ExOptacAbcCode, TStock, ParmsCurrCode, GetSiteDate, ExOptprPrZeroQty, CostPriceFormat, CostPricePlaces);
					if (sQLUtil.SQLEqual(PrintCost, 1) == true)
					{
						if (sQLUtil.SQLEqual(CostItemAtWhse, 0) == true)
						{
							this.iRpt_InventoryCostCRUD.UpdateTmpItemGeneral0(ProcessId);
						}
						else
						{
							this.iRpt_InventoryCostCRUD.UpdateTmpItemGeneral1(ProcessId);
							this.iRpt_InventoryCostCRUD.UpdateTmpItemGeneral2(ProcessId);
						}

						this.iRpt_InventoryCostCRUD.UpdateTmpItemGeneral3(ProcessId);
					}

					//this.iRpt_InventoryCostCRUD.SelectInsert_StagingTable(ProcessId, PrintCost, CostPriceFormat, CostPricePlaces);
				}

				var tv_ItemGeneralASigLoadResponse = this.iRpt_InventoryCostCRUD.SelectBunchPageFromStaging(ProcessId,
					bunchedLoadCollection.RecordCap, bunchedLoadCollection.LoadType, PrintCost);
				Data = tv_ItemGeneralASigLoadResponse;

				int recordCap = bunchedLoadCollection.RecordCap;
				if (recordCap == -1) recordCap = 200;
				if (recordCap == 0) recordCap = int.MaxValue - 1;
				if(tv_ItemGeneralASigLoadResponse == null ||
					tv_ItemGeneralASigLoadResponse.Items.Count <= bunchedLoadCollection.RecordCap)
					this.iRpt_InventoryCostCRUD.CleanupStagingTable(ProcessId);

				return (Data, Severity);
			}
			finally
			{
				if (bunchedLoadCollection != null)
					bunchedLoadCollection.EndBunching();
			}
		}		
	}
}

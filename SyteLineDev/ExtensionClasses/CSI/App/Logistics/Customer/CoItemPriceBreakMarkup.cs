//PROJECT NAME: Logistics
//CLASS NAME: CoItemPriceBreakMarkup.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.SQL;
using CSI.Logistics.Vendor;

namespace CSI.Logistics.Customer
{
	public class CoItemPriceBreakMarkup : ICoItemPriceBreakMarkup
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ICoItemSumJobOperCosts iCoItemSumJobOperCosts;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ITransactionFactory transactionFactory;
		readonly IScalarFunction scalarFunction;
		readonly IMO_GenEstJob iMO_GenEstJob;
		readonly IConvertToUtil convertToUtil;
		readonly ICurrCnvt iCurrCnvt;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICoItemPriceBreakMarkupCRUD iCoItemPriceBreakMarkupCRUD;
		
		public CoItemPriceBreakMarkup(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ICoItemSumJobOperCosts iCoItemSumJobOperCosts,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IScalarFunction scalarFunction,
			IMO_GenEstJob iMO_GenEstJob,
			IConvertToUtil convertToUtil,
			ICurrCnvt iCurrCnvt,
			ISQLValueComparerUtil sQLUtil,
			ICoItemPriceBreakMarkupCRUD iCoItemPriceBreakMarkupCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.iCoItemSumJobOperCosts = iCoItemSumJobOperCosts;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.transactionFactory = transactionFactory;
			this.scalarFunction = scalarFunction;
			this.iMO_GenEstJob = iMO_GenEstJob;
			this.convertToUtil = convertToUtil;
			this.iCurrCnvt = iCurrCnvt;
			this.sQLUtil = sQLUtil;
			this.iCoItemPriceBreakMarkupCRUD = iCoItemPriceBreakMarkupCRUD;
		}
		
		public (
			int? ReturnCode,
			string InfoBar)
		CoItemPriceBreakMarkupSp (
			string CoNum,
			int? CoLine,
			int? VendorPriceBreaks,
			decimal? ItemQty,
			decimal? ProdCycles,
			decimal? QtyPerCycle,
			string Item,
			DateTime? DueDate,
			string Whse,
			string BOMType,
			string Resource,
			string CoProductMix,
			string AlternateID,
			string PriceBasis,
			decimal? PriceBasisValue,
			decimal? CoDisc,
			string InfoBar)
		{
			
			QtyUnitType _ItemQty = ItemQty;
			QtyUnitType _QtyPerCycle = QtyPerCycle;
			ItemType _Item = Item;
			WksBasisType _PriceBasis = PriceBasis;
			AmountType _PriceBasisValue = PriceBasisValue;
			LineDiscType _CoDisc = CoDisc;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			AmountType _MatlCost = DBNull.Value;
			AmountType _Fixture = DBNull.Value;
			decimal? Fixture = null;
			AmountType _material = DBNull.Value;
			decimal? material = null;
			AmountType _Other = DBNull.Value;
			decimal? Other = null;
			AmountType _Tool = DBNull.Value;
			decimal? Tool = null;
			decimal? SetupCost = null;
			AmountType _RunCost = DBNull.Value;
			decimal? RunCost = null;
			AmountType _FixOvhdCost = DBNull.Value;
			decimal? FixOvhdCost = null;
			AmountType _VarOvhdCost = DBNull.Value;
			decimal? VarOvhdCost = null;
			AmountType _OutSideCost = DBNull.Value;
			decimal? OutSideCost = null;
			decimal? UnitFixture = null;
			decimal? Unitmaterial = null;
			decimal? UnitOther = null;
			decimal? UnitTool = null;
			decimal? unitSetupCost = null;
			decimal? UnitRunCost = null;
			decimal? UnitFixOvhdCost = null;
			decimal? UnitVarOvhdCost = null;
			decimal? UnitOutSideCost = null;
			AmountType _Markedup = DBNull.Value;
			decimal? Markedup = null;
			decimal? UnitMarkedup = null;
			decimal? Yield = null;
			string job = null;
			int? suffix = null;
			MarkupType _ProdcodeMarkup = DBNull.Value;
			decimal? ProdcodeMarkup = null;
			int? Severity = null;
			string Site = null;
			string CurrparmsCurrCode = null;
			decimal? TRate = null;
			string CoCurrCode = null;
			DateTime? CoOrderDate = null;
			int? CoFixedRate = null;
			decimal? CoExchRate = null;
            decimal? MatlCost = null;

            if (this.iCoItemPriceBreakMarkupCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] sysname);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCoItemPriceBreakMarkupCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCoItemPriceBreakMarkupCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCoItemPriceBreakMarkupCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCoItemPriceBreakMarkupCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCoItemPriceBreakMarkupCRUD.AltExtGen_CoItemPriceBreakMarkupSp (ALTGEN_SpName,
						CoNum,
						CoLine,
						VendorPriceBreaks,
						ItemQty,
						ProdCycles,
						QtyPerCycle,
						Item,
						DueDate,
						Whse,
						BOMType,
						Resource,
						CoProductMix,
						AlternateID,
						PriceBasis,
						PriceBasisValue,
						CoDisc,
						InfoBar);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, InfoBar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCoItemPriceBreakMarkupCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCoItemPriceBreakMarkupCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CoItemPriceBreakMarkupSp") != null)
			{
				var EXTGEN = this.iCoItemPriceBreakMarkupCRUD.AltExtGen_CoItemPriceBreakMarkupSp("dbo.EXTGEN_CoItemPriceBreakMarkupSp",
					CoNum,
					CoLine,
					VendorPriceBreaks,
					ItemQty,
					ProdCycles,
					QtyPerCycle,
					Item,
					DueDate,
					Whse,
					BOMType,
					Resource,
					CoProductMix,
					AlternateID,
					PriceBasis,
					PriceBasisValue,
					CoDisc,
					InfoBar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.InfoBar);
				}
			}
			
			_MatlCost = 0;
			_Fixture = 0;
			Fixture = 0;
			_material = 0;
			material = 0;
			_Other = 0;
			Other = 0;
			_Tool = 0;
			Tool = 0;
			SetupCost = 0;
			_RunCost = 0;
			RunCost = 0;
			_FixOvhdCost = 0;
			FixOvhdCost = 0;
			_VarOvhdCost = 0;
			VarOvhdCost = 0;
			_OutSideCost = 0;
			OutSideCost = 0;
			UnitFixture = 0;
			Unitmaterial = 0;
			UnitOther = 0;
			UnitTool = 0;
			unitSetupCost = 0;
			UnitRunCost = 0;
			UnitFixOvhdCost = 0;
			UnitVarOvhdCost = 0;
			UnitOutSideCost = 0;
			_Markedup = 0;
			Markedup = 0;
			UnitMarkedup = 0;
			Yield = 0;
			_ProdcodeMarkup = 0;
			ProdcodeMarkup = 0;
			(Site, rowCount) = this.iCoItemPriceBreakMarkupCRUD.ParmsLoad(Site);
			(CurrparmsCurrCode, rowCount) = this.iCoItemPriceBreakMarkupCRUD.CurrparmsLoad(CurrparmsCurrCode);
			(CoCurrCode, CoOrderDate, CoFixedRate, CoExchRate, rowCount) = this.iCoItemPriceBreakMarkupCRUD.CoLoad(CoNum, CoCurrCode, CoOrderDate, CoFixedRate, CoExchRate);
			if (ProdCycles== null || sQLUtil.SQLEqual(ProdCycles, 0) == true)
			{
				ProdCycles = 1M;
				
			}
			if (QtyPerCycle== null || sQLUtil.SQLEqual(QtyPerCycle, 0) == true)
			{
				QtyPerCycle = 1M;
				
			}
			if (ItemQty== null || sQLUtil.SQLEqual(ItemQty, 0) == true)
			{
				ItemQty = 1M;
				
			}
			if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLEqual(BOMType, "P"), sQLUtil.SQLNot(sQLUtil.SQLEqual(CoLine, 1)))))
			{
				return (Severity, InfoBar);
			}
			else
			{
				if (sQLUtil.SQLBool(sQLUtil.SQLEqual(BOMType, "P")))
				{
					(Item, QtyPerCycle, ItemQty, rowCount) = this.iCoItemPriceBreakMarkupCRUD.Prod_MixLoad(CoProductMix, ProdCycles, ItemQty, QtyPerCycle, Item);
					if (sQLUtil.SQLBool(sQLUtil.SQLNot(this.iCoItemPriceBreakMarkupCRUD.CoitemForExists(CoNum, Item))))
					{
						/*Needs to load at least one column from the table: coitem for delete, Loads the record based on its where and from clause, then deletes it by record.*/
						var coitem1LoadResponse = this.iCoItemPriceBreakMarkupCRUD.Coitem1Select(CoNum);
						this.iCoItemPriceBreakMarkupCRUD.Coitem1Delete(coitem1LoadResponse);
						
					}
					
				}
				
			}
			if (sQLUtil.SQLBool(sQLUtil.SQLOr(sQLUtil.SQLOr((sQLUtil.SQLAnd(sQLUtil.SQLNotEqual(BOMType, "P"), this.iCoItemPriceBreakMarkupCRUD.JobForExists(BOMType, CoNum, CoLine, Item))), (sQLUtil.SQLAnd(sQLUtil.SQLEqual(BOMType, "P"), this.iCoItemPriceBreakMarkupCRUD.Job1ForExists(BOMType, CoNum, CoProductMix)))), sQLUtil.SQLNot(this.iCoItemPriceBreakMarkupCRUD.Coitem2ForExists(CoNum)))))
			{
				/*Needs to load at least one column from the table: job_price_break for delete, Loads the record based on its where and from clause, then deletes it by record.*/
				var job_price_breakLoadResponse = this.iCoItemPriceBreakMarkupCRUD.Job_Price_BreakSelect(CoNum, CoLine);
				this.iCoItemPriceBreakMarkupCRUD.Job_Price_BreakDelete(job_price_breakLoadResponse);
				/*Needs to load at least one column from the table: jobitem for delete, Loads the record based on its where and from clause, then deletes it by record.*/
				var jobitemLoadResponse = this.iCoItemPriceBreakMarkupCRUD.JobitemSelect(CoNum, CoLine);
				this.iCoItemPriceBreakMarkupCRUD.JobitemDelete(jobitemLoadResponse);
				/*Needs to load at least one column from the table: job for delete, Loads the record based on its where and from clause, then deletes it by record.*/
				var job2LoadResponse = this.iCoItemPriceBreakMarkupCRUD.Job2Select(CoNum, CoLine);
				this.iCoItemPriceBreakMarkupCRUD.Job2Delete(job2LoadResponse);
				
			}
			if (sQLUtil.SQLBool(sQLUtil.SQLNot(this.iCoItemPriceBreakMarkupCRUD.Job3ForExists(CoNum, CoLine))))
			{
				this.transactionFactory.BeginTransaction("");
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: MO_GenEstJobSp
				var MO_GenEstJob = this.iMO_GenEstJob.MO_GenEstJobSp(
					CoNum: CoNum,
					CoLine: CoLine,
					Item: Item,
					QtyOrdered: ItemQty,
					ProductCycle: convertToUtil.ToInt32(ProdCycles),
					QtyPerCycle: QtyPerCycle,
					DueDate: DueDate,
					Whse: Whse,
					BOMType: BOMType,
					CoProductMix: CoProductMix,
					AlternateID: AlternateID,
					Resource: Resource,
					Infobar: InfoBar);
				InfoBar = MO_GenEstJob.Infobar;
				
				#endregion ExecuteMethodCall
				
				this.transactionFactory.CommitTransaction("");
				
			}
			var job4LoadResponse = this.iCoItemPriceBreakMarkupCRUD.Job4Select(CoNum, CoLine);
			this.iCoItemPriceBreakMarkupCRUD.Job4Update(ProdCycles, QtyPerCycle, CoProductMix, job4LoadResponse);
			(job, suffix, PriceBasisValue, ProdcodeMarkup, CoDisc, rowCount) = this.iCoItemPriceBreakMarkupCRUD.Job5Load(CoNum, CoLine, Item, PriceBasisValue, CoDisc, job, suffix, ProdcodeMarkup);
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: CoItemSumJobOperCostsSp
			var CoItemSumJobOperCosts = this.iCoItemSumJobOperCosts.CoItemSumJobOperCostsSp(
				CoNum: CoNum,
				CoLine: CoLine,
				ProdCycles: ItemQty,
				SetupCost: SetupCost,
				RunCost: RunCost,
				FixOvhdCost: FixOvhdCost,
				VarOvhdCost: VarOvhdCost,
				OutSideCost: OutSideCost,
				InfoBar: InfoBar);
			SetupCost = CoItemSumJobOperCosts.SetupCost;
			RunCost = CoItemSumJobOperCosts.RunCost;
			FixOvhdCost = CoItemSumJobOperCosts.FixOvhdCost;
			VarOvhdCost = CoItemSumJobOperCosts.VarOvhdCost;
			OutSideCost = CoItemSumJobOperCosts.OutSideCost;
			InfoBar = CoItemSumJobOperCosts.InfoBar;

            #endregion ExecuteMethodCall

            ( MatlCost,  Fixture,  material,  Tool,  Other,  RunCost,  FixOvhdCost,  VarOvhdCost,  OutSideCost) = this.iCoItemPriceBreakMarkupCRUD.CostSelect(CoNum, CoLine, ItemQty, Item, RunCost, FixOvhdCost, VarOvhdCost, OutSideCost);
			if (sQLUtil.SQLEqual(PriceBasis, "G") == true && this.iCoItemPriceBreakMarkupCRUD.Job_Price_Break1ForExists(PriceBasis, ItemQty, job, suffix))
			{
				Markedup = this.iCoItemPriceBreakMarkupCRUD.JbpSelect(CoNum, CoLine, ItemQty, Item, Fixture, material, Other, Tool, SetupCost, RunCost, FixOvhdCost, VarOvhdCost, OutSideCost);
                

            }
			else
			{
				Markedup = this.iCoItemPriceBreakMarkupCRUD.ValSelect(PriceBasisValue, ProdcodeMarkup, OutSideCost, FixOvhdCost, VarOvhdCost, PriceBasis, SetupCost, material, RunCost, Fixture, ItemQty, CoDisc, Other, Tool, CoNum, CoLine, Item);
				
			}
			UnitFixture = convertToUtil.ToDecimal(Fixture / ItemQty);
			Unitmaterial = (decimal?)(material / ItemQty);
			UnitOther = (decimal?)(Other / ItemQty);
			UnitTool = (decimal?)(Tool / ItemQty);
			unitSetupCost = (decimal?)(SetupCost / ItemQty);
			UnitRunCost = (decimal?)(RunCost / ItemQty);
			UnitFixOvhdCost = (decimal?)(FixOvhdCost / ItemQty);
			UnitVarOvhdCost = (decimal?)(VarOvhdCost / ItemQty);
			UnitOutSideCost = (decimal?)(OutSideCost / ItemQty);
			UnitMarkedup = (decimal?)(Markedup / ItemQty);
			TRate = CoExchRate;
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: CurrCnvtSp
			var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(
				CurrCode: CoCurrCode,
				FromDomestic: 1,
				UseBuyRate: 0,
				RoundResult: 0,
				Date: CoOrderDate,
				TRate: TRate,
				Infobar: InfoBar,
				Amount1: UnitMarkedup,
				Result1: UnitMarkedup,
				Site: Site,
				DomCurrCode: CurrparmsCurrCode);
			Severity = CurrCnvt.ReturnCode;
			TRate = CurrCnvt.TRate;
			InfoBar = CurrCnvt.Infobar;
			UnitMarkedup = CurrCnvt.Result1;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				return (Severity, InfoBar);
			}
			if (sQLUtil.SQLEqual(BOMType, "P") == true)
			{
				var coitem3LoadResponse = this.iCoItemPriceBreakMarkupCRUD.Coitem3Select(CoNum);
				this.iCoItemPriceBreakMarkupCRUD.Coitem3Update(ItemQty, PriceBasis, PriceBasisValue, CoDisc, UnitFixture, Unitmaterial, UnitOther, UnitTool, unitSetupCost, UnitRunCost, UnitFixOvhdCost, UnitVarOvhdCost, UnitOutSideCost, UnitMarkedup, Yield, job, suffix, coitem3LoadResponse);
				
			}
			else
			{
				var coitem4LoadResponse = this.iCoItemPriceBreakMarkupCRUD.Coitem4Select(CoNum, CoLine);
				this.iCoItemPriceBreakMarkupCRUD.Coitem4Update(ItemQty, PriceBasis, PriceBasisValue, CoDisc, UnitFixture, Unitmaterial, UnitOther, UnitTool, unitSetupCost, UnitRunCost, UnitFixOvhdCost, UnitVarOvhdCost, UnitOutSideCost, UnitMarkedup, job, suffix, coitem4LoadResponse);
				
			}
			return (Severity, InfoBar);
			
		}
		
	}
}



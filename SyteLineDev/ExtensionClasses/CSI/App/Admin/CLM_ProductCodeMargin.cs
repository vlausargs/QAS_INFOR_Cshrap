//PROJECT NAME: Admin
//CLASS NAME: CLM_ProductCodeMargin.cs

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

namespace CSI.Admin
{
	public class CLM_ProductCodeMargin : ICLM_ProductCodeMargin
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IDefaultToLocalSite iDefaultToLocalSite;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IMidnightOf iMidnightOf;
		readonly IStringUtil stringUtil;
		readonly ILowDate iLowDate;
		readonly IMathUtil mathUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_ProductCodeMarginCRUD iCLM_ProductCodeMarginCRUD;

		public CLM_ProductCodeMargin(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IDefaultToLocalSite iDefaultToLocalSite,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IDateTimeUtil dateTimeUtil,
			IMidnightOf iMidnightOf,
			IStringUtil stringUtil,
			ILowDate iLowDate,
			IMathUtil mathUtil,
			ISQLValueComparerUtil sQLUtil,
			ICLM_ProductCodeMarginCRUD iCLM_ProductCodeMarginCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iDefaultToLocalSite = iDefaultToLocalSite;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.dateTimeUtil = dateTimeUtil;
			this.iMidnightOf = iMidnightOf;
			this.stringUtil = stringUtil;
			this.iLowDate = iLowDate;
			this.mathUtil = mathUtil;
			this.sQLUtil = sQLUtil;
			this.iCLM_ProductCodeMarginCRUD = iCLM_ProductCodeMarginCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ProductCodeMarginSp(
			string ProductCode = null,
			int? StartYear = null,
			int? EndYear = null,
			int? StartPeriod = null,
			int? EndPeriod = null,
			int? PageNum = null,
			int? EntriesPerPage = null,
			string SiteRef = null)
		{

			IntType _StartPeriod = StartPeriod;
			IntType _EndPeriod = EndPeriod;

			ICollectionLoadResponse Data = null;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			DateTime? StartDate = null;
			DateTime? EndDate = null;
			int? TotalPages = null;
			decimal? GrossExpenseAmount = null;
			decimal? GrossRevenueAmount = null;
			decimal? GrossNetAmount = null;
			if (this.iCLM_ProductCodeMarginCRUD.Optional_ModuleForExists())
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_ProductCodeMarginCRUD.Optional_Module1Select();
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_ProductCodeMarginSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCLM_ProductCodeMarginCRUD.Optional_Module1Insert(optional_module1LoadResponse);

				while (this.iCLM_ProductCodeMarginCRUD.Tv_ALTGENForExists())
				{
					//BEGIN
					ALTGEN_SpName = this.iCLM_ProductCodeMarginCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_ProductCodeMarginCRUD.AltExtGen_CLM_ProductCodeMarginSp(ALTGEN_SpName,
						ProductCode,
						StartYear,
						EndYear,
						StartPeriod,
						EndPeriod,
						PageNum,
						EntriesPerPage,
						SiteRef);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_ProductCodeMarginCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_ProductCodeMarginCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					//END

				}
				//END

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ProductCodeMarginSp") != null)
			{
				var EXTGEN = this.iCLM_ProductCodeMarginCRUD.AltExtGen_CLM_ProductCodeMarginSp("dbo.EXTGEN_CLM_ProductCodeMarginSp",
					ProductCode,
					StartYear,
					EndYear,
					StartPeriod,
					EndPeriod,
					PageNum,
					EntriesPerPage,
					SiteRef);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			SiteRef = stringUtil.Coalesce<string>(SiteRef, this.iDefaultToLocalSite.DefaultToLocalSiteFn(SiteRef));
			if (StartYear == null)
			{
				StartYear = (int?)(dateTimeUtil.Year<int?>(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE"))));

			}
			if (EndYear == null)
			{
				EndYear = (int?)(dateTimeUtil.Year<int?>(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE") + TimeSpan.FromDays(1))));

			}
			if (StartPeriod == null)
			{
				StartPeriod = this.iCLM_ProductCodeMarginCRUD.PeriodsallviewaspvLoad(SiteRef, StartPeriod);

			}
			if (EndPeriod == null)
			{
				EndPeriod = this.iCLM_ProductCodeMarginCRUD.Periodsallviewaspv1Load(SiteRef, EndPeriod);

			}
			if (ProductCode == null)
			{
				ProductCode = "%";

			}
			StartDate = this.iCLM_ProductCodeMarginCRUD.Periodsallviewaspv2Load(StartYear, StartPeriod, SiteRef, StartDate);
			EndDate = this.iCLM_ProductCodeMarginCRUD.Periodsallviewaspv3Load(EndYear, EndPeriod, SiteRef, EndDate);
			if (StartDate == null)
			{
				StartDate = convertToUtil.ToDateTime(this.iLowDate.LowDateFn());

			}
			if (EndDate == null)
			{
				EndDate = convertToUtil.ToDateTime(scalarFunction.Execute<DateTime>("GETDATE"));

			}
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @PoductCodeAmounts TABLE (
				    ProductCode   ProductCodeType,
				    Description   DescriptionType,
				    ExpenseAmount AmountType     ,
				    RevenueAmount AmountType     ,
				    NetAmount     AmountType     ,
				    Margin        AmountType     ,
				    TotalPages    INT            );
				SELECT * into #tv_PoductCodeAmounts from @PoductCodeAmounts");
			PageNum = (int?)(stringUtil.IsNull(
				PageNum,
				1));
			EntriesPerPage = (int?)(stringUtil.IsNull(
				EntriesPerPage,
				5));
			TotalPages = 1;
			var tv_PoductCodeAmountsLoadResponse = this.iCLM_ProductCodeMarginCRUD.Tv_PoductcodeamountsSelect(TotalPages, SiteRef, StartDate, EndDate);
			this.iCLM_ProductCodeMarginCRUD.Tv_PoductcodeamountsInsert(tv_PoductCodeAmountsLoadResponse);

			(GrossExpenseAmount, GrossRevenueAmount, GrossNetAmount) = this.iCLM_ProductCodeMarginCRUD.Tv_Poductcodeamounts1Load(GrossExpenseAmount, GrossRevenueAmount, GrossNetAmount);
			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_PoductCodeAmounts ADD tempTableId INT IDENTITY");
			var tv_PoductCodeAmounts2LoadResponse = this.iCLM_ProductCodeMarginCRUD.Tv_Poductcodeamounts2Select(ProductCode);
			this.iCLM_ProductCodeMarginCRUD.Tv_Poductcodeamounts2Update(GrossNetAmount, tv_PoductCodeAmounts2LoadResponse);
			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_PoductCodeAmounts DROP COLUMN tempTableId");
			var tv_PoductCodeAmounts3LoadResponseForScalarSubQuery = this.iCLM_ProductCodeMarginCRUD.Tv_Poductcodeamounts3Select(ProductCode, EntriesPerPage);
			Data = tv_PoductCodeAmounts3LoadResponseForScalarSubQuery;

			TotalPages = (int?)(stringUtil.IsNull<int?>(
				((tv_PoductCodeAmounts3LoadResponseForScalarSubQuery.Items != null &&
						tv_PoductCodeAmounts3LoadResponseForScalarSubQuery.Items.Count != 0) ?
					(tv_PoductCodeAmounts3LoadResponseForScalarSubQuery.Items.FirstOrDefault().GetValue<int?>("col0")) : null),
				1));
			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_PoductCodeAmounts ADD tempTableId INT IDENTITY");
			var tv_PoductCodeAmounts4LoadResponse = this.iCLM_ProductCodeMarginCRUD.Tv_Poductcodeamounts4Select(ProductCode);
			this.iCLM_ProductCodeMarginCRUD.Tv_Poductcodeamounts4Update(TotalPages, tv_PoductCodeAmounts4LoadResponse);
			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_PoductCodeAmounts DROP COLUMN tempTableId");
			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_PoductCodeAmounts ADD tempTableId INT IDENTITY");
			/*Needs to load at least one column from the table: #tv_PoductCodeAmounts for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var tv_PoductCodeAmounts5LoadResponse = this.iCLM_ProductCodeMarginCRUD.Tv_Poductcodeamounts5Select(EntriesPerPage, PageNum, ProductCode);
			this.iCLM_ProductCodeMarginCRUD.Tv_Poductcodeamounts5Delete(tv_PoductCodeAmounts5LoadResponse);
			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_PoductCodeAmounts DROP COLUMN tempTableId");
			var tv_PoductCodeAmounts6LoadResponse = this.iCLM_ProductCodeMarginCRUD.Tv_Poductcodeamounts6Select(ProductCode, EntriesPerPage);
			Data = tv_PoductCodeAmounts6LoadResponse;

			return (Data, Severity);
		}

	}
}

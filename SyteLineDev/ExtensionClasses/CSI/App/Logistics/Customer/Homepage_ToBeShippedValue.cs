//PROJECT NAME: Logistics
//CLASS NAME: Homepage_ToBeShippedValue.cs

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
using CSI.Finance;

namespace CSI.Logistics.Customer
{
	public class Homepage_ToBeShippedValue : IHomepage_ToBeShippedValue
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IDefaultToLocalSite iDefaultToLocalSite;
		readonly ITransactionFactory transactionFactory;
		readonly IPeriodsGetDates iPeriodsGetDates;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IStringUtil stringUtil;
		readonly IMathUtil mathUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IPerGet iPerGet;
		readonly ICurrCnvtSingleAmt2 iCurrCnvtSingleAmt2;
		readonly IHomepage_ToBeShippedValueCRUD iHomepage_ToBeShippedValueCRUD;

		public Homepage_ToBeShippedValue(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IDefaultToLocalSite iDefaultToLocalSite,
			ITransactionFactory transactionFactory,
			IPeriodsGetDates iPeriodsGetDates,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IStringUtil stringUtil,
			IMathUtil mathUtil,
			ISQLValueComparerUtil sQLUtil,
			IPerGet iPerGet,
			ICurrCnvtSingleAmt2 iCurrCnvtSingleAmt2,
			IHomepage_ToBeShippedValueCRUD iHomepage_ToBeShippedValueCRUD)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iDefaultToLocalSite = iDefaultToLocalSite;
			this.transactionFactory = transactionFactory;
			this.iPeriodsGetDates = iPeriodsGetDates;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.stringUtil = stringUtil;
			this.mathUtil = mathUtil;
			this.sQLUtil = sQLUtil;
			this.iPerGet = iPerGet;
			this.iCurrCnvtSingleAmt2 = iCurrCnvtSingleAmt2;
			this.iHomepage_ToBeShippedValueCRUD = iHomepage_ToBeShippedValueCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Homepage_ToBeShippedValueSp()
		{

			ICollectionLoadResponse Data = null;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			DateTime? StartDate = null;
			int? Severity = null;
			string Infobar = null;
			int? PeriodsFiscalYear = null;
			int? CurrentPeriod = null;
			string SiteRef = null;
			DateTime? PerStart = null;
			DateTime? PerEnd = null;
			string DomCurrCode = null;
			int? Places = null;
			if (this.iHomepage_ToBeShippedValueCRUD.Optional_ModuleForExists())
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iHomepage_ToBeShippedValueCRUD.Optional_Module1Select();
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Homepage_ToBeShippedValueSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iHomepage_ToBeShippedValueCRUD.Optional_Module1Insert(optional_module1LoadResponse);

				while (this.iHomepage_ToBeShippedValueCRUD.Tv_ALTGENForExists())
				{
					//BEGIN
					var tv_ALTGEN1Load = this.iHomepage_ToBeShippedValueCRUD.Tv_ALTGEN1Load();
					ALTGEN_SpName = tv_ALTGEN1Load;
					var ALTGEN = this.iHomepage_ToBeShippedValueCRUD.AltExtGen_Homepage_ToBeShippedValueSp(ALTGEN_SpName);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iHomepage_ToBeShippedValueCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iHomepage_ToBeShippedValueCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					//END

				}
				//END

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_ToBeShippedValueSp") != null)
			{
				var EXTGEN = this.iHomepage_ToBeShippedValueCRUD.AltExtGen_Homepage_ToBeShippedValueSp("dbo.EXTGEN_Homepage_ToBeShippedValueSp");
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			StartDate = convertToUtil.ToDateTime(scalarFunction.Execute<DateTime>("GETDATE"));
			Severity = 0;
			Infobar = null;
			SiteRef = this.iDefaultToLocalSite.DefaultToLocalSiteFn(SiteRef);
			var currparmsLoad = this.iHomepage_ToBeShippedValueCRUD.CurrparmsLoad();
			DomCurrCode = currparmsLoad;
			var currencyLoad = this.iHomepage_ToBeShippedValueCRUD.CurrencyLoad(DomCurrCode);
			Places = currencyLoad;

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: PerGetSp
			var PerGet = this.iPerGet.PerGetSp(
				Date: StartDate,
				CurrentPeriod: CurrentPeriod,
				Infobar: Infobar,
				Site: SiteRef,
				PeriodsFiscalYear: PeriodsFiscalYear);
			Severity = PerGet.ReturnCode;
			CurrentPeriod = PerGet.CurrentPeriod;
			Infobar = PerGet.Infobar;
			PeriodsFiscalYear = PerGet.PeriodsFiscalYear;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: PeriodsGetDatesSp
			var PeriodsGetDates = this.iPeriodsGetDates.PeriodsGetDatesSp(
				FiscalYear: PeriodsFiscalYear,
				Period: CurrentPeriod,
				Site: SiteRef,
				PerStart: PerStart,
				PerEnd: PerEnd,
				Infobar: Infobar);
			Severity = PeriodsGetDates.ReturnCode;
			PerStart = PeriodsGetDates.PerStart;
			PerEnd = PeriodsGetDates.PerEnd;
			Infobar = PeriodsGetDates.Infobar;

			#endregion ExecuteMethodCall

			var coitemLoadResponse = this.iHomepage_ToBeShippedValueCRUD.CoitemSelect(Severity, StartDate, CurrentPeriod, Infobar, SiteRef, PeriodsFiscalYear, PerStart, PerEnd, DomCurrCode, Places);


			decimal? sumValue = 0;  //temp varaible to handle the adding value from loop below.
			foreach (var coitemItem in coitemLoadResponse.Items)
			{
				//Each calculated value will be added into this varaible sumValue
				sumValue = sumValue + mathUtil.Round<decimal?>((sQLUtil.SQLEqual(coitemItem.GetValue<string>("u0"), DomCurrCode) == true ? mathUtil.Round<decimal?>(coitemItem.GetValue<decimal?>("u1"), Places) : this.iCurrCnvtSingleAmt2.CurrCnvtSingleAmt2Fn(
							coitemItem.GetValue<string>("u0"),
							0,
							0,
							1,
							null,
							2,
							0,
							1,
							coitemItem.GetValue<decimal?>("u2"),
							null,
							DomCurrCode,
							0,
							coitemItem.GetValue<decimal?>("u1"))) * (coitemItem.GetValue<decimal?>("u3") - coitemItem.GetValue<decimal?>("u4")), Places);
			};
			sumValue = stringUtil.Coalesce<decimal?>(sumValue, 0.0M);
			#region CRUD LoadResponseWithoutTable
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "col0", sumValue},
			});

			var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
			#endregion CRUD LoadResponseWithoutTable

			Data = nonTableLoadResponse;

			return (Data, Severity);

		}

	}
}

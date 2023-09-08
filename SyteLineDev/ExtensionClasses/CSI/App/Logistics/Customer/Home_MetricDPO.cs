//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricDPO.cs

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
using CSI.Logistics.Vendor;
using CSI.Finance;
using CSI.Data.Utilities;

namespace CSI.Logistics.Customer
{
	public class Home_MetricDPO : IHome_MetricDPO
	{
		
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ITransactionFactory transactionFactory;
		readonly IPeriodsGetDates iPeriodsGetDates;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IGetSiteDate iGetSiteDate;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IMidnightOf iMidnightOf;
		readonly IStringUtil stringUtil;
		readonly IDayEndOf iDayEndOf;
		readonly ICurrCnvt iCurrCnvt;
		readonly ILowDate iLowDate;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IPerGet iPerGet;
		readonly IHome_MetricDPOCRUD iHome_MetricDPOCRUD;
		
		public Home_MetricDPO(ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IPeriodsGetDates iPeriodsGetDates,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IGetSiteDate iGetSiteDate,
			IDateTimeUtil dateTimeUtil,
			IMidnightOf iMidnightOf,
			IStringUtil stringUtil,
			IDayEndOf iDayEndOf,
			ICurrCnvt iCurrCnvt,
			ILowDate iLowDate,
			ISQLValueComparerUtil sQLUtil,
			IPerGet iPerGet,
			IHome_MetricDPOCRUD iHome_MetricDPOCRUD)
		{
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.transactionFactory = transactionFactory;
			this.iPeriodsGetDates = iPeriodsGetDates;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.iGetSiteDate = iGetSiteDate;
			this.dateTimeUtil = dateTimeUtil;
			this.iMidnightOf = iMidnightOf;
			this.stringUtil = stringUtil;
			this.iDayEndOf = iDayEndOf;
			this.iCurrCnvt = iCurrCnvt;
			this.iLowDate = iLowDate;
			this.sQLUtil = sQLUtil;
			this.iPerGet = iPerGet;
			this.iHome_MetricDPOCRUD = iHome_MetricDPOCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Home_MetricDPOSp (
			int? MultipleSites = 0,
			string SiteGroup = null,
			int? NumPeriods = 6)
		{
			
			ICollectionLoadResponse Data = null;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			string Infobar = null;
			string DomCurrCode = null;
			DateTime? Today = null;
			int? CurrentPeriod = null;
			int? PeriodsFiscalYear = null;
			SiteType _Site = DBNull.Value;
			string Site = null;
			DateTime? PerStart = null;
			DateTime? PerEnd = null;
			int? PerDays = null;
			FinPeriodType _i = DBNull.Value;
			int? i = null;
			int? FirstFlag = null;
			DateTime? CutoffDate = null;
			DateTime? LastDate = null;
			decimal? APAmt = null;
			decimal? ExchRate = null;
			string ExchRateCurrCode = null;
			string ExchRateSite = null;
			DateTime? LowDate = null;
			ICollectionLoadResponse erCrsLoadResponseForCursor = null;
			int erCrs_CursorFetch_Status = -1;
			int erCrs_CursorCounter = -1;
			if (this.iHome_MetricDPOCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");

				this.iHome_MetricDPOCRUD.Optional_Module1Insert();

				while (this.iHome_MetricDPOCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iHome_MetricDPOCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iHome_MetricDPOCRUD.AltExtGen_Home_MetricDPOSp (ALTGEN_SpName,
						MultipleSites,
						SiteGroup,
						NumPeriods);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.iHome_MetricDPOCRUD.Tv_ALTGEN2Delete(ALTGEN_SpName);
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_MetricDPOSp") != null)
			{
				var EXTGEN = this.iHome_MetricDPOCRUD.AltExtGen_Home_MetricDPOSp("dbo.EXTGEN_Home_MetricDPOSp",
					MultipleSites,
					SiteGroup,
					NumPeriods);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			if (MultipleSites== null)
			{
				MultipleSites = 0;
				
			}
			if (NumPeriods== null)
			{
				NumPeriods = 6;
				
			}
			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			
			this.sQLExpressionExecutor.Execute(@"SELECT site_ref,
				       curr_code,
				       exch_rate,
				       fixed_rate,
				       inv_amt AS vch_amt,
				       inv_amt AS pay_amt,
				       inv_date AS per_start
				INTO   #voucher
				FROM   aptrxp_all WITH (READUNCOMMITTED)
				WHERE  1 = 2");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @VendSiteVar TABLE (
				    VendNum      VendNumType ,
				    SiteRef      SiteType    ,
				    VendCurrCode CurrCodeType,
				    PRIMARY KEY (VendNum, SiteRef));
				SELECT * into #tv_VendSiteVar from @VendSiteVar
				ALTER TABLE #tv_VendSiteVar ADD PRIMARY KEY (VendNum, SiteRef)");
			
			this.sQLExpressionExecutor.Execute(@"SELECT curr_code AS FromCurrCode,
				       site_ref AS SiteRef,
				       euro_rate AS ExchRate,
				       places AS Places,
				       rate_is_divisor AS RateIsDivisor
				INTO   #ExchRates
				FROM   currency_all WITH (READUNCOMMITTED)
				WHERE  1 = 2");
			this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX ExchRatesCurrSite
				    ON #ExchRates(FromCurrCode, SiteRef)");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @Sites TABLE (
				    site SiteType);
				SELECT * into #tv_Sites from @Sites");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @periods TABLE (
				    per_start DateType  ,
				    per_end   DateType  ,
				    seq       INT       ,
				    inv_amt   AmtTotType,
				    pay_amt   AmtTotType,
				    num_days  INT        PRIMARY KEY (per_start, per_end));
				SELECT * into #tv_periods from @periods
				ALTER TABLE #tv_periods ADD PRIMARY KEY (per_start, per_end)");
			Severity = 0;
			Today = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE"))));
			LowDate = convertToUtil.ToDateTime(this.iLowDate.LowDateFn());
			(Site, rowCount) = this.iHome_MetricDPOCRUD.ParmsLoad(Site);
			DomCurrCode = null;
			if (sQLUtil.SQLEqual(MultipleSites, 0) == true)
			{
				this.iHome_MetricDPOCRUD.NontableInsert(Site);
				(DomCurrCode, rowCount) = this.iHome_MetricDPOCRUD.CurrparmsLoad(DomCurrCode);
			}
			else
			{
				this.iHome_MetricDPOCRUD.SitesInsert(SiteGroup);
				(DomCurrCode, rowCount) = this.iHome_MetricDPOCRUD.Currparms_AllLoad(DomCurrCode);
				
			}
			this.iHome_MetricDPOCRUD.VendsitevarInsert();
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: PerGetSp
			var PerGet = this.iPerGet.PerGetSp(
				Date: Today,
				CurrentPeriod: CurrentPeriod,
				Infobar: Infobar,
				Site: Site,
				PeriodsFiscalYear: PeriodsFiscalYear);
			Severity = PerGet.ReturnCode;
			CurrentPeriod = PerGet.CurrentPeriod;
			Infobar = PerGet.Infobar;
			PeriodsFiscalYear = PerGet.PeriodsFiscalYear;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLGreaterThan(Severity, 0) == true)
			{
				goto EOF;
				
			}
			NumPeriods = (int?)(stringUtil.IsNull(
				NumPeriods,
				6));
			FirstFlag = 0;
			i = NumPeriods;

            var unionUtil = new UnionUtil(UnionType.UnionAll);

            while (sQLUtil.SQLGreaterThan(i, 0) == true)
			{
				PerStart = null;
				CurrentPeriod = (int?)(CurrentPeriod - 1);
				if (sQLUtil.SQLEqual(CurrentPeriod, 0) == true)
				{
					if (sQLUtil.SQLEqual(FirstFlag, 1) == true)
					{
						
						break;
						
					}
					CurrentPeriod = 13;
					PeriodsFiscalYear = (int?)(PeriodsFiscalYear - 1);
					FirstFlag = 1;
					
				}
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: PeriodsGetDatesSp
				var PeriodsGetDates = this.iPeriodsGetDates.PeriodsGetDatesSp(
					FiscalYear: PeriodsFiscalYear,
					Period: CurrentPeriod,
					Site: Site,
					PerStart: PerStart,
					PerEnd: PerEnd,
					Infobar: Infobar);
				Severity = PeriodsGetDates.ReturnCode;
				PerStart = PeriodsGetDates.PerStart;
				PerEnd = PeriodsGetDates.PerEnd;
				Infobar = PeriodsGetDates.Infobar;
				
				#endregion ExecuteMethodCall
				
				if (PerStart!= null)
				{
					PerStart = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(PerStart));
					PerEnd = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(PerEnd));
					PerDays = (int?)(dateTimeUtil.DateDiff("Day",PerStart,PerEnd) + 1);

                    var nonTable1LoadResponse = this.iHome_MetricDPOCRUD.Nontable1Select(PerStart, PerEnd, i, PerDays);
                    unionUtil.Add(nonTable1LoadResponse);

                    i = (int?)(i - 1);
					FirstFlag = 0;
				}
			}

            var nonTable1LoadResponseUnionAll = unionUtil.Process();
            this.iHome_MetricDPOCRUD.Nontable1Insert(nonTable1LoadResponseUnionAll);

            if (sQLUtil.SQLBool(sQLUtil.SQLNot(this.iHome_MetricDPOCRUD.Tv_PeriodsForExists())))
			{
				goto EOF;
				
			}
			var tv_periods1LoadResponseForScalarSubQuery = this.iHome_MetricDPOCRUD.Tv_Periods1Select();
			
			CutoffDate = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day",-1,((tv_periods1LoadResponseForScalarSubQuery.Items != null &&
							tv_periods1LoadResponseForScalarSubQuery.Items.Count != 0) ?
						(tv_periods1LoadResponseForScalarSubQuery.Items.FirstOrDefault().GetValue<DateTime?>("per_start")) : null))));
			(LastDate, rowCount) = this.iHome_MetricDPOCRUD.Tv_Periods2Load(LastDate);
			this.iHome_MetricDPOCRUD.Voucher1Insert(CutoffDate, LastDate, LowDate);
			
			this.iHome_MetricDPOCRUD.Exchrates1Insert();
			
			#region Cursor Statement
			erCrsLoadResponseForCursor = this.iHome_MetricDPOCRUD.Exchrates2Select();
			erCrs_CursorFetch_Status = erCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			erCrs_CursorCounter = -1;
			
			#endregion Cursor Statement
			while (sQLUtil.SQLEqual(Severity, 0) == true)
			{
				erCrs_CursorCounter++;
				if(erCrsLoadResponseForCursor.Items.Count > erCrs_CursorCounter)
				{
					ExchRateCurrCode = erCrsLoadResponseForCursor.Items[erCrs_CursorCounter].GetValue<string>(0);
					ExchRateSite = erCrsLoadResponseForCursor.Items[erCrs_CursorCounter].GetValue<string>(1);
				}
				erCrs_CursorFetch_Status = (erCrs_CursorCounter == erCrsLoadResponseForCursor.Items.Count ? -1 : 0);
				
				if (sQLUtil.SQLNotEqual(erCrs_CursorFetch_Status, 0) == true)
				{
					
					break;
					
				}
				ExchRate = null;
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: CurrCnvtSp
				var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(
					CurrCode: ExchRateCurrCode,
					FromDomestic: 0,
					UseBuyRate: 1,
					RoundResult: 1,
					Date: Today,
					TRate: ExchRate,
					Infobar: Infobar,
					Amount1: 0,
					Result1: null,
					Site: ExchRateSite,
					DomCurrCode: DomCurrCode);
				Severity = CurrCnvt.ReturnCode;
				ExchRate = CurrCnvt.TRate;
				Infobar = CurrCnvt.Infobar;
				
				#endregion ExecuteMethodCall
				
				this.iHome_MetricDPOCRUD.Exchrates3Update(ExchRateCurrCode, ExchRateSite, ExchRate);
				
			}
			//Deallocate Cursor erCrs
			this.iHome_MetricDPOCRUD.Voucher2Update();

			(APAmt, rowCount) = this.iHome_MetricDPOCRUD.Voucher3Load(LowDate, APAmt);
			this.iHome_MetricDPOCRUD.Tv_Periods3Update();

			EOF: ;
			var tv_periods4LoadResponse = this.iHome_MetricDPOCRUD.Tv_Periods4Select(APAmt);
			Data = tv_periods4LoadResponse;
			
			return (Data, Severity);
			
		}
		
	}
}

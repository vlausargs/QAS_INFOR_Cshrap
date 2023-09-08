//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricDPOCRUD.cs

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

namespace CSI.Logistics.Customer
{
	public class Home_MetricDPOCRUD : IHome_MetricDPOCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly IMathUtil mathUtil;
		readonly ISQLValueComparerUtil sQLUtil;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory;
        readonly ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory;
        readonly ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory;


        public Home_MetricDPOCRUD(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			IMathUtil mathUtil,
			ISQLValueComparerUtil sQLUtil,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory,
            ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory,
            ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory
            )
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.mathUtil = mathUtil;
			this.sQLUtil = sQLUtil;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.collectionNonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
            this.collectionNonTriggerUpdateRequestFactory = collectionNonTriggerUpdateRequestFactory;
            this.collectionNonTriggerDeleteRequestFactory = collectionNonTriggerDeleteRequestFactory;
        }

        public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_MetricDPOSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}
		
		public void Optional_Module1Insert()
		{
            var optional_module1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#tv_Sites",
                targetColumns: new List<string>()
                {
                    { "SpName" },
                },
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                    { "SpName" , collectionNonTriggerInsertRequestFactory.Clause(" QUOTENAME(OBJECT_NAME(@@PROCID) + CHAR(95) + [om].[ModuleName])")}
                },
                fromClause: collectionNonTriggerInsertRequestFactory.Clause(" [optional_module] [om]"),
                whereClause: collectionNonTriggerInsertRequestFactory.Clause(" ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME(OBJECT_NAME(@@PROCID) + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                );

            this.appDB.InsertWithoutTrigger(optional_module1NonTriggerInsertRequest);
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
		
		public void Tv_ALTGEN2Delete(string ALTGEN_SpName)
		{
            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");

            var tv_ALTGEN2NonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                tableName: "#tv_ALTGEN",
                fromClause: collectionNonTriggerDeleteRequestFactory.Clause(""),
                whereClause: collectionNonTriggerDeleteRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName)
                );

            this.appDB.DeleteWithoutTrigger(tv_ALTGEN2NonTriggerDeleteRequest);

            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

        }
		
		public (string Site, int? rowCount) ParmsLoad(string Site)
		{
			SiteType _Site = DBNull.Value;
			
			var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_Site,"site"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"parms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
			if(parmsLoadResponse.Items.Count > 0)
			{
				Site = _Site;
			}
			
			int rowCount = parmsLoadResponse.Items.Count;
			return (Site, rowCount);
		}

		public void NontableInsert(string Site)
		{
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "site", Site},
            });

            var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);

            var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Sites",
                items: nonTableLoadResponse.Items);

            this.appDB.Insert(nonTableInsertRequest);
        }

        public (string DomCurrCode, int? rowCount) CurrparmsLoad(string DomCurrCode)
		{
			CurrCodeType _DomCurrCode = DBNull.Value;
			
			var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_DomCurrCode,"curr_code"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"currparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
			if(currparmsLoadResponse.Items.Count > 0)
			{
				DomCurrCode = _DomCurrCode;
			}
			
			int rowCount = currparmsLoadResponse.Items.Count;
			return (DomCurrCode, rowCount);
		}
		
		public void SitesInsert(string SiteGroup)
        {
            var SitesNonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#tv_Sites",
                targetColumns: new List<string>()
                {
                    { "site" },
                },
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                    { "site" , collectionNonTriggerInsertRequestFactory.Clause("site")}
                },
                fromClause: collectionNonTriggerInsertRequestFactory.Clause(" site_group"),
                whereClause: collectionNonTriggerInsertRequestFactory.Clause(" site_group.site_group = {0}", SiteGroup),
                orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                );

            this.appDB.InsertWithoutTrigger(SitesNonTriggerInsertRequest);
        }

        public (string DomCurrCode, int? rowCount) Currparms_AllLoad(string DomCurrCode)
		{
			CurrCodeType _DomCurrCode = DBNull.Value;
			
			var currparms_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_DomCurrCode,"currparms_all.curr_code"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"currparms_all",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("currparms_all.site_ref IN (SELECT site FROM #tv_Sites)"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currparms_allLoadResponse = this.appDB.Load(currparms_allLoadRequest);
			if(currparms_allLoadResponse.Items.Count > 0)
			{
				DomCurrCode = _DomCurrCode;
			}
			
			int rowCount = currparms_allLoadResponse.Items.Count;
			return (DomCurrCode, rowCount);
		}		
		
		public void VendsitevarInsert()
		{
            var VendSiteVarNonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#tv_VendSiteVar",
                targetColumns: new List<string>()
                {
                    {"VendNum"},
                    {"SiteRef"},
                    {"VendCurrCode"},
                },
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                    { "VendNum" , collectionNonTriggerInsertRequestFactory.Clause("vendor_all.vend_num")},
                    { "SiteRef" , collectionNonTriggerInsertRequestFactory.Clause("vendor_all.site_ref")},
                    { "VendCurrCode" , collectionNonTriggerInsertRequestFactory.Clause("vendor_all.curr_code")}
                },
                fromClause: collectionNonTriggerInsertRequestFactory.Clause("vendor_all WITH (READUNCOMMITTED) INNER JOIN #tv_Sites AS sit ON sit.site = vendor_all.site_ref"),
                whereClause: collectionNonTriggerInsertRequestFactory.Clause(""),
                orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                );

            this.appDB.InsertWithoutTrigger(VendSiteVarNonTriggerInsertRequest);
        }

        public ICollectionLoadResponse Nontable1Select(DateTime? PerStart, DateTime? PerEnd, int? i, int? PerDays)
        {
            var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "per_start", PerStart},
                    { "per_end", PerEnd},
                    { "seq", i},
                    { "inv_amt", 0},
                    { "pay_amt", 0},
                    { "num_days", PerDays},
            });

            return this.appDB.Load(nonTable1LoadRequest);
        }

        public void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse)
        {
            var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_periods",
                items: nonTable1LoadResponse.Items);

            this.appDB.Insert(nonTable1InsertRequest);
        }
		
		public bool Tv_PeriodsForExists()
		{
			return existsChecker.Exists(tableName:"#tv_periods",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""));
		}
		
		public ICollectionLoadResponse Tv_Periods1Select()
		{
			var tv_periods1LoadRequestForScalarSubQuery = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"per_start","per_start"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"#tv_periods",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("seq = 1"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_periods1LoadRequestForScalarSubQuery);
		}
		
		public (DateTime? LastDate, int? rowCount) Tv_Periods2Load(DateTime? LastDate)
		{
			DateType _LastDate = DBNull.Value;
			
			var tv_periods2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_LastDate,"per_end"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName:"#tv_periods",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" seq DESC"));
			
			var tv_periods2LoadResponse = this.appDB.Load(tv_periods2LoadRequest);
			if(tv_periods2LoadResponse.Items.Count > 0)
			{
				LastDate = _LastDate;
			}
			
			int rowCount = tv_periods2LoadResponse.Items.Count;
			return (LastDate, rowCount);
		}

		public void Voucher1Insert(DateTime? CutoffDate, DateTime? LastDate, DateTime? LowDate)
        {
            var voucher1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#voucher",
                targetColumns: new List<string>()
                {
                           { "site_ref" },
                           { "curr_code" },
                           { "exch_rate" },
                           { "fixed_rate" },
                           { "vch_amt" },
                           { "pay_amt" },
                           { "per_start" },
                },
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                           { "site_ref", collectionNonTriggerInsertRequestFactory.Clause("aptrxp.site_ref") },
                           { "curr_code", collectionNonTriggerInsertRequestFactory.Clause("aptrxp.curr_code") },
                           { "exch_rate", collectionNonTriggerInsertRequestFactory.Clause("aptrxp.exch_rate") },
                           { "fixed_rate", collectionNonTriggerInsertRequestFactory.Clause("aptrxp.fixed_rate") },
                           { "vch_amt", collectionNonTriggerInsertRequestFactory.Clause($"sum(CASE WHEN inv_date <= {variableUtil.GetQuotedValue<DateTime?>(CutoffDate)} THEN CASE WHEN aptrxp.type = 'P' THEN -(aptrxp.amt_paid + aptrxp.amt_disc) ELSE aptrxp.inv_amt END WHEN aptrxp.type = 'P' THEN 0 ELSE aptrxp.inv_amt END)") },
                           { "pay_amt", collectionNonTriggerInsertRequestFactory.Clause("sum(CASE WHEN type != 'P' THEN 0 ELSE (aptrxp.amt_paid + aptrxp.amt_disc) END)") },
                           { "per_start", collectionNonTriggerInsertRequestFactory.Clause($"isnull(per.per_start, {variableUtil.GetQuotedValue<DateTime?>(LowDate)})") },
                },
                fromClause: collectionNonTriggerInsertRequestFactory.Clause(@" aptrxp_all aptrxp 
                    INNER JOIN #tv_Sites AS sit ON sit.site = aptrxp.site_ref
                    LEFT OUTER JOIN #tv_periods AS per ON per.per_start <= aptrxp.inv_date AND per.per_end >= aptrxp.inv_date
                    INNER JOIN #tv_VendSiteVar AS VendSiteVar ON VendSiteVar.SiteRef = aptrxp.site_ref AND VendSiteVar.VendNum = aptrxp.vend_num "),
                whereClause: collectionNonTriggerInsertRequestFactory.Clause($" aptrxp.active = 1 AND aptrxp.inv_date <= {variableUtil.GetQuotedValue<DateTime?>(LastDate)} AND aptrxp.type IN('V', 'A', 'P') group by aptrxp.site_ref, aptrxp.curr_code, per.per_start, aptrxp.exch_rate, aptrxp.fixed_rate"),
                orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                );

            this.appDB.InsertWithoutTrigger(voucher1NonTriggerInsertRequest);
        }
		
		public void Exchrates1Insert()
		{

            var voucher1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#ExchRates",
                targetColumns: new List<string>()
                {
                           { "FromCurrCode" },
                           { "SiteRef" },
                           { "ExchRate" },
                           { "Places" },
                           { "RateIsDivisor" },
                },
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                           { "FromCurrCode", collectionNonTriggerInsertRequestFactory.Clause("distinct vch.curr_code") },
                           { "SiteRef", collectionNonTriggerInsertRequestFactory.Clause("vch.site_ref") },
                           { "ExchRate", collectionNonTriggerInsertRequestFactory.Clause("0") },
                           { "Places", collectionNonTriggerInsertRequestFactory.Clause("currency_all.places") },
                           { "RateIsDivisor", collectionNonTriggerInsertRequestFactory.Clause("currency_all.rate_is_divisor") },
                },
                fromClause: collectionNonTriggerInsertRequestFactory.Clause(@" #voucher AS vch
            INNER JOIN
            currency_all WITH (READUNCOMMITTED)
            ON currency_all.curr_code = vch.curr_code
            AND currency_all.site_ref = vch.site_ref"),
                whereClause: collectionNonTriggerInsertRequestFactory.Clause(@" (vch.fixed_rate = 0
                               OR vch.exch_rate IS NULL)
                               AND NOT EXISTS(SELECT 1
                               FROM   #ExchRates AS er
            	WHERE  er.FromCurrCode = vch.curr_code
                               AND er.SiteRef = vch.site_ref)"),
                orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                );

            this.appDB.InsertWithoutTrigger(voucher1NonTriggerInsertRequest);
        }

        public ICollectionLoadResponse Exchrates2Select()
		{
			var erCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"FromCurrCode","FromCurrCode"},
					{"SiteRef","SiteRef"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"#ExchRates",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("ExchRate = 0"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var erCrsLoadResponseForCursor = this.appDB.Load(erCrsLoadRequestForCursor);
			return erCrsLoadResponseForCursor;
		}
		
		public void Exchrates3Update(string ExchRateCurrCode, string ExchRateSite, decimal? ExchRate)
		{
            this.sQLExpressionExecutor.Execute("ALTER TABLE #ExchRates ADD tempTableId INT IDENTITY");

            var ExchratesNonTriggerUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
                tableName: "#ExchRates",
                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                    {"ExchRate", collectionNonTriggerUpdateRequestFactory.Clause($"{ExchRate}") }
                },
                fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
                whereClause: collectionNonTriggerUpdateRequestFactory.Clause($" SiteRef = '{ExchRateSite}' and FromCurrCode = '{ExchRateCurrCode}'")
                );

            this.appDB.UpdateWithoutTrigger(ExchratesNonTriggerUpdateRequest);

            this.sQLExpressionExecutor.Execute("ALTER TABLE #ExchRates DROP COLUMN tempTableId");

        }
		
		public void Voucher2Update()
		{
            this.sQLExpressionExecutor.Execute("ALTER TABLE #voucher ADD tempTableId INT IDENTITY");

            var ExchratesNonTriggerUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
                tableName: "vch",
                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                    {"vch_amt", collectionNonTriggerUpdateRequestFactory.Clause("round(case when er.RateIsDivisor = 1 then vch.vch_amt * case when vch.fixed_rate = 1 then vch.exch_rate else er.ExchRate end else vch.vch_amt / case when vch.fixed_rate = 1 then vch.exch_rate else er.ExchRate end end, er.Places)")},
                    {"pay_amt", collectionNonTriggerUpdateRequestFactory.Clause("round(case when er.RateIsDivisor = 1 then vch.pay_amt * case when vch.fixed_rate = 1 then vch.exch_rate else er.ExchRate end else vch.pay_amt / case when vch.fixed_rate = 1 then vch.exch_rate else er.ExchRate end end, er.Places)")}
                },
                fromClause: collectionNonTriggerUpdateRequestFactory.Clause(@" #voucher AS vch INNER JOIN #ExchRates AS er ON er.FromCurrCode = vch.curr_code
	            				AND er.SiteRef = vch.site_ref
	            				AND er.ExchRate != 1"),
                whereClause: collectionNonTriggerUpdateRequestFactory.Clause("(vch.vch_amt != 0 OR vch.pay_amt != 0)")
                );


            this.appDB.UpdateWithoutTrigger(ExchratesNonTriggerUpdateRequest);

            this.sQLExpressionExecutor.Execute("ALTER TABLE #voucher DROP COLUMN tempTableId");
        }

        public (decimal? APAmt, int? rowCount) Voucher3Load(DateTime? LowDate, decimal? APAmt)
		{
			AmtTotType _APAmt = DBNull.Value;
			
			var voucher3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_APAmt,"isnull(sum(vch_amt), 0)"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"#voucher",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("per_start = {0}",LowDate),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var voucher3LoadResponse = this.appDB.Load(voucher3LoadRequest);
			if(voucher3LoadResponse.Items.Count > 0)
			{
				APAmt = _APAmt;
			}
			
			int rowCount = voucher3LoadResponse.Items.Count;
			return (APAmt, rowCount);
		}

		public void Tv_Periods3Update()
		{
            var tv_periodsNonTriggerUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
                tableName: "per",
                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                    {"inv_amt", collectionNonTriggerUpdateRequestFactory.Clause("isnull(bb.sum_vch_amt, 0)")},
                    {"pay_amt", collectionNonTriggerUpdateRequestFactory.Clause("isnull(bb.sum_pay_amt, 0)")}
                },
                fromClause: collectionNonTriggerUpdateRequestFactory.Clause(@"(select per_start, sum(vch_amt) as sum_vch_amt, sum(pay_amt) as sum_pay_amt from #voucher group by per_start) as bb
                                                                               inner join #tv_periods as per on
                                                                               per.per_start = bb.per_start"),
                whereClause: collectionNonTriggerUpdateRequestFactory.Clause("")
                );


            this.appDB.UpdateWithoutTrigger(tv_periodsNonTriggerUpdateRequest);
        }
		
		public ICollectionLoadResponse Tv_Periods4Select(decimal? APAmt)
		{
			var tv_periods4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"DSOamount",$"CASE WHEN inv_amt = 0 THEN 0 ELSE (({APAmt} + (SELECT sum(inv_amt - pay_amt)                                              FROM   #tv_periods AS per1                                              WHERE  per1.seq <= per.seq)) / inv_amt) * num_days END"},
					{"DSOdate","CONVERT (NVARCHAR, per_end, 101)"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"#tv_periods",
				fromClause: collectionLoadRequestFactory.Clause(" per"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" seq"));
			return this.appDB.Load(tv_periods4LoadRequest);
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Home_MetricDPOSp(
			string AltExtGenSp,
			int? MultipleSites = 0,
			string SiteGroup = null,
			int? NumPeriods = 6)
		{
			ListYesNoType _MultipleSites = MultipleSites;
			SiteGroupType _SiteGroup = SiteGroup;
			IntType _NumPeriods = NumPeriods;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "MultipleSites", _MultipleSites, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumPeriods", _NumPeriods, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
				var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;
				
				return (resultSet, returnCode);
			}
		}
		
	}
}

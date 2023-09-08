//PROJECT NAME: Finance
//CLASS NAME: Home_MetricPaymentComparisonCRUD.cs

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

namespace CSI.Finance
{
	public class Home_MetricPaymentComparisonCRUD : IHome_MetricPaymentComparisonCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IStringUtil stringUtil;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;

        public Home_MetricPaymentComparisonCRUD(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IDateTimeUtil dateTimeUtil,
			IStringUtil stringUtil,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
			this.dateTimeUtil = dateTimeUtil;
			this.stringUtil = stringUtil;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_MetricPaymentComparisonSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}

        public void Optional_ModuleInsertSelect()
        {
            var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SpName","CAST (NULL AS NVARCHAR)"},
                    {"u0","[om].[ModuleName]"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_MetricPaymentComparisonSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_MetricPaymentComparisonSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
            };


            var optional_module1RequiredColumns = new List<string>() { "SpName" };
            optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);



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
		
		
		public void Tv_ALTGEN2Delete(string ALTGEN_SpName)
		{
            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");

            var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"[SpName]","[SpName]"},
                },
                loadForChange: true, 
                lockingType: LockingType.None,
                tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);

            var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);

            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
        }
		
		public ICollectionLoadResponse Site_GroupSelect(string SiteGroup)
		{
			var site_group_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"site_group.site","site_group.site"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName:"site_group",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("site_group.site_group = {0}",SiteGroup),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var site_group_crsLoadResponseForCursor = this.appDB.Load(site_group_crsLoadRequestForCursor);
			return site_group_crsLoadResponseForCursor;
		}
		public (string DomCurrCode, int? rowCount) Currparms_AllLoad(string Site, string DomCurrCode)
		{
			CurrCodeType _DomCurrCode = DBNull.Value;
			
			var currparms_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_DomCurrCode,"currparms_all.curr_code"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"currparms_all",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("currparms_all.site_ref = {0}",Site),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currparms_allLoadResponse = this.appDB.Load(currparms_allLoadRequest);
			if(currparms_allLoadResponse.Items.Count > 0)
			{
				DomCurrCode = _DomCurrCode;
			}
			
			int rowCount = currparms_allLoadResponse.Items.Count;
			return (DomCurrCode, rowCount);
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
		
		public void Artran1Insert(DateTime? PerStart, DateTime? PerEnd, string SiteList)
		{
            var Artran1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SiteRef","arta.site_ref"},
                    {"CustNum","arta.cust_num"},
                    {"DueDate","arta.due_date"},
                    {"InvNum","arta.inv_num"},
                    {"InvSeq","arta.inv_seq"},
                    {"CheckSeq","arta.check_seq"},
                    {"Amount","arta.amount"},
                    {"CustaddrCurrCode","arta.curr_code"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "artran_all",
                fromClause: collectionLoadRequestFactory.Clause(" AS arta WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("arta.type = 'P' AND arta.due_date BETWEEN {0} AND {2} AND dbo.IsInList({1}, arta.site_ref) > 0", PerStart, SiteList, PerEnd),
                orderByClause: collectionLoadRequestFactory.Clause(" arta.site_ref, arta.cust_num, arta.due_date, arta.inv_num, arta.inv_seq"));

            var Artran1LoadResponse = this.appDB.Load(Artran1LoadRequest);

            var Artran1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#Artran",
				items: Artran1LoadResponse.Items);
			
			this.appDB.Insert(Artran1InsertRequest);
		}
		
		public ICollectionLoadResponse Artran2Select(string DomCurrCode)
		{
			var currCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"CustaddrCurrCode","CustaddrCurrCode"},
					{"Amount","Amount"},
					{"seq","seq"},
					{"SiteRef","SiteRef"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"#Artran",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("CustaddrCurrCode != {0}",DomCurrCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var currCrsLoadResponseForCursor = this.appDB.Load(currCrsLoadRequestForCursor);
			return currCrsLoadResponseForCursor;
		}
		public ICollectionLoadResponse Artran3Select(int? Seq)
		{
			var Artran3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Amount","#Artran.Amount"},
				},
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"#Artran",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("seq = {0}",Seq),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(Artran3LoadRequest);
		}
		
		public void Artran3Update(int? Seq, decimal? Amount)
		{
            var Artran3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"Amount","#Artran.Amount"},
                },
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName: "#Artran",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("seq = {0}", Seq),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var Artran3LoadResponse =  this.appDB.Load(Artran3LoadRequest);

            foreach (var Artran3Item in Artran3LoadResponse.Items){
				Artran3Item.SetValue<decimal?>("Amount", Amount);
			};
			
			var Artran3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#Artran",
				items: Artran3LoadResponse.Items);
			
			this.appDB.Update(Artran3RequestUpdate);
		}
        
		public void Aptrxp1Insert(DateTime? PerStart, DateTime? PerEnd, string SiteList)
		{
            var Aptrxp1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SiteRef","apta.site_ref"},
                    {"VendNum","apta.vend_num"},
                    {"DistDate","apta.dist_date"},
                    {"Voucher","apta.voucher"},
                    {"VouchSeq","apta.vouch_seq"},
                    {"Amount","apta.amt_paid"},
                    {"VendorCurrCode","apta.curr_code"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "aptrxp_all",
                fromClause: collectionLoadRequestFactory.Clause(@" AS apta WITH (READUNCOMMITTED) INNER JOIN vendor_all WITH (READUNCOMMITTED) ON vendor_all.vend_num = apta.vend_num
	            				AND vendor_all.site_ref = apta.site_ref"),
                whereClause: collectionLoadRequestFactory.Clause("CHARINDEX(apta.type, 'POA') > 0 AND apta.due_date BETWEEN {0} AND {2} AND dbo.IsInList({1}, apta.site_ref) > 0", PerStart, SiteList, PerEnd),
                orderByClause: collectionLoadRequestFactory.Clause(" apta.site_ref, apta.vend_num, apta.due_date, apta.voucher, apta.vouch_seq"));

            var Aptrxp1LoadResponse = this.appDB.Load(Aptrxp1LoadRequest);

            var Aptrxp1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#Aptrxp",
				items: Aptrxp1LoadResponse.Items);
			
			this.appDB.Insert(Aptrxp1InsertRequest);
		}
		
		public ICollectionLoadResponse Aptrxp2Select(string DomCurrCode)
		{
			var curr2CrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"VendorCurrCode","VendorCurrCode"},
					{"Amount","Amount"},
					{"seq","seq"},
					{"SiteRef","SiteRef"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"#Aptrxp",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("VendorCurrCode != {0}",DomCurrCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var curr2CrsLoadResponseForCursor = this.appDB.Load(curr2CrsLoadRequestForCursor);
			return curr2CrsLoadResponseForCursor;
		}
		public ICollectionLoadResponse Aptrxp3Select(int? Seq)
		{
			var Aptrxp3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Amount","#Aptrxp.Amount"},
				},
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"#Aptrxp",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("seq = {0}",Seq),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(Aptrxp3LoadRequest);
		}
		
		public void Aptrxp3Update(int? Seq, decimal? Amount)
		{
            var Aptrxp3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"Amount","#Aptrxp.Amount"},
                },
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName: "#Aptrxp",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("seq = {0}", Seq),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var Aptrxp3LoadResponse = this.appDB.Load(Aptrxp3LoadRequest);

            foreach (var Aptrxp3Item in Aptrxp3LoadResponse.Items){
				Aptrxp3Item.SetValue<decimal?>("Amount", Amount);
			};
			
			var Aptrxp3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#Aptrxp",
				items: Aptrxp3LoadResponse.Items);
			
			this.appDB.Update(Aptrxp3RequestUpdate);
		}
		
		public (decimal? PeriodPaymentIn1,
			decimal? PeriodPaymentIn2,
			decimal? PeriodPaymentIn3,
			decimal? PeriodPaymentIn4,
			decimal? PeriodPaymentIn5,
			decimal? PeriodPaymentIn6, int? rowCount)
		Artran4Load(DateTime? PeriodStart1,
			DateTime? PeriodEnd1,
			DateTime? PeriodStart2,
			DateTime? PeriodEnd2,
			DateTime? PeriodStart3,
			DateTime? PeriodEnd3,
			DateTime? PeriodStart4,
			DateTime? PeriodEnd4,
			DateTime? PeriodStart5,
			DateTime? PeriodEnd5,
			DateTime? PeriodStart6,
			DateTime? PeriodEnd6,
			decimal? PeriodPaymentIn1,
			decimal? PeriodPaymentIn2,
			decimal? PeriodPaymentIn3,
			decimal? PeriodPaymentIn4,
			decimal? PeriodPaymentIn5,
			decimal? PeriodPaymentIn6)
		{
			AmtTotType _PeriodPaymentIn1 = DBNull.Value;
			AmtTotType _PeriodPaymentIn2 = DBNull.Value;
			AmtTotType _PeriodPaymentIn3 = DBNull.Value;
			AmtTotType _PeriodPaymentIn4 = DBNull.Value;
			AmtTotType _PeriodPaymentIn5 = DBNull.Value;
			AmtTotType _PeriodPaymentIn6 = DBNull.Value;
			
			var Artran4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PeriodPaymentIn1,$"sum(CASE WHEN DueDate BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart1)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd1)} THEN Amount ELSE 0 END)"},
					{_PeriodPaymentIn2,$"sum(CASE WHEN DueDate BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart2)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd2)} THEN Amount ELSE 0 END)"},
					{_PeriodPaymentIn3,$"sum(CASE WHEN DueDate BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart3)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd3)} THEN Amount ELSE 0 END)"},
					{_PeriodPaymentIn4,$"sum(CASE WHEN DueDate BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart4)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd4)} THEN Amount ELSE 0 END)"},
					{_PeriodPaymentIn5,$"sum(CASE WHEN DueDate BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart5)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd5)} THEN Amount ELSE 0 END)"},
					{_PeriodPaymentIn6,$"sum(CASE WHEN DueDate BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart6)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd6)} THEN Amount ELSE 0 END)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"#Artran",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var Artran4LoadResponse = this.appDB.Load(Artran4LoadRequest);
			if(Artran4LoadResponse.Items.Count > 0)
			{
				PeriodPaymentIn1 = _PeriodPaymentIn1;
				PeriodPaymentIn2 = _PeriodPaymentIn2;
				PeriodPaymentIn3 = _PeriodPaymentIn3;
				PeriodPaymentIn4 = _PeriodPaymentIn4;
				PeriodPaymentIn5 = _PeriodPaymentIn5;
				PeriodPaymentIn6 = _PeriodPaymentIn6;
			}
			
			int rowCount = Artran4LoadResponse.Items.Count;
			return (PeriodPaymentIn1, PeriodPaymentIn2, PeriodPaymentIn3, PeriodPaymentIn4, PeriodPaymentIn5, PeriodPaymentIn6, rowCount);
		}
		
		public (decimal? PeriodPaymentOut1,
			decimal? PeriodPaymentOut2,
			decimal? PeriodPaymentOut3,
			decimal? PeriodPaymentOut4,
			decimal? PeriodPaymentOut5,
			decimal? PeriodPaymentOut6, int? rowCount)
		Aptrxp4Load(DateTime? PeriodStart1,
			DateTime? PeriodEnd1,
			DateTime? PeriodStart2,
			DateTime? PeriodEnd2,
			DateTime? PeriodStart3,
			DateTime? PeriodEnd3,
			DateTime? PeriodStart4,
			DateTime? PeriodEnd4,
			DateTime? PeriodStart5,
			DateTime? PeriodEnd5,
			DateTime? PeriodStart6,
			DateTime? PeriodEnd6,
			decimal? PeriodPaymentOut1,
			decimal? PeriodPaymentOut2,
			decimal? PeriodPaymentOut3,
			decimal? PeriodPaymentOut4,
			decimal? PeriodPaymentOut5,
			decimal? PeriodPaymentOut6)
		{
			AmtTotType _PeriodPaymentOut1 = DBNull.Value;
			AmtTotType _PeriodPaymentOut2 = DBNull.Value;
			AmtTotType _PeriodPaymentOut3 = DBNull.Value;
			AmtTotType _PeriodPaymentOut4 = DBNull.Value;
			AmtTotType _PeriodPaymentOut5 = DBNull.Value;
			AmtTotType _PeriodPaymentOut6 = DBNull.Value;
			
			var Aptrxp4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PeriodPaymentOut1,$"sum(CASE WHEN DistDate BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart1)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd1)} THEN Amount ELSE 0 END)"},
					{_PeriodPaymentOut2,$"sum(CASE WHEN DistDate BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart2)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd2)} THEN Amount ELSE 0 END)"},
					{_PeriodPaymentOut3,$"sum(CASE WHEN DistDate BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart3)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd3)} THEN Amount ELSE 0 END)"},
					{_PeriodPaymentOut4,$"sum(CASE WHEN DistDate BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart4)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd4)} THEN Amount ELSE 0 END)"},
					{_PeriodPaymentOut5,$"sum(CASE WHEN DistDate BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart5)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd5)} THEN Amount ELSE 0 END)"},
					{_PeriodPaymentOut6,$"sum(CASE WHEN DistDate BETWEEN {variableUtil.GetQuotedValue<DateTime?>(PeriodStart6)} AND {variableUtil.GetQuotedValue<DateTime?>(PeriodEnd6)} THEN Amount ELSE 0 END)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"#Aptrxp",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var Aptrxp4LoadResponse = this.appDB.Load(Aptrxp4LoadRequest);
			if(Aptrxp4LoadResponse.Items.Count > 0)
			{
				PeriodPaymentOut1 = _PeriodPaymentOut1;
				PeriodPaymentOut2 = _PeriodPaymentOut2;
				PeriodPaymentOut3 = _PeriodPaymentOut3;
				PeriodPaymentOut4 = _PeriodPaymentOut4;
				PeriodPaymentOut5 = _PeriodPaymentOut5;
				PeriodPaymentOut6 = _PeriodPaymentOut6;
			}
			
			int rowCount = Aptrxp4LoadResponse.Items.Count;
			return (PeriodPaymentOut1, PeriodPaymentOut2, PeriodPaymentOut3, PeriodPaymentOut4, PeriodPaymentOut5, PeriodPaymentOut6, rowCount);
		}
		
		public void NontableInsert(decimal? PeriodPaymentIn, decimal? PeriodPaymentOut, DateTime? PeriodEnd)
		{
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "PaymentIn", PeriodPaymentIn},
                    { "PaymentOut", PeriodPaymentOut},
                    { "PeriodEnd", dateTimeUtil.ConvertToString(PeriodEnd, "MM/dd/yyyy")},
            });

            var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);

            var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
				items: nonTableLoadResponse.Items);
			
			this.appDB.Insert(nonTableInsertRequest);
		}
		
		public ICollectionLoadResponse Tv_ResultsSelect()
		{
			var tv_resultsLoadRequest = collectionLoadRequestFactory.SQLLoad(columns: new List<string>()
				{
					"PaymentIn",
					"PaymentOut",
					"PeriodEnd",
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_results",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			return this.appDB.Load(tv_resultsLoadRequest);
			
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Home_MetricPaymentComparisonSp(
			string AltExtGenSp,
			string SiteGroup = null)
		{
			SiteGroupType _SiteGroup = SiteGroup;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				
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

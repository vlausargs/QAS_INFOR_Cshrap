//PROJECT NAME: Admin
//CLASS NAME: CLM_ProductCodeMarginCRUD.cs

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
	public class CLM_ProductCodeMarginCRUD : ICLM_ProductCodeMarginCRUD
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;

		public CLM_ProductCodeMarginCRUD(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
		}

		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ProductCodeMarginSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
                tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ProductCodeMarginSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
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
			return existsChecker.Exists(tableName: "#tv_ALTGEN",
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
				tableName: "#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
			if (tv_ALTGEN1LoadResponse.Items.Count > 0)
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
				tableName: "#tv_ALTGEN",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}

		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}

		public int? PeriodsallviewaspvLoad(string SiteRef, int? StartPeriod)
		{
			IntType _StartPeriod = DBNull.Value;

			var PeriodsAllViewASpvLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_StartPeriod,"PV.period"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "PeriodsAllView AS pv",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("GETDATE() BETWEEN startDate AND endDate AND Site = {0}", SiteRef),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var PeriodsAllViewASpvLoadResponse = this.appDB.Load(PeriodsAllViewASpvLoadRequest);
			if (PeriodsAllViewASpvLoadResponse.Items.Count > 0)
			{
				StartPeriod = _StartPeriod;
			}

			return StartPeriod;
		}

		public int? Periodsallviewaspv1Load(string SiteRef, int? EndPeriod)
		{
			IntType _EndPeriod = DBNull.Value;

			var PeriodsAllViewASpv1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_EndPeriod,"PV.period"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "PeriodsAllView AS pv",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("GETDATE() BETWEEN startDate AND endDate AND Site = {0}", SiteRef),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var PeriodsAllViewASpv1LoadResponse = this.appDB.Load(PeriodsAllViewASpv1LoadRequest);
			if (PeriodsAllViewASpv1LoadResponse.Items.Count > 0)
			{
				EndPeriod = _EndPeriod;
			}

			return EndPeriod;
		}

		public DateTime? Periodsallviewaspv2Load(int? StartYear, int? StartPeriod, string SiteRef, DateTime? StartDate)
		{
			DateTimeType _StartDate = DBNull.Value;

			var PeriodsAllViewASpv2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_StartDate,"PV.startDate"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "PeriodsAllView AS pv",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("pv.FiscalYear = {1} AND pv.period = {0} AND Site = {2}", StartPeriod, StartYear, SiteRef),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var PeriodsAllViewASpv2LoadResponse = this.appDB.Load(PeriodsAllViewASpv2LoadRequest);
			if (PeriodsAllViewASpv2LoadResponse.Items.Count > 0)
			{
				StartDate = _StartDate;
			}

			return StartDate;
		}

		public DateTime? Periodsallviewaspv3Load(int? EndYear, int? EndPeriod, string SiteRef, DateTime? EndDate)
		{
			DateTimeType _EndDate = DBNull.Value;

			var PeriodsAllViewASpv3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_EndDate,"PV.EndDate"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "PeriodsAllView AS pv",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("pv.FiscalYear = {1} AND pv.period = {0} AND Site = {2}", EndPeriod, EndYear, SiteRef),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var PeriodsAllViewASpv3LoadResponse = this.appDB.Load(PeriodsAllViewASpv3LoadRequest);
			if (PeriodsAllViewASpv3LoadResponse.Items.Count > 0)
			{
				EndDate = _EndDate;
			}

			return EndDate;
		}

		public ICollectionLoadResponse Tv_PoductcodeamountsSelect(int? TotalPages, string SiteRef, DateTime? StartDate, DateTime? EndDate)
		{
			var tv_PoductCodeAmountsLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{ "ProductCode", "Prodcode.product_code" },
					{ "Description", "prodcode.description" },
					{ "ExpenseAmount", "ABS(SUM(CASE WHEN chart.type = 'E' THEN ledger.dom_amount ELSE 0 END))" },
					{ "RevenueAmount", "ABS(SUM(CASE WHEN chart.type = 'R' THEN ledger.dom_amount ELSE 0 END))" },
					{ "NetAmount", "ABS(SUM(CASE WHEN chart.type = 'R' THEN ledger.dom_amount ELSE 0 END)) - ABS(SUM(CASE WHEN chart.type = 'E' THEN ledger.dom_amount ELSE 0 END))" },
					{ "Margin", "0" },
					{ "TotalPages", $"{variableUtil.GetQuotedValue<int?>(TotalPages)}" },
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList
					FROM ledger_all AS ledger
					INNER JOIN
					chart_all AS chart
					ON ledger.acct = chart.acct
					AND chart.site_ref = {1}
					INNER JOIN
					prodcode_all AS prodcode
					ON prodcode.wip_acct_unit2 = ledger.acct_unit2
					AND prodcode.site_ref = {1}
					WHERE type IN ('E', 'R')
					AND ledger.from_id NOT IN ('General')
					AND trans_date BETWEEN {0}  AND {2}
					AND ledger.site_ref = {1}
					GROUP BY Prodcode.product_code, prodcode.Description", StartDate, SiteRef, EndDate));

			return this.appDB.Load(tv_PoductCodeAmountsLoadRequest);
		}

		public void Tv_PoductcodeamountsInsert(ICollectionLoadResponse tv_PoductCodeAmountsLoadResponse)
		{
			var tv_PoductCodeAmountsInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_PoductCodeAmounts",
				items: tv_PoductCodeAmountsLoadResponse.Items);

			this.appDB.Insert(tv_PoductCodeAmountsInsertRequest);
		}

		public (decimal? GrossExpenseAmount, decimal? GrossRevenueAmount, decimal? GrossNetAmount) Tv_Poductcodeamounts1Load(decimal? GrossExpenseAmount, decimal? GrossRevenueAmount, decimal? GrossNetAmount)
		{
			AmountType _GrossExpenseAmount = DBNull.Value;
			AmountType _GrossRevenueAmount = DBNull.Value;
			AmountType _GrossNetAmount = DBNull.Value;

			var tv_PoductCodeAmounts1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_GrossExpenseAmount,"SUM(ExpenseAmount)"},
					{_GrossRevenueAmount,"SUM(RevenueAmount)"},
					{_GrossNetAmount,"SUM(NetAmount)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_PoductCodeAmounts",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_PoductCodeAmounts1LoadResponse = this.appDB.Load(tv_PoductCodeAmounts1LoadRequest);
			if (tv_PoductCodeAmounts1LoadResponse.Items.Count > 0)
			{
				GrossExpenseAmount = _GrossExpenseAmount;
				GrossRevenueAmount = _GrossRevenueAmount;
				GrossNetAmount = _GrossNetAmount;
			}

			return (GrossExpenseAmount, GrossRevenueAmount, GrossNetAmount);
		}

		public ICollectionLoadResponse Tv_Poductcodeamounts2Select(string ProductCode)
		{
			var tv_PoductCodeAmounts2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Margin","#tv_PoductCodeAmounts.Margin"},
					{"u0","#tv_PoductCodeAmounts.NetAmount"},
				},
				tableName: "#tv_PoductCodeAmounts", 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("ProductCode LIKE {0}", ProductCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_PoductCodeAmounts2LoadRequest);
		}

		public void Tv_Poductcodeamounts2Update(decimal? GrossNetAmount, ICollectionLoadResponse tv_PoductCodeAmounts2LoadResponse)
		{
			foreach (var tv_PoductCodeAmounts2Item in tv_PoductCodeAmounts2LoadResponse.Items)
			{
				tv_PoductCodeAmounts2Item.SetValue<decimal?>("Margin", tv_PoductCodeAmounts2Item.GetDeletedValue<decimal?>("u0") / GrossNetAmount * 100M);
			};

			var tv_PoductCodeAmounts2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_PoductCodeAmounts",
				items: tv_PoductCodeAmounts2LoadResponse.Items);

			this.appDB.Update(tv_PoductCodeAmounts2RequestUpdate);
		}

		public ICollectionLoadResponse Tv_Poductcodeamounts3Select(string ProductCode, int? EntriesPerPage)
		{
			var tv_PoductCodeAmounts3LoadRequestForScalarSubQuery = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"col0",$"CEILING(CONVERT (DECIMAL, COUNT(*)) / CONVERT (DECIMAL, {variableUtil.GetQuotedValue<int?>(EntriesPerPage)}))"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_PoductCodeAmounts",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("ProductCode LIKE {0}", ProductCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_PoductCodeAmounts3LoadRequestForScalarSubQuery);
		}

		public ICollectionLoadResponse Tv_Poductcodeamounts4Select(string ProductCode)
		{
			var tv_PoductCodeAmounts4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"TotalPages","PL.TotalPages"},
				},
				tableName: "#tv_PoductCodeAmounts", 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(" AS PL"),
				whereClause: collectionLoadRequestFactory.Clause("ProductCode LIKE {0}", ProductCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_PoductCodeAmounts4LoadRequest);
		}

		public void Tv_Poductcodeamounts4Update(int? TotalPages, ICollectionLoadResponse tv_PoductCodeAmounts4LoadResponse)
		{
			foreach (var tv_PoductCodeAmounts4Item in tv_PoductCodeAmounts4LoadResponse.Items)
			{
				tv_PoductCodeAmounts4Item.SetValue<int?>("TotalPages", TotalPages);
			};

			var tv_PoductCodeAmounts4RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_PoductCodeAmounts",
				items: tv_PoductCodeAmounts4LoadResponse.Items);

			this.appDB.Update(tv_PoductCodeAmounts4RequestUpdate);
		}

		public ICollectionLoadResponse Tv_Poductcodeamounts5Select(int? EntriesPerPage, int? PageNum, string ProductCode)
		{
			var tv_PoductCodeAmounts5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"ProductCode","ProductCode"},
					{"Margin","Margin"},
				},
				maximumRows: PageNum, 
                loadForChange: true, 
                lockingType: LockingType.None,
                tableName: "#tv_PoductCodeAmounts",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("ProductCode IN (SELECT TOP ({0} * ({2} - 1)) ProductCode FROM #tv_PoductCodeAmounts WHERE ProductCode LIKE {1} ORDER BY Margin DESC)", EntriesPerPage, ProductCode, PageNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_PoductCodeAmounts5LoadRequest);
		}

		public void Tv_Poductcodeamounts5Delete(ICollectionLoadResponse tv_PoductCodeAmounts5LoadResponse)
		{
			var tv_PoductCodeAmounts5DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_PoductCodeAmounts",
				items: tv_PoductCodeAmounts5LoadResponse.Items);
			this.appDB.Delete(tv_PoductCodeAmounts5DeleteRequest);
		}

		public ICollectionLoadResponse Tv_Poductcodeamounts6Select(string ProductCode, int? EntriesPerPage)
		{
			var tv_PoductCodeAmounts6LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"ProductCode","ProductCode"},
					{"Description","Description"},
					{"Margin","Margin"},
					{"NetAmount","NetAmount"},
					{"TotalPages","TotalPages"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: EntriesPerPage,
				tableName: "#tv_PoductCodeAmounts",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("ProductCode LIKE {0}", ProductCode),
				orderByClause: collectionLoadRequestFactory.Clause(" Margin DESC"));
			return this.appDB.Load(tv_PoductCodeAmounts6LoadRequest);
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_CLM_ProductCodeMarginSp(
			string AltExtGenSp,
			string ProductCode = null,
			int? StartYear = null,
			int? EndYear = null,
			int? StartPeriod = null,
			int? EndPeriod = null,
			int? PageNum = null,
			int? EntriesPerPage = null,
			string SiteRef = null)
		{
			ProductCodeType _ProductCode = ProductCode;
			IntType _StartYear = StartYear;
			IntType _EndYear = EndYear;
			IntType _StartPeriod = StartPeriod;
			IntType _EndPeriod = EndPeriod;
			IntType _PageNum = PageNum;
			IntType _EntriesPerPage = EntriesPerPage;
			SiteType _SiteRef = SiteRef;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartYear", _StartYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndYear", _EndYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPeriod", _StartPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPeriod", _EndPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageNum", _PageNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntriesPerPage", _EntriesPerPage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);

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

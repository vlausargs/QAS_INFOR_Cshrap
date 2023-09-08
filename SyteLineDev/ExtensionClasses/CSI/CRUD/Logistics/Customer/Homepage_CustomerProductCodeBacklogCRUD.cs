//PROJECT NAME: Logistics
//CLASS NAME: Homepage_CustomerProductCodeBacklogCRUD.cs

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

namespace CSI.Logistics.Customer
{
	public class Homepage_CustomerProductCodeBacklogCRUD : IHomepage_CustomerProductCodeBacklogCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;

		public Homepage_CustomerProductCodeBacklogCRUD(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
		}


		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_CustomerProductCodeBacklogSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_CustomerProductCodeBacklogSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
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
                loadForChange: true, 
                lockingType: LockingType.None,
                tableName: "#tv_ALTGEN",
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

		public ICollectionLoadResponse Coitem_AllSelect(string CustNum, string SiteRef, DateTime? num90Date, DateTime? EndDate)
		{
			var coitem_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"TodayAmount","CAST (NULL AS DECIMAL)"},
					{"Amount30","CAST (NULL AS DECIMAL)"},
					{"Amount60","CAST (NULL AS DECIMAL)"},
					{"Amount90","CAST (NULL AS DECIMAL)"},
					{"u0","coi.promise_date"},
					{"u1","coi.qty_ordered"},
					{"u2","coi.u_m"},
					{"u3","coi.item"},
					{"u4","co.cust_num"},
					{"u5","coi.qty_shipped"},
					{"u6","co.curr_code"},
					{"u7","co.exch_rate"},
					{"u8","coi.price_conv"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "coitem_all",
				fromClause: collectionLoadRequestFactory.Clause(@" as coi left outer join co_all as co on co.co_num = coi.co_num
					and co.site_ref = coi.site_ref left outer join currency_all as currency on currency.curr_code = co.curr_code
					and currency.site_ref = {0}", SiteRef),
				whereClause: collectionLoadRequestFactory.Clause("coi.stat = 'O' AND ISNULL(coi.promise_date, {0}) BETWEEN {3} AND {0} AND coi.qty_ordered > coi.qty_shipped AND CO.cust_num LIKE {1} AND coi.site_ref = {2}", EndDate, CustNum, SiteRef, num90Date),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(coitem_allLoadRequest);
		}

		public ICollectionLoadResponse ProdcodeSelect(string ProductCode, string SiteRef, DateTime? num90Date, DateTime? EndDate)
		{
			var prodcodeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"TodayAmount","CAST (NULL AS DECIMAL)"},
					{"Amount30","CAST (NULL AS DECIMAL)"},
					{"Amount60","CAST (NULL AS DECIMAL)"},
					{"Amount90","CAST (NULL AS DECIMAL)"},
					{"u0","coi.promise_date"},
					{"u1","coi.qty_ordered"},
					{"u2","coi.u_m"},
					{"u3","coi.item"},
					{"u4","co.cust_num"},
					{"u5","coi.qty_shipped"},
					{"u6","co.curr_code"},
					{"u7","co.exch_rate"},
					{"u8","coi.price_conv"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "prodcode",
				fromClause: collectionLoadRequestFactory.Clause(@" as prcd left outer join item as it on it.product_code = prcd.product_code left outer join coitem_all as coi on coi.item = it.item left outer join co_all as co on co.co_num = coi.co_num
					and co.site_ref = coi.site_ref left outer join currency_all as currency on currency.curr_code = co.curr_code
					and currency.site_ref = {0}", SiteRef),
				whereClause: collectionLoadRequestFactory.Clause("coi.stat = 'O' AND ISNULL(coi.promise_date, {1}) BETWEEN {3} AND {1} AND coi.qty_ordered > coi.qty_shipped AND prcd.product_code = {0} AND coi.site_ref = {2}", ProductCode, EndDate, SiteRef, num90Date),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(prodcodeLoadRequest);
		}

		public ICollectionLoadResponse DynamicparametersSelect(string SelectionClause, string FromClause, string WhereClause, string AdditionalClause, string KeyColumns, string FilterString)
		{
			var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SelectionClause",$"{variableUtil.GetQuotedValue<string>(SelectionClause)}"},
					{"FromClause",$"{variableUtil.GetQuotedValue<string>(FromClause)}"},
					{"WhereClause",$"{variableUtil.GetQuotedValue<string>(WhereClause)}"},
					{"AdditionalClause",$"{variableUtil.GetQuotedValue<string>(AdditionalClause)}"},
					{"KeyColumns",$"{variableUtil.GetQuotedValue<string>(KeyColumns)}"},
					{"FilterString",$"{variableUtil.GetQuotedValue<string>(FilterString)}"},
				},
				selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList"));

			return this.appDB.Load(DynamicParametersLoadRequest);
		}

		public void DynamicparametersInsert(ICollectionLoadResponse DynamicParametersLoadResponse)
		{
			var DynamicParametersInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#DynamicParameters",
				items: DynamicParametersLoadResponse.Items);

			this.appDB.Insert(DynamicParametersInsertRequest);
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Homepage_CustomerProductCodeBacklogSp(
			string AltExtGenSp,
			string CustNum = null,
			string ProductCode = null,
			string SiteRef = null,
			string FilterString = null)
		{
			CustNumType _CustNum = CustNum;
			ProductCodeType _ProductCode = ProductCode;
			SiteType _SiteRef = SiteRef;
			LongListType _FilterString = FilterString;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);

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

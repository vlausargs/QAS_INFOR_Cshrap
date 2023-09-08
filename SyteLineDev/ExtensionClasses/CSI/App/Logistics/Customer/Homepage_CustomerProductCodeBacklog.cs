//PROJECT NAME: Logistics
//CLASS NAME: Homepage_CustomerProductCodeBacklog.cs

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
using CSI.DataCollection;

namespace CSI.Logistics.Customer
{
	public class Homepage_CustomerProductCodeBacklog : IHomepage_CustomerProductCodeBacklog
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IDefaultToLocalSite iDefaultToLocalSite;
		readonly ICurrCnvtSingleAmt2 iCurrCnvtSingleAmt2;
		readonly IExecuteDynamicSQL iExecuteDynamicSQL;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IDataTypeUtil dataTypeUtil;
		readonly IMidnightOf iMidnightOf;
		readonly IUomConvQty iUomConvQty;
		readonly IStringUtil stringUtil;
		readonly ISqlFilter iSqlFilter;
		readonly IGetumcf iGetumcf;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IVariableUtil variableUtil;
		readonly IHomepage_CustomerProductCodeBacklogCRUD iHomepage_CustomerProductCodeBacklogCRUD;

		public Homepage_CustomerProductCodeBacklog(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IDefaultToLocalSite iDefaultToLocalSite,
			ICurrCnvtSingleAmt2 iCurrCnvtSingleAmt2,
			IExecuteDynamicSQL iExecuteDynamicSQL,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IDataTypeUtil dataTypeUtil,
			IMidnightOf iMidnightOf,
			IUomConvQty iUomConvQty,
			IStringUtil stringUtil,
			ISqlFilter iSqlFilter,
			IGetumcf iGetumcf,
			ISQLValueComparerUtil sQLUtil,
			IVariableUtil variableUtil,
			IHomepage_CustomerProductCodeBacklogCRUD iHomepage_CustomerProductCodeBacklogCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iDefaultToLocalSite = iDefaultToLocalSite;
			this.iCurrCnvtSingleAmt2 = iCurrCnvtSingleAmt2;
			this.iExecuteDynamicSQL = iExecuteDynamicSQL;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.dataTypeUtil = dataTypeUtil;
			this.iMidnightOf = iMidnightOf;
			this.iUomConvQty = iUomConvQty;
			this.stringUtil = stringUtil;
			this.iSqlFilter = iSqlFilter;
			this.iGetumcf = iGetumcf;
			this.sQLUtil = sQLUtil;
			this.variableUtil = variableUtil;
			this.iHomepage_CustomerProductCodeBacklogCRUD = iHomepage_CustomerProductCodeBacklogCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Homepage_CustomerProductCodeBacklogSp(
			string CustNum = null,
			string ProductCode = null,
			string SiteRef = null,
			string FilterString = null)
		{

			ICollectionLoadResponse Data = null;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			DateTime? Today = null;
			DateTime? num30Date = null;
			DateTime? num60Date = null;
			DateTime? num90Date = null;
			DateTime? EndDate = null;
			decimal? TodayAmount = null;
			decimal? num30Amount = null;
			decimal? num60Amount = null;
			decimal? num90Amount = null;
			int? Severity = null;
			string Infobar = null;
			string WhereClause = null;
			string PropertyList = null;
			string ColumnList = null;
			string SelectionClause = null;
			string FromClause = null;
			string AdditionalClause = null;
			string KeyColumns = null;
			if (this.iHomepage_CustomerProductCodeBacklogCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iHomepage_CustomerProductCodeBacklogCRUD.Optional_Module1Select();
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Homepage_CustomerProductCodeBacklogSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iHomepage_CustomerProductCodeBacklogCRUD.Optional_Module1Insert(optional_module1LoadResponse);

				while (this.iHomepage_CustomerProductCodeBacklogCRUD.Tv_ALTGENForExists())
				{
					ALTGEN_SpName = this.iHomepage_CustomerProductCodeBacklogCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iHomepage_CustomerProductCodeBacklogCRUD.AltExtGen_Homepage_CustomerProductCodeBacklogSp(ALTGEN_SpName,
						CustNum,
						ProductCode,
						SiteRef,
						FilterString);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iHomepage_CustomerProductCodeBacklogCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iHomepage_CustomerProductCodeBacklogCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_CustomerProductCodeBacklogSp") != null)
			{
				var EXTGEN = this.iHomepage_CustomerProductCodeBacklogCRUD.AltExtGen_Homepage_CustomerProductCodeBacklogSp("dbo.EXTGEN_Homepage_CustomerProductCodeBacklogSp",
					CustNum,
					ProductCode,
					SiteRef,
					FilterString);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			SiteRef = stringUtil.Coalesce<string>(SiteRef, this.iDefaultToLocalSite.DefaultToLocalSiteFn(SiteRef));
			Today = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")));
			num30Date = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(29));
			num60Date = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(59));
			num90Date = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(89));
			EndDate = convertToUtil.ToDateTime(scalarFunction.Execute<DateTime>("GETDATE"));
			Severity = 0;
			TodayAmount = 0;
			num30Amount = 0;
			num60Amount = 0;
			num90Amount = 0;
			if (this.scalarFunction.Execute<int?>(
				"OBJECT_ID",
				"tempdb..#Results") != null)
			{
				this.sQLExpressionExecutor.Execute("DROP TABLE #Results");

			}
			var coitem_allLoadResponse = this.iHomepage_CustomerProductCodeBacklogCRUD.Coitem_AllSelect(CustNum, SiteRef, num90Date, EndDate);
			foreach (var coitem_allItem in coitem_allLoadResponse.Items)
			{
				TodayAmount = TodayAmount + (sQLUtil.SQLBetween(stringUtil.IsNull(
					coitem_allItem.GetValue<DateTime?>("u0"),
					EndDate), Today, EndDate) == true ? convertToUtil.ToDecimal(stringUtil.IsNull(
					stringUtil.IsNull<decimal?>(
						this.iUomConvQty.UomConvQtyFn(
							coitem_allItem.GetValue<decimal?>("u1"),
							this.iGetumcf.GetumcfFn(
								coitem_allItem.GetValue<string>("u2"),
								coitem_allItem.GetValue<string>("u3"),
								coitem_allItem.GetValue<string>("u4"),
								"C"),
							"from base") - this.iUomConvQty.UomConvQtyFn(
							coitem_allItem.GetValue<decimal?>("u5"),
							this.iGetumcf.GetumcfFn(
								coitem_allItem.GetValue<string>("u2"),
								coitem_allItem.GetValue<string>("u3"),
								coitem_allItem.GetValue<string>("u4"),
								"C"),
							"from base"),
						0) * this.iCurrCnvtSingleAmt2.CurrCnvtSingleAmt2Fn(
						coitem_allItem.GetValue<string>("u6"),
						0,
						0,
						1,
						null,
						null,
						null,
						null,
						coitem_allItem.GetValue<decimal?>("u7"),
						null,
						null,
						null,
						stringUtil.IsNull<decimal?>(
							coitem_allItem.GetValue<decimal?>("u8"),
							0)),
					0.00M)) : 0);

				num30Amount = num30Amount + (sQLUtil.SQLBetween(stringUtil.IsNull(
					coitem_allItem.GetValue<DateTime?>("u0"),
					EndDate), num30Date, EndDate) == true ? convertToUtil.ToDecimal(stringUtil.IsNull(
					stringUtil.IsNull<decimal?>(
						this.iUomConvQty.UomConvQtyFn(
							coitem_allItem.GetValue<decimal?>("u1"),
							this.iGetumcf.GetumcfFn(
								coitem_allItem.GetValue<string>("u2"),
								coitem_allItem.GetValue<string>("u3"),
								coitem_allItem.GetValue<string>("u4"),
								"C"),
							"from base") - this.iUomConvQty.UomConvQtyFn(
							coitem_allItem.GetValue<decimal?>("u5"),
							this.iGetumcf.GetumcfFn(
								coitem_allItem.GetValue<string>("u2"),
								coitem_allItem.GetValue<string>("u3"),
								coitem_allItem.GetValue<string>("u4"),
								"C"),
							"from base"),
						0) * this.iCurrCnvtSingleAmt2.CurrCnvtSingleAmt2Fn(
						coitem_allItem.GetValue<string>("u6"),
						0,
						0,
						1,
						null,
						null,
						null,
						null,
						coitem_allItem.GetValue<decimal?>("u7"),
						null,
						null,
						null,
						stringUtil.IsNull<decimal?>(
							coitem_allItem.GetValue<decimal?>("u8"),
							0)),
					0.00M)) : 0);

				num60Amount = num60Amount + (sQLUtil.SQLBetween(stringUtil.IsNull(
					coitem_allItem.GetValue<DateTime?>("u0"),
					EndDate), num60Date, EndDate) == true ? convertToUtil.ToDecimal(stringUtil.IsNull(
					stringUtil.IsNull<decimal?>(
						this.iUomConvQty.UomConvQtyFn(
							coitem_allItem.GetValue<decimal?>("u1"),
							this.iGetumcf.GetumcfFn(
								coitem_allItem.GetValue<string>("u2"),
								coitem_allItem.GetValue<string>("u3"),
								coitem_allItem.GetValue<string>("u4"),
								"C"),
							"from base") - this.iUomConvQty.UomConvQtyFn(
							coitem_allItem.GetValue<decimal?>("u5"),
							this.iGetumcf.GetumcfFn(
								coitem_allItem.GetValue<string>("u2"),
								coitem_allItem.GetValue<string>("u3"),
								coitem_allItem.GetValue<string>("u4"),
								"C"),
							"from base"),
						0) * this.iCurrCnvtSingleAmt2.CurrCnvtSingleAmt2Fn(
						coitem_allItem.GetValue<string>("u6"),
						0,
						0,
						1,
						null,
						null,
						null,
						null,
						coitem_allItem.GetValue<decimal?>("u7"),
						null,
						null,
						null,
						stringUtil.IsNull<decimal?>(
							coitem_allItem.GetValue<decimal?>("u8"),
							0)),
					0.00M)) : 0);

				num90Amount = num90Amount + (sQLUtil.SQLBetween(stringUtil.IsNull(
					coitem_allItem.GetValue<DateTime?>("u0"),
					EndDate), num90Date, EndDate) == true ? convertToUtil.ToDecimal(stringUtil.IsNull(
					stringUtil.IsNull<decimal?>(
						this.iUomConvQty.UomConvQtyFn(
							coitem_allItem.GetValue<decimal?>("u1"),
							this.iGetumcf.GetumcfFn(
								coitem_allItem.GetValue<string>("u2"),
								coitem_allItem.GetValue<string>("u3"),
								coitem_allItem.GetValue<string>("u4"),
								"C"),
							"from base") - this.iUomConvQty.UomConvQtyFn(
							coitem_allItem.GetValue<decimal?>("u5"),
							this.iGetumcf.GetumcfFn(
								coitem_allItem.GetValue<string>("u2"),
								coitem_allItem.GetValue<string>("u3"),
								coitem_allItem.GetValue<string>("u4"),
								"C"),
							"from base"),
						0) * this.iCurrCnvtSingleAmt2.CurrCnvtSingleAmt2Fn(
						coitem_allItem.GetValue<string>("u6"),
						0,
						0,
						1,
						null,
						null,
						null,
						null,
						coitem_allItem.GetValue<decimal?>("u7"),
						null,
						null,
						null,
						stringUtil.IsNull<decimal?>(
							coitem_allItem.GetValue<decimal?>("u8"),
							0)),
					0.00M)) : 0);
			};

			Data = coitem_allLoadResponse;

			var prodcodeLoadResponse = this.iHomepage_CustomerProductCodeBacklogCRUD.ProdcodeSelect(ProductCode, SiteRef, num90Date, EndDate);
			foreach (var prodcodeItem in prodcodeLoadResponse.Items)
			{
				TodayAmount = TodayAmount + (sQLUtil.SQLBetween(stringUtil.IsNull(
					prodcodeItem.GetValue<DateTime?>("u0"),
					EndDate), Today, EndDate) == true ? convertToUtil.ToDecimal(stringUtil.IsNull(
					stringUtil.IsNull<decimal?>(
						this.iUomConvQty.UomConvQtyFn(
							prodcodeItem.GetValue<decimal?>("u1"),
							this.iGetumcf.GetumcfFn(
								prodcodeItem.GetValue<string>("u2"),
								prodcodeItem.GetValue<string>("u3"),
								prodcodeItem.GetValue<string>("u4"),
								"C"),
							"from base") - this.iUomConvQty.UomConvQtyFn(
							prodcodeItem.GetValue<decimal?>("u5"),
							this.iGetumcf.GetumcfFn(
								prodcodeItem.GetValue<string>("u2"),
								prodcodeItem.GetValue<string>("u3"),
								prodcodeItem.GetValue<string>("u4"),
								"C"),
							"from base"),
						0) * this.iCurrCnvtSingleAmt2.CurrCnvtSingleAmt2Fn(
						prodcodeItem.GetValue<string>("u6"),
						0,
						0,
						1,
						null,
						null,
						null,
						null,
						prodcodeItem.GetValue<decimal?>("u7"),
						null,
						null,
						null,
						stringUtil.IsNull<decimal?>(
							prodcodeItem.GetValue<decimal?>("u8"),
							0)),
					0.00M)) : 0);

				num30Amount = num30Amount + (sQLUtil.SQLBetween(stringUtil.IsNull(
					prodcodeItem.GetValue<DateTime?>("u0"),
					EndDate), num30Date, EndDate) == true ? convertToUtil.ToDecimal(stringUtil.IsNull(
					stringUtil.IsNull<decimal?>(
						this.iUomConvQty.UomConvQtyFn(
							prodcodeItem.GetValue<decimal?>("u1"),
							this.iGetumcf.GetumcfFn(
								prodcodeItem.GetValue<string>("u2"),
								prodcodeItem.GetValue<string>("u3"),
								prodcodeItem.GetValue<string>("u4"),
								"C"),
							"from base") - this.iUomConvQty.UomConvQtyFn(
							prodcodeItem.GetValue<decimal?>("u5"),
							this.iGetumcf.GetumcfFn(
								prodcodeItem.GetValue<string>("u2"),
								prodcodeItem.GetValue<string>("u3"),
								prodcodeItem.GetValue<string>("u4"),
								"C"),
							"from base"),
						0) * this.iCurrCnvtSingleAmt2.CurrCnvtSingleAmt2Fn(
						prodcodeItem.GetValue<string>("u6"),
						0,
						0,
						1,
						null,
						null,
						null,
						null,
						prodcodeItem.GetValue<decimal?>("u7"),
						null,
						null,
						null,
						stringUtil.IsNull<decimal?>(
							prodcodeItem.GetValue<decimal?>("u8"),
							0)),
					0.00M)) : 0);

				num60Amount = num60Amount + (sQLUtil.SQLBetween(stringUtil.IsNull(
					prodcodeItem.GetValue<DateTime?>("u0"),
					EndDate), num60Date, EndDate) == true ? convertToUtil.ToDecimal(stringUtil.IsNull(
					stringUtil.IsNull<decimal?>(
						this.iUomConvQty.UomConvQtyFn(
							prodcodeItem.GetValue<decimal?>("u1"),
							this.iGetumcf.GetumcfFn(
								prodcodeItem.GetValue<string>("u2"),
								prodcodeItem.GetValue<string>("u3"),
								prodcodeItem.GetValue<string>("u4"),
								"C"),
							"from base") - this.iUomConvQty.UomConvQtyFn(
							prodcodeItem.GetValue<decimal?>("u5"),
							this.iGetumcf.GetumcfFn(
								prodcodeItem.GetValue<string>("u2"),
								prodcodeItem.GetValue<string>("u3"),
								prodcodeItem.GetValue<string>("u4"),
								"C"),
							"from base"),
						0) * this.iCurrCnvtSingleAmt2.CurrCnvtSingleAmt2Fn(
						prodcodeItem.GetValue<string>("u6"),
						0,
						0,
						1,
						null,
						null,
						null,
						null,
						prodcodeItem.GetValue<decimal?>("u7"),
						null,
						null,
						null,
						stringUtil.IsNull<decimal?>(
							prodcodeItem.GetValue<decimal?>("u8"),
							0)),
					0.00M)) : 0);

				num90Amount = num90Amount + (sQLUtil.SQLBetween(stringUtil.IsNull(
					prodcodeItem.GetValue<DateTime?>("u0"),
					EndDate), num90Date, EndDate) == true ? convertToUtil.ToDecimal(stringUtil.IsNull(
					stringUtil.IsNull<decimal?>(
						this.iUomConvQty.UomConvQtyFn(
							prodcodeItem.GetValue<decimal?>("u1"),
							this.iGetumcf.GetumcfFn(
								prodcodeItem.GetValue<string>("u2"),
								prodcodeItem.GetValue<string>("u3"),
								prodcodeItem.GetValue<string>("u4"),
								"C"),
							"from base") - this.iUomConvQty.UomConvQtyFn(
							prodcodeItem.GetValue<decimal?>("u5"),
							this.iGetumcf.GetumcfFn(
								prodcodeItem.GetValue<string>("u2"),
								prodcodeItem.GetValue<string>("u3"),
								prodcodeItem.GetValue<string>("u4"),
								"C"),
							"from base"),
						0) * this.iCurrCnvtSingleAmt2.CurrCnvtSingleAmt2Fn(
						prodcodeItem.GetValue<string>("u6"),
						0,
						0,
						1,
						null,
						null,
						null,
						null,
						prodcodeItem.GetValue<decimal?>("u7"),
						null,
						null,
						null,
						stringUtil.IsNull<decimal?>(
							prodcodeItem.GetValue<decimal?>("u8"),
							0)),
					0.00M)) : 0);
			};

			Data = prodcodeLoadResponse;

			this.sQLExpressionExecutor.Execute(@"SELECT 
            			CAST(0 AS int) AS KeySeq,
            			SS.KeyField AS KeyField,
            			CAST(0 AS decimal(23,8)) AS DomAmount
            	INTO   #Results
            	FROM   (SELECT 1 AS KeySeq,
            	               dbo.GetLabel('@!Today') AS KeyField,
            	               0 AS DomAmount) AS SS 
            	WHERE 1 = 0");

            this.sQLExpressionExecutor.Execute(@"INSERT 
            	INTO   #Results
            	SELECT KeySeq,
            	       KeyField,
            	       DomAmount 
            	FROM   (SELECT 1 AS KeySeq,
            	               dbo.GetLabel('@!Today') AS KeyField,
            	               CAST({0} as decimal(23,8)) AS DomAmount
            	        UNION
            	        SELECT 2 AS KeySeq,
            	               '30' AS KeyField,
            	               CAST({1} as decimal(23,8)) AS DomAmount
            	        UNION
            	        SELECT 3 AS KeySeq,
            	               '60' AS KeyField,
            	               CAST({2} as decimal(23,8)) AS DomAmount
            	        UNION
            	        SELECT 4 AS KeySeq,
            	               '90' AS KeyField,
            	               CAST({3} as decimal(23,8)) AS DomAmount) AS SS",
                TodayAmount,
                num30Amount,
                num60Amount,
                num90Amount);

            PropertyList = "KeySeq;KeyField;DomAmount;";
			ColumnList = "KeySeq;KeyField;DomAmount;";
			FilterString = stringUtil.IsNull(
				this.iSqlFilter.SqlFilterFn(
					FilterString,
					PropertyList,
					ColumnList,
					";"),
				"");
			SelectionClause = "";
			FromClause = "";
			AdditionalClause = "";
			KeyColumns = "";
			SelectionClause = "SELECT *";
			FromClause = "FROM #Results";
			WhereClause = null;
			AdditionalClause = "ORDER BY KeySeq Desc";
			KeyColumns = "KeySeq";
			if (this.scalarFunction.Execute<int?>(
				"OBJECT_ID",
				"tempdb..#DynamicParameters") != null)
			{
				this.sQLExpressionExecutor.Execute("DROP TABLE #DynamicParameters");

			}

			this.sQLExpressionExecutor.Execute(@"Declare
				@SelectionClause VeryLongListType
				,@FromClause VeryLongListType
				,@WhereClause LongListType
				,@AdditionalClause VeryLongListType
				,@KeyColumns VeryLongListType
				,@FilterString LongListType
				SELECT @SelectionClause AS SelectionClause,
				       @FromClause AS FromClause,
				       @WhereClause AS WhereClause,
				       @AdditionalClause AS AdditionalClause,
				       @KeyColumns AS KeyColumns,
				       @FilterString AS FilterString
				INTO   #DynamicParameters
				WHERE 1 = 2");
			var DynamicParametersLoadResponse = this.iHomepage_CustomerProductCodeBacklogCRUD.DynamicparametersSelect(SelectionClause, FromClause, WhereClause, AdditionalClause, KeyColumns, FilterString);

			this.iHomepage_CustomerProductCodeBacklogCRUD.DynamicparametersInsert(DynamicParametersLoadResponse);

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
			var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
				NeedGetMoreRows: 1,
				Infobar: Infobar);
			Severity = ExecuteDynamicSQL.ReturnCode;
			Data = ExecuteDynamicSQL.Data;
			Infobar = ExecuteDynamicSQL.Infobar;

			#endregion ExecuteMethodCall

			if (this.scalarFunction.Execute<int?>(
				"OBJECT_ID",
				"tempdb..#Results") != null)
			{
				this.sQLExpressionExecutor.Execute("DROP TABLE #Results");

			}
			return (Data, Severity);

		}

	}
}

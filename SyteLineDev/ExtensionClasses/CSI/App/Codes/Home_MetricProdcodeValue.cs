//PROJECT NAME: Codes
//CLASS NAME: Home_MetricProdcodeValue.cs

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

namespace CSI.Codes
{
	public class Home_MetricProdcodeValue : IHome_MetricProdcodeValue
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICLM_PerTotByProdcode iCLM_PerTotByProdcode;
		readonly ITransactionFactory transactionFactory;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IHome_MetricProdcodeValueCRUD iHome_MetricProdcodeValueCRUD;

		public Home_MetricProdcodeValue(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICLM_PerTotByProdcode iCLM_PerTotByProdcode,
			ITransactionFactory transactionFactory,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IHome_MetricProdcodeValueCRUD iHome_MetricProdcodeValueCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCLM_PerTotByProdcode = iCLM_PerTotByProdcode;
			this.transactionFactory = transactionFactory;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iHome_MetricProdcodeValueCRUD = iHome_MetricProdcodeValueCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Home_MetricProdcodeValueSp()
		{

			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iHome_MetricProdcodeValueCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iHome_MetricProdcodeValueCRUD.Optional_Module1Select();
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_MetricProdcodeValueSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iHome_MetricProdcodeValueCRUD.Optional_Module1Insert(optional_module1LoadResponse);

				while (this.iHome_MetricProdcodeValueCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iHome_MetricProdcodeValueCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iHome_MetricProdcodeValueCRUD.AltExtGen_Home_MetricProdcodeValueSp(ALTGEN_SpName);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iHome_MetricProdcodeValueCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iHome_MetricProdcodeValueCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_MetricProdcodeValueSp") != null)
			{
				var EXTGEN = this.iHome_MetricProdcodeValueCRUD.AltExtGen_Home_MetricProdcodeValueSp("dbo.EXTGEN_Home_MetricProdcodeValueSp");
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @StagingTable TABLE (
				    Whse         WhseType           ,
				    ProductCode  ProductCodeType    ,
				    InvAcct      PertotSortFieldType,
				    InvAcctUnit1 PertotSortFieldType,
				    InvAcctUnit2 PertotSortFieldType,
				    InvAcctUnit3 PertotSortFieldType,
				    InvAcctUnit4 PertotSortFieldType,
				    UBBalance1   AmountType         ,
				    UBBalance2   AmountType         ,
				    UBBalance3   AmountType         ,
				    UBBalance4   AmountType         ,
				    SiteRef      SiteType           );
				SELECT * into #tv_StagingTable from @StagingTable");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @ProductCode TABLE (
				    ProductCode ProductCodeType,
				    UBBalance   AmtTotType     );
				SELECT * into #tv_ProductCode from @ProductCode");
			//Please Generate the bounce for this stored procedure:CLM_PerTotByProdcodeSp
			var tv_StagingTableExecResult = this.iCLM_PerTotByProdcode.CLM_PerTotByProdcodeSp();
			this.iHome_MetricProdcodeValueCRUD.Tv_StagingtableInsert(tv_StagingTableExecResult.Data);
			var tv_StagingTable2LoadResponse = this.iHome_MetricProdcodeValueCRUD.Tv_Stagingtable2Select();

			Data = tv_StagingTable2LoadResponse;

			return (Data, Severity);
		}

	}
}

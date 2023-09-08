//PROJECT NAME: Logistics
//CLASS NAME: GetOrderParms.cs

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

namespace CSI.Logistics.Customer
{
	public class GetOrderParms : IGetOrderParms
    {
		readonly IApplicationDB appDB;

		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;

		public GetOrderParms(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}

		public (int? ReturnCode,
			int? OrderVerificationTemplate,
			int? OrderInvoiceTemplate,
			int? PackingSlipTemplate) 
		GetOrderParmsSp(int? OrderVerificationTemplate,
			int? OrderInvoiceTemplate,
			int? PackingSlipTemplate = null)
		{

			ListYesNoType _OrderVerificationTemplate = OrderVerificationTemplate;
			ListYesNoType _OrderInvoiceTemplate = OrderInvoiceTemplate;
			ReportTemplateIdType _PackingSlipTemplate = PackingSlipTemplate;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;

			if (existsChecker.Exists(
				tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GetOrderParmsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						[SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN ");

				#region CRUD LoadToRecord
				var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"SpName","CAST (NULL AS NVARCHAR)"},
						{"u0","[om].[ModuleName]"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GetOrderParmsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("GetOrderParmsSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);

				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords

				while (existsChecker.Exists(
					tableName: "#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("")))
				{
					//BEGIN
					#region CRUD LoadToVariable
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
					this.appDB.Load(tv_ALTGEN1LoadRequest);
					ALTGEN_SpName = _ALTGEN_SpName;
					#endregion  LoadToVariable

					var ALTGEN = AltExtGen_GetOrderParmsSp(_ALTGEN_SpName,
						OrderVerificationTemplate,
						OrderInvoiceTemplate,
						PackingSlipTemplate);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						OrderVerificationTemplate = _OrderVerificationTemplate;
						OrderInvoiceTemplate = _OrderInvoiceTemplate;
						PackingSlipTemplate = _PackingSlipTemplate;
						return (ALTGEN_Severity, OrderVerificationTemplate, OrderInvoiceTemplate, PackingSlipTemplate);
					}

					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					#region CRUD LoadToRecord
					var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"col0","1"},
						},
                        loadForChange: true, 
                        lockingType: LockingType.None,
                        tableName: "#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
					#endregion  LoadToRecord

					#region CRUD DeleteByRecord
					var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
						items: tv_ALTGEN2LoadResponse.Items);
					this.appDB.Delete(tv_ALTGEN2DeleteRequest);
					#endregion DeleteByRecord

					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					//END
				}
				//END
			}

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_GetOrderParmsSp") != null)
			{
				var EXTGEN = AltExtGen_GetOrderParmsSp("dbo.EXTGEN_GetOrderParmsSp",
					OrderVerificationTemplate,
					OrderInvoiceTemplate,
					PackingSlipTemplate);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.OrderVerificationTemplate, EXTGEN.OrderInvoiceTemplate, EXTGEN.PackingSlipTemplate);
				}
			}

			Severity = 0;

			#region CRUD LoadToVariable
			var coparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_OrderVerificationTemplate,"order_verification_rpt_template_id"},
					{_OrderInvoiceTemplate,"order_invoice_rpt_template_id"},
					{_PackingSlipTemplate,"packing_slip_rpt_template_id"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName: "coparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(coparmsLoadRequest);
			OrderVerificationTemplate = _OrderVerificationTemplate;
			OrderInvoiceTemplate = _OrderInvoiceTemplate;
			PackingSlipTemplate = _PackingSlipTemplate;
			#endregion  LoadToVariable

			OrderVerificationTemplate = _OrderVerificationTemplate;
			OrderInvoiceTemplate = _OrderInvoiceTemplate;
			PackingSlipTemplate = _PackingSlipTemplate;
			return (Severity, OrderVerificationTemplate, OrderInvoiceTemplate, PackingSlipTemplate);

		}

		public (int? ReturnCode, int? OrderVerificationTemplate,
			int? OrderInvoiceTemplate,
			int? PackingSlipTemplate) 
		AltExtGen_GetOrderParmsSp(string AltExtGenSp,
			int? OrderVerificationTemplate,
			int? OrderInvoiceTemplate,
			int? PackingSlipTemplate = null)
		{
			ListYesNoType _OrderVerificationTemplate = OrderVerificationTemplate;
			ListYesNoType _OrderInvoiceTemplate = OrderInvoiceTemplate;
			ReportTemplateIdType _PackingSlipTemplate = PackingSlipTemplate;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "OrderVerificationTemplate", _OrderVerificationTemplate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OrderInvoiceTemplate", _OrderInvoiceTemplate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PackingSlipTemplate", _PackingSlipTemplate, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				OrderVerificationTemplate = _OrderVerificationTemplate;
				OrderInvoiceTemplate = _OrderInvoiceTemplate;
				PackingSlipTemplate = _PackingSlipTemplate;

				return (Severity, OrderVerificationTemplate, OrderInvoiceTemplate, PackingSlipTemplate);
			}
		}
	}
}

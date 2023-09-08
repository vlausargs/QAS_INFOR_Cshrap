//PROJECT NAME: Finance
//CLASS NAME: CLM_DeprMethod.cs

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
using CSI.Data.Utilities;

namespace CSI.Finance
{
	public class CLM_DeprMethod : ICLM_DeprMethod
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IUnionUtil unionUtil;
		readonly ICLM_DeprMethodCRUD iCLM_DeprMethodCRUD;

		public CLM_DeprMethod(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IUnionUtil unionUtil,
			ICLM_DeprMethodCRUD iCLM_DeprMethodCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.unionUtil = unionUtil;
			this.iCLM_DeprMethodCRUD = iCLM_DeprMethodCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_DeprMethodSp()
		{

			ICollectionLoadResponse Data = null;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCLM_DeprMethodCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_DeprMethodCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCLM_DeprMethodCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCLM_DeprMethodCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_DeprMethodCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCLM_DeprMethodCRUD.AltExtGen_CLM_DeprMethodSp(ALTGEN_SpName);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_DeprMethodCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iCLM_DeprMethodCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_DeprMethodSp") != null)
			{
				var EXTGEN = this.iCLM_DeprMethodCRUD.AltExtGen_CLM_DeprMethodSp("dbo.EXTGEN_CLM_DeprMethodSp");
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			Severity = 0;
			var DeprMethodLoadResponse = this.iCLM_DeprMethodCRUD.SelectDeprmethod();
			unionUtil.Add(DeprMethodLoadResponse);

			var nonTableLoadResponse = this.iCLM_DeprMethodCRUD.SelectMethodSL();
			unionUtil.Add(nonTableLoadResponse);

			var nonTable1LoadResponse = this.iCLM_DeprMethodCRUD.SelectMethodSYD();
			unionUtil.Add(nonTable1LoadResponse);

			var nonTable2LoadResponse = this.iCLM_DeprMethodCRUD.SelectMethodUSAGE();
			unionUtil.Add(nonTable2LoadResponse);

			var nonTable3LoadResponse = this.iCLM_DeprMethodCRUD.SelectMethod125DB();
			unionUtil.Add(nonTable3LoadResponse);

			var nonTable4LoadResponse = this.iCLM_DeprMethodCRUD.SelectMethod150DB();
			unionUtil.Add(nonTable4LoadResponse);

			var nonTable5LoadResponse = this.iCLM_DeprMethodCRUD.SelectMethod175DB();
			unionUtil.Add(nonTable5LoadResponse);

			var nonTable6LoadResponse = this.iCLM_DeprMethodCRUD.SelectMethod200DB();
			unionUtil.Add(nonTable6LoadResponse);

			Data = unionUtil.Process(UnionType.UnionAll, "method");
			return (Data, Severity);

		}

	}
}

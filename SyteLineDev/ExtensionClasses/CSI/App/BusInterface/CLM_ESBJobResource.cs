//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBJobResource.cs

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

namespace CSI.BusInterface
{
	public class CLM_ESBJobResource : ICLM_ESBJobResource
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_ESBJobResourceCRUD iCLM_ESBJobResourceCRUD;

		public CLM_ESBJobResource(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICLM_ESBJobResourceCRUD iCLM_ESBJobResourceCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCLM_ESBJobResourceCRUD = iCLM_ESBJobResourceCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ESBJobResourceSP(
			string Job,
			int? Suffix,
			int? OperNum)
		{

			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iCLM_ESBJobResourceCRUD.CheckOptional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_ESBJobResourceCRUD.SelectOptional_Module();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCLM_ESBJobResourceCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCLM_ESBJobResourceCRUD.CheckTv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_ESBJobResourceCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCLM_ESBJobResourceCRUD.AltExtGen_CLM_ESBJobResourceSP(ALTGEN_SpName,
						Job,
						Suffix,
						OperNum);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_ESBJobResourceCRUD.SelectTv_ALTGEN(ALTGEN_SpName);
					this.iCLM_ESBJobResourceCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ESBJobResourceSP") != null)
			{
				var EXTGEN = this.iCLM_ESBJobResourceCRUD.AltExtGen_CLM_ESBJobResourceSP("dbo.EXTGEN_CLM_ESBJobResourceSP",
					Job,
					Suffix,
					OperNum);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			var ESBJobResourceViewLoadResponse = this.iCLM_ESBJobResourceCRUD.SelectEsbjobresourceview(Job, Suffix, OperNum);
			Data = ESBJobResourceViewLoadResponse;

			return (Data, Severity);
		}

	}
}

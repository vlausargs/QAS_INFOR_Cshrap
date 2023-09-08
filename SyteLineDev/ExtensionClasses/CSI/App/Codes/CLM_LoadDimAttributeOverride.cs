//PROJECT NAME: Codes
//CLASS NAME: CLM_LoadDimAttributeOverride.cs

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
	public class CLM_LoadDimAttributeOverride : ICLM_LoadDimAttributeOverride
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_LoadDimAttributeOverrideCRUD iCLM_LoadDimAttributeOverrideCRUD;

		public CLM_LoadDimAttributeOverride(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICLM_LoadDimAttributeOverrideCRUD iCLM_LoadDimAttributeOverrideCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCLM_LoadDimAttributeOverrideCRUD = iCLM_LoadDimAttributeOverrideCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_LoadDimAttributeOverrideSp(
			string Acct = null,
			string SubscriberObjectName = null,
			Guid? SubscriberObjectRowPointer = null)
		{

			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iCLM_LoadDimAttributeOverrideCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_LoadDimAttributeOverrideCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCLM_LoadDimAttributeOverrideCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCLM_LoadDimAttributeOverrideCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_LoadDimAttributeOverrideCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCLM_LoadDimAttributeOverrideCRUD.AltExtGen_CLM_LoadDimAttributeOverrideSp(ALTGEN_SpName,
						Acct,
						SubscriberObjectName,
						SubscriberObjectRowPointer);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_LoadDimAttributeOverrideCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iCLM_LoadDimAttributeOverrideCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_LoadDimAttributeOverrideSp") != null)
			{
				var EXTGEN = this.iCLM_LoadDimAttributeOverrideCRUD.AltExtGen_CLM_LoadDimAttributeOverrideSp("dbo.EXTGEN_CLM_LoadDimAttributeOverrideSp",
					Acct,
					SubscriberObjectName,
					SubscriberObjectRowPointer);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			var chartLoadResponse = this.iCLM_LoadDimAttributeOverrideCRUD.SelectChart(Acct, SubscriberObjectName, SubscriberObjectRowPointer);
			Data = chartLoadResponse;

			return (Data, Severity);
		}

	}
}

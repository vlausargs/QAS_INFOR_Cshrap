//PROJECT NAME: Production
//CLASS NAME: ApsClearPlannerStatus.cs

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

namespace CSI.Production.APS
{
	public class ApsClearPlannerStatus : IApsClearPlannerStatus
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IApsClearPlannerStatusCRUD iApsClearPlannerStatusCRUD;

		public ApsClearPlannerStatus(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IApsClearPlannerStatusCRUD iApsClearPlannerStatusCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iApsClearPlannerStatusCRUD = iApsClearPlannerStatusCRUD;
		}

		public int? ApsClearPlannerStatusSp(
			int? AltNo)
		{

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iApsClearPlannerStatusCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iApsClearPlannerStatusCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iApsClearPlannerStatusCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iApsClearPlannerStatusCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iApsClearPlannerStatusCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iApsClearPlannerStatusCRUD.AltExtGen_ApsClearPlannerStatusSp(ALTGEN_SpName,
						AltNo);
					ALTGEN_Severity = ALTGEN;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iApsClearPlannerStatusCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iApsClearPlannerStatusCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ApsClearPlannerStatusSp") != null)
			{
				var EXTGEN = this.iApsClearPlannerStatusCRUD.AltExtGen_ApsClearPlannerStatusSp("dbo.EXTGEN_ApsClearPlannerStatusSp",
					AltNo);
				int? EXTGEN_Severity = EXTGEN;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity);
				}
			}

			Severity = 0;
			var ALTPLANLoadResponse = this.iApsClearPlannerStatusCRUD.ALTPLANSelect(AltNo);
			this.iApsClearPlannerStatusCRUD.ALTPLANUpdate(ALTPLANLoadResponse);
			return (Severity);

		}

	}
}

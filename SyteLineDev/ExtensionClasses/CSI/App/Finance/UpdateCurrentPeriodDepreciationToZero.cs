//PROJECT NAME: Finance
//CLASS NAME: UpdateCurrentPeriodDepreciationToZero.cs

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

namespace CSI.Finance
{
	public class UpdateCurrentPeriodDepreciationToZero : IUpdateCurrentPeriodDepreciationToZero
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IUpdateCurrentPeriodDepreciationToZeroCRUD iUpdateCurrentPeriodDepreciationToZeroCRUD;

		public UpdateCurrentPeriodDepreciationToZero(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IUpdateCurrentPeriodDepreciationToZeroCRUD iUpdateCurrentPeriodDepreciationToZeroCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iUpdateCurrentPeriodDepreciationToZeroCRUD = iUpdateCurrentPeriodDepreciationToZeroCRUD;
		}

		public (
			int? ReturnCode,
			int? pNeedToUpdateCurPerDepr)
		UpdateCurrentPeriodDepreciationToZeroSp(
			string pFaNum,
			int? pNeedToUpdateCurPerDepr)
		{

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iUpdateCurrentPeriodDepreciationToZeroCRUD.CheckOptional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iUpdateCurrentPeriodDepreciationToZeroCRUD.SelectOptional_Module();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iUpdateCurrentPeriodDepreciationToZeroCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iUpdateCurrentPeriodDepreciationToZeroCRUD.CheckTv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iUpdateCurrentPeriodDepreciationToZeroCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iUpdateCurrentPeriodDepreciationToZeroCRUD.AltExtGen_UpdateCurrentPeriodDepreciationToZeroSp(ALTGEN_SpName,
						pFaNum,
						pNeedToUpdateCurPerDepr);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, pNeedToUpdateCurPerDepr);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iUpdateCurrentPeriodDepreciationToZeroCRUD.SelectTv_ALTGEN(ALTGEN_SpName);
					this.iUpdateCurrentPeriodDepreciationToZeroCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_UpdateCurrentPeriodDepreciationToZeroSp") != null)
			{
				var EXTGEN = this.iUpdateCurrentPeriodDepreciationToZeroCRUD.AltExtGen_UpdateCurrentPeriodDepreciationToZeroSp("dbo.EXTGEN_UpdateCurrentPeriodDepreciationToZeroSp",
					pFaNum,
					pNeedToUpdateCurPerDepr);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.pNeedToUpdateCurPerDepr);
				}
			}

			Severity = 0;
			if (sQLUtil.SQLEqual(pNeedToUpdateCurPerDepr, 1) == true)
			{
				var fadeprLoadResponse = this.iUpdateCurrentPeriodDepreciationToZeroCRUD.SelectFadepr(pFaNum);
				this.iUpdateCurrentPeriodDepreciationToZeroCRUD.UpdateFadepr(fadeprLoadResponse);

			}
			pNeedToUpdateCurPerDepr = 0;
			return (Severity, pNeedToUpdateCurPerDepr);

		}

	}
}

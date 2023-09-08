//PROJECT NAME: Production
//CLASS NAME: CurrentMaterialsOperChg.cs

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

namespace CSI.Production
{
	public class CurrentMaterialsOperChg : ICurrentMaterialsOperChg
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IIsAddonAvailable iIsAddonAvailable;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICurrentMaterialsOperChgCRUD iCurrentMaterialsOperChgCRUD;

		public CurrentMaterialsOperChg(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IIsAddonAvailable iIsAddonAvailable,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICurrentMaterialsOperChgCRUD iCurrentMaterialsOperChgCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iIsAddonAvailable = iIsAddonAvailable;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCurrentMaterialsOperChgCRUD = iCurrentMaterialsOperChgCRUD;
		}

		public (
			int? ReturnCode,
			int? MOShared,
			decimal? MOSecondsPerCycle,
			decimal? MOFormulaMatlWeight,
			string MOFormulaMatlWeightUnits,
			string InfoBar)
		CurrentMaterialsOperChgSp(
			string Job,
			int? Suffix,
			int? OperNum,
			int? MOShared,
			decimal? MOSecondsPerCycle,
			decimal? MOFormulaMatlWeight,
			string MOFormulaMatlWeightUnits,
			string InfoBar)
		{

			ListYesNoType _MOShared = MOShared;
			MO_CycleTimeType _MOSecondsPerCycle = MOSecondsPerCycle;
			WeightType _MOFormulaMatlWeight = MOFormulaMatlWeight;
			WeightUnitsType _MOFormulaMatlWeightUnits = MOFormulaMatlWeightUnits;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCurrentMaterialsOperChgCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCurrentMaterialsOperChgCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCurrentMaterialsOperChgCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCurrentMaterialsOperChgCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCurrentMaterialsOperChgCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCurrentMaterialsOperChgCRUD.AltExtGen_CurrentMaterialsOperChgSp(ALTGEN_SpName,
						Job,
						Suffix,
						OperNum,
						MOShared,
						MOSecondsPerCycle,
						MOFormulaMatlWeight,
						MOFormulaMatlWeightUnits,
						InfoBar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, MOShared, MOSecondsPerCycle, MOFormulaMatlWeight, MOFormulaMatlWeightUnits, InfoBar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCurrentMaterialsOperChgCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iCurrentMaterialsOperChgCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CurrentMaterialsOperChgSp") != null)
			{
				var EXTGEN = this.iCurrentMaterialsOperChgCRUD.AltExtGen_CurrentMaterialsOperChgSp("dbo.EXTGEN_CurrentMaterialsOperChgSp",
					Job,
					Suffix,
					OperNum,
					MOShared,
					MOSecondsPerCycle,
					MOFormulaMatlWeight,
					MOFormulaMatlWeightUnits,
					InfoBar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.MOShared, EXTGEN.MOSecondsPerCycle, EXTGEN.MOFormulaMatlWeight, EXTGEN.MOFormulaMatlWeightUnits, EXTGEN.InfoBar);
				}
			}

			Severity = 0;
			MOShared = 0;
			MOSecondsPerCycle = 0;
			MOFormulaMatlWeight = 0;
			MOFormulaMatlWeightUnits = null;
			if (sQLUtil.SQLNotEqual(this.iIsAddonAvailable.IsAddonAvailableFn("MoldingPack"), 1) == true)
			{
				return (Severity, MOShared, MOSecondsPerCycle, MOFormulaMatlWeight, MOFormulaMatlWeightUnits, InfoBar);

			}
			(MOShared, MOSecondsPerCycle, MOFormulaMatlWeight, MOFormulaMatlWeightUnits, rowCount) = this.iCurrentMaterialsOperChgCRUD.LoadJobroute(Job, Suffix, OperNum, MOShared, MOSecondsPerCycle, MOFormulaMatlWeight, MOFormulaMatlWeightUnits);
			return (Severity, MOShared, MOSecondsPerCycle, MOFormulaMatlWeight, MOFormulaMatlWeightUnits, InfoBar);

		}

	}
}

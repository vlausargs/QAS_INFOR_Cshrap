//PROJECT NAME: Production
//CLASS NAME: RSQC_GetHoldLoc.cs

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

namespace CSI.Production.Quality
{
	public class RSQC_GetHoldLoc : IRSQC_GetHoldLoc
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IIsAddonAvailable iIsAddonAvailable;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRSQC_GetHoldLocCRUD iRSQC_GetHoldLocCRUD;

		public RSQC_GetHoldLoc(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IIsAddonAvailable iIsAddonAvailable,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IRSQC_GetHoldLocCRUD iRSQC_GetHoldLocCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iIsAddonAvailable = iIsAddonAvailable;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iRSQC_GetHoldLocCRUD = iRSQC_GetHoldLocCRUD;
		}

		public (
			int? ReturnCode,
			string o_hold_loc,
			int? o_use_hold_loc)
		RSQC_GetHoldLocSp(
			string o_hold_loc,
			int? o_use_hold_loc)
		{

			LocType _o_hold_loc = o_hold_loc;
			IntType _o_use_hold_loc = o_use_hold_loc;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iRSQC_GetHoldLocCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRSQC_GetHoldLocCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iRSQC_GetHoldLocCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iRSQC_GetHoldLocCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iRSQC_GetHoldLocCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iRSQC_GetHoldLocCRUD.AltExtGen_RSQC_GetHoldLocSp(ALTGEN_SpName,
						o_hold_loc,
						o_use_hold_loc);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, o_hold_loc, o_use_hold_loc);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iRSQC_GetHoldLocCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iRSQC_GetHoldLocCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_RSQC_GetHoldLocSp") != null)
			{
				var EXTGEN = this.iRSQC_GetHoldLocCRUD.AltExtGen_RSQC_GetHoldLocSp("dbo.EXTGEN_RSQC_GetHoldLocSp",
					o_hold_loc,
					o_use_hold_loc);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.o_hold_loc, EXTGEN.o_use_hold_loc);
				}
			}

			if (sQLUtil.SQLNotEqual(this.iIsAddonAvailable.IsAddonAvailableFn("QualityControlSolution"), 1) == true)
			{
				return (Severity = 0, o_hold_loc, o_use_hold_loc);
			}
			Severity = 0;
			(o_hold_loc, o_use_hold_loc, rowCount) = this.iRSQC_GetHoldLocCRUD.Rs_QcparmsuLoad(o_hold_loc, o_use_hold_loc);

			return (Severity, o_hold_loc, o_use_hold_loc);
		}

	}
}

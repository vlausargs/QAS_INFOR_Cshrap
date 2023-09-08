//PROJECT NAME: Production
//CLASS NAME: RSQC_CalcInterval.cs

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
	public class RSQC_CalcInterval : IRSQC_CalcInterval
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IIsAddonAvailable iIsAddonAvailable;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRSQC_CalcIntervalCRUD iRSQC_CalcIntervalCRUD;

		public RSQC_CalcInterval(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IIsAddonAvailable iIsAddonAvailable,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IDateTimeUtil dateTimeUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IRSQC_CalcIntervalCRUD iRSQC_CalcIntervalCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iIsAddonAvailable = iIsAddonAvailable;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.dateTimeUtil = dateTimeUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iRSQC_CalcIntervalCRUD = iRSQC_CalcIntervalCRUD;
		}

		public (
			int? ReturnCode,
			DateTime? NewDate,
			string Infobar)
		RSQC_CalcIntervalSp(
			DateTime? Date,
			int? Interval,
			DateTime? NewDate,
			string Infobar)
		{

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iRSQC_CalcIntervalCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRSQC_CalcIntervalCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iRSQC_CalcIntervalCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iRSQC_CalcIntervalCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iRSQC_CalcIntervalCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iRSQC_CalcIntervalCRUD.AltExtGen_RSQC_CalcIntervalSp(ALTGEN_SpName,
						Date,
						Interval,
						NewDate,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, NewDate, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iRSQC_CalcIntervalCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iRSQC_CalcIntervalCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_RSQC_CalcIntervalSp") != null)
			{
				var EXTGEN = this.iRSQC_CalcIntervalCRUD.AltExtGen_RSQC_CalcIntervalSp("dbo.EXTGEN_RSQC_CalcIntervalSp",
					Date,
					Interval,
					NewDate,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.NewDate, EXTGEN.Infobar);
				}
			}

			if (sQLUtil.SQLNotEqual(this.iIsAddonAvailable.IsAddonAvailableFn("QualityControlSolution"), 1) == true)
			{
				return (Severity = 0, NewDate, Infobar);

			}
			Infobar = "";
			Severity = 0;
			NewDate = convertToUtil.ToDateTime(Date);
			Interval = (int?)(stringUtil.IsNull(
				Interval,
				0));
			NewDate = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Day", Interval, Date));
			return (Severity, NewDate, Infobar);

		}

	}
}

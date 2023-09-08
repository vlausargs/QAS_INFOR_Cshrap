//PROJECT NAME: Production
//CLASS NAME: ApsBOMDel.cs

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
	public class ApsBOMDel : IApsBOMDel
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ISQLCollectionLoad sQLCollectionLoad;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IApsBOMDelCRUD iApsBOMDelCRUD;

		public ApsBOMDel(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ISQLCollectionLoad sQLCollectionLoad,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IApsBOMDelCRUD iApsBOMDelCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.sQLCollectionLoad = sQLCollectionLoad;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iApsBOMDelCRUD = iApsBOMDelCRUD;
		}

		public int? ApsBOMDelSp(
			int? AltNo,
			Guid? RowPointer)
		{

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			string Table = null;
			string ParmList = null;
			string SQLStr = null;
			if (this.iApsBOMDelCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iApsBOMDelCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iApsBOMDelCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iApsBOMDelCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iApsBOMDelCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iApsBOMDelCRUD.AltExtGen_ApsBOMDelSp(ALTGEN_SpName,
						AltNo,
						RowPointer);
					ALTGEN_Severity = ALTGEN;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iApsBOMDelCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iApsBOMDelCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ApsBOMDelSp") != null)
			{
				var EXTGEN = this.iApsBOMDelCRUD.AltExtGen_ApsBOMDelSp("dbo.EXTGEN_ApsBOMDelSp",
					AltNo,
					RowPointer);
				int? EXTGEN_Severity = EXTGEN;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity);
				}
			}

			Severity = 0;
			ParmList = "@P_RowPointer RowPointerType";
			Table = stringUtil.Concat("BOM", stringUtil.Replace(
				stringUtil.Str(
					AltNo,
					3),
				" ",
				"0"));
			SQLStr = stringUtil.Concat("DELETE FROM ", Table, " WHERE RowPointer = @P_RowPointer");

			var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQLStr
			, ParmList
			, RowPointer);
			Severity = execResult.Severity;

			return (Severity);

		}

	}
}

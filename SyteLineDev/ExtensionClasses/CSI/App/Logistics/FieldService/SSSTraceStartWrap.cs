//PROJECT NAME: Logistics
//CLASS NAME: SSSTraceStartWrap.cs

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

namespace CSI.Logistics.FieldService
{
	public class SSSTraceStartWrap : ISSSTraceStartWrap
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISSSTraceStart iSSSTraceStart;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ISSSTraceStartWrapCRUD iSSSTraceStartWrapCRUD;

		public SSSTraceStartWrap(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISSSTraceStart iSSSTraceStart,
			ISQLValueComparerUtil sQLUtil,
			ISSSTraceStartWrapCRUD iSSSTraceStartWrapCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.iSSSTraceStart = iSSSTraceStart;
			this.sQLUtil = sQLUtil;
			this.iSSSTraceStartWrapCRUD = iSSSTraceStartWrapCRUD;
		}

		public (
			int? ReturnCode,
			int? oTraceID,
			string oServerName,
			string oTraceFile,
			string Infobar)
		SSSTraceStartWrapSp(
			long? iMaxTraceSizeMB,
			int? oTraceID,
			string oServerName,
			string oTraceFile,
			string Infobar,
			string FilterDatabaseNameLike,
			string FilterHostNameLike,
			string FilterLoginNameLike,
			string FilterTextDataLike,
			string FilterObjectNameLike,
			int? FilterSPIDEQ)
		{

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iSSSTraceStartWrapCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] sysname);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iSSSTraceStartWrapCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iSSSTraceStartWrapCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iSSSTraceStartWrapCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iSSSTraceStartWrapCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iSSSTraceStartWrapCRUD.AltExtGen_SSSTraceStartWrapSp(ALTGEN_SpName,
						iMaxTraceSizeMB,
						oTraceID,
						oServerName,
						oTraceFile,
						Infobar,
						FilterDatabaseNameLike,
						FilterHostNameLike,
						FilterLoginNameLike,
						FilterTextDataLike,
						FilterObjectNameLike,
						FilterSPIDEQ);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, oTraceID, oServerName, oTraceFile, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iSSSTraceStartWrapCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iSSSTraceStartWrapCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_SSSTraceStartWrapSp") != null)
			{
				var EXTGEN = this.iSSSTraceStartWrapCRUD.AltExtGen_SSSTraceStartWrapSp("dbo.EXTGEN_SSSTraceStartWrapSp",
					iMaxTraceSizeMB,
					oTraceID,
					oServerName,
					oTraceFile,
					Infobar,
					FilterDatabaseNameLike,
					FilterHostNameLike,
					FilterLoginNameLike,
					FilterTextDataLike,
					FilterObjectNameLike,
					FilterSPIDEQ);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.oTraceID, EXTGEN.oServerName, EXTGEN.oTraceFile, EXTGEN.Infobar);
				}
			}

			Severity = 0;

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: SSSTraceStartSp
			var SSSTraceStart = this.iSSSTraceStart.SSSTraceStartSp(
				iMaxTraceSizeMB: iMaxTraceSizeMB,
				oTraceID: oTraceID,
				oServerName: oServerName,
				oTraceFile: oTraceFile,
				Infobar: Infobar,
				FilterDatabaseNameLike: FilterDatabaseNameLike,
				FilterHostNameLike: FilterHostNameLike,
				FilterLoginNameLike: FilterLoginNameLike,
				FilterTextDataLike: FilterTextDataLike,
				FilterObjectNameLike: FilterObjectNameLike,
				FilterSPIDEQ: FilterSPIDEQ);
			Severity = SSSTraceStart.ReturnCode;
			oTraceID = SSSTraceStart.oTraceID;
			oServerName = SSSTraceStart.oServerName;
			oTraceFile = SSSTraceStart.oTraceFile;
			Infobar = SSSTraceStart.Infobar;

			#endregion ExecuteMethodCall

			return (Severity, oTraceID, oServerName, oTraceFile, Infobar);

		}

	}
}

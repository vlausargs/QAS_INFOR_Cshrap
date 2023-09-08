//PROJECT NAME: Production
//CLASS NAME: CLM_ApsWhatIfEXRCPTItem.cs

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
	public class CLM_ApsWhatIfEXRCPTItem : ICLM_ApsWhatIfEXRCPTItem
	{
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ISQLCollectionLoad sQLCollectionLoad;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_ApsWhatIfEXRCPTItemCRUD iCLM_ApsWhatIfEXRCPTItemCRUD;

		public CLM_ApsWhatIfEXRCPTItem(IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ISQLCollectionLoad sQLCollectionLoad,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ICLM_ApsWhatIfEXRCPTItemCRUD iCLM_ApsWhatIfEXRCPTItemCRUD)
		{
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.sQLCollectionLoad = sQLCollectionLoad;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iCLM_ApsWhatIfEXRCPTItemCRUD = iCLM_ApsWhatIfEXRCPTItemCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ApsWhatIfEXRCPTItemSp(
			int? AltNo,
			string MaterialIdFilter = null)
		{
			if (bunchedLoadCollection != null)
				bunchedLoadCollection.StartBunching();

			try
			{
				ICollectionLoadResponse Data = null;

				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				int? rowCount = null;
				int? Severity = null;
				string SQLStr = null;
				string MATERIAL = null;
				if (this.iCLM_ApsWhatIfEXRCPTItemCRUD.Optional_ModuleForExists())
				{
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");
					var optional_module1LoadResponse = this.iCLM_ApsWhatIfEXRCPTItemCRUD.Optional_Module1Select();
					var optional_module1RequiredColumns = new List<string>() { "SpName" };

					optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

					this.iCLM_ApsWhatIfEXRCPTItemCRUD.Optional_Module1Insert(optional_module1LoadResponse);
					while (this.iCLM_ApsWhatIfEXRCPTItemCRUD.Tv_ALTGENForExists())
					{
						(ALTGEN_SpName, rowCount) = this.iCLM_ApsWhatIfEXRCPTItemCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
						var ALTGEN = this.iCLM_ApsWhatIfEXRCPTItemCRUD.AltExtGen_CLM_ApsWhatIfEXRCPTItemSp(ALTGEN_SpName,
							AltNo,
							MaterialIdFilter);
						ALTGEN_Severity = ALTGEN.ReturnCode;

						if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
						{
							return (ALTGEN.Data, ALTGEN_Severity);
						}
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
						/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
						var tv_ALTGEN2LoadResponse = this.iCLM_ApsWhatIfEXRCPTItemCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
						this.iCLM_ApsWhatIfEXRCPTItemCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					}
				}
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ApsWhatIfEXRCPTItemSp") != null)
				{
					var EXTGEN = this.iCLM_ApsWhatIfEXRCPTItemCRUD.AltExtGen_CLM_ApsWhatIfEXRCPTItemSp("dbo.EXTGEN_CLM_ApsWhatIfEXRCPTItemSp",
						AltNo,
						MaterialIdFilter);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;

					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}

				Severity = 0;
				MATERIAL = stringUtil.Concat("MATL", stringUtil.Replace(
					stringUtil.Str(
						AltNo,
						3),
					" ",
					"0"));
				if (MaterialIdFilter == null || sQLUtil.SQLEqual(MaterialIdFilter, "") == true)
				{
					MaterialIdFilter = "%";
				}
				SQLStr = stringUtil.Concat(@"SELECT
					  mat.MATERIALID ", " FROM ", stringUtil.QuoteName(MATERIAL), " mat ", " WHERE (mat.FLAGS & 1) = 1 AND mat.MATERIALID LIKE @MaterialIdFilter ORDER BY mat.MATERIALID");

				var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQLStr
				, "@MaterialIdFilter LongListType"
				, MaterialIdFilter);
				Data = execResult.Data;
				Severity = execResult.Severity;
				/* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */

				return (Data, Severity);
			}
			finally
			{
				if (bunchedLoadCollection != null)
					bunchedLoadCollection.EndBunching();
			}
		}
	}
}

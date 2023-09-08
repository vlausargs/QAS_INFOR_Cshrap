//PROJECT NAME: Production
//CLASS NAME: CurrentMaterialsJobItemData.cs

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
	public class CurrentMaterialsJobItemData : ICurrentMaterialsJobItemData
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICurrentMaterialsJobItemDataCRUD iCurrentMaterialsJobItemDataCRUD;

		public CurrentMaterialsJobItemData(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICurrentMaterialsJobItemDataCRUD iCurrentMaterialsJobItemDataCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCurrentMaterialsJobItemDataCRUD = iCurrentMaterialsJobItemDataCRUD;
		}

		public (
			int? ReturnCode,
			int? ItemPlanFlag)
		CurrentMaterialsJobItemDataSp(
			string Item,
			int? ItemPlanFlag)
		{
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCurrentMaterialsJobItemDataCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCurrentMaterialsJobItemDataCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCurrentMaterialsJobItemDataCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCurrentMaterialsJobItemDataCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCurrentMaterialsJobItemDataCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCurrentMaterialsJobItemDataCRUD.AltExtGen_CurrentMaterialsJobItemDataSp(ALTGEN_SpName,
						Item,
						ItemPlanFlag);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, ItemPlanFlag);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCurrentMaterialsJobItemDataCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iCurrentMaterialsJobItemDataCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CurrentMaterialsJobItemDataSp") != null)
			{
				var EXTGEN = this.iCurrentMaterialsJobItemDataCRUD.AltExtGen_CurrentMaterialsJobItemDataSp("dbo.EXTGEN_CurrentMaterialsJobItemDataSp",
					Item,
					ItemPlanFlag);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.ItemPlanFlag);
				}
			}

			Severity = 0;
			ItemPlanFlag = 0;
			(ItemPlanFlag, rowCount) = this.iCurrentMaterialsJobItemDataCRUD.LoadItem(Item, ItemPlanFlag);
			return (Severity, ItemPlanFlag);

		}

	}
}

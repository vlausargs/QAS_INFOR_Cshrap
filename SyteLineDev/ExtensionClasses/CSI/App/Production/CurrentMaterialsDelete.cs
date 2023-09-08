//PROJECT NAME: Production
//CLASS NAME: CurrentMaterialsDelete.cs

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
	public class CurrentMaterialsDelete : ICurrentMaterialsDelete
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IAsRulesCmpCstI iAsRulesCmpCstI;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICurrentMaterialsDeleteCRUD iCurrentMaterialsDeleteCRUD;

		public CurrentMaterialsDelete(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IAsRulesCmpCstI iAsRulesCmpCstI,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICurrentMaterialsDeleteCRUD iCurrentMaterialsDeleteCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iAsRulesCmpCstI = iAsRulesCmpCstI;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCurrentMaterialsDeleteCRUD = iCurrentMaterialsDeleteCRUD;
		}

		public (
			int? ReturnCode,
			string Infobar)
		CurrentMaterialsDeleteSp(
			string JobType,
			string ItmItem,
			string Infobar)
		{

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			Guid? ItemPointer = null;
			if (this.iCurrentMaterialsDeleteCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCurrentMaterialsDeleteCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCurrentMaterialsDeleteCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCurrentMaterialsDeleteCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCurrentMaterialsDeleteCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCurrentMaterialsDeleteCRUD.AltExtGen_CurrentMaterialsDeleteSp(ALTGEN_SpName,
						JobType,
						ItmItem,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCurrentMaterialsDeleteCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iCurrentMaterialsDeleteCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CurrentMaterialsDeleteSp") != null)
			{
				var EXTGEN = this.iCurrentMaterialsDeleteCRUD.AltExtGen_CurrentMaterialsDeleteSp("dbo.EXTGEN_CurrentMaterialsDeleteSp",
					JobType,
					ItmItem,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}

			Severity = 0;
			Infobar = null;
			if (sQLUtil.SQLEqual(JobType, "S") == true || sQLUtil.SQLEqual(JobType, "C") == true)
			{
				(ItemPointer, rowCount) = this.iCurrentMaterialsDeleteCRUD.LoadItemLoad(ItmItem, ItemPointer);

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: AsRulesCmpCstISp
				var AsRulesCmpCstI = this.iAsRulesCmpCstI.AsRulesCmpCstISp(
					JobType: JobType,
					RowPointer: ItemPointer,
					Infobar: Infobar);
				Severity = AsRulesCmpCstI.ReturnCode;
				Infobar = AsRulesCmpCstI.Infobar;

				#endregion ExecuteMethodCall

				if (sQLUtil.SQLNotEqual(Severity, 0) == true)
				{
					return (Severity, Infobar);
				}

			}
			return (Severity, Infobar);

		}

	}
}

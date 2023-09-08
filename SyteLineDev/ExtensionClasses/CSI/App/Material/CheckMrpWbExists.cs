//PROJECT NAME: Material
//CLASS NAME: CheckMrpWbExists.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CheckMrpWbExists : ICheckMrpWbExists
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IHighCharacter highCharacter;
		readonly ILowCharacter lowCharacter;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICheckMrpWbExistsCRUD iCheckMrpWbExistsCRUD;

		public CheckMrpWbExists(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IHighCharacter highCharacter,
			ILowCharacter lowCharacter,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ICheckMrpWbExistsCRUD iCheckMrpWbExistsCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.highCharacter = highCharacter;
			this.lowCharacter = lowCharacter;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iCheckMrpWbExistsCRUD = iCheckMrpWbExistsCRUD;
		}

		public (
			int? ReturnCode,
			int? MrpWbExists,
			string Infobar)
		CheckMrpWbExistsSp(
			string FromItem,
			string ToItem,
			int? MrpWbExists,
			string Infobar)
		{

			ListYesNoType _MrpWbExists = MrpWbExists;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCheckMrpWbExistsCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCheckMrpWbExistsCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCheckMrpWbExistsCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCheckMrpWbExistsCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCheckMrpWbExistsCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCheckMrpWbExistsCRUD.AltExtGen_CheckMrpWbExistsSp(ALTGEN_SpName,
						FromItem,
						ToItem,
						MrpWbExists,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, MrpWbExists, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCheckMrpWbExistsCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCheckMrpWbExistsCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CheckMrpWbExistsSp") != null)
			{
				var EXTGEN = this.iCheckMrpWbExistsCRUD.AltExtGen_CheckMrpWbExistsSp("dbo.EXTGEN_CheckMrpWbExistsSp",
					FromItem,
					ToItem,
					MrpWbExists,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.MrpWbExists, EXTGEN.Infobar);
				}
			}

			Severity = 0;
			Infobar = null;
			FromItem = stringUtil.IsNull(
				FromItem,
				lowCharacter.LowCharacterFn());
			ToItem = stringUtil.IsNull(
				ToItem,
				highCharacter.HighCharacterFn());
			MrpWbExists = 0;
			(MrpWbExists, rowCount) = this.iCheckMrpWbExistsCRUD.Mrp_WbLoad(FromItem, ToItem, MrpWbExists);
			return (Severity, MrpWbExists, Infobar);

		}

	}
}

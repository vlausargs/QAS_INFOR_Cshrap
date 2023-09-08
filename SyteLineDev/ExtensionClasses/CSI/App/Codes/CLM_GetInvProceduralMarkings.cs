//PROJECT NAME: Codes
//CLASS NAME: CLM_GetInvProceduralMarkings.cs

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
using CSI.Material;

namespace CSI.Codes
{
	public class CLM_GetInvProceduralMarkings : ICLM_GetInvProceduralMarkings
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_GetInvProceduralMarkingsCRUD iCLM_GetInvProceduralMarkingsCRUD;
		readonly IExpandKyByType expandKyByType;

		public CLM_GetInvProceduralMarkings(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICLM_GetInvProceduralMarkingsCRUD iCLM_GetInvProceduralMarkingsCRUD,
			IExpandKyByType expandKyByType)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCLM_GetInvProceduralMarkingsCRUD = iCLM_GetInvProceduralMarkingsCRUD;
			this.expandKyByType = expandKyByType;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_GetInvProceduralMarkingsSp(
			string InvNum,
			int? InvSeq,
			string SiteRef)
		{
			InvNum = expandKyByType.ExpandKyByTypeFn("InvNumType", InvNum);

			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iCLM_GetInvProceduralMarkingsCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_GetInvProceduralMarkingsCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCLM_GetInvProceduralMarkingsCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCLM_GetInvProceduralMarkingsCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_GetInvProceduralMarkingsCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCLM_GetInvProceduralMarkingsCRUD.AltExtGen_CLM_GetInvProceduralMarkingsSp(ALTGEN_SpName,
						InvNum,
						InvSeq,
						SiteRef);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_GetInvProceduralMarkingsCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iCLM_GetInvProceduralMarkingsCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_GetInvProceduralMarkingsSp") != null)
			{
				var EXTGEN = this.iCLM_GetInvProceduralMarkingsCRUD.AltExtGen_CLM_GetInvProceduralMarkingsSp("dbo.EXTGEN_CLM_GetInvProceduralMarkingsSp",
					InvNum,
					InvSeq,
					SiteRef);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			var vat_procedural_marking_allLoadResponse = this.iCLM_GetInvProceduralMarkingsCRUD.SelectVat_Procedural_Marking_All(SiteRef, InvNum, InvSeq);
			Data = vat_procedural_marking_allLoadResponse;

			return (Data, Severity);
		}

	}
}

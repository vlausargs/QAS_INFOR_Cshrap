//PROJECT NAME: PLLOC
//CLASS NAME: CLM_VatProceduralMarkings.cs

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
using PLLOC.Interfaces;

namespace PLLOC.Objects
{
	public class CLM_VatProceduralMarkingsSp : ICLM_VatProceduralMarkingsSp
	{
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IStringUtil stringUtil;
		readonly IHighDate iHighDate;
		readonly ILowDate iLowDate;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_VatProceduralMarkingsCRUD iCLM_VatProceduralMarkingsCRUD;

		public CLM_VatProceduralMarkingsSp(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IStringUtil stringUtil,
			IHighDate iHighDate,
			ILowDate iLowDate,
			ISQLValueComparerUtil sQLUtil,
			ICLM_VatProceduralMarkingsCRUD iCLM_VatProceduralMarkingsCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.stringUtil = stringUtil;
			this.iHighDate = iHighDate;
			this.iLowDate = iLowDate;
			this.sQLUtil = sQLUtil;
			this.iCLM_VatProceduralMarkingsCRUD = iCLM_VatProceduralMarkingsCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		ExecuteSp(
			DateTime? BeginTaxDate = null,
			DateTime? EndTaxDate = null)
		{
			ICollectionLoadResponse Data = null;
			int? Severity = 0;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iCLM_VatProceduralMarkingsCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_VatProceduralMarkingsCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCLM_VatProceduralMarkingsCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCLM_VatProceduralMarkingsCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_VatProceduralMarkingsCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_VatProceduralMarkingsCRUD.AltExtGen_CLM_VatProceduralMarkingsSp(ALTGEN_SpName,
						BeginTaxDate,
						EndTaxDate);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_VatProceduralMarkingsCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_VatProceduralMarkingsCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
				}
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_VatProceduralMarkingsSp") != null)
			{
				var EXTGEN = this.iCLM_VatProceduralMarkingsCRUD.AltExtGen_CLM_VatProceduralMarkingsSp("dbo.EXTGEN_CLM_VatProceduralMarkingsSp",
					BeginTaxDate,
					EndTaxDate);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			BeginTaxDate = convertToUtil.ToDateTime(stringUtil.Coalesce<DateTime?>(BeginTaxDate, this.iLowDate.LowDateFn()));
			EndTaxDate = convertToUtil.ToDateTime(stringUtil.Coalesce<DateTime?>(EndTaxDate, this.iHighDate.HighDateFn()));
			var VatProcMarkingsLoadResponse = this.iCLM_VatProceduralMarkingsCRUD.VatprocmarkingsSelect(BeginTaxDate, EndTaxDate);
			Data = VatProcMarkingsLoadResponse;

			return (Data, Severity);
		}
	}
}

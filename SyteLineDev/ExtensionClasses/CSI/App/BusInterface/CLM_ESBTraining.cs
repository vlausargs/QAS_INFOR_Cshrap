//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBTraining.cs

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

namespace CSI.BusInterface
{
	public class CLM_ESBTraining : ICLM_ESBTraining
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_ESBTrainingCRUD iCLM_ESBTrainingCRUD;

		public CLM_ESBTraining(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICLM_ESBTrainingCRUD iCLM_ESBTrainingCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCLM_ESBTrainingCRUD = iCLM_ESBTrainingCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ESBTrainingSp(
			string EmpNum)
		{

			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iCLM_ESBTrainingCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_ESBTrainingCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCLM_ESBTrainingCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCLM_ESBTrainingCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_ESBTrainingCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCLM_ESBTrainingCRUD.AltExtGen_CLM_ESBTrainingSp(ALTGEN_SpName,
						EmpNum);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_ESBTrainingCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iCLM_ESBTrainingCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ESBTrainingSp") != null)
			{
				var EXTGEN = this.iCLM_ESBTrainingCRUD.AltExtGen_CLM_ESBTrainingSp("dbo.EXTGEN_CLM_ESBTrainingSp",
					EmpNum);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			var ESBTrainingViewLoadResponse = this.iCLM_ESBTrainingCRUD.SelectEsbtrainingview(EmpNum);
			Data = ESBTrainingViewLoadResponse;

			return (Data, Severity);
		}

	}
}

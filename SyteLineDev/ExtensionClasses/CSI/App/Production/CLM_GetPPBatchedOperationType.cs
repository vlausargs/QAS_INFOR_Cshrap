//PROJECT NAME: Production
//CLASS NAME: CLM_GetPPBatchedOperationType.cs

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
	public class CLM_GetPPBatchedOperationType : ICLM_GetPPBatchedOperationType
	{
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_GetPPBatchedOperationTypeCRUD iCLM_GetPPBatchedOperationTypeCRUD;
		
		public CLM_GetPPBatchedOperationType(IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICLM_GetPPBatchedOperationTypeCRUD iCLM_GetPPBatchedOperationTypeCRUD)
		{
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCLM_GetPPBatchedOperationTypeCRUD = iCLM_GetPPBatchedOperationTypeCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_GetPPBatchedOperationTypeSp (
			int? BatchId,
			string BatchDefinition)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ICollectionLoadResponse Data = null;
				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				int? rowCount = null;
				if (this.iCLM_GetPPBatchedOperationTypeCRUD.Optional_ModuleForExists())
				{
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");
					var optional_module1LoadResponse = this.iCLM_GetPPBatchedOperationTypeCRUD.Optional_Module1Select();
					var optional_module1RequiredColumns = new List<string>() {"SpName"};
					
					optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
					
					this.iCLM_GetPPBatchedOperationTypeCRUD.Optional_Module1Insert(optional_module1LoadResponse);
					while (this.iCLM_GetPPBatchedOperationTypeCRUD.Tv_ALTGENForExists())
					{
						(ALTGEN_SpName, rowCount) = this.iCLM_GetPPBatchedOperationTypeCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
						var ALTGEN = this.iCLM_GetPPBatchedOperationTypeCRUD.AltExtGen_CLM_GetPPBatchedOperationTypeSp (ALTGEN_SpName,
							BatchId,
							BatchDefinition);
						ALTGEN_Severity = ALTGEN.ReturnCode;
						
						if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
						{
							return (ALTGEN.Data, ALTGEN_Severity);
						}
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
						/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
						var tv_ALTGEN2LoadResponse = this.iCLM_GetPPBatchedOperationTypeCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
						this.iCLM_GetPPBatchedOperationTypeCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					}
				}
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_GetPPBatchedOperationTypeSp") != null)
				{
					var EXTGEN = this.iCLM_GetPPBatchedOperationTypeCRUD.AltExtGen_CLM_GetPPBatchedOperationTypeSp("dbo.EXTGEN_CLM_GetPPBatchedOperationTypeSp",
						BatchId,
						BatchDefinition);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;
					
					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}
				
				if (BatchId!= null && BatchDefinition!= null)
				{
					var jrt_sch1LoadResponse = this.iCLM_GetPPBatchedOperationTypeCRUD.Jrt_Sch1Select(BatchId, BatchDefinition);
					Data = jrt_sch1LoadResponse;
				}
				else
				{
					var PP_OPER_TYPELoadResponse = this.iCLM_GetPPBatchedOperationTypeCRUD.PP_OPER_TYPESelect();
					Data = PP_OPER_TYPELoadResponse;
				}

				return (Data, 0);
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}

//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetRGRP.cs

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

namespace CSI.Production.APS
{
	public class CLM_ApsGetRGRP : ICLM_ApsGetRGRP
	{
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IExecuteDynamicSQL iExecuteDynamicSQL;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_ApsGetRGRPCRUD iCLM_ApsGetRGRPCRUD;
		
		public CLM_ApsGetRGRP(IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IExecuteDynamicSQL iExecuteDynamicSQL,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ICLM_ApsGetRGRPCRUD iCLM_ApsGetRGRPCRUD)
		{
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iExecuteDynamicSQL = iExecuteDynamicSQL;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iCLM_ApsGetRGRPCRUD = iCLM_ApsGetRGRPCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ApsGetRGRPSp (
			int? AltNo,
			string Filter = null)
		{
			
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				
				ICollectionLoadResponse Data = null;
				
				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				int? rowCount = null;
				int? Severity = null;
				string Table = null;
				string SelectionClause = null;
				string FromClause = null;
				string Infobar = null;
				if (this.iCLM_ApsGetRGRPCRUD.Optional_ModuleForExists())
				{
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");
					var optional_module1LoadResponse = this.iCLM_ApsGetRGRPCRUD.Optional_Module1Select();
					var optional_module1RequiredColumns = new List<string>() {"SpName"};
					
					optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
					
					this.iCLM_ApsGetRGRPCRUD.Optional_Module1Insert(optional_module1LoadResponse);
					while (this.iCLM_ApsGetRGRPCRUD.Tv_ALTGENForExists())
					{
						(ALTGEN_SpName, rowCount) = this.iCLM_ApsGetRGRPCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
						var ALTGEN = this.iCLM_ApsGetRGRPCRUD.AltExtGen_CLM_ApsGetRGRPSp (ALTGEN_SpName,
							AltNo,
							Filter);
						ALTGEN_Severity = ALTGEN.ReturnCode;
						
						if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
						{
							return (ALTGEN.Data, ALTGEN_Severity);
							
						}
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
						/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
						var tv_ALTGEN2LoadResponse = this.iCLM_ApsGetRGRPCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
						this.iCLM_ApsGetRGRPCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
						
					}
					
				}
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ApsGetRGRPSp") != null)
				{
					var EXTGEN = this.iCLM_ApsGetRGRPCRUD.AltExtGen_CLM_ApsGetRGRPSp("dbo.EXTGEN_CLM_ApsGetRGRPSp",
						AltNo,
						Filter);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;
					
					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}
				
				Severity = 0;
				Table = stringUtil.Concat("RGRP", stringUtil.Replace(
					stringUtil.Str(
						AltNo,
						3),
					" ",
					"0"));
				SelectionClause = "SELECT * ";
				FromClause = stringUtil.Concat(@" FROM (SELECT
					                           RGID
					                         , DESCR
					                         , SLTYPE
					                         , BUFFERIN
					                         , BUFFEROUT
					                         , INFCAP
					                         , ALLOCRL
					                         , INFINITEFG
					                         , REALLOCFG
					                         , LOADFG
					                         , SUMFG
					                         , plant
					                         , RGID_alias AS RGIDAlias
					                         , RowPointer
					                         FROM ", stringUtil.QuoteName(Table), " ) result");
				
				this.sQLExpressionExecutor.Execute(@"Declare
					@SelectionClause LongListType
					,@FromClause LongListType
					,@Filter LongListType
					SELECT @SelectionClause AS SelectionClause,
					       @FromClause AS FromClause,
					       N' WHERE 1 = 1 ' AS WhereClause,
					       N' ORDER BY RGID' AS AdditionalClause,
					       N'RGID' AS KeyColumns,
					       @Filter AS FilterString
					INTO   #DynamicParameters
					WHERE 1 = 2");
				var DynamicParametersLoadResponse = this.iCLM_ApsGetRGRPCRUD.DynamicparametersSelect(SelectionClause, FromClause, Filter);
				
				this.iCLM_ApsGetRGRPCRUD.DynamicparametersInsert(DynamicParametersLoadResponse);
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
				var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
					NeedGetMoreRows: 1,
					Infobar: Infobar);
				Severity = ExecuteDynamicSQL.ReturnCode;
				Data = ExecuteDynamicSQL.Data;
				Infobar = ExecuteDynamicSQL.Infobar;
				
				#endregion ExecuteMethodCall
				
				return (Data, Severity);
				
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
		
	}
}

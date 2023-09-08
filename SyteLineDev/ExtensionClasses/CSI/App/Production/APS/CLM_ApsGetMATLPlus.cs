//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetMATLPlus.cs

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
	public class CLM_ApsGetMATLPlus : ICLM_ApsGetMATLPlus
	{
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ISQLCollectionLoad sQLCollectionLoad;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_ApsGetMATLPlusCRUD iCLM_ApsGetMATLPlusCRUD;
		
		public CLM_ApsGetMATLPlus(IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ISQLCollectionLoad sQLCollectionLoad,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ICLM_ApsGetMATLPlusCRUD iCLM_ApsGetMATLPlusCRUD)
		{
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.sQLCollectionLoad = sQLCollectionLoad;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iCLM_ApsGetMATLPlusCRUD = iCLM_ApsGetMATLPlusCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ApsGetMATLPlusSp (
			int? AltNo,
			string MaterialIdFilter = null)
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
				string SQLStr = null;
				string MATL = null;
				if (this.iCLM_ApsGetMATLPlusCRUD.Optional_ModuleForExists())
				{
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");
					var optional_module1LoadResponse = this.iCLM_ApsGetMATLPlusCRUD.Optional_Module1Select();
					var optional_module1RequiredColumns = new List<string>() {"SpName"};
					
					optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
					
					this.iCLM_ApsGetMATLPlusCRUD.Optional_Module1Insert(optional_module1LoadResponse);
					while (this.iCLM_ApsGetMATLPlusCRUD.Tv_ALTGENForExists())
					{
						(ALTGEN_SpName, rowCount) = this.iCLM_ApsGetMATLPlusCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
						var ALTGEN = this.iCLM_ApsGetMATLPlusCRUD.AltExtGen_CLM_ApsGetMATLPlusSp (ALTGEN_SpName,
							AltNo,
							MaterialIdFilter);
						ALTGEN_Severity = ALTGEN.ReturnCode;
						
						if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
						{
							return (ALTGEN.Data, ALTGEN_Severity);
							
						}
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
						/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
						var tv_ALTGEN2LoadResponse = this.iCLM_ApsGetMATLPlusCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
						this.iCLM_ApsGetMATLPlusCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
						
					}
					
				}
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ApsGetMATLPlusSp") != null)
				{
					var EXTGEN = this.iCLM_ApsGetMATLPlusCRUD.AltExtGen_CLM_ApsGetMATLPlusSp("dbo.EXTGEN_CLM_ApsGetMATLPlusSp",
						AltNo,
						MaterialIdFilter);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;
					
					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}
				
				if (MaterialIdFilter== null || sQLUtil.SQLEqual(MaterialIdFilter, "") == true)
				{
					MaterialIdFilter = "%";
					
				}
				Severity = 0;
				MATL = stringUtil.Concat("MATL", stringUtil.Replace(
					stringUtil.Str(
						AltNo,
						3),
					" ",
					"0"));
				SQLStr = stringUtil.Concat(@"SELECT MATERIALID FROM(
					SELECT
					  MATERIALID", " FROM ", stringUtil.QuoteName(MATL), " WHERE SCHEDONLYFG <> 'Y'", ") SS ", " WHERE MATERIALID LIKE @MaterialIdFilter ORDER BY MATERIALID");
				//#error "Conversion Failed"
				
				var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQLStr
				, "@MaterialIdFilter NVARCHAR(4000)"
				, MaterialIdFilter);
				Data = execResult.Data;
				Severity = execResult.Severity;
				
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

//PROJECT NAME: Production
//CLASS NAME: CLM_ApsWhatIfEXRCPTDemand.cs

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
	public class CLM_ApsWhatIfEXRCPTDemand : ICLM_ApsWhatIfEXRCPTDemand
	{
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ISQLCollectionLoad sQLCollectionLoad;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_ApsWhatIfEXRCPTDemandCRUD iCLM_ApsWhatIfEXRCPTDemandCRUD;
		
		public CLM_ApsWhatIfEXRCPTDemand(IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ISQLCollectionLoad sQLCollectionLoad,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ICLM_ApsWhatIfEXRCPTDemandCRUD iCLM_ApsWhatIfEXRCPTDemandCRUD)
		{
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.sQLCollectionLoad = sQLCollectionLoad;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iCLM_ApsWhatIfEXRCPTDemandCRUD = iCLM_ApsWhatIfEXRCPTDemandCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ApsWhatIfEXRCPTDemandSp (
			int? AltNo,
			string OrderIdFilter = null)
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
				string ORDER = null;
				if (this.iCLM_ApsWhatIfEXRCPTDemandCRUD.Optional_ModuleForExists())
				{
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");
					var optional_module1LoadResponse = this.iCLM_ApsWhatIfEXRCPTDemandCRUD.Optional_Module1Select();
					var optional_module1RequiredColumns = new List<string>() {"SpName"};
					
					optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
					
					this.iCLM_ApsWhatIfEXRCPTDemandCRUD.Optional_Module1Insert(optional_module1LoadResponse);
					while (this.iCLM_ApsWhatIfEXRCPTDemandCRUD.Tv_ALTGENForExists())
					{
						(ALTGEN_SpName, rowCount) = this.iCLM_ApsWhatIfEXRCPTDemandCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
						var ALTGEN = this.iCLM_ApsWhatIfEXRCPTDemandCRUD.AltExtGen_CLM_ApsWhatIfEXRCPTDemandSp (ALTGEN_SpName,
							AltNo,
							OrderIdFilter);
						ALTGEN_Severity = ALTGEN.ReturnCode;
						
						if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
						{
							return (ALTGEN.Data, ALTGEN_Severity);
						}
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
						/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
						var tv_ALTGEN2LoadResponse = this.iCLM_ApsWhatIfEXRCPTDemandCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
						this.iCLM_ApsWhatIfEXRCPTDemandCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");						
					}
				}
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ApsWhatIfEXRCPTDemandSp") != null)
				{
					var EXTGEN = this.iCLM_ApsWhatIfEXRCPTDemandCRUD.AltExtGen_CLM_ApsWhatIfEXRCPTDemandSp("dbo.EXTGEN_CLM_ApsWhatIfEXRCPTDemandSp",
						AltNo,
						OrderIdFilter);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;
					
					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}
				
				Severity = 0;
				ORDER = stringUtil.Concat("ORDER", stringUtil.Replace(
					stringUtil.Str(
						AltNo,
						3),
					" ",
					"0"));
				if (OrderIdFilter== null || sQLUtil.SQLEqual(OrderIdFilter, "") == true)
				{
					OrderIdFilter = "%";
				}
				SQLStr = stringUtil.Concat(@"SELECT
					  ord.ORDERID", " FROM ", stringUtil.QuoteName(ORDER), " ord", @" WHERE (ord.OrderTable = 'job' or ord.OrderTable = 'coitem')
					AND ord.ORDERID LIKE @OrderIdFilter ORDER BY ord.ORDERID");				
				
				var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQLStr
				, "@OrderIdFilter LongListType"
				, OrderIdFilter);
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

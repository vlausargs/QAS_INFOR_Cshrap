//PROJECT NAME: Production
//CLASS NAME: CLM_APSItemList.cs

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
	public class CLM_APSItemList : ICLM_APSItemList
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ISQLCollectionLoad sQLCollectionLoad;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_APSItemListCRUD iCLM_APSItemListCRUD;
		
		public CLM_APSItemList(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ISQLCollectionLoad sQLCollectionLoad,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ICLM_APSItemListCRUD iCLM_APSItemListCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.sQLCollectionLoad = sQLCollectionLoad;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iCLM_APSItemListCRUD = iCLM_APSItemListCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_APSItemListSp (
			int? AltNo,
			string ItemFilter = null)
		{
			
			ICollectionLoadResponse Data = null;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			string SQLStr = null;
			if (this.iCLM_APSItemListCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_APSItemListCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCLM_APSItemListCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCLM_APSItemListCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_APSItemListCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_APSItemListCRUD.AltExtGen_CLM_APSItemListSp (ALTGEN_SpName,
						AltNo,
						ItemFilter);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_APSItemListCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_APSItemListCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_APSItemListSp") != null)
			{
				var EXTGEN = this.iCLM_APSItemListCRUD.AltExtGen_CLM_APSItemListSp("dbo.EXTGEN_CLM_APSItemListSp",
					AltNo,
					ItemFilter);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			Severity = 0;
			if (ItemFilter== null || sQLUtil.SQLEqual(ItemFilter, "") == true)
			{
				ItemFilter = "%";
				
			}
			SQLStr = "SELECT DISTINCT  MSGITEM FROM APSMSGS WHERE MSGITEM <> '' AND MSGITEM LIKE @ItemFilter ORDER BY MSGITEM";
			
			var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQLStr
			, "@ItemFilter LongListType"
			, ItemFilter);
			Severity = execResult.Severity;
			Data = execResult.Data;
			
			return (Data, Severity);
		}
		
	}
}

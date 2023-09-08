//PROJECT NAME: Logistics
//CLASS NAME: TableSharedSites.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Utilities;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class TableSharedSites : ITableSharedSites
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
        readonly IUnionUtil unionUtil;
        readonly ITableSharedSitesCRUD iTableSharedSitesCRUD;
		
		public TableSharedSites(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
            IUnionUtil unionUtil,
            ITableSharedSitesCRUD iTableSharedSitesCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
            this.unionUtil = unionUtil;
			this.iTableSharedSitesCRUD = iTableSharedSitesCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		TableSharedSitesSp (
			string TableName)
		{
			
			ICollectionLoadResponse Data = null;
			
			int? Severity = 0;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iTableSharedSitesCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iTableSharedSitesCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iTableSharedSitesCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iTableSharedSitesCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iTableSharedSitesCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iTableSharedSitesCRUD.AltExtGen_TableSharedSitesSp (ALTGEN_SpName,
						TableName);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iTableSharedSitesCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iTableSharedSitesCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_TableSharedSitesSp") != null)
			{
				var EXTGEN = this.iTableSharedSitesCRUD.AltExtGen_TableSharedSitesSp("dbo.EXTGEN_TableSharedSitesSp",
					TableName);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			var parmsLoadResponse = this.iTableSharedSitesCRUD.SelectParms();
			unionUtil.Add(parmsLoadResponse);

			var rep_ruleLoadResponse = this.iTableSharedSitesCRUD.SelectRep_Rule(TableName);
            unionUtil.Add(rep_ruleLoadResponse);

			Data = unionUtil.Process();
            return (Data, Severity);
			
		}
		
	}
}

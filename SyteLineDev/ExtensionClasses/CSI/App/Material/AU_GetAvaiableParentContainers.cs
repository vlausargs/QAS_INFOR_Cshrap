//PROJECT NAME: Material
//CLASS NAME: AU_GetAvaiableParentContainers.cs

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

namespace CSI.Material
{
	public class AU_GetAvaiableParentContainers : IAU_GetAvaiableParentContainers
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IIsAddonAvailable iIsAddonAvailable;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IAU_GetAvaiableParentContainersCRUD iAU_GetAvaiableParentContainersCRUD;
		
		public AU_GetAvaiableParentContainers(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IIsAddonAvailable iIsAddonAvailable,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IAU_GetAvaiableParentContainersCRUD iAU_GetAvaiableParentContainersCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iIsAddonAvailable = iIsAddonAvailable;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iAU_GetAvaiableParentContainersCRUD = iAU_GetAvaiableParentContainersCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AU_GetAvaiableParentContainersSp (
			string ContainerNum,
			string Whse,
			string Loc)
		{
			
			ICollectionLoadResponse Data = null;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iAU_GetAvaiableParentContainersCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iAU_GetAvaiableParentContainersCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iAU_GetAvaiableParentContainersCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iAU_GetAvaiableParentContainersCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iAU_GetAvaiableParentContainersCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iAU_GetAvaiableParentContainersCRUD.AltExtGen_AU_GetAvaiableParentContainersSp (ALTGEN_SpName,
						ContainerNum,
						Whse,
						Loc);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iAU_GetAvaiableParentContainersCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iAU_GetAvaiableParentContainersCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_AU_GetAvaiableParentContainersSp") != null)
			{
				var EXTGEN = this.iAU_GetAvaiableParentContainersCRUD.AltExtGen_AU_GetAvaiableParentContainersSp("dbo.EXTGEN_AU_GetAvaiableParentContainersSp",
					ContainerNum,
					Whse,
					Loc);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			if (sQLUtil.SQLNotEqual(this.iIsAddonAvailable.IsAddonAvailableFn("Automotive_Mfg"), 1) == true)
			{
				return (Data, Severity = 0);
				
			}
			Severity = 0;
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @tmp_container TABLE (
				    container_num NVARCHAR (15) NOT NULL);
				SELECT * into #tv_tmp_container from @tmp_container");
			var tv_tmp_containerLoadResponse = this.iAU_GetAvaiableParentContainersCRUD.SelectTv_Tmp_ContainerForInsert(ContainerNum);
			this.iAU_GetAvaiableParentContainersCRUD.InsertTv_Tmp_Container(tv_tmp_containerLoadResponse);
			
			var containerLoadResponse = this.iAU_GetAvaiableParentContainersCRUD.SelectContainer(Whse, Loc);
			Data = containerLoadResponse;
			
			return (Data, Severity);
			
		}
		
	}
}

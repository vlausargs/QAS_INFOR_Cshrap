//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefItemData.cs

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

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefItemData : IRSQC_GetXrefItemData
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IIsAddonAvailable iIsAddonAvailable;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRSQC_GetXrefItemDataCRUD iRSQC_GetXrefItemDataCRUD;
		
		public RSQC_GetXrefItemData(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IIsAddonAvailable iIsAddonAvailable,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IRSQC_GetXrefItemDataCRUD iRSQC_GetXrefItemDataCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iIsAddonAvailable = iIsAddonAvailable;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iRSQC_GetXrefItemDataCRUD = iRSQC_GetXrefItemDataCRUD;
		}
		
		public (
			int? ReturnCode,
			string o_desc,
			string Infobar)
		RSQC_GetXrefItemDataSp (
			string i_item,
			string o_desc,
			string Infobar)
		{
			
			DescriptionType _o_desc = o_desc;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iRSQC_GetXrefItemDataCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRSQC_GetXrefItemDataCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iRSQC_GetXrefItemDataCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iRSQC_GetXrefItemDataCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iRSQC_GetXrefItemDataCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iRSQC_GetXrefItemDataCRUD.AltExtGen_RSQC_GetXrefItemDataSp (ALTGEN_SpName,
						i_item,
						o_desc,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, o_desc, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iRSQC_GetXrefItemDataCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iRSQC_GetXrefItemDataCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_RSQC_GetXrefItemDataSp") != null)
			{
				var EXTGEN = this.iRSQC_GetXrefItemDataCRUD.AltExtGen_RSQC_GetXrefItemDataSp("dbo.EXTGEN_RSQC_GetXrefItemDataSp",
					i_item,
					o_desc,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.o_desc, EXTGEN.Infobar);
				}
			}
			
			if (sQLUtil.SQLNotEqual(this.iIsAddonAvailable.IsAddonAvailableFn("QualityControlSolution"), 1) == true)
			{
				return (Severity = 0 , o_desc, Infobar);
				
			}
			Severity = 0;
			(o_desc, rowCount) = this.iRSQC_GetXrefItemDataCRUD.ItemLoad(i_item, o_desc);
			var nonTableLoadResponse = this.iRSQC_GetXrefItemDataCRUD.NontableSelect(o_desc);
			
			return (Severity, o_desc, Infobar);
		}
		
	}
}

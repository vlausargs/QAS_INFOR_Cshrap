//PROJECT NAME: Production
//CLASS NAME: PmfPnReOpen.cs

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

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnReOpen : IPmfPnReOpen
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IPmfPnReOpenCRUD iPmfPnReOpenCRUD;
		
		public PmfPnReOpen(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IPmfPnReOpenCRUD iPmfPnReOpenCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iPmfPnReOpenCRUD = iPmfPnReOpenCRUD;
		}
		
		public (
			int? ReturnCode,
			string InfoBar)
		PmfPnReOpenSp (
			string InfoBar = null,
			Guid? PnRp = null)
		{
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			ProcessMfgProductionIdType _Pn = DBNull.Value;
			int? Severity = null;
			if (this.iPmfPnReOpenCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iPmfPnReOpenCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("PmfPnReOpenSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iPmfPnReOpenCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iPmfPnReOpenCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iPmfPnReOpenCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iPmfPnReOpenCRUD.AltExtGen_PmfPnReOpenSp (ALTGEN_SpName,
						InfoBar,
						PnRp);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, InfoBar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iPmfPnReOpenCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iPmfPnReOpenCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_PmfPnReOpenSp") != null)
			{
				var EXTGEN = this.iPmfPnReOpenCRUD.AltExtGen_PmfPnReOpenSp("dbo.EXTGEN_PmfPnReOpenSp",
					InfoBar,
					PnRp);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.InfoBar);
				}
			}
			
			Severity = 0;
			var pmf_pn_batchLoadResponse = this.iPmfPnReOpenCRUD.Pmf_Pn_BatchSelect(PnRp);
			this.iPmfPnReOpenCRUD.Pmf_Pn_BatchUpdate(pmf_pn_batchLoadResponse);
			var jobLoadResponse = this.iPmfPnReOpenCRUD.JobSelect(PnRp);
			this.iPmfPnReOpenCRUD.JobUpdate(jobLoadResponse);
			var pmf_formulaLoadResponse = this.iPmfPnReOpenCRUD.Pmf_FormulaSelect(PnRp);
			this.iPmfPnReOpenCRUD.Pmf_FormulaUpdate(pmf_formulaLoadResponse);
			goto SPEND;
			
			SPEND: ;
			return (Severity, InfoBar);
			
		}
		
	}
}

//PROJECT NAME: Production
//CLASS NAME: CLM_JobRouteOEE.cs

using CSI.Data;
using CSI.Data.CRUD;
using System.Collections.Generic;
using CSI.Data.Functions;
using CSI.Data.Utilities;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CLM_JobRouteOEE : ICLM_JobRouteOEE
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly IUnionUtil unionUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly ICLM_JobRouteOEECRUD iCLM_JobRouteOEECRUD;
		
		public CLM_JobRouteOEE(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			IUnionUtil unionUtil,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			ICLM_JobRouteOEECRUD iCLM_JobRouteOEECRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.unionUtil = unionUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iCLM_JobRouteOEECRUD = iCLM_JobRouteOEECRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_JobRouteOEESp (
			decimal? OEE)
		{
			
			ICollectionLoadResponse Data = null;
			
			int? Severity = 0;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			decimal? JobRoutesOEE = null;
			decimal? JobRoutesWASTE = null;
			string StrOEE = null;
			string StrWaste = null;
			if (this.iCLM_JobRouteOEECRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_JobRouteOEECRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCLM_JobRouteOEECRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCLM_JobRouteOEECRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_JobRouteOEECRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCLM_JobRouteOEECRUD.AltExtGen_CLM_JobRouteOEESp (ALTGEN_SpName,
						OEE);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_JobRouteOEECRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iCLM_JobRouteOEECRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_JobRouteOEESp") != null)
			{
				var EXTGEN = this.iCLM_JobRouteOEECRUD.AltExtGen_CLM_JobRouteOEESp("dbo.EXTGEN_CLM_JobRouteOEESp",
					OEE);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			JobRoutesOEE = (decimal?)(stringUtil.IsNull<decimal?>(
				OEE,
				0));
			JobRoutesWASTE = (decimal?)(100M - JobRoutesOEE);
			
			#region CRUD ExecuteMethodCall
			
			var MsgApp = this.iMsgApp.MsgAppSp(
				Infobar: StrOEE,
				BaseMsg: "@!OEE");
			StrOEE = MsgApp.Infobar;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			var MsgApp1 = this.iMsgApp.MsgAppSp(
				Infobar: StrWaste,
				BaseMsg: "@!Waste");
			StrWaste = MsgApp1.Infobar;
			
			#endregion ExecuteMethodCall
			
			var nonTableLoadResponse = this.iCLM_JobRouteOEECRUD.SelectOEE(StrOEE, StrWaste, JobRoutesOEE);
			unionUtil.Add(nonTableLoadResponse);

			var nonTable1LoadResponse = this.iCLM_JobRouteOEECRUD.SelectWaste(JobRoutesWASTE, StrWaste);
			unionUtil.Add(nonTable1LoadResponse);

			var unionTableResult = unionUtil.Process();
			Data = unionTableResult;
			
			return (Data, Severity);
		}
		
	}
}

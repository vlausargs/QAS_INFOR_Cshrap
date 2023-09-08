//PROJECT NAME: Logistics
//CLASS NAME: IncidentPreDelete.cs

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

namespace CSI.Logistics.FieldService.CallCenter
{
	public class IncidentPreDelete : IIncidentPreDelete
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly IIncidentPreDeleteCRUD iIncidentPreDeleteCRUD;
		
		public IncidentPreDelete(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			IIncidentPreDeleteCRUD iIncidentPreDeleteCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iIncidentPreDeleteCRUD = iIncidentPreDeleteCRUD;
		}
		
		public (
			int? ReturnCode,
			string Infobar)
		IncidentPreDeleteSp (
			string IncNum,
			string Infobar)
		{
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			string SroNum = null;
			string Site = null;
			if (this.iIncidentPreDeleteCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] sysname);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iIncidentPreDeleteCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iIncidentPreDeleteCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iIncidentPreDeleteCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iIncidentPreDeleteCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iIncidentPreDeleteCRUD.AltExtGen_IncidentPreDeleteSp (ALTGEN_SpName,
						IncNum,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iIncidentPreDeleteCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iIncidentPreDeleteCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_IncidentPreDeleteSp") != null)
			{
				var EXTGEN = this.iIncidentPreDeleteCRUD.AltExtGen_IncidentPreDeleteSp("dbo.EXTGEN_IncidentPreDeleteSp",
					IncNum,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			Severity = 0;
			(SroNum, rowCount) = this.iIncidentPreDeleteCRUD.LoadFs_Sro(IncNum, SroNum);
			if (SroNum!= null)
			{
				(Site, rowCount) = this.iIncidentPreDeleteCRUD.LoadParms(Site);
				
				#region CRUD ExecuteMethodCall
				
				var MsgApp = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=CmdFailed",
					Parm1: "@%delete");
				Severity = MsgApp.ReturnCode;
				Infobar = MsgApp.Infobar;
				
				#endregion ExecuteMethodCall
				
				#region CRUD ExecuteMethodCall
				
				var MsgApp1 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=Exist3",
					Parm1: "@fs_sro",
					Parm2: "@fs_sro.sro_num",
					Parm3: SroNum,
					Parm4: "@fs_sro.inc_num",
					Parm5: IncNum,
					Parm6: "@site.site",
					Parm7: Site);
				Severity = MsgApp1.ReturnCode;
				Infobar = MsgApp1.Infobar;
				
				#endregion ExecuteMethodCall
				
			}
			return (Severity, Infobar);
			
		}
		
	}
}

//PROJECT NAME: Admin
//CLASS NAME: Rpt_EmpChildPrivacy.cs

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
using CSI.Material;
namespace CSI.Admin
{
	public class Rpt_EmpChildPrivacy : IRpt_EmpChildPrivacy
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IInitSessionContext iInitSessionContext;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRpt_EmpChildPrivacyCRUD iRpt_EmpChildPrivacyCRUD;

		public Rpt_EmpChildPrivacy(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICloseSessionContext iCloseSessionContext,
			IInitSessionContext iInitSessionContext,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IRpt_EmpChildPrivacyCRUD iRpt_EmpChildPrivacyCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iInitSessionContext = iInitSessionContext;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iRpt_EmpChildPrivacyCRUD = iRpt_EmpChildPrivacyCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_EmpChildPrivacySp(
			string EmpNum,
			string pSite)
		{

			ICollectionLoadResponse Data = null;

			int? Severity = 0;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			Guid? RptSessionID = null;
			if (this.iRpt_EmpChildPrivacyCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRpt_EmpChildPrivacyCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iRpt_EmpChildPrivacyCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iRpt_EmpChildPrivacyCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iRpt_EmpChildPrivacyCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iRpt_EmpChildPrivacyCRUD.AltExtGen_Rpt_EmpChildPrivacySp(ALTGEN_SpName,
						EmpNum,
						pSite);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iRpt_EmpChildPrivacyCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iRpt_EmpChildPrivacyCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_EmpChildPrivacySp") != null)
			{
				var EXTGEN = this.iRpt_EmpChildPrivacyCRUD.AltExtGen_Rpt_EmpChildPrivacySp("dbo.EXTGEN_Rpt_EmpChildPrivacySp",
					EmpNum,
					pSite);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InitSessionContextSp
			var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(
				ContextName: "Rpt_EmpChildPrivacySp",
				SessionID: RptSessionID,
				Site: pSite);
			RptSessionID = InitSessionContext.SessionID;

			#endregion ExecuteMethodCall

			EmpNum = this.iExpandKyByType.ExpandKyByTypeFn(
				"EmpNumType",
				EmpNum);
			var emp_childLoadResponse = this.iRpt_EmpChildPrivacyCRUD.Emp_ChildSelect(EmpNum);
			Data = emp_childLoadResponse;

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

			#endregion ExecuteMethodCall

			return (Data, Severity);
		}

	}
}

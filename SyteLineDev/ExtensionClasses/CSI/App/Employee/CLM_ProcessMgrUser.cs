//PROJECT NAME: Employee
//CLASS NAME: CLM_ProcessMgrUser.cs

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

namespace CSI.Employee
{
	public class CLM_ProcessMgrUser : ICLM_ProcessMgrUser
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_ProcessMgrUserCRUD iCLM_ProcessMgrUserCRUD;

		public CLM_ProcessMgrUser(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICLM_ProcessMgrUserCRUD iCLM_ProcessMgrUserCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCLM_ProcessMgrUserCRUD = iCLM_ProcessMgrUserCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ProcessMgrUserSp()
		{

			ICollectionLoadResponse Data = null;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCLM_ProcessMgrUserCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_ProcessMgrUserCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCLM_ProcessMgrUserCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCLM_ProcessMgrUserCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_ProcessMgrUserCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCLM_ProcessMgrUserCRUD.AltExtGen_CLM_ProcessMgrUserSp(ALTGEN_SpName);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_ProcessMgrUserCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iCLM_ProcessMgrUserCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ProcessMgrUserSp") != null)
			{
				var EXTGEN = this.iCLM_ProcessMgrUserCRUD.AltExtGen_CLM_ProcessMgrUserSp("dbo.EXTGEN_CLM_ProcessMgrUserSp");
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			Severity = 0;
			var UserNames1LoadResponse = this.iCLM_ProcessMgrUserCRUD.SelectUsernames();
			Data = UserNames1LoadResponse;
			return (Data, Severity);

		}

	}
}

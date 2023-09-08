//PROJECT NAME: Employee
//CLASS NAME: CLM_GetEmpManagerInfo.cs

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
	public class CLM_GetEmpManagerInfo : ICLM_GetEmpManagerInfo
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IStringUtil stringUtil;
		readonly IUserPrincipal iUserName;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_GetEmpManagerInfoCRUD iCLM_GetEmpManagerInfoCRUD;
		
		public CLM_GetEmpManagerInfo(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IStringUtil stringUtil,
			IUserPrincipal iUserName,
			ISQLValueComparerUtil sQLUtil,
			ICLM_GetEmpManagerInfoCRUD iCLM_GetEmpManagerInfoCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.stringUtil = stringUtil;
			this.iUserName = iUserName;
			this.sQLUtil = sQLUtil;
			this.iCLM_GetEmpManagerInfoCRUD = iCLM_GetEmpManagerInfoCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_GetEmpManagerInfoSp (
			string EmpNum = null,
			string UserName = null)
		{
			
			EmpNumType _EmpNum = EmpNum;
			
			ICollectionLoadResponse Data = null;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCLM_GetEmpManagerInfoCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_GetEmpManagerInfoCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCLM_GetEmpManagerInfoCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCLM_GetEmpManagerInfoCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_GetEmpManagerInfoCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_GetEmpManagerInfoCRUD.AltExtGen_CLM_GetEmpManagerInfoSp (ALTGEN_SpName,
						EmpNum,
						UserName);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_GetEmpManagerInfoCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_GetEmpManagerInfoCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_GetEmpManagerInfoSp") != null)
			{
				var EXTGEN = this.iCLM_GetEmpManagerInfoCRUD.AltExtGen_CLM_GetEmpManagerInfoSp("dbo.EXTGEN_CLM_GetEmpManagerInfoSp",
					EmpNum,
					UserName);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			Severity = 0;
			if (sQLUtil.SQLEqual(stringUtil.IsNull(
					UserName,
					""), "") == true)
			{
				UserName = convertToUtil.ToString(this.iUserName.UserName);
				
			}
			if (sQLUtil.SQLEqual(stringUtil.IsNull(
					EmpNum,
					""), "") == true)
			{
				(EmpNum, rowCount) = this.iCLM_GetEmpManagerInfoCRUD.EmployeeLoad(UserName, EmpNum);
				
			}
			var employee1LoadResponse = this.iCLM_GetEmpManagerInfoCRUD.Employee1Select(EmpNum);
			Data = employee1LoadResponse;
			
			return (Data, Severity);
			
		}
		
	}
}

//PROJECT NAME: Employee
//CLASS NAME: EmpSalaryDelete.cs

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
	public class EmpSalaryDelete : IEmpSalaryDelete
	{
		readonly IApplicationDB appDB;

		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;

		public EmpSalaryDelete(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IDateTimeUtil dateTimeUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.dateTimeUtil = dateTimeUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
		}

		public (
			int? ReturnCode,
			string Infobar)
		EmpSalaryDeleteSp(
			string EmpSalaryEmpNum,
			DateTime? EmpSalaryJobdate,
			DateTime? EmpSalarySalDate,
			string Infobar)
		{

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			string DateMsg = null;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('EmpSalaryDeleteSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
			)
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");

				#region CRUD LoadToRecord
				var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"SpName","CAST (NULL AS NVARCHAR)"},
						{"u0","[om].[ModuleName]"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('EmpSalaryDeleteSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("EmpSalaryDeleteSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);

				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords

				while (existsChecker.Exists(tableName: "#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""))
				)
				{
					//BEGIN

					#region CRUD LoadToVariable
					var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_ALTGEN_SpName,"[SpName]"},
						},
						loadForChange: false,
                        lockingType: LockingType.None,
                        maximumRows: 1,
						tableName: "#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause(""),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
					if (tv_ALTGEN1LoadResponse.Items.Count > 0)
					{
						ALTGEN_SpName = _ALTGEN_SpName;
					}
					#endregion  LoadToVariable

					var ALTGEN = AltExtGen_EmpSalaryDeleteSp(ALTGEN_SpName,
						EmpSalaryEmpNum,
						EmpSalaryJobdate,
						EmpSalarySalDate,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					#region CRUD LoadToRecord
					var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"[SpName]","[SpName]"},
						}, 
                        loadForChange: true, 
                        lockingType: LockingType.None,
                        tableName: "#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
					#endregion  LoadToRecord

					#region CRUD DeleteByRecord
					var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
						items: tv_ALTGEN2LoadResponse.Items);
					this.appDB.Delete(tv_ALTGEN2DeleteRequest);
					#endregion DeleteByRecord

					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					//END

				}
				//END

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_EmpSalaryDeleteSp") != null)
			{
				var EXTGEN = AltExtGen_EmpSalaryDeleteSp("dbo.EXTGEN_EmpSalaryDeleteSp",
					EmpSalaryEmpNum,
					EmpSalaryJobdate,
					EmpSalarySalDate,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}

			Severity = 0;
			Infobar = null;
			if (sQLUtil.SQLEqual(dateTimeUtil.DateDiff("Day", EmpSalaryJobdate, EmpSalarySalDate), 0) == true)
			{
				//BEGIN
				if (existsChecker.Exists(tableName: "emp_pos",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("emp_pos.emp_num = {1} AND emp_pos.jobdate = {0}", EmpSalaryJobdate, EmpSalaryEmpNum))
				)
				{
					//BEGIN

					#region CRUD ExecuteMethodCall

					var MsgApp = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "E=FirstFor1",
						Parm1: "@emp_salary",
						Parm2: "@emp_pos",
						Parm3: "@emp_pos.emp_num",
						Parm4: EmpSalaryEmpNum);
					Severity = MsgApp.ReturnCode;
					Infobar = MsgApp.Infobar;

					#endregion ExecuteMethodCall

					//END

				}
				else
				{
					//BEGIN
					DateMsg = dateTimeUtil.ConvertToString(EmpSalaryJobdate, "MM/dd/yyyy");

					#region CRUD ExecuteMethodCall

					var MsgApp1 = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "E=FirstFor2",
						Parm1: "@emp_salary",
						Parm2: "@emp_hpos",
						Parm3: "@emp_hpos.emp_num",
						Parm4: EmpSalaryEmpNum,
						Parm5: "@emp_hpos.jobdate",
						Parm6: DateMsg);
					Severity = MsgApp1.ReturnCode;
					Infobar = MsgApp1.Infobar;

					#endregion ExecuteMethodCall

					//END

				}
				//END

			}
			return (Severity, Infobar);

		}
		public (int? ReturnCode,
			string Infobar)
		AltExtGen_EmpSalaryDeleteSp(
			string AltExtGenSp,
			string EmpSalaryEmpNum,
			DateTime? EmpSalaryJobdate,
			DateTime? EmpSalarySalDate,
			string Infobar)
		{
			EmpNumType _EmpSalaryEmpNum = EmpSalaryEmpNum;
			DateType _EmpSalaryJobdate = EmpSalaryJobdate;
			DateType _EmpSalarySalDate = EmpSalarySalDate;
			Infobar _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "EmpSalaryEmpNum", _EmpSalaryEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpSalaryJobdate", _EmpSalaryJobdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpSalarySalDate", _EmpSalarySalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}

	}
}

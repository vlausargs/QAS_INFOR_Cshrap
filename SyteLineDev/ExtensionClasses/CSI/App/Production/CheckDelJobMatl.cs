//PROJECT NAME: Production
//CLASS NAME: CheckDelJobMatl.cs

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

namespace CSI.Production
{
	public class CheckDelJobMatl : ICheckDelJobMatl
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly ICheckDelJobMatlCRUD iCheckDelJobMatlCRUD;

		public CheckDelJobMatl(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			ICheckDelJobMatlCRUD iCheckDelJobMatlCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iCheckDelJobMatlCRUD = iCheckDelJobMatlCRUD;
		}

		public (
			int? ReturnCode,
			string Infobar)
		CheckDelJobMatlSp(
			string Job,
			int? Suffix,
			int? OperNum,
			int? AltGroup,
			int? AltGroupRank,
			string Infobar)
		{

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCheckDelJobMatlCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCheckDelJobMatlCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCheckDelJobMatlCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCheckDelJobMatlCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCheckDelJobMatlCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCheckDelJobMatlCRUD.AltExtGen_CheckDelJobMatlSp(ALTGEN_SpName,
						Job,
						Suffix,
						OperNum,
						AltGroup,
						AltGroupRank,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCheckDelJobMatlCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCheckDelJobMatlCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CheckDelJobMatlSp") != null)
			{
				var EXTGEN = this.iCheckDelJobMatlCRUD.AltExtGen_CheckDelJobMatlSp("dbo.EXTGEN_CheckDelJobMatlSp",
					Job,
					Suffix,
					OperNum,
					AltGroup,
					AltGroupRank,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}

			Severity = 0;
			Infobar = null;
			if (sQLUtil.SQLEqual(AltGroupRank, 0) == true)
			{
				if (this.iCheckDelJobMatlCRUD.JobmatlForExists(Job, Suffix, OperNum, AltGroup))
				{

					#region CRUD ExecuteMethodCall

					var MsgApp = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "E=ExistForIsAndIsAndIs",
						Parm1: "@item.cur_mat_cost",
						Parm2: "@item",
						Parm3: "@jobmatl.parent",
						Parm4: "@jrtresourcegroup.oper_num",
						Parm5: convertToUtil.ToString(OperNum),
						Parm6: "@jobmatl.alt_group",
						Parm7: convertToUtil.ToString(AltGroup));
					Severity = MsgApp.ReturnCode;
					Infobar = MsgApp.Infobar;

					#endregion ExecuteMethodCall

				}

			}
			return (Severity, Infobar);

		}

	}
}

//PROJECT NAME: Logistics
//CLASS NAME: ValidateCoNumXref.cs

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

namespace CSI.Logistics.Customer
{
	public class ValidateCoNumXref : IValidateCoNumXref
	{
		readonly IApplicationDB appDB;

		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;

		public ValidateCoNumXref(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
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
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
		}

		public (int? ReturnCode, string Infobar) ValidateCoNumXrefSp(string DerCoNumXref,
			string CoNum,
			string InvNum,
			string SiteRef,
			string Infobar)
		{
			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidateCoNumXrefSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN ");

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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidateCoNumXrefSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ValidateCoNumXrefSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);

				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords

				while (existsChecker.Exists(tableName: "#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("")))
				{
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

					var ALTGEN = AltExtGen_ValidateCoNumXrefSp(_ALTGEN_SpName,
						DerCoNumXref,
						CoNum,
						InvNum,
						SiteRef,
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
							{"col0","1"},
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
				}
			}

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ValidateCoNumXrefSp") != null)
			{
				var EXTGEN = AltExtGen_ValidateCoNumXrefSp("dbo.EXTGEN_ValidateCoNumXrefSp",
					DerCoNumXref,
					CoNum,
					InvNum,
					SiteRef,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}

			Infobar = null;
			Severity = 0;
			if (SiteRef == null)
			{
				#region CRUD LoadToRecord
				var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"col0",$"{variableUtil.GetValue<string>(SiteRef)}"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "parms",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("parms.parm_key = 0"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
				#endregion  LoadToRecord
			}
			if (InvNum == null)
			{
				InvNum = "0";
			}
			while (sQLUtil.SQLBool(sQLUtil.SQLEqual(Severity, 0)))
			{
				if (sQLUtil.SQLEqual(DerCoNumXref, "X") == true)
				{
					#region CRUD ExecuteMethodCall

					var MsgApp = this.iMsgApp.MsgAppSp(Infobar: Infobar
						, BaseMsg: "E=Invalid"
						, Parm1: "@co.co_num");
					Severity = MsgApp.ReturnCode;
					Infobar = MsgApp.Infobar;

					#endregion ExecuteMethodCall

					break;
				}
				if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLEqual(DerCoNumXref, "O"), sQLUtil.SQLNot(existsChecker.Exists(tableName: "co_all",
					fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
					whereClause: collectionLoadRequestFactory.Clause("co_all.co_num = {1} AND co_all.site_ref = {0}", SiteRef, CoNum))))))
				{
					#region CRUD ExecuteMethodCall

					var MsgApp1 = this.iMsgApp.MsgAppSp(Infobar: Infobar
						, BaseMsg: "E=NoExist1"
						, Parm1: "@co"
						, Parm2: "@co.co_num"
						, Parm3: CoNum);
					Severity = MsgApp1.ReturnCode;
					Infobar = MsgApp1.Infobar;

					#endregion ExecuteMethodCall
					break;
					//END

				}
				if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLEqual(DerCoNumXref, "H"), sQLUtil.SQLNot(existsChecker.Exists(tableName: "coh_all",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("coh_all.co_num = {1} AND coh_all.site_ref = {0}", SiteRef, CoNum))))))
				{
					#region CRUD ExecuteMethodCall

					var MsgApp2 = this.iMsgApp.MsgAppSp(Infobar: Infobar
						, BaseMsg: "E=NoExist1"
						, Parm1: "@coh"
						, Parm2: "@coh.co_num"
						, Parm3: CoNum);
					Severity = MsgApp2.ReturnCode;
					Infobar = MsgApp2.Infobar;

					#endregion ExecuteMethodCall
					break;
				}

				if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLEqual(DerCoNumXref, "R"), sQLUtil.SQLNot(existsChecker.Exists(tableName: "rma",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("rma.rma_num = {0}", CoNum))))))
				{
					#region CRUD ExecuteMethodCall

					var MsgApp3 = this.iMsgApp.MsgAppSp(Infobar: Infobar
						, BaseMsg: "E=NoExist1"
						, Parm1: "@rma"
						, Parm2: "@rma.rma_num"
						, Parm3: CoNum);
					Severity = MsgApp3.ReturnCode;
					Infobar = MsgApp3.Infobar;

					#endregion ExecuteMethodCall
					break;
				}
				if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLEqual(DerCoNumXref, "P"), existsChecker.Exists(tableName: "proj_inv_hdr",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("proj_inv_hdr.inv_num = {0}", InvNum)))))
				{
					if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(tableName: "proj_all",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("proj_all.proj_num = {1} AND proj_all.site_ref = {0}", SiteRef, CoNum)))))
					{
						#region CRUD ExecuteMethodCall

						var MsgApp4 = this.iMsgApp.MsgAppSp(Infobar: Infobar
							, BaseMsg: "E=NoExist1"
							, Parm1: "@proj"
							, Parm2: "@proj.proj_num"
							, Parm3: CoNum);
						Severity = MsgApp4.ReturnCode;
						Infobar = MsgApp4.Infobar;

						#endregion ExecuteMethodCall

						break;
					}
				}

				break;
			}

			return (Severity, Infobar);
		}

		public (int? ReturnCode, string Infobar) AltExtGen_ValidateCoNumXrefSp(string AltExtGenSp,
			string DerCoNumXref,
			string CoNum,
			string InvNum,
			string SiteRef,
			string Infobar)
		{
			StringType _DerCoNumXref = DerCoNumXref;
			CoNumType _CoNum = CoNum;
			InvNumType _InvNum = InvNum;
			SiteType _SiteRef = SiteRef;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "DerCoNumXref", _DerCoNumXref, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}
}

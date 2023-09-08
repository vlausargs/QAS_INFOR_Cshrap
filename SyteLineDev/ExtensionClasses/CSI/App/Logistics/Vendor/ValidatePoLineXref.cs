//PROJECT NAME: Logistics
//CLASS NAME: ValidatePoLineXref.cs

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

namespace CSI.Logistics.Vendor
{
	public class ValidatePoLineXref : IValidatePoLineXref
	{
		readonly IApplicationDB appDB;

		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;

		public ValidatePoLineXref(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
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
			this.convertToUtil = convertToUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
		}

		public (int? ReturnCode,
			string PromptMsg,
			string Infobar) 
		ValidatePoLineXrefSp(string PoNum,
			int? PoLine,
			int? PoRelease,
			string PoItem,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string PromptMsg,
			string Infobar)
		{
			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			RowPointerType _JobmatlRowPointer = DBNull.Value;
			Guid? JobmatlRowPointer = null;
			ItemType _JobmatlItem = DBNull.Value;
			string JobmatlItem = null;
			RowPointerType _CoItemRowPointer = DBNull.Value;
			Guid? CoItemRowPointer = null;
			ItemType _CoItemItem = DBNull.Value;
			string CoItemItem = null;
			RowPointerType _ProjmatlRowPointer = DBNull.Value;
			Guid? ProjmatlRowPointer = null;
			ItemType _ProjmatlItem = DBNull.Value;
			string ProjmatlItem = null;
			RowPointerType _TrnItemRowPointer = DBNull.Value;
			Guid? TrnItemRowPointer = null;
			ItemType _TrnItemItem = DBNull.Value;
			string TrnItemItem = null;

			if (existsChecker.Exists(
				tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidatePoLineXrefSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
			{
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidatePoLineXrefSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ValidatePoLineXrefSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);

				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords

				while (existsChecker.Exists(
					tableName: "#tv_ALTGEN",
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

					var ALTGEN = AltExtGen_ValidatePoLineXrefSp(_ALTGEN_SpName,
						PoNum,
						PoLine,
						PoRelease,
						PoItem,
						RefType,
						RefNum,
						RefLineSuf,
						RefRelease,
						PromptMsg,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, PromptMsg, Infobar);
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ValidatePoLineXrefSp") != null)
			{
				var EXTGEN = AltExtGen_ValidatePoLineXrefSp("dbo.EXTGEN_ValidatePoLineXrefSp",
					PoNum,
					PoLine,
					PoRelease,
					PoItem,
					RefType,
					RefNum,
					RefLineSuf,
					RefRelease,
					PromptMsg,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.PromptMsg, EXTGEN.Infobar);
				}
			}

			Infobar = null;
			PromptMsg = null;
			Severity = 0;
			if (PoNum == null || PoItem == null || RefType == null || RefNum == null || RefLineSuf == null)
			{
				return (Severity, PromptMsg, Infobar);
			}
			while (sQLUtil.SQLEqual(Severity, 0) == true)
			{
				if (sQLUtil.SQLEqual(RefType, "J") == true)
				{
					#region CRUD LoadToVariable
					var jobmatlLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_JobmatlRowPointer,"jobmatl.RowPointer"},
							{_JobmatlItem,"jobmatl.item"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "jobmatl",
						fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
						whereClause: collectionLoadRequestFactory.Clause("jobmatl.job = {3} AND jobmatl.suffix = {0} AND jobmatl.oper_num = {1} AND jobmatl.ref_num = {5} AND jobmatl.ref_line_suf = {4} AND jobmatl.ref_release = {2}", RefLineSuf, RefRelease, PoRelease, RefNum, PoLine, PoNum),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var jobmatlLoadResponse = this.appDB.Load(jobmatlLoadRequest);
					if (jobmatlLoadResponse.Items.Count > 0)
					{
						JobmatlRowPointer = _JobmatlRowPointer;
						JobmatlItem = _JobmatlItem;
					}
					#endregion  LoadToVariable

					if (JobmatlRowPointer != null && sQLUtil.SQLNotEqual(JobmatlItem, PoItem) == true)
					{
						#region CRUD ExecuteMethodCall

						var MsgApp = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
							, BaseMsg: "E=IsCompare3"
							, Parm1: "@jobmatl.item"
							, Parm2: JobmatlItem
							, Parm3: "@jobmatl"
							, Parm4: "@jobmatl.job"
							, Parm5: RefNum
							, Parm6: "@jobmatl.suffix"
							, Parm7: convertToUtil.ToString(RefLineSuf)
							, Parm8: "@jobmatl.oper_num"
							, Parm9: convertToUtil.ToString(RefRelease));
						PromptMsg = MsgApp.Infobar;

						#endregion ExecuteMethodCall

						#region CRUD ExecuteMethodCall

						var MsgApp1 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
							, BaseMsg: "I=IsCompareWillSet3"
							, Parm1: "@jobmatl.item"
							, Parm2: JobmatlItem
							, Parm3: PoItem
							, Parm4: "@poitem"
							, Parm5: "@poitem.po_num"
							, Parm6: PoNum
							, Parm7: "@poitem.po_line"
							, Parm8: convertToUtil.ToString(PoLine)
							, Parm9: "@poitem.po_release"
							, Parm10: convertToUtil.ToString(PoRelease));
						PromptMsg = MsgApp1.Infobar;

						#endregion ExecuteMethodCall

						#region CRUD ExecuteMethodCall

						var MsgApp2 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
							, BaseMsg: "E=XrefInvalid");
						PromptMsg = MsgApp2.Infobar;

						#endregion ExecuteMethodCall
					}
				}

				if (sQLUtil.SQLEqual(RefType, "O") == true)
				{
					#region CRUD LoadToVariable
					var coitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_CoItemRowPointer,"coitem.RowPointer"},
							{_CoItemItem,"coitem.item"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "coitem",
						fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
						whereClause: collectionLoadRequestFactory.Clause("coitem.co_num = {3} AND coitem.co_line = {0} AND coitem.co_release = {1} AND coitem.ref_num = {5} AND coitem.ref_line_suf = {4} AND coitem.ref_release = {2}", RefLineSuf, RefRelease, PoRelease, RefNum, PoLine, PoNum),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var coitemLoadResponse = this.appDB.Load(coitemLoadRequest);
					if (coitemLoadResponse.Items.Count > 0)
					{
						CoItemRowPointer = _CoItemRowPointer;
						CoItemItem = _CoItemItem;
					}
					#endregion  LoadToVariable

					if (CoItemRowPointer != null && sQLUtil.SQLNotEqual(CoItemItem, PoItem) == true)
					{
						#region CRUD ExecuteMethodCall

						var MsgApp3 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
							, BaseMsg: "E=IsCompare3"
							, Parm1: "@coitem.item"
							, Parm2: CoItemItem
							, Parm3: "@coitem"
							, Parm4: "@coitem.co_num"
							, Parm5: RefNum
							, Parm6: "@coitem.co_line"
							, Parm7: convertToUtil.ToString(RefLineSuf)
							, Parm8: "@coitem.co_release"
							, Parm9: convertToUtil.ToString(RefRelease));
						PromptMsg = MsgApp3.Infobar;

						#endregion ExecuteMethodCall

						#region CRUD ExecuteMethodCall

						var MsgApp4 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
							, BaseMsg: "I=IsCompareWillSet3"
							, Parm1: "@coitem.item"
							, Parm2: CoItemItem
							, Parm3: PoItem
							, Parm4: "@poitem"
							, Parm5: "@poitem.po_num"
							, Parm6: PoNum
							, Parm7: "@poitem.po_line"
							, Parm8: convertToUtil.ToString(PoLine)
							, Parm9: "@poitem.po_release"
							, Parm10: convertToUtil.ToString(PoRelease));
						PromptMsg = MsgApp4.Infobar;

						#endregion ExecuteMethodCall

						#region CRUD ExecuteMethodCall

						var MsgApp5 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
							, BaseMsg: "E=XrefInvalid");
						PromptMsg = MsgApp5.Infobar;

						#endregion ExecuteMethodCall
					}
				}
				if (sQLUtil.SQLEqual(RefType, "K") == true)
				{
					#region CRUD LoadToVariable
					var projmatlLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_ProjmatlRowPointer,"projmatl.RowPointer"},
							{_ProjmatlItem,"projmatl.item"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "projmatl",
						fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
						whereClause: collectionLoadRequestFactory.Clause("projmatl.proj_num = {3} AND projmatl.task_num = {0} AND projmatl.seq = {1} AND projmatl.ref_num = {5} AND projmatl.ref_line_suf = {4} AND projmatl.ref_release = {2}", RefLineSuf, RefRelease, PoRelease, RefNum, PoLine, PoNum),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var projmatlLoadResponse = this.appDB.Load(projmatlLoadRequest);
					if (projmatlLoadResponse.Items.Count > 0)
					{
						ProjmatlRowPointer = _ProjmatlRowPointer;
						ProjmatlItem = _ProjmatlItem;
					}
					#endregion  LoadToVariable

					if (ProjmatlRowPointer != null && sQLUtil.SQLNotEqual(ProjmatlItem, PoItem) == true)
					{
						#region CRUD ExecuteMethodCall

						var MsgApp6 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
							, BaseMsg: "E=IsCompare3"
							, Parm1: "@projmatl.item"
							, Parm2: ProjmatlItem
							, Parm3: "@projmatl"
							, Parm4: "@projmatl.proj_num"
							, Parm5: RefNum
							, Parm6: "@projmatl.task_num"
							, Parm7: convertToUtil.ToString(RefLineSuf)
							, Parm8: "@projmatl.seq"
							, Parm9: convertToUtil.ToString(RefRelease));
						PromptMsg = MsgApp6.Infobar;

						#endregion ExecuteMethodCall

						#region CRUD ExecuteMethodCall

						var MsgApp7 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
							, BaseMsg: "I=IsCompareWillSet3"
							, Parm1: "@projmatl.item"
							, Parm2: ProjmatlItem
							, Parm3: PoItem
							, Parm4: "@poitem"
							, Parm5: "@poitem.po_num"
							, Parm6: PoNum
							, Parm7: "@poitem.po_line"
							, Parm8: convertToUtil.ToString(PoLine)
							, Parm9: "@poitem.po_release"
							, Parm10: convertToUtil.ToString(PoRelease));
							PromptMsg = MsgApp7.Infobar;

						#endregion ExecuteMethodCall

						#region CRUD ExecuteMethodCall

						var MsgApp8 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
							, BaseMsg: "E=XrefInvalid");
						PromptMsg = MsgApp8.Infobar;

						#endregion ExecuteMethodCall
					}
				}

				if (sQLUtil.SQLEqual(RefType, "T") == true)
				{
					#region CRUD LoadToVariable
					var trnitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_TrnItemRowPointer,"trnitem.RowPointer"},
							{_TrnItemItem,"trnitem.item"},
						},
						loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "trnitem",
						fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
						whereClause: collectionLoadRequestFactory.Clause("trnitem.trn_num = {2} AND trnitem.trn_line = {0} AND trnitem.frm_ref_num = {4} AND trnitem.frm_ref_line_suf = {3} AND trnitem.frm_ref_release = {1}", RefLineSuf, PoRelease, RefNum, PoLine, PoNum),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var trnitemLoadResponse = this.appDB.Load(trnitemLoadRequest);
					if (trnitemLoadResponse.Items.Count > 0)
					{
						TrnItemRowPointer = _TrnItemRowPointer;
						TrnItemItem = _TrnItemItem;
					}
					#endregion  LoadToVariable

					if (TrnItemRowPointer != null && sQLUtil.SQLNotEqual(TrnItemItem, PoItem) == true)
					{
						#region CRUD ExecuteMethodCall

						var MsgApp9 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
							, BaseMsg: "E=IsCompare2"
							, Parm1: "@trnitem.item"
							, Parm2: TrnItemItem
							, Parm3: "@trnitem"
							, Parm4: "@trnitem.trn_num"
							, Parm5: RefNum
							, Parm6: "@trnitem.trn_line"
							, Parm7: convertToUtil.ToString(RefLineSuf));
						PromptMsg = MsgApp9.Infobar;

						#endregion ExecuteMethodCall

						#region CRUD ExecuteMethodCall

						var MsgApp10 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
							, BaseMsg: "I=IsCompareWillSet3"
							, Parm1: "@trnitem.item"
							, Parm2: TrnItemItem
							, Parm3: PoItem
							, Parm4: "@poitem"
							, Parm5: "@poitem.po_num"
							, Parm6: PoNum
							, Parm7: "@poitem.po_line"
							, Parm8: convertToUtil.ToString(PoLine)
							, Parm9: "@poitem.po_release"
							, Parm10: convertToUtil.ToString(PoRelease));
							PromptMsg = MsgApp10.Infobar;

						#endregion ExecuteMethodCall

						#region CRUD ExecuteMethodCall

						var MsgApp11 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
							, BaseMsg: "E=XrefInvalid");
						PromptMsg = MsgApp11.Infobar;

						#endregion ExecuteMethodCall
					}
				}

				break;
			}

			return (Severity, PromptMsg, Infobar);
		}

		public (int? ReturnCode, 
			string PromptMsg,
			string Infobar) 
		AltExtGen_ValidatePoLineXrefSp(string AltExtGenSp,
			string PoNum,
			int? PoLine,
			int? PoRelease,
			string PoItem,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string PromptMsg,
			string Infobar)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			ItemType _PoItem = PoItem;
			RefTypeIJKOTType _RefType = RefType;
			CoJobProjTrnNumType _RefNum = RefNum;
			CoLineSuffixProjTaskTrnLineType _RefLineSuf = RefLineSuf;
			CoReleaseOperNumType _RefRelease = RefRelease;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItem", _PoItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				PromptMsg = _PromptMsg;
				Infobar = _Infobar;

				return (Severity, PromptMsg, Infobar);
			}
		}
	}
}

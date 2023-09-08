//PROJECT NAME: Logistics
//CLASS NAME: ValidateInvVoid.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ValidateInvVoid : IValidateInvVoid
	{
		readonly IApplicationDB appDB;

		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;

		public ValidateInvVoid(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
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
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
		}

		public (int? ReturnCode, string Infobar) ValidateInvVoidSP(string VInvNum,
			string Type,
			string Infobar)
		{
			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			RowPointerType _InvRowPointer = DBNull.Value;
			Guid? InvRowPointer = null;
			int? Severity = null;
			string SeqType = null;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidateInvVoidSP' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidateInvVoidSP' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ValidateInvVoidSP", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_ValidateInvVoidSP(_ALTGEN_SpName,
						VInvNum,
						Type,
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ValidateInvVoidSP") != null)
			{
				var EXTGEN = AltExtGen_ValidateInvVoidSP("dbo.EXTGEN_ValidateInvVoidSP",
					VInvNum,
					Type,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}

			Severity = 0;
			InvRowPointer = null;
			if (sQLUtil.SQLEqual(Type, "I") == true)
			{
				SeqType = "@:ArinvType:I";
			}
			else
			{
				if (sQLUtil.SQLEqual(Type, "D") == true)
				{
					SeqType = "@:ArinvType:D";
				}
				else
				{
					SeqType = "@:ArinvType:C";
				}
			}

			#region CRUD LoadToVariable
			var inv_sequenceLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_InvRowPointer,"inv_sequence.RowPointer"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "inv_sequence",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("{0} BETWEEN start_inv_num AND end_inv_num AND type = {1}", VInvNum, Type),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var inv_sequenceLoadResponse = this.appDB.Load(inv_sequenceLoadRequest);
			if (inv_sequenceLoadResponse.Items.Count > 0)
			{
				InvRowPointer = _InvRowPointer;
			}
			#endregion  LoadToVariable

			if (InvRowPointer == null)
			{
				Infobar = null;

				#region CRUD ExecuteMethodCall

				var MsgApp = this.iMsgApp.MsgAppSp(Infobar: Infobar
					, BaseMsg: "E=NoExistFor1"
					, Parm1: "@inv_sequence"
					, Parm2: VInvNum
					, Parm3: "@inv_sequence.type"
					, Parm4: SeqType);
				Severity = MsgApp.ReturnCode;
				Infobar = MsgApp.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, Infobar);//END
			}

			InvRowPointer = null;

			#region CRUD LoadToVariable
			var inv_voidLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_InvRowPointer,"inv_void.RowPointer"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "inv_void",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("inv_void.inv_num = {0} AND type = {1}", VInvNum, Type),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var inv_voidLoadResponse = this.appDB.Load(inv_voidLoadRequest);
			if (inv_voidLoadResponse.Items.Count > 0)
			{
				InvRowPointer = _InvRowPointer;
			}
			#endregion  LoadToVariable

			if (InvRowPointer != null)
			{
				Infobar = null;

				#region CRUD ExecuteMethodCall

				var MsgApp1 = this.iMsgApp.MsgAppSp(Infobar: Infobar
					, BaseMsg: "E=Voided"
					, Parm1: SeqType
					, Parm2: VInvNum);
				Severity = MsgApp1.ReturnCode;
				Infobar = MsgApp1.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, Infobar);//END
			}

			InvRowPointer = null;

			#region CRUD LoadToVariable
			var inv_hdrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_InvRowPointer,"inv_hdr.RowPointer"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "inv_hdr",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("inv_hdr.inv_num = {0}", VInvNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var inv_hdrLoadResponse = this.appDB.Load(inv_hdrLoadRequest);
			if (inv_hdrLoadResponse.Items.Count > 0)
			{
				InvRowPointer = _InvRowPointer;
			}
			#endregion  LoadToVariable

			if (InvRowPointer != null)
			{
				Infobar = null;

				#region CRUD ExecuteMethodCall

				var MsgApp2 = this.iMsgApp.MsgAppSp(Infobar: Infobar
					, BaseMsg: "E=Exist1"
					, Parm1: "@inv_hdr"
					, Parm2: "@inv_hdr.inv_num"
					, Parm3: VInvNum);
				Severity = MsgApp2.ReturnCode;
				Infobar = MsgApp2.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, Infobar);//END
			}
			InvRowPointer = null;

			#region CRUD LoadToVariable
			var proj_inv_hdrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_InvRowPointer,"proj_inv_hdr.RowPointer"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "proj_inv_hdr",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("proj_inv_hdr.inv_num = {0}", VInvNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var proj_inv_hdrLoadResponse = this.appDB.Load(proj_inv_hdrLoadRequest);
			if (proj_inv_hdrLoadResponse.Items.Count > 0)
			{
				InvRowPointer = _InvRowPointer;
			}
			#endregion  LoadToVariable

			if (InvRowPointer != null)
			{
				Infobar = null;

				#region CRUD ExecuteMethodCall

				var MsgApp3 = this.iMsgApp.MsgAppSp(Infobar: Infobar
					, BaseMsg: "E=Exist1"
					, Parm1: "@proj_inv_hdr"
					, Parm2: "@proj_inv_hdr.inv_num"
					, Parm3: VInvNum);
				Severity = MsgApp3.ReturnCode;
				Infobar = MsgApp3.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, Infobar);//END
			}

			InvRowPointer = null;

			#region CRUD LoadToVariable
			var arinvLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_InvRowPointer,"arinv.RowPointer"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "arinv",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("arinv.inv_num = {0}", VInvNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var arinvLoadResponse = this.appDB.Load(arinvLoadRequest);
			if (arinvLoadResponse.Items.Count > 0)
			{
				InvRowPointer = _InvRowPointer;
			}
			#endregion  LoadToVariable

			if (InvRowPointer != null)
			{
				Infobar = null;

				#region CRUD ExecuteMethodCall

				var MsgApp4 = this.iMsgApp.MsgAppSp(Infobar: Infobar
					, BaseMsg: "E=Exist1"
					, Parm1: "@arinv"
					, Parm2: "@arinv.inv_num"
					, Parm3: VInvNum);
				Severity = MsgApp4.ReturnCode;
				Infobar = MsgApp4.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, Infobar);//END
			}

			return (Severity, Infobar);
		}

		public (int? ReturnCode, string Infobar) AltExtGen_ValidateInvVoidSP(string AltExtGenSp,
			string VInvNum,
			string Type,
			string Infobar)
		{
			InvNumType _VInvNum = VInvNum;
			ArinvTypeType _Type = Type;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "VInvNum", _VInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}
}

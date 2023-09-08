//PROJECT NAME: Material
//CLASS NAME: CLM_TransactionDetailMatTran.cs

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

namespace CSI.Material
{
	public class CLM_TransactionDetailMatTran : ICLM_TransactionDetailMatTran
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
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMtCode iMtCode;

		public CLM_TransactionDetailMatTran(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IMtCode iMtCode)
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
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iMtCode = iMtCode;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_TransactionDetailMatTranSp(
			decimal? PMatlTransNum,
			string PSite,
			string PRefNum = null)
		{

			SiteType _PSite = PSite;

			ICollectionLoadResponse Data = null;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			string Ref = null;
			string RefDesc = null;
			string Job = null;
			string Loc = null;
			string LocCode = null;
			string Reason = null;
			string ReasonDesc = null;
			string Type = null;
			string From = null;
			string To = null;
			decimal? TotPost = null;
			string Infobar = null;
			string TaskNum = null;
			string ProjNum = null;
			string TempRefNum = null;
			int? Position = null;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_TransactionDetailMatTranSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_TransactionDetailMatTranSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_TransactionDetailMatTranSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_CLM_TransactionDetailMatTranSp(ALTGEN_SpName,
						PMatlTransNum,
						PSite,
						PRefNum);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					#region CRUD LoadToRecord
					var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"[SpName]","[SpName]"},
						},
						tableName: "#tv_ALTGEN", 
                        loadForChange: true, 
                        lockingType: LockingType.None,
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
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_TransactionDetailMatTranSp") != null)
			{
				var EXTGEN = AltExtGen_CLM_TransactionDetailMatTranSp("dbo.EXTGEN_CLM_TransactionDetailMatTranSp",
					PMatlTransNum,
					PSite,
					PRefNum);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			Severity = 0;
			if (PSite == null)
			{

				#region CRUD LoadToVariable
				var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_PSite,"parms.site"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "parms",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
				if (parmsLoadResponse.Items.Count > 0)
				{
					PSite = _PSite;
				}
				#endregion  LoadToVariable

			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: MtCodeSp
			var MtCode = this.iMtCode.MtCodeSp(
				Site: PSite,
				TransNum: PMatlTransNum,
				Ref: Ref,
				RefDesc: RefDesc,
				Job: Job,
				Loc: Loc,
				LocCode: LocCode,
				Reason: Reason,
				ReasonDesc: ReasonDesc,
				Type: Type,
				From: From,
				To: To,
				TotPost: TotPost,
				Infobar: Infobar);
			Ref = MtCode.Ref;
			RefDesc = MtCode.RefDesc;
			Job = MtCode.Job;
			Loc = MtCode.Loc;
			LocCode = MtCode.LocCode;
			Reason = MtCode.Reason;
			ReasonDesc = MtCode.ReasonDesc;
			Type = MtCode.Type;
			From = MtCode.From;
			To = MtCode.To;
			TotPost = MtCode.TotPost;
			Infobar = MtCode.Infobar;

			#endregion ExecuteMethodCall

			if (existsChecker.Exists(tableName: "matltran_all",
				fromClause: collectionLoadRequestFactory.Clause(" AS mt_a"),
				whereClause: collectionLoadRequestFactory.Clause("mt_a.site_ref = {1} AND mt_a.trans_num = {0}", PMatlTransNum, PSite))
			)
			{
				//BEGIN

				#region CRUD LoadToRecord
				var matltran_all1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"mt_a.trans_num","mt_a.trans_num"},
						{"mt_a.trans_date","mt_a.trans_date"},
						{"mt_a.item","mt_a.item"},
						{"mt_a.whse","mt_a.whse"},
						{"col4",$"{variableUtil.GetQuotedValue<string>(Type)}"},
						{"mt_a.user_code","mt_a.user_code"},
						{"col6",$"{variableUtil.GetQuotedValue<string>(From)}"},
						{"col7",$"{variableUtil.GetQuotedValue<string>(To)}"},
						{"mt_a.qty","mt_a.qty"},
						{"mt_a.cost","mt_a.cost"},
						{"col10",$"{variableUtil.GetQuotedValue<decimal?>(TotPost)}"},
						{"mt_a.document_num","mt_a.document_num"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "matltran_all",
					fromClause: collectionLoadRequestFactory.Clause(" AS mt_a"),
					whereClause: collectionLoadRequestFactory.Clause("mt_a.site_ref = {1} AND mt_a.trans_num = {0}", PMatlTransNum, PSite),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var matltran_all1LoadResponse = this.appDB.Load(matltran_all1LoadRequest);
				#endregion  LoadToRecord

				Data = matltran_all1LoadResponse;

				//END

			}
			else
			{
				Position = convertToUtil.ToInt32(stringUtil.CharIndex(
					" ",
					stringUtil.Reverse(PRefNum)));
				TaskNum = stringUtil.LTrim(stringUtil.RTrim(stringUtil.Right(PRefNum, Position)));
				TempRefNum = stringUtil.Substring(
					PRefNum,
					1,
					stringUtil.Len(PRefNum) - Position);
				ProjNum = stringUtil.LTrim(stringUtil.RTrim(stringUtil.Right(TempRefNum, stringUtil.CharIndex(
					" ",
					stringUtil.Reverse(TempRefNum)))));

				#region CRUD LoadToRecord
				var projtranLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"trans_num","trans_num"},
					{"tran_date","tran_date"},
					{"item","item"},
					{"whse","NULL"},
					{"tran_type","tran_type"},
					{"user_code","NULL"},
					{"FromCol",$"{variableUtil.GetQuotedValue<string>(From)}"},
					{"ToCol",$"{variableUtil.GetQuotedValue<string>(To)}"},
					{"qty","qty"},
					{"Amount","Amount"},
					{"TotPost",$"{variableUtil.GetQuotedValue<decimal?>(TotPost)}"},
					{"ref_num","ref_num"},
				},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    maximumRows: 1,
					tableName: "projtran",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("proj_num = {0} AND tran_type = 'L' AND task_num = {1} AND amount IN (SELECT DISTINCT dom_amount FROM Ledger WHERE ref = {2} AND ISNULL(matl_trans_num, 0) = 0)", ProjNum, TaskNum, PRefNum),
					orderByClause: collectionLoadRequestFactory.Clause(" Trans_Num DESC"));
				var projtranLoadResponse = this.appDB.Load(projtranLoadRequest);
				#endregion  LoadToRecord

				Data = projtranLoadResponse;
			}
			return (Data, Severity);

		}
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_CLM_TransactionDetailMatTranSp(
			string AltExtGenSp,
			decimal? PMatlTransNum,
			string PSite,
			string PRefNum = null)
		{
			MatlTransNumType _PMatlTransNum = PMatlTransNum;
			SiteType _PSite = PSite;
			ReferenceType _PRefNum = PRefNum;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "PMatlTransNum", _PMatlTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);

				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

				dtReturn = appDB.ExecuteQuery(cmd);

				var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
				var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;

				return (resultSet, returnCode);
			}
		}

	}
}

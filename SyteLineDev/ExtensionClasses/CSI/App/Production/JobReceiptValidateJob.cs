//PROJECT NAME: Production
//CLASS NAME: JobReceiptValidateJob.cs

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
using CSI.Logistics.Customer;

namespace CSI.Production
{
	public class JobReceiptValidateJob : IJobReceiptValidateJob
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
		readonly IObsSlow iObsSlow;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IFmtJob iFmtJob;
		readonly IMsgApp iMsgApp;
		readonly IMsgAsk iMsgAsk;

		public JobReceiptValidateJob(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			IObsSlow iObsSlow,
			ISQLValueComparerUtil sQLUtil,
			IFmtJob iFmtJob,
			IMsgApp iMsgApp,
			IMsgAsk iMsgAsk)
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
			this.iObsSlow = iObsSlow;
			this.sQLUtil = sQLUtil;
			this.iFmtJob = iFmtJob;
			this.iMsgApp = iMsgApp;
			this.iMsgAsk = iMsgAsk;
		}

		public (
			int? ReturnCode,
			int? JobrouteOperNum,
			decimal? QtyMoved,
			decimal? QtyComplete,
			int? ItemLotTracked,
			int? ItemSerialTracked,
			string Infobar,
			string Prompt,
			string PromptButtons)
		JobReceiptValidateJobSp(
			string Job,
			int? Suffix,
			int? JobrouteOperNum,
			decimal? QtyMoved,
			decimal? QtyComplete,
			int? ItemLotTracked,
			int? ItemSerialTracked,
			string Infobar,
			string Prompt = null,
			string PromptButtons = null)
		{
			JobType _Job = Job;
			OperNumType _JobrouteOperNum = JobrouteOperNum;
			QtyUnitType _QtyMoved = QtyMoved;
			QtyUnitType _QtyComplete = QtyComplete;
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			ListYesNoType _ItemSerialTracked = ItemSerialTracked;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			string FormattedJob = null;
			string MsgArg = null;
			JobStatusType _JobStatus = DBNull.Value;
			string JobStatus = null;
			ItemType _JobItem = DBNull.Value;
			string JobItem = null;
			WhseType _JobWhse = DBNull.Value;
			string JobWhse = null;
			ListYesNoType _JobCoProductMix = DBNull.Value;
			int? JobCoProductMix = null;
			ProductCodeType _ItemProductCode = DBNull.Value;
			string ItemProductCode = null;
			ListYesNoType _WhsePhyInvFlg = DBNull.Value;
			int? WhsePhyInvFlg = null;
			ListYesNoType _ItemwhseCntInProc = DBNull.Value;
			int? ItemwhseCntInProc = null;
			OperNumType _JobrouteOperation = DBNull.Value;
			int? JobrouteOperation = null;

			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('JobReceiptValidateJobSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('JobReceiptValidateJobSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("JobReceiptValidateJobSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_JobReceiptValidateJobSp(_ALTGEN_SpName,
						Job,
						Suffix,
						JobrouteOperNum,
						QtyMoved,
						QtyComplete,
						ItemLotTracked,
						ItemSerialTracked,
						Infobar,
						Prompt,
						PromptButtons);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						ItemLotTracked = _ItemLotTracked;
						ItemSerialTracked = _ItemSerialTracked;
						JobrouteOperNum = _JobrouteOperNum;
						QtyMoved = _QtyMoved;
						QtyComplete = _QtyComplete;
						return (ALTGEN_Severity, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons);
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
				}
			}

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_JobReceiptValidateJobSp") != null)
			{
				var EXTGEN = AltExtGen_JobReceiptValidateJobSp("dbo.EXTGEN_JobReceiptValidateJobSp",
					Job,
					Suffix,
					JobrouteOperNum,
					QtyMoved,
					QtyComplete,
					ItemLotTracked,
					ItemSerialTracked,
					Infobar,
					Prompt,
					PromptButtons);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.JobrouteOperNum, EXTGEN.QtyMoved, EXTGEN.QtyComplete, EXTGEN.ItemLotTracked, EXTGEN.ItemSerialTracked, EXTGEN.Infobar, EXTGEN.Prompt, EXTGEN.PromptButtons);
				}
			}

			Severity = 0;
			Prompt = null;

			#region CRUD LoadToVariable
			var jobLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_JobStatus,"job.stat"},
					{_JobItem,"job.item"},
					{_JobWhse,"job.whse"},
					{_JobCoProductMix,"job.co_product_mix"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "job",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job.job = {1} AND job.suffix = {0} AND job.type = 'J'", Suffix, Job),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var jobLoadResponse = this.appDB.Load(jobLoadRequest);
			if (jobLoadResponse.Items.Count > 0)
			{
				JobStatus = _JobStatus;
				JobItem = _JobItem;
				JobWhse = _JobWhse;
				JobCoProductMix = _JobCoProductMix;
			}
			#endregion  LoadToVariable

			if (sQLUtil.SQLEqual(this.scalarFunction.Execute<int>("@@rowcount"), 0) == true)
			{
				FormattedJob = this.iFmtJob.FmtJobSp(
					Job,
					Suffix);

				#region CRUD ExecuteMethodCall

				var MsgApp = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NoExist1",
					Parm1: "@job",
					Parm2: "@job.job",
					Parm3: FormattedJob);
				Severity = MsgApp.ReturnCode;
				Infobar = MsgApp.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons);//END
			}

			if (sQLUtil.SQLNotEqual(JobStatus, "R") == true)
			{
				//BEGIN
				MsgArg = stringUtil.Concat("@:JobStatus:", JobStatus);

				#region CRUD ExecuteMethodCall

				var MsgApp1 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NoCompare=",
					Parm1: "@job.stat",
					Parm2: MsgArg);
				Severity = MsgApp1.ReturnCode;
				Infobar = MsgApp1.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons);//END
			}

			#region CRUD LoadToVariable
			var itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ItemProductCode,"item.product_code"},
					{_ItemLotTracked,"item.lot_tracked"},
					{_ItemSerialTracked,"item.serial_tracked"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "item",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("item.item = {0}", JobItem),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var itemLoadResponse = this.appDB.Load(itemLoadRequest);
			if (itemLoadResponse.Items.Count > 0)
			{
				ItemProductCode = _ItemProductCode;
				ItemLotTracked = _ItemLotTracked;
				ItemSerialTracked = _ItemSerialTracked;
			}
			#endregion  LoadToVariable

			if (sQLUtil.SQLEqual(this.scalarFunction.Execute<int>("@@rowcount"), 0) == true)
			{
				#region CRUD ExecuteMethodCall

				var MsgApp2 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NoExist1",
					Parm1: "@item",
					Parm2: "@job.item",
					Parm3: JobItem);
				Severity = MsgApp2.ReturnCode;
				Infobar = MsgApp2.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons);//END
			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ObsSlowSp
			var ObsSlow = this.iObsSlow.ObsSlowSp(
				Item: JobItem,
				Infobar: Infobar,
				Prompt: Prompt,
				PromptButtons: PromptButtons);
			Severity = ObsSlow.ReturnCode;
			Infobar = ObsSlow.Infobar;
			Prompt = ObsSlow.Prompt;
			PromptButtons = ObsSlow.PromptButtons;

			#endregion ExecuteMethodCall

			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				return (Severity, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons);
			}
			if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(tableName: "prodcode",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("product_code = {0}", ItemProductCode)))))
			{
				#region CRUD ExecuteMethodCall

				var MsgApp3 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NoExist1",
					Parm1: "@prodcode",
					Parm2: "@prodcode.product_code",
					Parm3: ItemProductCode);
				Severity = MsgApp3.ReturnCode;
				Infobar = MsgApp3.Infobar;

				#endregion ExecuteMethodCall

				#region CRUD ExecuteMethodCall

				var MsgApp4 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=IsCompare",
					Parm1: "@item.item",
					Parm2: JobItem);
				Severity = MsgApp4.ReturnCode;
				Infobar = MsgApp4.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons);//END
			}

			#region CRUD LoadToVariable
			var whseLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_WhsePhyInvFlg,"whse.phy_inv_flg"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "whse",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("whse.whse = {0}", JobWhse),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var whseLoadResponse = this.appDB.Load(whseLoadRequest);
			if (whseLoadResponse.Items.Count > 0)
			{
				WhsePhyInvFlg = _WhsePhyInvFlg;
			}
			#endregion  LoadToVariable

			if (sQLUtil.SQLEqual(this.scalarFunction.Execute<int>("@@rowcount"), 0) == true)
			{
				#region CRUD ExecuteMethodCall

				var MsgApp5 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NoExist1",
					Parm1: "@whse",
					Parm2: "@whse.whse",
					Parm3: JobWhse);
				Severity = MsgApp5.ReturnCode;
				Infobar = MsgApp5.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons);//END
			}

			if (sQLUtil.SQLEqual(WhsePhyInvFlg, 1) == true)
			{
				#region CRUD ExecuteMethodCall

				var MsgApp6 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=IsCompare2",
					Parm1: "@whse.phy_inv_flg",
					Parm2: "@:logical:yes",
					Parm3: "@whse",
					Parm4: "@job.job",
					Parm5: Job,
					Parm6: "@job.whse",
					Parm7: JobWhse);
				Severity = MsgApp6.ReturnCode;
				Infobar = MsgApp6.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons);//END
			}

			#region CRUD LoadToVariable
			var itemwhseLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ItemwhseCntInProc,"itemwhse.cnt_in_proc"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "itemwhse",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("itemwhse.whse = {0} AND itemwhse.item = {1}", JobWhse, JobItem),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var itemwhseLoadResponse = this.appDB.Load(itemwhseLoadRequest);
			if (itemwhseLoadResponse.Items.Count > 0)
			{
				ItemwhseCntInProc = _ItemwhseCntInProc;
			}
			#endregion  LoadToVariable

			if (sQLUtil.SQLEqual(this.scalarFunction.Execute<int>("@@rowcount"), 0) == true)
			{
				#region CRUD ExecuteMethodCall

				var MsgApp7 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NoExist2",
					Parm1: "@itemwhse",
					Parm2: "@itemwhse.item",
					Parm3: JobItem,
					Parm4: "@itemwhse.whse",
					Parm5: JobWhse);
				Severity = MsgApp7.ReturnCode;
				Infobar = MsgApp7.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons);//END
			}
			if (sQLUtil.SQLEqual(ItemwhseCntInProc, 1) == true)
			{
				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: MsgAskSp
				var MsgAsk = this.iMsgAsk.MsgAskSp(
					Infobar: Prompt,
					Buttons: PromptButtons,
					BaseMsg: "Q=IsCompare2NoYes",
					Parm1: "@itemwhse.cnt_in_proc",
					Parm2: "@:logical:yes",
					Parm3: "@itemwhse",
					Parm4: "@itemwhse.item",
					Parm5: JobItem,
					Parm6: "@itemwhse.whse",
					Parm7: JobWhse);
				Prompt = MsgAsk.Infobar;
				PromptButtons = MsgAsk.Buttons;

				#endregion ExecuteMethodCall
			}
			if (sQLUtil.SQLEqual(JobrouteOperNum, 0) == true)
			{
				#region CRUD LoadToVariable
				var jobrouteLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_JobrouteOperNum,"jobroute.oper_num"},
						{_QtyMoved,"jobroute.qty_moved"},
						{_QtyComplete,"jobroute.qty_complete"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    maximumRows: 1,
					tableName: "jobroute",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("jobroute.job = {1} AND jobroute.suffix = {0}", Suffix, Job),
					orderByClause: collectionLoadRequestFactory.Clause(" oper_num DESC"));

				var jobrouteLoadResponse = this.appDB.Load(jobrouteLoadRequest);
				if (jobrouteLoadResponse.Items.Count > 0)
				{
					JobrouteOperNum = _JobrouteOperNum;
					QtyMoved = _QtyMoved;
					QtyComplete = _QtyComplete;
				}
				#endregion  LoadToVariable
			}

			#region CRUD LoadToVariable
			var jobroute1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_JobrouteOperation,"jobroute.oper_num"},
					{_QtyMoved,"jobroute.qty_moved"},
					{_QtyComplete,"jobroute.qty_complete"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName: "jobroute",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("jobroute.job = {1} AND jobroute.suffix = {0}", Suffix, Job),
				orderByClause: collectionLoadRequestFactory.Clause(" oper_num DESC"));

			var jobroute1LoadResponse = this.appDB.Load(jobroute1LoadRequest);
			if (jobroute1LoadResponse.Items.Count > 0)
			{
				JobrouteOperation = _JobrouteOperation;
				QtyMoved = _QtyMoved;
				QtyComplete = _QtyComplete;
			}
			#endregion  LoadToVariable

			if (sQLUtil.SQLEqual(this.scalarFunction.Execute<int>("@@rowcount"), 0) == true)
			{
				FormattedJob = this.iFmtJob.FmtJobSp(
					Job,
					Suffix);

				#region CRUD ExecuteMethodCall

				var MsgApp8 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=NoExistFor1",
					Parm1: "@jobroute",
					Parm2: "@job",
					Parm3: "@jobroute.job",
					Parm4: FormattedJob);
				Severity = MsgApp8.ReturnCode;
				Infobar = MsgApp8.Infobar;

				#endregion ExecuteMethodCall

				return (Severity, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons);//END
			}
			if (sQLUtil.SQLEqual(JobCoProductMix, 1) == true)
			{

				#region CRUD LoadToVariable
				var jrt_itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_QtyMoved,"jrt_item.qty_moved"},
						{_QtyComplete,"jrt_item.qty_complete"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "jrt_item",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("jrt_item.job = {3} AND jrt_item.suffix = {2} AND jrt_item.oper_num = {0} AND jrt_item.item = {1}", JobrouteOperation, JobItem, Suffix, Job),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var jrt_itemLoadResponse = this.appDB.Load(jrt_itemLoadRequest);
				if (jrt_itemLoadResponse.Items.Count > 0)
				{
					QtyMoved = _QtyMoved;
					QtyComplete = _QtyComplete;
				}
				#endregion  LoadToVariable

			}

			return (Severity, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons);

		}
		public (int? ReturnCode,
			int? JobrouteOperNum,
			decimal? QtyMoved,
			decimal? QtyComplete,
			int? ItemLotTracked,
			int? ItemSerialTracked,
			string Infobar,
			string Prompt,
			string PromptButtons)
		AltExtGen_JobReceiptValidateJobSp(
			string AltExtGenSp,
			string Job,
			int? Suffix,
			int? JobrouteOperNum,
			decimal? QtyMoved,
			decimal? QtyComplete,
			int? ItemLotTracked,
			int? ItemSerialTracked,
			string Infobar,
			string Prompt = null,
			string PromptButtons = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _JobrouteOperNum = JobrouteOperNum;
			QtyUnitType _QtyMoved = QtyMoved;
			QtyUnitType _QtyComplete = QtyComplete;
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			ListYesNoType _ItemSerialTracked = ItemSerialTracked;
			InfobarType _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteOperNum", _JobrouteOperNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyMoved", _QtyMoved, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyComplete", _QtyComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				JobrouteOperNum = _JobrouteOperNum;
				QtyMoved = _QtyMoved;
				QtyComplete = _QtyComplete;
				ItemLotTracked = _ItemLotTracked;
				ItemSerialTracked = _ItemSerialTracked;
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;

				return (Severity, JobrouteOperNum, QtyMoved, QtyComplete, ItemLotTracked, ItemSerialTracked, Infobar, Prompt, PromptButtons);
			}
		}
	}
}

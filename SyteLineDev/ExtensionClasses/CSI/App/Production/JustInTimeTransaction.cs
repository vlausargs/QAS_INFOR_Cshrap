//PROJECT NAME: Production
//CLASS NAME: JustInTimeTransaction.cs

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
using CSI.Finance;
using CSI.Codes;

namespace CSI.Production
{
	public class JustInTimeTransaction : IJustInTimeTransaction
	{
		
		readonly ICheckWhseExternalControlledFlag iCheckWhseExternalControlledFlag;
		readonly IUndefineVariableBySessionId iUndefineVariableBySessionId;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly IValidateRestrictedTrans iValidateRestrictedTrans;
		readonly IDefinedValueBySessionId iDefinedValueBySessionId;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ITransactionFactory transactionFactory;
		readonly IJournalImmediate iJournalImmediate;
		readonly IApsSyncImmediate iApsSyncImmediate;
		readonly IJobtranPostMatl iJobtranPostMatl;
		readonly IDefineVariable iDefineVariable;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IApsSyncDefer iApsSyncDefer;
		readonly IJournalDefer iJournalDefer;
		readonly IStringUtil stringUtil;
		readonly IUserCode iUserCode;
		readonly ISernumJ iSernumJ;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly IJobP2 iJobP2;
		readonly IJobtP iJobtP;
		readonly IJustInTimeTransactionCRUD iJustInTimeTransactionCRUD;
		
		public JustInTimeTransaction(ICheckWhseExternalControlledFlag iCheckWhseExternalControlledFlag,
			IUndefineVariableBySessionId iUndefineVariableBySessionId,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			IValidateRestrictedTrans iValidateRestrictedTrans,
			IDefinedValueBySessionId iDefinedValueBySessionId,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IJournalImmediate iJournalImmediate,
			IApsSyncImmediate iApsSyncImmediate,
			IJobtranPostMatl iJobtranPostMatl,
			IDefineVariable iDefineVariable,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IApsSyncDefer iApsSyncDefer,
			IJournalDefer iJournalDefer,
			IStringUtil stringUtil,
			IUserCode iUserCode,
			ISernumJ iSernumJ,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			IJobP2 iJobP2,
			IJobtP iJobtP,
			IJustInTimeTransactionCRUD iJustInTimeTransactionCRUD)
		{
			this.iCheckWhseExternalControlledFlag = iCheckWhseExternalControlledFlag;
			this.iUndefineVariableBySessionId = iUndefineVariableBySessionId;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.iValidateRestrictedTrans = iValidateRestrictedTrans;
			this.iDefinedValueBySessionId = iDefinedValueBySessionId;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.transactionFactory = transactionFactory;
			this.iJournalImmediate = iJournalImmediate;
			this.iApsSyncImmediate = iApsSyncImmediate;
			this.iJobtranPostMatl = iJobtranPostMatl;
			this.iDefineVariable = iDefineVariable;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.iApsSyncDefer = iApsSyncDefer;
			this.iJournalDefer = iJournalDefer;
			this.stringUtil = stringUtil;
			this.iUserCode = iUserCode;
			this.iSernumJ = iSernumJ;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iJobP2 = iJobP2;
			this.iJobtP = iJobtP;
			this.iJustInTimeTransactionCRUD = iJustInTimeTransactionCRUD;
		}
		
		public (
			int? ReturnCode,
			string Infobar)
		JustInTimeTransactionSp (
			string TItem,
			decimal? TcQtuQty,
			string TWhse,
			string TLoc,
			string TLot,
			DateTime? TTransDate,
			string TShift,
			string TEmpNum,
			int? PPostNeg,
			string SerialPrefix,
			Guid? SessionID,
			string Infobar,
			string ContainerNum = null,
			string DocumentNum = null)
		{
			
			Flag _PPostNeg = PPostNeg;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			int? CalledInTransaction = null;
			string JobrouteJob = null;
			int? JobrouteSuffix = null;
			int? JobrouteOperNum = null;
			string JobrouteWc = null;
			Guid? JobtranRowPointer = null;
			string JobtranTransType = null;
			string JobtranTransClass = null;
			DateTime? JobtranTransDate = null;
			decimal? JobtranQtyComplete = null;
			decimal? JobtranQtyScrapped = null;
			string JobtranEmpNum = null;
			decimal? JobtranQtyMoved = null;
			string JobtranShift = null;
			string JobtranWhse = null;
			string JobtranLoc = null;
			string JobtranUserCode = null;
			string JobtranLot = null;
			int? JobtranNextOper = null;
			int? JobtranPosted = null;
			int? JobtranAwaitingEop = null;
			string JobtranJob = null;
			int? JobtranSuffix = null;
			int? JobtranOperNum = null;
			string JobtranWc = null;
			string TTransType = null;
			decimal? TmpQty = null;
			int? ItemSerialTracked = null;
			string ItemJob = null;
			int? ItemSuffix = null;
			int? WhsePhyInvFlg = null;
			string WhseWhse = null;
			int? UseExistingSerials = null;
			Guid? BufferJournal = null;
			decimal? TJobtranTransNum = null;
			int? Coby = null;
			string JobJob = null;
			string ObsoleteItem = null;
			Guid? TJobtranRowPointer = null;
			if (this.iJustInTimeTransactionCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iJustInTimeTransactionCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("JustInTimeTransactionSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iJustInTimeTransactionCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				
				while (this.iJustInTimeTransactionCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iJustInTimeTransactionCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iJustInTimeTransactionCRUD.AltExtGen_JustInTimeTransactionSp (ALTGEN_SpName,
						TItem,
						TcQtuQty,
						TWhse,
						TLoc,
						TLot,
						TTransDate,
						TShift,
						TEmpNum,
						PPostNeg,
						SerialPrefix,
						SessionID,
						Infobar,
						ContainerNum,
						DocumentNum);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iJustInTimeTransactionCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iJustInTimeTransactionCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_JustInTimeTransactionSp") != null)
			{
				var EXTGEN = this.iJustInTimeTransactionCRUD.AltExtGen_JustInTimeTransactionSp("dbo.EXTGEN_JustInTimeTransactionSp",
					TItem,
					TcQtuQty,
					TWhse,
					TLoc,
					TLot,
					TTransDate,
					TShift,
					TEmpNum,
					PPostNeg,
					SerialPrefix,
					SessionID,
					Infobar,
					ContainerNum,
					DocumentNum);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			Severity = 0;
			Infobar = null;
			CalledInTransaction = this.scalarFunction.Execute<int>("@@TranCount");
			if (sQLUtil.SQLEqual(CalledInTransaction, 0) == true)
			{
				this.transactionFactory.BeginTransaction("");
				
			}
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: ValidateRestrictedTransSp
			var ValidateRestrictedTrans = this.iValidateRestrictedTrans.ValidateRestrictedTransSp(
				Item: TItem,
				Lot: TLot,
				SerialNums: null,
				MatlTransType: "F",
				Infobar: Infobar,
				RefId: null,
				RefType: null,
				ProcessId: SessionID,
				Site: null);
			Severity = ValidateRestrictedTrans.ReturnCode;
			Infobar = ValidateRestrictedTrans.Infobar;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				if (sQLUtil.SQLEqual(CalledInTransaction, 0) == true)
				{
					this.transactionFactory.RollbackTransaction("");
					
				}
				goto EOF;
				
			}
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: CheckWhseExternalControlledFlagSp
			var CheckWhseExternalControlledFlag = this.iCheckWhseExternalControlledFlag.CheckWhseExternalControlledFlagSp(
				PWhse: TWhse,
				PSite: null,
				Infobar: Infobar);
			Severity = CheckWhseExternalControlledFlag.ReturnCode;
			Infobar = CheckWhseExternalControlledFlag.Infobar;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				if (sQLUtil.SQLEqual(CalledInTransaction, 0) == true)
				{
					this.transactionFactory.RollbackTransaction("");
					
				}
				goto EOF;
				
			}
			ObsoleteItem = null;
			(ObsoleteItem, rowCount) = this.iJustInTimeTransactionCRUD.ItemasparentLoad(TItem, ObsoleteItem, TTransDate);
			if (ObsoleteItem!= null)
			{
				Infobar = null;
				
				#region CRUD ExecuteMethodCall
				
				var MsgApp = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=IsCompare1",
					Parm1: "@item.stat",
					Parm2: "@:ItemStatus:O",
					Parm3: "@item",
					Parm4: "@item.item",
					Parm5: ObsoleteItem);
				Severity = MsgApp.ReturnCode;
				Infobar = MsgApp.Infobar;
				
				#endregion ExecuteMethodCall
				
				if (sQLUtil.SQLEqual(CalledInTransaction, 0) == true)
				{
					this.transactionFactory.RollbackTransaction("");
					
				}
				goto EOF;
				
			}
			TTransType = "M";
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: DefineVariableSp
			var DefineVariable = this.iDefineVariable.DefineVariableSp(
				VariableName: "TmpSerId",
				VariableValue: convertToUtil.ToString(SessionID),
				Infobar: Infobar);
			Severity = DefineVariable.ReturnCode;
			Infobar = DefineVariable.Infobar;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				goto END_OF_MAIN_BLOCK;
				
			}
			SerialPrefix = stringUtil.IsNull(
				SerialPrefix,
				"");
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: DefineVariableSp
			var DefineVariable1 = this.iDefineVariable.DefineVariableSp(
				VariableName: "SerialPrefix",
				VariableValue: SerialPrefix,
				Infobar: Infobar);
			Severity = DefineVariable1.ReturnCode;
			Infobar = DefineVariable1.Infobar;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				goto END_OF_MAIN_BLOCK;
				
			}
			if (sQLUtil.SQLLessThan(TcQtuQty, 0) == true)
			{
				UseExistingSerials = 1;
				
			}
			else
			{
				UseExistingSerials = 0;
				
			}
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: DefineVariableSp
			var DefineVariable2 = this.iDefineVariable.DefineVariableSp(
				VariableName: "UseExistingSerials",
				VariableValue: convertToUtil.ToString(UseExistingSerials),
				Infobar: Infobar);
			Severity = DefineVariable2.ReturnCode;
			Infobar = DefineVariable2.Infobar;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				goto END_OF_MAIN_BLOCK;
				
			}
			WhsePhyInvFlg = 0;
			(WhsePhyInvFlg, WhseWhse, PPostNeg, rowCount) = this.iJustInTimeTransactionCRUD.WhseLoad(PPostNeg, WhsePhyInvFlg, WhseWhse);
			if (sQLUtil.SQLEqual(WhsePhyInvFlg, 1) == true)
			{
				Infobar = null;
				
				#region CRUD ExecuteMethodCall
				
				var MsgApp1 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=IsCompare1",
					Parm1: "@whse.phy_inv_flg",
					Parm2: "@:logical:yes",
					Parm3: "@whse",
					Parm4: "@invparms.def_whse",
					Parm5: WhseWhse);
				Severity = MsgApp1.ReturnCode;
				Infobar = MsgApp1.Infobar;
				
				#endregion ExecuteMethodCall
				
				goto END_OF_MAIN_BLOCK;
				
			}
			(ItemSerialTracked, ItemJob, ItemSuffix, rowCount) = this.iJustInTimeTransactionCRUD.ItemLoad(TItem, ItemSerialTracked, ItemJob, ItemSuffix);
			(JobJob, rowCount) = this.iJustInTimeTransactionCRUD.JobLoad(ItemJob, ItemSuffix, JobJob);
			JobrouteJob = null;
			JobrouteSuffix = 0;
			JobrouteOperNum = 0;
			JobrouteWc = null;
			(JobrouteJob, JobrouteSuffix, JobrouteOperNum, JobrouteWc, rowCount) = this.iJustInTimeTransactionCRUD.JobrouteLoad(ItemJob, ItemSuffix, JobrouteJob, JobrouteSuffix, JobrouteOperNum, JobrouteWc);
			TJobtranRowPointer = null;
			JobtranRowPointer = Guid.NewGuid();
			JobtranTransType = TTransType;
			JobtranTransClass = "K";
			JobtranTransDate = TTransDate;
			JobtranQtyComplete = TcQtuQty;
			JobtranQtyScrapped = 0;
			JobtranEmpNum = TEmpNum;
			JobtranQtyMoved = TcQtuQty;
			JobtranShift = TShift;
			JobtranWhse = TWhse;
			JobtranLoc = TLoc;
			JobtranUserCode = convertToUtil.ToString(this.iUserCode.UserCodeFn());
			JobtranLot = TLot;
			JobtranNextOper = null;
			JobtranPosted = 0;
			JobtranAwaitingEop = 0;
			JobtranJob = JobrouteJob;
			JobtranSuffix = JobrouteSuffix;
			JobtranOperNum = JobrouteOperNum;
			JobtranWc = JobrouteWc;
			TJobtranRowPointer = convertToUtil.ToGuid(this.iDefinedValueBySessionId.DefinedValueBySessionIdFn(
				SessionID,
				"JITJobtranRowPointer"));
			if (TJobtranRowPointer!= null)
			{
				JobtranRowPointer = TJobtranRowPointer;
				
			}
			if (sQLUtil.SQLBool(sQLUtil.SQLNot(this.iJustInTimeTransactionCRUD.JobtranForExists(JobtranRowPointer))))
			{
				var nonTableLoadResponse = this.iJustInTimeTransactionCRUD.NontableSelect(JobtranRowPointer, JobtranTransType, JobtranTransClass, JobtranTransDate, JobtranQtyComplete, JobtranQtyScrapped, JobtranEmpNum, JobtranQtyMoved, JobtranShift, JobtranWhse, JobtranLoc, JobtranUserCode, JobtranLot, JobtranNextOper, JobtranPosted, JobtranAwaitingEop, JobtranJob, JobtranSuffix, JobtranOperNum, JobtranWc, ContainerNum);
				this.iJustInTimeTransactionCRUD.NontableInsert(nonTableLoadResponse);
				
			}
			else
			{
				var jobtran1LoadResponse = this.iJustInTimeTransactionCRUD.Jobtran1Select(JobtranRowPointer);
				this.iJustInTimeTransactionCRUD.Jobtran1Update(ContainerNum, JobtranTransType, JobtranTransClass, JobtranTransDate, JobtranQtyComplete, JobtranQtyScrapped, JobtranEmpNum, JobtranQtyMoved, JobtranShift, JobtranWhse, JobtranLoc, JobtranUserCode, JobtranLot, JobtranNextOper, JobtranPosted, JobtranAwaitingEop, JobtranJob, JobtranSuffix, JobtranOperNum, JobtranWc, jobtran1LoadResponse);
				
			}
			(TJobtranTransNum, rowCount) = this.iJustInTimeTransactionCRUD.Jobtran2Load(JobtranRowPointer, TJobtranTransNum);
			if (sQLUtil.SQLEqual(ItemSerialTracked, 1) == true)
			{
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: SernumJSp
				var SernumJ = this.iSernumJ.SernumJSp(
					PWhse: TWhse,
					PActionCode: "2",
					PTransNum: TJobtranTransNum,
					PLoc: TLoc,
					PLot: TLot,
					PQty: TcQtuQty,
					Workkey: null,
					PQtySelected: TmpQty,
					Infobar: Infobar,
					PImportDocId: null,
					ContainerNum: ContainerNum);
				Severity = SernumJ.ReturnCode;
				TmpQty = SernumJ.PQtySelected;
				Infobar = SernumJ.Infobar;
				
				#endregion ExecuteMethodCall
				
				if (sQLUtil.SQLNotEqual(Severity, 0) == true)
				{
					
					#region CRUD ExecuteMethodCall
					
					var MsgApp2 = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "E=CmdFailed",
						Parm1: "@%post");
					Severity = MsgApp2.ReturnCode;
					Infobar = MsgApp2.Infobar;
					
					#endregion ExecuteMethodCall
					
					goto END_OF_MAIN_BLOCK;
					
				}
				
			}
			END_OF_MAIN_BLOCK: ;
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				if (sQLUtil.SQLEqual(CalledInTransaction, 0) == true)
				{
					this.transactionFactory.RollbackTransaction("");
					
				}
				goto EOF;
				
			}
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: ApsSyncDeferSp
			var ApsSyncDefer = this.iApsSyncDefer.ApsSyncDeferSp(
				Infobar: Infobar,
				Context: "JustInTimeTransactionSp");
			Infobar = ApsSyncDefer.Infobar;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: JournalDeferSp
			var JournalDefer = this.iJournalDefer.JournalDeferSp(
				Partition: BufferJournal,
				Infobar: Infobar);
			BufferJournal = JournalDefer.Partition;
			Infobar = JournalDefer.Infobar;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: JobP2Sp
			var JobP2 = this.iJobP2.JobP2Sp(
				SJobtranRowPointer: JobtranRowPointer,
				PPostNeg: PPostNeg,
				TCoby: Coby,
				Infobar: Infobar,
				DocumentNum: DocumentNum);
			Severity = JobP2.ReturnCode;
			Coby = JobP2.TCoby;
			Infobar = JobP2.Infobar;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLEqual(Severity, 0) == true)
			{
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: JobtPSp
				var JobtP = this.iJobtP.JobtPSp(
					CallFrom: "JIT",
					PTransNum: TJobtranTransNum,
					SessionId: SessionID,
					Infobar: Infobar);
				Severity = JobtP.ReturnCode;
				Infobar = JobtP.Infobar;
				
				#endregion ExecuteMethodCall
				
			}
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				if (sQLUtil.SQLEqual(CalledInTransaction, 0) == true)
				{
					this.transactionFactory.RollbackTransaction("");
					
				}
				
				#region CRUD ExecuteMethodCall
				
				var MsgApp3 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=CmdFailed",
					Parm1: "@%post");
				Severity = MsgApp3.ReturnCode;
				Infobar = MsgApp3.Infobar;
				
				#endregion ExecuteMethodCall
				
				goto EOF;
				
			}
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: JournalImmediateSp
			var JournalImmediate = this.iJournalImmediate.JournalImmediateSp(
				Partition: BufferJournal,
				Infobar: Infobar);
			Severity = JournalImmediate.ReturnCode;
			Infobar = JournalImmediate.Infobar;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				if (sQLUtil.SQLEqual(CalledInTransaction, 0) == true)
				{
					this.transactionFactory.RollbackTransaction("");
					
				}
				
				#region CRUD ExecuteMethodCall
				
				var MsgApp4 = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "E=CmdFailed",
					Parm1: "@%post");
				Severity = MsgApp4.ReturnCode;
				Infobar = MsgApp4.Infobar;
				
				#endregion ExecuteMethodCall
				
				goto EOF;
				
			}
			if (sQLUtil.SQLEqual(CalledInTransaction, 0) == true)
			{
				this.transactionFactory.CommitTransaction("");
				
			}
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: JobtranPostMatlSp
			var JobtranPostMatl = this.iJobtranPostMatl.JobtranPostMatlSp(
				SessionID: SessionID,
				JobtranTransNum: TJobtranTransNum,
				CallFrom: "JIT",
				Coby: Coby,
				Infobar: Infobar);
			Severity = JobtranPostMatl.ReturnCode;
			Infobar = JobtranPostMatl.Infobar;
			
			#endregion ExecuteMethodCall
			
			/*Needs to load at least one column from the table: tmp_ser for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var tmp_serLoadResponse = this.iJustInTimeTransactionCRUD.Tmp_SerSelect(Severity, SessionID, TJobtranTransNum, Coby, Infobar);
			this.iJustInTimeTransactionCRUD.Tmp_SerDelete(tmp_serLoadResponse);
			if (sQLUtil.SQLEqual(CalledInTransaction, 0) == true)
			{
				this.transactionFactory.BeginTransaction("");
				
			}
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: ApsSyncImmediateSp
			var ApsSyncImmediate = this.iApsSyncImmediate.ApsSyncImmediateSp(
				Infobar: Infobar,
				DropDeferred: Severity,
				Context: "JustInTimeTransactionSp");
			Infobar = ApsSyncImmediate.Infobar;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLEqual(CalledInTransaction, 0) == true)
			{
				this.transactionFactory.CommitTransaction("");
				
			}
			EOF: ;
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: UndefineVariableBySessionIdSp
			var UndefineVariableBySessionId = this.iUndefineVariableBySessionId.UndefineVariableBySessionIdSp(
				SessionID: SessionID,
				VariableName: "JITJobtranRowPointer",
				Infobar: null);
			
			#endregion ExecuteMethodCall
			
			return (Severity, Infobar);
			
		}
		
	}
}

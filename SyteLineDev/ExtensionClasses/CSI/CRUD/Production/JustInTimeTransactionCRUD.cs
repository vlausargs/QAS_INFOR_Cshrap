//PROJECT NAME: Production
//CLASS NAME: JustInTimeTransactionCRUD.cs

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

namespace CSI.Production
{
	public class JustInTimeTransactionCRUD : IJustInTimeTransactionCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		
		public JustInTimeTransactionCRUD(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('JustInTimeTransactionSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}
		
		public ICollectionLoadResponse Optional_Module1Select()
		{
			var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SpName","CAST (NULL AS NVARCHAR)"},
					{"u0","[om].[ModuleName]"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('JustInTimeTransactionSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(optional_module1LoadRequest);
		}
		
		public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
		{
			var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);
			
			this.appDB.Insert(optional_module1InsertRequest);
		}
		
		public bool Tv_ALTGENForExists()
		{
			return existsChecker.Exists(tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""));
		}
		
		public (string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
		{
			StringType _ALTGEN_SpName = DBNull.Value;
			
			var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ALTGEN_SpName,"[SpName]"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
			if(tv_ALTGEN1LoadResponse.Items.Count > 0)
			{
				ALTGEN_SpName = _ALTGEN_SpName;
			}
			
			int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
			return (ALTGEN_SpName, rowCount);
		}
		
		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
		{
			var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"[SpName]","[SpName]"},
				},
                loadForChange: true, 
                lockingType: LockingType.None,
                tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}",ALTGEN_SpName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}
		
		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}
		
		public (string, int? rowCount) ItemasparentLoad(string TItem, string ObsoleteItem, DateTime? TTransDate)
		{
			ItemType _ObsoleteItem = DBNull.Value;
			
			var itemASparentLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ObsoleteItem,"jobmatl.item"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"item AS parent",
				fromClause: collectionLoadRequestFactory.Clause(@" WITH (READUNCOMMITTED) INNER JOIN jobmatl ON jobmatl.job = parent.job
					AND jobmatl.suffix = parent.suffix
					AND (jobmatl.effect_date IS NULL
						OR jobmatl.effect_date <= {0})
					AND (jobmatl.obs_date IS NULL
						OR jobmatl.obs_date > {0}) INNER JOIN item AS child WITH (READUNCOMMITTED) ON child.item = jobmatl.item
					AND child.stat = 'O'",TTransDate),
				whereClause: collectionLoadRequestFactory.Clause("parent.item = {0}",TItem),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var itemASparentLoadResponse = this.appDB.Load(itemASparentLoadRequest);
			if(itemASparentLoadResponse.Items.Count > 0)
			{
				ObsoleteItem = _ObsoleteItem;
			}
			
			int rowCount = itemASparentLoadResponse.Items.Count;
			return (ObsoleteItem, rowCount);
		}
		
		public (int? WhsePhyInvFlg, string WhseWhse, int? PPostNeg, int? rowCount) WhseLoad(int? PPostNeg, int? WhsePhyInvFlg, string WhseWhse)
		{
			ListYesNoType _WhsePhyInvFlg = DBNull.Value;
			WhseType _WhseWhse = DBNull.Value;
			Flag _PPostNeg = DBNull.Value;
			
			var whseLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_WhsePhyInvFlg,"whse.phy_inv_flg"},
					{_WhseWhse,"whse.whse"},
					{_PPostNeg,"invparms.neg_flag"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"whse",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED) INNER JOIN invparms WITH (READUNCOMMITTED) ON whse.whse = invparms.def_whse"),
				whereClause: collectionLoadRequestFactory.Clause("invparms.parm_key = 0"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var whseLoadResponse = this.appDB.Load(whseLoadRequest);
			if(whseLoadResponse.Items.Count > 0)
			{
				WhsePhyInvFlg = _WhsePhyInvFlg;
				WhseWhse = _WhseWhse;
				PPostNeg = _PPostNeg;
			}
			
			int rowCount = whseLoadResponse.Items.Count;
			return (WhsePhyInvFlg, WhseWhse, PPostNeg, rowCount);
		}
		
		public (int? ItemSerialTracked, string ItemJob, int? ItemSuffix, int? rowCount) ItemLoad(string TItem, int? ItemSerialTracked, string ItemJob, int? ItemSuffix)
		{
			ListYesNoType _ItemSerialTracked = DBNull.Value;
			JobType _ItemJob = DBNull.Value;
			SuffixType _ItemSuffix = DBNull.Value;
			
			var itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ItemSerialTracked,"item.serial_tracked"},
					{_ItemJob,"item.job"},
					{_ItemSuffix,"item.suffix"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"item",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("item.item = {0}",TItem),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var itemLoadResponse = this.appDB.Load(itemLoadRequest);
			if(itemLoadResponse.Items.Count > 0)
			{
				ItemSerialTracked = _ItemSerialTracked;
				ItemJob = _ItemJob;
				ItemSuffix = _ItemSuffix;
			}
			
			int rowCount = itemLoadResponse.Items.Count;
			return (ItemSerialTracked, ItemJob, ItemSuffix, rowCount);
		}
		
		public (string, int? rowCount) JobLoad(string ItemJob, int? ItemSuffix, string JobJob)
		{
			JobType _JobJob = DBNull.Value;
			
			var jobLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_JobJob,"job.job"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"job",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (XLOCK, HOLDLOCK)"),
				whereClause: collectionLoadRequestFactory.Clause("job.job = {1} AND job.suffix = {0}",ItemSuffix,ItemJob),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var jobLoadResponse = this.appDB.Load(jobLoadRequest);
			if(jobLoadResponse.Items.Count > 0)
			{
				JobJob = _JobJob;
			}
			
			int rowCount = jobLoadResponse.Items.Count;
			return (JobJob, rowCount);
		}
		
		public (string JobrouteJob, int? JobrouteSuffix, int? JobrouteOperNum, string JobrouteWc, int? rowCount) JobrouteLoad(string ItemJob, int? ItemSuffix, string JobrouteJob, int? JobrouteSuffix, int? JobrouteOperNum, string JobrouteWc)
		{
			JobType _JobrouteJob = DBNull.Value;
			SuffixType _JobrouteSuffix = DBNull.Value;
			OperNumType _JobrouteOperNum = DBNull.Value;
			WcType _JobrouteWc = DBNull.Value;
			
			var jobrouteLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_JobrouteJob,"jobroute.job"},
					{_JobrouteSuffix,"jobroute.suffix"},
					{_JobrouteOperNum,"jobroute.oper_num"},
					{_JobrouteWc,"jobroute.wc"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName:"jobroute",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("jobroute.job = {1} AND jobroute.suffix = {0}",ItemSuffix,ItemJob),
				orderByClause: collectionLoadRequestFactory.Clause(" jobroute.oper_num DESC"));
			
			var jobrouteLoadResponse = this.appDB.Load(jobrouteLoadRequest);
			if(jobrouteLoadResponse.Items.Count > 0)
			{
				JobrouteJob = _JobrouteJob;
				JobrouteSuffix = _JobrouteSuffix;
				JobrouteOperNum = _JobrouteOperNum;
				JobrouteWc = _JobrouteWc;
			}
			
			int rowCount = jobrouteLoadResponse.Items.Count;
			return (JobrouteJob, JobrouteSuffix, JobrouteOperNum, JobrouteWc, rowCount);
		}
		
		public bool JobtranForExists(Guid? JobtranRowPointer)
		{
			return existsChecker.Exists(tableName:"jobtran",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("RowPointer = {0}",JobtranRowPointer));
		}
		
		public ICollectionLoadResponse NontableSelect(Guid? JobtranRowPointer, string JobtranTransType, string JobtranTransClass, DateTime? JobtranTransDate, decimal? JobtranQtyComplete, decimal? JobtranQtyScrapped, string JobtranEmpNum, decimal? JobtranQtyMoved, string JobtranShift, string JobtranWhse, string JobtranLoc, string JobtranUserCode, string JobtranLot, int? JobtranNextOper, int? JobtranPosted, int? JobtranAwaitingEop, string JobtranJob, int? JobtranSuffix, int? JobtranOperNum, string JobtranWc, string ContainerNum)
		{
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "RowPointer", JobtranRowPointer},
					{ "trans_type", JobtranTransType},
					{ "trans_class", JobtranTransClass},
					{ "trans_date", JobtranTransDate},
					{ "qty_complete", JobtranQtyComplete},
					{ "qty_scrapped", JobtranQtyScrapped},
					{ "emp_num", JobtranEmpNum},
					{ "qty_moved", JobtranQtyMoved},
					{ "shift", JobtranShift},
					{ "whse", JobtranWhse},
					{ "loc", JobtranLoc},
					{ "user_code", JobtranUserCode},
					{ "lot", JobtranLot},
					{ "next_oper", JobtranNextOper},
					{ "posted", JobtranPosted},
					{ "awaiting_eop", JobtranAwaitingEop},
					{ "job", JobtranJob},
					{ "suffix", JobtranSuffix},
					{ "oper_num", JobtranOperNum},
					{ "wc", JobtranWc},
					{ "import_doc_id", null},
					{ "container_num", ContainerNum},
			});
			
			return this.appDB.Load(nonTableLoadRequest);
		}
		public void NontableInsert(ICollectionLoadResponse nonTableLoadResponse)
		{
			var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "jobtran",
				items: nonTableLoadResponse.Items);
			
			this.appDB.Insert(nonTableInsertRequest);
		}
		
		public ICollectionLoadResponse Jobtran1Select(Guid? JobtranRowPointer)
		{
			var jobtran1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"trans_type","jobtran.trans_type"},
					{"trans_class","jobtran.trans_class"},
					{"trans_date","jobtran.trans_date"},
					{"qty_complete","jobtran.qty_complete"},
					{"qty_scrapped","jobtran.qty_scrapped"},
					{"emp_num","jobtran.emp_num"},
					{"qty_moved","jobtran.qty_moved"},
					{"shift","jobtran.shift"},
					{"whse","jobtran.whse"},
					{"loc","jobtran.loc"},
					{"user_code","jobtran.user_code"},
					{"lot","jobtran.lot"},
					{"next_oper","jobtran.next_oper"},
					{"posted","jobtran.posted"},
					{"awaiting_eop","jobtran.awaiting_eop"},
					{"job","jobtran.job"},
					{"suffix","jobtran.suffix"},
					{"oper_num","jobtran.oper_num"},
					{"wc","jobtran.wc"},
					{"import_doc_id","jobtran.import_doc_id"},
					{"container_num","jobtran.container_num"},
				},
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName:"jobtran",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("RowPointer = {0}",JobtranRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(jobtran1LoadRequest);
		}
		
		public void Jobtran1Update(string ContainerNum, string JobtranTransType, string JobtranTransClass, DateTime? JobtranTransDate, decimal? JobtranQtyComplete, decimal? JobtranQtyScrapped, string JobtranEmpNum, decimal? JobtranQtyMoved, string JobtranShift, string JobtranWhse, string JobtranLoc, string JobtranUserCode, string JobtranLot, int? JobtranNextOper, int? JobtranPosted, int? JobtranAwaitingEop, string JobtranJob, int? JobtranSuffix, int? JobtranOperNum, string JobtranWc, ICollectionLoadResponse jobtran1LoadResponse)
		{
			foreach(var jobtran1Item in jobtran1LoadResponse.Items){
				jobtran1Item.SetValue<string>("trans_type", JobtranTransType);
				jobtran1Item.SetValue<string>("trans_class", JobtranTransClass);
				jobtran1Item.SetValue<DateTime?>("trans_date", JobtranTransDate);
				jobtran1Item.SetValue<decimal?>("qty_complete", JobtranQtyComplete);
				jobtran1Item.SetValue<decimal?>("qty_scrapped", JobtranQtyScrapped);
				jobtran1Item.SetValue<string>("emp_num", JobtranEmpNum);
				jobtran1Item.SetValue<decimal?>("qty_moved", JobtranQtyMoved);
				jobtran1Item.SetValue<string>("shift", JobtranShift);
				jobtran1Item.SetValue<string>("whse", JobtranWhse);
				jobtran1Item.SetValue<string>("loc", JobtranLoc);
				jobtran1Item.SetValue<string>("user_code", JobtranUserCode);
				jobtran1Item.SetValue<string>("lot", JobtranLot);
				jobtran1Item.SetValue<int?>("next_oper", JobtranNextOper);
				jobtran1Item.SetValue<int?>("posted", JobtranPosted);
				jobtran1Item.SetValue<int?>("awaiting_eop", JobtranAwaitingEop);
				jobtran1Item.SetValue<string>("job", JobtranJob);
				jobtran1Item.SetValue<int?>("suffix", JobtranSuffix);
				jobtran1Item.SetValue<int?>("oper_num", JobtranOperNum);
				jobtran1Item.SetValue<string>("wc", JobtranWc);
				jobtran1Item.SetValue<string>("import_doc_id", null);
				jobtran1Item.SetValue<string>("container_num", ContainerNum);
			};
			
			var jobtran1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "jobtran",
				items: jobtran1LoadResponse.Items);
			
			this.appDB.Update(jobtran1RequestUpdate);
		}
		
		public (decimal?, int? rowCount) Jobtran2Load(Guid? JobtranRowPointer, decimal? TJobtranTransNum)
		{
			HugeTransNumType _TJobtranTransNum = DBNull.Value;
			
			var jobtran2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_TJobtranTransNum,"trans_num"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"jobtran",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("RowPointer = {0}",JobtranRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var jobtran2LoadResponse = this.appDB.Load(jobtran2LoadRequest);
			if(jobtran2LoadResponse.Items.Count > 0)
			{
				TJobtranTransNum = _TJobtranTransNum;
			}
			
			int rowCount = jobtran2LoadResponse.Items.Count;
			return (TJobtranTransNum, rowCount);
		}
		
		public ICollectionLoadResponse Tmp_SerSelect(int? Severity, Guid? SessionID, decimal? TJobtranTransNum, int? Coby, string Infobar)
		{
			var tmp_serLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"tmp_ser.SessionId","tmp_ser.SessionId"},
					{"tmp_ser.ref_str","tmp_ser.ref_str"},
				},
                loadForChange: true, 
                lockingType: LockingType.None,
                tableName:"tmp_ser",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("tmp_ser.SessionId = {0} AND tmp_ser.ref_str IS NULL",SessionID),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tmp_serLoadRequest);
		}
		
		public void Tmp_SerDelete(ICollectionLoadResponse tmp_serLoadResponse)
		{
			var tmp_serDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "tmp_ser",
				items: tmp_serLoadResponse.Items);
			this.appDB.Delete(tmp_serDeleteRequest);
		}
		
		public (int? ReturnCode,
			string Infobar)
		AltExtGen_JustInTimeTransactionSp(
			string AltExtGenSp,
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
			ItemType _TItem = TItem;
			QtyUnitType _TcQtuQty = TcQtuQty;
			WhseType _TWhse = TWhse;
			LocType _TLoc = TLoc;
			LotType _TLot = TLot;
			DateType _TTransDate = TTransDate;
			ShiftType _TShift = TShift;
			EmpNumType _TEmpNum = TEmpNum;
			Flag _PPostNeg = PPostNeg;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			ContainerNumType _ContainerNum = ContainerNum;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcQtuQty", _TcQtuQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TWhse", _TWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLoc", _TLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TShift", _TShift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostNeg", _PPostNeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
		
	}
}

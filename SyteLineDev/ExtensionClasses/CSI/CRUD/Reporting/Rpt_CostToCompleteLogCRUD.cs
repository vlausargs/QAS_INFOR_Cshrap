//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CostToCompleteLogCRUD.cs

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

namespace CSI.Reporting
{
	public class Rpt_CostToCompleteLogCRUD : IRpt_CostToCompleteLogCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		
		public Rpt_CostToCompleteLogCRUD(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_CostToCompleteLogSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_CostToCompleteLogSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
			
			foreach(var optional_module1Item in optional_module1LoadResponse.Items){
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_CostToCompleteLogSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
			};
			
			return optional_module1LoadResponse;
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
		
		public (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
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
		
		public ICollectionLoadResponse Tv_Rpt_SetSelect()
		{
			var tv_rpt_setLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"proj_num","proj_num"},
				},
				loadForChange: true,
				lockingType: LockingType.None,
				tableName:"#tv_rpt_set",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_rpt_setLoadRequest);
		}
		
		public void Tv_Rpt_SetDelete(ICollectionLoadResponse tv_rpt_setLoadResponse)
		{
			var tv_rpt_setDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_rpt_set",
				items: tv_rpt_setLoadResponse.Items);
			this.appDB.Delete(tv_rpt_setDeleteRequest);
		}
		
		public ICollectionLoadResponse ProjSelect(string ProjectStarting, string ProjectEnding, int? TaskStarting, int? TaskEnding, string CostCodeStarting, string CostCodeEnding, string ProjectStatus, DateTime? Date)
		{
			var log_curLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"proj.proj_num","proj.proj_num"},
					{"proj.proj_desc","proj.proj_desc"},
					{"proj.stat","proj.stat"},
					{"proj.cust_num","proj.cust_num"},
					{"proj.cust_seq","proj.cust_seq"},
					{"custaddr.name","custaddr.name"},
					{"proj.contract","proj.contract"},
					{"projtask.task_num","projtask.task_num"},
					{"projtask.task_desc","projtask.task_desc"},
					{"costcode.cost_class","costcode.cost_class"},
					{"costcode.cost_code","costcode.cost_code"},
					{"costcode.cost_desc","costcode.cost_desc"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"proj",
				fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN custaddr ON custaddr.cust_num = proj.cust_num
					AND custaddr.cust_seq = proj.cust_seq INNER JOIN projtask ON projtask.proj_num = proj.proj_num INNER JOIN projcost ON projcost.proj_num = projtask.proj_num
					AND projcost.task_num = projtask.task_num
					AND projcost.seq = 0
					AND projcost.type = 'T'
					AND projcost.cost_code_type = 'P' INNER JOIN costcode ON costcode.cost_code = projcost.cost_code"),
				whereClause: collectionLoadRequestFactory.Clause("CHARINDEX(proj.stat, {3}) > 0 AND (proj.proj_num BETWEEN {1} AND {4}) AND (projtask.task_num BETWEEN {5} AND {6}) AND (costcode.cost_code BETWEEN {0} AND {2}) AND EXISTS (SELECT 1 FROM ctc_log WHERE ctc_log.snap_util_created = 1 AND ctc_log.proj_num = proj.proj_num AND ctc_log.trans_date <= {7})",CostCodeStarting,ProjectStarting,CostCodeEnding,ProjectStatus,ProjectEnding,TaskStarting,TaskEnding,Date),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var log_curLoadResponseForCursor = this.appDB.Load(log_curLoadRequestForCursor);
			return log_curLoadResponseForCursor;
		}
		public (decimal? a_units,
			decimal? a_cost,
			decimal? units,
			decimal? fcst_cost,
			decimal? plan_units,
			decimal? plan_cost,
			DateTime? snap_date, int? rowCount)
		Ctc_LogLoad(DateTime? Date,
			string proj_num,
			int? task_num,
			string cost_code,
			DateTime? snap_date,
			decimal? a_units,
			decimal? a_cost,
			decimal? units,
			decimal? plan_units,
			decimal? fcst_cost,
			decimal? plan_cost)
		{
			ProjUnitsType _a_units = DBNull.Value;
			AmtTotType _a_cost = DBNull.Value;
			ProjUnitsType _units = DBNull.Value;
			AmtTotType _fcst_cost = DBNull.Value;
			ProjUnitsType _plan_units = DBNull.Value;
			AmtTotType _plan_cost = DBNull.Value;
			DateType _snap_date = DBNull.Value;
			
			var ctc_logLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_a_units,"a_units"},
					{_a_cost,"a_cost"},
					{_units,"units"},
					{_fcst_cost,"fcst_cost"},
					{_plan_units,"plan_units"},
					{_plan_cost,"plan_cost"},
					{_snap_date,"trans_date"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"ctc_log",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("ctc_log.proj_num = {1} AND ctc_log.task_num = {2} AND ctc_log.cost_code = {0} AND ctc_log.trans_date = (SELECT TOP 1 trans_date FROM ctc_log WHERE ctc_log.snap_util_created = 1 AND ctc_log.proj_num = {1} AND ctc_log.trans_date <= {3} ORDER BY proj_num DESC, task_num DESC, cost_code DESC, seq DESC) AND ctc_log.snap_util_created = 1",cost_code,proj_num,task_num,Date),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var ctc_logLoadResponse = this.appDB.Load(ctc_logLoadRequest);
			if(ctc_logLoadResponse.Items.Count > 0)
			{
				a_units = _a_units;
				a_cost = _a_cost;
				units = _units;
				fcst_cost = _fcst_cost;
				plan_units = _plan_units;
				plan_cost = _plan_cost;
				snap_date = _snap_date;
			}
			
			int rowCount = ctc_logLoadResponse.Items.Count;
			return (a_units, a_cost, units, fcst_cost, plan_units, plan_cost, snap_date, rowCount);
		}
		
		public ICollectionLoadResponse NontableSelect(string proj_num, string proj_desc, string stat, string cust_num, int? cust_seq, string name, string contract, DateTime? snap_date, int? task_num, string task_desc, string cost_class, string cost_code, string cost_desc, decimal? a_units, decimal? a_cost, decimal? units, decimal? plan_units, decimal? fcst_cost, decimal? plan_cost, decimal? cost_to_complete, decimal? cost_to_complete_units)
		{
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "proj_num", proj_num},
					{ "proj_desc", proj_desc},
					{ "stat", stat},
					{ "cust_num", cust_num},
					{ "cust_seq", cust_seq},
					{ "name", name},
					{ "contract", contract},
					{ "snap_date", snap_date},
					{ "task_num", task_num},
					{ "task_desc", task_desc},
					{ "cost_class", cost_class},
					{ "cost_code", cost_code},
					{ "cost_desc", cost_desc},
					{ "a_units", stringUtil.IsNull<decimal?>(
						a_units,
						0)},
					{ "a_cost", stringUtil.IsNull<decimal?>(
						a_cost,
						0)},
					{ "units", stringUtil.IsNull<decimal?>(
						units,
						0)},
					{ "plan_units", stringUtil.IsNull<decimal?>(
						plan_units,
						0)},
					{ "fcst_cost", stringUtil.IsNull<decimal?>(
						fcst_cost,
						0)},
					{ "plan_cost", stringUtil.IsNull<decimal?>(
						plan_cost,
						0)},
					{ "cost_to_complete", stringUtil.IsNull<decimal?>(
						cost_to_complete,
						0)},
					{ "cost_to_complete_units", stringUtil.IsNull<decimal?>(
						cost_to_complete_units,
						0)},
			});
			
			return this.appDB.Load(nonTableLoadRequest);
		}
		public void NontableInsert(ICollectionLoadResponse nonTableLoadResponse)
		{
			var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_rpt_set",
				items: nonTableLoadResponse.Items);
			
			this.appDB.Insert(nonTableInsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Rpt_Set1Select()
		{
			var tv_rpt_set1LoadRequest = collectionLoadRequestFactory.SQLLoad(columns: new List<string>()
				{
					"proj_num",
					"proj_desc",
					"stat",
					"cust_num",
					"cust_seq",
					"name",
					"contract",
					"snap_date",
					"task_num",
					"task_desc",
					"cost_class",
					"cost_code",
					"cost_desc",
					"a_units",
					"a_cost",
					"units",
					"plan_units",
					"fcst_cost",
					"plan_cost",
					"cost_to_complete",
					"cost_to_complete_units",
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "#tv_rpt_set",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" proj_num, task_num, cost_class, cost_code"));
			
			return this.appDB.Load(tv_rpt_set1LoadRequest);
			
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Rpt_CostToCompleteLogSp(
			string AltExtGenSp,
			string ProjectStarting = null,
			string ProjectEnding = null,
			int? TaskStarting = null,
			int? TaskEnding = null,
			string CostCodeStarting = null,
			string CostCodeEnding = null,
			string ProjectStatus = null,
			DateTime? Date = null,
			int? DateOffset = null,
			int? Printcost = 0,
			int? DisplayHeader = 1,
			string pSite = null)
		{
			ProjNumType _ProjectStarting = ProjectStarting;
			ProjNumType _ProjectEnding = ProjectEnding;
			TaskNumType _TaskStarting = TaskStarting;
			TaskNumType _TaskEnding = TaskEnding;
			CostCodeType _CostCodeStarting = CostCodeStarting;
			CostCodeType _CostCodeEnding = CostCodeEnding;
			InfobarType _ProjectStatus = ProjectStatus;
			DateType _Date = Date;
			DateOffsetType _DateOffset = DateOffset;
			ListYesNoType _Printcost = Printcost;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "ProjectStarting", _ProjectStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectEnding", _ProjectEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskStarting", _TaskStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskEnding", _TaskEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCodeStarting", _CostCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCodeEnding", _CostCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectStatus", _ProjectStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateOffset", _DateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Printcost", _Printcost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
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

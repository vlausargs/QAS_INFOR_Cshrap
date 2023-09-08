//PROJECT NAME: Logistics
//CLASS NAME: Home_GetProductionPlannerParmsCRUD.cs

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
	public class Home_GetProductionPlannerParmsCRUD : IHome_GetProductionPlannerParmsCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;

        public Home_GetProductionPlannerParmsCRUD(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IStringUtil stringUtil,
            ICollectionLoadResponseUtil collectionLoadResponseUtil
            )
        {
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
            this.stringUtil = stringUtil;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
        }

        public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_GetProductionPlannerParmsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_GetProductionPlannerParmsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_moduleLoadResponse= this.appDB.Load(optional_module1LoadRequest);
            foreach (var optional_module1Item in optional_moduleLoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_GetProductionPlannerParmsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
            };

            var optional_module1RequiredColumns = new List<string>() { "SpName" };

            return collectionLoadResponseUtil.ExtractRequiredColumns(optional_moduleLoadResponse, optional_module1RequiredColumns);
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
		
		public (int? ReturnCode,
			int? pFiscalYear,
			string InvSiteGrp,
			string ApsParmApsmode,
			int? CanAdd,
			int? CanUpdate,
			int? CanDelete,
			string PlanMode,
			string Parm_DefWhse,
			int? UnpostedDCSFC,
			int? UnpostedDCJM,
			int? UnpostedDCJMRcpt,
			int? UnpostedJobLaborTrans,
			int? UnpostedDCJIT,
			int? UnpostedDCPS,
			int? UnpostedDCPSScrap,
			int? UnpostedJobMatlTrans,
			int? UnpostedDCSFCWCLabor,
			int? UnpostedDCSFCWCMachine,
			int? UnpostedDCWC,
			int? pCurPeriod,
			DateTime? rPer1Start,
			DateTime? rPer2Start,
			DateTime? rPer3Start,
			DateTime? rPer4Start,
			DateTime? rPer5Start,
			DateTime? rPer6Start,
			DateTime? rPer7Start,
			DateTime? rPer8Start,
			DateTime? rPer9Start,
			DateTime? rPer10Start,
			DateTime? rPer11Start,
			DateTime? rPer12Start,
			DateTime? rPer13Start,
			DateTime? rPer1End,
			DateTime? rPer2End,
			DateTime? rPer3End,
			DateTime? rPer4End,
			DateTime? rPer5End,
			DateTime? rPer6End,
			DateTime? rPer7End,
			DateTime? rPer8End,
			DateTime? rPer9End,
			DateTime? rPer10End,
			DateTime? rPer11End,
			DateTime? rPer12End,
			DateTime? rPer13End,
			int? CompleteQty,
			int? PastDueQty,
			string Infobar)
		AltExtGen_Home_GetProductionPlannerParmsSp(
			string AltExtGenSp,
			decimal? Userid,
			int? pFiscalYear,
			string InvSiteGrp,
			string ApsParmApsmode,
			int? CanAdd,
			int? CanUpdate,
			int? CanDelete,
			string PlanMode,
			string Parm_DefWhse,
			int? UnpostedDCSFC,
			int? UnpostedDCJM,
			int? UnpostedDCJMRcpt,
			int? UnpostedJobLaborTrans,
			int? UnpostedDCJIT,
			int? UnpostedDCPS,
			int? UnpostedDCPSScrap,
			int? UnpostedJobMatlTrans,
			int? UnpostedDCSFCWCLabor,
			int? UnpostedDCSFCWCMachine,
			int? UnpostedDCWC,
			int? pCurPeriod,
			DateTime? rPer1Start,
			DateTime? rPer2Start,
			DateTime? rPer3Start,
			DateTime? rPer4Start,
			DateTime? rPer5Start,
			DateTime? rPer6Start,
			DateTime? rPer7Start,
			DateTime? rPer8Start,
			DateTime? rPer9Start,
			DateTime? rPer10Start,
			DateTime? rPer11Start,
			DateTime? rPer12Start,
			DateTime? rPer13Start,
			DateTime? rPer1End,
			DateTime? rPer2End,
			DateTime? rPer3End,
			DateTime? rPer4End,
			DateTime? rPer5End,
			DateTime? rPer6End,
			DateTime? rPer7End,
			DateTime? rPer8End,
			DateTime? rPer9End,
			DateTime? rPer10End,
			DateTime? rPer11End,
			DateTime? rPer12End,
			DateTime? rPer13End,
			int? CompleteQty,
			int? PastDueQty,
			string Infobar)
		{
			TokenType _Userid = Userid;
			FiscalYearType _pFiscalYear = pFiscalYear;
			SiteGroupType _InvSiteGrp = InvSiteGrp;
			ApsModeType _ApsParmApsmode = ApsParmApsmode;
			ListYesNoType _CanAdd = CanAdd;
			ListYesNoType _CanUpdate = CanUpdate;
			ListYesNoType _CanDelete = CanDelete;
			StringType _PlanMode = PlanMode;
			WhseType _Parm_DefWhse = Parm_DefWhse;
			IntType _UnpostedDCSFC = UnpostedDCSFC;
			IntType _UnpostedDCJM = UnpostedDCJM;
			IntType _UnpostedDCJMRcpt = UnpostedDCJMRcpt;
			IntType _UnpostedJobLaborTrans = UnpostedJobLaborTrans;
			IntType _UnpostedDCJIT = UnpostedDCJIT;
			IntType _UnpostedDCPS = UnpostedDCPS;
			IntType _UnpostedDCPSScrap = UnpostedDCPSScrap;
			IntType _UnpostedJobMatlTrans = UnpostedJobMatlTrans;
			IntType _UnpostedDCSFCWCLabor = UnpostedDCSFCWCLabor;
			IntType _UnpostedDCSFCWCMachine = UnpostedDCSFCWCMachine;
			IntType _UnpostedDCWC = UnpostedDCWC;
			FinPeriodType _pCurPeriod = pCurPeriod;
			DateType _rPer1Start = rPer1Start;
			DateType _rPer2Start = rPer2Start;
			DateType _rPer3Start = rPer3Start;
			DateType _rPer4Start = rPer4Start;
			DateType _rPer5Start = rPer5Start;
			DateType _rPer6Start = rPer6Start;
			DateType _rPer7Start = rPer7Start;
			DateType _rPer8Start = rPer8Start;
			DateType _rPer9Start = rPer9Start;
			DateType _rPer10Start = rPer10Start;
			DateType _rPer11Start = rPer11Start;
			DateType _rPer12Start = rPer12Start;
			DateType _rPer13Start = rPer13Start;
			DateType _rPer1End = rPer1End;
			DateType _rPer2End = rPer2End;
			DateType _rPer3End = rPer3End;
			DateType _rPer4End = rPer4End;
			DateType _rPer5End = rPer5End;
			DateType _rPer6End = rPer6End;
			DateType _rPer7End = rPer7End;
			DateType _rPer8End = rPer8End;
			DateType _rPer9End = rPer9End;
			DateType _rPer10End = rPer10End;
			DateType _rPer11End = rPer11End;
			DateType _rPer12End = rPer12End;
			DateType _rPer13End = rPer13End;
			IntType _CompleteQty = CompleteQty;
			IntType _PastDueQty = PastDueQty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "Userid", _Userid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFiscalYear", _pFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvSiteGrp", _InvSiteGrp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ApsParmApsmode", _ApsParmApsmode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAdd", _CanAdd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanUpdate", _CanUpdate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanDelete", _CanDelete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlanMode", _PlanMode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Parm_DefWhse", _Parm_DefWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCSFC", _UnpostedDCSFC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCJM", _UnpostedDCJM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCJMRcpt", _UnpostedDCJMRcpt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedJobLaborTrans", _UnpostedJobLaborTrans, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCJIT", _UnpostedDCJIT, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCPS", _UnpostedDCPS, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCPSScrap", _UnpostedDCPSScrap, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedJobMatlTrans", _UnpostedJobMatlTrans, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCSFCWCLabor", _UnpostedDCSFCWCLabor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCSFCWCMachine", _UnpostedDCSFCWCMachine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnpostedDCWC", _UnpostedDCWC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCurPeriod", _pCurPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer1Start", _rPer1Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer2Start", _rPer2Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer3Start", _rPer3Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer4Start", _rPer4Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer5Start", _rPer5Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer6Start", _rPer6Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer7Start", _rPer7Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer8Start", _rPer8Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer9Start", _rPer9Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer10Start", _rPer10Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer11Start", _rPer11Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer12Start", _rPer12Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer13Start", _rPer13Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer1End", _rPer1End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer2End", _rPer2End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer3End", _rPer3End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer4End", _rPer4End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer5End", _rPer5End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer6End", _rPer6End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer7End", _rPer7End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer8End", _rPer8End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer9End", _rPer9End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer10End", _rPer10End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer11End", _rPer11End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer12End", _rPer12End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer13End", _rPer13End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CompleteQty", _CompleteQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueQty", _PastDueQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pFiscalYear = _pFiscalYear;
				InvSiteGrp = _InvSiteGrp;
				ApsParmApsmode = _ApsParmApsmode;
				CanAdd = _CanAdd;
				CanUpdate = _CanUpdate;
				CanDelete = _CanDelete;
				PlanMode = _PlanMode;
				Parm_DefWhse = _Parm_DefWhse;
				UnpostedDCSFC = _UnpostedDCSFC;
				UnpostedDCJM = _UnpostedDCJM;
				UnpostedDCJMRcpt = _UnpostedDCJMRcpt;
				UnpostedJobLaborTrans = _UnpostedJobLaborTrans;
				UnpostedDCJIT = _UnpostedDCJIT;
				UnpostedDCPS = _UnpostedDCPS;
				UnpostedDCPSScrap = _UnpostedDCPSScrap;
				UnpostedJobMatlTrans = _UnpostedJobMatlTrans;
				UnpostedDCSFCWCLabor = _UnpostedDCSFCWCLabor;
				UnpostedDCSFCWCMachine = _UnpostedDCSFCWCMachine;
				UnpostedDCWC = _UnpostedDCWC;
				pCurPeriod = _pCurPeriod;
				rPer1Start = _rPer1Start;
				rPer2Start = _rPer2Start;
				rPer3Start = _rPer3Start;
				rPer4Start = _rPer4Start;
				rPer5Start = _rPer5Start;
				rPer6Start = _rPer6Start;
				rPer7Start = _rPer7Start;
				rPer8Start = _rPer8Start;
				rPer9Start = _rPer9Start;
				rPer10Start = _rPer10Start;
				rPer11Start = _rPer11Start;
				rPer12Start = _rPer12Start;
				rPer13Start = _rPer13Start;
				rPer1End = _rPer1End;
				rPer2End = _rPer2End;
				rPer3End = _rPer3End;
				rPer4End = _rPer4End;
				rPer5End = _rPer5End;
				rPer6End = _rPer6End;
				rPer7End = _rPer7End;
				rPer8End = _rPer8End;
				rPer9End = _rPer9End;
				rPer10End = _rPer10End;
				rPer11End = _rPer11End;
				rPer12End = _rPer12End;
				rPer13End = _rPer13End;
				CompleteQty = _CompleteQty;
				PastDueQty = _PastDueQty;
				Infobar = _Infobar;
				
				return (Severity, pFiscalYear, InvSiteGrp, ApsParmApsmode, CanAdd, CanUpdate, CanDelete, PlanMode, Parm_DefWhse, UnpostedDCSFC, UnpostedDCJM, UnpostedDCJMRcpt, UnpostedJobLaborTrans, UnpostedDCJIT, UnpostedDCPS, UnpostedDCPSScrap, UnpostedJobMatlTrans, UnpostedDCSFCWCLabor, UnpostedDCSFCWCMachine, UnpostedDCWC, pCurPeriod, rPer1Start, rPer2Start, rPer3Start, rPer4Start, rPer5Start, rPer6Start, rPer7Start, rPer8Start, rPer9Start, rPer10Start, rPer11Start, rPer12Start, rPer13Start, rPer1End, rPer2End, rPer3End, rPer4End, rPer5End, rPer6End, rPer7End, rPer8End, rPer9End, rPer10End, rPer11End, rPer12End, rPer13End, CompleteQty, PastDueQty, Infobar);
			}
		}
		
	}
}

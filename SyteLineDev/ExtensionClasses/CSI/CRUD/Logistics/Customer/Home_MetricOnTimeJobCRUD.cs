//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricOnTimeJobCRUD.cs

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

namespace CSI.Logistics.Customer
{
	public class Home_MetricOnTimeJobCRUD : IHome_MetricOnTimeJobCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IDateTimeUtil dateTimeUtil;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;


        public Home_MetricOnTimeJobCRUD(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			ISQLValueComparerUtil sQLUtil,
            IDateTimeUtil dateTimeUtil,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            IStringUtil stringUtil,
            ISQLExpressionExecutor sQLExpressionExecutor)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.sQLUtil = sQLUtil;
			this.dateTimeUtil = dateTimeUtil;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.stringUtil = stringUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_MetricOnTimeJobSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}
		
		
		public void Optional_Module1Insert()
		{
            var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SpName","CAST (NULL AS NVARCHAR)"},
                    {"u0","[om].[ModuleName]"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_MetricOnTimeJobSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_MetricOnTimeJobSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
            };

            var optional_module1RequiredColumns = new List<string>() { "SpName" };
            optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

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
		
		public void Tv_ALTGEN2Delete(string ALTGEN_SpName)
		{
            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");

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

            var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);

            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

        }
		
		public (string Site, int? rowCount) ParmsLoad(string Site)
		{
			SiteType _Site = DBNull.Value;
			
			var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_Site,"site"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"parms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
			if(parmsLoadResponse.Items.Count > 0)
			{
				Site = _Site;
			}
			
			int rowCount = parmsLoadResponse.Items.Count;
			return (Site, rowCount);
		}
		
		public (decimal? PeriodTotal, int? rowCount) JobLoad(DateTime? PeriodStart, DateTime? PeriodEnd, decimal? PeriodTotal)
		{
			AmtTotType _PeriodTotal = DBNull.Value;
			
			var jobLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PeriodTotal,"count(job)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"job",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job.type = 'J' AND midnight_of_job_sch_end_date BETWEEN {0} AND {1}",PeriodStart,PeriodEnd),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var jobLoadResponse = this.appDB.Load(jobLoadRequest);
			if(jobLoadResponse.Items.Count > 0)
			{
				PeriodTotal = _PeriodTotal;
			}
			
			int rowCount = jobLoadResponse.Items.Count;
			return (PeriodTotal, rowCount);
		}
		
		public (decimal? PeriodOnTime, int? rowCount) Job2Load(DateTime? PeriodStart, DateTime? PeriodEnd, decimal? PeriodOnTime)
		{
			AmtTotType _PeriodOnTime = DBNull.Value;
			
			var job11LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PeriodOnTime,"count(job)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"job",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job.type = 'J' AND midnight_of_job_sch_end_date BETWEEN {0} AND {1} AND (midnight_of_job_sch_end_date >= dbo.MidnightOf(job.lst_trx_date) AND qty_complete >= qty_released)",PeriodStart,PeriodEnd),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var job11LoadResponse = this.appDB.Load(job11LoadRequest);
			if(job11LoadResponse.Items.Count > 0)
			{
				PeriodOnTime = _PeriodOnTime;
			}
			
			int rowCount = job11LoadResponse.Items.Count;
			return (PeriodOnTime, rowCount);
		}

		public void NontableInsert(decimal? PeriodOnTime, decimal? PeriodTotal, DateTime? PeriodEnd)
		{
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "on_time", PeriodOnTime * 100.0M / (sQLUtil.SQLEqual(PeriodTotal, 0) == true ? 1 : PeriodTotal)},
                    { "period_end", dateTimeUtil.ConvertToString(PeriodEnd, "MM-dd-yyyy")},
                    { "period_end_date", PeriodEnd},
            });

            var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);

            var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_results",
				items: nonTableLoadResponse.Items);
			
			this.appDB.Insert(nonTableInsertRequest);
		}
				
		public ICollectionLoadResponse Tv_ResultsSelect()
		{
			var tv_resultsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"on_time","on_time"},
					{"period_end","period_end"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName:"#tv_results",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" period_end_date"));
			return this.appDB.Load(tv_resultsLoadRequest);
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Home_MetricOnTimeJobSp(
			string AltExtGenSp,
			int? Count = 4)
		{
			IntType _Count = Count;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "Count", _Count, ParameterDirection.Input);
				
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

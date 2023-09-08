//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricJobWIPCRUD.cs

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
using CSI.Production;

namespace CSI.Logistics.Customer
{
	public class Home_MetricJobWIPCRUD : IHome_MetricJobWIPCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		readonly IFmtJob iFmtJob;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;

        public Home_MetricJobWIPCRUD(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IStringUtil stringUtil,
			IFmtJob iFmtJob,
			ISQLExpressionExecutor sQLExpressionExecutor,
            ICollectionLoadResponseUtil collectionLoadResponseUtil
            )
        {
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
			this.iFmtJob = iFmtJob;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
        }

        public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_MetricJobWIPSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}

        public void DeclareAltgen()
        {

            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_MetricJobWIPSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
			
			foreach(var optional_module1Item in optional_module1LoadResponse.Items){
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_MetricJobWIPSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
			};
			
			return optional_module1LoadResponse;
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_MetricJobWIPSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_MetricJobWIPSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

        public ICollectionLoadResponse JobSelect(int? Count)
		{
			var jobLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Job_Suffix","CAST (NULL AS NVARCHAR)"},
					{"wip_total","job.wip_total"},
					{"u0","job.job"},
					{"u1","job.suffix"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: Count,
				tableName:"job",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job.type = 'J' AND stat IN ('R', 'S')"),
				orderByClause: collectionLoadRequestFactory.Clause(" wip_total DESC"));
			
			var jobLoadResponse = this.appDB.Load(jobLoadRequest);
			
			foreach(var jobItem in jobLoadResponse.Items){
				jobItem.SetValue<string>("Job_Suffix", this.iFmtJob.FmtJobSp(
					jobItem.GetValue<string>("u0"),
					jobItem.GetValue<int?>("u1")));
				jobItem.SetValue<decimal?>("wip_total", jobItem.GetValue<decimal?>("wip_total"));
			};
			
			return jobLoadResponse;
		}
		
		public ICollectionLoadResponse Job1Select()
		{
			var job1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Job_Suffix","CAST (NULL AS NVARCHAR)"},
					{"wip_total","job.wip_total"},
					{"u0","job.job"},
					{"u1","job.suffix"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"job",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job.type = 'J' AND stat IN ('R', 'S')"),
				orderByClause: collectionLoadRequestFactory.Clause(" wip_total DESC"));
			
			var job1LoadResponse = this.appDB.Load(job1LoadRequest);
			
			foreach(var job1Item in job1LoadResponse.Items){
				job1Item.SetValue<string>("Job_Suffix", this.iFmtJob.FmtJobSp(
					job1Item.GetValue<string>("u0"),
					job1Item.GetValue<int?>("u1")));
				job1Item.SetValue<decimal?>("wip_total", job1Item.GetValue<decimal?>("wip_total"));
			};
			
			return job1LoadResponse;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Home_MetricJobWIPSp(
			string AltExtGenSp,
			int? Count = 5)
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

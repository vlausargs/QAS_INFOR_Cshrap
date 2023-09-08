//PROJECT NAME: Production
//CLASS NAME: Home_GetTodaysKeyProjectValuesCRUD.cs

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

namespace CSI.Production.Projects
{
	public class Home_GetTodaysKeyProjectValuesCRUD : IHome_GetTodaysKeyProjectValuesCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;

        public Home_GetTodaysKeyProjectValuesCRUD(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IStringUtil stringUtil,
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
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
        }

        public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_GetTodaysKeyProjectValuesSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}

        public void DeclareAltgen()
        {
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_GetTodaysKeyProjectValuesSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_GetTodaysKeyProjectValuesSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
		
		public (decimal? InvoiceAmountTot, int? rowCount) Inv_MsLoad(DateTime? Today, decimal? InvoiceAmountTot)
		{
			AmtTotType _InvoiceAmountTot = DBNull.Value;
			
			var inv_msLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_InvoiceAmountTot,"COALESCE (SUM(plan_inv_amt), 0.0)"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"inv_ms",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN proj ON proj.proj_num = inv_ms.proj_num
					AND proj.type = 'P'"),
				whereClause: collectionLoadRequestFactory.Clause("inv_ms.plan_date < {0} AND inv_ms.posted = 0",Today),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var inv_msLoadResponse = this.appDB.Load(inv_msLoadRequest);
			if(inv_msLoadResponse.Items.Count > 0)
			{
				InvoiceAmountTot = _InvoiceAmountTot;
			}
			
			int rowCount = inv_msLoadResponse.Items.Count;
			return (InvoiceAmountTot, rowCount);
		}
		
		public (decimal? RevenueAmountTot, int? rowCount) Rev_MsLoad(DateTime? Today, decimal? RevenueAmountTot)
		{
			AmtTotType _RevenueAmountTot = DBNull.Value;
			
			var rev_msLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_RevenueAmountTot,"COALESCE (SUM(plan_rev), 0.0)"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"rev_ms",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN proj ON proj.proj_num = rev_ms.proj_num
					AND proj.type = 'P'"),
				whereClause: collectionLoadRequestFactory.Clause("rev_ms.plan_date < {0} AND rev_ms.posted = 0",Today),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var rev_msLoadResponse = this.appDB.Load(rev_msLoadRequest);
			if(rev_msLoadResponse.Items.Count > 0)
			{
				RevenueAmountTot = _RevenueAmountTot;
			}
			
			int rowCount = rev_msLoadResponse.Items.Count;
			return (RevenueAmountTot, rowCount);
		}
		
		public (int? ReturnCode,
			decimal? InvoiceAmountTot,
			decimal? RevenueAmountTot)
		AltExtGen_Home_GetTodaysKeyProjectValuesSp(
			string AltExtGenSp,
			decimal? InvoiceAmountTot,
			decimal? RevenueAmountTot)
		{
			AmtTotType _InvoiceAmountTot = InvoiceAmountTot;
			AmtTotType _RevenueAmountTot = RevenueAmountTot;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "InvoiceAmountTot", _InvoiceAmountTot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevenueAmountTot", _RevenueAmountTot, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InvoiceAmountTot = _InvoiceAmountTot;
				RevenueAmountTot = _RevenueAmountTot;
				
				return (Severity, InvoiceAmountTot, RevenueAmountTot);
			}
		}
		
	}
}

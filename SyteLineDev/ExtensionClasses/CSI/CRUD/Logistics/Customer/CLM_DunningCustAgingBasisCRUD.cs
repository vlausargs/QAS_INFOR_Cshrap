//PROJECT NAME: Logistics
//CLASS NAME: CLM_DunningCustAgingBasisCRUD.cs

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
    public class CLM_DunningCustAgingBasisCRUD : ICLM_DunningCustAgingBasisCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;

        public CLM_DunningCustAgingBasisCRUD(IApplicationDB appDB,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IExistsChecker existsChecker,
            IStringUtil stringUtil)
        {
            this.appDB = appDB;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.existsChecker = existsChecker;
            this.stringUtil = stringUtil;
        }

        public bool Optional_ModuleForExists()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_DunningCustAgingBasisSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_DunningCustAgingBasisSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_DunningCustAgingBasisSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
            return existsChecker.Exists(tableName: "#tv_ALTGEN",
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
                tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
            if (tv_ALTGEN1LoadResponse.Items.Count > 0)
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
                tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(tv_ALTGEN2LoadRequest);
        }

        public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
        {
            var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                items: tv_ALTGEN2LoadResponse.Items);
            this.appDB.Delete(tv_ALTGEN2DeleteRequest);
        }

        public ICollectionLoadResponse _1Select(string CustNum, string SiteRef)
        {
            var _1LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"t.CustNum","t.CustNum"},
                    {"AgingDays","ISNULL(CONVERT (VARCHAR (50), t1.AgingDays), t.Balance)"},
                    {"AgingTitle","ISNULL(t2.AgingTitle, t.Total)"},
                    {"t.AgingAmount","t.AgingAmount"},
                    {"t.SiteRef","t.SiteRef"},
                },
                selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList
					FROM (SELECT Subordinate,
						SiteRef,
						CustNum,
						RIGHT(AgeAmount, 1) AS [Order],
						AgeAmount,
						AgingAmount,
						'Balance' AS Balance,
						'Total' AS Total
						FROM   (SELECT   Subordinate,
							site_ref AS SiteRef,
							cust_num AS CustNum,
							SUM(AgeBal1) AS AgeBal1,
							SUM(AgeBal2) AS AgeBal2,
							SUM(AgeBal3) AS AgeBal3,
							SUM(AgeBal4) AS AgeBal4,
							SUM(AgeBal5) AS AgeBal5,
							SUM(AgeBal6) AS AgeBal6
							FROM     ARAgingDoView
							WHERE    Subordinate = 0
							AND site_ref = {0}
							AND cust_num = {1}
							AND active = 1
							GROUP BY Subordinate, site_ref, cust_num) AS p UNPIVOT (AgingAmount FOR AgeAmount IN (AgeBal1, AgeBal2, AgeBal3, AgeBal4, AgeBal5, AgeBal6)) AS unpvt) AS t
					LEFT OUTER JOIN
					(SELECT SiteRef,
						ParmsKey,
						RIGHT(AgeDays, 1) AS [Order],
						AgeDays,
						AgingDays
						FROM   (SELECT site_ref AS SiteRef,
							arparms_key AS ParmsKey,
							age_days##1,
							age_days##2,
							age_days##3,
							age_days##4,
							age_days##5
							FROM   arparms_all
							WHERE  site_ref = {0}
							AND arparms_key = 0) AS P UNPIVOT (AgingDays FOR AgeDays IN (age_days##1, age_days##2, age_days##3, age_days##4, age_days##5)) AS unpvt1) AS t1
					ON t.SiteRef = t1.SiteRef
					AND t.[Order] = t1.[Order]
					LEFT OUTER JOIN
					(SELECT SiteRef,
						ParmsKey,
						RIGHT(AgeDays, 1) AS [Order],
						AgeDays,
						AgingTitle
						FROM   (SELECT site_ref AS SiteRef,
							arparms_key AS ParmsKey,
							age_desc##1,
							age_desc##2,
							age_desc##3,
							age_desc##4,
							age_desc##5
							FROM   arparms_all
							WHERE  site_ref = {0}
							AND arparms_key = 0) AS P UNPIVOT (AgingTitle FOR AgeDays IN (age_desc##1, age_desc##2, age_desc##3, age_desc##4, age_desc##5)) AS unpvt2) AS t2
					ON t1.SiteRef = t2.SiteRef
					AND t1.ParmsKey = t2.ParmsKey
					AND t1.[Order] = t2.[Order]", SiteRef, CustNum));

            return this.appDB.Load(_1LoadRequest);
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_CLM_DunningCustAgingBasisSp(
            string AltExtGenSp,
            string CustNum = null,
            string SiteRef = null)
        {
            CustNumType _CustNum = CustNum;
            SiteType _SiteRef = SiteRef;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);

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

//PROJECT NAME: Production
//CLASS NAME: PmfRptSelectSessPnsCRUD.cs

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

namespace CSI.Production.ProcessManufacturing
{
    public class PmfRptSelectSessPnsCRUD : IPmfRptSelectSessPnsCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;

        public PmfRptSelectSessPnsCRUD(IApplicationDB appDB,
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('PmfRptSelectSessPnsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('PmfRptSelectSessPnsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("PmfRptSelectSessPnsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

        public ICollectionLoadResponse Vpmfrptpn1Select(Guid? SessionId, int? Seq)
        {
            var vPmfRptPn1LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"pn.production_id","pn.production_id"},
                    {"pn.suffix","pn.suffix"},
                    {"pn.mfg_class","pn.mfg_class"},
                    {"pn.mfg_sub_class","pn.mfg_sub_class"},
                    {"pn.ProdOrdered","pn.ProdOrdered"},
                    {"pn.ProdItem","pn.ProdItem"},
                    {"pn.JobRp","pn.JobRp"},
                    {"pn.formula_id","pn.formula_id"},
                    {"pn.formula_version","pn.formula_version"},
                    {"pn.fm_revision_num","pn.fm_revision_num"},
                    {"pn.total_gross_weight","pn.total_gross_weight"},
                    {"pn.total_gross_volume","pn.total_gross_volume"},
                    {"pn_batch_sequence","pn.sequence"},
                    {"pn.SessionId","pn.SessionId"},
                    {"row_cnt","ROW_NUMBER() OVER (PARTITION BY production_id ORDER BY production_id)"},
                    {"total_cnt","COUNT(production_id) OVER (PARTITION BY production_id)"},
                    {"pn.job","pn.job"},
                    {"pn.description","pn.description" },
                    {"pn.mfg_specification_id", "pn.mfg_specification_id"},
                    {"pn.mfg_specification_version", "pn.mfg_specification_version"},
                },
                selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList
					FROM vPmfRptPn AS pn
					WHERE SessionId = {0}
					AND sequence = {1}
					ORDER BY pn.production_id, pn.job, pn.suffix DESC", SessionId, Seq));

            return this.appDB.Load(vPmfRptPn1LoadRequest);
        }

        public ICollectionLoadResponse Pmf_Tmp_Rpt_PnSelect(Guid? SessionId, int? Seq)
        {
            var pmf_tmp_rpt_pnLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SessionId","SessionId"},
                    {"sequence","sequence"},
                },
                loadForChange: true,
                lockingType: LockingType.None,
                tableName: "pmf_tmp_rpt_pn",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("SessionId = {0} AND sequence = {1}", SessionId, Seq),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(pmf_tmp_rpt_pnLoadRequest);
        }

        public void Pmf_Tmp_Rpt_PnDelete(ICollectionLoadResponse pmf_tmp_rpt_pnLoadResponse)
        {
            var pmf_tmp_rpt_pnDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "pmf_tmp_rpt_pn",
                items: pmf_tmp_rpt_pnLoadResponse.Items);
            this.appDB.Delete(pmf_tmp_rpt_pnDeleteRequest);
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_PmfRptSelectSessPnsSp(
            string AltExtGenSp,
            Guid? SessionId,
            int? Seq,
            int? ClearSess = 0)
        {
            RowPointerType _SessionId = SessionId;
            IntType _Seq = Seq;
            IntType _ClearSess = ClearSess;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ClearSess", _ClearSess, ParameterDirection.Input);

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
